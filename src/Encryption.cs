﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TL;

namespace WTelegram
{
	internal static class Encryption
	{
		internal static readonly RNGCryptoServiceProvider RNG = new();
		private static readonly Dictionary<long, RSAPublicKey> PublicKeys = new();

		internal static async Task CreateAuthorizationKey(Client client, Session session)
		{
			if (PublicKeys.Count == 0) LoadDefaultPublicKey();

			//1)
			var reqPQ = new Fn.ReqPQ() { nonce = new Int128(RNG) };
			await client.SendAsync(reqPQ, false);
			//2)
			var reply = await client.RecvInternalAsync();
			if (reply is not ResPQ resPQ) throw new ApplicationException($"Expected ResPQ but got {reply.GetType().Name}");
			if (resPQ.nonce != reqPQ.nonce) throw new ApplicationException("Nonce mismatch");
			var fingerprint = resPQ.server_public_key_fingerprints.FirstOrDefault(PublicKeys.ContainsKey);
			if (fingerprint == 0) throw new ApplicationException("Couldn't match any server_public_key_fingerprints");
			Helpers.Log(2, $"Selected public key with fingerprint {fingerprint:X}");
			//3)
			long retry_id = 0;
			ulong pq = Helpers.FromBigEndian(resPQ.pq);
			ulong p = Helpers.PQFactorize(pq);
			ulong q = pq / p;
			//4)
			var new_nonce = new Int256(RNG);
			var reqDHparams = MakeReqDHparam(fingerprint, PublicKeys[fingerprint], new PQInnerData
			{
				pq = resPQ.pq,
				p = Helpers.ToBigEndian(p),
				q = Helpers.ToBigEndian(q),
				nonce = resPQ.nonce,
				server_nonce = resPQ.server_nonce,
				new_nonce = new_nonce,
			});
			await client.SendAsync(reqDHparams, false);
			//5)
			reply = await client.RecvInternalAsync();
			if (reply is not ServerDHParams serverDHparams) throw new ApplicationException($"Expected ServerDHParams but got {reply.GetType().Name}");
			var localTime = DateTimeOffset.UtcNow;
			if (serverDHparams is not ServerDHParamsOk serverDHparamsOk) throw new ApplicationException("not server_DH_params_ok");
			if (serverDHparamsOk.nonce != resPQ.nonce) throw new ApplicationException("Nonce mismatch");
			if (serverDHparamsOk.server_nonce != resPQ.server_nonce) throw new ApplicationException("Server Nonce mismatch");
			var (tmp_aes_key, tmp_aes_iv) = ConstructTmpAESKeyIV(resPQ.server_nonce, new_nonce);
			var answer = AES_IGE_EncryptDecrypt(serverDHparamsOk.encrypted_answer, tmp_aes_key, tmp_aes_iv, false);

			using var encryptedReader = new BinaryReader(new MemoryStream(answer));
			var answerHash = encryptedReader.ReadBytes(20);
			var answerObj = Schema.DeserializeValue(encryptedReader, typeof(object));
			if (answerObj is not ServerDHInnerData serverDHinnerData) throw new ApplicationException("not server_DH_inner_data");
			long padding = encryptedReader.BaseStream.Length - encryptedReader.BaseStream.Position;
			if (padding >= 16) throw new ApplicationException("Too much pad");
			if (!Enumerable.SequenceEqual(SHA.SHA1.ComputeHash(answer, 20, answer.Length - (int)padding), answerHash))
				throw new ApplicationException("Answer SHA1 mismatch");
			if (serverDHinnerData.nonce != resPQ.nonce) throw new ApplicationException("Nonce mismatch");
			if (serverDHinnerData.server_nonce != resPQ.server_nonce) throw new ApplicationException("Server Nonce mismatch");
			var g_a = new BigInteger(serverDHinnerData.g_a, true, true);
			var dh_prime = new BigInteger(serverDHinnerData.dh_prime, true, true);
			ValidityChecks(dh_prime, serverDHinnerData.g);
			Helpers.Log(1, $"Server time: {serverDHinnerData.server_time} UTC");
			session.ServerTicksOffset = (serverDHinnerData.server_time - localTime).Ticks;

			//6)
			var bData = new byte[256];
			RNG.GetBytes(bData);
			var b = new BigInteger(bData, true, true);
			var g_b = BigInteger.ModPow(serverDHinnerData.g, b, dh_prime);
			var setClientDHparams = MakeClientDHparams(tmp_aes_key, tmp_aes_iv, new ClientDHInnerData
			{
				nonce = resPQ.nonce,
				server_nonce = resPQ.server_nonce,
				retry_id = retry_id,
				g_b = g_b.ToByteArray(true, true)
			});
			await client.SendAsync(setClientDHparams, false);

			//7)
			var gab = BigInteger.ModPow(g_a, b, dh_prime);
			var authKey = gab.ToByteArray(true, true);

			//8)
			var authKeyHash = SHA.SHA1.ComputeHash(authKey);
			retry_id = BinaryPrimitives.ReadInt64LittleEndian(authKeyHash); // (auth_key_aux_hash)
			//9)
			reply = await client.RecvInternalAsync();
			if (reply is not SetClientDHParamsAnswer setClientDHparamsAnswer) throw new ApplicationException($"Expected SetClientDHParamsAnswer but got {reply.GetType().Name}");
			if (setClientDHparamsAnswer is not DHGenOk) throw new ApplicationException("not dh_gen_ok");
			if (setClientDHparamsAnswer.nonce != resPQ.nonce) throw new ApplicationException("Nonce mismatch");
			if (setClientDHparamsAnswer.server_nonce != resPQ.server_nonce) throw new ApplicationException("Server Nonce mismatch");
			var expected_new_nonceN = new byte[32 + 1 + 8];
			new_nonce.raw.CopyTo(expected_new_nonceN, 0);
			expected_new_nonceN[32] = 1;
			Array.Copy(authKeyHash, 0, expected_new_nonceN, 33, 8); // (auth_key_aux_hash)
			if (!Enumerable.SequenceEqual(setClientDHparamsAnswer.new_nonce_hashN.raw, SHA.SHA1.ComputeHash(expected_new_nonceN).Skip(4)))
				throw new ApplicationException("setClientDHparamsAnswer.new_nonce_hashN mismatch");

			session.AuthKeyID = BinaryPrimitives.ReadInt64LittleEndian(authKeyHash.AsSpan(12));
			session.AuthKey = authKey;
			session.Salt = BinaryPrimitives.ReadInt64LittleEndian(new_nonce.raw) ^ BinaryPrimitives.ReadInt64LittleEndian(resPQ.server_nonce.raw);
			session.Save();

			static (byte[] key, byte[] iv) ConstructTmpAESKeyIV(Int128 server_nonce, Int256 new_nonce)
			{
				byte[] tmp_aes_key = new byte[32], tmp_aes_iv = new byte[32];
				using var sha1 = new SHA1Managed();
				sha1.TransformBlock(new_nonce, 0, 32, null, 0);
				sha1.TransformFinalBlock(server_nonce, 0, 16);
				sha1.Hash.CopyTo(tmp_aes_key, 0);                   // tmp_aes_key := SHA1(new_nonce + server_nonce)
				sha1.TransformBlock(server_nonce, 0, 16, null, 0);
				sha1.TransformFinalBlock(new_nonce, 0, 32);
				Array.Copy(sha1.Hash, 0, tmp_aes_key, 20, 12);      //              + SHA1(server_nonce, new_nonce)[0:12]
				Array.Copy(sha1.Hash, 12, tmp_aes_iv, 0, 8);        // tmp_aes_iv  != SHA1(server_nonce, new_nonce)[12:8]
				sha1.TransformBlock(new_nonce, 0, 32, null, 0);
				sha1.TransformFinalBlock(new_nonce, 0, 32);
				sha1.Hash.CopyTo(tmp_aes_iv, 8);                    //              + SHA(new_nonce + new_nonce)
				Array.Copy(new_nonce, 0, tmp_aes_iv, 28, 4);        //              + new_nonce[0:4]
				return (tmp_aes_key, tmp_aes_iv);
			}
		}

		private static void ValidityChecks(BigInteger p, int g)
		{
			//TODO: check whether p is a safe prime (meaning that both p and (p - 1) / 2 are prime)
			// check that 2^2047 <= p < 2^2048
			if (p.GetBitLength() != 2048) throw new ApplicationException("p is not 2048-bit number");
			// check that g generates a cyclic subgroup of prime order (p - 1) / 2, i.e. is a quadratic residue mod p.
			BigInteger mod_r;
			if (g switch
			{
				2 => p % 8 != 7,
				3 => p % 3 != 2,
				4 => false,
				5 => (mod_r = p % 5) != 1 && mod_r != 4,
				6 => (mod_r = p % 24) != 19 && mod_r != 23,
				7 => (mod_r = p % 7) != 3 && mod_r != 5 && mod_r != 6,
				_ => true,
			})
				throw new ApplicationException("Bad prime mod 4g");
			//TODO: check that g, g_a and g_b are greater than 1 and less than dh_prime - 1.
			// We recommend checking that g_a and g_b are between 2^{2048-64} and dh_prime - 2^{2048-64} as well.
		}

		private static Fn.ReqDHParams MakeReqDHparam(long publicKey_fingerprint, RSAPublicKey publicKey, PQInnerData pqInnerData)
		{
			// the following code was the way TDLib did it (and seems still accepted) until they changed on 8 July 2021
			using var clearStream = new MemoryStream(255);
			clearStream.Position = 20; // skip SHA1 area (to be patched)
			using var writer = new BinaryWriter(clearStream, Encoding.UTF8);
			Schema.Serialize(writer, pqInnerData);
			int clearLength = (int)clearStream.Length;  // length before padding (= 20 + message_data_length)
			if (clearLength > 255) throw new ApplicationException("PQInnerData too big");
			byte[] clearBuffer = clearStream.GetBuffer();
			RNG.GetBytes(clearBuffer, clearLength, 255 - clearLength);
			clearBuffer = SHA.SHA1.ComputeHash(clearBuffer, 20, clearLength); // patch with SHA1

			var encrypted_data = BigInteger.ModPow(new BigInteger(clearBuffer, true, true), // encrypt with RSA key
				new BigInteger(publicKey.e, true, true), new BigInteger(publicKey.n, true, true)).ToByteArray(true, true);
			return new Fn.ReqDHParams
			{
				nonce = pqInnerData.nonce,
				server_nonce = pqInnerData.server_nonce,
				p = pqInnerData.p,
				q = pqInnerData.q,
				public_key_fingerprint = publicKey_fingerprint,
				encrypted_data = encrypted_data
			};
		}

		private static Fn.SetClientDHParams MakeClientDHparams(byte[] tmp_aes_key, byte[] tmp_aes_iv, ClientDHInnerData clientDHinnerData)
		{
			// the following code was the way TDLib did it (and seems still accepted) until they changed on 8 July 2021
			using var clearStream = new MemoryStream(384);
			clearStream.Position = 20; // skip SHA1 area (to be patched)
			using var writer = new BinaryWriter(clearStream, Encoding.UTF8);
			Schema.Serialize(writer, clientDHinnerData);
			int clearLength = (int)clearStream.Length;  // length before padding (= 20 + message_data_length)
			int padding = (0x7FFFFFF0 - clearLength) % 16;
			clearStream.SetLength(clearLength + padding);
			byte[] clearBuffer = clearStream.GetBuffer();
			RNG.GetBytes(clearBuffer, clearLength, padding);
			clearBuffer = SHA.SHA1.ComputeHash(clearBuffer, 20, clearLength);

			var encrypted_data = AES_IGE_EncryptDecrypt(clearBuffer.AsSpan(0, clearLength + padding), tmp_aes_key, tmp_aes_iv, true);
			return new Fn.SetClientDHParams
			{
				nonce = clientDHinnerData.nonce,
				server_nonce = clientDHinnerData.server_nonce,
				encrypted_data = encrypted_data
			};
		}

		public static void LoadPublicKey(string pem)
		{
			using var rsa = RSA.Create();
			rsa.ImportFromPem(pem);
			var rsaParam = rsa.ExportParameters(false);
			var publicKey = new RSAPublicKey { n = rsaParam.Modulus, e = rsaParam.Exponent };
			var bareData = Schema.Serialize(publicKey); // bare serialization
			var fingerprint = BinaryPrimitives.ReadInt64LittleEndian(SHA.SHA1.ComputeHash(bareData, 4, bareData.Length - 4).AsSpan(12)); // 64 lower-order bits of SHA1
			PublicKeys[fingerprint] = publicKey;
			Helpers.Log(1, $"Loaded a public key with fingerprint {fingerprint:X}");
		}

		private static void LoadDefaultPublicKey() // fingerprint C3B42B026CE86B21
		{
			LoadPublicKey(@"-----BEGIN RSA PUBLIC KEY-----
MIIBCgKCAQEAwVACPi9w23mF3tBkdZz+zwrzKOaaQdr01vAbU4E1pvkfj4sqDsm6
lyDONS789sVoD/xCS9Y0hkkC3gtL1tSfTlgCMOOul9lcixlEKzwKENj1Yz/s7daS
an9tqw3bfUV/nqgbhGX81v/+7RFAEd+RwFnK7a+XYl9sluzHRyVVaTTveB2GazTw
Efzk2DWgkBluml8OREmvfraX3bkHZJTKX4EQSjBbbdJ2ZXIsRrYOXfaA+xayEGB+
8hdlLmAjbCVfaigxX0CDqWeR1yFL9kwd9P0NsZRPsmoqVwMbMu7mStFai6aIhc3n
Slv8kg9qv1m6XHVQY3PnEw+QQtqSIXklHwIDAQAB
-----END RSA PUBLIC KEY-----");
		}

		internal static byte[] EncryptDecryptMessage(Span<byte> input, bool encrypt, byte[] authKey, byte[] clearSha1)
		{
			// first, construct AES key & IV
			int x = encrypt ? 0 : 8;
			byte[] aes_key = new byte[32], aes_iv = new byte[32];
			using var sha1 = new SHA1Managed();
			sha1.TransformBlock(clearSha1, 4, 16, null, 0);     // msgKey
			sha1.TransformFinalBlock(authKey, x, 32);           // authKey[x:32]
			var sha1_a = sha1.Hash;
			sha1.TransformBlock(authKey, 32 + x, 16, null, 0);  // authKey[32+x:16]
			sha1.TransformBlock(clearSha1, 4, 16, null, 0);     // msgKey
			sha1.TransformFinalBlock(authKey, 48 + x, 16);      // authKey[48+x:16]
			var sha1_b = sha1.Hash;
			sha1.TransformBlock(authKey, 64 + x, 32, null, 0);  // authKey[64+x:32]
			sha1.TransformFinalBlock(clearSha1, 4, 16);         // msgKey
			var sha1_c = sha1.Hash;
			sha1.TransformBlock(clearSha1, 4, 16, null, 0);     // msgKey
			sha1.TransformFinalBlock(authKey, 96 + x, 32);      // authKey[96+x:32]
			var sha1_d = sha1.Hash;
			Array.Copy(sha1_a, 0, aes_key, 0, 8);
			Array.Copy(sha1_b, 8, aes_key, 8, 12);
			Array.Copy(sha1_c, 4, aes_key, 20, 12);
			Array.Copy(sha1_a, 8, aes_iv, 0, 12);
			Array.Copy(sha1_b, 0, aes_iv, 12, 8);
			Array.Copy(sha1_c, 16, aes_iv, 20, 4);
			Array.Copy(sha1_d, 0, aes_iv, 24, 8);

			return AES_IGE_EncryptDecrypt(input, aes_key, aes_iv, encrypt);
		}

		private static byte[] AES_IGE_EncryptDecrypt(Span<byte> input, byte[] aes_key, byte[] aes_iv, bool encrypt)
		{
			using var aes = Aes.Create();
			aes.Mode = CipherMode.ECB;
			aes.Padding = PaddingMode.Zeros;
			if (aes.BlockSize != 128) throw new ApplicationException("AES Blocksize is not 16 bytes");
			if (input.Length % 16 != 0) throw new ApplicationException("intput size not divisible by 16");

			// code adapted from PHP implementation found at https://mgp25.com/AESIGE/
			var output = new byte[input.Length];
			var xPrev = aes_iv.AsSpan(encrypt ? 16 : 0, 16);
			var yPrev = aes_iv.AsSpan(encrypt ? 0 : 16, 16);
			var aesCrypto = encrypt ? aes.CreateEncryptor(aes_key, null) : aes.CreateDecryptor(aes_key, null);
			using (aesCrypto)
			{
				byte[] yXOR = new byte[16];
				for (int i = 0; i < input.Length; i += 16)
				{
					var x = input.Slice(i, 16);
					var y = output.AsSpan(i, 16);
					for (int j = 0; j < 16; j++)
						yXOR[j] = (byte)(x[j] ^ yPrev[j]);
					var yFinal = aesCrypto.TransformFinalBlock(yXOR, 0, 16);
					for (int j = 0; j < 16; j++)
						y[j] = (byte)(yFinal[j] ^ xPrev[j]);
					xPrev = x;
					yPrev = y;
				}
			}
			return output;
		}
	}
}
