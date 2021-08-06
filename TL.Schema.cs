using System;

namespace TL
{
	[TLDef(0x3FEDD339, "true#3fedd339 = True")]
	public class True : ITLObject { }

	[TLDef(0xC4B9F9BB, "error#c4b9f9bb code:int text:string = Error")]
	public class Error : ITLObject
	{
		public int code;
		public string text;
	}

	[TLDef(0x56730BCC, "null#56730bcc = Null")]
	public class Null : ITLObject { }

	public abstract class InputPeer : ITLObject { }
	[TLDef(0x7F3B18EA, "inputPeerEmpty#7f3b18ea = InputPeer")]
	public class InputPeerEmpty : InputPeer { }
	[TLDef(0x7DA07EC9, "inputPeerSelf#7da07ec9 = InputPeer")]
	public class InputPeerSelf : InputPeer { }
	[TLDef(0x179BE863, "inputPeerChat#179be863 chat_id:int = InputPeer")]
	public class InputPeerChat : InputPeer { public int chat_id; }
	[TLDef(0x7B8E7DE6, "inputPeerUser#7b8e7de6 user_id:int access_hash:long = InputPeer")]
	public class InputPeerUser : InputPeer
	{
		public int user_id;
		public long access_hash;
	}
	[TLDef(0x20ADAEF8, "inputPeerChannel#20adaef8 channel_id:int access_hash:long = InputPeer")]
	public class InputPeerChannel : InputPeer
	{
		public int channel_id;
		public long access_hash;
	}
	[TLDef(0x17BAE2E6, "inputPeerUserFromMessage#17bae2e6 peer:InputPeer msg_id:int user_id:int = InputPeer")]
	public class InputPeerUserFromMessage : InputPeer
	{
		public InputPeer peer;
		public int msg_id;
		public int user_id;
	}
	[TLDef(0x9C95F7BB, "inputPeerChannelFromMessage#9c95f7bb peer:InputPeer msg_id:int channel_id:int = InputPeer")]
	public class InputPeerChannelFromMessage : InputPeer
	{
		public InputPeer peer;
		public int msg_id;
		public int channel_id;
	}

	public abstract class InputUserBase : ITLObject { }
	[TLDef(0xB98886CF, "inputUserEmpty#b98886cf = InputUser")]
	public class InputUserEmpty : InputUserBase { }
	[TLDef(0xF7C1B13F, "inputUserSelf#f7c1b13f = InputUser")]
	public class InputUserSelf : InputUserBase { }
	[TLDef(0xD8292816, "inputUser#d8292816 user_id:int access_hash:long = InputUser")]
	public class InputUser : InputUserBase
	{
		public int user_id;
		public long access_hash;
	}
	[TLDef(0x2D117597, "inputUserFromMessage#2d117597 peer:InputPeer msg_id:int user_id:int = InputUser")]
	public class InputUserFromMessage : InputUserBase
	{
		public InputPeer peer;
		public int msg_id;
		public int user_id;
	}

	public abstract class InputContact : ITLObject { }
	[TLDef(0xF392B7F4, "inputPhoneContact#f392b7f4 client_id:long phone:string first_name:string last_name:string = InputContact")]
	public class InputPhoneContact : InputContact
	{
		public long client_id;
		public string phone;
		public string first_name;
		public string last_name;
	}

	public abstract class InputFileBase : ITLObject { }
	[TLDef(0xF52FF27F, "inputFile#f52ff27f id:long parts:int name:string md5_checksum:string = InputFile")]
	public class InputFile : InputFileBase
	{
		public long id;
		public int parts;
		public string name;
		public byte[] md5_checksum;
	}
	[TLDef(0xFA4F0BB5, "inputFileBig#fa4f0bb5 id:long parts:int name:string = InputFile")]
	public class InputFileBig : InputFileBase
	{
		public long id;
		public int parts;
		public string name;
	}

	public abstract class InputMedia : ITLObject { }
	[TLDef(0x9664F57F, "inputMediaEmpty#9664f57f = InputMedia")]
	public class InputMediaEmpty : InputMedia { }
	[TLDef(0x1E287D04, "inputMediaUploadedPhoto#1e287d04 flags:# file:InputFile stickers:flags.0?Vector<InputDocument> ttl_seconds:flags.1?int = InputMedia")]
	public class InputMediaUploadedPhoto : InputMedia
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_ttl_seconds = 0x2 }
		public Flags flags;
		public InputFileBase file;
		[IfFlag(0)] public InputDocumentBase[] stickers;
		[IfFlag(1)] public int ttl_seconds;
	}
	[TLDef(0xB3BA0635, "inputMediaPhoto#b3ba0635 flags:# id:InputPhoto ttl_seconds:flags.0?int = InputMedia")]
	public class InputMediaPhoto : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public InputPhotoBase id;
		[IfFlag(0)] public int ttl_seconds;
	}
	[TLDef(0xF9C44144, "inputMediaGeoPoint#f9c44144 geo_point:InputGeoPoint = InputMedia")]
	public class InputMediaGeoPoint : InputMedia { public InputGeoPointBase geo_point; }
	[TLDef(0xF8AB7DFB, "inputMediaContact#f8ab7dfb phone_number:string first_name:string last_name:string vcard:string = InputMedia")]
	public class InputMediaContact : InputMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
	}
	[TLDef(0x5B38C6C1, "inputMediaUploadedDocument#5b38c6c1 flags:# nosound_video:flags.3?true force_file:flags.4?true file:InputFile thumb:flags.2?InputFile mime_type:string attributes:Vector<DocumentAttribute> stickers:flags.0?Vector<InputDocument> ttl_seconds:flags.1?int = InputMedia")]
	public class InputMediaUploadedDocument : InputMedia
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_ttl_seconds = 0x2, has_thumb = 0x4, nosound_video = 0x8, force_file = 0x10 }
		public Flags flags;
		public InputFileBase file;
		[IfFlag(2)] public InputFileBase thumb;
		public string mime_type;
		public DocumentAttribute[] attributes;
		[IfFlag(0)] public InputDocumentBase[] stickers;
		[IfFlag(1)] public int ttl_seconds;
	}
	[TLDef(0x23AB23D2, "inputMediaDocument#23ab23d2 flags:# id:InputDocument ttl_seconds:flags.0?int = InputMedia")]
	public class InputMediaDocument : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public InputDocumentBase id;
		[IfFlag(0)] public int ttl_seconds;
	}
	[TLDef(0xC13D1C11, "inputMediaVenue#c13d1c11 geo_point:InputGeoPoint title:string address:string provider:string venue_id:string venue_type:string = InputMedia")]
	public class InputMediaVenue : InputMedia
	{
		public InputGeoPointBase geo_point;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
	}
	[TLDef(0xE5BBFE1A, "inputMediaPhotoExternal#e5bbfe1a flags:# url:string ttl_seconds:flags.0?int = InputMedia")]
	public class InputMediaPhotoExternal : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public string url;
		[IfFlag(0)] public int ttl_seconds;
	}
	[TLDef(0xFB52DC99, "inputMediaDocumentExternal#fb52dc99 flags:# url:string ttl_seconds:flags.0?int = InputMedia")]
	public class InputMediaDocumentExternal : InputMedia
	{
		[Flags] public enum Flags { has_ttl_seconds = 0x1 }
		public Flags flags;
		public string url;
		[IfFlag(0)] public int ttl_seconds;
	}
	[TLDef(0xD33F43F3, "inputMediaGame#d33f43f3 id:InputGame = InputMedia")]
	public class InputMediaGame : InputMedia { public InputGame id; }
	[TLDef(0xF4E096C3, "inputMediaInvoice#f4e096c3 flags:# title:string description:string photo:flags.0?InputWebDocument invoice:Invoice payload:bytes provider:string provider_data:DataJSON start_param:string = InputMedia")]
	public class InputMediaInvoice : InputMedia
	{
		[Flags] public enum Flags { has_photo = 0x1 }
		public Flags flags;
		public string title;
		public string description;
		[IfFlag(0)] public InputWebDocument photo;
		public Invoice invoice;
		public byte[] payload;
		public string provider;
		public DataJSON provider_data;
		public string start_param;
	}
	[TLDef(0x971FA843, "inputMediaGeoLive#971fa843 flags:# stopped:flags.0?true geo_point:InputGeoPoint heading:flags.2?int period:flags.1?int proximity_notification_radius:flags.3?int = InputMedia")]
	public class InputMediaGeoLive : InputMedia
	{
		[Flags] public enum Flags { stopped = 0x1, has_period = 0x2, has_heading = 0x4, has_proximity_notification_radius = 0x8 }
		public Flags flags;
		public InputGeoPointBase geo_point;
		[IfFlag(2)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
	}
	[TLDef(0xF94E5F1, "inputMediaPoll#0f94e5f1 flags:# poll:Poll correct_answers:flags.0?Vector<bytes> solution:flags.1?string solution_entities:flags.1?Vector<MessageEntity> = InputMedia")]
	public class InputMediaPoll : InputMedia
	{
		[Flags] public enum Flags { has_correct_answers = 0x1, has_solution = 0x2 }
		public Flags flags;
		public Poll poll;
		[IfFlag(0)] public byte[][] correct_answers;
		[IfFlag(1)] public string solution;
		[IfFlag(1)] public MessageEntity[] solution_entities;
	}
	[TLDef(0xE66FBF7B, "inputMediaDice#e66fbf7b emoticon:string = InputMedia")]
	public class InputMediaDice : InputMedia { public string emoticon; }

	public abstract class InputChatPhotoBase : ITLObject { }
	[TLDef(0x1CA48F57, "inputChatPhotoEmpty#1ca48f57 = InputChatPhoto")]
	public class InputChatPhotoEmpty : InputChatPhotoBase { }
	[TLDef(0xC642724E, "inputChatUploadedPhoto#c642724e flags:# file:flags.0?InputFile video:flags.1?InputFile video_start_ts:flags.2?double = InputChatPhoto")]
	public class InputChatUploadedPhoto : InputChatPhotoBase
	{
		[Flags] public enum Flags { has_file = 0x1, has_video = 0x2, has_video_start_ts = 0x4 }
		public Flags flags;
		[IfFlag(0)] public InputFileBase file;
		[IfFlag(1)] public InputFileBase video;
		[IfFlag(2)] public double video_start_ts;
	}
	[TLDef(0x8953AD37, "inputChatPhoto#8953ad37 id:InputPhoto = InputChatPhoto")]
	public class InputChatPhoto : InputChatPhotoBase { public InputPhotoBase id; }

	public abstract class InputGeoPointBase : ITLObject { }
	[TLDef(0xE4C123D6, "inputGeoPointEmpty#e4c123d6 = InputGeoPoint")]
	public class InputGeoPointEmpty : InputGeoPointBase { }
	[TLDef(0x48222FAF, "inputGeoPoint#48222faf flags:# lat:double long:double accuracy_radius:flags.0?int = InputGeoPoint")]
	public class InputGeoPoint : InputGeoPointBase
	{
		[Flags] public enum Flags { has_accuracy_radius = 0x1 }
		public Flags flags;
		public double lat;
		public double long_;
		[IfFlag(0)] public int accuracy_radius;
	}

	public abstract class InputPhotoBase : ITLObject { }
	[TLDef(0x1CD7BF0D, "inputPhotoEmpty#1cd7bf0d = InputPhoto")]
	public class InputPhotoEmpty : InputPhotoBase { }
	[TLDef(0x3BB3B94A, "inputPhoto#3bb3b94a id:long access_hash:long file_reference:bytes = InputPhoto")]
	public class InputPhoto : InputPhotoBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
	}

	public abstract class InputFileLocationBase : ITLObject { }
	[TLDef(0xDFDAABE1, "inputFileLocation#dfdaabe1 volume_id:long local_id:int secret:long file_reference:bytes = InputFileLocation")]
	public class InputFileLocation : InputFileLocationBase
	{
		public long volume_id;
		public int local_id;
		public long secret;
		public byte[] file_reference;
	}
	[TLDef(0xF5235D55, "inputEncryptedFileLocation#f5235d55 id:long access_hash:long = InputFileLocation")]
	public class InputEncryptedFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0xBAD07584, "inputDocumentFileLocation#bad07584 id:long access_hash:long file_reference:bytes thumb_size:string = InputFileLocation")]
	public class InputDocumentFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public string thumb_size;
	}
	[TLDef(0xCBC7EE28, "inputSecureFileLocation#cbc7ee28 id:long access_hash:long = InputFileLocation")]
	public class InputSecureFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0x29BE5899, "inputTakeoutFileLocation#29be5899 = InputFileLocation")]
	public class InputTakeoutFileLocation : InputFileLocationBase { }
	[TLDef(0x40181FFE, "inputPhotoFileLocation#40181ffe id:long access_hash:long file_reference:bytes thumb_size:string = InputFileLocation")]
	public class InputPhotoFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public string thumb_size;
	}
	[TLDef(0xD83466F3, "inputPhotoLegacyFileLocation#d83466f3 id:long access_hash:long file_reference:bytes volume_id:long local_id:int secret:long = InputFileLocation")]
	public class InputPhotoLegacyFileLocation : InputFileLocationBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public long volume_id;
		public int local_id;
		public long secret;
	}
	[TLDef(0x27D69997, "inputPeerPhotoFileLocation#27d69997 flags:# big:flags.0?true peer:InputPeer volume_id:long local_id:int = InputFileLocation")]
	public class InputPeerPhotoFileLocation : InputFileLocationBase
	{
		[Flags] public enum Flags { big = 0x1 }
		public Flags flags;
		public InputPeer peer;
		public long volume_id;
		public int local_id;
	}
	[TLDef(0xDBAEAE9, "inputStickerSetThumb#0dbaeae9 stickerset:InputStickerSet volume_id:long local_id:int = InputFileLocation")]
	public class InputStickerSetThumb : InputFileLocationBase
	{
		public InputStickerSet stickerset;
		public long volume_id;
		public int local_id;
	}

	public abstract class Peer : ITLObject { }
	[TLDef(0x9DB1BC6D, "peerUser#9db1bc6d user_id:int = Peer")]
	public class PeerUser : Peer { public int user_id; }
	[TLDef(0xBAD0E5BB, "peerChat#bad0e5bb chat_id:int = Peer")]
	public class PeerChat : Peer { public int chat_id; }
	[TLDef(0xBDDDE532, "peerChannel#bddde532 channel_id:int = Peer")]
	public class PeerChannel : Peer { public int channel_id; }

	public abstract class Storage_FileType : ITLObject { }
	[TLDef(0xAA963B05, "storage.fileUnknown#aa963b05 = storage.FileType")]
	public class Storage_FileUnknown : Storage_FileType { }
	[TLDef(0x40BC6F52, "storage.filePartial#40bc6f52 = storage.FileType")]
	public class Storage_FilePartial : Storage_FileType { }
	[TLDef(0x7EFE0E, "storage.fileJpeg#007efe0e = storage.FileType")]
	public class Storage_FileJpeg : Storage_FileType { }
	[TLDef(0xCAE1AADF, "storage.fileGif#cae1aadf = storage.FileType")]
	public class Storage_FileGif : Storage_FileType { }
	[TLDef(0xA4F63C0, "storage.filePng#0a4f63c0 = storage.FileType")]
	public class Storage_FilePng : Storage_FileType { }
	[TLDef(0xAE1E508D, "storage.filePdf#ae1e508d = storage.FileType")]
	public class Storage_FilePdf : Storage_FileType { }
	[TLDef(0x528A0677, "storage.fileMp3#528a0677 = storage.FileType")]
	public class Storage_FileMp3 : Storage_FileType { }
	[TLDef(0x4B09EBBC, "storage.fileMov#4b09ebbc = storage.FileType")]
	public class Storage_FileMov : Storage_FileType { }
	[TLDef(0xB3CEA0E4, "storage.fileMp4#b3cea0e4 = storage.FileType")]
	public class Storage_FileMp4 : Storage_FileType { }
	[TLDef(0x1081464C, "storage.fileWebp#1081464c = storage.FileType")]
	public class Storage_FileWebp : Storage_FileType { }

	public abstract class UserBase : ITLObject { }
	[TLDef(0x200250BA, "userEmpty#200250ba id:int = User")]
	public class UserEmpty : UserBase { public int id; }
	[TLDef(0x938458C1, "user#938458c1 flags:# self:flags.10?true contact:flags.11?true mutual_contact:flags.12?true deleted:flags.13?true bot:flags.14?true bot_chat_history:flags.15?true bot_nochats:flags.16?true verified:flags.17?true restricted:flags.18?true min:flags.20?true bot_inline_geo:flags.21?true support:flags.23?true scam:flags.24?true apply_min_photo:flags.25?true id:int access_hash:flags.0?long first_name:flags.1?string last_name:flags.2?string username:flags.3?string phone:flags.4?string photo:flags.5?UserProfilePhoto status:flags.6?UserStatus bot_info_version:flags.14?int restriction_reason:flags.18?Vector<RestrictionReason> bot_inline_placeholder:flags.19?string lang_code:flags.22?string = User")]
	public class User : UserBase
	{
		[Flags] public enum Flags { has_access_hash = 0x1, has_first_name = 0x2, has_last_name = 0x4, has_username = 0x8, 
			has_phone = 0x10, has_photo = 0x20, has_status = 0x40, self = 0x400, contact = 0x800, mutual_contact = 0x1000, 
			deleted = 0x2000, bot = 0x4000, bot_chat_history = 0x8000, bot_nochats = 0x10000, verified = 0x20000, restricted = 0x40000, 
			has_bot_inline_placeholder = 0x80000, min = 0x100000, bot_inline_geo = 0x200000, has_lang_code = 0x400000, support = 0x800000, 
			scam = 0x1000000, apply_min_photo = 0x2000000 }
		public Flags flags;
		public int id;
		[IfFlag(0)] public long access_hash;
		[IfFlag(1)] public string first_name;
		[IfFlag(2)] public string last_name;
		[IfFlag(3)] public string username;
		[IfFlag(4)] public string phone;
		[IfFlag(5)] public UserProfilePhotoBase photo;
		[IfFlag(6)] public UserStatus status;
		[IfFlag(14)] public int bot_info_version;
		[IfFlag(18)] public RestrictionReason[] restriction_reason;
		[IfFlag(19)] public string bot_inline_placeholder;
		[IfFlag(22)] public string lang_code;
	}

	public abstract class UserProfilePhotoBase : ITLObject { }
	[TLDef(0x4F11BAE1, "userProfilePhotoEmpty#4f11bae1 = UserProfilePhoto")]
	public class UserProfilePhotoEmpty : UserProfilePhotoBase { }
	[TLDef(0x69D3AB26, "userProfilePhoto#69d3ab26 flags:# has_video:flags.0?true photo_id:long photo_small:FileLocation photo_big:FileLocation dc_id:int = UserProfilePhoto")]
	public class UserProfilePhoto : UserProfilePhotoBase
	{
		[Flags] public enum Flags { has_video = 0x1 }
		public Flags flags;
		public long photo_id;
		public FileLocation photo_small;
		public FileLocation photo_big;
		public int dc_id;
	}

	public abstract class UserStatus : ITLObject { }
	[TLDef(0x9D05049, "userStatusEmpty#09d05049 = UserStatus")]
	public class UserStatusEmpty : UserStatus { }
	[TLDef(0xEDB93949, "userStatusOnline#edb93949 expires:int = UserStatus")]
	public class UserStatusOnline : UserStatus { public DateTime expires; }
	[TLDef(0x8C703F, "userStatusOffline#008c703f was_online:int = UserStatus")]
	public class UserStatusOffline : UserStatus { public int was_online; }
	[TLDef(0xE26F42F1, "userStatusRecently#e26f42f1 = UserStatus")]
	public class UserStatusRecently : UserStatus { }
	[TLDef(0x7BF09FC, "userStatusLastWeek#07bf09fc = UserStatus")]
	public class UserStatusLastWeek : UserStatus { }
	[TLDef(0x77EBC742, "userStatusLastMonth#77ebc742 = UserStatus")]
	public class UserStatusLastMonth : UserStatus { }

	public abstract class ChatBase : ITLObject { }
	[TLDef(0x9BA2D800, "chatEmpty#9ba2d800 id:int = Chat")]
	public class ChatEmpty : ChatBase { public int id; }
	[TLDef(0x3BDA1BDE, "chat#3bda1bde flags:# creator:flags.0?true kicked:flags.1?true left:flags.2?true deactivated:flags.5?true call_active:flags.23?true call_not_empty:flags.24?true id:int title:string photo:ChatPhoto participants_count:int date:int version:int migrated_to:flags.6?InputChannel admin_rights:flags.14?ChatAdminRights default_banned_rights:flags.18?ChatBannedRights = Chat")]
	public class Chat : ChatBase
	{
		[Flags] public enum Flags { creator = 0x1, kicked = 0x2, left = 0x4, deactivated = 0x20, has_migrated_to = 0x40, 
			has_admin_rights = 0x4000, has_default_banned_rights = 0x40000, call_active = 0x800000, call_not_empty = 0x1000000 }
		public Flags flags;
		public int id;
		public string title;
		public ChatPhotoBase photo;
		public int participants_count;
		public DateTime date;
		public int version;
		[IfFlag(6)] public InputChannelBase migrated_to;
		[IfFlag(14)] public ChatAdminRights admin_rights;
		[IfFlag(18)] public ChatBannedRights default_banned_rights;
	}
	[TLDef(0x7328BDB, "chatForbidden#07328bdb id:int title:string = Chat")]
	public class ChatForbidden : ChatBase
	{
		public int id;
		public string title;
	}
	[TLDef(0xD31A961E, "channel#d31a961e flags:# creator:flags.0?true left:flags.2?true broadcast:flags.5?true verified:flags.7?true megagroup:flags.8?true restricted:flags.9?true signatures:flags.11?true min:flags.12?true scam:flags.19?true has_link:flags.20?true has_geo:flags.21?true slowmode_enabled:flags.22?true call_active:flags.23?true call_not_empty:flags.24?true id:int access_hash:flags.13?long title:string username:flags.6?string photo:ChatPhoto date:int version:int restriction_reason:flags.9?Vector<RestrictionReason> admin_rights:flags.14?ChatAdminRights banned_rights:flags.15?ChatBannedRights default_banned_rights:flags.18?ChatBannedRights participants_count:flags.17?int = Chat")]
	public class Channel : ChatBase
	{
		[Flags] public enum Flags { creator = 0x1, left = 0x4, broadcast = 0x20, has_username = 0x40, verified = 0x80, 
			megagroup = 0x100, restricted = 0x200, signatures = 0x800, min = 0x1000, has_access_hash = 0x2000, has_admin_rights = 0x4000, 
			has_banned_rights = 0x8000, has_participants_count = 0x20000, has_default_banned_rights = 0x40000, scam = 0x80000, 
			has_link = 0x100000, has_geo = 0x200000, slowmode_enabled = 0x400000, call_active = 0x800000, call_not_empty = 0x1000000 }
		public Flags flags;
		public int id;
		[IfFlag(13)] public long access_hash;
		public string title;
		[IfFlag(6)] public string username;
		public ChatPhotoBase photo;
		public DateTime date;
		public int version;
		[IfFlag(9)] public RestrictionReason[] restriction_reason;
		[IfFlag(14)] public ChatAdminRights admin_rights;
		[IfFlag(15)] public ChatBannedRights banned_rights;
		[IfFlag(18)] public ChatBannedRights default_banned_rights;
		[IfFlag(17)] public int participants_count;
	}
	[TLDef(0x289DA732, "channelForbidden#289da732 flags:# broadcast:flags.5?true megagroup:flags.8?true id:int access_hash:long title:string until_date:flags.16?int = Chat")]
	public class ChannelForbidden : ChatBase
	{
		[Flags] public enum Flags { broadcast = 0x20, megagroup = 0x100, has_until_date = 0x10000 }
		public Flags flags;
		public int id;
		public long access_hash;
		public string title;
		[IfFlag(16)] public DateTime until_date;
	}

	public abstract class ChatFullBase : ITLObject { }
	[TLDef(0x1B7C9DB3, "chatFull#1b7c9db3 flags:# can_set_username:flags.7?true has_scheduled:flags.8?true id:int about:string participants:ChatParticipants chat_photo:flags.2?Photo notify_settings:PeerNotifySettings exported_invite:ExportedChatInvite bot_info:flags.3?Vector<BotInfo> pinned_msg_id:flags.6?int folder_id:flags.11?int = ChatFull")]
	public class ChatFull : ChatFullBase
	{
		[Flags] public enum Flags { has_chat_photo = 0x4, has_bot_info = 0x8, has_pinned_msg_id = 0x40, can_set_username = 0x80, 
			has_scheduled = 0x100, has_folder_id = 0x800 }
		public Flags flags;
		public int id;
		public string about;
		public ChatParticipantsBase participants;
		[IfFlag(2)] public PhotoBase chat_photo;
		public PeerNotifySettings notify_settings;
		public ExportedChatInvite exported_invite;
		[IfFlag(3)] public BotInfo[] bot_info;
		[IfFlag(6)] public int pinned_msg_id;
		[IfFlag(11)] public int folder_id;
	}
	[TLDef(0xF0E6672A, "channelFull#f0e6672a flags:# can_view_participants:flags.3?true can_set_username:flags.6?true can_set_stickers:flags.7?true hidden_prehistory:flags.10?true can_set_location:flags.16?true has_scheduled:flags.19?true can_view_stats:flags.20?true blocked:flags.22?true id:int about:string participants_count:flags.0?int admins_count:flags.1?int kicked_count:flags.2?int banned_count:flags.2?int online_count:flags.13?int read_inbox_max_id:int read_outbox_max_id:int unread_count:int chat_photo:Photo notify_settings:PeerNotifySettings exported_invite:ExportedChatInvite bot_info:Vector<BotInfo> migrated_from_chat_id:flags.4?int migrated_from_max_id:flags.4?int pinned_msg_id:flags.5?int stickerset:flags.8?StickerSet available_min_id:flags.9?int folder_id:flags.11?int linked_chat_id:flags.14?int location:flags.15?ChannelLocation slowmode_seconds:flags.17?int slowmode_next_send_date:flags.18?int stats_dc:flags.12?int pts:int = ChatFull")]
	public class ChannelFull : ChatFullBase
	{
		[Flags] public enum Flags { has_participants_count = 0x1, has_admins_count = 0x2, has_kicked_count = 0x4, 
			can_view_participants = 0x8, has_migrated_from_chat_id = 0x10, has_pinned_msg_id = 0x20, can_set_username = 0x40, 
			can_set_stickers = 0x80, has_stickerset = 0x100, has_available_min_id = 0x200, hidden_prehistory = 0x400, 
			has_folder_id = 0x800, has_stats_dc = 0x1000, has_online_count = 0x2000, has_linked_chat_id = 0x4000, has_location = 0x8000, 
			can_set_location = 0x10000, has_slowmode_seconds = 0x20000, has_slowmode_next_send_date = 0x40000, has_scheduled = 0x80000, 
			can_view_stats = 0x100000, blocked = 0x400000 }
		public Flags flags;
		public int id;
		public string about;
		[IfFlag(0)] public int participants_count;
		[IfFlag(1)] public int admins_count;
		[IfFlag(2)] public int kicked_count;
		[IfFlag(2)] public int banned_count;
		[IfFlag(13)] public int online_count;
		public int read_inbox_max_id;
		public int read_outbox_max_id;
		public int unread_count;
		public PhotoBase chat_photo;
		public PeerNotifySettings notify_settings;
		public ExportedChatInvite exported_invite;
		public BotInfo[] bot_info;
		[IfFlag(4)] public int migrated_from_chat_id;
		[IfFlag(4)] public int migrated_from_max_id;
		[IfFlag(5)] public int pinned_msg_id;
		[IfFlag(8)] public StickerSet stickerset;
		[IfFlag(9)] public int available_min_id;
		[IfFlag(11)] public int folder_id;
		[IfFlag(14)] public int linked_chat_id;
		[IfFlag(15)] public ChannelLocationBase location;
		[IfFlag(17)] public int slowmode_seconds;
		[IfFlag(18)] public DateTime slowmode_next_send_date;
		[IfFlag(12)] public int stats_dc;
		public int pts;
	}

	public abstract class ChatParticipantBase : ITLObject { }
	[TLDef(0xC8D7493E, "chatParticipant#c8d7493e user_id:int inviter_id:int date:int = ChatParticipant")]
	public class ChatParticipant : ChatParticipantBase
	{
		public int user_id;
		public int inviter_id;
		public DateTime date;
	}
	[TLDef(0xDA13538A, "chatParticipantCreator#da13538a user_id:int = ChatParticipant")]
	public class ChatParticipantCreator : ChatParticipantBase { public int user_id; }
	[TLDef(0xE2D6E436, "chatParticipantAdmin#e2d6e436 user_id:int inviter_id:int date:int = ChatParticipant")]
	public class ChatParticipantAdmin : ChatParticipantBase
	{
		public int user_id;
		public int inviter_id;
		public DateTime date;
	}

	public abstract class ChatParticipantsBase : ITLObject { }
	[TLDef(0xFC900C2B, "chatParticipantsForbidden#fc900c2b flags:# chat_id:int self_participant:flags.0?ChatParticipant = ChatParticipants")]
	public class ChatParticipantsForbidden : ChatParticipantsBase
	{
		[Flags] public enum Flags { has_self_participant = 0x1 }
		public Flags flags;
		public int chat_id;
		[IfFlag(0)] public ChatParticipantBase self_participant;
	}
	[TLDef(0x3F460FED, "chatParticipants#3f460fed chat_id:int participants:Vector<ChatParticipant> version:int = ChatParticipants")]
	public class ChatParticipants : ChatParticipantsBase
	{
		public int chat_id;
		public ChatParticipantBase[] participants;
		public int version;
	}

	public abstract class ChatPhotoBase : ITLObject { }
	[TLDef(0x37C1011C, "chatPhotoEmpty#37c1011c = ChatPhoto")]
	public class ChatPhotoEmpty : ChatPhotoBase { }
	[TLDef(0xD20B9F3C, "chatPhoto#d20b9f3c flags:# has_video:flags.0?true photo_small:FileLocation photo_big:FileLocation dc_id:int = ChatPhoto")]
	public class ChatPhoto : ChatPhotoBase
	{
		[Flags] public enum Flags { has_video = 0x1 }
		public Flags flags;
		public FileLocation photo_small;
		public FileLocation photo_big;
		public int dc_id;
	}

	public abstract class MessageBase : ITLObject { }
	[TLDef(0x83E5DE54, "messageEmpty#83e5de54 id:int = Message")]
	public class MessageEmpty : MessageBase { public int id; }
	[TLDef(0x58AE39C9, "message#58ae39c9 flags:# out:flags.1?true mentioned:flags.4?true media_unread:flags.5?true silent:flags.13?true post:flags.14?true from_scheduled:flags.18?true legacy:flags.19?true edit_hide:flags.21?true pinned:flags.24?true id:int from_id:flags.8?Peer peer_id:Peer fwd_from:flags.2?MessageFwdHeader via_bot_id:flags.11?int reply_to:flags.3?MessageReplyHeader date:int message:string media:flags.9?MessageMedia reply_markup:flags.6?ReplyMarkup entities:flags.7?Vector<MessageEntity> views:flags.10?int forwards:flags.10?int replies:flags.23?MessageReplies edit_date:flags.15?int post_author:flags.16?string grouped_id:flags.17?long restriction_reason:flags.22?Vector<RestrictionReason> = Message")]
	public class Message : MessageBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_fwd_from = 0x4, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, 
			has_reply_markup = 0x40, has_entities = 0x80, has_from_id = 0x100, has_media = 0x200, has_views = 0x400, 
			has_via_bot_id = 0x800, silent = 0x2000, post = 0x4000, has_edit_date = 0x8000, has_post_author = 0x10000, 
			has_grouped_id = 0x20000, from_scheduled = 0x40000, legacy = 0x80000, edit_hide = 0x200000, has_restriction_reason = 0x400000, 
			has_replies = 0x800000, pinned = 0x1000000 }
		public Flags flags;
		public int id;
		[IfFlag(8)] public Peer from_id;
		public Peer peer_id;
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		[IfFlag(11)] public int via_bot_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		public DateTime date;
		public string message;
		[IfFlag(9)] public MessageMedia media;
		[IfFlag(6)] public ReplyMarkup reply_markup;
		[IfFlag(7)] public MessageEntity[] entities;
		[IfFlag(10)] public int views;
		[IfFlag(10)] public int forwards;
		[IfFlag(23)] public MessageReplies replies;
		[IfFlag(15)] public DateTime edit_date;
		[IfFlag(16)] public string post_author;
		[IfFlag(17)] public long grouped_id;
		[IfFlag(22)] public RestrictionReason[] restriction_reason;
	}
	[TLDef(0x286FA604, "messageService#286fa604 flags:# out:flags.1?true mentioned:flags.4?true media_unread:flags.5?true silent:flags.13?true post:flags.14?true legacy:flags.19?true id:int from_id:flags.8?Peer peer_id:Peer reply_to:flags.3?MessageReplyHeader date:int action:MessageAction = Message")]
	public class MessageService : MessageBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, has_from_id = 0x100, 
			silent = 0x2000, post = 0x4000, legacy = 0x80000 }
		public Flags flags;
		public int id;
		[IfFlag(8)] public Peer from_id;
		public Peer peer_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		public DateTime date;
		public MessageAction action;
	}

	public abstract class MessageMedia : ITLObject { }
	[TLDef(0x3DED6320, "messageMediaEmpty#3ded6320 = MessageMedia")]
	public class MessageMediaEmpty : MessageMedia { }
	[TLDef(0x695150D7, "messageMediaPhoto#695150d7 flags:# photo:flags.0?Photo ttl_seconds:flags.2?int = MessageMedia")]
	public class MessageMediaPhoto : MessageMedia
	{
		[Flags] public enum Flags { has_photo = 0x1, has_ttl_seconds = 0x4 }
		public Flags flags;
		[IfFlag(0)] public PhotoBase photo;
		[IfFlag(2)] public int ttl_seconds;
	}
	[TLDef(0x56E0D474, "messageMediaGeo#56e0d474 geo:GeoPoint = MessageMedia")]
	public class MessageMediaGeo : MessageMedia { public GeoPointBase geo; }
	[TLDef(0xCBF24940, "messageMediaContact#cbf24940 phone_number:string first_name:string last_name:string vcard:string user_id:int = MessageMedia")]
	public class MessageMediaContact : MessageMedia
	{
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		public int user_id;
	}
	[TLDef(0x9F84F49E, "messageMediaUnsupported#9f84f49e = MessageMedia")]
	public class MessageMediaUnsupported : MessageMedia { }
	[TLDef(0x9CB070D7, "messageMediaDocument#9cb070d7 flags:# document:flags.0?Document ttl_seconds:flags.2?int = MessageMedia")]
	public class MessageMediaDocument : MessageMedia
	{
		[Flags] public enum Flags { has_document = 0x1, has_ttl_seconds = 0x4 }
		public Flags flags;
		[IfFlag(0)] public DocumentBase document;
		[IfFlag(2)] public int ttl_seconds;
	}
	[TLDef(0xA32DD600, "messageMediaWebPage#a32dd600 webpage:WebPage = MessageMedia")]
	public class MessageMediaWebPage : MessageMedia { public WebPageBase webpage; }
	[TLDef(0x2EC0533F, "messageMediaVenue#2ec0533f geo:GeoPoint title:string address:string provider:string venue_id:string venue_type:string = MessageMedia")]
	public class MessageMediaVenue : MessageMedia
	{
		public GeoPointBase geo;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
	}
	[TLDef(0xFDB19008, "messageMediaGame#fdb19008 game:Game = MessageMedia")]
	public class MessageMediaGame : MessageMedia { public Game game; }
	[TLDef(0x84551347, "messageMediaInvoice#84551347 flags:# shipping_address_requested:flags.1?true test:flags.3?true title:string description:string photo:flags.0?WebDocument receipt_msg_id:flags.2?int currency:string total_amount:long start_param:string = MessageMedia")]
	public class MessageMediaInvoice : MessageMedia
	{
		[Flags] public enum Flags { has_photo = 0x1, shipping_address_requested = 0x2, has_receipt_msg_id = 0x4, test = 0x8 }
		public Flags flags;
		public string title;
		public string description;
		[IfFlag(0)] public WebDocumentBase photo;
		[IfFlag(2)] public int receipt_msg_id;
		public string currency;
		public long total_amount;
		public string start_param;
	}
	[TLDef(0xB940C666, "messageMediaGeoLive#b940c666 flags:# geo:GeoPoint heading:flags.0?int period:int proximity_notification_radius:flags.1?int = MessageMedia")]
	public class MessageMediaGeoLive : MessageMedia
	{
		[Flags] public enum Flags { has_heading = 0x1, has_proximity_notification_radius = 0x2 }
		public Flags flags;
		public GeoPointBase geo;
		[IfFlag(0)] public int heading;
		public int period;
		[IfFlag(1)] public int proximity_notification_radius;
	}
	[TLDef(0x4BD6E798, "messageMediaPoll#4bd6e798 poll:Poll results:PollResults = MessageMedia")]
	public class MessageMediaPoll : MessageMedia
	{
		public Poll poll;
		public PollResults results;
	}
	[TLDef(0x3F7EE58B, "messageMediaDice#3f7ee58b value:int emoticon:string = MessageMedia")]
	public class MessageMediaDice : MessageMedia
	{
		public int value;
		public string emoticon;
	}

	public abstract class MessageAction : ITLObject { }
	[TLDef(0xB6AEF7B0, "messageActionEmpty#b6aef7b0 = MessageAction")]
	public class MessageActionEmpty : MessageAction { }
	[TLDef(0xA6638B9A, "messageActionChatCreate#a6638b9a title:string users:Vector<int> = MessageAction")]
	public class MessageActionChatCreate : MessageAction
	{
		public string title;
		public int[] users;
	}
	[TLDef(0xB5A1CE5A, "messageActionChatEditTitle#b5a1ce5a title:string = MessageAction")]
	public class MessageActionChatEditTitle : MessageAction { public string title; }
	[TLDef(0x7FCB13A8, "messageActionChatEditPhoto#7fcb13a8 photo:Photo = MessageAction")]
	public class MessageActionChatEditPhoto : MessageAction { public PhotoBase photo; }
	[TLDef(0x95E3FBEF, "messageActionChatDeletePhoto#95e3fbef = MessageAction")]
	public class MessageActionChatDeletePhoto : MessageAction { }
	[TLDef(0x488A7337, "messageActionChatAddUser#488a7337 users:Vector<int> = MessageAction")]
	public class MessageActionChatAddUser : MessageAction { public int[] users; }
	[TLDef(0xB2AE9B0C, "messageActionChatDeleteUser#b2ae9b0c user_id:int = MessageAction")]
	public class MessageActionChatDeleteUser : MessageAction { public int user_id; }
	[TLDef(0xF89CF5E8, "messageActionChatJoinedByLink#f89cf5e8 inviter_id:int = MessageAction")]
	public class MessageActionChatJoinedByLink : MessageAction { public int inviter_id; }
	[TLDef(0x95D2AC92, "messageActionChannelCreate#95d2ac92 title:string = MessageAction")]
	public class MessageActionChannelCreate : MessageAction { public string title; }
	[TLDef(0x51BDB021, "messageActionChatMigrateTo#51bdb021 channel_id:int = MessageAction")]
	public class MessageActionChatMigrateTo : MessageAction { public int channel_id; }
	[TLDef(0xB055EAEE, "messageActionChannelMigrateFrom#b055eaee title:string chat_id:int = MessageAction")]
	public class MessageActionChannelMigrateFrom : MessageAction
	{
		public string title;
		public int chat_id;
	}
	[TLDef(0x94BD38ED, "messageActionPinMessage#94bd38ed = MessageAction")]
	public class MessageActionPinMessage : MessageAction { }
	[TLDef(0x9FBAB604, "messageActionHistoryClear#9fbab604 = MessageAction")]
	public class MessageActionHistoryClear : MessageAction { }
	[TLDef(0x92A72876, "messageActionGameScore#92a72876 game_id:long score:int = MessageAction")]
	public class MessageActionGameScore : MessageAction
	{
		public long game_id;
		public int score;
	}
	[TLDef(0x8F31B327, "messageActionPaymentSentMe#8f31b327 flags:# currency:string total_amount:long payload:bytes info:flags.0?PaymentRequestedInfo shipping_option_id:flags.1?string charge:PaymentCharge = MessageAction")]
	public class MessageActionPaymentSentMe : MessageAction
	{
		[Flags] public enum Flags { has_info = 0x1, has_shipping_option_id = 0x2 }
		public Flags flags;
		public string currency;
		public long total_amount;
		public byte[] payload;
		[IfFlag(0)] public PaymentRequestedInfo info;
		[IfFlag(1)] public string shipping_option_id;
		public PaymentCharge charge;
	}
	[TLDef(0x40699CD0, "messageActionPaymentSent#40699cd0 currency:string total_amount:long = MessageAction")]
	public class MessageActionPaymentSent : MessageAction
	{
		public string currency;
		public long total_amount;
	}
	[TLDef(0x80E11A7F, "messageActionPhoneCall#80e11a7f flags:# video:flags.2?true call_id:long reason:flags.0?PhoneCallDiscardReason duration:flags.1?int = MessageAction")]
	public class MessageActionPhoneCall : MessageAction
	{
		[Flags] public enum Flags { has_reason = 0x1, has_duration = 0x2, video = 0x4 }
		public Flags flags;
		public long call_id;
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		[IfFlag(1)] public int duration;
	}
	[TLDef(0x4792929B, "messageActionScreenshotTaken#4792929b = MessageAction")]
	public class MessageActionScreenshotTaken : MessageAction { }
	[TLDef(0xFAE69F56, "messageActionCustomAction#fae69f56 message:string = MessageAction")]
	public class MessageActionCustomAction : MessageAction { public string message; }
	[TLDef(0xABE9AFFE, "messageActionBotAllowed#abe9affe domain:string = MessageAction")]
	public class MessageActionBotAllowed : MessageAction { public string domain; }
	[TLDef(0x1B287353, "messageActionSecureValuesSentMe#1b287353 values:Vector<SecureValue> credentials:SecureCredentialsEncrypted = MessageAction")]
	public class MessageActionSecureValuesSentMe : MessageAction
	{
		public SecureValue[] values;
		public SecureCredentialsEncrypted credentials;
	}
	[TLDef(0xD95C6154, "messageActionSecureValuesSent#d95c6154 types:Vector<SecureValueType> = MessageAction")]
	public class MessageActionSecureValuesSent : MessageAction { public SecureValueType[] types; }
	[TLDef(0xF3F25F76, "messageActionContactSignUp#f3f25f76 = MessageAction")]
	public class MessageActionContactSignUp : MessageAction { }
	[TLDef(0x98E0D697, "messageActionGeoProximityReached#98e0d697 from_id:Peer to_id:Peer distance:int = MessageAction")]
	public class MessageActionGeoProximityReached : MessageAction
	{
		public Peer from_id;
		public Peer to_id;
		public int distance;
	}

	public abstract class DialogBase : ITLObject { }
	[TLDef(0x2C171F72, "dialog#2c171f72 flags:# pinned:flags.2?true unread_mark:flags.3?true peer:Peer top_message:int read_inbox_max_id:int read_outbox_max_id:int unread_count:int unread_mentions_count:int notify_settings:PeerNotifySettings pts:flags.0?int draft:flags.1?DraftMessage folder_id:flags.4?int = Dialog")]
	public class Dialog : DialogBase
	{
		[Flags] public enum Flags { has_pts = 0x1, has_draft = 0x2, pinned = 0x4, unread_mark = 0x8, has_folder_id = 0x10 }
		public Flags flags;
		public Peer peer;
		public int top_message;
		public int read_inbox_max_id;
		public int read_outbox_max_id;
		public int unread_count;
		public int unread_mentions_count;
		public PeerNotifySettings notify_settings;
		[IfFlag(0)] public int pts;
		[IfFlag(1)] public DraftMessageBase draft;
		[IfFlag(4)] public int folder_id;
	}
	[TLDef(0x71BD134C, "dialogFolder#71bd134c flags:# pinned:flags.2?true folder:Folder peer:Peer top_message:int unread_muted_peers_count:int unread_unmuted_peers_count:int unread_muted_messages_count:int unread_unmuted_messages_count:int = Dialog")]
	public class DialogFolder : DialogBase
	{
		[Flags] public enum Flags { pinned = 0x4 }
		public Flags flags;
		public Folder folder;
		public Peer peer;
		public int top_message;
		public int unread_muted_peers_count;
		public int unread_unmuted_peers_count;
		public int unread_muted_messages_count;
		public int unread_unmuted_messages_count;
	}

	public abstract class PhotoBase : ITLObject { }
	[TLDef(0x2331B22D, "photoEmpty#2331b22d id:long = Photo")]
	public class PhotoEmpty : PhotoBase { public long id; }
	[TLDef(0xFB197A65, "photo#fb197a65 flags:# has_stickers:flags.0?true id:long access_hash:long file_reference:bytes date:int sizes:Vector<PhotoSize> video_sizes:flags.1?Vector<VideoSize> dc_id:int = Photo")]
	public class Photo : PhotoBase
	{
		[Flags] public enum Flags { has_stickers = 0x1, has_video_sizes = 0x2 }
		public Flags flags;
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public DateTime date;
		public PhotoSizeBase[] sizes;
		[IfFlag(1)] public VideoSize[] video_sizes;
		public int dc_id;
	}

	public abstract class PhotoSizeBase : ITLObject { }
	[TLDef(0xE17E23C, "photoSizeEmpty#0e17e23c type:string = PhotoSize")]
	public class PhotoSizeEmpty : PhotoSizeBase { public string type; }
	[TLDef(0x77BFB61B, "photoSize#77bfb61b type:string location:FileLocation w:int h:int size:int = PhotoSize")]
	public class PhotoSize : PhotoSizeBase
	{
		public string type;
		public FileLocation location;
		public int w;
		public int h;
		public int size;
	}
	[TLDef(0xE9A734FA, "photoCachedSize#e9a734fa type:string location:FileLocation w:int h:int bytes:bytes = PhotoSize")]
	public class PhotoCachedSize : PhotoSizeBase
	{
		public string type;
		public FileLocation location;
		public int w;
		public int h;
		public byte[] bytes;
	}
	[TLDef(0xE0B0BC2E, "photoStrippedSize#e0b0bc2e type:string bytes:bytes = PhotoSize")]
	public class PhotoStrippedSize : PhotoSizeBase
	{
		public string type;
		public byte[] bytes;
	}
	[TLDef(0x5AA86A51, "photoSizeProgressive#5aa86a51 type:string location:FileLocation w:int h:int sizes:Vector<int> = PhotoSize")]
	public class PhotoSizeProgressive : PhotoSizeBase
	{
		public string type;
		public FileLocation location;
		public int w;
		public int h;
		public int[] sizes;
	}
	[TLDef(0xD8214D41, "photoPathSize#d8214d41 type:string bytes:bytes = PhotoSize")]
	public class PhotoPathSize : PhotoSizeBase
	{
		public string type;
		public byte[] bytes;
	}

	public abstract class GeoPointBase : ITLObject { }
	[TLDef(0x1117DD5F, "geoPointEmpty#1117dd5f = GeoPoint")]
	public class GeoPointEmpty : GeoPointBase { }
	[TLDef(0xB2A2F663, "geoPoint#b2a2f663 flags:# long:double lat:double access_hash:long accuracy_radius:flags.0?int = GeoPoint")]
	public class GeoPoint : GeoPointBase
	{
		[Flags] public enum Flags { has_accuracy_radius = 0x1 }
		public Flags flags;
		public double long_;
		public double lat;
		public long access_hash;
		[IfFlag(0)] public int accuracy_radius;
	}

	[TLDef(0x5E002502, "auth.sentCode#5e002502 flags:# type:auth.SentCodeType phone_code_hash:string next_type:flags.1?auth.CodeType timeout:flags.2?int = auth.SentCode")]
	public class Auth_SentCode : ITLObject
	{
		[Flags] public enum Flags { has_next_type = 0x2, has_timeout = 0x4 }
		public Flags flags;
		public Auth_SentCodeType type;
		public string phone_code_hash;
		[IfFlag(1)] public Auth_CodeType next_type;
		[IfFlag(2)] public int timeout;
	}

	public abstract class Auth_AuthorizationBase : ITLObject { }
	[TLDef(0xCD050916, "auth.authorization#cd050916 flags:# tmp_sessions:flags.0?int user:User = auth.Authorization")]
	public class Auth_Authorization : Auth_AuthorizationBase
	{
		[Flags] public enum Flags { has_tmp_sessions = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int tmp_sessions;
		public UserBase user;
	}
	[TLDef(0x44747E9A, "auth.authorizationSignUpRequired#44747e9a flags:# terms_of_service:flags.0?help.TermsOfService = auth.Authorization")]
	public class Auth_AuthorizationSignUpRequired : Auth_AuthorizationBase
	{
		[Flags] public enum Flags { has_terms_of_service = 0x1 }
		public Flags flags;
		[IfFlag(0)] public Help_TermsOfService terms_of_service;
	}

	[TLDef(0xDF969C2D, "auth.exportedAuthorization#df969c2d id:int bytes:bytes = auth.ExportedAuthorization")]
	public class Auth_ExportedAuthorization : ITLObject
	{
		public int id;
		public byte[] bytes;
	}

	public abstract class InputNotifyPeerBase : ITLObject { }
	[TLDef(0xB8BC5B0C, "inputNotifyPeer#b8bc5b0c peer:InputPeer = InputNotifyPeer")]
	public class InputNotifyPeer : InputNotifyPeerBase { public InputPeer peer; }
	[TLDef(0x193B4417, "inputNotifyUsers#193b4417 = InputNotifyPeer")]
	public class InputNotifyUsers : InputNotifyPeerBase { }
	[TLDef(0x4A95E84E, "inputNotifyChats#4a95e84e = InputNotifyPeer")]
	public class InputNotifyChats : InputNotifyPeerBase { }
	[TLDef(0xB1DB7C7E, "inputNotifyBroadcasts#b1db7c7e = InputNotifyPeer")]
	public class InputNotifyBroadcasts : InputNotifyPeerBase { }

	[TLDef(0x9C3D198E, "inputPeerNotifySettings#9c3d198e flags:# show_previews:flags.0?Bool silent:flags.1?Bool mute_until:flags.2?int sound:flags.3?string = InputPeerNotifySettings")]
	public class InputPeerNotifySettings : ITLObject
	{
		[Flags] public enum Flags { has_show_previews = 0x1, has_silent = 0x2, has_mute_until = 0x4, has_sound = 0x8 }
		public Flags flags;
		[IfFlag(0)] public bool show_previews;
		[IfFlag(1)] public bool silent;
		[IfFlag(2)] public int mute_until;
		[IfFlag(3)] public string sound;
	}

	[TLDef(0xAF509D20, "peerNotifySettings#af509d20 flags:# show_previews:flags.0?Bool silent:flags.1?Bool mute_until:flags.2?int sound:flags.3?string = PeerNotifySettings")]
	public class PeerNotifySettings : ITLObject
	{
		[Flags] public enum Flags { has_show_previews = 0x1, has_silent = 0x2, has_mute_until = 0x4, has_sound = 0x8 }
		public Flags flags;
		[IfFlag(0)] public bool show_previews;
		[IfFlag(1)] public bool silent;
		[IfFlag(2)] public int mute_until;
		[IfFlag(3)] public string sound;
	}

	[TLDef(0x733F2961, "peerSettings#733f2961 flags:# report_spam:flags.0?true add_contact:flags.1?true block_contact:flags.2?true share_contact:flags.3?true need_contacts_exception:flags.4?true report_geo:flags.5?true autoarchived:flags.7?true invite_members:flags.8?true geo_distance:flags.6?int = PeerSettings")]
	public class PeerSettings : ITLObject
	{
		[Flags] public enum Flags { report_spam = 0x1, add_contact = 0x2, block_contact = 0x4, share_contact = 0x8, 
			need_contacts_exception = 0x10, report_geo = 0x20, has_geo_distance = 0x40, autoarchived = 0x80, invite_members = 0x100 }
		public Flags flags;
		[IfFlag(6)] public int geo_distance;
	}

	public abstract class WallPaperBase : ITLObject { }
	[TLDef(0xA437C3ED, "wallPaper#a437c3ed id:long flags:# creator:flags.0?true default:flags.1?true pattern:flags.3?true dark:flags.4?true access_hash:long slug:string document:Document settings:flags.2?WallPaperSettings = WallPaper")]
	public class WallPaper : WallPaperBase
	{
		[Flags] public enum Flags { creator = 0x1, default_ = 0x2, has_settings = 0x4, pattern = 0x8, dark = 0x10 }
		public long id;
		public Flags flags;
		public long access_hash;
		public string slug;
		public DocumentBase document;
		[IfFlag(2)] public WallPaperSettings settings;
	}
	[TLDef(0x8AF40B25, "wallPaperNoFile#8af40b25 flags:# default:flags.1?true dark:flags.4?true settings:flags.2?WallPaperSettings = WallPaper")]
	public class WallPaperNoFile : WallPaperBase
	{
		[Flags] public enum Flags { default_ = 0x2, has_settings = 0x4, dark = 0x10 }
		public Flags flags;
		[IfFlag(2)] public WallPaperSettings settings;
	}

	public abstract class ReportReason : ITLObject { }
	[TLDef(0x58DBCAB8, "inputReportReasonSpam#58dbcab8 = ReportReason")]
	public class InputReportReasonSpam : ReportReason { }
	[TLDef(0x1E22C78D, "inputReportReasonViolence#1e22c78d = ReportReason")]
	public class InputReportReasonViolence : ReportReason { }
	[TLDef(0x2E59D922, "inputReportReasonPornography#2e59d922 = ReportReason")]
	public class InputReportReasonPornography : ReportReason { }
	[TLDef(0xADF44EE3, "inputReportReasonChildAbuse#adf44ee3 = ReportReason")]
	public class InputReportReasonChildAbuse : ReportReason { }
	[TLDef(0xE1746D0A, "inputReportReasonOther#e1746d0a text:string = ReportReason")]
	public class InputReportReasonOther : ReportReason { public string text; }
	[TLDef(0x9B89F93A, "inputReportReasonCopyright#9b89f93a = ReportReason")]
	public class InputReportReasonCopyright : ReportReason { }
	[TLDef(0xDBD4FEED, "inputReportReasonGeoIrrelevant#dbd4feed = ReportReason")]
	public class InputReportReasonGeoIrrelevant : ReportReason { }

	[TLDef(0xEDF17C12, "userFull#edf17c12 flags:# blocked:flags.0?true phone_calls_available:flags.4?true phone_calls_private:flags.5?true can_pin_message:flags.7?true has_scheduled:flags.12?true video_calls_available:flags.13?true user:User about:flags.1?string settings:PeerSettings profile_photo:flags.2?Photo notify_settings:PeerNotifySettings bot_info:flags.3?BotInfo pinned_msg_id:flags.6?int common_chats_count:int folder_id:flags.11?int = UserFull")]
	public class UserFull : ITLObject
	{
		[Flags] public enum Flags { blocked = 0x1, has_about = 0x2, has_profile_photo = 0x4, has_bot_info = 0x8, 
			phone_calls_available = 0x10, phone_calls_private = 0x20, has_pinned_msg_id = 0x40, can_pin_message = 0x80, 
			has_folder_id = 0x800, has_scheduled = 0x1000, video_calls_available = 0x2000 }
		public Flags flags;
		public UserBase user;
		[IfFlag(1)] public string about;
		public PeerSettings settings;
		[IfFlag(2)] public PhotoBase profile_photo;
		public PeerNotifySettings notify_settings;
		[IfFlag(3)] public BotInfo bot_info;
		[IfFlag(6)] public int pinned_msg_id;
		public int common_chats_count;
		[IfFlag(11)] public int folder_id;
	}

	[TLDef(0xF911C994, "contact#f911c994 user_id:int mutual:Bool = Contact")]
	public class Contact : ITLObject
	{
		public int user_id;
		public bool mutual;
	}

	[TLDef(0xD0028438, "importedContact#d0028438 user_id:int client_id:long = ImportedContact")]
	public class ImportedContact : ITLObject
	{
		public int user_id;
		public long client_id;
	}

	[TLDef(0xD3680C61, "contactStatus#d3680c61 user_id:int status:UserStatus = ContactStatus")]
	public class ContactStatus : ITLObject
	{
		public int user_id;
		public UserStatus status;
	}

	public abstract class Contacts_ContactsBase : ITLObject { }
	[TLDef(0xB74BA9D2, "contacts.contactsNotModified#b74ba9d2 = contacts.Contacts")]
	public class Contacts_ContactsNotModified : Contacts_ContactsBase { }
	[TLDef(0xEAE87E42, "contacts.contacts#eae87e42 contacts:Vector<Contact> saved_count:int users:Vector<User> = contacts.Contacts")]
	public class Contacts_Contacts : Contacts_ContactsBase
	{
		public Contact[] contacts;
		public int saved_count;
		public UserBase[] users;
	}

	[TLDef(0x77D01C3B, "contacts.importedContacts#77d01c3b imported:Vector<ImportedContact> popular_invites:Vector<PopularContact> retry_contacts:Vector<long> users:Vector<User> = contacts.ImportedContacts")]
	public class Contacts_ImportedContacts : ITLObject
	{
		public ImportedContact[] imported;
		public PopularContact[] popular_invites;
		public long[] retry_contacts;
		public UserBase[] users;
	}

	public abstract class Contacts_BlockedBase : ITLObject { }
	[TLDef(0xADE1591, "contacts.blocked#0ade1591 blocked:Vector<PeerBlocked> chats:Vector<Chat> users:Vector<User> = contacts.Blocked")]
	public class Contacts_Blocked : Contacts_BlockedBase
	{
		public PeerBlocked[] blocked;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0xE1664194, "contacts.blockedSlice#e1664194 count:int blocked:Vector<PeerBlocked> chats:Vector<Chat> users:Vector<User> = contacts.Blocked")]
	public class Contacts_BlockedSlice : Contacts_BlockedBase
	{
		public int count;
		public PeerBlocked[] blocked;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	public abstract class Messages_DialogsBase : ITLObject { }
	[TLDef(0x15BA6C40, "messages.dialogs#15ba6c40 dialogs:Vector<Dialog> messages:Vector<Message> chats:Vector<Chat> users:Vector<User> = messages.Dialogs")]
	public class Messages_Dialogs : Messages_DialogsBase
	{
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0x71E094F3, "messages.dialogsSlice#71e094f3 count:int dialogs:Vector<Dialog> messages:Vector<Message> chats:Vector<Chat> users:Vector<User> = messages.Dialogs")]
	public class Messages_DialogsSlice : Messages_DialogsBase
	{
		public int count;
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0xF0E3E596, "messages.dialogsNotModified#f0e3e596 count:int = messages.Dialogs")]
	public class Messages_DialogsNotModified : Messages_DialogsBase { public int count; }

	public abstract class Messages_MessagesBase : ITLObject { }
	[TLDef(0x8C718E87, "messages.messages#8c718e87 messages:Vector<Message> chats:Vector<Chat> users:Vector<User> = messages.Messages")]
	public class Messages_Messages : Messages_MessagesBase
	{
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0x3A54685E, "messages.messagesSlice#3a54685e flags:# inexact:flags.1?true count:int next_rate:flags.0?int offset_id_offset:flags.2?int messages:Vector<Message> chats:Vector<Chat> users:Vector<User> = messages.Messages")]
	public class Messages_MessagesSlice : Messages_MessagesBase
	{
		[Flags] public enum Flags { has_next_rate = 0x1, inexact = 0x2, has_offset_id_offset = 0x4 }
		public Flags flags;
		public int count;
		[IfFlag(0)] public int next_rate;
		[IfFlag(2)] public int offset_id_offset;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0x64479808, "messages.channelMessages#64479808 flags:# inexact:flags.1?true pts:int count:int offset_id_offset:flags.2?int messages:Vector<Message> chats:Vector<Chat> users:Vector<User> = messages.Messages")]
	public class Messages_ChannelMessages : Messages_MessagesBase
	{
		[Flags] public enum Flags { inexact = 0x2, has_offset_id_offset = 0x4 }
		public Flags flags;
		public int pts;
		public int count;
		[IfFlag(2)] public int offset_id_offset;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0x74535F21, "messages.messagesNotModified#74535f21 count:int = messages.Messages")]
	public class Messages_MessagesNotModified : Messages_MessagesBase { public int count; }

	public abstract class Messages_ChatsBase : ITLObject { }
	[TLDef(0x64FF9FD5, "messages.chats#64ff9fd5 chats:Vector<Chat> = messages.Chats")]
	public class Messages_Chats : Messages_ChatsBase { public ChatBase[] chats; }
	[TLDef(0x9CD81144, "messages.chatsSlice#9cd81144 count:int chats:Vector<Chat> = messages.Chats")]
	public class Messages_ChatsSlice : Messages_ChatsBase
	{
		public int count;
		public ChatBase[] chats;
	}

	[TLDef(0xE5D7D19C, "messages.chatFull#e5d7d19c full_chat:ChatFull chats:Vector<Chat> users:Vector<User> = messages.ChatFull")]
	public class Messages_ChatFull : ITLObject
	{
		public ChatFullBase full_chat;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0xB45C69D1, "messages.affectedHistory#b45c69d1 pts:int pts_count:int offset:int = messages.AffectedHistory")]
	public class Messages_AffectedHistory : ITLObject
	{
		public int pts;
		public int pts_count;
		public int offset;
	}

	public abstract class MessagesFilter : ITLObject { }
	[TLDef(0x57E2F66C, "inputMessagesFilterEmpty#57e2f66c = MessagesFilter")]
	public class InputMessagesFilterEmpty : MessagesFilter { }
	[TLDef(0x9609A51C, "inputMessagesFilterPhotos#9609a51c = MessagesFilter")]
	public class InputMessagesFilterPhotos : MessagesFilter { }
	[TLDef(0x9FC00E65, "inputMessagesFilterVideo#9fc00e65 = MessagesFilter")]
	public class InputMessagesFilterVideo : MessagesFilter { }
	[TLDef(0x56E9F0E4, "inputMessagesFilterPhotoVideo#56e9f0e4 = MessagesFilter")]
	public class InputMessagesFilterPhotoVideo : MessagesFilter { }
	[TLDef(0x9EDDF188, "inputMessagesFilterDocument#9eddf188 = MessagesFilter")]
	public class InputMessagesFilterDocument : MessagesFilter { }
	[TLDef(0x7EF0DD87, "inputMessagesFilterUrl#7ef0dd87 = MessagesFilter")]
	public class InputMessagesFilterUrl : MessagesFilter { }
	[TLDef(0xFFC86587, "inputMessagesFilterGif#ffc86587 = MessagesFilter")]
	public class InputMessagesFilterGif : MessagesFilter { }
	[TLDef(0x50F5C392, "inputMessagesFilterVoice#50f5c392 = MessagesFilter")]
	public class InputMessagesFilterVoice : MessagesFilter { }
	[TLDef(0x3751B49E, "inputMessagesFilterMusic#3751b49e = MessagesFilter")]
	public class InputMessagesFilterMusic : MessagesFilter { }
	[TLDef(0x3A20ECB8, "inputMessagesFilterChatPhotos#3a20ecb8 = MessagesFilter")]
	public class InputMessagesFilterChatPhotos : MessagesFilter { }
	[TLDef(0x80C99768, "inputMessagesFilterPhoneCalls#80c99768 flags:# missed:flags.0?true = MessagesFilter")]
	public class InputMessagesFilterPhoneCalls : MessagesFilter
	{
		[Flags] public enum Flags { missed = 0x1 }
		public Flags flags;
	}
	[TLDef(0x7A7C17A4, "inputMessagesFilterRoundVoice#7a7c17a4 = MessagesFilter")]
	public class InputMessagesFilterRoundVoice : MessagesFilter { }
	[TLDef(0xB549DA53, "inputMessagesFilterRoundVideo#b549da53 = MessagesFilter")]
	public class InputMessagesFilterRoundVideo : MessagesFilter { }
	[TLDef(0xC1F8E69A, "inputMessagesFilterMyMentions#c1f8e69a = MessagesFilter")]
	public class InputMessagesFilterMyMentions : MessagesFilter { }
	[TLDef(0xE7026D0D, "inputMessagesFilterGeo#e7026d0d = MessagesFilter")]
	public class InputMessagesFilterGeo : MessagesFilter { }
	[TLDef(0xE062DB83, "inputMessagesFilterContacts#e062db83 = MessagesFilter")]
	public class InputMessagesFilterContacts : MessagesFilter { }
	[TLDef(0x1BB00451, "inputMessagesFilterPinned#1bb00451 = MessagesFilter")]
	public class InputMessagesFilterPinned : MessagesFilter { }

	public abstract class Update : ITLObject { }
	[TLDef(0x1F2B0AFD, "updateNewMessage#1f2b0afd message:Message pts:int pts_count:int = Update")]
	public class UpdateNewMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x4E90BFD6, "updateMessageID#4e90bfd6 id:int random_id:long = Update")]
	public class UpdateMessageID : Update
	{
		public int id;
		public long random_id;
	}
	[TLDef(0xA20DB0E5, "updateDeleteMessages#a20db0e5 messages:Vector<int> pts:int pts_count:int = Update")]
	public class UpdateDeleteMessages : Update
	{
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x5C486927, "updateUserTyping#5c486927 user_id:int action:SendMessageAction = Update")]
	public class UpdateUserTyping : Update
	{
		public int user_id;
		public SendMessageAction action;
	}
	[TLDef(0x9A65EA1F, "updateChatUserTyping#9a65ea1f chat_id:int user_id:int action:SendMessageAction = Update")]
	public class UpdateChatUserTyping : Update
	{
		public int chat_id;
		public int user_id;
		public SendMessageAction action;
	}
	[TLDef(0x7761198, "updateChatParticipants#07761198 participants:ChatParticipants = Update")]
	public class UpdateChatParticipants : Update { public ChatParticipantsBase participants; }
	[TLDef(0x1BFBD823, "updateUserStatus#1bfbd823 user_id:int status:UserStatus = Update")]
	public class UpdateUserStatus : Update
	{
		public int user_id;
		public UserStatus status;
	}
	[TLDef(0xA7332B73, "updateUserName#a7332b73 user_id:int first_name:string last_name:string username:string = Update")]
	public class UpdateUserName : Update
	{
		public int user_id;
		public string first_name;
		public string last_name;
		public string username;
	}
	[TLDef(0x95313B0C, "updateUserPhoto#95313b0c user_id:int date:int photo:UserProfilePhoto previous:Bool = Update")]
	public class UpdateUserPhoto : Update
	{
		public int user_id;
		public DateTime date;
		public UserProfilePhotoBase photo;
		public bool previous;
	}
	[TLDef(0x12BCBD9A, "updateNewEncryptedMessage#12bcbd9a message:EncryptedMessage qts:int = Update")]
	public class UpdateNewEncryptedMessage : Update
	{
		public EncryptedMessageBase message;
		public int qts;
	}
	[TLDef(0x1710F156, "updateEncryptedChatTyping#1710f156 chat_id:int = Update")]
	public class UpdateEncryptedChatTyping : Update { public int chat_id; }
	[TLDef(0xB4A2E88D, "updateEncryption#b4a2e88d chat:EncryptedChat date:int = Update")]
	public class UpdateEncryption : Update
	{
		public EncryptedChatBase chat;
		public DateTime date;
	}
	[TLDef(0x38FE25B7, "updateEncryptedMessagesRead#38fe25b7 chat_id:int max_date:int date:int = Update")]
	public class UpdateEncryptedMessagesRead : Update
	{
		public int chat_id;
		public DateTime max_date;
		public DateTime date;
	}
	[TLDef(0xEA4B0E5C, "updateChatParticipantAdd#ea4b0e5c chat_id:int user_id:int inviter_id:int date:int version:int = Update")]
	public class UpdateChatParticipantAdd : Update
	{
		public int chat_id;
		public int user_id;
		public int inviter_id;
		public DateTime date;
		public int version;
	}
	[TLDef(0x6E5F8C22, "updateChatParticipantDelete#6e5f8c22 chat_id:int user_id:int version:int = Update")]
	public class UpdateChatParticipantDelete : Update
	{
		public int chat_id;
		public int user_id;
		public int version;
	}
	[TLDef(0x8E5E9873, "updateDcOptions#8e5e9873 dc_options:Vector<DcOption> = Update")]
	public class UpdateDcOptions : Update { public DcOption[] dc_options; }
	[TLDef(0xBEC268EF, "updateNotifySettings#bec268ef peer:NotifyPeer notify_settings:PeerNotifySettings = Update")]
	public class UpdateNotifySettings : Update
	{
		public NotifyPeerBase peer;
		public PeerNotifySettings notify_settings;
	}
	[TLDef(0xEBE46819, "updateServiceNotification#ebe46819 flags:# popup:flags.0?true inbox_date:flags.1?int type:string message:string media:MessageMedia entities:Vector<MessageEntity> = Update")]
	public class UpdateServiceNotification : Update
	{
		[Flags] public enum Flags { popup = 0x1, has_inbox_date = 0x2 }
		public Flags flags;
		[IfFlag(1)] public DateTime inbox_date;
		public string type;
		public string message;
		public MessageMedia media;
		public MessageEntity[] entities;
	}
	[TLDef(0xEE3B272A, "updatePrivacy#ee3b272a key:PrivacyKey rules:Vector<PrivacyRule> = Update")]
	public class UpdatePrivacy : Update
	{
		public PrivacyKey key;
		public PrivacyRule[] rules;
	}
	[TLDef(0x12B9417B, "updateUserPhone#12b9417b user_id:int phone:string = Update")]
	public class UpdateUserPhone : Update
	{
		public int user_id;
		public string phone;
	}
	[TLDef(0x9C974FDF, "updateReadHistoryInbox#9c974fdf flags:# folder_id:flags.0?int peer:Peer max_id:int still_unread_count:int pts:int pts_count:int = Update")]
	public class UpdateReadHistoryInbox : Update
	{
		[Flags] public enum Flags { has_folder_id = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public Peer peer;
		public int max_id;
		public int still_unread_count;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x2F2F21BF, "updateReadHistoryOutbox#2f2f21bf peer:Peer max_id:int pts:int pts_count:int = Update")]
	public class UpdateReadHistoryOutbox : Update
	{
		public Peer peer;
		public int max_id;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x7F891213, "updateWebPage#7f891213 webpage:WebPage pts:int pts_count:int = Update")]
	public class UpdateWebPage : Update
	{
		public WebPageBase webpage;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x68C13933, "updateReadMessagesContents#68c13933 messages:Vector<int> pts:int pts_count:int = Update")]
	public class UpdateReadMessagesContents : Update
	{
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	[TLDef(0xEB0467FB, "updateChannelTooLong#eb0467fb flags:# channel_id:int pts:flags.0?int = Update")]
	public class UpdateChannelTooLong : Update
	{
		[Flags] public enum Flags { has_pts = 0x1 }
		public Flags flags;
		public int channel_id;
		[IfFlag(0)] public int pts;
	}
	[TLDef(0xB6D45656, "updateChannel#b6d45656 channel_id:int = Update")]
	public class UpdateChannel : Update { public int channel_id; }
	[TLDef(0x62BA04D9, "updateNewChannelMessage#62ba04d9 message:Message pts:int pts_count:int = Update")]
	public class UpdateNewChannelMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x330B5424, "updateReadChannelInbox#330b5424 flags:# folder_id:flags.0?int channel_id:int max_id:int still_unread_count:int pts:int = Update")]
	public class UpdateReadChannelInbox : Update
	{
		[Flags] public enum Flags { has_folder_id = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public int channel_id;
		public int max_id;
		public int still_unread_count;
		public int pts;
	}
	[TLDef(0xC37521C9, "updateDeleteChannelMessages#c37521c9 channel_id:int messages:Vector<int> pts:int pts_count:int = Update")]
	public class UpdateDeleteChannelMessages : Update
	{
		public int channel_id;
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x98A12B4B, "updateChannelMessageViews#98a12b4b channel_id:int id:int views:int = Update")]
	public class UpdateChannelMessageViews : Update
	{
		public int channel_id;
		public int id;
		public int views;
	}
	[TLDef(0xB6901959, "updateChatParticipantAdmin#b6901959 chat_id:int user_id:int is_admin:Bool version:int = Update")]
	public class UpdateChatParticipantAdmin : Update
	{
		public int chat_id;
		public int user_id;
		public bool is_admin;
		public int version;
	}
	[TLDef(0x688A30AA, "updateNewStickerSet#688a30aa stickerset:messages.StickerSet = Update")]
	public class UpdateNewStickerSet : Update { public Messages_StickerSet stickerset; }
	[TLDef(0xBB2D201, "updateStickerSetsOrder#0bb2d201 flags:# masks:flags.0?true order:Vector<long> = Update")]
	public class UpdateStickerSetsOrder : Update
	{
		[Flags] public enum Flags { masks = 0x1 }
		public Flags flags;
		public long[] order;
	}
	[TLDef(0x43AE3DEC, "updateStickerSets#43ae3dec = Update")]
	public class UpdateStickerSets : Update { }
	[TLDef(0x9375341E, "updateSavedGifs#9375341e = Update")]
	public class UpdateSavedGifs : Update { }
	[TLDef(0x54826690, "updateBotInlineQuery#54826690 flags:# query_id:long user_id:int query:string geo:flags.0?GeoPoint offset:string = Update")]
	public class UpdateBotInlineQuery : Update
	{
		[Flags] public enum Flags { has_geo = 0x1 }
		public Flags flags;
		public long query_id;
		public int user_id;
		public string query;
		[IfFlag(0)] public GeoPointBase geo;
		public string offset;
	}
	[TLDef(0xE48F964, "updateBotInlineSend#0e48f964 flags:# user_id:int query:string geo:flags.0?GeoPoint id:string msg_id:flags.1?InputBotInlineMessageID = Update")]
	public class UpdateBotInlineSend : Update
	{
		[Flags] public enum Flags { has_geo = 0x1, has_msg_id = 0x2 }
		public Flags flags;
		public int user_id;
		public string query;
		[IfFlag(0)] public GeoPointBase geo;
		public string id;
		[IfFlag(1)] public InputBotInlineMessageID msg_id;
	}
	[TLDef(0x1B3F4DF7, "updateEditChannelMessage#1b3f4df7 message:Message pts:int pts_count:int = Update")]
	public class UpdateEditChannelMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	[TLDef(0xE73547E1, "updateBotCallbackQuery#e73547e1 flags:# query_id:long user_id:int peer:Peer msg_id:int chat_instance:long data:flags.0?bytes game_short_name:flags.1?string = Update")]
	public class UpdateBotCallbackQuery : Update
	{
		[Flags] public enum Flags { has_data = 0x1, has_game_short_name = 0x2 }
		public Flags flags;
		public long query_id;
		public int user_id;
		public Peer peer;
		public int msg_id;
		public long chat_instance;
		[IfFlag(0)] public byte[] data;
		[IfFlag(1)] public string game_short_name;
	}
	[TLDef(0xE40370A3, "updateEditMessage#e40370a3 message:Message pts:int pts_count:int = Update")]
	public class UpdateEditMessage : Update
	{
		public MessageBase message;
		public int pts;
		public int pts_count;
	}
	[TLDef(0xF9D27A5A, "updateInlineBotCallbackQuery#f9d27a5a flags:# query_id:long user_id:int msg_id:InputBotInlineMessageID chat_instance:long data:flags.0?bytes game_short_name:flags.1?string = Update")]
	public class UpdateInlineBotCallbackQuery : Update
	{
		[Flags] public enum Flags { has_data = 0x1, has_game_short_name = 0x2 }
		public Flags flags;
		public long query_id;
		public int user_id;
		public InputBotInlineMessageID msg_id;
		public long chat_instance;
		[IfFlag(0)] public byte[] data;
		[IfFlag(1)] public string game_short_name;
	}
	[TLDef(0x25D6C9C7, "updateReadChannelOutbox#25d6c9c7 channel_id:int max_id:int = Update")]
	public class UpdateReadChannelOutbox : Update
	{
		public int channel_id;
		public int max_id;
	}
	[TLDef(0xEE2BB969, "updateDraftMessage#ee2bb969 peer:Peer draft:DraftMessage = Update")]
	public class UpdateDraftMessage : Update
	{
		public Peer peer;
		public DraftMessageBase draft;
	}
	[TLDef(0x571D2742, "updateReadFeaturedStickers#571d2742 = Update")]
	public class UpdateReadFeaturedStickers : Update { }
	[TLDef(0x9A422C20, "updateRecentStickers#9a422c20 = Update")]
	public class UpdateRecentStickers : Update { }
	[TLDef(0xA229DD06, "updateConfig#a229dd06 = Update")]
	public class UpdateConfig : Update { }
	[TLDef(0x3354678F, "updatePtsChanged#3354678f = Update")]
	public class UpdatePtsChanged : Update { }
	[TLDef(0x40771900, "updateChannelWebPage#40771900 channel_id:int webpage:WebPage pts:int pts_count:int = Update")]
	public class UpdateChannelWebPage : Update
	{
		public int channel_id;
		public WebPageBase webpage;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x6E6FE51C, "updateDialogPinned#6e6fe51c flags:# pinned:flags.0?true folder_id:flags.1?int peer:DialogPeer = Update")]
	public class UpdateDialogPinned : Update
	{
		[Flags] public enum Flags { pinned = 0x1, has_folder_id = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		public DialogPeerBase peer;
	}
	[TLDef(0xFA0F3CA2, "updatePinnedDialogs#fa0f3ca2 flags:# folder_id:flags.1?int order:flags.0?Vector<DialogPeer> = Update")]
	public class UpdatePinnedDialogs : Update
	{
		[Flags] public enum Flags { has_order = 0x1, has_folder_id = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int folder_id;
		[IfFlag(0)] public DialogPeerBase[] order;
	}
	[TLDef(0x8317C0C3, "updateBotWebhookJSON#8317c0c3 data:DataJSON = Update")]
	public class UpdateBotWebhookJSON : Update { public DataJSON data; }
	[TLDef(0x9B9240A6, "updateBotWebhookJSONQuery#9b9240a6 query_id:long data:DataJSON timeout:int = Update")]
	public class UpdateBotWebhookJSONQuery : Update
	{
		public long query_id;
		public DataJSON data;
		public int timeout;
	}
	[TLDef(0xE0CDC940, "updateBotShippingQuery#e0cdc940 query_id:long user_id:int payload:bytes shipping_address:PostAddress = Update")]
	public class UpdateBotShippingQuery : Update
	{
		public long query_id;
		public int user_id;
		public byte[] payload;
		public PostAddress shipping_address;
	}
	[TLDef(0x5D2F3AA9, "updateBotPrecheckoutQuery#5d2f3aa9 flags:# query_id:long user_id:int payload:bytes info:flags.0?PaymentRequestedInfo shipping_option_id:flags.1?string currency:string total_amount:long = Update")]
	public class UpdateBotPrecheckoutQuery : Update
	{
		[Flags] public enum Flags { has_info = 0x1, has_shipping_option_id = 0x2 }
		public Flags flags;
		public long query_id;
		public int user_id;
		public byte[] payload;
		[IfFlag(0)] public PaymentRequestedInfo info;
		[IfFlag(1)] public string shipping_option_id;
		public string currency;
		public long total_amount;
	}
	[TLDef(0xAB0F6B1E, "updatePhoneCall#ab0f6b1e phone_call:PhoneCall = Update")]
	public class UpdatePhoneCall : Update { public PhoneCallBase phone_call; }
	[TLDef(0x46560264, "updateLangPackTooLong#46560264 lang_code:string = Update")]
	public class UpdateLangPackTooLong : Update { public string lang_code; }
	[TLDef(0x56022F4D, "updateLangPack#56022f4d difference:LangPackDifference = Update")]
	public class UpdateLangPack : Update { public LangPackDifference difference; }
	[TLDef(0xE511996D, "updateFavedStickers#e511996d = Update")]
	public class UpdateFavedStickers : Update { }
	[TLDef(0x89893B45, "updateChannelReadMessagesContents#89893b45 channel_id:int messages:Vector<int> = Update")]
	public class UpdateChannelReadMessagesContents : Update
	{
		public int channel_id;
		public int[] messages;
	}
	[TLDef(0x7084A7BE, "updateContactsReset#7084a7be = Update")]
	public class UpdateContactsReset : Update { }
	[TLDef(0x70DB6837, "updateChannelAvailableMessages#70db6837 channel_id:int available_min_id:int = Update")]
	public class UpdateChannelAvailableMessages : Update
	{
		public int channel_id;
		public int available_min_id;
	}
	[TLDef(0xE16459C3, "updateDialogUnreadMark#e16459c3 flags:# unread:flags.0?true peer:DialogPeer = Update")]
	public class UpdateDialogUnreadMark : Update
	{
		[Flags] public enum Flags { unread = 0x1 }
		public Flags flags;
		public DialogPeerBase peer;
	}
	[TLDef(0xACA1657B, "updateMessagePoll#aca1657b flags:# poll_id:long poll:flags.0?Poll results:PollResults = Update")]
	public class UpdateMessagePoll : Update
	{
		[Flags] public enum Flags { has_poll = 0x1 }
		public Flags flags;
		public long poll_id;
		[IfFlag(0)] public Poll poll;
		public PollResults results;
	}
	[TLDef(0x54C01850, "updateChatDefaultBannedRights#54c01850 peer:Peer default_banned_rights:ChatBannedRights version:int = Update")]
	public class UpdateChatDefaultBannedRights : Update
	{
		public Peer peer;
		public ChatBannedRights default_banned_rights;
		public int version;
	}
	[TLDef(0x19360DC0, "updateFolderPeers#19360dc0 folder_peers:Vector<FolderPeer> pts:int pts_count:int = Update")]
	public class UpdateFolderPeers : Update
	{
		public FolderPeer[] folder_peers;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x6A7E7366, "updatePeerSettings#6a7e7366 peer:Peer settings:PeerSettings = Update")]
	public class UpdatePeerSettings : Update
	{
		public Peer peer;
		public PeerSettings settings;
	}
	[TLDef(0xB4AFCFB0, "updatePeerLocated#b4afcfb0 peers:Vector<PeerLocated> = Update")]
	public class UpdatePeerLocated : Update { public PeerLocatedBase[] peers; }
	[TLDef(0x39A51DFB, "updateNewScheduledMessage#39a51dfb message:Message = Update")]
	public class UpdateNewScheduledMessage : Update { public MessageBase message; }
	[TLDef(0x90866CEE, "updateDeleteScheduledMessages#90866cee peer:Peer messages:Vector<int> = Update")]
	public class UpdateDeleteScheduledMessages : Update
	{
		public Peer peer;
		public int[] messages;
	}
	[TLDef(0x8216FBA3, "updateTheme#8216fba3 theme:Theme = Update")]
	public class UpdateTheme : Update { public Theme theme; }
	[TLDef(0x871FB939, "updateGeoLiveViewed#871fb939 peer:Peer msg_id:int = Update")]
	public class UpdateGeoLiveViewed : Update
	{
		public Peer peer;
		public int msg_id;
	}
	[TLDef(0x564FE691, "updateLoginToken#564fe691 = Update")]
	public class UpdateLoginToken : Update { }
	[TLDef(0x42F88F2C, "updateMessagePollVote#42f88f2c poll_id:long user_id:int options:Vector<bytes> = Update")]
	public class UpdateMessagePollVote : Update
	{
		public long poll_id;
		public int user_id;
		public byte[][] options;
	}
	[TLDef(0x26FFDE7D, "updateDialogFilter#26ffde7d flags:# id:int filter:flags.0?DialogFilter = Update")]
	public class UpdateDialogFilter : Update
	{
		[Flags] public enum Flags { has_filter = 0x1 }
		public Flags flags;
		public int id;
		[IfFlag(0)] public DialogFilter filter;
	}
	[TLDef(0xA5D72105, "updateDialogFilterOrder#a5d72105 order:Vector<int> = Update")]
	public class UpdateDialogFilterOrder : Update { public int[] order; }
	[TLDef(0x3504914F, "updateDialogFilters#3504914f = Update")]
	public class UpdateDialogFilters : Update { }
	[TLDef(0x2661BF09, "updatePhoneCallSignalingData#2661bf09 phone_call_id:long data:bytes = Update")]
	public class UpdatePhoneCallSignalingData : Update
	{
		public long phone_call_id;
		public byte[] data;
	}
	[TLDef(0x6E8A84DF, "updateChannelMessageForwards#6e8a84df channel_id:int id:int forwards:int = Update")]
	public class UpdateChannelMessageForwards : Update
	{
		public int channel_id;
		public int id;
		public int forwards;
	}
	[TLDef(0x1CC7DE54, "updateReadChannelDiscussionInbox#1cc7de54 flags:# channel_id:int top_msg_id:int read_max_id:int broadcast_id:flags.0?int broadcast_post:flags.0?int = Update")]
	public class UpdateReadChannelDiscussionInbox : Update
	{
		[Flags] public enum Flags { has_broadcast_id = 0x1 }
		public Flags flags;
		public int channel_id;
		public int top_msg_id;
		public int read_max_id;
		[IfFlag(0)] public int broadcast_id;
		[IfFlag(0)] public int broadcast_post;
	}
	[TLDef(0x4638A26C, "updateReadChannelDiscussionOutbox#4638a26c channel_id:int top_msg_id:int read_max_id:int = Update")]
	public class UpdateReadChannelDiscussionOutbox : Update
	{
		public int channel_id;
		public int top_msg_id;
		public int read_max_id;
	}
	[TLDef(0x246A4B22, "updatePeerBlocked#246a4b22 peer_id:Peer blocked:Bool = Update")]
	public class UpdatePeerBlocked : Update
	{
		public Peer peer_id;
		public bool blocked;
	}
	[TLDef(0xFF2ABE9F, "updateChannelUserTyping#ff2abe9f flags:# channel_id:int top_msg_id:flags.0?int user_id:int action:SendMessageAction = Update")]
	public class UpdateChannelUserTyping : Update
	{
		[Flags] public enum Flags { has_top_msg_id = 0x1 }
		public Flags flags;
		public int channel_id;
		[IfFlag(0)] public int top_msg_id;
		public int user_id;
		public SendMessageAction action;
	}
	[TLDef(0xED85EAB5, "updatePinnedMessages#ed85eab5 flags:# pinned:flags.0?true peer:Peer messages:Vector<int> pts:int pts_count:int = Update")]
	public class UpdatePinnedMessages : Update
	{
		[Flags] public enum Flags { pinned = 0x1 }
		public Flags flags;
		public Peer peer;
		public int[] messages;
		public int pts;
		public int pts_count;
	}
	[TLDef(0x8588878B, "updatePinnedChannelMessages#8588878b flags:# pinned:flags.0?true channel_id:int messages:Vector<int> pts:int pts_count:int = Update")]
	public class UpdatePinnedChannelMessages : Update
	{
		[Flags] public enum Flags { pinned = 0x1 }
		public Flags flags;
		public int channel_id;
		public int[] messages;
		public int pts;
		public int pts_count;
	}

	[TLDef(0xA56C2A3E, "updates.state#a56c2a3e pts:int qts:int date:int seq:int unread_count:int = updates.State")]
	public class Updates_State : ITLObject
	{
		public int pts;
		public int qts;
		public DateTime date;
		public int seq;
		public int unread_count;
	}

	public abstract class Updates_DifferenceBase : ITLObject { }
	[TLDef(0x5D75A138, "updates.differenceEmpty#5d75a138 date:int seq:int = updates.Difference")]
	public class Updates_DifferenceEmpty : Updates_DifferenceBase
	{
		public DateTime date;
		public int seq;
	}
	[TLDef(0xF49CA0, "updates.difference#00f49ca0 new_messages:Vector<Message> new_encrypted_messages:Vector<EncryptedMessage> other_updates:Vector<Update> chats:Vector<Chat> users:Vector<User> state:updates.State = updates.Difference")]
	public class Updates_Difference : Updates_DifferenceBase
	{
		public MessageBase[] new_messages;
		public EncryptedMessageBase[] new_encrypted_messages;
		public Update[] other_updates;
		public ChatBase[] chats;
		public UserBase[] users;
		public Updates_State state;
	}
	[TLDef(0xA8FB1981, "updates.differenceSlice#a8fb1981 new_messages:Vector<Message> new_encrypted_messages:Vector<EncryptedMessage> other_updates:Vector<Update> chats:Vector<Chat> users:Vector<User> intermediate_state:updates.State = updates.Difference")]
	public class Updates_DifferenceSlice : Updates_DifferenceBase
	{
		public MessageBase[] new_messages;
		public EncryptedMessageBase[] new_encrypted_messages;
		public Update[] other_updates;
		public ChatBase[] chats;
		public UserBase[] users;
		public Updates_State intermediate_state;
	}
	[TLDef(0x4AFE8F6D, "updates.differenceTooLong#4afe8f6d pts:int = updates.Difference")]
	public class Updates_DifferenceTooLong : Updates_DifferenceBase { public int pts; }

	public abstract class UpdatesBase : ITLObject { }
	[TLDef(0xE317AF7E, "updatesTooLong#e317af7e = Updates")]
	public class UpdatesTooLong : UpdatesBase { }
	[TLDef(0x2296D2C8, "updateShortMessage#2296d2c8 flags:# out:flags.1?true mentioned:flags.4?true media_unread:flags.5?true silent:flags.13?true id:int user_id:int message:string pts:int pts_count:int date:int fwd_from:flags.2?MessageFwdHeader via_bot_id:flags.11?int reply_to:flags.3?MessageReplyHeader entities:flags.7?Vector<MessageEntity> = Updates")]
	public class UpdateShortMessage : UpdatesBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_fwd_from = 0x4, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, 
			has_entities = 0x80, has_via_bot_id = 0x800, silent = 0x2000 }
		public Flags flags;
		public int id;
		public int user_id;
		public string message;
		public int pts;
		public int pts_count;
		public DateTime date;
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		[IfFlag(11)] public int via_bot_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		[IfFlag(7)] public MessageEntity[] entities;
	}
	[TLDef(0x402D5DBB, "updateShortChatMessage#402d5dbb flags:# out:flags.1?true mentioned:flags.4?true media_unread:flags.5?true silent:flags.13?true id:int from_id:int chat_id:int message:string pts:int pts_count:int date:int fwd_from:flags.2?MessageFwdHeader via_bot_id:flags.11?int reply_to:flags.3?MessageReplyHeader entities:flags.7?Vector<MessageEntity> = Updates")]
	public class UpdateShortChatMessage : UpdatesBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_fwd_from = 0x4, has_reply_to = 0x8, mentioned = 0x10, media_unread = 0x20, 
			has_entities = 0x80, has_via_bot_id = 0x800, silent = 0x2000 }
		public Flags flags;
		public int id;
		public int from_id;
		public int chat_id;
		public string message;
		public int pts;
		public int pts_count;
		public DateTime date;
		[IfFlag(2)] public MessageFwdHeader fwd_from;
		[IfFlag(11)] public int via_bot_id;
		[IfFlag(3)] public MessageReplyHeader reply_to;
		[IfFlag(7)] public MessageEntity[] entities;
	}
	[TLDef(0x78D4DEC1, "updateShort#78d4dec1 update:Update date:int = Updates")]
	public class UpdateShort : UpdatesBase
	{
		public Update update;
		public DateTime date;
	}
	[TLDef(0x725B04C3, "updatesCombined#725b04c3 updates:Vector<Update> users:Vector<User> chats:Vector<Chat> date:int seq_start:int seq:int = Updates")]
	public class UpdatesCombined : UpdatesBase
	{
		public Update[] updates;
		public UserBase[] users;
		public ChatBase[] chats;
		public DateTime date;
		public int seq_start;
		public int seq;
	}
	[TLDef(0x74AE4240, "updates#74ae4240 updates:Vector<Update> users:Vector<User> chats:Vector<Chat> date:int seq:int = Updates")]
	public class Updates : UpdatesBase
	{
		public Update[] updates;
		public UserBase[] users;
		public ChatBase[] chats;
		public DateTime date;
		public int seq;
	}
	[TLDef(0x11F1331C, "updateShortSentMessage#11f1331c flags:# out:flags.1?true id:int pts:int pts_count:int date:int media:flags.9?MessageMedia entities:flags.7?Vector<MessageEntity> = Updates")]
	public class UpdateShortSentMessage : UpdatesBase
	{
		[Flags] public enum Flags { out_ = 0x2, has_entities = 0x80, has_media = 0x200 }
		public Flags flags;
		public int id;
		public int pts;
		public int pts_count;
		public DateTime date;
		[IfFlag(9)] public MessageMedia media;
		[IfFlag(7)] public MessageEntity[] entities;
	}

	public abstract class Photos_PhotosBase : ITLObject { }
	[TLDef(0x8DCA6AA5, "photos.photos#8dca6aa5 photos:Vector<Photo> users:Vector<User> = photos.Photos")]
	public class Photos_Photos : Photos_PhotosBase
	{
		public PhotoBase[] photos;
		public UserBase[] users;
	}
	[TLDef(0x15051F54, "photos.photosSlice#15051f54 count:int photos:Vector<Photo> users:Vector<User> = photos.Photos")]
	public class Photos_PhotosSlice : Photos_PhotosBase
	{
		public int count;
		public PhotoBase[] photos;
		public UserBase[] users;
	}

	[TLDef(0x20212CA8, "photos.photo#20212ca8 photo:Photo users:Vector<User> = photos.Photo")]
	public class Photos_Photo : ITLObject
	{
		public PhotoBase photo;
		public UserBase[] users;
	}

	public abstract class Upload_FileBase : ITLObject { }
	[TLDef(0x96A18D5, "upload.file#096a18d5 type:storage.FileType mtime:int bytes:bytes = upload.File")]
	public class Upload_File : Upload_FileBase
	{
		public Storage_FileType type;
		public int mtime;
		public byte[] bytes;
	}
	[TLDef(0xF18CDA44, "upload.fileCdnRedirect#f18cda44 dc_id:int file_token:bytes encryption_key:bytes encryption_iv:bytes file_hashes:Vector<FileHash> = upload.File")]
	public class Upload_FileCdnRedirect : Upload_FileBase
	{
		public int dc_id;
		public byte[] file_token;
		public byte[] encryption_key;
		public byte[] encryption_iv;
		public FileHash[] file_hashes;
	}

	[TLDef(0x18B7A10D, "dcOption#18b7a10d flags:# ipv6:flags.0?true media_only:flags.1?true tcpo_only:flags.2?true cdn:flags.3?true static:flags.4?true id:int ip_address:string port:int secret:flags.10?bytes = DcOption")]
	public class DcOption : ITLObject
	{
		[Flags] public enum Flags { ipv6 = 0x1, media_only = 0x2, tcpo_only = 0x4, cdn = 0x8, static_ = 0x10, has_secret = 0x400 }
		public Flags flags;
		public int id;
		public string ip_address;
		public int port;
		[IfFlag(10)] public byte[] secret;
	}

	[TLDef(0x330B4067, "config#330b4067 flags:# phonecalls_enabled:flags.1?true default_p2p_contacts:flags.3?true preload_featured_stickers:flags.4?true ignore_phone_entities:flags.5?true revoke_pm_inbox:flags.6?true blocked_mode:flags.8?true pfs_enabled:flags.13?true date:int expires:int test_mode:Bool this_dc:int dc_options:Vector<DcOption> dc_txt_domain_name:string chat_size_max:int megagroup_size_max:int forwarded_count_max:int online_update_period_ms:int offline_blur_timeout_ms:int offline_idle_timeout_ms:int online_cloud_timeout_ms:int notify_cloud_delay_ms:int notify_default_delay_ms:int push_chat_period_ms:int push_chat_limit:int saved_gifs_limit:int edit_time_limit:int revoke_time_limit:int revoke_pm_time_limit:int rating_e_decay:int stickers_recent_limit:int stickers_faved_limit:int channels_read_media_period:int tmp_sessions:flags.0?int pinned_dialogs_count_max:int pinned_infolder_count_max:int call_receive_timeout_ms:int call_ring_timeout_ms:int call_connect_timeout_ms:int call_packet_timeout_ms:int me_url_prefix:string autoupdate_url_prefix:flags.7?string gif_search_username:flags.9?string venue_search_username:flags.10?string img_search_username:flags.11?string static_maps_provider:flags.12?string caption_length_max:int message_length_max:int webfile_dc_id:int suggested_lang_code:flags.2?string lang_pack_version:flags.2?int base_lang_pack_version:flags.2?int = Config")]
	public class Config : ITLObject
	{
		[Flags] public enum Flags { has_tmp_sessions = 0x1, phonecalls_enabled = 0x2, has_suggested_lang_code = 0x4, 
			default_p2p_contacts = 0x8, preload_featured_stickers = 0x10, ignore_phone_entities = 0x20, revoke_pm_inbox = 0x40, 
			has_autoupdate_url_prefix = 0x80, blocked_mode = 0x100, has_gif_search_username = 0x200, has_venue_search_username = 0x400, 
			has_img_search_username = 0x800, has_static_maps_provider = 0x1000, pfs_enabled = 0x2000 }
		public Flags flags;
		public DateTime date;
		public DateTime expires;
		public bool test_mode;
		public int this_dc;
		public DcOption[] dc_options;
		public string dc_txt_domain_name;
		public int chat_size_max;
		public int megagroup_size_max;
		public int forwarded_count_max;
		public int online_update_period_ms;
		public int offline_blur_timeout_ms;
		public int offline_idle_timeout_ms;
		public int online_cloud_timeout_ms;
		public int notify_cloud_delay_ms;
		public int notify_default_delay_ms;
		public int push_chat_period_ms;
		public int push_chat_limit;
		public int saved_gifs_limit;
		public int edit_time_limit;
		public int revoke_time_limit;
		public int revoke_pm_time_limit;
		public int rating_e_decay;
		public int stickers_recent_limit;
		public int stickers_faved_limit;
		public int channels_read_media_period;
		[IfFlag(0)] public int tmp_sessions;
		public int pinned_dialogs_count_max;
		public int pinned_infolder_count_max;
		public int call_receive_timeout_ms;
		public int call_ring_timeout_ms;
		public int call_connect_timeout_ms;
		public int call_packet_timeout_ms;
		public string me_url_prefix;
		[IfFlag(7)] public string autoupdate_url_prefix;
		[IfFlag(9)] public string gif_search_username;
		[IfFlag(10)] public string venue_search_username;
		[IfFlag(11)] public string img_search_username;
		[IfFlag(12)] public string static_maps_provider;
		public int caption_length_max;
		public int message_length_max;
		public int webfile_dc_id;
		[IfFlag(2)] public string suggested_lang_code;
		[IfFlag(2)] public int lang_pack_version;
		[IfFlag(2)] public int base_lang_pack_version;
	}

	[TLDef(0x8E1A1775, "nearestDc#8e1a1775 country:string this_dc:int nearest_dc:int = NearestDc")]
	public class NearestDc : ITLObject
	{
		public string country;
		public int this_dc;
		public int nearest_dc;
	}

	public abstract class Help_AppUpdateBase : ITLObject { }
	[TLDef(0x1DA7158F, "help.appUpdate#1da7158f flags:# can_not_skip:flags.0?true id:int version:string text:string entities:Vector<MessageEntity> document:flags.1?Document url:flags.2?string = help.AppUpdate")]
	public class Help_AppUpdate : Help_AppUpdateBase
	{
		[Flags] public enum Flags { can_not_skip = 0x1, has_document = 0x2, has_url = 0x4 }
		public Flags flags;
		public int id;
		public string version;
		public string text;
		public MessageEntity[] entities;
		[IfFlag(1)] public DocumentBase document;
		[IfFlag(2)] public string url;
	}
	[TLDef(0xC45A6536, "help.noAppUpdate#c45a6536 = help.AppUpdate")]
	public class Help_NoAppUpdate : Help_AppUpdateBase { }

	[TLDef(0x18CB9F78, "help.inviteText#18cb9f78 message:string = help.InviteText")]
	public class Help_InviteText : ITLObject { public string message; }

	public abstract class EncryptedChatBase : ITLObject { }
	[TLDef(0xAB7EC0A0, "encryptedChatEmpty#ab7ec0a0 id:int = EncryptedChat")]
	public class EncryptedChatEmpty : EncryptedChatBase { public int id; }
	[TLDef(0x3BF703DC, "encryptedChatWaiting#3bf703dc id:int access_hash:long date:int admin_id:int participant_id:int = EncryptedChat")]
	public class EncryptedChatWaiting : EncryptedChatBase
	{
		public int id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
	}
	[TLDef(0x62718A82, "encryptedChatRequested#62718a82 flags:# folder_id:flags.0?int id:int access_hash:long date:int admin_id:int participant_id:int g_a:bytes = EncryptedChat")]
	public class EncryptedChatRequested : EncryptedChatBase
	{
		[Flags] public enum Flags { has_folder_id = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int folder_id;
		public int id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
		public byte[] g_a;
	}
	[TLDef(0xFA56CE36, "encryptedChat#fa56ce36 id:int access_hash:long date:int admin_id:int participant_id:int g_a_or_b:bytes key_fingerprint:long = EncryptedChat")]
	public class EncryptedChat : EncryptedChatBase
	{
		public int id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
		public byte[] g_a_or_b;
		public long key_fingerprint;
	}
	[TLDef(0x13D6DD27, "encryptedChatDiscarded#13d6dd27 id:int = EncryptedChat")]
	public class EncryptedChatDiscarded : EncryptedChatBase { public int id; }

	[TLDef(0xF141B5E1, "inputEncryptedChat#f141b5e1 chat_id:int access_hash:long = InputEncryptedChat")]
	public class InputEncryptedChat : ITLObject
	{
		public int chat_id;
		public long access_hash;
	}

	public abstract class EncryptedFileBase : ITLObject { }
	[TLDef(0xC21F497E, "encryptedFileEmpty#c21f497e = EncryptedFile")]
	public class EncryptedFileEmpty : EncryptedFileBase { }
	[TLDef(0x4A70994C, "encryptedFile#4a70994c id:long access_hash:long size:int dc_id:int key_fingerprint:int = EncryptedFile")]
	public class EncryptedFile : EncryptedFileBase
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public int key_fingerprint;
	}

	public abstract class InputEncryptedFileBase : ITLObject { }
	[TLDef(0x1837C364, "inputEncryptedFileEmpty#1837c364 = InputEncryptedFile")]
	public class InputEncryptedFileEmpty : InputEncryptedFileBase { }
	[TLDef(0x64BD0306, "inputEncryptedFileUploaded#64bd0306 id:long parts:int md5_checksum:string key_fingerprint:int = InputEncryptedFile")]
	public class InputEncryptedFileUploaded : InputEncryptedFileBase
	{
		public long id;
		public int parts;
		public byte[] md5_checksum;
		public int key_fingerprint;
	}
	[TLDef(0x5A17B5E5, "inputEncryptedFile#5a17b5e5 id:long access_hash:long = InputEncryptedFile")]
	public class InputEncryptedFile : InputEncryptedFileBase
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0x2DC173C8, "inputEncryptedFileBigUploaded#2dc173c8 id:long parts:int key_fingerprint:int = InputEncryptedFile")]
	public class InputEncryptedFileBigUploaded : InputEncryptedFileBase
	{
		public long id;
		public int parts;
		public int key_fingerprint;
	}

	public abstract class EncryptedMessageBase : ITLObject { }
	[TLDef(0xED18C118, "encryptedMessage#ed18c118 random_id:long chat_id:int date:int bytes:bytes file:EncryptedFile = EncryptedMessage")]
	public class EncryptedMessage : EncryptedMessageBase
	{
		public long random_id;
		public int chat_id;
		public DateTime date;
		public byte[] bytes;
		public EncryptedFileBase file;
	}
	[TLDef(0x23734B06, "encryptedMessageService#23734b06 random_id:long chat_id:int date:int bytes:bytes = EncryptedMessage")]
	public class EncryptedMessageService : EncryptedMessageBase
	{
		public long random_id;
		public int chat_id;
		public DateTime date;
		public byte[] bytes;
	}

	public abstract class Messages_DhConfigBase : ITLObject { }
	[TLDef(0xC0E24635, "messages.dhConfigNotModified#c0e24635 random:bytes = messages.DhConfig")]
	public class Messages_DhConfigNotModified : Messages_DhConfigBase { public byte[] random; }
	[TLDef(0x2C221EDD, "messages.dhConfig#2c221edd g:int p:bytes version:int random:bytes = messages.DhConfig")]
	public class Messages_DhConfig : Messages_DhConfigBase
	{
		public int g;
		public byte[] p;
		public int version;
		public byte[] random;
	}

	[TLDef(0x560F8935, "messages.sentEncryptedMessage#560f8935 date:int = messages.SentEncryptedMessage")]
	public class Messages_SentEncryptedMessage : ITLObject { public DateTime date; }
	[TLDef(0x9493FF32, "messages.sentEncryptedFile#9493ff32 date:int file:EncryptedFile = messages.SentEncryptedMessage")]
	public class Messages_SentEncryptedFile : Messages_SentEncryptedMessage { public EncryptedFileBase file; }

	public abstract class InputDocumentBase : ITLObject { }
	[TLDef(0x72F0EAAE, "inputDocumentEmpty#72f0eaae = InputDocument")]
	public class InputDocumentEmpty : InputDocumentBase { }
	[TLDef(0x1ABFB575, "inputDocument#1abfb575 id:long access_hash:long file_reference:bytes = InputDocument")]
	public class InputDocument : InputDocumentBase
	{
		public long id;
		public long access_hash;
		public byte[] file_reference;
	}

	public abstract class DocumentBase : ITLObject { }
	[TLDef(0x36F8C871, "documentEmpty#36f8c871 id:long = Document")]
	public class DocumentEmpty : DocumentBase { public long id; }
	[TLDef(0x1E87342B, "document#1e87342b flags:# id:long access_hash:long file_reference:bytes date:int mime_type:string size:int thumbs:flags.0?Vector<PhotoSize> video_thumbs:flags.1?Vector<VideoSize> dc_id:int attributes:Vector<DocumentAttribute> = Document")]
	public class Document : DocumentBase
	{
		[Flags] public enum Flags { has_thumbs = 0x1, has_video_thumbs = 0x2 }
		public Flags flags;
		public long id;
		public long access_hash;
		public byte[] file_reference;
		public DateTime date;
		public string mime_type;
		public int size;
		[IfFlag(0)] public PhotoSizeBase[] thumbs;
		[IfFlag(1)] public VideoSize[] video_thumbs;
		public int dc_id;
		public DocumentAttribute[] attributes;
	}

	[TLDef(0x17C6B5F6, "help.support#17c6b5f6 phone_number:string user:User = help.Support")]
	public class Help_Support : ITLObject
	{
		public string phone_number;
		public UserBase user;
	}

	public abstract class NotifyPeerBase : ITLObject { }
	[TLDef(0x9FD40BD8, "notifyPeer#9fd40bd8 peer:Peer = NotifyPeer")]
	public class NotifyPeer : NotifyPeerBase { public Peer peer; }
	[TLDef(0xB4C83B4C, "notifyUsers#b4c83b4c = NotifyPeer")]
	public class NotifyUsers : NotifyPeerBase { }
	[TLDef(0xC007CEC3, "notifyChats#c007cec3 = NotifyPeer")]
	public class NotifyChats : NotifyPeerBase { }
	[TLDef(0xD612E8EF, "notifyBroadcasts#d612e8ef = NotifyPeer")]
	public class NotifyBroadcasts : NotifyPeerBase { }

	public abstract class SendMessageAction : ITLObject { }
	[TLDef(0x16BF744E, "sendMessageTypingAction#16bf744e = SendMessageAction")]
	public class SendMessageTypingAction : SendMessageAction { }
	[TLDef(0xFD5EC8F5, "sendMessageCancelAction#fd5ec8f5 = SendMessageAction")]
	public class SendMessageCancelAction : SendMessageAction { }
	[TLDef(0xA187D66F, "sendMessageRecordVideoAction#a187d66f = SendMessageAction")]
	public class SendMessageRecordVideoAction : SendMessageAction { }
	[TLDef(0xE9763AEC, "sendMessageUploadVideoAction#e9763aec progress:int = SendMessageAction")]
	public class SendMessageUploadVideoAction : SendMessageAction { public int progress; }
	[TLDef(0xD52F73F7, "sendMessageRecordAudioAction#d52f73f7 = SendMessageAction")]
	public class SendMessageRecordAudioAction : SendMessageAction { }
	[TLDef(0xF351D7AB, "sendMessageUploadAudioAction#f351d7ab progress:int = SendMessageAction")]
	public class SendMessageUploadAudioAction : SendMessageAction { public int progress; }
	[TLDef(0xD1D34A26, "sendMessageUploadPhotoAction#d1d34a26 progress:int = SendMessageAction")]
	public class SendMessageUploadPhotoAction : SendMessageAction { public int progress; }
	[TLDef(0xAA0CD9E4, "sendMessageUploadDocumentAction#aa0cd9e4 progress:int = SendMessageAction")]
	public class SendMessageUploadDocumentAction : SendMessageAction { public int progress; }
	[TLDef(0x176F8BA1, "sendMessageGeoLocationAction#176f8ba1 = SendMessageAction")]
	public class SendMessageGeoLocationAction : SendMessageAction { }
	[TLDef(0x628CBC6F, "sendMessageChooseContactAction#628cbc6f = SendMessageAction")]
	public class SendMessageChooseContactAction : SendMessageAction { }
	[TLDef(0xDD6A8F48, "sendMessageGamePlayAction#dd6a8f48 = SendMessageAction")]
	public class SendMessageGamePlayAction : SendMessageAction { }
	[TLDef(0x88F27FBC, "sendMessageRecordRoundAction#88f27fbc = SendMessageAction")]
	public class SendMessageRecordRoundAction : SendMessageAction { }
	[TLDef(0x243E1C66, "sendMessageUploadRoundAction#243e1c66 progress:int = SendMessageAction")]
	public class SendMessageUploadRoundAction : SendMessageAction { public int progress; }

	[TLDef(0xB3134D9D, "contacts.found#b3134d9d my_results:Vector<Peer> results:Vector<Peer> chats:Vector<Chat> users:Vector<User> = contacts.Found")]
	public class Contacts_Found : ITLObject
	{
		public Peer[] my_results;
		public Peer[] results;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	public abstract class InputPrivacyKey : ITLObject { }
	[TLDef(0x4F96CB18, "inputPrivacyKeyStatusTimestamp#4f96cb18 = InputPrivacyKey")]
	public class InputPrivacyKeyStatusTimestamp : InputPrivacyKey { }
	[TLDef(0xBDFB0426, "inputPrivacyKeyChatInvite#bdfb0426 = InputPrivacyKey")]
	public class InputPrivacyKeyChatInvite : InputPrivacyKey { }
	[TLDef(0xFABADC5F, "inputPrivacyKeyPhoneCall#fabadc5f = InputPrivacyKey")]
	public class InputPrivacyKeyPhoneCall : InputPrivacyKey { }
	[TLDef(0xDB9E70D2, "inputPrivacyKeyPhoneP2P#db9e70d2 = InputPrivacyKey")]
	public class InputPrivacyKeyPhoneP2P : InputPrivacyKey { }
	[TLDef(0xA4DD4C08, "inputPrivacyKeyForwards#a4dd4c08 = InputPrivacyKey")]
	public class InputPrivacyKeyForwards : InputPrivacyKey { }
	[TLDef(0x5719BACC, "inputPrivacyKeyProfilePhoto#5719bacc = InputPrivacyKey")]
	public class InputPrivacyKeyProfilePhoto : InputPrivacyKey { }
	[TLDef(0x352DAFA, "inputPrivacyKeyPhoneNumber#0352dafa = InputPrivacyKey")]
	public class InputPrivacyKeyPhoneNumber : InputPrivacyKey { }
	[TLDef(0xD1219BDD, "inputPrivacyKeyAddedByPhone#d1219bdd = InputPrivacyKey")]
	public class InputPrivacyKeyAddedByPhone : InputPrivacyKey { }

	public abstract class PrivacyKey : ITLObject { }
	[TLDef(0xBC2EAB30, "privacyKeyStatusTimestamp#bc2eab30 = PrivacyKey")]
	public class PrivacyKeyStatusTimestamp : PrivacyKey { }
	[TLDef(0x500E6DFA, "privacyKeyChatInvite#500e6dfa = PrivacyKey")]
	public class PrivacyKeyChatInvite : PrivacyKey { }
	[TLDef(0x3D662B7B, "privacyKeyPhoneCall#3d662b7b = PrivacyKey")]
	public class PrivacyKeyPhoneCall : PrivacyKey { }
	[TLDef(0x39491CC8, "privacyKeyPhoneP2P#39491cc8 = PrivacyKey")]
	public class PrivacyKeyPhoneP2P : PrivacyKey { }
	[TLDef(0x69EC56A3, "privacyKeyForwards#69ec56a3 = PrivacyKey")]
	public class PrivacyKeyForwards : PrivacyKey { }
	[TLDef(0x96151FED, "privacyKeyProfilePhoto#96151fed = PrivacyKey")]
	public class PrivacyKeyProfilePhoto : PrivacyKey { }
	[TLDef(0xD19AE46D, "privacyKeyPhoneNumber#d19ae46d = PrivacyKey")]
	public class PrivacyKeyPhoneNumber : PrivacyKey { }
	[TLDef(0x42FFD42B, "privacyKeyAddedByPhone#42ffd42b = PrivacyKey")]
	public class PrivacyKeyAddedByPhone : PrivacyKey { }

	public abstract class InputPrivacyRule : ITLObject { }
	[TLDef(0xD09E07B, "inputPrivacyValueAllowContacts#0d09e07b = InputPrivacyRule")]
	public class InputPrivacyValueAllowContacts : InputPrivacyRule { }
	[TLDef(0x184B35CE, "inputPrivacyValueAllowAll#184b35ce = InputPrivacyRule")]
	public class InputPrivacyValueAllowAll : InputPrivacyRule { }
	[TLDef(0x131CC67F, "inputPrivacyValueAllowUsers#131cc67f users:Vector<InputUser> = InputPrivacyRule")]
	public class InputPrivacyValueAllowUsers : InputPrivacyRule { public InputUserBase[] users; }
	[TLDef(0xBA52007, "inputPrivacyValueDisallowContacts#0ba52007 = InputPrivacyRule")]
	public class InputPrivacyValueDisallowContacts : InputPrivacyRule { }
	[TLDef(0xD66B66C9, "inputPrivacyValueDisallowAll#d66b66c9 = InputPrivacyRule")]
	public class InputPrivacyValueDisallowAll : InputPrivacyRule { }
	[TLDef(0x90110467, "inputPrivacyValueDisallowUsers#90110467 users:Vector<InputUser> = InputPrivacyRule")]
	public class InputPrivacyValueDisallowUsers : InputPrivacyRule { public InputUserBase[] users; }
	[TLDef(0x4C81C1BA, "inputPrivacyValueAllowChatParticipants#4c81c1ba chats:Vector<int> = InputPrivacyRule")]
	public class InputPrivacyValueAllowChatParticipants : InputPrivacyRule { public int[] chats; }
	[TLDef(0xD82363AF, "inputPrivacyValueDisallowChatParticipants#d82363af chats:Vector<int> = InputPrivacyRule")]
	public class InputPrivacyValueDisallowChatParticipants : InputPrivacyRule { public int[] chats; }

	public abstract class PrivacyRule : ITLObject { }
	[TLDef(0xFFFE1BAC, "privacyValueAllowContacts#fffe1bac = PrivacyRule")]
	public class PrivacyValueAllowContacts : PrivacyRule { }
	[TLDef(0x65427B82, "privacyValueAllowAll#65427b82 = PrivacyRule")]
	public class PrivacyValueAllowAll : PrivacyRule { }
	[TLDef(0x4D5BBE0C, "privacyValueAllowUsers#4d5bbe0c users:Vector<int> = PrivacyRule")]
	public class PrivacyValueAllowUsers : PrivacyRule { public int[] users; }
	[TLDef(0xF888FA1A, "privacyValueDisallowContacts#f888fa1a = PrivacyRule")]
	public class PrivacyValueDisallowContacts : PrivacyRule { }
	[TLDef(0x8B73E763, "privacyValueDisallowAll#8b73e763 = PrivacyRule")]
	public class PrivacyValueDisallowAll : PrivacyRule { }
	[TLDef(0xC7F49B7, "privacyValueDisallowUsers#0c7f49b7 users:Vector<int> = PrivacyRule")]
	public class PrivacyValueDisallowUsers : PrivacyRule { public int[] users; }
	[TLDef(0x18BE796B, "privacyValueAllowChatParticipants#18be796b chats:Vector<int> = PrivacyRule")]
	public class PrivacyValueAllowChatParticipants : PrivacyRule { public int[] chats; }
	[TLDef(0xACAE0690, "privacyValueDisallowChatParticipants#acae0690 chats:Vector<int> = PrivacyRule")]
	public class PrivacyValueDisallowChatParticipants : PrivacyRule { public int[] chats; }

	[TLDef(0x50A04E45, "account.privacyRules#50a04e45 rules:Vector<PrivacyRule> chats:Vector<Chat> users:Vector<User> = account.PrivacyRules")]
	public class Account_PrivacyRules : ITLObject
	{
		public PrivacyRule[] rules;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0xB8D0AFDF, "accountDaysTTL#b8d0afdf days:int = AccountDaysTTL")]
	public class AccountDaysTTL : ITLObject { public int days; }

	public abstract class DocumentAttribute : ITLObject { }
	[TLDef(0x6C37C15C, "documentAttributeImageSize#6c37c15c w:int h:int = DocumentAttribute")]
	public class DocumentAttributeImageSize : DocumentAttribute
	{
		public int w;
		public int h;
	}
	[TLDef(0x11B58939, "documentAttributeAnimated#11b58939 = DocumentAttribute")]
	public class DocumentAttributeAnimated : DocumentAttribute { }
	[TLDef(0x6319D612, "documentAttributeSticker#6319d612 flags:# mask:flags.1?true alt:string stickerset:InputStickerSet mask_coords:flags.0?MaskCoords = DocumentAttribute")]
	public class DocumentAttributeSticker : DocumentAttribute
	{
		[Flags] public enum Flags { has_mask_coords = 0x1, mask = 0x2 }
		public Flags flags;
		public string alt;
		public InputStickerSet stickerset;
		[IfFlag(0)] public MaskCoords mask_coords;
	}
	[TLDef(0xEF02CE6, "documentAttributeVideo#0ef02ce6 flags:# round_message:flags.0?true supports_streaming:flags.1?true duration:int w:int h:int = DocumentAttribute")]
	public class DocumentAttributeVideo : DocumentAttribute
	{
		[Flags] public enum Flags { round_message = 0x1, supports_streaming = 0x2 }
		public Flags flags;
		public int duration;
		public int w;
		public int h;
	}
	[TLDef(0x9852F9C6, "documentAttributeAudio#9852f9c6 flags:# voice:flags.10?true duration:int title:flags.0?string performer:flags.1?string waveform:flags.2?bytes = DocumentAttribute")]
	public class DocumentAttributeAudio : DocumentAttribute
	{
		[Flags] public enum Flags { has_title = 0x1, has_performer = 0x2, has_waveform = 0x4, voice = 0x400 }
		public Flags flags;
		public int duration;
		[IfFlag(0)] public string title;
		[IfFlag(1)] public string performer;
		[IfFlag(2)] public byte[] waveform;
	}
	[TLDef(0x15590068, "documentAttributeFilename#15590068 file_name:string = DocumentAttribute")]
	public class DocumentAttributeFilename : DocumentAttribute { public string file_name; }
	[TLDef(0x9801D2F7, "documentAttributeHasStickers#9801d2f7 = DocumentAttribute")]
	public class DocumentAttributeHasStickers : DocumentAttribute { }

	public abstract class Messages_StickersBase : ITLObject { }
	[TLDef(0xF1749A22, "messages.stickersNotModified#f1749a22 = messages.Stickers")]
	public class Messages_StickersNotModified : Messages_StickersBase { }
	[TLDef(0xE4599BBD, "messages.stickers#e4599bbd hash:int stickers:Vector<Document> = messages.Stickers")]
	public class Messages_Stickers : Messages_StickersBase
	{
		public int hash;
		public DocumentBase[] stickers;
	}

	[TLDef(0x12B299D4, "stickerPack#12b299d4 emoticon:string documents:Vector<long> = StickerPack")]
	public class StickerPack : ITLObject
	{
		public string emoticon;
		public long[] documents;
	}

	public abstract class Messages_AllStickersBase : ITLObject { }
	[TLDef(0xE86602C3, "messages.allStickersNotModified#e86602c3 = messages.AllStickers")]
	public class Messages_AllStickersNotModified : Messages_AllStickersBase { }
	[TLDef(0xEDFD405F, "messages.allStickers#edfd405f hash:int sets:Vector<StickerSet> = messages.AllStickers")]
	public class Messages_AllStickers : Messages_AllStickersBase
	{
		public int hash;
		public StickerSet[] sets;
	}

	[TLDef(0x84D19185, "messages.affectedMessages#84d19185 pts:int pts_count:int = messages.AffectedMessages")]
	public class Messages_AffectedMessages : ITLObject
	{
		public int pts;
		public int pts_count;
	}

	public abstract class WebPageBase : ITLObject { }
	[TLDef(0xEB1477E8, "webPageEmpty#eb1477e8 id:long = WebPage")]
	public class WebPageEmpty : WebPageBase { public long id; }
	[TLDef(0xC586DA1C, "webPagePending#c586da1c id:long date:int = WebPage")]
	public class WebPagePending : WebPageBase
	{
		public long id;
		public DateTime date;
	}
	[TLDef(0xE89C45B2, "webPage#e89c45b2 flags:# id:long url:string display_url:string hash:int type:flags.0?string site_name:flags.1?string title:flags.2?string description:flags.3?string photo:flags.4?Photo embed_url:flags.5?string embed_type:flags.5?string embed_width:flags.6?int embed_height:flags.6?int duration:flags.7?int author:flags.8?string document:flags.9?Document cached_page:flags.10?Page attributes:flags.12?Vector<WebPageAttribute> = WebPage")]
	public class WebPage : WebPageBase
	{
		[Flags] public enum Flags { has_type = 0x1, has_site_name = 0x2, has_title = 0x4, has_description = 0x8, has_photo = 0x10, 
			has_embed_url = 0x20, has_embed_width = 0x40, has_duration = 0x80, has_author = 0x100, has_document = 0x200, 
			has_cached_page = 0x400, has_attributes = 0x1000 }
		public Flags flags;
		public long id;
		public string url;
		public string display_url;
		public int hash;
		[IfFlag(0)] public string type;
		[IfFlag(1)] public string site_name;
		[IfFlag(2)] public string title;
		[IfFlag(3)] public string description;
		[IfFlag(4)] public PhotoBase photo;
		[IfFlag(5)] public string embed_url;
		[IfFlag(5)] public string embed_type;
		[IfFlag(6)] public int embed_width;
		[IfFlag(6)] public int embed_height;
		[IfFlag(7)] public int duration;
		[IfFlag(8)] public string author;
		[IfFlag(9)] public DocumentBase document;
		[IfFlag(10)] public Page cached_page;
		[IfFlag(12)] public WebPageAttribute[] attributes;
	}
	[TLDef(0x7311CA11, "webPageNotModified#7311ca11 flags:# cached_page_views:flags.0?int = WebPage")]
	public class WebPageNotModified : WebPageBase
	{
		[Flags] public enum Flags { has_cached_page_views = 0x1 }
		public Flags flags;
		[IfFlag(0)] public int cached_page_views;
	}

	[TLDef(0xAD01D61D, "authorization#ad01d61d flags:# current:flags.0?true official_app:flags.1?true password_pending:flags.2?true hash:long device_model:string platform:string system_version:string api_id:int app_name:string app_version:string date_created:int date_active:int ip:string country:string region:string = Authorization")]
	public class Authorization : ITLObject
	{
		[Flags] public enum Flags { current = 0x1, official_app = 0x2, password_pending = 0x4 }
		public Flags flags;
		public long hash;
		public string device_model;
		public string platform;
		public string system_version;
		public int api_id;
		public string app_name;
		public string app_version;
		public int date_created;
		public int date_active;
		public string ip;
		public string country;
		public string region;
	}

	[TLDef(0x1250ABDE, "account.authorizations#1250abde authorizations:Vector<Authorization> = account.Authorizations")]
	public class Account_Authorizations : ITLObject { public Authorization[] authorizations; }

	[TLDef(0xAD2641F8, "account.password#ad2641f8 flags:# has_recovery:flags.0?true has_secure_values:flags.1?true has_password:flags.2?true current_algo:flags.2?PasswordKdfAlgo srp_B:flags.2?bytes srp_id:flags.2?long hint:flags.3?string email_unconfirmed_pattern:flags.4?string new_algo:PasswordKdfAlgo new_secure_algo:SecurePasswordKdfAlgo secure_random:bytes = account.Password")]
	public class Account_Password : ITLObject
	{
		[Flags] public enum Flags { has_recovery = 0x1, has_secure_values = 0x2, has_password = 0x4, has_hint = 0x8, 
			has_email_unconfirmed_pattern = 0x10 }
		public Flags flags;
		[IfFlag(2)] public PasswordKdfAlgo current_algo;
		[IfFlag(2)] public byte[] srp_B;
		[IfFlag(2)] public long srp_id;
		[IfFlag(3)] public string hint;
		[IfFlag(4)] public string email_unconfirmed_pattern;
		public PasswordKdfAlgo new_algo;
		public SecurePasswordKdfAlgo new_secure_algo;
		public byte[] secure_random;
	}

	[TLDef(0x9A5C33E5, "account.passwordSettings#9a5c33e5 flags:# email:flags.0?string secure_settings:flags.1?SecureSecretSettings = account.PasswordSettings")]
	public class Account_PasswordSettings : ITLObject
	{
		[Flags] public enum Flags { has_email = 0x1, has_secure_settings = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string email;
		[IfFlag(1)] public SecureSecretSettings secure_settings;
	}

	[TLDef(0xC23727C9, "account.passwordInputSettings#c23727c9 flags:# new_algo:flags.0?PasswordKdfAlgo new_password_hash:flags.0?bytes hint:flags.0?string email:flags.1?string new_secure_settings:flags.2?SecureSecretSettings = account.PasswordInputSettings")]
	public class Account_PasswordInputSettings : ITLObject
	{
		[Flags] public enum Flags { has_new_algo = 0x1, has_email = 0x2, has_new_secure_settings = 0x4 }
		public Flags flags;
		[IfFlag(0)] public PasswordKdfAlgo new_algo;
		[IfFlag(0)] public byte[] new_password_hash;
		[IfFlag(0)] public string hint;
		[IfFlag(1)] public string email;
		[IfFlag(2)] public SecureSecretSettings new_secure_settings;
	}

	[TLDef(0x137948A5, "auth.passwordRecovery#137948a5 email_pattern:string = auth.PasswordRecovery")]
	public class Auth_PasswordRecovery : ITLObject { public string email_pattern; }

	[TLDef(0xA384B779, "receivedNotifyMessage#a384b779 id:int flags:int = ReceivedNotifyMessage")]
	public class ReceivedNotifyMessage : ITLObject
	{
		public int id;
		public int flags;
	}

	public abstract class ExportedChatInvite : ITLObject { }
	[TLDef(0x69DF3769, "chatInviteEmpty#69df3769 = ExportedChatInvite")]
	public class ChatInviteEmpty : ExportedChatInvite { }
	[TLDef(0xFC2E05BC, "chatInviteExported#fc2e05bc link:string = ExportedChatInvite")]
	public class ChatInviteExported : ExportedChatInvite { public string link; }

	public abstract class ChatInviteBase : ITLObject { }
	[TLDef(0x5A686D7C, "chatInviteAlready#5a686d7c chat:Chat = ChatInvite")]
	public class ChatInviteAlready : ChatInviteBase { public ChatBase chat; }
	[TLDef(0xDFC2F58E, "chatInvite#dfc2f58e flags:# channel:flags.0?true broadcast:flags.1?true public:flags.2?true megagroup:flags.3?true title:string photo:Photo participants_count:int participants:flags.4?Vector<User> = ChatInvite")]
	public class ChatInvite : ChatInviteBase
	{
		[Flags] public enum Flags { channel = 0x1, broadcast = 0x2, public_ = 0x4, megagroup = 0x8, has_participants = 0x10 }
		public Flags flags;
		public string title;
		public PhotoBase photo;
		public int participants_count;
		[IfFlag(4)] public UserBase[] participants;
	}
	[TLDef(0x61695CB0, "chatInvitePeek#61695cb0 chat:Chat expires:int = ChatInvite")]
	public class ChatInvitePeek : ChatInviteBase
	{
		public ChatBase chat;
		public DateTime expires;
	}

	public abstract class InputStickerSet : ITLObject { }
	[TLDef(0xFFB62B95, "inputStickerSetEmpty#ffb62b95 = InputStickerSet")]
	public class InputStickerSetEmpty : InputStickerSet { }
	[TLDef(0x9DE7A269, "inputStickerSetID#9de7a269 id:long access_hash:long = InputStickerSet")]
	public class InputStickerSetID : InputStickerSet
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0x861CC8A0, "inputStickerSetShortName#861cc8a0 short_name:string = InputStickerSet")]
	public class InputStickerSetShortName : InputStickerSet { public string short_name; }
	[TLDef(0x28703C8, "inputStickerSetAnimatedEmoji#028703c8 = InputStickerSet")]
	public class InputStickerSetAnimatedEmoji : InputStickerSet { }
	[TLDef(0xE67F520E, "inputStickerSetDice#e67f520e emoticon:string = InputStickerSet")]
	public class InputStickerSetDice : InputStickerSet { public string emoticon; }

	[TLDef(0xEEB46F27, "stickerSet#eeb46f27 flags:# archived:flags.1?true official:flags.2?true masks:flags.3?true animated:flags.5?true installed_date:flags.0?int id:long access_hash:long title:string short_name:string thumb:flags.4?PhotoSize thumb_dc_id:flags.4?int count:int hash:int = StickerSet")]
	public class StickerSet : ITLObject
	{
		[Flags] public enum Flags { has_installed_date = 0x1, archived = 0x2, official = 0x4, masks = 0x8, has_thumb = 0x10, 
			animated = 0x20 }
		public Flags flags;
		[IfFlag(0)] public DateTime installed_date;
		public long id;
		public long access_hash;
		public string title;
		public string short_name;
		[IfFlag(4)] public PhotoSizeBase thumb;
		[IfFlag(4)] public int thumb_dc_id;
		public int count;
		public int hash;
	}

	[TLDef(0xB60A24A6, "messages.stickerSet#b60a24a6 set:StickerSet packs:Vector<StickerPack> documents:Vector<Document> = messages.StickerSet")]
	public class Messages_StickerSet : ITLObject
	{
		public StickerSet set;
		public StickerPack[] packs;
		public DocumentBase[] documents;
	}

	[TLDef(0xC27AC8C7, "botCommand#c27ac8c7 command:string description:string = BotCommand")]
	public class BotCommand : ITLObject
	{
		public string command;
		public string description;
	}

	[TLDef(0x98E81D3A, "botInfo#98e81d3a user_id:int description:string commands:Vector<BotCommand> = BotInfo")]
	public class BotInfo : ITLObject
	{
		public int user_id;
		public string description;
		public BotCommand[] commands;
	}

	public abstract class KeyboardButtonBase : ITLObject { }
	[TLDef(0xA2FA4880, "keyboardButton#a2fa4880 text:string = KeyboardButton")]
	public class KeyboardButton : KeyboardButtonBase { public string text; }
	[TLDef(0x258AFF05, "keyboardButtonUrl#258aff05 text:string url:string = KeyboardButton")]
	public class KeyboardButtonUrl : KeyboardButtonBase
	{
		public string text;
		public string url;
	}
	[TLDef(0x35BBDB6B, "keyboardButtonCallback#35bbdb6b flags:# requires_password:flags.0?true text:string data:bytes = KeyboardButton")]
	public class KeyboardButtonCallback : KeyboardButtonBase
	{
		[Flags] public enum Flags { requires_password = 0x1 }
		public Flags flags;
		public string text;
		public byte[] data;
	}
	[TLDef(0xB16A6C29, "keyboardButtonRequestPhone#b16a6c29 text:string = KeyboardButton")]
	public class KeyboardButtonRequestPhone : KeyboardButtonBase { public string text; }
	[TLDef(0xFC796B3F, "keyboardButtonRequestGeoLocation#fc796b3f text:string = KeyboardButton")]
	public class KeyboardButtonRequestGeoLocation : KeyboardButtonBase { public string text; }
	[TLDef(0x568A748, "keyboardButtonSwitchInline#0568a748 flags:# same_peer:flags.0?true text:string query:string = KeyboardButton")]
	public class KeyboardButtonSwitchInline : KeyboardButtonBase
	{
		[Flags] public enum Flags { same_peer = 0x1 }
		public Flags flags;
		public string text;
		public string query;
	}
	[TLDef(0x50F41CCF, "keyboardButtonGame#50f41ccf text:string = KeyboardButton")]
	public class KeyboardButtonGame : KeyboardButtonBase { public string text; }
	[TLDef(0xAFD93FBB, "keyboardButtonBuy#afd93fbb text:string = KeyboardButton")]
	public class KeyboardButtonBuy : KeyboardButtonBase { public string text; }
	[TLDef(0x10B78D29, "keyboardButtonUrlAuth#10b78d29 flags:# text:string fwd_text:flags.0?string url:string button_id:int = KeyboardButton")]
	public class KeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags] public enum Flags { has_fwd_text = 0x1 }
		public Flags flags;
		public string text;
		[IfFlag(0)] public string fwd_text;
		public string url;
		public int button_id;
	}
	[TLDef(0xD02E7FD4, "inputKeyboardButtonUrlAuth#d02e7fd4 flags:# request_write_access:flags.0?true text:string fwd_text:flags.1?string url:string bot:InputUser = KeyboardButton")]
	public class InputKeyboardButtonUrlAuth : KeyboardButtonBase
	{
		[Flags] public enum Flags { request_write_access = 0x1, has_fwd_text = 0x2 }
		public Flags flags;
		public string text;
		[IfFlag(1)] public string fwd_text;
		public string url;
		public InputUserBase bot;
	}
	[TLDef(0xBBC7515D, "keyboardButtonRequestPoll#bbc7515d flags:# quiz:flags.0?Bool text:string = KeyboardButton")]
	public class KeyboardButtonRequestPoll : KeyboardButtonBase
	{
		[Flags] public enum Flags { has_quiz = 0x1 }
		public Flags flags;
		[IfFlag(0)] public bool quiz;
		public string text;
	}

	[TLDef(0x77608B83, "keyboardButtonRow#77608b83 buttons:Vector<KeyboardButton> = KeyboardButtonRow")]
	public class KeyboardButtonRow : ITLObject { public KeyboardButtonBase[] buttons; }

	public abstract class ReplyMarkup : ITLObject { }
	[TLDef(0xA03E5B85, "replyKeyboardHide#a03e5b85 flags:# selective:flags.2?true = ReplyMarkup")]
	public class ReplyKeyboardHide : ReplyMarkup
	{
		[Flags] public enum Flags { selective = 0x4 }
		public Flags flags;
	}
	[TLDef(0xF4108AA0, "replyKeyboardForceReply#f4108aa0 flags:# single_use:flags.1?true selective:flags.2?true = ReplyMarkup")]
	public class ReplyKeyboardForceReply : ReplyMarkup
	{
		[Flags] public enum Flags { single_use = 0x2, selective = 0x4 }
		public Flags flags;
	}
	[TLDef(0x3502758C, "replyKeyboardMarkup#3502758c flags:# resize:flags.0?true single_use:flags.1?true selective:flags.2?true rows:Vector<KeyboardButtonRow> = ReplyMarkup")]
	public class ReplyKeyboardMarkup : ReplyMarkup
	{
		[Flags] public enum Flags { resize = 0x1, single_use = 0x2, selective = 0x4 }
		public Flags flags;
		public KeyboardButtonRow[] rows;
	}
	[TLDef(0x48A30254, "replyInlineMarkup#48a30254 rows:Vector<KeyboardButtonRow> = ReplyMarkup")]
	public class ReplyInlineMarkup : ReplyMarkup { public KeyboardButtonRow[] rows; }

	public abstract class MessageEntity : ITLObject
	{
		public int offset;
		public int length;
	}
	[TLDef(0xBB92BA95, "messageEntityUnknown#bb92ba95 offset:int length:int = MessageEntity")]
	public class MessageEntityUnknown : MessageEntity { }
	[TLDef(0xFA04579D, "messageEntityMention#fa04579d offset:int length:int = MessageEntity")]
	public class MessageEntityMention : MessageEntity { }
	[TLDef(0x6F635B0D, "messageEntityHashtag#6f635b0d offset:int length:int = MessageEntity")]
	public class MessageEntityHashtag : MessageEntity { }
	[TLDef(0x6CEF8AC7, "messageEntityBotCommand#6cef8ac7 offset:int length:int = MessageEntity")]
	public class MessageEntityBotCommand : MessageEntity { }
	[TLDef(0x6ED02538, "messageEntityUrl#6ed02538 offset:int length:int = MessageEntity")]
	public class MessageEntityUrl : MessageEntity { }
	[TLDef(0x64E475C2, "messageEntityEmail#64e475c2 offset:int length:int = MessageEntity")]
	public class MessageEntityEmail : MessageEntity { }
	[TLDef(0xBD610BC9, "messageEntityBold#bd610bc9 offset:int length:int = MessageEntity")]
	public class MessageEntityBold : MessageEntity { }
	[TLDef(0x826F8B60, "messageEntityItalic#826f8b60 offset:int length:int = MessageEntity")]
	public class MessageEntityItalic : MessageEntity { }
	[TLDef(0x28A20571, "messageEntityCode#28a20571 offset:int length:int = MessageEntity")]
	public class MessageEntityCode : MessageEntity { }
	[TLDef(0x73924BE0, "messageEntityPre#73924be0 offset:int length:int language:string = MessageEntity")]
	public class MessageEntityPre : MessageEntity { public string language; }
	[TLDef(0x76A6D327, "messageEntityTextUrl#76a6d327 offset:int length:int url:string = MessageEntity")]
	public class MessageEntityTextUrl : MessageEntity { public string url; }
	[TLDef(0x352DCA58, "messageEntityMentionName#352dca58 offset:int length:int user_id:int = MessageEntity")]
	public class MessageEntityMentionName : MessageEntity { public int user_id; }
	[TLDef(0x208E68C9, "inputMessageEntityMentionName#208e68c9 offset:int length:int user_id:InputUser = MessageEntity")]
	public class InputMessageEntityMentionName : MessageEntity { public InputUserBase user_id; }
	[TLDef(0x9B69E34B, "messageEntityPhone#9b69e34b offset:int length:int = MessageEntity")]
	public class MessageEntityPhone : MessageEntity { }
	[TLDef(0x4C4E743F, "messageEntityCashtag#4c4e743f offset:int length:int = MessageEntity")]
	public class MessageEntityCashtag : MessageEntity { }
	[TLDef(0x9C4E7E8B, "messageEntityUnderline#9c4e7e8b offset:int length:int = MessageEntity")]
	public class MessageEntityUnderline : MessageEntity { }
	[TLDef(0xBF0693D4, "messageEntityStrike#bf0693d4 offset:int length:int = MessageEntity")]
	public class MessageEntityStrike : MessageEntity { }
	[TLDef(0x20DF5D0, "messageEntityBlockquote#020df5d0 offset:int length:int = MessageEntity")]
	public class MessageEntityBlockquote : MessageEntity { }
	[TLDef(0x761E6AF4, "messageEntityBankCard#761e6af4 offset:int length:int = MessageEntity")]
	public class MessageEntityBankCard : MessageEntity { }

	public abstract class InputChannelBase : ITLObject { }
	[TLDef(0xEE8C1E86, "inputChannelEmpty#ee8c1e86 = InputChannel")]
	public class InputChannelEmpty : InputChannelBase { }
	[TLDef(0xAFEB712E, "inputChannel#afeb712e channel_id:int access_hash:long = InputChannel")]
	public class InputChannel : InputChannelBase
	{
		public int channel_id;
		public long access_hash;
	}
	[TLDef(0x2A286531, "inputChannelFromMessage#2a286531 peer:InputPeer msg_id:int channel_id:int = InputChannel")]
	public class InputChannelFromMessage : InputChannelBase
	{
		public InputPeer peer;
		public int msg_id;
		public int channel_id;
	}

	[TLDef(0x7F077AD9, "contacts.resolvedPeer#7f077ad9 peer:Peer chats:Vector<Chat> users:Vector<User> = contacts.ResolvedPeer")]
	public class Contacts_ResolvedPeer : ITLObject
	{
		public Peer peer;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0xAE30253, "messageRange#0ae30253 min_id:int max_id:int = MessageRange")]
	public class MessageRange : ITLObject
	{
		public int min_id;
		public int max_id;
	}

	public abstract class Updates_ChannelDifferenceBase : ITLObject { }
	[TLDef(0x3E11AFFB, "updates.channelDifferenceEmpty#3e11affb flags:# final:flags.0?true pts:int timeout:flags.1?int = updates.ChannelDifference")]
	public class Updates_ChannelDifferenceEmpty : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int timeout;
	}
	[TLDef(0xA4BCC6FE, "updates.channelDifferenceTooLong#a4bcc6fe flags:# final:flags.0?true timeout:flags.1?int dialog:Dialog messages:Vector<Message> chats:Vector<Chat> users:Vector<User> = updates.ChannelDifference")]
	public class Updates_ChannelDifferenceTooLong : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		[IfFlag(1)] public int timeout;
		public DialogBase dialog;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0x2064674E, "updates.channelDifference#2064674e flags:# final:flags.0?true pts:int timeout:flags.1?int new_messages:Vector<Message> other_updates:Vector<Update> chats:Vector<Chat> users:Vector<User> = updates.ChannelDifference")]
	public class Updates_ChannelDifference : Updates_ChannelDifferenceBase
	{
		[Flags] public enum Flags { final = 0x1, has_timeout = 0x2 }
		public Flags flags;
		public int pts;
		[IfFlag(1)] public int timeout;
		public MessageBase[] new_messages;
		public Update[] other_updates;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	public abstract class ChannelMessagesFilterBase : ITLObject { }
	[TLDef(0x94D42EE7, "channelMessagesFilterEmpty#94d42ee7 = ChannelMessagesFilter")]
	public class ChannelMessagesFilterEmpty : ChannelMessagesFilterBase { }
	[TLDef(0xCD77D957, "channelMessagesFilter#cd77d957 flags:# exclude_new_messages:flags.1?true ranges:Vector<MessageRange> = ChannelMessagesFilter")]
	public class ChannelMessagesFilter : ChannelMessagesFilterBase
	{
		[Flags] public enum Flags { exclude_new_messages = 0x2 }
		public Flags flags;
		public MessageRange[] ranges;
	}

	public abstract class ChannelParticipantBase : ITLObject { }
	[TLDef(0x15EBAC1D, "channelParticipant#15ebac1d user_id:int date:int = ChannelParticipant")]
	public class ChannelParticipant : ChannelParticipantBase
	{
		public int user_id;
		public DateTime date;
	}
	[TLDef(0xA3289A6D, "channelParticipantSelf#a3289a6d user_id:int inviter_id:int date:int = ChannelParticipant")]
	public class ChannelParticipantSelf : ChannelParticipantBase
	{
		public int user_id;
		public int inviter_id;
		public DateTime date;
	}
	[TLDef(0x447DCA4B, "channelParticipantCreator#447dca4b flags:# user_id:int admin_rights:ChatAdminRights rank:flags.0?string = ChannelParticipant")]
	public class ChannelParticipantCreator : ChannelParticipantBase
	{
		[Flags] public enum Flags { has_rank = 0x1 }
		public Flags flags;
		public int user_id;
		public ChatAdminRights admin_rights;
		[IfFlag(0)] public string rank;
	}
	[TLDef(0xCCBEBBAF, "channelParticipantAdmin#ccbebbaf flags:# can_edit:flags.0?true self:flags.1?true user_id:int inviter_id:flags.1?int promoted_by:int date:int admin_rights:ChatAdminRights rank:flags.2?string = ChannelParticipant")]
	public class ChannelParticipantAdmin : ChannelParticipantBase
	{
		[Flags] public enum Flags { can_edit = 0x1, self = 0x2, has_rank = 0x4 }
		public Flags flags;
		public int user_id;
		[IfFlag(1)] public int inviter_id;
		public int promoted_by;
		public DateTime date;
		public ChatAdminRights admin_rights;
		[IfFlag(2)] public string rank;
	}
	[TLDef(0x1C0FACAF, "channelParticipantBanned#1c0facaf flags:# left:flags.0?true user_id:int kicked_by:int date:int banned_rights:ChatBannedRights = ChannelParticipant")]
	public class ChannelParticipantBanned : ChannelParticipantBase
	{
		[Flags] public enum Flags { left = 0x1 }
		public Flags flags;
		public int user_id;
		public int kicked_by;
		public DateTime date;
		public ChatBannedRights banned_rights;
	}
	[TLDef(0xC3C6796B, "channelParticipantLeft#c3c6796b user_id:int = ChannelParticipant")]
	public class ChannelParticipantLeft : ChannelParticipantBase { public int user_id; }

	public abstract class ChannelParticipantsFilter : ITLObject { }
	[TLDef(0xDE3F3C79, "channelParticipantsRecent#de3f3c79 = ChannelParticipantsFilter")]
	public class ChannelParticipantsRecent : ChannelParticipantsFilter { }
	[TLDef(0xB4608969, "channelParticipantsAdmins#b4608969 = ChannelParticipantsFilter")]
	public class ChannelParticipantsAdmins : ChannelParticipantsFilter { }
	[TLDef(0xA3B54985, "channelParticipantsKicked#a3b54985 q:string = ChannelParticipantsFilter")]
	public class ChannelParticipantsKicked : ChannelParticipantsFilter { public string q; }
	[TLDef(0xB0D1865B, "channelParticipantsBots#b0d1865b = ChannelParticipantsFilter")]
	public class ChannelParticipantsBots : ChannelParticipantsFilter { }
	[TLDef(0x1427A5E1, "channelParticipantsBanned#1427a5e1 q:string = ChannelParticipantsFilter")]
	public class ChannelParticipantsBanned : ChannelParticipantsFilter { public string q; }
	[TLDef(0x656AC4B, "channelParticipantsSearch#0656ac4b q:string = ChannelParticipantsFilter")]
	public class ChannelParticipantsSearch : ChannelParticipantsFilter { public string q; }
	[TLDef(0xBB6AE88D, "channelParticipantsContacts#bb6ae88d q:string = ChannelParticipantsFilter")]
	public class ChannelParticipantsContacts : ChannelParticipantsFilter { public string q; }
	[TLDef(0xE04B5CEB, "channelParticipantsMentions#e04b5ceb flags:# q:flags.0?string top_msg_id:flags.1?int = ChannelParticipantsFilter")]
	public class ChannelParticipantsMentions : ChannelParticipantsFilter
	{
		[Flags] public enum Flags { has_q = 0x1, has_top_msg_id = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string q;
		[IfFlag(1)] public int top_msg_id;
	}

	public abstract class Channels_ChannelParticipantsBase : ITLObject { }
	[TLDef(0xF56EE2A8, "channels.channelParticipants#f56ee2a8 count:int participants:Vector<ChannelParticipant> users:Vector<User> = channels.ChannelParticipants")]
	public class Channels_ChannelParticipants : Channels_ChannelParticipantsBase
	{
		public int count;
		public ChannelParticipantBase[] participants;
		public UserBase[] users;
	}
	[TLDef(0xF0173FE9, "channels.channelParticipantsNotModified#f0173fe9 = channels.ChannelParticipants")]
	public class Channels_ChannelParticipantsNotModified : Channels_ChannelParticipantsBase { }

	[TLDef(0xD0D9B163, "channels.channelParticipant#d0d9b163 participant:ChannelParticipant users:Vector<User> = channels.ChannelParticipant")]
	public class Channels_ChannelParticipant : ITLObject
	{
		public ChannelParticipantBase participant;
		public UserBase[] users;
	}

	[TLDef(0x780A0310, "help.termsOfService#780a0310 flags:# popup:flags.0?true id:DataJSON text:string entities:Vector<MessageEntity> min_age_confirm:flags.1?int = help.TermsOfService")]
	public class Help_TermsOfService : ITLObject
	{
		[Flags] public enum Flags { popup = 0x1, has_min_age_confirm = 0x2 }
		public Flags flags;
		public DataJSON id;
		public string text;
		public MessageEntity[] entities;
		[IfFlag(1)] public int min_age_confirm;
	}

	public abstract class Messages_SavedGifsBase : ITLObject { }
	[TLDef(0xE8025CA2, "messages.savedGifsNotModified#e8025ca2 = messages.SavedGifs")]
	public class Messages_SavedGifsNotModified : Messages_SavedGifsBase { }
	[TLDef(0x2E0709A5, "messages.savedGifs#2e0709a5 hash:int gifs:Vector<Document> = messages.SavedGifs")]
	public class Messages_SavedGifs : Messages_SavedGifsBase
	{
		public int hash;
		public DocumentBase[] gifs;
	}

	public abstract class InputBotInlineMessage : ITLObject { public int flags; }
	[TLDef(0x3380C786, "inputBotInlineMessageMediaAuto#3380c786 flags:# message:string entities:flags.1?Vector<MessageEntity> reply_markup:flags.2?ReplyMarkup = InputBotInlineMessage")]
	public class InputBotInlineMessageMediaAuto : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x3DCD7A87, "inputBotInlineMessageText#3dcd7a87 flags:# no_webpage:flags.0?true message:string entities:flags.1?Vector<MessageEntity> reply_markup:flags.2?ReplyMarkup = InputBotInlineMessage")]
	public class InputBotInlineMessageText : InputBotInlineMessage
	{
		[Flags] public enum Flags { no_webpage = 0x1, has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x96929A85, "inputBotInlineMessageMediaGeo#96929a85 flags:# geo_point:InputGeoPoint heading:flags.0?int period:flags.1?int proximity_notification_radius:flags.3?int reply_markup:flags.2?ReplyMarkup = InputBotInlineMessage")]
	public class InputBotInlineMessageMediaGeo : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_heading = 0x1, has_period = 0x2, has_reply_markup = 0x4, 
			has_proximity_notification_radius = 0x8 }
		public InputGeoPointBase geo_point;
		[IfFlag(0)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x417BBF11, "inputBotInlineMessageMediaVenue#417bbf11 flags:# geo_point:InputGeoPoint title:string address:string provider:string venue_id:string venue_type:string reply_markup:flags.2?ReplyMarkup = InputBotInlineMessage")]
	public class InputBotInlineMessageMediaVenue : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public InputGeoPointBase geo_point;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0xA6EDBFFD, "inputBotInlineMessageMediaContact#a6edbffd flags:# phone_number:string first_name:string last_name:string vcard:string reply_markup:flags.2?ReplyMarkup = InputBotInlineMessage")]
	public class InputBotInlineMessageMediaContact : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x4B425864, "inputBotInlineMessageGame#4b425864 flags:# reply_markup:flags.2?ReplyMarkup = InputBotInlineMessage")]
	public class InputBotInlineMessageGame : InputBotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}

	public abstract class InputBotInlineResultBase : ITLObject { }
	[TLDef(0x88BF9319, "inputBotInlineResult#88bf9319 flags:# id:string type:string title:flags.1?string description:flags.2?string url:flags.3?string thumb:flags.4?InputWebDocument content:flags.5?InputWebDocument send_message:InputBotInlineMessage = InputBotInlineResult")]
	public class InputBotInlineResult : InputBotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4, has_url = 0x8, has_thumb = 0x10, has_content = 0x20 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		[IfFlag(3)] public string url;
		[IfFlag(4)] public InputWebDocument thumb;
		[IfFlag(5)] public InputWebDocument content;
		public InputBotInlineMessage send_message;
	}
	[TLDef(0xA8D864A7, "inputBotInlineResultPhoto#a8d864a7 id:string type:string photo:InputPhoto send_message:InputBotInlineMessage = InputBotInlineResult")]
	public class InputBotInlineResultPhoto : InputBotInlineResultBase
	{
		public string id;
		public string type;
		public InputPhotoBase photo;
		public InputBotInlineMessage send_message;
	}
	[TLDef(0xFFF8FDC4, "inputBotInlineResultDocument#fff8fdc4 flags:# id:string type:string title:flags.1?string description:flags.2?string document:InputDocument send_message:InputBotInlineMessage = InputBotInlineResult")]
	public class InputBotInlineResultDocument : InputBotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		public InputDocumentBase document;
		public InputBotInlineMessage send_message;
	}
	[TLDef(0x4FA417F2, "inputBotInlineResultGame#4fa417f2 id:string short_name:string send_message:InputBotInlineMessage = InputBotInlineResult")]
	public class InputBotInlineResultGame : InputBotInlineResultBase
	{
		public string id;
		public string short_name;
		public InputBotInlineMessage send_message;
	}

	public abstract class BotInlineMessage : ITLObject { public int flags; }
	[TLDef(0x764CF810, "botInlineMessageMediaAuto#764cf810 flags:# message:string entities:flags.1?Vector<MessageEntity> reply_markup:flags.2?ReplyMarkup = BotInlineMessage")]
	public class BotInlineMessageMediaAuto : BotInlineMessage
	{
		[Flags] public enum Flags { has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x8C7F65E2, "botInlineMessageText#8c7f65e2 flags:# no_webpage:flags.0?true message:string entities:flags.1?Vector<MessageEntity> reply_markup:flags.2?ReplyMarkup = BotInlineMessage")]
	public class BotInlineMessageText : BotInlineMessage
	{
		[Flags] public enum Flags { no_webpage = 0x1, has_entities = 0x2, has_reply_markup = 0x4 }
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x51846FD, "botInlineMessageMediaGeo#051846fd flags:# geo:GeoPoint heading:flags.0?int period:flags.1?int proximity_notification_radius:flags.3?int reply_markup:flags.2?ReplyMarkup = BotInlineMessage")]
	public class BotInlineMessageMediaGeo : BotInlineMessage
	{
		[Flags] public enum Flags { has_heading = 0x1, has_period = 0x2, has_reply_markup = 0x4, 
			has_proximity_notification_radius = 0x8 }
		public GeoPointBase geo;
		[IfFlag(0)] public int heading;
		[IfFlag(1)] public int period;
		[IfFlag(3)] public int proximity_notification_radius;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x8A86659C, "botInlineMessageMediaVenue#8a86659c flags:# geo:GeoPoint title:string address:string provider:string venue_id:string venue_type:string reply_markup:flags.2?ReplyMarkup = BotInlineMessage")]
	public class BotInlineMessageMediaVenue : BotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public GeoPointBase geo;
		public string title;
		public string address;
		public string provider;
		public string venue_id;
		public string venue_type;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}
	[TLDef(0x18D1CDC2, "botInlineMessageMediaContact#18d1cdc2 flags:# phone_number:string first_name:string last_name:string vcard:string reply_markup:flags.2?ReplyMarkup = BotInlineMessage")]
	public class BotInlineMessageMediaContact : BotInlineMessage
	{
		[Flags] public enum Flags { has_reply_markup = 0x4 }
		public string phone_number;
		public string first_name;
		public string last_name;
		public string vcard;
		[IfFlag(2)] public ReplyMarkup reply_markup;
	}

	public abstract class BotInlineResultBase : ITLObject { }
	[TLDef(0x11965F3A, "botInlineResult#11965f3a flags:# id:string type:string title:flags.1?string description:flags.2?string url:flags.3?string thumb:flags.4?WebDocument content:flags.5?WebDocument send_message:BotInlineMessage = BotInlineResult")]
	public class BotInlineResult : BotInlineResultBase
	{
		[Flags] public enum Flags { has_title = 0x2, has_description = 0x4, has_url = 0x8, has_thumb = 0x10, has_content = 0x20 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(1)] public string title;
		[IfFlag(2)] public string description;
		[IfFlag(3)] public string url;
		[IfFlag(4)] public WebDocumentBase thumb;
		[IfFlag(5)] public WebDocumentBase content;
		public BotInlineMessage send_message;
	}
	[TLDef(0x17DB940B, "botInlineMediaResult#17db940b flags:# id:string type:string photo:flags.0?Photo document:flags.1?Document title:flags.2?string description:flags.3?string send_message:BotInlineMessage = BotInlineResult")]
	public class BotInlineMediaResult : BotInlineResultBase
	{
		[Flags] public enum Flags { has_photo = 0x1, has_document = 0x2, has_title = 0x4, has_description = 0x8 }
		public Flags flags;
		public string id;
		public string type;
		[IfFlag(0)] public PhotoBase photo;
		[IfFlag(1)] public DocumentBase document;
		[IfFlag(2)] public string title;
		[IfFlag(3)] public string description;
		public BotInlineMessage send_message;
	}

	[TLDef(0x947CA848, "messages.botResults#947ca848 flags:# gallery:flags.0?true query_id:long next_offset:flags.1?string switch_pm:flags.2?InlineBotSwitchPM results:Vector<BotInlineResult> cache_time:int users:Vector<User> = messages.BotResults")]
	public class Messages_BotResults : ITLObject
	{
		[Flags] public enum Flags { gallery = 0x1, has_next_offset = 0x2, has_switch_pm = 0x4 }
		public Flags flags;
		public long query_id;
		[IfFlag(1)] public string next_offset;
		[IfFlag(2)] public InlineBotSwitchPM switch_pm;
		public BotInlineResultBase[] results;
		public DateTime cache_time;
		public UserBase[] users;
	}

	[TLDef(0x5DAB1AF4, "exportedMessageLink#5dab1af4 link:string html:string = ExportedMessageLink")]
	public class ExportedMessageLink : ITLObject
	{
		public string link;
		public string html;
	}

	[TLDef(0x5F777DCE, "messageFwdHeader#5f777dce flags:# imported:flags.7?true from_id:flags.0?Peer from_name:flags.5?string date:int channel_post:flags.2?int post_author:flags.3?string saved_from_peer:flags.4?Peer saved_from_msg_id:flags.4?int psa_type:flags.6?string = MessageFwdHeader")]
	public class MessageFwdHeader : ITLObject
	{
		[Flags] public enum Flags { has_from_id = 0x1, has_channel_post = 0x4, has_post_author = 0x8, has_saved_from_peer = 0x10, 
			has_from_name = 0x20, has_psa_type = 0x40, imported = 0x80 }
		public Flags flags;
		[IfFlag(0)] public Peer from_id;
		[IfFlag(5)] public string from_name;
		public DateTime date;
		[IfFlag(2)] public int channel_post;
		[IfFlag(3)] public string post_author;
		[IfFlag(4)] public Peer saved_from_peer;
		[IfFlag(4)] public int saved_from_msg_id;
		[IfFlag(6)] public string psa_type;
	}

	public abstract class Auth_CodeType : ITLObject { }
	[TLDef(0x72A3158C, "auth.codeTypeSms#72a3158c = auth.CodeType")]
	public class Auth_CodeTypeSms : Auth_CodeType { }
	[TLDef(0x741CD3E3, "auth.codeTypeCall#741cd3e3 = auth.CodeType")]
	public class Auth_CodeTypeCall : Auth_CodeType { }
	[TLDef(0x226CCEFB, "auth.codeTypeFlashCall#226ccefb = auth.CodeType")]
	public class Auth_CodeTypeFlashCall : Auth_CodeType { }

	public abstract class Auth_SentCodeType : ITLObject { }
	[TLDef(0x3DBB5986, "auth.sentCodeTypeApp#3dbb5986 length:int = auth.SentCodeType")]
	public class Auth_SentCodeTypeApp : Auth_SentCodeType { public int length; }
	[TLDef(0xC000BBA2, "auth.sentCodeTypeSms#c000bba2 length:int = auth.SentCodeType")]
	public class Auth_SentCodeTypeSms : Auth_SentCodeType { public int length; }
	[TLDef(0x5353E5A7, "auth.sentCodeTypeCall#5353e5a7 length:int = auth.SentCodeType")]
	public class Auth_SentCodeTypeCall : Auth_SentCodeType { public int length; }
	[TLDef(0xAB03C6D9, "auth.sentCodeTypeFlashCall#ab03c6d9 pattern:string = auth.SentCodeType")]
	public class Auth_SentCodeTypeFlashCall : Auth_SentCodeType { public string pattern; }

	[TLDef(0x36585EA4, "messages.botCallbackAnswer#36585ea4 flags:# alert:flags.1?true has_url:flags.3?true native_ui:flags.4?true message:flags.0?string url:flags.2?string cache_time:int = messages.BotCallbackAnswer")]
	public class Messages_BotCallbackAnswer : ITLObject
	{
		[Flags] public enum Flags { has_message = 0x1, alert = 0x2, has_url_field = 0x4, has_url = 0x8, native_ui = 0x10 }
		public Flags flags;
		[IfFlag(0)] public string message;
		[IfFlag(2)] public string url;
		public DateTime cache_time;
	}

	[TLDef(0x26B5DDE6, "messages.messageEditData#26b5dde6 flags:# caption:flags.0?true = messages.MessageEditData")]
	public class Messages_MessageEditData : ITLObject
	{
		[Flags] public enum Flags { caption = 0x1 }
		public Flags flags;
	}

	[TLDef(0x890C3D89, "inputBotInlineMessageID#890c3d89 dc_id:int id:long access_hash:long = InputBotInlineMessageID")]
	public class InputBotInlineMessageID : ITLObject
	{
		public int dc_id;
		public long id;
		public long access_hash;
	}

	[TLDef(0x3C20629F, "inlineBotSwitchPM#3c20629f text:string start_param:string = InlineBotSwitchPM")]
	public class InlineBotSwitchPM : ITLObject
	{
		public string text;
		public string start_param;
	}

	[TLDef(0x3371C354, "messages.peerDialogs#3371c354 dialogs:Vector<Dialog> messages:Vector<Message> chats:Vector<Chat> users:Vector<User> state:updates.State = messages.PeerDialogs")]
	public class Messages_PeerDialogs : ITLObject
	{
		public DialogBase[] dialogs;
		public MessageBase[] messages;
		public ChatBase[] chats;
		public UserBase[] users;
		public Updates_State state;
	}

	[TLDef(0xEDCDC05B, "topPeer#edcdc05b peer:Peer rating:double = TopPeer")]
	public class TopPeer : ITLObject
	{
		public Peer peer;
		public double rating;
	}

	public abstract class TopPeerCategory : ITLObject { }
	[TLDef(0xAB661B5B, "topPeerCategoryBotsPM#ab661b5b = TopPeerCategory")]
	public class TopPeerCategoryBotsPM : TopPeerCategory { }
	[TLDef(0x148677E2, "topPeerCategoryBotsInline#148677e2 = TopPeerCategory")]
	public class TopPeerCategoryBotsInline : TopPeerCategory { }
	[TLDef(0x637B7ED, "topPeerCategoryCorrespondents#0637b7ed = TopPeerCategory")]
	public class TopPeerCategoryCorrespondents : TopPeerCategory { }
	[TLDef(0xBD17A14A, "topPeerCategoryGroups#bd17a14a = TopPeerCategory")]
	public class TopPeerCategoryGroups : TopPeerCategory { }
	[TLDef(0x161D9628, "topPeerCategoryChannels#161d9628 = TopPeerCategory")]
	public class TopPeerCategoryChannels : TopPeerCategory { }
	[TLDef(0x1E76A78C, "topPeerCategoryPhoneCalls#1e76a78c = TopPeerCategory")]
	public class TopPeerCategoryPhoneCalls : TopPeerCategory { }
	[TLDef(0xA8406CA9, "topPeerCategoryForwardUsers#a8406ca9 = TopPeerCategory")]
	public class TopPeerCategoryForwardUsers : TopPeerCategory { }
	[TLDef(0xFBEEC0F0, "topPeerCategoryForwardChats#fbeec0f0 = TopPeerCategory")]
	public class TopPeerCategoryForwardChats : TopPeerCategory { }

	[TLDef(0xFB834291, "topPeerCategoryPeers#fb834291 category:TopPeerCategory count:int peers:Vector<TopPeer> = TopPeerCategoryPeers")]
	public class TopPeerCategoryPeers : ITLObject
	{
		public TopPeerCategory category;
		public int count;
		public TopPeer[] peers;
	}

	public abstract class Contacts_TopPeersBase : ITLObject { }
	[TLDef(0xDE266EF5, "contacts.topPeersNotModified#de266ef5 = contacts.TopPeers")]
	public class Contacts_TopPeersNotModified : Contacts_TopPeersBase { }
	[TLDef(0x70B772A8, "contacts.topPeers#70b772a8 categories:Vector<TopPeerCategoryPeers> chats:Vector<Chat> users:Vector<User> = contacts.TopPeers")]
	public class Contacts_TopPeers : Contacts_TopPeersBase
	{
		public TopPeerCategoryPeers[] categories;
		public ChatBase[] chats;
		public UserBase[] users;
	}
	[TLDef(0xB52C939D, "contacts.topPeersDisabled#b52c939d = contacts.TopPeers")]
	public class Contacts_TopPeersDisabled : Contacts_TopPeersBase { }

	public abstract class DraftMessageBase : ITLObject { }
	[TLDef(0x1B0C841A, "draftMessageEmpty#1b0c841a flags:# date:flags.0?int = DraftMessage")]
	public class DraftMessageEmpty : DraftMessageBase
	{
		[Flags] public enum Flags { has_date = 0x1 }
		public Flags flags;
		[IfFlag(0)] public DateTime date;
	}
	[TLDef(0xFD8E711F, "draftMessage#fd8e711f flags:# no_webpage:flags.1?true reply_to_msg_id:flags.0?int message:string entities:flags.3?Vector<MessageEntity> date:int = DraftMessage")]
	public class DraftMessage : DraftMessageBase
	{
		[Flags] public enum Flags { has_reply_to_msg_id = 0x1, no_webpage = 0x2, has_entities = 0x8 }
		public Flags flags;
		[IfFlag(0)] public int reply_to_msg_id;
		public string message;
		[IfFlag(3)] public MessageEntity[] entities;
		public DateTime date;
	}

	public abstract class Messages_FeaturedStickersBase : ITLObject { }
	[TLDef(0xC6DC0C66, "messages.featuredStickersNotModified#c6dc0c66 count:int = messages.FeaturedStickers")]
	public class Messages_FeaturedStickersNotModified : Messages_FeaturedStickersBase { public int count; }
	[TLDef(0xB6ABC341, "messages.featuredStickers#b6abc341 hash:int count:int sets:Vector<StickerSetCovered> unread:Vector<long> = messages.FeaturedStickers")]
	public class Messages_FeaturedStickers : Messages_FeaturedStickersBase
	{
		public int hash;
		public int count;
		public StickerSetCoveredBase[] sets;
		public long[] unread;
	}

	public abstract class Messages_RecentStickersBase : ITLObject { }
	[TLDef(0xB17F890, "messages.recentStickersNotModified#0b17f890 = messages.RecentStickers")]
	public class Messages_RecentStickersNotModified : Messages_RecentStickersBase { }
	[TLDef(0x22F3AFB3, "messages.recentStickers#22f3afb3 hash:int packs:Vector<StickerPack> stickers:Vector<Document> dates:Vector<int> = messages.RecentStickers")]
	public class Messages_RecentStickers : Messages_RecentStickersBase
	{
		public int hash;
		public StickerPack[] packs;
		public DocumentBase[] stickers;
		public int[] dates;
	}

	[TLDef(0x4FCBA9C8, "messages.archivedStickers#4fcba9c8 count:int sets:Vector<StickerSetCovered> = messages.ArchivedStickers")]
	public class Messages_ArchivedStickers : ITLObject
	{
		public int count;
		public StickerSetCoveredBase[] sets;
	}

	public abstract class Messages_StickerSetInstallResult : ITLObject { }
	[TLDef(0x38641628, "messages.stickerSetInstallResultSuccess#38641628 = messages.StickerSetInstallResult")]
	public class Messages_StickerSetInstallResultSuccess : Messages_StickerSetInstallResult { }
	[TLDef(0x35E410A8, "messages.stickerSetInstallResultArchive#35e410a8 sets:Vector<StickerSetCovered> = messages.StickerSetInstallResult")]
	public class Messages_StickerSetInstallResultArchive : Messages_StickerSetInstallResult { public StickerSetCoveredBase[] sets; }

	public abstract class StickerSetCoveredBase : ITLObject { }
	[TLDef(0x6410A5D2, "stickerSetCovered#6410a5d2 set:StickerSet cover:Document = StickerSetCovered")]
	public class StickerSetCovered : StickerSetCoveredBase
	{
		public StickerSet set;
		public DocumentBase cover;
	}
	[TLDef(0x3407E51B, "stickerSetMultiCovered#3407e51b set:StickerSet covers:Vector<Document> = StickerSetCovered")]
	public class StickerSetMultiCovered : StickerSetCoveredBase
	{
		public StickerSet set;
		public DocumentBase[] covers;
	}

	[TLDef(0xAED6DBB2, "maskCoords#aed6dbb2 n:int x:double y:double zoom:double = MaskCoords")]
	public class MaskCoords : ITLObject
	{
		public int n;
		public double x;
		public double y;
		public double zoom;
	}

	public abstract class InputStickeredMedia : ITLObject { }
	[TLDef(0x4A992157, "inputStickeredMediaPhoto#4a992157 id:InputPhoto = InputStickeredMedia")]
	public class InputStickeredMediaPhoto : InputStickeredMedia { public InputPhotoBase id; }
	[TLDef(0x438865B, "inputStickeredMediaDocument#0438865b id:InputDocument = InputStickeredMedia")]
	public class InputStickeredMediaDocument : InputStickeredMedia { public InputDocumentBase id; }

	[TLDef(0xBDF9653B, "game#bdf9653b flags:# id:long access_hash:long short_name:string title:string description:string photo:Photo document:flags.0?Document = Game")]
	public class Game : ITLObject
	{
		[Flags] public enum Flags { has_document = 0x1 }
		public Flags flags;
		public long id;
		public long access_hash;
		public string short_name;
		public string title;
		public string description;
		public PhotoBase photo;
		[IfFlag(0)] public DocumentBase document;
	}

	public abstract class InputGame : ITLObject { }
	[TLDef(0x32C3E77, "inputGameID#032c3e77 id:long access_hash:long = InputGame")]
	public class InputGameID : InputGame
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0xC331E80A, "inputGameShortName#c331e80a bot_id:InputUser short_name:string = InputGame")]
	public class InputGameShortName : InputGame
	{
		public InputUserBase bot_id;
		public string short_name;
	}

	[TLDef(0x58FFFCD0, "highScore#58fffcd0 pos:int user_id:int score:int = HighScore")]
	public class HighScore : ITLObject
	{
		public int pos;
		public int user_id;
		public int score;
	}

	[TLDef(0x9A3BFD99, "messages.highScores#9a3bfd99 scores:Vector<HighScore> users:Vector<User> = messages.HighScores")]
	public class Messages_HighScores : ITLObject
	{
		public HighScore[] scores;
		public UserBase[] users;
	}

	public abstract class RichText : ITLObject { }
	[TLDef(0xDC3D824F, "textEmpty#dc3d824f = RichText")]
	public class TextEmpty : RichText { }
	[TLDef(0x744694E0, "textPlain#744694e0 text:string = RichText")]
	public class TextPlain : RichText { public string text; }
	[TLDef(0x6724ABC4, "textBold#6724abc4 text:RichText = RichText")]
	public class TextBold : RichText { public RichText text; }
	[TLDef(0xD912A59C, "textItalic#d912a59c text:RichText = RichText")]
	public class TextItalic : RichText { public RichText text; }
	[TLDef(0xC12622C4, "textUnderline#c12622c4 text:RichText = RichText")]
	public class TextUnderline : RichText { public RichText text; }
	[TLDef(0x9BF8BB95, "textStrike#9bf8bb95 text:RichText = RichText")]
	public class TextStrike : RichText { public RichText text; }
	[TLDef(0x6C3F19B9, "textFixed#6c3f19b9 text:RichText = RichText")]
	public class TextFixed : RichText { public RichText text; }
	[TLDef(0x3C2884C1, "textUrl#3c2884c1 text:RichText url:string webpage_id:long = RichText")]
	public class TextUrl : RichText
	{
		public RichText text;
		public string url;
		public long webpage_id;
	}
	[TLDef(0xDE5A0DD6, "textEmail#de5a0dd6 text:RichText email:string = RichText")]
	public class TextEmail : RichText
	{
		public RichText text;
		public string email;
	}
	[TLDef(0x7E6260D7, "textConcat#7e6260d7 texts:Vector<RichText> = RichText")]
	public class TextConcat : RichText { public RichText[] texts; }
	[TLDef(0xED6A8504, "textSubscript#ed6a8504 text:RichText = RichText")]
	public class TextSubscript : RichText { public RichText text; }
	[TLDef(0xC7FB5E01, "textSuperscript#c7fb5e01 text:RichText = RichText")]
	public class TextSuperscript : RichText { public RichText text; }
	[TLDef(0x34B8621, "textMarked#034b8621 text:RichText = RichText")]
	public class TextMarked : RichText { public RichText text; }
	[TLDef(0x1CCB966A, "textPhone#1ccb966a text:RichText phone:string = RichText")]
	public class TextPhone : RichText
	{
		public RichText text;
		public string phone;
	}
	[TLDef(0x81CCF4F, "textImage#081ccf4f document_id:long w:int h:int = RichText")]
	public class TextImage : RichText
	{
		public long document_id;
		public int w;
		public int h;
	}
	[TLDef(0x35553762, "textAnchor#35553762 text:RichText name:string = RichText")]
	public class TextAnchor : RichText
	{
		public RichText text;
		public string name;
	}

	public abstract class PageBlock : ITLObject { }
	[TLDef(0x13567E8A, "pageBlockUnsupported#13567e8a = PageBlock")]
	public class PageBlockUnsupported : PageBlock { }
	[TLDef(0x70ABC3FD, "pageBlockTitle#70abc3fd text:RichText = PageBlock")]
	public class PageBlockTitle : PageBlock { public RichText text; }
	[TLDef(0x8FFA9A1F, "pageBlockSubtitle#8ffa9a1f text:RichText = PageBlock")]
	public class PageBlockSubtitle : PageBlock { public RichText text; }
	[TLDef(0xBAAFE5E0, "pageBlockAuthorDate#baafe5e0 author:RichText published_date:int = PageBlock")]
	public class PageBlockAuthorDate : PageBlock
	{
		public RichText author;
		public DateTime published_date;
	}
	[TLDef(0xBFD064EC, "pageBlockHeader#bfd064ec text:RichText = PageBlock")]
	public class PageBlockHeader : PageBlock { public RichText text; }
	[TLDef(0xF12BB6E1, "pageBlockSubheader#f12bb6e1 text:RichText = PageBlock")]
	public class PageBlockSubheader : PageBlock { public RichText text; }
	[TLDef(0x467A0766, "pageBlockParagraph#467a0766 text:RichText = PageBlock")]
	public class PageBlockParagraph : PageBlock { public RichText text; }
	[TLDef(0xC070D93E, "pageBlockPreformatted#c070d93e text:RichText language:string = PageBlock")]
	public class PageBlockPreformatted : PageBlock
	{
		public RichText text;
		public string language;
	}
	[TLDef(0x48870999, "pageBlockFooter#48870999 text:RichText = PageBlock")]
	public class PageBlockFooter : PageBlock { public RichText text; }
	[TLDef(0xDB20B188, "pageBlockDivider#db20b188 = PageBlock")]
	public class PageBlockDivider : PageBlock { }
	[TLDef(0xCE0D37B0, "pageBlockAnchor#ce0d37b0 name:string = PageBlock")]
	public class PageBlockAnchor : PageBlock { public string name; }
	[TLDef(0xE4E88011, "pageBlockList#e4e88011 items:Vector<PageListItem> = PageBlock")]
	public class PageBlockList : PageBlock { public PageListItem[] items; }
	[TLDef(0x263D7C26, "pageBlockBlockquote#263d7c26 text:RichText caption:RichText = PageBlock")]
	public class PageBlockBlockquote : PageBlock
	{
		public RichText text;
		public RichText caption;
	}
	[TLDef(0x4F4456D3, "pageBlockPullquote#4f4456d3 text:RichText caption:RichText = PageBlock")]
	public class PageBlockPullquote : PageBlock
	{
		public RichText text;
		public RichText caption;
	}
	[TLDef(0x1759C560, "pageBlockPhoto#1759c560 flags:# photo_id:long caption:PageCaption url:flags.0?string webpage_id:flags.0?long = PageBlock")]
	public class PageBlockPhoto : PageBlock
	{
		[Flags] public enum Flags { has_url = 0x1 }
		public Flags flags;
		public long photo_id;
		public PageCaption caption;
		[IfFlag(0)] public string url;
		[IfFlag(0)] public long webpage_id;
	}
	[TLDef(0x7C8FE7B6, "pageBlockVideo#7c8fe7b6 flags:# autoplay:flags.0?true loop:flags.1?true video_id:long caption:PageCaption = PageBlock")]
	public class PageBlockVideo : PageBlock
	{
		[Flags] public enum Flags { autoplay = 0x1, loop = 0x2 }
		public Flags flags;
		public long video_id;
		public PageCaption caption;
	}
	[TLDef(0x39F23300, "pageBlockCover#39f23300 cover:PageBlock = PageBlock")]
	public class PageBlockCover : PageBlock { public PageBlock cover; }
	[TLDef(0xA8718DC5, "pageBlockEmbed#a8718dc5 flags:# full_width:flags.0?true allow_scrolling:flags.3?true url:flags.1?string html:flags.2?string poster_photo_id:flags.4?long w:flags.5?int h:flags.5?int caption:PageCaption = PageBlock")]
	public class PageBlockEmbed : PageBlock
	{
		[Flags] public enum Flags { full_width = 0x1, has_url = 0x2, has_html = 0x4, allow_scrolling = 0x8, has_poster_photo_id = 0x10, 
			has_w = 0x20 }
		public Flags flags;
		[IfFlag(1)] public string url;
		[IfFlag(2)] public string html;
		[IfFlag(4)] public long poster_photo_id;
		[IfFlag(5)] public int w;
		[IfFlag(5)] public int h;
		public PageCaption caption;
	}
	[TLDef(0xF259A80B, "pageBlockEmbedPost#f259a80b url:string webpage_id:long author_photo_id:long author:string date:int blocks:Vector<PageBlock> caption:PageCaption = PageBlock")]
	public class PageBlockEmbedPost : PageBlock
	{
		public string url;
		public long webpage_id;
		public long author_photo_id;
		public string author;
		public DateTime date;
		public PageBlock[] blocks;
		public PageCaption caption;
	}
	[TLDef(0x65A0FA4D, "pageBlockCollage#65a0fa4d items:Vector<PageBlock> caption:PageCaption = PageBlock")]
	public class PageBlockCollage : PageBlock
	{
		public PageBlock[] items;
		public PageCaption caption;
	}
	[TLDef(0x31F9590, "pageBlockSlideshow#031f9590 items:Vector<PageBlock> caption:PageCaption = PageBlock")]
	public class PageBlockSlideshow : PageBlock
	{
		public PageBlock[] items;
		public PageCaption caption;
	}
	[TLDef(0xEF1751B5, "pageBlockChannel#ef1751b5 channel:Chat = PageBlock")]
	public class PageBlockChannel : PageBlock { public ChatBase channel; }
	[TLDef(0x804361EA, "pageBlockAudio#804361ea audio_id:long caption:PageCaption = PageBlock")]
	public class PageBlockAudio : PageBlock
	{
		public long audio_id;
		public PageCaption caption;
	}
	[TLDef(0x1E148390, "pageBlockKicker#1e148390 text:RichText = PageBlock")]
	public class PageBlockKicker : PageBlock { public RichText text; }
	[TLDef(0xBF4DEA82, "pageBlockTable#bf4dea82 flags:# bordered:flags.0?true striped:flags.1?true title:RichText rows:Vector<PageTableRow> = PageBlock")]
	public class PageBlockTable : PageBlock
	{
		[Flags] public enum Flags { bordered = 0x1, striped = 0x2 }
		public Flags flags;
		public RichText title;
		public PageTableRow[] rows;
	}
	[TLDef(0x9A8AE1E1, "pageBlockOrderedList#9a8ae1e1 items:Vector<PageListOrderedItem> = PageBlock")]
	public class PageBlockOrderedList : PageBlock { public PageListOrderedItem[] items; }
	[TLDef(0x76768BED, "pageBlockDetails#76768bed flags:# open:flags.0?true blocks:Vector<PageBlock> title:RichText = PageBlock")]
	public class PageBlockDetails : PageBlock
	{
		[Flags] public enum Flags { open = 0x1 }
		public Flags flags;
		public PageBlock[] blocks;
		public RichText title;
	}
	[TLDef(0x16115A96, "pageBlockRelatedArticles#16115a96 title:RichText articles:Vector<PageRelatedArticle> = PageBlock")]
	public class PageBlockRelatedArticles : PageBlock
	{
		public RichText title;
		public PageRelatedArticle[] articles;
	}
	[TLDef(0xA44F3EF6, "pageBlockMap#a44f3ef6 geo:GeoPoint zoom:int w:int h:int caption:PageCaption = PageBlock")]
	public class PageBlockMap : PageBlock
	{
		public GeoPointBase geo;
		public int zoom;
		public int w;
		public int h;
		public PageCaption caption;
	}

	public abstract class PhoneCallDiscardReason : ITLObject { }
	[TLDef(0x85E42301, "phoneCallDiscardReasonMissed#85e42301 = PhoneCallDiscardReason")]
	public class PhoneCallDiscardReasonMissed : PhoneCallDiscardReason { }
	[TLDef(0xE095C1A0, "phoneCallDiscardReasonDisconnect#e095c1a0 = PhoneCallDiscardReason")]
	public class PhoneCallDiscardReasonDisconnect : PhoneCallDiscardReason { }
	[TLDef(0x57ADC690, "phoneCallDiscardReasonHangup#57adc690 = PhoneCallDiscardReason")]
	public class PhoneCallDiscardReasonHangup : PhoneCallDiscardReason { }
	[TLDef(0xFAF7E8C9, "phoneCallDiscardReasonBusy#faf7e8c9 = PhoneCallDiscardReason")]
	public class PhoneCallDiscardReasonBusy : PhoneCallDiscardReason { }

	[TLDef(0x7D748D04, "dataJSON#7d748d04 data:string = DataJSON")]
	public class DataJSON : ITLObject { public string data; }

	[TLDef(0xCB296BF8, "labeledPrice#cb296bf8 label:string amount:long = LabeledPrice")]
	public class LabeledPrice : ITLObject
	{
		public string label;
		public long amount;
	}

	[TLDef(0xC30AA358, "invoice#c30aa358 flags:# test:flags.0?true name_requested:flags.1?true phone_requested:flags.2?true email_requested:flags.3?true shipping_address_requested:flags.4?true flexible:flags.5?true phone_to_provider:flags.6?true email_to_provider:flags.7?true currency:string prices:Vector<LabeledPrice> = Invoice")]
	public class Invoice : ITLObject
	{
		[Flags] public enum Flags { test = 0x1, name_requested = 0x2, phone_requested = 0x4, email_requested = 0x8, 
			shipping_address_requested = 0x10, flexible = 0x20, phone_to_provider = 0x40, email_to_provider = 0x80 }
		public Flags flags;
		public string currency;
		public LabeledPrice[] prices;
	}

	[TLDef(0xEA02C27E, "paymentCharge#ea02c27e id:string provider_charge_id:string = PaymentCharge")]
	public class PaymentCharge : ITLObject
	{
		public string id;
		public string provider_charge_id;
	}

	[TLDef(0x1E8CAAEB, "postAddress#1e8caaeb street_line1:string street_line2:string city:string state:string country_iso2:string post_code:string = PostAddress")]
	public class PostAddress : ITLObject
	{
		public string street_line1;
		public string street_line2;
		public string city;
		public string state;
		public string country_iso2;
		public string post_code;
	}

	[TLDef(0x909C3F94, "paymentRequestedInfo#909c3f94 flags:# name:flags.0?string phone:flags.1?string email:flags.2?string shipping_address:flags.3?PostAddress = PaymentRequestedInfo")]
	public class PaymentRequestedInfo : ITLObject
	{
		[Flags] public enum Flags { has_name = 0x1, has_phone = 0x2, has_email = 0x4, has_shipping_address = 0x8 }
		public Flags flags;
		[IfFlag(0)] public string name;
		[IfFlag(1)] public string phone;
		[IfFlag(2)] public string email;
		[IfFlag(3)] public PostAddress shipping_address;
	}

	public abstract class PaymentSavedCredentials : ITLObject { }
	[TLDef(0xCDC27A1F, "paymentSavedCredentialsCard#cdc27a1f id:string title:string = PaymentSavedCredentials")]
	public class PaymentSavedCredentialsCard : PaymentSavedCredentials
	{
		public string id;
		public string title;
	}

	public abstract class WebDocumentBase : ITLObject { }
	[TLDef(0x1C570ED1, "webDocument#1c570ed1 url:string access_hash:long size:int mime_type:string attributes:Vector<DocumentAttribute> = WebDocument")]
	public class WebDocument : WebDocumentBase
	{
		public string url;
		public long access_hash;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}
	[TLDef(0xF9C8BCC6, "webDocumentNoProxy#f9c8bcc6 url:string size:int mime_type:string attributes:Vector<DocumentAttribute> = WebDocument")]
	public class WebDocumentNoProxy : WebDocumentBase
	{
		public string url;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}

	[TLDef(0x9BED434D, "inputWebDocument#9bed434d url:string size:int mime_type:string attributes:Vector<DocumentAttribute> = InputWebDocument")]
	public class InputWebDocument : ITLObject
	{
		public string url;
		public int size;
		public string mime_type;
		public DocumentAttribute[] attributes;
	}

	public abstract class InputWebFileLocationBase : ITLObject { }
	[TLDef(0xC239D686, "inputWebFileLocation#c239d686 url:string access_hash:long = InputWebFileLocation")]
	public class InputWebFileLocation : InputWebFileLocationBase
	{
		public string url;
		public long access_hash;
	}
	[TLDef(0x9F2221C9, "inputWebFileGeoPointLocation#9f2221c9 geo_point:InputGeoPoint access_hash:long w:int h:int zoom:int scale:int = InputWebFileLocation")]
	public class InputWebFileGeoPointLocation : InputWebFileLocationBase
	{
		public InputGeoPointBase geo_point;
		public long access_hash;
		public int w;
		public int h;
		public int zoom;
		public int scale;
	}

	[TLDef(0x21E753BC, "upload.webFile#21e753bc size:int mime_type:string file_type:storage.FileType mtime:int bytes:bytes = upload.WebFile")]
	public class Upload_WebFile : ITLObject
	{
		public int size;
		public string mime_type;
		public Storage_FileType file_type;
		public int mtime;
		public byte[] bytes;
	}

	[TLDef(0x3F56AEA3, "payments.paymentForm#3f56aea3 flags:# can_save_credentials:flags.2?true password_missing:flags.3?true bot_id:int invoice:Invoice provider_id:int url:string native_provider:flags.4?string native_params:flags.4?DataJSON saved_info:flags.0?PaymentRequestedInfo saved_credentials:flags.1?PaymentSavedCredentials users:Vector<User> = payments.PaymentForm")]
	public class Payments_PaymentForm : ITLObject
	{
		[Flags] public enum Flags { has_saved_info = 0x1, has_saved_credentials = 0x2, can_save_credentials = 0x4, 
			password_missing = 0x8, has_native_provider = 0x10 }
		public Flags flags;
		public int bot_id;
		public Invoice invoice;
		public int provider_id;
		public string url;
		[IfFlag(4)] public string native_provider;
		[IfFlag(4)] public DataJSON native_params;
		[IfFlag(0)] public PaymentRequestedInfo saved_info;
		[IfFlag(1)] public PaymentSavedCredentials saved_credentials;
		public UserBase[] users;
	}

	[TLDef(0xD1451883, "payments.validatedRequestedInfo#d1451883 flags:# id:flags.0?string shipping_options:flags.1?Vector<ShippingOption> = payments.ValidatedRequestedInfo")]
	public class Payments_ValidatedRequestedInfo : ITLObject
	{
		[Flags] public enum Flags { has_id = 0x1, has_shipping_options = 0x2 }
		public Flags flags;
		[IfFlag(0)] public string id;
		[IfFlag(1)] public ShippingOption[] shipping_options;
	}

	public abstract class Payments_PaymentResultBase : ITLObject { }
	[TLDef(0x4E5F810D, "payments.paymentResult#4e5f810d updates:Updates = payments.PaymentResult")]
	public class Payments_PaymentResult : Payments_PaymentResultBase { public UpdatesBase updates; }
	[TLDef(0xD8411139, "payments.paymentVerificationNeeded#d8411139 url:string = payments.PaymentResult")]
	public class Payments_PaymentVerificationNeeded : Payments_PaymentResultBase { public string url; }

	[TLDef(0x500911E1, "payments.paymentReceipt#500911e1 flags:# date:int bot_id:int invoice:Invoice provider_id:int info:flags.0?PaymentRequestedInfo shipping:flags.1?ShippingOption currency:string total_amount:long credentials_title:string users:Vector<User> = payments.PaymentReceipt")]
	public class Payments_PaymentReceipt : ITLObject
	{
		[Flags] public enum Flags { has_info = 0x1, has_shipping = 0x2 }
		public Flags flags;
		public DateTime date;
		public int bot_id;
		public Invoice invoice;
		public int provider_id;
		[IfFlag(0)] public PaymentRequestedInfo info;
		[IfFlag(1)] public ShippingOption shipping;
		public string currency;
		public long total_amount;
		public string credentials_title;
		public UserBase[] users;
	}

	[TLDef(0xFB8FE43C, "payments.savedInfo#fb8fe43c flags:# has_saved_credentials:flags.1?true saved_info:flags.0?PaymentRequestedInfo = payments.SavedInfo")]
	public class Payments_SavedInfo : ITLObject
	{
		[Flags] public enum Flags { has_saved_info = 0x1, has_saved_credentials = 0x2 }
		public Flags flags;
		[IfFlag(0)] public PaymentRequestedInfo saved_info;
	}

	public abstract class InputPaymentCredentialsBase : ITLObject { }
	[TLDef(0xC10EB2CF, "inputPaymentCredentialsSaved#c10eb2cf id:string tmp_password:bytes = InputPaymentCredentials")]
	public class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{
		public string id;
		public byte[] tmp_password;
	}
	[TLDef(0x3417D728, "inputPaymentCredentials#3417d728 flags:# save:flags.0?true data:DataJSON = InputPaymentCredentials")]
	public class InputPaymentCredentials : InputPaymentCredentialsBase
	{
		[Flags] public enum Flags { save = 0x1 }
		public Flags flags;
		public DataJSON data;
	}
	[TLDef(0xAA1C39F, "inputPaymentCredentialsApplePay#0aa1c39f payment_data:DataJSON = InputPaymentCredentials")]
	public class InputPaymentCredentialsApplePay : InputPaymentCredentialsBase { public DataJSON payment_data; }
	[TLDef(0xCA05D50E, "inputPaymentCredentialsAndroidPay#ca05d50e payment_token:DataJSON google_transaction_id:string = InputPaymentCredentials")]
	public class InputPaymentCredentialsAndroidPay : InputPaymentCredentialsBase
	{
		public DataJSON payment_token;
		public string google_transaction_id;
	}

	[TLDef(0xDB64FD34, "account.tmpPassword#db64fd34 tmp_password:bytes valid_until:int = account.TmpPassword")]
	public class Account_TmpPassword : ITLObject
	{
		public byte[] tmp_password;
		public DateTime valid_until;
	}

	[TLDef(0xB6213CDF, "shippingOption#b6213cdf id:string title:string prices:Vector<LabeledPrice> = ShippingOption")]
	public class ShippingOption : ITLObject
	{
		public string id;
		public string title;
		public LabeledPrice[] prices;
	}

	[TLDef(0xFFA0A496, "inputStickerSetItem#ffa0a496 flags:# document:InputDocument emoji:string mask_coords:flags.0?MaskCoords = InputStickerSetItem")]
	public class InputStickerSetItem : ITLObject
	{
		[Flags] public enum Flags { has_mask_coords = 0x1 }
		public Flags flags;
		public InputDocumentBase document;
		public string emoji;
		[IfFlag(0)] public MaskCoords mask_coords;
	}

	[TLDef(0x1E36FDED, "inputPhoneCall#1e36fded id:long access_hash:long = InputPhoneCall")]
	public class InputPhoneCall : ITLObject
	{
		public long id;
		public long access_hash;
	}

	public abstract class PhoneCallBase : ITLObject { }
	[TLDef(0x5366C915, "phoneCallEmpty#5366c915 id:long = PhoneCall")]
	public class PhoneCallEmpty : PhoneCallBase { public long id; }
	[TLDef(0x1B8F4AD1, "phoneCallWaiting#1b8f4ad1 flags:# video:flags.6?true id:long access_hash:long date:int admin_id:int participant_id:int protocol:PhoneCallProtocol receive_date:flags.0?int = PhoneCall")]
	public class PhoneCallWaiting : PhoneCallBase
	{
		[Flags] public enum Flags { has_receive_date = 0x1, video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
		public PhoneCallProtocol protocol;
		[IfFlag(0)] public DateTime receive_date;
	}
	[TLDef(0x87EABB53, "phoneCallRequested#87eabb53 flags:# video:flags.6?true id:long access_hash:long date:int admin_id:int participant_id:int g_a_hash:bytes protocol:PhoneCallProtocol = PhoneCall")]
	public class PhoneCallRequested : PhoneCallBase
	{
		[Flags] public enum Flags { video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
		public byte[] g_a_hash;
		public PhoneCallProtocol protocol;
	}
	[TLDef(0x997C454A, "phoneCallAccepted#997c454a flags:# video:flags.6?true id:long access_hash:long date:int admin_id:int participant_id:int g_b:bytes protocol:PhoneCallProtocol = PhoneCall")]
	public class PhoneCallAccepted : PhoneCallBase
	{
		[Flags] public enum Flags { video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
		public byte[] g_b;
		public PhoneCallProtocol protocol;
	}
	[TLDef(0x8742AE7F, "phoneCall#8742ae7f flags:# p2p_allowed:flags.5?true video:flags.6?true id:long access_hash:long date:int admin_id:int participant_id:int g_a_or_b:bytes key_fingerprint:long protocol:PhoneCallProtocol connections:Vector<PhoneConnection> start_date:int = PhoneCall")]
	public class PhoneCall : PhoneCallBase
	{
		[Flags] public enum Flags { p2p_allowed = 0x20, video = 0x40 }
		public Flags flags;
		public long id;
		public long access_hash;
		public DateTime date;
		public int admin_id;
		public int participant_id;
		public byte[] g_a_or_b;
		public long key_fingerprint;
		public PhoneCallProtocol protocol;
		public PhoneConnectionBase[] connections;
		public DateTime start_date;
	}
	[TLDef(0x50CA4DE1, "phoneCallDiscarded#50ca4de1 flags:# need_rating:flags.2?true need_debug:flags.3?true video:flags.6?true id:long reason:flags.0?PhoneCallDiscardReason duration:flags.1?int = PhoneCall")]
	public class PhoneCallDiscarded : PhoneCallBase
	{
		[Flags] public enum Flags { has_reason = 0x1, has_duration = 0x2, need_rating = 0x4, need_debug = 0x8, video = 0x40 }
		public Flags flags;
		public long id;
		[IfFlag(0)] public PhoneCallDiscardReason reason;
		[IfFlag(1)] public int duration;
	}

	public abstract class PhoneConnectionBase : ITLObject { }
	[TLDef(0x9D4C17C0, "phoneConnection#9d4c17c0 id:long ip:string ipv6:string port:int peer_tag:bytes = PhoneConnection")]
	public class PhoneConnection : PhoneConnectionBase
	{
		public long id;
		public string ip;
		public string ipv6;
		public int port;
		public byte[] peer_tag;
	}
	[TLDef(0x635FE375, "phoneConnectionWebrtc#635fe375 flags:# turn:flags.0?true stun:flags.1?true id:long ip:string ipv6:string port:int username:string password:string = PhoneConnection")]
	public class PhoneConnectionWebrtc : PhoneConnectionBase
	{
		[Flags] public enum Flags { turn = 0x1, stun = 0x2 }
		public Flags flags;
		public long id;
		public string ip;
		public string ipv6;
		public int port;
		public string username;
		public string password;
	}

	[TLDef(0xFC878FC8, "phoneCallProtocol#fc878fc8 flags:# udp_p2p:flags.0?true udp_reflector:flags.1?true min_layer:int max_layer:int library_versions:Vector<string> = PhoneCallProtocol")]
	public class PhoneCallProtocol : ITLObject
	{
		[Flags] public enum Flags { udp_p2p = 0x1, udp_reflector = 0x2 }
		public Flags flags;
		public int min_layer;
		public int max_layer;
		public string[] library_versions;
	}

	[TLDef(0xEC82E140, "phone.phoneCall#ec82e140 phone_call:PhoneCall users:Vector<User> = phone.PhoneCall")]
	public class Phone_PhoneCall : ITLObject
	{
		public PhoneCallBase phone_call;
		public UserBase[] users;
	}

	public abstract class Upload_CdnFileBase : ITLObject { }
	[TLDef(0xEEA8E46E, "upload.cdnFileReuploadNeeded#eea8e46e request_token:bytes = upload.CdnFile")]
	public class Upload_CdnFileReuploadNeeded : Upload_CdnFileBase { public byte[] request_token; }
	[TLDef(0xA99FCA4F, "upload.cdnFile#a99fca4f bytes:bytes = upload.CdnFile")]
	public class Upload_CdnFile : Upload_CdnFileBase { public byte[] bytes; }

	[TLDef(0xC982EABA, "cdnPublicKey#c982eaba dc_id:int public_key:string = CdnPublicKey")]
	public class CdnPublicKey : ITLObject
	{
		public int dc_id;
		public string public_key;
	}

	[TLDef(0x5725E40A, "cdnConfig#5725e40a public_keys:Vector<CdnPublicKey> = CdnConfig")]
	public class CdnConfig : ITLObject { public CdnPublicKey[] public_keys; }

	public abstract class LangPackStringBase : ITLObject { }
	[TLDef(0xCAD181F6, "langPackString#cad181f6 key:string value:string = LangPackString")]
	public class LangPackString : LangPackStringBase
	{
		public string key;
		public string value;
	}
	[TLDef(0x6C47AC9F, "langPackStringPluralized#6c47ac9f flags:# key:string zero_value:flags.0?string one_value:flags.1?string two_value:flags.2?string few_value:flags.3?string many_value:flags.4?string other_value:string = LangPackString")]
	public class LangPackStringPluralized : LangPackStringBase
	{
		[Flags] public enum Flags { has_zero_value = 0x1, has_one_value = 0x2, has_two_value = 0x4, has_few_value = 0x8, 
			has_many_value = 0x10 }
		public Flags flags;
		public string key;
		[IfFlag(0)] public string zero_value;
		[IfFlag(1)] public string one_value;
		[IfFlag(2)] public string two_value;
		[IfFlag(3)] public string few_value;
		[IfFlag(4)] public string many_value;
		public string other_value;
	}
	[TLDef(0x2979EEB2, "langPackStringDeleted#2979eeb2 key:string = LangPackString")]
	public class LangPackStringDeleted : LangPackStringBase { public string key; }

	[TLDef(0xF385C1F6, "langPackDifference#f385c1f6 lang_code:string from_version:int version:int strings:Vector<LangPackString> = LangPackDifference")]
	public class LangPackDifference : ITLObject
	{
		public string lang_code;
		public int from_version;
		public int version;
		public LangPackStringBase[] strings;
	}

	[TLDef(0xEECA5CE3, "langPackLanguage#eeca5ce3 flags:# official:flags.0?true rtl:flags.2?true beta:flags.3?true name:string native_name:string lang_code:string base_lang_code:flags.1?string plural_code:string strings_count:int translated_count:int translations_url:string = LangPackLanguage")]
	public class LangPackLanguage : ITLObject
	{
		[Flags] public enum Flags { official = 0x1, has_base_lang_code = 0x2, rtl = 0x4, beta = 0x8 }
		public Flags flags;
		public string name;
		public string native_name;
		public string lang_code;
		[IfFlag(1)] public string base_lang_code;
		public string plural_code;
		public int strings_count;
		public int translated_count;
		public string translations_url;
	}

	public abstract class ChannelAdminLogEventAction : ITLObject { }
	[TLDef(0xE6DFB825, "channelAdminLogEventActionChangeTitle#e6dfb825 prev_value:string new_value:string = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangeTitle : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	[TLDef(0x55188A2E, "channelAdminLogEventActionChangeAbout#55188a2e prev_value:string new_value:string = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangeAbout : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	[TLDef(0x6A4AFC38, "channelAdminLogEventActionChangeUsername#6a4afc38 prev_value:string new_value:string = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangeUsername : ChannelAdminLogEventAction
	{
		public string prev_value;
		public string new_value;
	}
	[TLDef(0x434BD2AF, "channelAdminLogEventActionChangePhoto#434bd2af prev_photo:Photo new_photo:Photo = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangePhoto : ChannelAdminLogEventAction
	{
		public PhotoBase prev_photo;
		public PhotoBase new_photo;
	}
	[TLDef(0x1B7907AE, "channelAdminLogEventActionToggleInvites#1b7907ae new_value:Bool = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionToggleInvites : ChannelAdminLogEventAction { public bool new_value; }
	[TLDef(0x26AE0971, "channelAdminLogEventActionToggleSignatures#26ae0971 new_value:Bool = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionToggleSignatures : ChannelAdminLogEventAction { public bool new_value; }
	[TLDef(0xE9E82C18, "channelAdminLogEventActionUpdatePinned#e9e82c18 message:Message = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionUpdatePinned : ChannelAdminLogEventAction { public MessageBase message; }
	[TLDef(0x709B2405, "channelAdminLogEventActionEditMessage#709b2405 prev_message:Message new_message:Message = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventAction
	{
		public MessageBase prev_message;
		public MessageBase new_message;
	}
	[TLDef(0x42E047BB, "channelAdminLogEventActionDeleteMessage#42e047bb message:Message = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionDeleteMessage : ChannelAdminLogEventAction { public MessageBase message; }
	[TLDef(0x183040D3, "channelAdminLogEventActionParticipantJoin#183040d3 = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionParticipantJoin : ChannelAdminLogEventAction { }
	[TLDef(0xF89777F2, "channelAdminLogEventActionParticipantLeave#f89777f2 = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionParticipantLeave : ChannelAdminLogEventAction { }
	[TLDef(0xE31C34D8, "channelAdminLogEventActionParticipantInvite#e31c34d8 participant:ChannelParticipant = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventAction { public ChannelParticipantBase participant; }
	[TLDef(0xE6D83D7E, "channelAdminLogEventActionParticipantToggleBan#e6d83d7e prev_participant:ChannelParticipant new_participant:ChannelParticipant = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventAction
	{
		public ChannelParticipantBase prev_participant;
		public ChannelParticipantBase new_participant;
	}
	[TLDef(0xD5676710, "channelAdminLogEventActionParticipantToggleAdmin#d5676710 prev_participant:ChannelParticipant new_participant:ChannelParticipant = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionParticipantToggleAdmin : ChannelAdminLogEventAction
	{
		public ChannelParticipantBase prev_participant;
		public ChannelParticipantBase new_participant;
	}
	[TLDef(0xB1C3CAA7, "channelAdminLogEventActionChangeStickerSet#b1c3caa7 prev_stickerset:InputStickerSet new_stickerset:InputStickerSet = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangeStickerSet : ChannelAdminLogEventAction
	{
		public InputStickerSet prev_stickerset;
		public InputStickerSet new_stickerset;
	}
	[TLDef(0x5F5C95F1, "channelAdminLogEventActionTogglePreHistoryHidden#5f5c95f1 new_value:Bool = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionTogglePreHistoryHidden : ChannelAdminLogEventAction { public bool new_value; }
	[TLDef(0x2DF5FC0A, "channelAdminLogEventActionDefaultBannedRights#2df5fc0a prev_banned_rights:ChatBannedRights new_banned_rights:ChatBannedRights = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionDefaultBannedRights : ChannelAdminLogEventAction
	{
		public ChatBannedRights prev_banned_rights;
		public ChatBannedRights new_banned_rights;
	}
	[TLDef(0x8F079643, "channelAdminLogEventActionStopPoll#8f079643 message:Message = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionStopPoll : ChannelAdminLogEventAction { public MessageBase message; }
	[TLDef(0xA26F881B, "channelAdminLogEventActionChangeLinkedChat#a26f881b prev_value:int new_value:int = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangeLinkedChat : ChannelAdminLogEventAction
	{
		public int prev_value;
		public int new_value;
	}
	[TLDef(0xE6B76AE, "channelAdminLogEventActionChangeLocation#0e6b76ae prev_value:ChannelLocation new_value:ChannelLocation = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventAction
	{
		public ChannelLocationBase prev_value;
		public ChannelLocationBase new_value;
	}
	[TLDef(0x53909779, "channelAdminLogEventActionToggleSlowMode#53909779 prev_value:int new_value:int = ChannelAdminLogEventAction")]
	public class ChannelAdminLogEventActionToggleSlowMode : ChannelAdminLogEventAction
	{
		public int prev_value;
		public int new_value;
	}

	[TLDef(0x3B5A3E40, "channelAdminLogEvent#3b5a3e40 id:long date:int user_id:int action:ChannelAdminLogEventAction = ChannelAdminLogEvent")]
	public class ChannelAdminLogEvent : ITLObject
	{
		public long id;
		public DateTime date;
		public int user_id;
		public ChannelAdminLogEventAction action;
	}

	[TLDef(0xED8AF74D, "channels.adminLogResults#ed8af74d events:Vector<ChannelAdminLogEvent> chats:Vector<Chat> users:Vector<User> = channels.AdminLogResults")]
	public class Channels_AdminLogResults : ITLObject
	{
		public ChannelAdminLogEvent[] events;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0xEA107AE4, "channelAdminLogEventsFilter#ea107ae4 flags:# join:flags.0?true leave:flags.1?true invite:flags.2?true ban:flags.3?true unban:flags.4?true kick:flags.5?true unkick:flags.6?true promote:flags.7?true demote:flags.8?true info:flags.9?true settings:flags.10?true pinned:flags.11?true edit:flags.12?true delete:flags.13?true group_call:flags.14?true invites:flags.15?true = ChannelAdminLogEventsFilter")]
	public class ChannelAdminLogEventsFilter : ITLObject
	{
		[Flags] public enum Flags { join = 0x1, leave = 0x2, invite = 0x4, ban = 0x8, unban = 0x10, kick = 0x20, unkick = 0x40, 
			promote = 0x80, demote = 0x100, info = 0x200, settings = 0x400, pinned = 0x800, edit = 0x1000, delete = 0x2000, 
			group_call = 0x4000, invites = 0x8000 }
		public Flags flags;
	}

	[TLDef(0x5CE14175, "popularContact#5ce14175 client_id:long importers:int = PopularContact")]
	public class PopularContact : ITLObject
	{
		public long client_id;
		public int importers;
	}

	public abstract class Messages_FavedStickersBase : ITLObject { }
	[TLDef(0x9E8FA6D3, "messages.favedStickersNotModified#9e8fa6d3 = messages.FavedStickers")]
	public class Messages_FavedStickersNotModified : Messages_FavedStickersBase { }
	[TLDef(0xF37F2F16, "messages.favedStickers#f37f2f16 hash:int packs:Vector<StickerPack> stickers:Vector<Document> = messages.FavedStickers")]
	public class Messages_FavedStickers : Messages_FavedStickersBase
	{
		public int hash;
		public StickerPack[] packs;
		public DocumentBase[] stickers;
	}

	public abstract class RecentMeUrl : ITLObject { public string url; }
	[TLDef(0x46E1D13D, "recentMeUrlUnknown#46e1d13d url:string = RecentMeUrl")]
	public class RecentMeUrlUnknown : RecentMeUrl { }
	[TLDef(0x8DBC3336, "recentMeUrlUser#8dbc3336 url:string user_id:int = RecentMeUrl")]
	public class RecentMeUrlUser : RecentMeUrl { public int user_id; }
	[TLDef(0xA01B22F9, "recentMeUrlChat#a01b22f9 url:string chat_id:int = RecentMeUrl")]
	public class RecentMeUrlChat : RecentMeUrl { public int chat_id; }
	[TLDef(0xEB49081D, "recentMeUrlChatInvite#eb49081d url:string chat_invite:ChatInvite = RecentMeUrl")]
	public class RecentMeUrlChatInvite : RecentMeUrl { public ChatInviteBase chat_invite; }
	[TLDef(0xBC0A57DC, "recentMeUrlStickerSet#bc0a57dc url:string set:StickerSetCovered = RecentMeUrl")]
	public class RecentMeUrlStickerSet : RecentMeUrl { public StickerSetCoveredBase set; }

	[TLDef(0xE0310D7, "help.recentMeUrls#0e0310d7 urls:Vector<RecentMeUrl> chats:Vector<Chat> users:Vector<User> = help.RecentMeUrls")]
	public class Help_RecentMeUrls : ITLObject
	{
		public RecentMeUrl[] urls;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0x1CC6E91F, "inputSingleMedia#1cc6e91f flags:# media:InputMedia random_id:long message:string entities:flags.0?Vector<MessageEntity> = InputSingleMedia")]
	public class InputSingleMedia : ITLObject
	{
		[Flags] public enum Flags { has_entities = 0x1 }
		public Flags flags;
		public InputMedia media;
		public long random_id;
		public string message;
		[IfFlag(0)] public MessageEntity[] entities;
	}

	[TLDef(0xCAC943F2, "webAuthorization#cac943f2 hash:long bot_id:int domain:string browser:string platform:string date_created:int date_active:int ip:string region:string = WebAuthorization")]
	public class WebAuthorization : ITLObject
	{
		public long hash;
		public int bot_id;
		public string domain;
		public string browser;
		public string platform;
		public int date_created;
		public int date_active;
		public string ip;
		public string region;
	}

	[TLDef(0xED56C9FC, "account.webAuthorizations#ed56c9fc authorizations:Vector<WebAuthorization> users:Vector<User> = account.WebAuthorizations")]
	public class Account_WebAuthorizations : ITLObject
	{
		public WebAuthorization[] authorizations;
		public UserBase[] users;
	}

	public abstract class InputMessage : ITLObject { }
	[TLDef(0xA676A322, "inputMessageID#a676a322 id:int = InputMessage")]
	public class InputMessageID : InputMessage { public int id; }
	[TLDef(0xBAD88395, "inputMessageReplyTo#bad88395 id:int = InputMessage")]
	public class InputMessageReplyTo : InputMessage { public int id; }
	[TLDef(0x86872538, "inputMessagePinned#86872538 = InputMessage")]
	public class InputMessagePinned : InputMessage { }
	[TLDef(0xACFA1A7E, "inputMessageCallbackQuery#acfa1a7e id:int query_id:long = InputMessage")]
	public class InputMessageCallbackQuery : InputMessage
	{
		public int id;
		public long query_id;
	}

	public abstract class InputDialogPeerBase : ITLObject { }
	[TLDef(0xFCAAFEB7, "inputDialogPeer#fcaafeb7 peer:InputPeer = InputDialogPeer")]
	public class InputDialogPeer : InputDialogPeerBase { public InputPeer peer; }
	[TLDef(0x64600527, "inputDialogPeerFolder#64600527 folder_id:int = InputDialogPeer")]
	public class InputDialogPeerFolder : InputDialogPeerBase { public int folder_id; }

	public abstract class DialogPeerBase : ITLObject { }
	[TLDef(0xE56DBF05, "dialogPeer#e56dbf05 peer:Peer = DialogPeer")]
	public class DialogPeer : DialogPeerBase { public Peer peer; }
	[TLDef(0x514519E2, "dialogPeerFolder#514519e2 folder_id:int = DialogPeer")]
	public class DialogPeerFolder : DialogPeerBase { public int folder_id; }

	public abstract class Messages_FoundStickerSetsBase : ITLObject { }
	[TLDef(0xD54B65D, "messages.foundStickerSetsNotModified#0d54b65d = messages.FoundStickerSets")]
	public class Messages_FoundStickerSetsNotModified : Messages_FoundStickerSetsBase { }
	[TLDef(0x5108D648, "messages.foundStickerSets#5108d648 hash:int sets:Vector<StickerSetCovered> = messages.FoundStickerSets")]
	public class Messages_FoundStickerSets : Messages_FoundStickerSetsBase
	{
		public int hash;
		public StickerSetCoveredBase[] sets;
	}

	[TLDef(0x6242C773, "fileHash#6242c773 offset:int limit:int hash:bytes = FileHash")]
	public class FileHash : ITLObject
	{
		public int offset;
		public int limit;
		public byte[] hash;
	}

	[TLDef(0x75588B3F, "inputClientProxy#75588b3f address:string port:int = InputClientProxy")]
	public class InputClientProxy : ITLObject
	{
		public string address;
		public int port;
	}

	public abstract class Help_TermsOfServiceUpdateBase : ITLObject { }
	[TLDef(0xE3309F7F, "help.termsOfServiceUpdateEmpty#e3309f7f expires:int = help.TermsOfServiceUpdate")]
	public class Help_TermsOfServiceUpdateEmpty : Help_TermsOfServiceUpdateBase { public DateTime expires; }
	[TLDef(0x28ECF961, "help.termsOfServiceUpdate#28ecf961 expires:int terms_of_service:help.TermsOfService = help.TermsOfServiceUpdate")]
	public class Help_TermsOfServiceUpdate : Help_TermsOfServiceUpdateBase
	{
		public DateTime expires;
		public Help_TermsOfService terms_of_service;
	}

	public abstract class InputSecureFileBase : ITLObject { }
	[TLDef(0x3334B0F0, "inputSecureFileUploaded#3334b0f0 id:long parts:int md5_checksum:string file_hash:bytes secret:bytes = InputSecureFile")]
	public class InputSecureFileUploaded : InputSecureFileBase
	{
		public long id;
		public int parts;
		public byte[] md5_checksum;
		public byte[] file_hash;
		public byte[] secret;
	}
	[TLDef(0x5367E5BE, "inputSecureFile#5367e5be id:long access_hash:long = InputSecureFile")]
	public class InputSecureFile : InputSecureFileBase
	{
		public long id;
		public long access_hash;
	}

	public abstract class SecureFileBase : ITLObject { }
	[TLDef(0x64199744, "secureFileEmpty#64199744 = SecureFile")]
	public class SecureFileEmpty : SecureFileBase { }
	[TLDef(0xE0277A62, "secureFile#e0277a62 id:long access_hash:long size:int dc_id:int date:int file_hash:bytes secret:bytes = SecureFile")]
	public class SecureFile : SecureFileBase
	{
		public long id;
		public long access_hash;
		public int size;
		public int dc_id;
		public DateTime date;
		public byte[] file_hash;
		public byte[] secret;
	}

	[TLDef(0x8AEABEC3, "secureData#8aeabec3 data:bytes data_hash:bytes secret:bytes = SecureData")]
	public class SecureData : ITLObject
	{
		public byte[] data;
		public byte[] data_hash;
		public byte[] secret;
	}

	public abstract class SecurePlainData : ITLObject { }
	[TLDef(0x7D6099DD, "securePlainPhone#7d6099dd phone:string = SecurePlainData")]
	public class SecurePlainPhone : SecurePlainData { public string phone; }
	[TLDef(0x21EC5A5F, "securePlainEmail#21ec5a5f email:string = SecurePlainData")]
	public class SecurePlainEmail : SecurePlainData { public string email; }

	public abstract class SecureValueType : ITLObject { }
	[TLDef(0x9D2A81E3, "secureValueTypePersonalDetails#9d2a81e3 = SecureValueType")]
	public class SecureValueTypePersonalDetails : SecureValueType { }
	[TLDef(0x3DAC6A00, "secureValueTypePassport#3dac6a00 = SecureValueType")]
	public class SecureValueTypePassport : SecureValueType { }
	[TLDef(0x6E425C4, "secureValueTypeDriverLicense#06e425c4 = SecureValueType")]
	public class SecureValueTypeDriverLicense : SecureValueType { }
	[TLDef(0xA0D0744B, "secureValueTypeIdentityCard#a0d0744b = SecureValueType")]
	public class SecureValueTypeIdentityCard : SecureValueType { }
	[TLDef(0x99A48F23, "secureValueTypeInternalPassport#99a48f23 = SecureValueType")]
	public class SecureValueTypeInternalPassport : SecureValueType { }
	[TLDef(0xCBE31E26, "secureValueTypeAddress#cbe31e26 = SecureValueType")]
	public class SecureValueTypeAddress : SecureValueType { }
	[TLDef(0xFC36954E, "secureValueTypeUtilityBill#fc36954e = SecureValueType")]
	public class SecureValueTypeUtilityBill : SecureValueType { }
	[TLDef(0x89137C0D, "secureValueTypeBankStatement#89137c0d = SecureValueType")]
	public class SecureValueTypeBankStatement : SecureValueType { }
	[TLDef(0x8B883488, "secureValueTypeRentalAgreement#8b883488 = SecureValueType")]
	public class SecureValueTypeRentalAgreement : SecureValueType { }
	[TLDef(0x99E3806A, "secureValueTypePassportRegistration#99e3806a = SecureValueType")]
	public class SecureValueTypePassportRegistration : SecureValueType { }
	[TLDef(0xEA02EC33, "secureValueTypeTemporaryRegistration#ea02ec33 = SecureValueType")]
	public class SecureValueTypeTemporaryRegistration : SecureValueType { }
	[TLDef(0xB320AADB, "secureValueTypePhone#b320aadb = SecureValueType")]
	public class SecureValueTypePhone : SecureValueType { }
	[TLDef(0x8E3CA7EE, "secureValueTypeEmail#8e3ca7ee = SecureValueType")]
	public class SecureValueTypeEmail : SecureValueType { }

	[TLDef(0x187FA0CA, "secureValue#187fa0ca flags:# type:SecureValueType data:flags.0?SecureData front_side:flags.1?SecureFile reverse_side:flags.2?SecureFile selfie:flags.3?SecureFile translation:flags.6?Vector<SecureFile> files:flags.4?Vector<SecureFile> plain_data:flags.5?SecurePlainData hash:bytes = SecureValue")]
	public class SecureValue : ITLObject
	{
		[Flags] public enum Flags { has_data = 0x1, has_front_side = 0x2, has_reverse_side = 0x4, has_selfie = 0x8, has_files = 0x10, 
			has_plain_data = 0x20, has_translation = 0x40 }
		public Flags flags;
		public SecureValueType type;
		[IfFlag(0)] public SecureData data;
		[IfFlag(1)] public SecureFileBase front_side;
		[IfFlag(2)] public SecureFileBase reverse_side;
		[IfFlag(3)] public SecureFileBase selfie;
		[IfFlag(6)] public SecureFileBase[] translation;
		[IfFlag(4)] public SecureFileBase[] files;
		[IfFlag(5)] public SecurePlainData plain_data;
		public byte[] hash;
	}

	[TLDef(0xDB21D0A7, "inputSecureValue#db21d0a7 flags:# type:SecureValueType data:flags.0?SecureData front_side:flags.1?InputSecureFile reverse_side:flags.2?InputSecureFile selfie:flags.3?InputSecureFile translation:flags.6?Vector<InputSecureFile> files:flags.4?Vector<InputSecureFile> plain_data:flags.5?SecurePlainData = InputSecureValue")]
	public class InputSecureValue : ITLObject
	{
		[Flags] public enum Flags { has_data = 0x1, has_front_side = 0x2, has_reverse_side = 0x4, has_selfie = 0x8, has_files = 0x10, 
			has_plain_data = 0x20, has_translation = 0x40 }
		public Flags flags;
		public SecureValueType type;
		[IfFlag(0)] public SecureData data;
		[IfFlag(1)] public InputSecureFileBase front_side;
		[IfFlag(2)] public InputSecureFileBase reverse_side;
		[IfFlag(3)] public InputSecureFileBase selfie;
		[IfFlag(6)] public InputSecureFileBase[] translation;
		[IfFlag(4)] public InputSecureFileBase[] files;
		[IfFlag(5)] public SecurePlainData plain_data;
	}

	[TLDef(0xED1ECDB0, "secureValueHash#ed1ecdb0 type:SecureValueType hash:bytes = SecureValueHash")]
	public class SecureValueHash : ITLObject
	{
		public SecureValueType type;
		public byte[] hash;
	}

	public abstract class SecureValueErrorBase : ITLObject { }
	[TLDef(0xE8A40BD9, "secureValueErrorData#e8a40bd9 type:SecureValueType data_hash:bytes field:string text:string = SecureValueError")]
	public class SecureValueErrorData : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] data_hash;
		public string field;
		public string text;
	}
	[TLDef(0xBE3DFA, "secureValueErrorFrontSide#00be3dfa type:SecureValueType file_hash:bytes text:string = SecureValueError")]
	public class SecureValueErrorFrontSide : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	[TLDef(0x868A2AA5, "secureValueErrorReverseSide#868a2aa5 type:SecureValueType file_hash:bytes text:string = SecureValueError")]
	public class SecureValueErrorReverseSide : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	[TLDef(0xE537CED6, "secureValueErrorSelfie#e537ced6 type:SecureValueType file_hash:bytes text:string = SecureValueError")]
	public class SecureValueErrorSelfie : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	[TLDef(0x7A700873, "secureValueErrorFile#7a700873 type:SecureValueType file_hash:bytes text:string = SecureValueError")]
	public class SecureValueErrorFile : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	[TLDef(0x666220E9, "secureValueErrorFiles#666220e9 type:SecureValueType file_hash:Vector<bytes> text:string = SecureValueError")]
	public class SecureValueErrorFiles : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[][] file_hash;
		public string text;
	}
	[TLDef(0x869D758F, "secureValueError#869d758f type:SecureValueType hash:bytes text:string = SecureValueError")]
	public class SecureValueError : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] hash;
		public string text;
	}
	[TLDef(0xA1144770, "secureValueErrorTranslationFile#a1144770 type:SecureValueType file_hash:bytes text:string = SecureValueError")]
	public class SecureValueErrorTranslationFile : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[] file_hash;
		public string text;
	}
	[TLDef(0x34636DD8, "secureValueErrorTranslationFiles#34636dd8 type:SecureValueType file_hash:Vector<bytes> text:string = SecureValueError")]
	public class SecureValueErrorTranslationFiles : SecureValueErrorBase
	{
		public SecureValueType type;
		public byte[][] file_hash;
		public string text;
	}

	[TLDef(0x33F0EA47, "secureCredentialsEncrypted#33f0ea47 data:bytes hash:bytes secret:bytes = SecureCredentialsEncrypted")]
	public class SecureCredentialsEncrypted : ITLObject
	{
		public byte[] data;
		public byte[] hash;
		public byte[] secret;
	}

	[TLDef(0xAD2E1CD8, "account.authorizationForm#ad2e1cd8 flags:# required_types:Vector<SecureRequiredType> values:Vector<SecureValue> errors:Vector<SecureValueError> users:Vector<User> privacy_policy_url:flags.0?string = account.AuthorizationForm")]
	public class Account_AuthorizationForm : ITLObject
	{
		[Flags] public enum Flags { has_privacy_policy_url = 0x1 }
		public Flags flags;
		public SecureRequiredTypeBase[] required_types;
		public SecureValue[] values;
		public SecureValueErrorBase[] errors;
		public UserBase[] users;
		[IfFlag(0)] public string privacy_policy_url;
	}

	[TLDef(0x811F854F, "account.sentEmailCode#811f854f email_pattern:string length:int = account.SentEmailCode")]
	public class Account_SentEmailCode : ITLObject
	{
		public string email_pattern;
		public int length;
	}

	public abstract class Help_DeepLinkInfoBase : ITLObject { }
	[TLDef(0x66AFA166, "help.deepLinkInfoEmpty#66afa166 = help.DeepLinkInfo")]
	public class Help_DeepLinkInfoEmpty : Help_DeepLinkInfoBase { }
	[TLDef(0x6A4EE832, "help.deepLinkInfo#6a4ee832 flags:# update_app:flags.0?true message:string entities:flags.1?Vector<MessageEntity> = help.DeepLinkInfo")]
	public class Help_DeepLinkInfo : Help_DeepLinkInfoBase
	{
		[Flags] public enum Flags { update_app = 0x1, has_entities = 0x2 }
		public Flags flags;
		public string message;
		[IfFlag(1)] public MessageEntity[] entities;
	}

	public abstract class SavedContact : ITLObject { }
	[TLDef(0x1142BD56, "savedPhoneContact#1142bd56 phone:string first_name:string last_name:string date:int = SavedContact")]
	public class SavedPhoneContact : SavedContact
	{
		public string phone;
		public string first_name;
		public string last_name;
		public DateTime date;
	}

	[TLDef(0x4DBA4501, "account.takeout#4dba4501 id:long = account.Takeout")]
	public class Account_Takeout : ITLObject { public long id; }

	public abstract class PasswordKdfAlgo : ITLObject { }
	[TLDef(0xD45AB096, "passwordKdfAlgoUnknown#d45ab096 = PasswordKdfAlgo")]
	public class PasswordKdfAlgoUnknown : PasswordKdfAlgo { }
	[TLDef(0x3A912D4A, "passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow#3a912d4a salt1:bytes salt2:bytes g:int p:bytes = PasswordKdfAlgo")]
	public class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : PasswordKdfAlgo
	{
		public byte[] salt1;
		public byte[] salt2;
		public int g;
		public byte[] p;
	}

	public abstract class SecurePasswordKdfAlgo : ITLObject { }
	[TLDef(0x4A8537, "securePasswordKdfAlgoUnknown#004a8537 = SecurePasswordKdfAlgo")]
	public class SecurePasswordKdfAlgoUnknown : SecurePasswordKdfAlgo { }
	[TLDef(0xBBF2DDA0, "securePasswordKdfAlgoPBKDF2HMACSHA512iter100000#bbf2dda0 salt:bytes = SecurePasswordKdfAlgo")]
	public class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : SecurePasswordKdfAlgo { public byte[] salt; }
	[TLDef(0x86471D92, "securePasswordKdfAlgoSHA512#86471d92 salt:bytes = SecurePasswordKdfAlgo")]
	public class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgo { public byte[] salt; }

	[TLDef(0x1527BCAC, "secureSecretSettings#1527bcac secure_algo:SecurePasswordKdfAlgo secure_secret:bytes secure_secret_id:long = SecureSecretSettings")]
	public class SecureSecretSettings : ITLObject
	{
		public SecurePasswordKdfAlgo secure_algo;
		public byte[] secure_secret;
		public long secure_secret_id;
	}

	public abstract class InputCheckPasswordSRPBase : ITLObject { }
	[TLDef(0x9880F658, "inputCheckPasswordEmpty#9880f658 = InputCheckPasswordSRP")]
	public class InputCheckPasswordEmpty : InputCheckPasswordSRPBase { }
	[TLDef(0xD27FF082, "inputCheckPasswordSRP#d27ff082 srp_id:long A:bytes M1:bytes = InputCheckPasswordSRP")]
	public class InputCheckPasswordSRP : InputCheckPasswordSRPBase
	{
		public long srp_id;
		public byte[] A;
		public byte[] M1;
	}

	public abstract class SecureRequiredTypeBase : ITLObject { }
	[TLDef(0x829D99DA, "secureRequiredType#829d99da flags:# native_names:flags.0?true selfie_required:flags.1?true translation_required:flags.2?true type:SecureValueType = SecureRequiredType")]
	public class SecureRequiredType : SecureRequiredTypeBase
	{
		[Flags] public enum Flags { native_names = 0x1, selfie_required = 0x2, translation_required = 0x4 }
		public Flags flags;
		public SecureValueType type;
	}
	[TLDef(0x27477B4, "secureRequiredTypeOneOf#027477b4 types:Vector<SecureRequiredType> = SecureRequiredType")]
	public class SecureRequiredTypeOneOf : SecureRequiredTypeBase { public SecureRequiredTypeBase[] types; }

	public abstract class Help_PassportConfigBase : ITLObject { }
	[TLDef(0xBFB9F457, "help.passportConfigNotModified#bfb9f457 = help.PassportConfig")]
	public class Help_PassportConfigNotModified : Help_PassportConfigBase { }
	[TLDef(0xA098D6AF, "help.passportConfig#a098d6af hash:int countries_langs:DataJSON = help.PassportConfig")]
	public class Help_PassportConfig : Help_PassportConfigBase
	{
		public int hash;
		public DataJSON countries_langs;
	}

	[TLDef(0x1D1B1245, "inputAppEvent#1d1b1245 time:double type:string peer:long data:JSONValue = InputAppEvent")]
	public class InputAppEvent : ITLObject
	{
		public double time;
		public string type;
		public long peer;
		public JSONValue data;
	}

	public abstract class JSONObjectValue : ITLObject { }
	[TLDef(0xC0DE1BD9, "jsonObjectValue#c0de1bd9 key:string value:JSONValue = JSONObjectValue")]
	public class JsonObjectValue : JSONObjectValue
	{
		public string key;
		public JSONValue value;
	}

	public abstract class JSONValue : ITLObject { }
	[TLDef(0x3F6D7B68, "jsonNull#3f6d7b68 = JSONValue")]
	public class JsonNull : JSONValue { }
	[TLDef(0xC7345E6A, "jsonBool#c7345e6a value:Bool = JSONValue")]
	public class JsonBool : JSONValue { public bool value; }
	[TLDef(0x2BE0DFA4, "jsonNumber#2be0dfa4 value:double = JSONValue")]
	public class JsonNumber : JSONValue { public double value; }
	[TLDef(0xB71E767A, "jsonString#b71e767a value:string = JSONValue")]
	public class JsonString : JSONValue { public string value; }
	[TLDef(0xF7444763, "jsonArray#f7444763 value:Vector<JSONValue> = JSONValue")]
	public class JsonArray : JSONValue { public JSONValue[] value; }
	[TLDef(0x99C1D49D, "jsonObject#99c1d49d value:Vector<JSONObjectValue> = JSONValue")]
	public class JsonObject : JSONValue { public JSONObjectValue[] value; }

	[TLDef(0x34566B6A, "pageTableCell#34566b6a flags:# header:flags.0?true align_center:flags.3?true align_right:flags.4?true valign_middle:flags.5?true valign_bottom:flags.6?true text:flags.7?RichText colspan:flags.1?int rowspan:flags.2?int = PageTableCell")]
	public class PageTableCell : ITLObject
	{
		[Flags] public enum Flags { header = 0x1, has_colspan = 0x2, has_rowspan = 0x4, align_center = 0x8, align_right = 0x10, 
			valign_middle = 0x20, valign_bottom = 0x40, has_text = 0x80 }
		public Flags flags;
		[IfFlag(7)] public RichText text;
		[IfFlag(1)] public int colspan;
		[IfFlag(2)] public int rowspan;
	}

	[TLDef(0xE0C0C5E5, "pageTableRow#e0c0c5e5 cells:Vector<PageTableCell> = PageTableRow")]
	public class PageTableRow : ITLObject { public PageTableCell[] cells; }

	[TLDef(0x6F747657, "pageCaption#6f747657 text:RichText credit:RichText = PageCaption")]
	public class PageCaption : ITLObject
	{
		public RichText text;
		public RichText credit;
	}

	public abstract class PageListItem : ITLObject { }
	[TLDef(0xB92FB6CD, "pageListItemText#b92fb6cd text:RichText = PageListItem")]
	public class PageListItemText : PageListItem { public RichText text; }
	[TLDef(0x25E073FC, "pageListItemBlocks#25e073fc blocks:Vector<PageBlock> = PageListItem")]
	public class PageListItemBlocks : PageListItem { public PageBlock[] blocks; }

	public abstract class PageListOrderedItem : ITLObject { public string num; }
	[TLDef(0x5E068047, "pageListOrderedItemText#5e068047 num:string text:RichText = PageListOrderedItem")]
	public class PageListOrderedItemText : PageListOrderedItem { public RichText text; }
	[TLDef(0x98DD8936, "pageListOrderedItemBlocks#98dd8936 num:string blocks:Vector<PageBlock> = PageListOrderedItem")]
	public class PageListOrderedItemBlocks : PageListOrderedItem { public PageBlock[] blocks; }

	[TLDef(0xB390DC08, "pageRelatedArticle#b390dc08 flags:# url:string webpage_id:long title:flags.0?string description:flags.1?string photo_id:flags.2?long author:flags.3?string published_date:flags.4?int = PageRelatedArticle")]
	public class PageRelatedArticle : ITLObject
	{
		[Flags] public enum Flags { has_title = 0x1, has_description = 0x2, has_photo_id = 0x4, has_author = 0x8, 
			has_published_date = 0x10 }
		public Flags flags;
		public string url;
		public long webpage_id;
		[IfFlag(0)] public string title;
		[IfFlag(1)] public string description;
		[IfFlag(2)] public long photo_id;
		[IfFlag(3)] public string author;
		[IfFlag(4)] public DateTime published_date;
	}

	[TLDef(0x98657F0D, "page#98657f0d flags:# part:flags.0?true rtl:flags.1?true v2:flags.2?true url:string blocks:Vector<PageBlock> photos:Vector<Photo> documents:Vector<Document> views:flags.3?int = Page")]
	public class Page : ITLObject
	{
		[Flags] public enum Flags { part = 0x1, rtl = 0x2, v2 = 0x4, has_views = 0x8 }
		public Flags flags;
		public string url;
		public PageBlock[] blocks;
		public PhotoBase[] photos;
		public DocumentBase[] documents;
		[IfFlag(3)] public int views;
	}

	[TLDef(0x8C05F1C9, "help.supportName#8c05f1c9 name:string = help.SupportName")]
	public class Help_SupportName : ITLObject { public string name; }

	public abstract class Help_UserInfoBase : ITLObject { }
	[TLDef(0xF3AE2EED, "help.userInfoEmpty#f3ae2eed = help.UserInfo")]
	public class Help_UserInfoEmpty : Help_UserInfoBase { }
	[TLDef(0x1EB3758, "help.userInfo#01eb3758 message:string entities:Vector<MessageEntity> author:string date:int = help.UserInfo")]
	public class Help_UserInfo : Help_UserInfoBase
	{
		public string message;
		public MessageEntity[] entities;
		public string author;
		public DateTime date;
	}

	[TLDef(0x6CA9C2E9, "pollAnswer#6ca9c2e9 text:string option:bytes = PollAnswer")]
	public class PollAnswer : ITLObject
	{
		public string text;
		public byte[] option;
	}

	[TLDef(0x86E18161, "poll#86e18161 id:long flags:# closed:flags.0?true public_voters:flags.1?true multiple_choice:flags.2?true quiz:flags.3?true question:string answers:Vector<PollAnswer> close_period:flags.4?int close_date:flags.5?int = Poll")]
	public class Poll : ITLObject
	{
		[Flags] public enum Flags { closed = 0x1, public_voters = 0x2, multiple_choice = 0x4, quiz = 0x8, has_close_period = 0x10, 
			has_close_date = 0x20 }
		public long id;
		public Flags flags;
		public string question;
		public PollAnswer[] answers;
		[IfFlag(4)] public int close_period;
		[IfFlag(5)] public DateTime close_date;
	}

	[TLDef(0x3B6DDAD2, "pollAnswerVoters#3b6ddad2 flags:# chosen:flags.0?true correct:flags.1?true option:bytes voters:int = PollAnswerVoters")]
	public class PollAnswerVoters : ITLObject
	{
		[Flags] public enum Flags { chosen = 0x1, correct = 0x2 }
		public Flags flags;
		public byte[] option;
		public int voters;
	}

	[TLDef(0xBADCC1A3, "pollResults#badcc1a3 flags:# min:flags.0?true results:flags.1?Vector<PollAnswerVoters> total_voters:flags.2?int recent_voters:flags.3?Vector<int> solution:flags.4?string solution_entities:flags.4?Vector<MessageEntity> = PollResults")]
	public class PollResults : ITLObject
	{
		[Flags] public enum Flags { min = 0x1, has_results = 0x2, has_total_voters = 0x4, has_recent_voters = 0x8, has_solution = 0x10 }
		public Flags flags;
		[IfFlag(1)] public PollAnswerVoters[] results;
		[IfFlag(2)] public int total_voters;
		[IfFlag(3)] public int[] recent_voters;
		[IfFlag(4)] public string solution;
		[IfFlag(4)] public MessageEntity[] solution_entities;
	}

	[TLDef(0xF041E250, "chatOnlines#f041e250 onlines:int = ChatOnlines")]
	public class ChatOnlines : ITLObject { public int onlines; }

	[TLDef(0x47A971E0, "statsURL#47a971e0 url:string = StatsURL")]
	public class StatsURL : ITLObject { public string url; }

	[TLDef(0x5FB224D5, "chatAdminRights#5fb224d5 flags:# change_info:flags.0?true post_messages:flags.1?true edit_messages:flags.2?true delete_messages:flags.3?true ban_users:flags.4?true invite_users:flags.5?true pin_messages:flags.7?true add_admins:flags.9?true anonymous:flags.10?true manage_call:flags.11?true other:flags.12?true = ChatAdminRights")]
	public class ChatAdminRights : ITLObject
	{
		[Flags] public enum Flags { change_info = 0x1, post_messages = 0x2, edit_messages = 0x4, delete_messages = 0x8, 
			ban_users = 0x10, invite_users = 0x20, pin_messages = 0x80, add_admins = 0x200, anonymous = 0x400, manage_call = 0x800, 
			other = 0x1000 }
		public Flags flags;
	}

	[TLDef(0x9F120418, "chatBannedRights#9f120418 flags:# view_messages:flags.0?true send_messages:flags.1?true send_media:flags.2?true send_stickers:flags.3?true send_gifs:flags.4?true send_games:flags.5?true send_inline:flags.6?true embed_links:flags.7?true send_polls:flags.8?true change_info:flags.10?true invite_users:flags.15?true pin_messages:flags.17?true until_date:int = ChatBannedRights")]
	public class ChatBannedRights : ITLObject
	{
		[Flags] public enum Flags { view_messages = 0x1, send_messages = 0x2, send_media = 0x4, send_stickers = 0x8, send_gifs = 0x10, 
			send_games = 0x20, send_inline = 0x40, embed_links = 0x80, send_polls = 0x100, change_info = 0x400, invite_users = 0x8000, 
			pin_messages = 0x20000 }
		public Flags flags;
		public DateTime until_date;
	}

	public abstract class InputWallPaperBase : ITLObject { }
	[TLDef(0xE630B979, "inputWallPaper#e630b979 id:long access_hash:long = InputWallPaper")]
	public class InputWallPaper : InputWallPaperBase
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0x72091C80, "inputWallPaperSlug#72091c80 slug:string = InputWallPaper")]
	public class InputWallPaperSlug : InputWallPaperBase { public string slug; }
	[TLDef(0x8427BBAC, "inputWallPaperNoFile#8427bbac = InputWallPaper")]
	public class InputWallPaperNoFile : InputWallPaperBase { }

	public abstract class Account_WallPapersBase : ITLObject { }
	[TLDef(0x1C199183, "account.wallPapersNotModified#1c199183 = account.WallPapers")]
	public class Account_WallPapersNotModified : Account_WallPapersBase { }
	[TLDef(0x702B65A9, "account.wallPapers#702b65a9 hash:int wallpapers:Vector<WallPaper> = account.WallPapers")]
	public class Account_WallPapers : Account_WallPapersBase
	{
		public int hash;
		public WallPaperBase[] wallpapers;
	}

	[TLDef(0xDEBEBE83, "codeSettings#debebe83 flags:# allow_flashcall:flags.0?true current_number:flags.1?true allow_app_hash:flags.4?true = CodeSettings")]
	public class CodeSettings : ITLObject
	{
		[Flags] public enum Flags { allow_flashcall = 0x1, current_number = 0x2, allow_app_hash = 0x10 }
		public Flags flags;
	}

	[TLDef(0x5086CF8, "wallPaperSettings#05086cf8 flags:# blur:flags.1?true motion:flags.2?true background_color:flags.0?int second_background_color:flags.4?int intensity:flags.3?int rotation:flags.4?int = WallPaperSettings")]
	public class WallPaperSettings : ITLObject
	{
		[Flags] public enum Flags { has_background_color = 0x1, blur = 0x2, motion = 0x4, has_intensity = 0x8, 
			has_second_background_color = 0x10 }
		public Flags flags;
		[IfFlag(0)] public int background_color;
		[IfFlag(4)] public int second_background_color;
		[IfFlag(3)] public int intensity;
		[IfFlag(4)] public int rotation;
	}

	[TLDef(0xE04232F3, "autoDownloadSettings#e04232f3 flags:# disabled:flags.0?true video_preload_large:flags.1?true audio_preload_next:flags.2?true phonecalls_less_data:flags.3?true photo_size_max:int video_size_max:int file_size_max:int video_upload_maxbitrate:int = AutoDownloadSettings")]
	public class AutoDownloadSettings : ITLObject
	{
		[Flags] public enum Flags { disabled = 0x1, video_preload_large = 0x2, audio_preload_next = 0x4, phonecalls_less_data = 0x8 }
		public Flags flags;
		public int photo_size_max;
		public int video_size_max;
		public int file_size_max;
		public int video_upload_maxbitrate;
	}

	[TLDef(0x63CACF26, "account.autoDownloadSettings#63cacf26 low:AutoDownloadSettings medium:AutoDownloadSettings high:AutoDownloadSettings = account.AutoDownloadSettings")]
	public class Account_AutoDownloadSettings : ITLObject
	{
		public AutoDownloadSettings low;
		public AutoDownloadSettings medium;
		public AutoDownloadSettings high;
	}

	[TLDef(0xD5B3B9F9, "emojiKeyword#d5b3b9f9 keyword:string emoticons:Vector<string> = EmojiKeyword")]
	public class EmojiKeyword : ITLObject
	{
		public string keyword;
		public string[] emoticons;
	}
	[TLDef(0x236DF622, "emojiKeywordDeleted#236df622 keyword:string emoticons:Vector<string> = EmojiKeyword")]
	public class EmojiKeywordDeleted : EmojiKeyword { }

	[TLDef(0x5CC761BD, "emojiKeywordsDifference#5cc761bd lang_code:string from_version:int version:int keywords:Vector<EmojiKeyword> = EmojiKeywordsDifference")]
	public class EmojiKeywordsDifference : ITLObject
	{
		public string lang_code;
		public int from_version;
		public int version;
		public EmojiKeyword[] keywords;
	}

	[TLDef(0xA575739D, "emojiURL#a575739d url:string = EmojiURL")]
	public class EmojiURL : ITLObject { public string url; }

	[TLDef(0xB3FB5361, "emojiLanguage#b3fb5361 lang_code:string = EmojiLanguage")]
	public class EmojiLanguage : ITLObject { public string lang_code; }

	public abstract class FileLocation : ITLObject { }
	[TLDef(0xBC7FC6CD, "fileLocationToBeDeprecated#bc7fc6cd volume_id:long local_id:int = FileLocation")]
	public class FileLocationToBeDeprecated : FileLocation
	{
		public long volume_id;
		public int local_id;
	}

	[TLDef(0xFF544E65, "folder#ff544e65 flags:# autofill_new_broadcasts:flags.0?true autofill_public_groups:flags.1?true autofill_new_correspondents:flags.2?true id:int title:string photo:flags.3?ChatPhoto = Folder")]
	public class Folder : ITLObject
	{
		[Flags] public enum Flags { autofill_new_broadcasts = 0x1, autofill_public_groups = 0x2, autofill_new_correspondents = 0x4, 
			has_photo = 0x8 }
		public Flags flags;
		public int id;
		public string title;
		[IfFlag(3)] public ChatPhotoBase photo;
	}

	[TLDef(0xFBD2C296, "inputFolderPeer#fbd2c296 peer:InputPeer folder_id:int = InputFolderPeer")]
	public class InputFolderPeer : ITLObject
	{
		public InputPeer peer;
		public int folder_id;
	}

	[TLDef(0xE9BAA668, "folderPeer#e9baa668 peer:Peer folder_id:int = FolderPeer")]
	public class FolderPeer : ITLObject
	{
		public Peer peer;
		public int folder_id;
	}

	[TLDef(0xE844EBFF, "messages.searchCounter#e844ebff flags:# inexact:flags.1?true filter:MessagesFilter count:int = messages.SearchCounter")]
	public class Messages_SearchCounter : ITLObject
	{
		[Flags] public enum Flags { inexact = 0x2 }
		public Flags flags;
		public MessagesFilter filter;
		public int count;
	}

	public abstract class UrlAuthResult : ITLObject { }
	[TLDef(0x92D33A0E, "urlAuthResultRequest#92d33a0e flags:# request_write_access:flags.0?true bot:User domain:string = UrlAuthResult")]
	public class UrlAuthResultRequest : UrlAuthResult
	{
		[Flags] public enum Flags { request_write_access = 0x1 }
		public Flags flags;
		public UserBase bot;
		public string domain;
	}
	[TLDef(0x8F8C0E4E, "urlAuthResultAccepted#8f8c0e4e url:string = UrlAuthResult")]
	public class UrlAuthResultAccepted : UrlAuthResult { public string url; }
	[TLDef(0xA9D6DB1F, "urlAuthResultDefault#a9d6db1f = UrlAuthResult")]
	public class UrlAuthResultDefault : UrlAuthResult { }

	public abstract class ChannelLocationBase : ITLObject { }
	[TLDef(0xBFB5AD8B, "channelLocationEmpty#bfb5ad8b = ChannelLocation")]
	public class ChannelLocationEmpty : ChannelLocationBase { }
	[TLDef(0x209B82DB, "channelLocation#209b82db geo_point:GeoPoint address:string = ChannelLocation")]
	public class ChannelLocation : ChannelLocationBase
	{
		public GeoPointBase geo_point;
		public string address;
	}

	public abstract class PeerLocatedBase : ITLObject { }
	[TLDef(0xCA461B5D, "peerLocated#ca461b5d peer:Peer expires:int distance:int = PeerLocated")]
	public class PeerLocated : PeerLocatedBase
	{
		public Peer peer;
		public DateTime expires;
		public int distance;
	}
	[TLDef(0xF8EC284B, "peerSelfLocated#f8ec284b expires:int = PeerLocated")]
	public class PeerSelfLocated : PeerLocatedBase { public DateTime expires; }

	[TLDef(0xD072ACB4, "restrictionReason#d072acb4 platform:string reason:string text:string = RestrictionReason")]
	public class RestrictionReason : ITLObject
	{
		public string platform;
		public string reason;
		public string text;
	}

	public abstract class InputThemeBase : ITLObject { }
	[TLDef(0x3C5693E9, "inputTheme#3c5693e9 id:long access_hash:long = InputTheme")]
	public class InputTheme : InputThemeBase
	{
		public long id;
		public long access_hash;
	}
	[TLDef(0xF5890DF1, "inputThemeSlug#f5890df1 slug:string = InputTheme")]
	public class InputThemeSlug : InputThemeBase { public string slug; }

	[TLDef(0x28F1114, "theme#028f1114 flags:# creator:flags.0?true default:flags.1?true id:long access_hash:long slug:string title:string document:flags.2?Document settings:flags.3?ThemeSettings installs_count:int = Theme")]
	public class Theme : ITLObject
	{
		[Flags] public enum Flags { creator = 0x1, default_ = 0x2, has_document = 0x4, has_settings = 0x8 }
		public Flags flags;
		public long id;
		public long access_hash;
		public string slug;
		public string title;
		[IfFlag(2)] public DocumentBase document;
		[IfFlag(3)] public ThemeSettings settings;
		public int installs_count;
	}

	public abstract class Account_ThemesBase : ITLObject { }
	[TLDef(0xF41EB622, "account.themesNotModified#f41eb622 = account.Themes")]
	public class Account_ThemesNotModified : Account_ThemesBase { }
	[TLDef(0x7F676421, "account.themes#7f676421 hash:int themes:Vector<Theme> = account.Themes")]
	public class Account_Themes : Account_ThemesBase
	{
		public int hash;
		public Theme[] themes;
	}

	public abstract class Auth_LoginTokenBase : ITLObject { }
	[TLDef(0x629F1980, "auth.loginToken#629f1980 expires:int token:bytes = auth.LoginToken")]
	public class Auth_LoginToken : Auth_LoginTokenBase
	{
		public DateTime expires;
		public byte[] token;
	}
	[TLDef(0x68E9916, "auth.loginTokenMigrateTo#068e9916 dc_id:int token:bytes = auth.LoginToken")]
	public class Auth_LoginTokenMigrateTo : Auth_LoginTokenBase
	{
		public int dc_id;
		public byte[] token;
	}
	[TLDef(0x390D5C5E, "auth.loginTokenSuccess#390d5c5e authorization:auth.Authorization = auth.LoginToken")]
	public class Auth_LoginTokenSuccess : Auth_LoginTokenBase { public Auth_AuthorizationBase authorization; }

	[TLDef(0x57E28221, "account.contentSettings#57e28221 flags:# sensitive_enabled:flags.0?true sensitive_can_change:flags.1?true = account.ContentSettings")]
	public class Account_ContentSettings : ITLObject
	{
		[Flags] public enum Flags { sensitive_enabled = 0x1, sensitive_can_change = 0x2 }
		public Flags flags;
	}

	[TLDef(0xA927FEC5, "messages.inactiveChats#a927fec5 dates:Vector<int> chats:Vector<Chat> users:Vector<User> = messages.InactiveChats")]
	public class Messages_InactiveChats : ITLObject
	{
		public int[] dates;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	public abstract class BaseTheme : ITLObject { }
	[TLDef(0xC3A12462, "baseThemeClassic#c3a12462 = BaseTheme")]
	public class BaseThemeClassic : BaseTheme { }
	[TLDef(0xFBD81688, "baseThemeDay#fbd81688 = BaseTheme")]
	public class BaseThemeDay : BaseTheme { }
	[TLDef(0xB7B31EA8, "baseThemeNight#b7b31ea8 = BaseTheme")]
	public class BaseThemeNight : BaseTheme { }
	[TLDef(0x6D5F77EE, "baseThemeTinted#6d5f77ee = BaseTheme")]
	public class BaseThemeTinted : BaseTheme { }
	[TLDef(0x5B11125A, "baseThemeArctic#5b11125a = BaseTheme")]
	public class BaseThemeArctic : BaseTheme { }

	[TLDef(0xBD507CD1, "inputThemeSettings#bd507cd1 flags:# base_theme:BaseTheme accent_color:int message_top_color:flags.0?int message_bottom_color:flags.0?int wallpaper:flags.1?InputWallPaper wallpaper_settings:flags.1?WallPaperSettings = InputThemeSettings")]
	public class InputThemeSettings : ITLObject
	{
		[Flags] public enum Flags { has_message_top_color = 0x1, has_wallpaper = 0x2 }
		public Flags flags;
		public BaseTheme base_theme;
		public int accent_color;
		[IfFlag(0)] public int message_top_color;
		[IfFlag(0)] public int message_bottom_color;
		[IfFlag(1)] public InputWallPaperBase wallpaper;
		[IfFlag(1)] public WallPaperSettings wallpaper_settings;
	}

	[TLDef(0x9C14984A, "themeSettings#9c14984a flags:# base_theme:BaseTheme accent_color:int message_top_color:flags.0?int message_bottom_color:flags.0?int wallpaper:flags.1?WallPaper = ThemeSettings")]
	public class ThemeSettings : ITLObject
	{
		[Flags] public enum Flags { has_message_top_color = 0x1, has_wallpaper = 0x2 }
		public Flags flags;
		public BaseTheme base_theme;
		public int accent_color;
		[IfFlag(0)] public int message_top_color;
		[IfFlag(0)] public int message_bottom_color;
		[IfFlag(1)] public WallPaperBase wallpaper;
	}

	public abstract class WebPageAttribute : ITLObject { }
	[TLDef(0x54B56617, "webPageAttributeTheme#54b56617 flags:# documents:flags.0?Vector<Document> settings:flags.1?ThemeSettings = WebPageAttribute")]
	public class WebPageAttributeTheme : WebPageAttribute
	{
		[Flags] public enum Flags { has_documents = 0x1, has_settings = 0x2 }
		public Flags flags;
		[IfFlag(0)] public DocumentBase[] documents;
		[IfFlag(1)] public ThemeSettings settings;
	}

	public abstract class MessageUserVoteBase : ITLObject { }
	[TLDef(0xA28E5559, "messageUserVote#a28e5559 user_id:int option:bytes date:int = MessageUserVote")]
	public class MessageUserVote : MessageUserVoteBase
	{
		public int user_id;
		public byte[] option;
		public DateTime date;
	}
	[TLDef(0x36377430, "messageUserVoteInputOption#36377430 user_id:int date:int = MessageUserVote")]
	public class MessageUserVoteInputOption : MessageUserVoteBase
	{
		public int user_id;
		public DateTime date;
	}
	[TLDef(0xE8FE0DE, "messageUserVoteMultiple#0e8fe0de user_id:int options:Vector<bytes> date:int = MessageUserVote")]
	public class MessageUserVoteMultiple : MessageUserVoteBase
	{
		public int user_id;
		public byte[][] options;
		public DateTime date;
	}

	[TLDef(0x823F649, "messages.votesList#0823f649 flags:# count:int votes:Vector<MessageUserVote> users:Vector<User> next_offset:flags.0?string = messages.VotesList")]
	public class Messages_VotesList : ITLObject
	{
		[Flags] public enum Flags { has_next_offset = 0x1 }
		public Flags flags;
		public int count;
		public MessageUserVoteBase[] votes;
		public UserBase[] users;
		[IfFlag(0)] public string next_offset;
	}

	[TLDef(0xF568028A, "bankCardOpenUrl#f568028a url:string name:string = BankCardOpenUrl")]
	public class BankCardOpenUrl : ITLObject
	{
		public string url;
		public string name;
	}

	[TLDef(0x3E24E573, "payments.bankCardData#3e24e573 title:string open_urls:Vector<BankCardOpenUrl> = payments.BankCardData")]
	public class Payments_BankCardData : ITLObject
	{
		public string title;
		public BankCardOpenUrl[] open_urls;
	}

	[TLDef(0x7438F7E8, "dialogFilter#7438f7e8 flags:# contacts:flags.0?true non_contacts:flags.1?true groups:flags.2?true broadcasts:flags.3?true bots:flags.4?true exclude_muted:flags.11?true exclude_read:flags.12?true exclude_archived:flags.13?true id:int title:string emoticon:flags.25?string pinned_peers:Vector<InputPeer> include_peers:Vector<InputPeer> exclude_peers:Vector<InputPeer> = DialogFilter")]
	public class DialogFilter : ITLObject
	{
		[Flags] public enum Flags { contacts = 0x1, non_contacts = 0x2, groups = 0x4, broadcasts = 0x8, bots = 0x10, 
			exclude_muted = 0x800, exclude_read = 0x1000, exclude_archived = 0x2000, has_emoticon = 0x2000000 }
		public Flags flags;
		public int id;
		public string title;
		[IfFlag(25)] public string emoticon;
		public InputPeer[] pinned_peers;
		public InputPeer[] include_peers;
		public InputPeer[] exclude_peers;
	}

	[TLDef(0x77744D4A, "dialogFilterSuggested#77744d4a filter:DialogFilter description:string = DialogFilterSuggested")]
	public class DialogFilterSuggested : ITLObject
	{
		public DialogFilter filter;
		public string description;
	}

	[TLDef(0xB637EDAF, "statsDateRangeDays#b637edaf min_date:int max_date:int = StatsDateRangeDays")]
	public class StatsDateRangeDays : ITLObject
	{
		public DateTime min_date;
		public DateTime max_date;
	}

	[TLDef(0xCB43ACDE, "statsAbsValueAndPrev#cb43acde current:double previous:double = StatsAbsValueAndPrev")]
	public class StatsAbsValueAndPrev : ITLObject
	{
		public double current;
		public double previous;
	}

	[TLDef(0xCBCE2FE0, "statsPercentValue#cbce2fe0 part:double total:double = StatsPercentValue")]
	public class StatsPercentValue : ITLObject
	{
		public double part;
		public double total;
	}

	public abstract class StatsGraphBase : ITLObject { }
	[TLDef(0x4A27EB2D, "statsGraphAsync#4a27eb2d token:string = StatsGraph")]
	public class StatsGraphAsync : StatsGraphBase { public string token; }
	[TLDef(0xBEDC9822, "statsGraphError#bedc9822 error:string = StatsGraph")]
	public class StatsGraphError : StatsGraphBase { public string error; }
	[TLDef(0x8EA464B6, "statsGraph#8ea464b6 flags:# json:DataJSON zoom_token:flags.0?string = StatsGraph")]
	public class StatsGraph : StatsGraphBase
	{
		[Flags] public enum Flags { has_zoom_token = 0x1 }
		public Flags flags;
		public DataJSON json;
		[IfFlag(0)] public string zoom_token;
	}

	[TLDef(0xAD4FC9BD, "messageInteractionCounters#ad4fc9bd msg_id:int views:int forwards:int = MessageInteractionCounters")]
	public class MessageInteractionCounters : ITLObject
	{
		public int msg_id;
		public int views;
		public int forwards;
	}

	[TLDef(0xBDF78394, "stats.broadcastStats#bdf78394 period:StatsDateRangeDays followers:StatsAbsValueAndPrev views_per_post:StatsAbsValueAndPrev shares_per_post:StatsAbsValueAndPrev enabled_notifications:StatsPercentValue growth_graph:StatsGraph followers_graph:StatsGraph mute_graph:StatsGraph top_hours_graph:StatsGraph interactions_graph:StatsGraph iv_interactions_graph:StatsGraph views_by_source_graph:StatsGraph new_followers_by_source_graph:StatsGraph languages_graph:StatsGraph recent_message_interactions:Vector<MessageInteractionCounters> = stats.BroadcastStats")]
	public class Stats_BroadcastStats : ITLObject
	{
		public StatsDateRangeDays period;
		public StatsAbsValueAndPrev followers;
		public StatsAbsValueAndPrev views_per_post;
		public StatsAbsValueAndPrev shares_per_post;
		public StatsPercentValue enabled_notifications;
		public StatsGraphBase growth_graph;
		public StatsGraphBase followers_graph;
		public StatsGraphBase mute_graph;
		public StatsGraphBase top_hours_graph;
		public StatsGraphBase interactions_graph;
		public StatsGraphBase iv_interactions_graph;
		public StatsGraphBase views_by_source_graph;
		public StatsGraphBase new_followers_by_source_graph;
		public StatsGraphBase languages_graph;
		public MessageInteractionCounters[] recent_message_interactions;
	}

	public abstract class Help_PromoDataBase : ITLObject { }
	[TLDef(0x98F6AC75, "help.promoDataEmpty#98f6ac75 expires:int = help.PromoData")]
	public class Help_PromoDataEmpty : Help_PromoDataBase { public DateTime expires; }
	[TLDef(0x8C39793F, "help.promoData#8c39793f flags:# proxy:flags.0?true expires:int peer:Peer chats:Vector<Chat> users:Vector<User> psa_type:flags.1?string psa_message:flags.2?string = help.PromoData")]
	public class Help_PromoData : Help_PromoDataBase
	{
		[Flags] public enum Flags { proxy = 0x1, has_psa_type = 0x2, has_psa_message = 0x4 }
		public Flags flags;
		public DateTime expires;
		public Peer peer;
		public ChatBase[] chats;
		public UserBase[] users;
		[IfFlag(1)] public string psa_type;
		[IfFlag(2)] public string psa_message;
	}

	[TLDef(0xE831C556, "videoSize#e831c556 flags:# type:string location:FileLocation w:int h:int size:int video_start_ts:flags.0?double = VideoSize")]
	public class VideoSize : ITLObject
	{
		[Flags] public enum Flags { has_video_start_ts = 0x1 }
		public Flags flags;
		public string type;
		public FileLocation location;
		public int w;
		public int h;
		public int size;
		[IfFlag(0)] public double video_start_ts;
	}

	[TLDef(0x18F3D0F7, "statsGroupTopPoster#18f3d0f7 user_id:int messages:int avg_chars:int = StatsGroupTopPoster")]
	public class StatsGroupTopPoster : ITLObject
	{
		public int user_id;
		public int messages;
		public int avg_chars;
	}

	[TLDef(0x6014F412, "statsGroupTopAdmin#6014f412 user_id:int deleted:int kicked:int banned:int = StatsGroupTopAdmin")]
	public class StatsGroupTopAdmin : ITLObject
	{
		public int user_id;
		public int deleted;
		public int kicked;
		public int banned;
	}

	[TLDef(0x31962A4C, "statsGroupTopInviter#31962a4c user_id:int invitations:int = StatsGroupTopInviter")]
	public class StatsGroupTopInviter : ITLObject
	{
		public int user_id;
		public int invitations;
	}

	[TLDef(0xEF7FF916, "stats.megagroupStats#ef7ff916 period:StatsDateRangeDays members:StatsAbsValueAndPrev messages:StatsAbsValueAndPrev viewers:StatsAbsValueAndPrev posters:StatsAbsValueAndPrev growth_graph:StatsGraph members_graph:StatsGraph new_members_by_source_graph:StatsGraph languages_graph:StatsGraph messages_graph:StatsGraph actions_graph:StatsGraph top_hours_graph:StatsGraph weekdays_graph:StatsGraph top_posters:Vector<StatsGroupTopPoster> top_admins:Vector<StatsGroupTopAdmin> top_inviters:Vector<StatsGroupTopInviter> users:Vector<User> = stats.MegagroupStats")]
	public class Stats_MegagroupStats : ITLObject
	{
		public StatsDateRangeDays period;
		public StatsAbsValueAndPrev members;
		public StatsAbsValueAndPrev messages;
		public StatsAbsValueAndPrev viewers;
		public StatsAbsValueAndPrev posters;
		public StatsGraphBase growth_graph;
		public StatsGraphBase members_graph;
		public StatsGraphBase new_members_by_source_graph;
		public StatsGraphBase languages_graph;
		public StatsGraphBase messages_graph;
		public StatsGraphBase actions_graph;
		public StatsGraphBase top_hours_graph;
		public StatsGraphBase weekdays_graph;
		public StatsGroupTopPoster[] top_posters;
		public StatsGroupTopAdmin[] top_admins;
		public StatsGroupTopInviter[] top_inviters;
		public UserBase[] users;
	}

	[TLDef(0xBEA2F424, "globalPrivacySettings#bea2f424 flags:# archive_and_mute_new_noncontact_peers:flags.0?Bool = GlobalPrivacySettings")]
	public class GlobalPrivacySettings : ITLObject
	{
		[Flags] public enum Flags { has_archive_and_mute_new_noncontact_peers = 0x1 }
		public Flags flags;
		[IfFlag(0)] public bool archive_and_mute_new_noncontact_peers;
	}

	[TLDef(0x4203C5EF, "help.countryCode#4203c5ef flags:# country_code:string prefixes:flags.0?Vector<string> patterns:flags.1?Vector<string> = help.CountryCode")]
	public class Help_CountryCode : ITLObject
	{
		[Flags] public enum Flags { has_prefixes = 0x1, has_patterns = 0x2 }
		public Flags flags;
		public string country_code;
		[IfFlag(0)] public string[] prefixes;
		[IfFlag(1)] public string[] patterns;
	}

	[TLDef(0xC3878E23, "help.country#c3878e23 flags:# hidden:flags.0?true iso2:string default_name:string name:flags.1?string country_codes:Vector<help.CountryCode> = help.Country")]
	public class Help_Country : ITLObject
	{
		[Flags] public enum Flags { hidden = 0x1, has_name = 0x2 }
		public Flags flags;
		public string iso2;
		public string default_name;
		[IfFlag(1)] public string name;
		public Help_CountryCode[] country_codes;
	}

	public abstract class Help_CountriesListBase : ITLObject { }
	[TLDef(0x93CC1F32, "help.countriesListNotModified#93cc1f32 = help.CountriesList")]
	public class Help_CountriesListNotModified : Help_CountriesListBase { }
	[TLDef(0x87D0759E, "help.countriesList#87d0759e countries:Vector<help.Country> hash:int = help.CountriesList")]
	public class Help_CountriesList : Help_CountriesListBase
	{
		public Help_Country[] countries;
		public int hash;
	}

	[TLDef(0x455B853D, "messageViews#455b853d flags:# views:flags.0?int forwards:flags.1?int replies:flags.2?MessageReplies = MessageViews")]
	public class MessageViews : ITLObject
	{
		[Flags] public enum Flags { has_views = 0x1, has_forwards = 0x2, has_replies = 0x4 }
		public Flags flags;
		[IfFlag(0)] public int views;
		[IfFlag(1)] public int forwards;
		[IfFlag(2)] public MessageReplies replies;
	}

	[TLDef(0xB6C4F543, "messages.messageViews#b6c4f543 views:Vector<MessageViews> chats:Vector<Chat> users:Vector<User> = messages.MessageViews")]
	public class Messages_MessageViews : ITLObject
	{
		public MessageViews[] views;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0xF5DD8F9D, "messages.discussionMessage#f5dd8f9d flags:# messages:Vector<Message> max_id:flags.0?int read_inbox_max_id:flags.1?int read_outbox_max_id:flags.2?int chats:Vector<Chat> users:Vector<User> = messages.DiscussionMessage")]
	public class Messages_DiscussionMessage : ITLObject
	{
		[Flags] public enum Flags { has_max_id = 0x1, has_read_inbox_max_id = 0x2, has_read_outbox_max_id = 0x4 }
		public Flags flags;
		public MessageBase[] messages;
		[IfFlag(0)] public int max_id;
		[IfFlag(1)] public int read_inbox_max_id;
		[IfFlag(2)] public int read_outbox_max_id;
		public ChatBase[] chats;
		public UserBase[] users;
	}

	[TLDef(0xA6D57763, "messageReplyHeader#a6d57763 flags:# reply_to_msg_id:int reply_to_peer_id:flags.0?Peer reply_to_top_id:flags.1?int = MessageReplyHeader")]
	public class MessageReplyHeader : ITLObject
	{
		[Flags] public enum Flags { has_reply_to_peer_id = 0x1, has_reply_to_top_id = 0x2 }
		public Flags flags;
		public int reply_to_msg_id;
		[IfFlag(0)] public Peer reply_to_peer_id;
		[IfFlag(1)] public int reply_to_top_id;
	}

	[TLDef(0x4128FAAC, "messageReplies#4128faac flags:# comments:flags.0?true replies:int replies_pts:int recent_repliers:flags.1?Vector<Peer> channel_id:flags.0?int max_id:flags.2?int read_max_id:flags.3?int = MessageReplies")]
	public class MessageReplies : ITLObject
	{
		[Flags] public enum Flags { comments = 0x1, has_recent_repliers = 0x2, has_max_id = 0x4, has_read_max_id = 0x8 }
		public Flags flags;
		public int replies;
		public int replies_pts;
		[IfFlag(1)] public Peer[] recent_repliers;
		[IfFlag(0)] public int channel_id;
		[IfFlag(2)] public int max_id;
		[IfFlag(3)] public int read_max_id;
	}

	[TLDef(0xE8FD8014, "peerBlocked#e8fd8014 peer_id:Peer date:int = PeerBlocked")]
	public class PeerBlocked : ITLObject
	{
		public Peer peer_id;
		public DateTime date;
	}

	[TLDef(0x8999F295, "stats.messageStats#8999f295 views_graph:StatsGraph = stats.MessageStats")]
	public class Stats_MessageStats : ITLObject { public StatsGraphBase views_graph; }

	public static partial class Fn // ---functions---
	{
		[TLDef(0xCB9F372D, "invokeAfterMsg#cb9f372d {X:Type} msg_id:long query:!X = X")]
		public class InvokeAfterMsg<X> : ITLFunction<X>
		{
			public long msg_id;
			public ITLFunction<X> query;
		}

		[TLDef(0x3DC4B4F0, "invokeAfterMsgs#3dc4b4f0 {X:Type} msg_ids:Vector<long> query:!X = X")]
		public class InvokeAfterMsgs<X> : ITLFunction<X>
		{
			public long[] msg_ids;
			public ITLFunction<X> query;
		}

		[TLDef(0xA677244F, "auth.sendCode#a677244f phone_number:string api_id:int api_hash:string settings:CodeSettings = auth.SentCode")]
		public class Auth_SendCode : ITLFunction<Auth_SentCode>
		{
			public string phone_number;
			public int api_id;
			public string api_hash;
			public CodeSettings settings;
		}

		[TLDef(0x80EEE427, "auth.signUp#80eee427 phone_number:string phone_code_hash:string first_name:string last_name:string = auth.Authorization")]
		public class Auth_SignUp : ITLFunction<Auth_AuthorizationBase>
		{
			public string phone_number;
			public string phone_code_hash;
			public string first_name;
			public string last_name;
		}

		[TLDef(0xBCD51581, "auth.signIn#bcd51581 phone_number:string phone_code_hash:string phone_code:string = auth.Authorization")]
		public class Auth_SignIn : ITLFunction<Auth_AuthorizationBase>
		{
			public string phone_number;
			public string phone_code_hash;
			public string phone_code;
		}

		[TLDef(0x5717DA40, "auth.logOut#5717da40 = Bool")]
		public class Auth_LogOut : ITLFunction<bool> { }

		[TLDef(0x9FAB0D1A, "auth.resetAuthorizations#9fab0d1a = Bool")]
		public class Auth_ResetAuthorizations : ITLFunction<bool> { }

		[TLDef(0xE5BFFFCD, "auth.exportAuthorization#e5bfffcd dc_id:int = auth.ExportedAuthorization")]
		public class Auth_ExportAuthorization : ITLFunction<Auth_ExportedAuthorization> { public int dc_id; }

		[TLDef(0xE3EF9613, "auth.importAuthorization#e3ef9613 id:int bytes:bytes = auth.Authorization")]
		public class Auth_ImportAuthorization : ITLFunction<Auth_AuthorizationBase>
		{
			public int id;
			public byte[] bytes;
		}

		[TLDef(0xCDD42A05, "auth.bindTempAuthKey#cdd42a05 perm_auth_key_id:long nonce:long expires_at:int encrypted_message:bytes = Bool")]
		public class Auth_BindTempAuthKey : ITLFunction<bool>
		{
			public long perm_auth_key_id;
			public long nonce;
			public int expires_at;
			public byte[] encrypted_message;
		}

		[TLDef(0x68976C6F, "account.registerDevice#68976c6f flags:# no_muted:flags.0?true token_type:int token:string app_sandbox:Bool secret:bytes other_uids:Vector<int> = Bool")]
		public class Account_RegisterDevice : ITLFunction<bool>
		{
			[Flags] public enum Flags { no_muted = 0x1 }
			public Flags flags;
			public int token_type;
			public string token;
			public bool app_sandbox;
			public byte[] secret;
			public int[] other_uids;
		}

		[TLDef(0x3076C4BF, "account.unregisterDevice#3076c4bf token_type:int token:string other_uids:Vector<int> = Bool")]
		public class Account_UnregisterDevice : ITLFunction<bool>
		{
			public int token_type;
			public string token;
			public int[] other_uids;
		}

		[TLDef(0x84BE5B93, "account.updateNotifySettings#84be5b93 peer:InputNotifyPeer settings:InputPeerNotifySettings = Bool")]
		public class Account_UpdateNotifySettings : ITLFunction<bool>
		{
			public InputNotifyPeerBase peer;
			public InputPeerNotifySettings settings;
		}

		[TLDef(0x12B3AD31, "account.getNotifySettings#12b3ad31 peer:InputNotifyPeer = PeerNotifySettings")]
		public class Account_GetNotifySettings : ITLFunction<PeerNotifySettings> { public InputNotifyPeerBase peer; }

		[TLDef(0xDB7E1747, "account.resetNotifySettings#db7e1747 = Bool")]
		public class Account_ResetNotifySettings : ITLFunction<bool> { }

		[TLDef(0x78515775, "account.updateProfile#78515775 flags:# first_name:flags.0?string last_name:flags.1?string about:flags.2?string = User")]
		public class Account_UpdateProfile : ITLFunction<UserBase>
		{
			[Flags] public enum Flags { has_first_name = 0x1, has_last_name = 0x2, has_about = 0x4 }
			public Flags flags;
			[IfFlag(0)] public string first_name;
			[IfFlag(1)] public string last_name;
			[IfFlag(2)] public string about;
		}

		[TLDef(0x6628562C, "account.updateStatus#6628562c offline:Bool = Bool")]
		public class Account_UpdateStatus : ITLFunction<bool> { public bool offline; }

		[TLDef(0xAABB1763, "account.getWallPapers#aabb1763 hash:int = account.WallPapers")]
		public class Account_GetWallPapers : ITLFunction<Account_WallPapersBase> { public int hash; }

		[TLDef(0xAE189D5F, "account.reportPeer#ae189d5f peer:InputPeer reason:ReportReason = Bool")]
		public class Account_ReportPeer : ITLFunction<bool>
		{
			public InputPeer peer;
			public ReportReason reason;
		}

		[TLDef(0xD91A548, "users.getUsers#0d91a548 id:Vector<InputUser> = Vector<User>")]
		public class Users_GetUsers : ITLFunction<UserBase[]> { public InputUserBase[] id; }

		[TLDef(0xCA30A5B1, "users.getFullUser#ca30a5b1 id:InputUser = UserFull")]
		public class Users_GetFullUser : ITLFunction<UserFull> { public InputUserBase id; }

		[TLDef(0x2CAA4A42, "contacts.getContactIDs#2caa4a42 hash:int = Vector<int>")]
		public class Contacts_GetContactIDs : ITLFunction<int[]> { public int hash; }

		[TLDef(0xC4A353EE, "contacts.getStatuses#c4a353ee = Vector<ContactStatus>")]
		public class Contacts_GetStatuses : ITLFunction<ContactStatus[]> { }

		[TLDef(0xC023849F, "contacts.getContacts#c023849f hash:int = contacts.Contacts")]
		public class Contacts_GetContacts : ITLFunction<Contacts_ContactsBase> { public int hash; }

		[TLDef(0x2C800BE5, "contacts.importContacts#2c800be5 contacts:Vector<InputContact> = contacts.ImportedContacts")]
		public class Contacts_ImportContacts : ITLFunction<Contacts_ImportedContacts> { public InputContact[] contacts; }

		[TLDef(0x96A0E00, "contacts.deleteContacts#096a0e00 id:Vector<InputUser> = Updates")]
		public class Contacts_DeleteContacts : ITLFunction<UpdatesBase> { public InputUserBase[] id; }

		[TLDef(0x1013FD9E, "contacts.deleteByPhones#1013fd9e phones:Vector<string> = Bool")]
		public class Contacts_DeleteByPhones : ITLFunction<bool> { public string[] phones; }

		[TLDef(0x68CC1411, "contacts.block#68cc1411 id:InputPeer = Bool")]
		public class Contacts_Block : ITLFunction<bool> { public InputPeer id; }

		[TLDef(0xBEA65D50, "contacts.unblock#bea65d50 id:InputPeer = Bool")]
		public class Contacts_Unblock : ITLFunction<bool> { public InputPeer id; }

		[TLDef(0xF57C350F, "contacts.getBlocked#f57c350f offset:int limit:int = contacts.Blocked")]
		public class Contacts_GetBlocked : ITLFunction<Contacts_BlockedBase>
		{
			public int offset;
			public int limit;
		}

		[TLDef(0x63C66506, "messages.getMessages#63c66506 id:Vector<InputMessage> = messages.Messages")]
		public class Messages_GetMessages : ITLFunction<Messages_MessagesBase> { public InputMessage[] id; }

		[TLDef(0xA0EE3B73, "messages.getDialogs#a0ee3b73 flags:# exclude_pinned:flags.0?true folder_id:flags.1?int offset_date:int offset_id:int offset_peer:InputPeer limit:int hash:int = messages.Dialogs")]
		public class Messages_GetDialogs : ITLFunction<Messages_DialogsBase>
		{
			[Flags] public enum Flags { exclude_pinned = 0x1, has_folder_id = 0x2 }
			public Flags flags;
			[IfFlag(1)] public int folder_id;
			public DateTime offset_date;
			public int offset_id;
			public InputPeer offset_peer;
			public int limit;
			public int hash;
		}

		[TLDef(0xDCBB8260, "messages.getHistory#dcbb8260 peer:InputPeer offset_id:int offset_date:int add_offset:int limit:int max_id:int min_id:int hash:int = messages.Messages")]
		public class Messages_GetHistory : ITLFunction<Messages_MessagesBase>
		{
			public InputPeer peer;
			public int offset_id;
			public DateTime offset_date;
			public int add_offset;
			public int limit;
			public int max_id;
			public int min_id;
			public int hash;
		}

		[TLDef(0xC352EEC, "messages.search#0c352eec flags:# peer:InputPeer q:string from_id:flags.0?InputPeer top_msg_id:flags.1?int filter:MessagesFilter min_date:int max_date:int offset_id:int add_offset:int limit:int max_id:int min_id:int hash:int = messages.Messages")]
		public class Messages_Search : ITLFunction<Messages_MessagesBase>
		{
			[Flags] public enum Flags { has_from_id = 0x1, has_top_msg_id = 0x2 }
			public Flags flags;
			public InputPeer peer;
			public string q;
			[IfFlag(0)] public InputPeer from_id;
			[IfFlag(1)] public int top_msg_id;
			public MessagesFilter filter;
			public DateTime min_date;
			public DateTime max_date;
			public int offset_id;
			public int add_offset;
			public int limit;
			public int max_id;
			public int min_id;
			public int hash;
		}

		[TLDef(0xE306D3A, "messages.readHistory#0e306d3a peer:InputPeer max_id:int = messages.AffectedMessages")]
		public class Messages_ReadHistory : ITLFunction<Messages_AffectedMessages>
		{
			public InputPeer peer;
			public int max_id;
		}

		[TLDef(0x1C015B09, "messages.deleteHistory#1c015b09 flags:# just_clear:flags.0?true revoke:flags.1?true peer:InputPeer max_id:int = messages.AffectedHistory")]
		public class Messages_DeleteHistory : ITLFunction<Messages_AffectedHistory>
		{
			[Flags] public enum Flags { just_clear = 0x1, revoke = 0x2 }
			public Flags flags;
			public InputPeer peer;
			public int max_id;
		}

		[TLDef(0xE58E95D2, "messages.deleteMessages#e58e95d2 flags:# revoke:flags.0?true id:Vector<int> = messages.AffectedMessages")]
		public class Messages_DeleteMessages : ITLFunction<Messages_AffectedMessages>
		{
			[Flags] public enum Flags { revoke = 0x1 }
			public Flags flags;
			public int[] id;
		}

		[TLDef(0x5A954C0, "messages.receivedMessages#05a954c0 max_id:int = Vector<ReceivedNotifyMessage>")]
		public class Messages_ReceivedMessages : ITLFunction<ReceivedNotifyMessage[]> { public int max_id; }

		[TLDef(0x58943EE2, "messages.setTyping#58943ee2 flags:# peer:InputPeer top_msg_id:flags.0?int action:SendMessageAction = Bool")]
		public class Messages_SetTyping : ITLFunction<bool>
		{
			[Flags] public enum Flags { has_top_msg_id = 0x1 }
			public Flags flags;
			public InputPeer peer;
			[IfFlag(0)] public int top_msg_id;
			public SendMessageAction action;
		}

		[TLDef(0x520C3870, "messages.sendMessage#520c3870 flags:# no_webpage:flags.1?true silent:flags.5?true background:flags.6?true clear_draft:flags.7?true peer:InputPeer reply_to_msg_id:flags.0?int message:string random_id:long reply_markup:flags.2?ReplyMarkup entities:flags.3?Vector<MessageEntity> schedule_date:flags.10?int = Updates")]
		public class Messages_SendMessage : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { has_reply_to_msg_id = 0x1, no_webpage = 0x2, has_reply_markup = 0x4, has_entities = 0x8, 
				silent = 0x20, background = 0x40, clear_draft = 0x80, has_schedule_date = 0x400 }
			public Flags flags;
			public InputPeer peer;
			[IfFlag(0)] public int reply_to_msg_id;
			public string message;
			public long random_id;
			[IfFlag(2)] public ReplyMarkup reply_markup;
			[IfFlag(3)] public MessageEntity[] entities;
			[IfFlag(10)] public DateTime schedule_date;
		}

		[TLDef(0x3491EBA9, "messages.sendMedia#3491eba9 flags:# silent:flags.5?true background:flags.6?true clear_draft:flags.7?true peer:InputPeer reply_to_msg_id:flags.0?int media:InputMedia message:string random_id:long reply_markup:flags.2?ReplyMarkup entities:flags.3?Vector<MessageEntity> schedule_date:flags.10?int = Updates")]
		public class Messages_SendMedia : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { has_reply_to_msg_id = 0x1, has_reply_markup = 0x4, has_entities = 0x8, silent = 0x20, 
				background = 0x40, clear_draft = 0x80, has_schedule_date = 0x400 }
			public Flags flags;
			public InputPeer peer;
			[IfFlag(0)] public int reply_to_msg_id;
			public InputMedia media;
			public string message;
			public long random_id;
			[IfFlag(2)] public ReplyMarkup reply_markup;
			[IfFlag(3)] public MessageEntity[] entities;
			[IfFlag(10)] public DateTime schedule_date;
		}

		[TLDef(0xD9FEE60E, "messages.forwardMessages#d9fee60e flags:# silent:flags.5?true background:flags.6?true with_my_score:flags.8?true from_peer:InputPeer id:Vector<int> random_id:Vector<long> to_peer:InputPeer schedule_date:flags.10?int = Updates")]
		public class Messages_ForwardMessages : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { silent = 0x20, background = 0x40, with_my_score = 0x100, has_schedule_date = 0x400 }
			public Flags flags;
			public InputPeer from_peer;
			public int[] id;
			public long[] random_id;
			public InputPeer to_peer;
			[IfFlag(10)] public DateTime schedule_date;
		}

		[TLDef(0xCF1592DB, "messages.reportSpam#cf1592db peer:InputPeer = Bool")]
		public class Messages_ReportSpam : ITLFunction<bool> { public InputPeer peer; }

		[TLDef(0x3672E09C, "messages.getPeerSettings#3672e09c peer:InputPeer = PeerSettings")]
		public class Messages_GetPeerSettings : ITLFunction<PeerSettings> { public InputPeer peer; }

		[TLDef(0xBD82B658, "messages.report#bd82b658 peer:InputPeer id:Vector<int> reason:ReportReason = Bool")]
		public class Messages_Report : ITLFunction<bool>
		{
			public InputPeer peer;
			public int[] id;
			public ReportReason reason;
		}

		[TLDef(0x3C6AA187, "messages.getChats#3c6aa187 id:Vector<int> = messages.Chats")]
		public class Messages_GetChats : ITLFunction<Messages_ChatsBase> { public int[] id; }

		[TLDef(0x3B831C66, "messages.getFullChat#3b831c66 chat_id:int = messages.ChatFull")]
		public class Messages_GetFullChat : ITLFunction<Messages_ChatFull> { public int chat_id; }

		[TLDef(0xDC452855, "messages.editChatTitle#dc452855 chat_id:int title:string = Updates")]
		public class Messages_EditChatTitle : ITLFunction<UpdatesBase>
		{
			public int chat_id;
			public string title;
		}

		[TLDef(0xCA4C79D8, "messages.editChatPhoto#ca4c79d8 chat_id:int photo:InputChatPhoto = Updates")]
		public class Messages_EditChatPhoto : ITLFunction<UpdatesBase>
		{
			public int chat_id;
			public InputChatPhotoBase photo;
		}

		[TLDef(0xF9A0AA09, "messages.addChatUser#f9a0aa09 chat_id:int user_id:InputUser fwd_limit:int = Updates")]
		public class Messages_AddChatUser : ITLFunction<UpdatesBase>
		{
			public int chat_id;
			public InputUserBase user_id;
			public int fwd_limit;
		}

		[TLDef(0xE0611F16, "messages.deleteChatUser#e0611f16 chat_id:int user_id:InputUser = Updates")]
		public class Messages_DeleteChatUser : ITLFunction<UpdatesBase>
		{
			public int chat_id;
			public InputUserBase user_id;
		}

		[TLDef(0x9CB126E, "messages.createChat#09cb126e users:Vector<InputUser> title:string = Updates")]
		public class Messages_CreateChat : ITLFunction<UpdatesBase>
		{
			public InputUserBase[] users;
			public string title;
		}

		[TLDef(0xEDD4882A, "updates.getState#edd4882a = updates.State")]
		public class Updates_GetState : ITLFunction<Updates_State> { }

		[TLDef(0x25939651, "updates.getDifference#25939651 flags:# pts:int pts_total_limit:flags.0?int date:int qts:int = updates.Difference")]
		public class Updates_GetDifference : ITLFunction<Updates_DifferenceBase>
		{
			[Flags] public enum Flags { has_pts_total_limit = 0x1 }
			public Flags flags;
			public int pts;
			[IfFlag(0)] public int pts_total_limit;
			public DateTime date;
			public int qts;
		}

		[TLDef(0x72D4742C, "photos.updateProfilePhoto#72d4742c id:InputPhoto = photos.Photo")]
		public class Photos_UpdateProfilePhoto : ITLFunction<Photos_Photo> { public InputPhotoBase id; }

		[TLDef(0x89F30F69, "photos.uploadProfilePhoto#89f30f69 flags:# file:flags.0?InputFile video:flags.1?InputFile video_start_ts:flags.2?double = photos.Photo")]
		public class Photos_UploadProfilePhoto : ITLFunction<Photos_Photo>
		{
			[Flags] public enum Flags { has_file = 0x1, has_video = 0x2, has_video_start_ts = 0x4 }
			public Flags flags;
			[IfFlag(0)] public InputFileBase file;
			[IfFlag(1)] public InputFileBase video;
			[IfFlag(2)] public double video_start_ts;
		}

		[TLDef(0x87CF7F2F, "photos.deletePhotos#87cf7f2f id:Vector<InputPhoto> = Vector<long>")]
		public class Photos_DeletePhotos : ITLFunction<long[]> { public InputPhotoBase[] id; }

		[TLDef(0xB304A621, "upload.saveFilePart#b304a621 file_id:long file_part:int bytes:bytes = Bool")]
		public class Upload_SaveFilePart : ITLFunction<bool>
		{
			public long file_id;
			public int file_part;
			public byte[] bytes;
		}

		[TLDef(0xB15A9AFC, "upload.getFile#b15a9afc flags:# precise:flags.0?true cdn_supported:flags.1?true location:InputFileLocation offset:int limit:int = upload.File")]
		public class Upload_GetFile : ITLFunction<Upload_FileBase>
		{
			[Flags] public enum Flags { precise = 0x1, cdn_supported = 0x2 }
			public Flags flags;
			public InputFileLocationBase location;
			public int offset;
			public int limit;
		}

		[TLDef(0xC4F9186B, "help.getConfig#c4f9186b = Config")]
		public class Help_GetConfig : ITLFunction<Config> { }

		[TLDef(0x1FB33026, "help.getNearestDc#1fb33026 = NearestDc")]
		public class Help_GetNearestDc : ITLFunction<NearestDc> { }

		[TLDef(0x522D5A7D, "help.getAppUpdate#522d5a7d source:string = help.AppUpdate")]
		public class Help_GetAppUpdate : ITLFunction<Help_AppUpdateBase> { public string source; }

		[TLDef(0x4D392343, "help.getInviteText#4d392343 = help.InviteText")]
		public class Help_GetInviteText : ITLFunction<Help_InviteText> { }

		[TLDef(0x91CD32A8, "photos.getUserPhotos#91cd32a8 user_id:InputUser offset:int max_id:long limit:int = photos.Photos")]
		public class Photos_GetUserPhotos : ITLFunction<Photos_PhotosBase>
		{
			public InputUserBase user_id;
			public int offset;
			public long max_id;
			public int limit;
		}

		[TLDef(0x26CF8950, "messages.getDhConfig#26cf8950 version:int random_length:int = messages.DhConfig")]
		public class Messages_GetDhConfig : ITLFunction<Messages_DhConfigBase>
		{
			public int version;
			public int random_length;
		}

		[TLDef(0xF64DAF43, "messages.requestEncryption#f64daf43 user_id:InputUser random_id:int g_a:bytes = EncryptedChat")]
		public class Messages_RequestEncryption : ITLFunction<EncryptedChatBase>
		{
			public InputUserBase user_id;
			public int random_id;
			public byte[] g_a;
		}

		[TLDef(0x3DBC0415, "messages.acceptEncryption#3dbc0415 peer:InputEncryptedChat g_b:bytes key_fingerprint:long = EncryptedChat")]
		public class Messages_AcceptEncryption : ITLFunction<EncryptedChatBase>
		{
			public InputEncryptedChat peer;
			public byte[] g_b;
			public long key_fingerprint;
		}

		[TLDef(0xEDD923C5, "messages.discardEncryption#edd923c5 chat_id:int = Bool")]
		public class Messages_DiscardEncryption : ITLFunction<bool> { public int chat_id; }

		[TLDef(0x791451ED, "messages.setEncryptedTyping#791451ed peer:InputEncryptedChat typing:Bool = Bool")]
		public class Messages_SetEncryptedTyping : ITLFunction<bool>
		{
			public InputEncryptedChat peer;
			public bool typing;
		}

		[TLDef(0x7F4B690A, "messages.readEncryptedHistory#7f4b690a peer:InputEncryptedChat max_date:int = Bool")]
		public class Messages_ReadEncryptedHistory : ITLFunction<bool>
		{
			public InputEncryptedChat peer;
			public DateTime max_date;
		}

		[TLDef(0x44FA7A15, "messages.sendEncrypted#44fa7a15 flags:# silent:flags.0?true peer:InputEncryptedChat random_id:long data:bytes = messages.SentEncryptedMessage")]
		public class Messages_SendEncrypted : ITLFunction<Messages_SentEncryptedMessage>
		{
			[Flags] public enum Flags { silent = 0x1 }
			public Flags flags;
			public InputEncryptedChat peer;
			public long random_id;
			public byte[] data;
		}

		[TLDef(0x5559481D, "messages.sendEncryptedFile#5559481d flags:# silent:flags.0?true peer:InputEncryptedChat random_id:long data:bytes file:InputEncryptedFile = messages.SentEncryptedMessage")]
		public class Messages_SendEncryptedFile : ITLFunction<Messages_SentEncryptedMessage>
		{
			[Flags] public enum Flags { silent = 0x1 }
			public Flags flags;
			public InputEncryptedChat peer;
			public long random_id;
			public byte[] data;
			public InputEncryptedFileBase file;
		}

		[TLDef(0x32D439A4, "messages.sendEncryptedService#32d439a4 peer:InputEncryptedChat random_id:long data:bytes = messages.SentEncryptedMessage")]
		public class Messages_SendEncryptedService : ITLFunction<Messages_SentEncryptedMessage>
		{
			public InputEncryptedChat peer;
			public long random_id;
			public byte[] data;
		}

		[TLDef(0x55A5BB66, "messages.receivedQueue#55a5bb66 max_qts:int = Vector<long>")]
		public class Messages_ReceivedQueue : ITLFunction<long[]> { public int max_qts; }

		[TLDef(0x4B0C8C0F, "messages.reportEncryptedSpam#4b0c8c0f peer:InputEncryptedChat = Bool")]
		public class Messages_ReportEncryptedSpam : ITLFunction<bool> { public InputEncryptedChat peer; }

		[TLDef(0xDE7B673D, "upload.saveBigFilePart#de7b673d file_id:long file_part:int file_total_parts:int bytes:bytes = Bool")]
		public class Upload_SaveBigFilePart : ITLFunction<bool>
		{
			public long file_id;
			public int file_part;
			public int file_total_parts;
			public byte[] bytes;
		}

		[TLDef(0xC1CD5EA9, "initConnection#c1cd5ea9 {X:Type} flags:# api_id:int device_model:string system_version:string app_version:string system_lang_code:string lang_pack:string lang_code:string proxy:flags.0?InputClientProxy params:flags.1?JSONValue query:!X = X")]
		public class InitConnection<X> : ITLFunction<X>
		{
			[Flags] public enum Flags { has_proxy = 0x1, has_params = 0x2 }
			public Flags flags;
			public int api_id;
			public string device_model;
			public string system_version;
			public string app_version;
			public string system_lang_code;
			public string lang_pack;
			public string lang_code;
			[IfFlag(0)] public InputClientProxy proxy;
			[IfFlag(1)] public JSONValue params_;
			public ITLFunction<X> query;
		}

		[TLDef(0x9CDF08CD, "help.getSupport#9cdf08cd = help.Support")]
		public class Help_GetSupport : ITLFunction<Help_Support> { }

		[TLDef(0x36A73F77, "messages.readMessageContents#36a73f77 id:Vector<int> = messages.AffectedMessages")]
		public class Messages_ReadMessageContents : ITLFunction<Messages_AffectedMessages> { public int[] id; }

		[TLDef(0x2714D86C, "account.checkUsername#2714d86c username:string = Bool")]
		public class Account_CheckUsername : ITLFunction<bool> { public string username; }

		[TLDef(0x3E0BDD7C, "account.updateUsername#3e0bdd7c username:string = User")]
		public class Account_UpdateUsername : ITLFunction<UserBase> { public string username; }

		[TLDef(0x11F812D8, "contacts.search#11f812d8 q:string limit:int = contacts.Found")]
		public class Contacts_Search : ITLFunction<Contacts_Found>
		{
			public string q;
			public int limit;
		}

		[TLDef(0xDADBC950, "account.getPrivacy#dadbc950 key:InputPrivacyKey = account.PrivacyRules")]
		public class Account_GetPrivacy : ITLFunction<Account_PrivacyRules> { public InputPrivacyKey key; }

		[TLDef(0xC9F81CE8, "account.setPrivacy#c9f81ce8 key:InputPrivacyKey rules:Vector<InputPrivacyRule> = account.PrivacyRules")]
		public class Account_SetPrivacy : ITLFunction<Account_PrivacyRules>
		{
			public InputPrivacyKey key;
			public InputPrivacyRule[] rules;
		}

		[TLDef(0x418D4E0B, "account.deleteAccount#418d4e0b reason:string = Bool")]
		public class Account_DeleteAccount : ITLFunction<bool> { public string reason; }

		[TLDef(0x8FC711D, "account.getAccountTTL#08fc711d = AccountDaysTTL")]
		public class Account_GetAccountTTL : ITLFunction<AccountDaysTTL> { }

		[TLDef(0x2442485E, "account.setAccountTTL#2442485e ttl:AccountDaysTTL = Bool")]
		public class Account_SetAccountTTL : ITLFunction<bool> { public AccountDaysTTL ttl; }

		[TLDef(0xDA9B0D0D, "invokeWithLayer#da9b0d0d {X:Type} layer:int query:!X = X")]
		public class InvokeWithLayer<X> : ITLFunction<X>
		{
			public int layer;
			public ITLFunction<X> query;
		}

		[TLDef(0xF93CCBA3, "contacts.resolveUsername#f93ccba3 username:string = contacts.ResolvedPeer")]
		public class Contacts_ResolveUsername : ITLFunction<Contacts_ResolvedPeer> { public string username; }

		[TLDef(0x82574AE5, "account.sendChangePhoneCode#82574ae5 phone_number:string settings:CodeSettings = auth.SentCode")]
		public class Account_SendChangePhoneCode : ITLFunction<Auth_SentCode>
		{
			public string phone_number;
			public CodeSettings settings;
		}

		[TLDef(0x70C32EDB, "account.changePhone#70c32edb phone_number:string phone_code_hash:string phone_code:string = User")]
		public class Account_ChangePhone : ITLFunction<UserBase>
		{
			public string phone_number;
			public string phone_code_hash;
			public string phone_code;
		}

		[TLDef(0x43D4F2C, "messages.getStickers#043d4f2c emoticon:string hash:int = messages.Stickers")]
		public class Messages_GetStickers : ITLFunction<Messages_StickersBase>
		{
			public string emoticon;
			public int hash;
		}

		[TLDef(0x1C9618B1, "messages.getAllStickers#1c9618b1 hash:int = messages.AllStickers")]
		public class Messages_GetAllStickers : ITLFunction<Messages_AllStickersBase> { public int hash; }

		[TLDef(0x38DF3532, "account.updateDeviceLocked#38df3532 period:int = Bool")]
		public class Account_UpdateDeviceLocked : ITLFunction<bool> { public int period; }

		[TLDef(0x67A3FF2C, "auth.importBotAuthorization#67a3ff2c flags:int api_id:int api_hash:string bot_auth_token:string = auth.Authorization")]
		public class Auth_ImportBotAuthorization : ITLFunction<Auth_AuthorizationBase>
		{
			public int flags;
			public int api_id;
			public string api_hash;
			public string bot_auth_token;
		}

		[TLDef(0x8B68B0CC, "messages.getWebPagePreview#8b68b0cc flags:# message:string entities:flags.3?Vector<MessageEntity> = MessageMedia")]
		public class Messages_GetWebPagePreview : ITLFunction<MessageMedia>
		{
			[Flags] public enum Flags { has_entities = 0x8 }
			public Flags flags;
			public string message;
			[IfFlag(3)] public MessageEntity[] entities;
		}

		[TLDef(0xE320C158, "account.getAuthorizations#e320c158 = account.Authorizations")]
		public class Account_GetAuthorizations : ITLFunction<Account_Authorizations> { }

		[TLDef(0xDF77F3BC, "account.resetAuthorization#df77f3bc hash:long = Bool")]
		public class Account_ResetAuthorization : ITLFunction<bool> { public long hash; }

		[TLDef(0x548A30F5, "account.getPassword#548a30f5 = account.Password")]
		public class Account_GetPassword : ITLFunction<Account_Password> { }

		[TLDef(0x9CD4EAF9, "account.getPasswordSettings#9cd4eaf9 password:InputCheckPasswordSRP = account.PasswordSettings")]
		public class Account_GetPasswordSettings : ITLFunction<Account_PasswordSettings> { public InputCheckPasswordSRPBase password; }

		[TLDef(0xA59B102F, "account.updatePasswordSettings#a59b102f password:InputCheckPasswordSRP new_settings:account.PasswordInputSettings = Bool")]
		public class Account_UpdatePasswordSettings : ITLFunction<bool>
		{
			public InputCheckPasswordSRPBase password;
			public Account_PasswordInputSettings new_settings;
		}

		[TLDef(0xD18B4D16, "auth.checkPassword#d18b4d16 password:InputCheckPasswordSRP = auth.Authorization")]
		public class Auth_CheckPassword : ITLFunction<Auth_AuthorizationBase> { public InputCheckPasswordSRPBase password; }

		[TLDef(0xD897BC66, "auth.requestPasswordRecovery#d897bc66 = auth.PasswordRecovery")]
		public class Auth_RequestPasswordRecovery : ITLFunction<Auth_PasswordRecovery> { }

		[TLDef(0x4EA56E92, "auth.recoverPassword#4ea56e92 code:string = auth.Authorization")]
		public class Auth_RecoverPassword : ITLFunction<Auth_AuthorizationBase> { public string code; }

		[TLDef(0xBF9459B7, "invokeWithoutUpdates#bf9459b7 {X:Type} query:!X = X")]
		public class InvokeWithoutUpdates<X> : ITLFunction<X> { public ITLFunction<X> query; }

		[TLDef(0xDF7534C, "messages.exportChatInvite#0df7534c peer:InputPeer = ExportedChatInvite")]
		public class Messages_ExportChatInvite : ITLFunction<ExportedChatInvite> { public InputPeer peer; }

		[TLDef(0x3EADB1BB, "messages.checkChatInvite#3eadb1bb hash:string = ChatInvite")]
		public class Messages_CheckChatInvite : ITLFunction<ChatInviteBase> { public string hash; }

		[TLDef(0x6C50051C, "messages.importChatInvite#6c50051c hash:string = Updates")]
		public class Messages_ImportChatInvite : ITLFunction<UpdatesBase> { public string hash; }

		[TLDef(0x2619A90E, "messages.getStickerSet#2619a90e stickerset:InputStickerSet = messages.StickerSet")]
		public class Messages_GetStickerSet : ITLFunction<Messages_StickerSet> { public InputStickerSet stickerset; }

		[TLDef(0xC78FE460, "messages.installStickerSet#c78fe460 stickerset:InputStickerSet archived:Bool = messages.StickerSetInstallResult")]
		public class Messages_InstallStickerSet : ITLFunction<Messages_StickerSetInstallResult>
		{
			public InputStickerSet stickerset;
			public bool archived;
		}

		[TLDef(0xF96E55DE, "messages.uninstallStickerSet#f96e55de stickerset:InputStickerSet = Bool")]
		public class Messages_UninstallStickerSet : ITLFunction<bool> { public InputStickerSet stickerset; }

		[TLDef(0xE6DF7378, "messages.startBot#e6df7378 bot:InputUser peer:InputPeer random_id:long start_param:string = Updates")]
		public class Messages_StartBot : ITLFunction<UpdatesBase>
		{
			public InputUserBase bot;
			public InputPeer peer;
			public long random_id;
			public string start_param;
		}

		[TLDef(0x9010EF6F, "help.getAppChangelog#9010ef6f prev_app_version:string = Updates")]
		public class Help_GetAppChangelog : ITLFunction<UpdatesBase> { public string prev_app_version; }

		[TLDef(0x5784D3E1, "messages.getMessagesViews#5784d3e1 peer:InputPeer id:Vector<int> increment:Bool = messages.MessageViews")]
		public class Messages_GetMessagesViews : ITLFunction<Messages_MessageViews>
		{
			public InputPeer peer;
			public int[] id;
			public bool increment;
		}

		[TLDef(0xCC104937, "channels.readHistory#cc104937 channel:InputChannel max_id:int = Bool")]
		public class Channels_ReadHistory : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public int max_id;
		}

		[TLDef(0x84C1FD4E, "channels.deleteMessages#84c1fd4e channel:InputChannel id:Vector<int> = messages.AffectedMessages")]
		public class Channels_DeleteMessages : ITLFunction<Messages_AffectedMessages>
		{
			public InputChannelBase channel;
			public int[] id;
		}

		[TLDef(0xD10DD71B, "channels.deleteUserHistory#d10dd71b channel:InputChannel user_id:InputUser = messages.AffectedHistory")]
		public class Channels_DeleteUserHistory : ITLFunction<Messages_AffectedHistory>
		{
			public InputChannelBase channel;
			public InputUserBase user_id;
		}

		[TLDef(0xFE087810, "channels.reportSpam#fe087810 channel:InputChannel user_id:InputUser id:Vector<int> = Bool")]
		public class Channels_ReportSpam : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public InputUserBase user_id;
			public int[] id;
		}

		[TLDef(0xAD8C9A23, "channels.getMessages#ad8c9a23 channel:InputChannel id:Vector<InputMessage> = messages.Messages")]
		public class Channels_GetMessages : ITLFunction<Messages_MessagesBase>
		{
			public InputChannelBase channel;
			public InputMessage[] id;
		}

		[TLDef(0x123E05E9, "channels.getParticipants#123e05e9 channel:InputChannel filter:ChannelParticipantsFilter offset:int limit:int hash:int = channels.ChannelParticipants")]
		public class Channels_GetParticipants : ITLFunction<Channels_ChannelParticipantsBase>
		{
			public InputChannelBase channel;
			public ChannelParticipantsFilter filter;
			public int offset;
			public int limit;
			public int hash;
		}

		[TLDef(0x546DD7A6, "channels.getParticipant#546dd7a6 channel:InputChannel user_id:InputUser = channels.ChannelParticipant")]
		public class Channels_GetParticipant : ITLFunction<Channels_ChannelParticipant>
		{
			public InputChannelBase channel;
			public InputUserBase user_id;
		}

		[TLDef(0xA7F6BBB, "channels.getChannels#0a7f6bbb id:Vector<InputChannel> = messages.Chats")]
		public class Channels_GetChannels : ITLFunction<Messages_ChatsBase> { public InputChannelBase[] id; }

		[TLDef(0x8736A09, "channels.getFullChannel#08736a09 channel:InputChannel = messages.ChatFull")]
		public class Channels_GetFullChannel : ITLFunction<Messages_ChatFull> { public InputChannelBase channel; }

		[TLDef(0x3D5FB10F, "channels.createChannel#3d5fb10f flags:# broadcast:flags.0?true megagroup:flags.1?true for_import:flags.3?true title:string about:string geo_point:flags.2?InputGeoPoint address:flags.2?string = Updates")]
		public class Channels_CreateChannel : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { broadcast = 0x1, megagroup = 0x2, has_geo_point = 0x4, for_import = 0x8 }
			public Flags flags;
			public string title;
			public string about;
			[IfFlag(2)] public InputGeoPointBase geo_point;
			[IfFlag(2)] public string address;
		}

		[TLDef(0xD33C8902, "channels.editAdmin#d33c8902 channel:InputChannel user_id:InputUser admin_rights:ChatAdminRights rank:string = Updates")]
		public class Channels_EditAdmin : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public InputUserBase user_id;
			public ChatAdminRights admin_rights;
			public string rank;
		}

		[TLDef(0x566DECD0, "channels.editTitle#566decd0 channel:InputChannel title:string = Updates")]
		public class Channels_EditTitle : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public string title;
		}

		[TLDef(0xF12E57C9, "channels.editPhoto#f12e57c9 channel:InputChannel photo:InputChatPhoto = Updates")]
		public class Channels_EditPhoto : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public InputChatPhotoBase photo;
		}

		[TLDef(0x10E6BD2C, "channels.checkUsername#10e6bd2c channel:InputChannel username:string = Bool")]
		public class Channels_CheckUsername : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public string username;
		}

		[TLDef(0x3514B3DE, "channels.updateUsername#3514b3de channel:InputChannel username:string = Bool")]
		public class Channels_UpdateUsername : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public string username;
		}

		[TLDef(0x24B524C5, "channels.joinChannel#24b524c5 channel:InputChannel = Updates")]
		public class Channels_JoinChannel : ITLFunction<UpdatesBase> { public InputChannelBase channel; }

		[TLDef(0xF836AA95, "channels.leaveChannel#f836aa95 channel:InputChannel = Updates")]
		public class Channels_LeaveChannel : ITLFunction<UpdatesBase> { public InputChannelBase channel; }

		[TLDef(0x199F3A6C, "channels.inviteToChannel#199f3a6c channel:InputChannel users:Vector<InputUser> = Updates")]
		public class Channels_InviteToChannel : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public InputUserBase[] users;
		}

		[TLDef(0xC0111FE3, "channels.deleteChannel#c0111fe3 channel:InputChannel = Updates")]
		public class Channels_DeleteChannel : ITLFunction<UpdatesBase> { public InputChannelBase channel; }

		[TLDef(0x3173D78, "updates.getChannelDifference#03173d78 flags:# force:flags.0?true channel:InputChannel filter:ChannelMessagesFilter pts:int limit:int = updates.ChannelDifference")]
		public class Updates_GetChannelDifference : ITLFunction<Updates_ChannelDifferenceBase>
		{
			[Flags] public enum Flags { force = 0x1 }
			public Flags flags;
			public InputChannelBase channel;
			public ChannelMessagesFilterBase filter;
			public int pts;
			public int limit;
		}

		[TLDef(0xA9E69F2E, "messages.editChatAdmin#a9e69f2e chat_id:int user_id:InputUser is_admin:Bool = Bool")]
		public class Messages_EditChatAdmin : ITLFunction<bool>
		{
			public int chat_id;
			public InputUserBase user_id;
			public bool is_admin;
		}

		[TLDef(0x15A3B8E3, "messages.migrateChat#15a3b8e3 chat_id:int = Updates")]
		public class Messages_MigrateChat : ITLFunction<UpdatesBase> { public int chat_id; }

		[TLDef(0x4BC6589A, "messages.searchGlobal#4bc6589a flags:# folder_id:flags.0?int q:string filter:MessagesFilter min_date:int max_date:int offset_rate:int offset_peer:InputPeer offset_id:int limit:int = messages.Messages")]
		public class Messages_SearchGlobal : ITLFunction<Messages_MessagesBase>
		{
			[Flags] public enum Flags { has_folder_id = 0x1 }
			public Flags flags;
			[IfFlag(0)] public int folder_id;
			public string q;
			public MessagesFilter filter;
			public DateTime min_date;
			public DateTime max_date;
			public int offset_rate;
			public InputPeer offset_peer;
			public int offset_id;
			public int limit;
		}

		[TLDef(0x78337739, "messages.reorderStickerSets#78337739 flags:# masks:flags.0?true order:Vector<long> = Bool")]
		public class Messages_ReorderStickerSets : ITLFunction<bool>
		{
			[Flags] public enum Flags { masks = 0x1 }
			public Flags flags;
			public long[] order;
		}

		[TLDef(0x338E2464, "messages.getDocumentByHash#338e2464 sha256:bytes size:int mime_type:string = Document")]
		public class Messages_GetDocumentByHash : ITLFunction<DocumentBase>
		{
			public byte[] sha256;
			public int size;
			public string mime_type;
		}

		[TLDef(0x83BF3D52, "messages.getSavedGifs#83bf3d52 hash:int = messages.SavedGifs")]
		public class Messages_GetSavedGifs : ITLFunction<Messages_SavedGifsBase> { public int hash; }

		[TLDef(0x327A30CB, "messages.saveGif#327a30cb id:InputDocument unsave:Bool = Bool")]
		public class Messages_SaveGif : ITLFunction<bool>
		{
			public InputDocumentBase id;
			public bool unsave;
		}

		[TLDef(0x514E999D, "messages.getInlineBotResults#514e999d flags:# bot:InputUser peer:InputPeer geo_point:flags.0?InputGeoPoint query:string offset:string = messages.BotResults")]
		public class Messages_GetInlineBotResults : ITLFunction<Messages_BotResults>
		{
			[Flags] public enum Flags { has_geo_point = 0x1 }
			public Flags flags;
			public InputUserBase bot;
			public InputPeer peer;
			[IfFlag(0)] public InputGeoPointBase geo_point;
			public string query;
			public string offset;
		}

		[TLDef(0xEB5EA206, "messages.setInlineBotResults#eb5ea206 flags:# gallery:flags.0?true private:flags.1?true query_id:long results:Vector<InputBotInlineResult> cache_time:int next_offset:flags.2?string switch_pm:flags.3?InlineBotSwitchPM = Bool")]
		public class Messages_SetInlineBotResults : ITLFunction<bool>
		{
			[Flags] public enum Flags { gallery = 0x1, private_ = 0x2, has_next_offset = 0x4, has_switch_pm = 0x8 }
			public Flags flags;
			public long query_id;
			public InputBotInlineResultBase[] results;
			public DateTime cache_time;
			[IfFlag(2)] public string next_offset;
			[IfFlag(3)] public InlineBotSwitchPM switch_pm;
		}

		[TLDef(0x220815B0, "messages.sendInlineBotResult#220815b0 flags:# silent:flags.5?true background:flags.6?true clear_draft:flags.7?true hide_via:flags.11?true peer:InputPeer reply_to_msg_id:flags.0?int random_id:long query_id:long id:string schedule_date:flags.10?int = Updates")]
		public class Messages_SendInlineBotResult : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { has_reply_to_msg_id = 0x1, silent = 0x20, background = 0x40, clear_draft = 0x80, 
				has_schedule_date = 0x400, hide_via = 0x800 }
			public Flags flags;
			public InputPeer peer;
			[IfFlag(0)] public int reply_to_msg_id;
			public long random_id;
			public long query_id;
			public string id;
			[IfFlag(10)] public DateTime schedule_date;
		}

		[TLDef(0xE63FADEB, "channels.exportMessageLink#e63fadeb flags:# grouped:flags.0?true thread:flags.1?true channel:InputChannel id:int = ExportedMessageLink")]
		public class Channels_ExportMessageLink : ITLFunction<ExportedMessageLink>
		{
			[Flags] public enum Flags { grouped = 0x1, thread = 0x2 }
			public Flags flags;
			public InputChannelBase channel;
			public int id;
		}

		[TLDef(0x1F69B606, "channels.toggleSignatures#1f69b606 channel:InputChannel enabled:Bool = Updates")]
		public class Channels_ToggleSignatures : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public bool enabled;
		}

		[TLDef(0x3EF1A9BF, "auth.resendCode#3ef1a9bf phone_number:string phone_code_hash:string = auth.SentCode")]
		public class Auth_ResendCode : ITLFunction<Auth_SentCode>
		{
			public string phone_number;
			public string phone_code_hash;
		}

		[TLDef(0x1F040578, "auth.cancelCode#1f040578 phone_number:string phone_code_hash:string = Bool")]
		public class Auth_CancelCode : ITLFunction<bool>
		{
			public string phone_number;
			public string phone_code_hash;
		}

		[TLDef(0xFDA68D36, "messages.getMessageEditData#fda68d36 peer:InputPeer id:int = messages.MessageEditData")]
		public class Messages_GetMessageEditData : ITLFunction<Messages_MessageEditData>
		{
			public InputPeer peer;
			public int id;
		}

		[TLDef(0x48F71778, "messages.editMessage#48f71778 flags:# no_webpage:flags.1?true peer:InputPeer id:int message:flags.11?string media:flags.14?InputMedia reply_markup:flags.2?ReplyMarkup entities:flags.3?Vector<MessageEntity> schedule_date:flags.15?int = Updates")]
		public class Messages_EditMessage : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { no_webpage = 0x2, has_reply_markup = 0x4, has_entities = 0x8, has_message = 0x800, 
				has_media = 0x4000, has_schedule_date = 0x8000 }
			public Flags flags;
			public InputPeer peer;
			public int id;
			[IfFlag(11)] public string message;
			[IfFlag(14)] public InputMedia media;
			[IfFlag(2)] public ReplyMarkup reply_markup;
			[IfFlag(3)] public MessageEntity[] entities;
			[IfFlag(15)] public DateTime schedule_date;
		}

		[TLDef(0x83557DBA, "messages.editInlineBotMessage#83557dba flags:# no_webpage:flags.1?true id:InputBotInlineMessageID message:flags.11?string media:flags.14?InputMedia reply_markup:flags.2?ReplyMarkup entities:flags.3?Vector<MessageEntity> = Bool")]
		public class Messages_EditInlineBotMessage : ITLFunction<bool>
		{
			[Flags] public enum Flags { no_webpage = 0x2, has_reply_markup = 0x4, has_entities = 0x8, has_message = 0x800, 
				has_media = 0x4000 }
			public Flags flags;
			public InputBotInlineMessageID id;
			[IfFlag(11)] public string message;
			[IfFlag(14)] public InputMedia media;
			[IfFlag(2)] public ReplyMarkup reply_markup;
			[IfFlag(3)] public MessageEntity[] entities;
		}

		[TLDef(0x9342CA07, "messages.getBotCallbackAnswer#9342ca07 flags:# game:flags.1?true peer:InputPeer msg_id:int data:flags.0?bytes password:flags.2?InputCheckPasswordSRP = messages.BotCallbackAnswer")]
		public class Messages_GetBotCallbackAnswer : ITLFunction<Messages_BotCallbackAnswer>
		{
			[Flags] public enum Flags { has_data = 0x1, game = 0x2, has_password = 0x4 }
			public Flags flags;
			public InputPeer peer;
			public int msg_id;
			[IfFlag(0)] public byte[] data;
			[IfFlag(2)] public InputCheckPasswordSRPBase password;
		}

		[TLDef(0xD58F130A, "messages.setBotCallbackAnswer#d58f130a flags:# alert:flags.1?true query_id:long message:flags.0?string url:flags.2?string cache_time:int = Bool")]
		public class Messages_SetBotCallbackAnswer : ITLFunction<bool>
		{
			[Flags] public enum Flags { has_message = 0x1, alert = 0x2, has_url = 0x4 }
			public Flags flags;
			public long query_id;
			[IfFlag(0)] public string message;
			[IfFlag(2)] public string url;
			public DateTime cache_time;
		}

		[TLDef(0xD4982DB5, "contacts.getTopPeers#d4982db5 flags:# correspondents:flags.0?true bots_pm:flags.1?true bots_inline:flags.2?true phone_calls:flags.3?true forward_users:flags.4?true forward_chats:flags.5?true groups:flags.10?true channels:flags.15?true offset:int limit:int hash:int = contacts.TopPeers")]
		public class Contacts_GetTopPeers : ITLFunction<Contacts_TopPeersBase>
		{
			[Flags] public enum Flags { correspondents = 0x1, bots_pm = 0x2, bots_inline = 0x4, phone_calls = 0x8, 
				forward_users = 0x10, forward_chats = 0x20, groups = 0x400, channels = 0x8000 }
			public Flags flags;
			public int offset;
			public int limit;
			public int hash;
		}

		[TLDef(0x1AE373AC, "contacts.resetTopPeerRating#1ae373ac category:TopPeerCategory peer:InputPeer = Bool")]
		public class Contacts_ResetTopPeerRating : ITLFunction<bool>
		{
			public TopPeerCategory category;
			public InputPeer peer;
		}

		[TLDef(0xE470BCFD, "messages.getPeerDialogs#e470bcfd peers:Vector<InputDialogPeer> = messages.PeerDialogs")]
		public class Messages_GetPeerDialogs : ITLFunction<Messages_PeerDialogs> { public InputDialogPeerBase[] peers; }

		[TLDef(0xBC39E14B, "messages.saveDraft#bc39e14b flags:# no_webpage:flags.1?true reply_to_msg_id:flags.0?int peer:InputPeer message:string entities:flags.3?Vector<MessageEntity> = Bool")]
		public class Messages_SaveDraft : ITLFunction<bool>
		{
			[Flags] public enum Flags { has_reply_to_msg_id = 0x1, no_webpage = 0x2, has_entities = 0x8 }
			public Flags flags;
			[IfFlag(0)] public int reply_to_msg_id;
			public InputPeer peer;
			public string message;
			[IfFlag(3)] public MessageEntity[] entities;
		}

		[TLDef(0x6A3F8D65, "messages.getAllDrafts#6a3f8d65 = Updates")]
		public class Messages_GetAllDrafts : ITLFunction<UpdatesBase> { }

		[TLDef(0x2DACCA4F, "messages.getFeaturedStickers#2dacca4f hash:int = messages.FeaturedStickers")]
		public class Messages_GetFeaturedStickers : ITLFunction<Messages_FeaturedStickersBase> { public int hash; }

		[TLDef(0x5B118126, "messages.readFeaturedStickers#5b118126 id:Vector<long> = Bool")]
		public class Messages_ReadFeaturedStickers : ITLFunction<bool> { public long[] id; }

		[TLDef(0x5EA192C9, "messages.getRecentStickers#5ea192c9 flags:# attached:flags.0?true hash:int = messages.RecentStickers")]
		public class Messages_GetRecentStickers : ITLFunction<Messages_RecentStickersBase>
		{
			[Flags] public enum Flags { attached = 0x1 }
			public Flags flags;
			public int hash;
		}

		[TLDef(0x392718F8, "messages.saveRecentSticker#392718f8 flags:# attached:flags.0?true id:InputDocument unsave:Bool = Bool")]
		public class Messages_SaveRecentSticker : ITLFunction<bool>
		{
			[Flags] public enum Flags { attached = 0x1 }
			public Flags flags;
			public InputDocumentBase id;
			public bool unsave;
		}

		[TLDef(0x8999602D, "messages.clearRecentStickers#8999602d flags:# attached:flags.0?true = Bool")]
		public class Messages_ClearRecentStickers : ITLFunction<bool>
		{
			[Flags] public enum Flags { attached = 0x1 }
			public Flags flags;
		}

		[TLDef(0x57F17692, "messages.getArchivedStickers#57f17692 flags:# masks:flags.0?true offset_id:long limit:int = messages.ArchivedStickers")]
		public class Messages_GetArchivedStickers : ITLFunction<Messages_ArchivedStickers>
		{
			[Flags] public enum Flags { masks = 0x1 }
			public Flags flags;
			public long offset_id;
			public int limit;
		}

		[TLDef(0x1B3FAA88, "account.sendConfirmPhoneCode#1b3faa88 hash:string settings:CodeSettings = auth.SentCode")]
		public class Account_SendConfirmPhoneCode : ITLFunction<Auth_SentCode>
		{
			public string hash;
			public CodeSettings settings;
		}

		[TLDef(0x5F2178C3, "account.confirmPhone#5f2178c3 phone_code_hash:string phone_code:string = Bool")]
		public class Account_ConfirmPhone : ITLFunction<bool>
		{
			public string phone_code_hash;
			public string phone_code;
		}

		[TLDef(0xF8B036AF, "channels.getAdminedPublicChannels#f8b036af flags:# by_location:flags.0?true check_limit:flags.1?true = messages.Chats")]
		public class Channels_GetAdminedPublicChannels : ITLFunction<Messages_ChatsBase>
		{
			[Flags] public enum Flags { by_location = 0x1, check_limit = 0x2 }
			public Flags flags;
		}

		[TLDef(0x65B8C79F, "messages.getMaskStickers#65b8c79f hash:int = messages.AllStickers")]
		public class Messages_GetMaskStickers : ITLFunction<Messages_AllStickersBase> { public int hash; }

		[TLDef(0xCC5B67CC, "messages.getAttachedStickers#cc5b67cc media:InputStickeredMedia = Vector<StickerSetCovered>")]
		public class Messages_GetAttachedStickers : ITLFunction<StickerSetCoveredBase[]> { public InputStickeredMedia media; }

		[TLDef(0x8E48A188, "auth.dropTempAuthKeys#8e48a188 except_auth_keys:Vector<long> = Bool")]
		public class Auth_DropTempAuthKeys : ITLFunction<bool> { public long[] except_auth_keys; }

		[TLDef(0x8EF8ECC0, "messages.setGameScore#8ef8ecc0 flags:# edit_message:flags.0?true force:flags.1?true peer:InputPeer id:int user_id:InputUser score:int = Updates")]
		public class Messages_SetGameScore : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { edit_message = 0x1, force = 0x2 }
			public Flags flags;
			public InputPeer peer;
			public int id;
			public InputUserBase user_id;
			public int score;
		}

		[TLDef(0x15AD9F64, "messages.setInlineGameScore#15ad9f64 flags:# edit_message:flags.0?true force:flags.1?true id:InputBotInlineMessageID user_id:InputUser score:int = Bool")]
		public class Messages_SetInlineGameScore : ITLFunction<bool>
		{
			[Flags] public enum Flags { edit_message = 0x1, force = 0x2 }
			public Flags flags;
			public InputBotInlineMessageID id;
			public InputUserBase user_id;
			public int score;
		}

		[TLDef(0xE822649D, "messages.getGameHighScores#e822649d peer:InputPeer id:int user_id:InputUser = messages.HighScores")]
		public class Messages_GetGameHighScores : ITLFunction<Messages_HighScores>
		{
			public InputPeer peer;
			public int id;
			public InputUserBase user_id;
		}

		[TLDef(0xF635E1B, "messages.getInlineGameHighScores#0f635e1b id:InputBotInlineMessageID user_id:InputUser = messages.HighScores")]
		public class Messages_GetInlineGameHighScores : ITLFunction<Messages_HighScores>
		{
			public InputBotInlineMessageID id;
			public InputUserBase user_id;
		}

		[TLDef(0xD0A48C4, "messages.getCommonChats#0d0a48c4 user_id:InputUser max_id:int limit:int = messages.Chats")]
		public class Messages_GetCommonChats : ITLFunction<Messages_ChatsBase>
		{
			public InputUserBase user_id;
			public int max_id;
			public int limit;
		}

		[TLDef(0xEBA80FF0, "messages.getAllChats#eba80ff0 except_ids:Vector<int> = messages.Chats")]
		public class Messages_GetAllChats : ITLFunction<Messages_ChatsBase> { public int[] except_ids; }

		[TLDef(0xEC22CFCD, "help.setBotUpdatesStatus#ec22cfcd pending_updates_count:int message:string = Bool")]
		public class Help_SetBotUpdatesStatus : ITLFunction<bool>
		{
			public int pending_updates_count;
			public string message;
		}

		[TLDef(0x32CA8F91, "messages.getWebPage#32ca8f91 url:string hash:int = WebPage")]
		public class Messages_GetWebPage : ITLFunction<WebPageBase>
		{
			public string url;
			public int hash;
		}

		[TLDef(0xA731E257, "messages.toggleDialogPin#a731e257 flags:# pinned:flags.0?true peer:InputDialogPeer = Bool")]
		public class Messages_ToggleDialogPin : ITLFunction<bool>
		{
			[Flags] public enum Flags { pinned = 0x1 }
			public Flags flags;
			public InputDialogPeerBase peer;
		}

		[TLDef(0x3B1ADF37, "messages.reorderPinnedDialogs#3b1adf37 flags:# force:flags.0?true folder_id:int order:Vector<InputDialogPeer> = Bool")]
		public class Messages_ReorderPinnedDialogs : ITLFunction<bool>
		{
			[Flags] public enum Flags { force = 0x1 }
			public Flags flags;
			public int folder_id;
			public InputDialogPeerBase[] order;
		}

		[TLDef(0xD6B94DF2, "messages.getPinnedDialogs#d6b94df2 folder_id:int = messages.PeerDialogs")]
		public class Messages_GetPinnedDialogs : ITLFunction<Messages_PeerDialogs> { public int folder_id; }

		[TLDef(0xAA2769ED, "bots.sendCustomRequest#aa2769ed custom_method:string params:DataJSON = DataJSON")]
		public class Bots_SendCustomRequest : ITLFunction<DataJSON>
		{
			public string custom_method;
			public DataJSON params_;
		}

		[TLDef(0xE6213F4D, "bots.answerWebhookJSONQuery#e6213f4d query_id:long data:DataJSON = Bool")]
		public class Bots_AnswerWebhookJSONQuery : ITLFunction<bool>
		{
			public long query_id;
			public DataJSON data;
		}

		[TLDef(0x24E6818D, "upload.getWebFile#24e6818d location:InputWebFileLocation offset:int limit:int = upload.WebFile")]
		public class Upload_GetWebFile : ITLFunction<Upload_WebFile>
		{
			public InputWebFileLocationBase location;
			public int offset;
			public int limit;
		}

		[TLDef(0x99F09745, "payments.getPaymentForm#99f09745 msg_id:int = payments.PaymentForm")]
		public class Payments_GetPaymentForm : ITLFunction<Payments_PaymentForm> { public int msg_id; }

		[TLDef(0xA092A980, "payments.getPaymentReceipt#a092a980 msg_id:int = payments.PaymentReceipt")]
		public class Payments_GetPaymentReceipt : ITLFunction<Payments_PaymentReceipt> { public int msg_id; }

		[TLDef(0x770A8E74, "payments.validateRequestedInfo#770a8e74 flags:# save:flags.0?true msg_id:int info:PaymentRequestedInfo = payments.ValidatedRequestedInfo")]
		public class Payments_ValidateRequestedInfo : ITLFunction<Payments_ValidatedRequestedInfo>
		{
			[Flags] public enum Flags { save = 0x1 }
			public Flags flags;
			public int msg_id;
			public PaymentRequestedInfo info;
		}

		[TLDef(0x2B8879B3, "payments.sendPaymentForm#2b8879b3 flags:# msg_id:int requested_info_id:flags.0?string shipping_option_id:flags.1?string credentials:InputPaymentCredentials = payments.PaymentResult")]
		public class Payments_SendPaymentForm : ITLFunction<Payments_PaymentResultBase>
		{
			[Flags] public enum Flags { has_requested_info_id = 0x1, has_shipping_option_id = 0x2 }
			public Flags flags;
			public int msg_id;
			[IfFlag(0)] public string requested_info_id;
			[IfFlag(1)] public string shipping_option_id;
			public InputPaymentCredentialsBase credentials;
		}

		[TLDef(0x449E0B51, "account.getTmpPassword#449e0b51 password:InputCheckPasswordSRP period:int = account.TmpPassword")]
		public class Account_GetTmpPassword : ITLFunction<Account_TmpPassword>
		{
			public InputCheckPasswordSRPBase password;
			public int period;
		}

		[TLDef(0x227D824B, "payments.getSavedInfo#227d824b = payments.SavedInfo")]
		public class Payments_GetSavedInfo : ITLFunction<Payments_SavedInfo> { }

		[TLDef(0xD83D70C1, "payments.clearSavedInfo#d83d70c1 flags:# credentials:flags.0?true info:flags.1?true = Bool")]
		public class Payments_ClearSavedInfo : ITLFunction<bool>
		{
			[Flags] public enum Flags { credentials = 0x1, info = 0x2 }
			public Flags flags;
		}

		[TLDef(0xE5F672FA, "messages.setBotShippingResults#e5f672fa flags:# query_id:long error:flags.0?string shipping_options:flags.1?Vector<ShippingOption> = Bool")]
		public class Messages_SetBotShippingResults : ITLFunction<bool>
		{
			[Flags] public enum Flags { has_error = 0x1, has_shipping_options = 0x2 }
			public Flags flags;
			public long query_id;
			[IfFlag(0)] public string error;
			[IfFlag(1)] public ShippingOption[] shipping_options;
		}

		[TLDef(0x9C2DD95, "messages.setBotPrecheckoutResults#09c2dd95 flags:# success:flags.1?true query_id:long error:flags.0?string = Bool")]
		public class Messages_SetBotPrecheckoutResults : ITLFunction<bool>
		{
			[Flags] public enum Flags { has_error = 0x1, success = 0x2 }
			public Flags flags;
			public long query_id;
			[IfFlag(0)] public string error;
		}

		[TLDef(0xF1036780, "stickers.createStickerSet#f1036780 flags:# masks:flags.0?true animated:flags.1?true user_id:InputUser title:string short_name:string thumb:flags.2?InputDocument stickers:Vector<InputStickerSetItem> = messages.StickerSet")]
		public class Stickers_CreateStickerSet : ITLFunction<Messages_StickerSet>
		{
			[Flags] public enum Flags { masks = 0x1, animated = 0x2, has_thumb = 0x4 }
			public Flags flags;
			public InputUserBase user_id;
			public string title;
			public string short_name;
			[IfFlag(2)] public InputDocumentBase thumb;
			public InputStickerSetItem[] stickers;
		}

		[TLDef(0xF7760F51, "stickers.removeStickerFromSet#f7760f51 sticker:InputDocument = messages.StickerSet")]
		public class Stickers_RemoveStickerFromSet : ITLFunction<Messages_StickerSet> { public InputDocumentBase sticker; }

		[TLDef(0xFFB6D4CA, "stickers.changeStickerPosition#ffb6d4ca sticker:InputDocument position:int = messages.StickerSet")]
		public class Stickers_ChangeStickerPosition : ITLFunction<Messages_StickerSet>
		{
			public InputDocumentBase sticker;
			public int position;
		}

		[TLDef(0x8653FEBE, "stickers.addStickerToSet#8653febe stickerset:InputStickerSet sticker:InputStickerSetItem = messages.StickerSet")]
		public class Stickers_AddStickerToSet : ITLFunction<Messages_StickerSet>
		{
			public InputStickerSet stickerset;
			public InputStickerSetItem sticker;
		}

		[TLDef(0x519BC2B1, "messages.uploadMedia#519bc2b1 peer:InputPeer media:InputMedia = MessageMedia")]
		public class Messages_UploadMedia : ITLFunction<MessageMedia>
		{
			public InputPeer peer;
			public InputMedia media;
		}

		[TLDef(0x55451FA9, "phone.getCallConfig#55451fa9 = DataJSON")]
		public class Phone_GetCallConfig : ITLFunction<DataJSON> { }

		[TLDef(0x42FF96ED, "phone.requestCall#42ff96ed flags:# video:flags.0?true user_id:InputUser random_id:int g_a_hash:bytes protocol:PhoneCallProtocol = phone.PhoneCall")]
		public class Phone_RequestCall : ITLFunction<Phone_PhoneCall>
		{
			[Flags] public enum Flags { video = 0x1 }
			public Flags flags;
			public InputUserBase user_id;
			public int random_id;
			public byte[] g_a_hash;
			public PhoneCallProtocol protocol;
		}

		[TLDef(0x3BD2B4A0, "phone.acceptCall#3bd2b4a0 peer:InputPhoneCall g_b:bytes protocol:PhoneCallProtocol = phone.PhoneCall")]
		public class Phone_AcceptCall : ITLFunction<Phone_PhoneCall>
		{
			public InputPhoneCall peer;
			public byte[] g_b;
			public PhoneCallProtocol protocol;
		}

		[TLDef(0x2EFE1722, "phone.confirmCall#2efe1722 peer:InputPhoneCall g_a:bytes key_fingerprint:long protocol:PhoneCallProtocol = phone.PhoneCall")]
		public class Phone_ConfirmCall : ITLFunction<Phone_PhoneCall>
		{
			public InputPhoneCall peer;
			public byte[] g_a;
			public long key_fingerprint;
			public PhoneCallProtocol protocol;
		}

		[TLDef(0x17D54F61, "phone.receivedCall#17d54f61 peer:InputPhoneCall = Bool")]
		public class Phone_ReceivedCall : ITLFunction<bool> { public InputPhoneCall peer; }

		[TLDef(0xB2CBC1C0, "phone.discardCall#b2cbc1c0 flags:# video:flags.0?true peer:InputPhoneCall duration:int reason:PhoneCallDiscardReason connection_id:long = Updates")]
		public class Phone_DiscardCall : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { video = 0x1 }
			public Flags flags;
			public InputPhoneCall peer;
			public int duration;
			public PhoneCallDiscardReason reason;
			public long connection_id;
		}

		[TLDef(0x59EAD627, "phone.setCallRating#59ead627 flags:# user_initiative:flags.0?true peer:InputPhoneCall rating:int comment:string = Updates")]
		public class Phone_SetCallRating : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { user_initiative = 0x1 }
			public Flags flags;
			public InputPhoneCall peer;
			public int rating;
			public string comment;
		}

		[TLDef(0x277ADD7E, "phone.saveCallDebug#277add7e peer:InputPhoneCall debug:DataJSON = Bool")]
		public class Phone_SaveCallDebug : ITLFunction<bool>
		{
			public InputPhoneCall peer;
			public DataJSON debug;
		}

		[TLDef(0x2000BCC3, "upload.getCdnFile#2000bcc3 file_token:bytes offset:int limit:int = upload.CdnFile")]
		public class Upload_GetCdnFile : ITLFunction<Upload_CdnFileBase>
		{
			public byte[] file_token;
			public int offset;
			public int limit;
		}

		[TLDef(0x9B2754A8, "upload.reuploadCdnFile#9b2754a8 file_token:bytes request_token:bytes = Vector<FileHash>")]
		public class Upload_ReuploadCdnFile : ITLFunction<FileHash[]>
		{
			public byte[] file_token;
			public byte[] request_token;
		}

		[TLDef(0x52029342, "help.getCdnConfig#52029342 = CdnConfig")]
		public class Help_GetCdnConfig : ITLFunction<CdnConfig> { }

		[TLDef(0xF2F2330A, "langpack.getLangPack#f2f2330a lang_pack:string lang_code:string = LangPackDifference")]
		public class Langpack_GetLangPack : ITLFunction<LangPackDifference>
		{
			public string lang_pack;
			public string lang_code;
		}

		[TLDef(0xEFEA3803, "langpack.getStrings#efea3803 lang_pack:string lang_code:string keys:Vector<string> = Vector<LangPackString>")]
		public class Langpack_GetStrings : ITLFunction<LangPackStringBase[]>
		{
			public string lang_pack;
			public string lang_code;
			public string[] keys;
		}

		[TLDef(0xCD984AA5, "langpack.getDifference#cd984aa5 lang_pack:string lang_code:string from_version:int = LangPackDifference")]
		public class Langpack_GetDifference : ITLFunction<LangPackDifference>
		{
			public string lang_pack;
			public string lang_code;
			public int from_version;
		}

		[TLDef(0x42C6978F, "langpack.getLanguages#42c6978f lang_pack:string = Vector<LangPackLanguage>")]
		public class Langpack_GetLanguages : ITLFunction<LangPackLanguage[]> { public string lang_pack; }

		[TLDef(0x72796912, "channels.editBanned#72796912 channel:InputChannel user_id:InputUser banned_rights:ChatBannedRights = Updates")]
		public class Channels_EditBanned : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public InputUserBase user_id;
			public ChatBannedRights banned_rights;
		}

		[TLDef(0x33DDF480, "channels.getAdminLog#33ddf480 flags:# channel:InputChannel q:string events_filter:flags.0?ChannelAdminLogEventsFilter admins:flags.1?Vector<InputUser> max_id:long min_id:long limit:int = channels.AdminLogResults")]
		public class Channels_GetAdminLog : ITLFunction<Channels_AdminLogResults>
		{
			[Flags] public enum Flags { has_events_filter = 0x1, has_admins = 0x2 }
			public Flags flags;
			public InputChannelBase channel;
			public string q;
			[IfFlag(0)] public ChannelAdminLogEventsFilter events_filter;
			[IfFlag(1)] public InputUserBase[] admins;
			public long max_id;
			public long min_id;
			public int limit;
		}

		[TLDef(0x4DA54231, "upload.getCdnFileHashes#4da54231 file_token:bytes offset:int = Vector<FileHash>")]
		public class Upload_GetCdnFileHashes : ITLFunction<FileHash[]>
		{
			public byte[] file_token;
			public int offset;
		}

		[TLDef(0xC97DF020, "messages.sendScreenshotNotification#c97df020 peer:InputPeer reply_to_msg_id:int random_id:long = Updates")]
		public class Messages_SendScreenshotNotification : ITLFunction<UpdatesBase>
		{
			public InputPeer peer;
			public int reply_to_msg_id;
			public long random_id;
		}

		[TLDef(0xEA8CA4F9, "channels.setStickers#ea8ca4f9 channel:InputChannel stickerset:InputStickerSet = Bool")]
		public class Channels_SetStickers : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public InputStickerSet stickerset;
		}

		[TLDef(0x21CE0B0E, "messages.getFavedStickers#21ce0b0e hash:int = messages.FavedStickers")]
		public class Messages_GetFavedStickers : ITLFunction<Messages_FavedStickersBase> { public int hash; }

		[TLDef(0xB9FFC55B, "messages.faveSticker#b9ffc55b id:InputDocument unfave:Bool = Bool")]
		public class Messages_FaveSticker : ITLFunction<bool>
		{
			public InputDocumentBase id;
			public bool unfave;
		}

		[TLDef(0xEAB5DC38, "channels.readMessageContents#eab5dc38 channel:InputChannel id:Vector<int> = Bool")]
		public class Channels_ReadMessageContents : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public int[] id;
		}

		[TLDef(0x879537F1, "contacts.resetSaved#879537f1 = Bool")]
		public class Contacts_ResetSaved : ITLFunction<bool> { }

		[TLDef(0x46578472, "messages.getUnreadMentions#46578472 peer:InputPeer offset_id:int add_offset:int limit:int max_id:int min_id:int = messages.Messages")]
		public class Messages_GetUnreadMentions : ITLFunction<Messages_MessagesBase>
		{
			public InputPeer peer;
			public int offset_id;
			public int add_offset;
			public int limit;
			public int max_id;
			public int min_id;
		}

		[TLDef(0xAF369D42, "channels.deleteHistory#af369d42 channel:InputChannel max_id:int = Bool")]
		public class Channels_DeleteHistory : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public int max_id;
		}

		[TLDef(0x3DC0F114, "help.getRecentMeUrls#3dc0f114 referer:string = help.RecentMeUrls")]
		public class Help_GetRecentMeUrls : ITLFunction<Help_RecentMeUrls> { public string referer; }

		[TLDef(0xEABBB94C, "channels.togglePreHistoryHidden#eabbb94c channel:InputChannel enabled:Bool = Updates")]
		public class Channels_TogglePreHistoryHidden : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public bool enabled;
		}

		[TLDef(0xF0189D3, "messages.readMentions#0f0189d3 peer:InputPeer = messages.AffectedHistory")]
		public class Messages_ReadMentions : ITLFunction<Messages_AffectedHistory> { public InputPeer peer; }

		[TLDef(0xBBC45B09, "messages.getRecentLocations#bbc45b09 peer:InputPeer limit:int hash:int = messages.Messages")]
		public class Messages_GetRecentLocations : ITLFunction<Messages_MessagesBase>
		{
			public InputPeer peer;
			public int limit;
			public int hash;
		}

		[TLDef(0xCC0110CB, "messages.sendMultiMedia#cc0110cb flags:# silent:flags.5?true background:flags.6?true clear_draft:flags.7?true peer:InputPeer reply_to_msg_id:flags.0?int multi_media:Vector<InputSingleMedia> schedule_date:flags.10?int = Updates")]
		public class Messages_SendMultiMedia : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { has_reply_to_msg_id = 0x1, silent = 0x20, background = 0x40, clear_draft = 0x80, 
				has_schedule_date = 0x400 }
			public Flags flags;
			public InputPeer peer;
			[IfFlag(0)] public int reply_to_msg_id;
			public InputSingleMedia[] multi_media;
			[IfFlag(10)] public DateTime schedule_date;
		}

		[TLDef(0x5057C497, "messages.uploadEncryptedFile#5057c497 peer:InputEncryptedChat file:InputEncryptedFile = EncryptedFile")]
		public class Messages_UploadEncryptedFile : ITLFunction<EncryptedFileBase>
		{
			public InputEncryptedChat peer;
			public InputEncryptedFileBase file;
		}

		[TLDef(0x182E6D6F, "account.getWebAuthorizations#182e6d6f = account.WebAuthorizations")]
		public class Account_GetWebAuthorizations : ITLFunction<Account_WebAuthorizations> { }

		[TLDef(0x2D01B9EF, "account.resetWebAuthorization#2d01b9ef hash:long = Bool")]
		public class Account_ResetWebAuthorization : ITLFunction<bool> { public long hash; }

		[TLDef(0x682D2594, "account.resetWebAuthorizations#682d2594 = Bool")]
		public class Account_ResetWebAuthorizations : ITLFunction<bool> { }

		[TLDef(0xC2B7D08B, "messages.searchStickerSets#c2b7d08b flags:# exclude_featured:flags.0?true q:string hash:int = messages.FoundStickerSets")]
		public class Messages_SearchStickerSets : ITLFunction<Messages_FoundStickerSetsBase>
		{
			[Flags] public enum Flags { exclude_featured = 0x1 }
			public Flags flags;
			public string q;
			public int hash;
		}

		[TLDef(0xC7025931, "upload.getFileHashes#c7025931 location:InputFileLocation offset:int = Vector<FileHash>")]
		public class Upload_GetFileHashes : ITLFunction<FileHash[]>
		{
			public InputFileLocationBase location;
			public int offset;
		}

		[TLDef(0x2CA51FD1, "help.getTermsOfServiceUpdate#2ca51fd1 = help.TermsOfServiceUpdate")]
		public class Help_GetTermsOfServiceUpdate : ITLFunction<Help_TermsOfServiceUpdateBase> { }

		[TLDef(0xEE72F79A, "help.acceptTermsOfService#ee72f79a id:DataJSON = Bool")]
		public class Help_AcceptTermsOfService : ITLFunction<bool> { public DataJSON id; }

		[TLDef(0xB288BC7D, "account.getAllSecureValues#b288bc7d = Vector<SecureValue>")]
		public class Account_GetAllSecureValues : ITLFunction<SecureValue[]> { }

		[TLDef(0x73665BC2, "account.getSecureValue#73665bc2 types:Vector<SecureValueType> = Vector<SecureValue>")]
		public class Account_GetSecureValue : ITLFunction<SecureValue[]> { public SecureValueType[] types; }

		[TLDef(0x899FE31D, "account.saveSecureValue#899fe31d value:InputSecureValue secure_secret_id:long = SecureValue")]
		public class Account_SaveSecureValue : ITLFunction<SecureValue>
		{
			public InputSecureValue value;
			public long secure_secret_id;
		}

		[TLDef(0xB880BC4B, "account.deleteSecureValue#b880bc4b types:Vector<SecureValueType> = Bool")]
		public class Account_DeleteSecureValue : ITLFunction<bool> { public SecureValueType[] types; }

		[TLDef(0x90C894B5, "users.setSecureValueErrors#90c894b5 id:InputUser errors:Vector<SecureValueError> = Bool")]
		public class Users_SetSecureValueErrors : ITLFunction<bool>
		{
			public InputUserBase id;
			public SecureValueErrorBase[] errors;
		}

		[TLDef(0xB86BA8E1, "account.getAuthorizationForm#b86ba8e1 bot_id:int scope:string public_key:string = account.AuthorizationForm")]
		public class Account_GetAuthorizationForm : ITLFunction<Account_AuthorizationForm>
		{
			public int bot_id;
			public string scope;
			public string public_key;
		}

		[TLDef(0xE7027C94, "account.acceptAuthorization#e7027c94 bot_id:int scope:string public_key:string value_hashes:Vector<SecureValueHash> credentials:SecureCredentialsEncrypted = Bool")]
		public class Account_AcceptAuthorization : ITLFunction<bool>
		{
			public int bot_id;
			public string scope;
			public string public_key;
			public SecureValueHash[] value_hashes;
			public SecureCredentialsEncrypted credentials;
		}

		[TLDef(0xA5A356F9, "account.sendVerifyPhoneCode#a5a356f9 phone_number:string settings:CodeSettings = auth.SentCode")]
		public class Account_SendVerifyPhoneCode : ITLFunction<Auth_SentCode>
		{
			public string phone_number;
			public CodeSettings settings;
		}

		[TLDef(0x4DD3A7F6, "account.verifyPhone#4dd3a7f6 phone_number:string phone_code_hash:string phone_code:string = Bool")]
		public class Account_VerifyPhone : ITLFunction<bool>
		{
			public string phone_number;
			public string phone_code_hash;
			public string phone_code;
		}

		[TLDef(0x7011509F, "account.sendVerifyEmailCode#7011509f email:string = account.SentEmailCode")]
		public class Account_SendVerifyEmailCode : ITLFunction<Account_SentEmailCode> { public string email; }

		[TLDef(0xECBA39DB, "account.verifyEmail#ecba39db email:string code:string = Bool")]
		public class Account_VerifyEmail : ITLFunction<bool>
		{
			public string email;
			public string code;
		}

		[TLDef(0x3FEDC75F, "help.getDeepLinkInfo#3fedc75f path:string = help.DeepLinkInfo")]
		public class Help_GetDeepLinkInfo : ITLFunction<Help_DeepLinkInfoBase> { public string path; }

		[TLDef(0x82F1E39F, "contacts.getSaved#82f1e39f = Vector<SavedContact>")]
		public class Contacts_GetSaved : ITLFunction<SavedContact[]> { }

		[TLDef(0x8341ECC0, "channels.getLeftChannels#8341ecc0 offset:int = messages.Chats")]
		public class Channels_GetLeftChannels : ITLFunction<Messages_ChatsBase> { public int offset; }

		[TLDef(0xF05B4804, "account.initTakeoutSession#f05b4804 flags:# contacts:flags.0?true message_users:flags.1?true message_chats:flags.2?true message_megagroups:flags.3?true message_channels:flags.4?true files:flags.5?true file_max_size:flags.5?int = account.Takeout")]
		public class Account_InitTakeoutSession : ITLFunction<Account_Takeout>
		{
			[Flags] public enum Flags { contacts = 0x1, message_users = 0x2, message_chats = 0x4, message_megagroups = 0x8, 
				message_channels = 0x10, files = 0x20 }
			public Flags flags;
			[IfFlag(5)] public int file_max_size;
		}

		[TLDef(0x1D2652EE, "account.finishTakeoutSession#1d2652ee flags:# success:flags.0?true = Bool")]
		public class Account_FinishTakeoutSession : ITLFunction<bool>
		{
			[Flags] public enum Flags { success = 0x1 }
			public Flags flags;
		}

		[TLDef(0x1CFF7E08, "messages.getSplitRanges#1cff7e08 = Vector<MessageRange>")]
		public class Messages_GetSplitRanges : ITLFunction<MessageRange[]> { }

		[TLDef(0x365275F2, "invokeWithMessagesRange#365275f2 {X:Type} range:MessageRange query:!X = X")]
		public class InvokeWithMessagesRange<X> : ITLFunction<X>
		{
			public MessageRange range;
			public ITLFunction<X> query;
		}

		[TLDef(0xACA9FD2E, "invokeWithTakeout#aca9fd2e {X:Type} takeout_id:long query:!X = X")]
		public class InvokeWithTakeout<X> : ITLFunction<X>
		{
			public long takeout_id;
			public ITLFunction<X> query;
		}

		[TLDef(0xC286D98F, "messages.markDialogUnread#c286d98f flags:# unread:flags.0?true peer:InputDialogPeer = Bool")]
		public class Messages_MarkDialogUnread : ITLFunction<bool>
		{
			[Flags] public enum Flags { unread = 0x1 }
			public Flags flags;
			public InputDialogPeerBase peer;
		}

		[TLDef(0x22E24E22, "messages.getDialogUnreadMarks#22e24e22 = Vector<DialogPeer>")]
		public class Messages_GetDialogUnreadMarks : ITLFunction<DialogPeerBase[]> { }

		[TLDef(0x8514BDDA, "contacts.toggleTopPeers#8514bdda enabled:Bool = Bool")]
		public class Contacts_ToggleTopPeers : ITLFunction<bool> { public bool enabled; }

		[TLDef(0x7E58EE9C, "messages.clearAllDrafts#7e58ee9c = Bool")]
		public class Messages_ClearAllDrafts : ITLFunction<bool> { }

		[TLDef(0x98914110, "help.getAppConfig#98914110 = JSONValue")]
		public class Help_GetAppConfig : ITLFunction<JSONValue> { }

		[TLDef(0x6F02F748, "help.saveAppLog#6f02f748 events:Vector<InputAppEvent> = Bool")]
		public class Help_SaveAppLog : ITLFunction<bool> { public InputAppEvent[] events; }

		[TLDef(0xC661AD08, "help.getPassportConfig#c661ad08 hash:int = help.PassportConfig")]
		public class Help_GetPassportConfig : ITLFunction<Help_PassportConfigBase> { public int hash; }

		[TLDef(0x6A596502, "langpack.getLanguage#6a596502 lang_pack:string lang_code:string = LangPackLanguage")]
		public class Langpack_GetLanguage : ITLFunction<LangPackLanguage>
		{
			public string lang_pack;
			public string lang_code;
		}

		[TLDef(0xD2AAF7EC, "messages.updatePinnedMessage#d2aaf7ec flags:# silent:flags.0?true unpin:flags.1?true pm_oneside:flags.2?true peer:InputPeer id:int = Updates")]
		public class Messages_UpdatePinnedMessage : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { silent = 0x1, unpin = 0x2, pm_oneside = 0x4 }
			public Flags flags;
			public InputPeer peer;
			public int id;
		}

		[TLDef(0x8FDF1920, "account.confirmPasswordEmail#8fdf1920 code:string = Bool")]
		public class Account_ConfirmPasswordEmail : ITLFunction<bool> { public string code; }

		[TLDef(0x7A7F2A15, "account.resendPasswordEmail#7a7f2a15 = Bool")]
		public class Account_ResendPasswordEmail : ITLFunction<bool> { }

		[TLDef(0xC1CBD5B6, "account.cancelPasswordEmail#c1cbd5b6 = Bool")]
		public class Account_CancelPasswordEmail : ITLFunction<bool> { }

		[TLDef(0xD360E72C, "help.getSupportName#d360e72c = help.SupportName")]
		public class Help_GetSupportName : ITLFunction<Help_SupportName> { }

		[TLDef(0x38A08D3, "help.getUserInfo#038a08d3 user_id:InputUser = help.UserInfo")]
		public class Help_GetUserInfo : ITLFunction<Help_UserInfoBase> { public InputUserBase user_id; }

		[TLDef(0x66B91B70, "help.editUserInfo#66b91b70 user_id:InputUser message:string entities:Vector<MessageEntity> = help.UserInfo")]
		public class Help_EditUserInfo : ITLFunction<Help_UserInfoBase>
		{
			public InputUserBase user_id;
			public string message;
			public MessageEntity[] entities;
		}

		[TLDef(0x9F07C728, "account.getContactSignUpNotification#9f07c728 = Bool")]
		public class Account_GetContactSignUpNotification : ITLFunction<bool> { }

		[TLDef(0xCFF43F61, "account.setContactSignUpNotification#cff43f61 silent:Bool = Bool")]
		public class Account_SetContactSignUpNotification : ITLFunction<bool> { public bool silent; }

		[TLDef(0x53577479, "account.getNotifyExceptions#53577479 flags:# compare_sound:flags.1?true peer:flags.0?InputNotifyPeer = Updates")]
		public class Account_GetNotifyExceptions : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { has_peer = 0x1, compare_sound = 0x2 }
			public Flags flags;
			[IfFlag(0)] public InputNotifyPeerBase peer;
		}

		[TLDef(0x10EA6184, "messages.sendVote#10ea6184 peer:InputPeer msg_id:int options:Vector<bytes> = Updates")]
		public class Messages_SendVote : ITLFunction<UpdatesBase>
		{
			public InputPeer peer;
			public int msg_id;
			public byte[][] options;
		}

		[TLDef(0x73BB643B, "messages.getPollResults#73bb643b peer:InputPeer msg_id:int = Updates")]
		public class Messages_GetPollResults : ITLFunction<UpdatesBase>
		{
			public InputPeer peer;
			public int msg_id;
		}

		[TLDef(0x6E2BE050, "messages.getOnlines#6e2be050 peer:InputPeer = ChatOnlines")]
		public class Messages_GetOnlines : ITLFunction<ChatOnlines> { public InputPeer peer; }

		[TLDef(0x812C2AE6, "messages.getStatsURL#812c2ae6 flags:# dark:flags.0?true peer:InputPeer params:string = StatsURL")]
		public class Messages_GetStatsURL : ITLFunction<StatsURL>
		{
			[Flags] public enum Flags { dark = 0x1 }
			public Flags flags;
			public InputPeer peer;
			public string params_;
		}

		[TLDef(0xDEF60797, "messages.editChatAbout#def60797 peer:InputPeer about:string = Bool")]
		public class Messages_EditChatAbout : ITLFunction<bool>
		{
			public InputPeer peer;
			public string about;
		}

		[TLDef(0xA5866B41, "messages.editChatDefaultBannedRights#a5866b41 peer:InputPeer banned_rights:ChatBannedRights = Updates")]
		public class Messages_EditChatDefaultBannedRights : ITLFunction<UpdatesBase>
		{
			public InputPeer peer;
			public ChatBannedRights banned_rights;
		}

		[TLDef(0xFC8DDBEA, "account.getWallPaper#fc8ddbea wallpaper:InputWallPaper = WallPaper")]
		public class Account_GetWallPaper : ITLFunction<WallPaperBase> { public InputWallPaperBase wallpaper; }

		[TLDef(0xDD853661, "account.uploadWallPaper#dd853661 file:InputFile mime_type:string settings:WallPaperSettings = WallPaper")]
		public class Account_UploadWallPaper : ITLFunction<WallPaperBase>
		{
			public InputFileBase file;
			public string mime_type;
			public WallPaperSettings settings;
		}

		[TLDef(0x6C5A5B37, "account.saveWallPaper#6c5a5b37 wallpaper:InputWallPaper unsave:Bool settings:WallPaperSettings = Bool")]
		public class Account_SaveWallPaper : ITLFunction<bool>
		{
			public InputWallPaperBase wallpaper;
			public bool unsave;
			public WallPaperSettings settings;
		}

		[TLDef(0xFEED5769, "account.installWallPaper#feed5769 wallpaper:InputWallPaper settings:WallPaperSettings = Bool")]
		public class Account_InstallWallPaper : ITLFunction<bool>
		{
			public InputWallPaperBase wallpaper;
			public WallPaperSettings settings;
		}

		[TLDef(0xBB3B9804, "account.resetWallPapers#bb3b9804 = Bool")]
		public class Account_ResetWallPapers : ITLFunction<bool> { }

		[TLDef(0x56DA0B3F, "account.getAutoDownloadSettings#56da0b3f = account.AutoDownloadSettings")]
		public class Account_GetAutoDownloadSettings : ITLFunction<Account_AutoDownloadSettings> { }

		[TLDef(0x76F36233, "account.saveAutoDownloadSettings#76f36233 flags:# low:flags.0?true high:flags.1?true settings:AutoDownloadSettings = Bool")]
		public class Account_SaveAutoDownloadSettings : ITLFunction<bool>
		{
			[Flags] public enum Flags { low = 0x1, high = 0x2 }
			public Flags flags;
			public AutoDownloadSettings settings;
		}

		[TLDef(0x35A0E062, "messages.getEmojiKeywords#35a0e062 lang_code:string = EmojiKeywordsDifference")]
		public class Messages_GetEmojiKeywords : ITLFunction<EmojiKeywordsDifference> { public string lang_code; }

		[TLDef(0x1508B6AF, "messages.getEmojiKeywordsDifference#1508b6af lang_code:string from_version:int = EmojiKeywordsDifference")]
		public class Messages_GetEmojiKeywordsDifference : ITLFunction<EmojiKeywordsDifference>
		{
			public string lang_code;
			public int from_version;
		}

		[TLDef(0x4E9963B2, "messages.getEmojiKeywordsLanguages#4e9963b2 lang_codes:Vector<string> = Vector<EmojiLanguage>")]
		public class Messages_GetEmojiKeywordsLanguages : ITLFunction<EmojiLanguage[]> { public string[] lang_codes; }

		[TLDef(0xD5B10C26, "messages.getEmojiURL#d5b10c26 lang_code:string = EmojiURL")]
		public class Messages_GetEmojiURL : ITLFunction<EmojiURL> { public string lang_code; }

		[TLDef(0x6847D0AB, "folders.editPeerFolders#6847d0ab folder_peers:Vector<InputFolderPeer> = Updates")]
		public class Folders_EditPeerFolders : ITLFunction<UpdatesBase> { public InputFolderPeer[] folder_peers; }

		[TLDef(0x1C295881, "folders.deleteFolder#1c295881 folder_id:int = Updates")]
		public class Folders_DeleteFolder : ITLFunction<UpdatesBase> { public int folder_id; }

		[TLDef(0x732EEF00, "messages.getSearchCounters#732eef00 peer:InputPeer filters:Vector<MessagesFilter> = Vector<messages.SearchCounter>")]
		public class Messages_GetSearchCounters : ITLFunction<Messages_SearchCounter[]>
		{
			public InputPeer peer;
			public MessagesFilter[] filters;
		}

		[TLDef(0xF5DAD378, "channels.getGroupsForDiscussion#f5dad378 = messages.Chats")]
		public class Channels_GetGroupsForDiscussion : ITLFunction<Messages_ChatsBase> { }

		[TLDef(0x40582BB2, "channels.setDiscussionGroup#40582bb2 broadcast:InputChannel group:InputChannel = Bool")]
		public class Channels_SetDiscussionGroup : ITLFunction<bool>
		{
			public InputChannelBase broadcast;
			public InputChannelBase group;
		}

		[TLDef(0xE33F5613, "messages.requestUrlAuth#e33f5613 peer:InputPeer msg_id:int button_id:int = UrlAuthResult")]
		public class Messages_RequestUrlAuth : ITLFunction<UrlAuthResult>
		{
			public InputPeer peer;
			public int msg_id;
			public int button_id;
		}

		[TLDef(0xF729EA98, "messages.acceptUrlAuth#f729ea98 flags:# write_allowed:flags.0?true peer:InputPeer msg_id:int button_id:int = UrlAuthResult")]
		public class Messages_AcceptUrlAuth : ITLFunction<UrlAuthResult>
		{
			[Flags] public enum Flags { write_allowed = 0x1 }
			public Flags flags;
			public InputPeer peer;
			public int msg_id;
			public int button_id;
		}

		[TLDef(0x4FACB138, "messages.hidePeerSettingsBar#4facb138 peer:InputPeer = Bool")]
		public class Messages_HidePeerSettingsBar : ITLFunction<bool> { public InputPeer peer; }

		[TLDef(0xE8F463D0, "contacts.addContact#e8f463d0 flags:# add_phone_privacy_exception:flags.0?true id:InputUser first_name:string last_name:string phone:string = Updates")]
		public class Contacts_AddContact : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { add_phone_privacy_exception = 0x1 }
			public Flags flags;
			public InputUserBase id;
			public string first_name;
			public string last_name;
			public string phone;
		}

		[TLDef(0xF831A20F, "contacts.acceptContact#f831a20f id:InputUser = Updates")]
		public class Contacts_AcceptContact : ITLFunction<UpdatesBase> { public InputUserBase id; }

		[TLDef(0x8F38CD1F, "channels.editCreator#8f38cd1f channel:InputChannel user_id:InputUser password:InputCheckPasswordSRP = Updates")]
		public class Channels_EditCreator : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public InputUserBase user_id;
			public InputCheckPasswordSRPBase password;
		}

		[TLDef(0xD348BC44, "contacts.getLocated#d348bc44 flags:# background:flags.1?true geo_point:InputGeoPoint self_expires:flags.0?int = Updates")]
		public class Contacts_GetLocated : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { has_self_expires = 0x1, background = 0x2 }
			public Flags flags;
			public InputGeoPointBase geo_point;
			[IfFlag(0)] public int self_expires;
		}

		[TLDef(0x58E63F6D, "channels.editLocation#58e63f6d channel:InputChannel geo_point:InputGeoPoint address:string = Bool")]
		public class Channels_EditLocation : ITLFunction<bool>
		{
			public InputChannelBase channel;
			public InputGeoPointBase geo_point;
			public string address;
		}

		[TLDef(0xEDD49EF0, "channels.toggleSlowMode#edd49ef0 channel:InputChannel seconds:int = Updates")]
		public class Channels_ToggleSlowMode : ITLFunction<UpdatesBase>
		{
			public InputChannelBase channel;
			public int seconds;
		}

		[TLDef(0xE2C2685B, "messages.getScheduledHistory#e2c2685b peer:InputPeer hash:int = messages.Messages")]
		public class Messages_GetScheduledHistory : ITLFunction<Messages_MessagesBase>
		{
			public InputPeer peer;
			public int hash;
		}

		[TLDef(0xBDBB0464, "messages.getScheduledMessages#bdbb0464 peer:InputPeer id:Vector<int> = messages.Messages")]
		public class Messages_GetScheduledMessages : ITLFunction<Messages_MessagesBase>
		{
			public InputPeer peer;
			public int[] id;
		}

		[TLDef(0xBD38850A, "messages.sendScheduledMessages#bd38850a peer:InputPeer id:Vector<int> = Updates")]
		public class Messages_SendScheduledMessages : ITLFunction<UpdatesBase>
		{
			public InputPeer peer;
			public int[] id;
		}

		[TLDef(0x59AE2B16, "messages.deleteScheduledMessages#59ae2b16 peer:InputPeer id:Vector<int> = Updates")]
		public class Messages_DeleteScheduledMessages : ITLFunction<UpdatesBase>
		{
			public InputPeer peer;
			public int[] id;
		}

		[TLDef(0x1C3DB333, "account.uploadTheme#1c3db333 flags:# file:InputFile thumb:flags.0?InputFile file_name:string mime_type:string = Document")]
		public class Account_UploadTheme : ITLFunction<DocumentBase>
		{
			[Flags] public enum Flags { has_thumb = 0x1 }
			public Flags flags;
			public InputFileBase file;
			[IfFlag(0)] public InputFileBase thumb;
			public string file_name;
			public string mime_type;
		}

		[TLDef(0x8432C21F, "account.createTheme#8432c21f flags:# slug:string title:string document:flags.2?InputDocument settings:flags.3?InputThemeSettings = Theme")]
		public class Account_CreateTheme : ITLFunction<Theme>
		{
			[Flags] public enum Flags { has_document = 0x4, has_settings = 0x8 }
			public Flags flags;
			public string slug;
			public string title;
			[IfFlag(2)] public InputDocumentBase document;
			[IfFlag(3)] public InputThemeSettings settings;
		}

		[TLDef(0x5CB367D5, "account.updateTheme#5cb367d5 flags:# format:string theme:InputTheme slug:flags.0?string title:flags.1?string document:flags.2?InputDocument settings:flags.3?InputThemeSettings = Theme")]
		public class Account_UpdateTheme : ITLFunction<Theme>
		{
			[Flags] public enum Flags { has_slug = 0x1, has_title = 0x2, has_document = 0x4, has_settings = 0x8 }
			public Flags flags;
			public string format;
			public InputThemeBase theme;
			[IfFlag(0)] public string slug;
			[IfFlag(1)] public string title;
			[IfFlag(2)] public InputDocumentBase document;
			[IfFlag(3)] public InputThemeSettings settings;
		}

		[TLDef(0xF257106C, "account.saveTheme#f257106c theme:InputTheme unsave:Bool = Bool")]
		public class Account_SaveTheme : ITLFunction<bool>
		{
			public InputThemeBase theme;
			public bool unsave;
		}

		[TLDef(0x7AE43737, "account.installTheme#7ae43737 flags:# dark:flags.0?true format:flags.1?string theme:flags.1?InputTheme = Bool")]
		public class Account_InstallTheme : ITLFunction<bool>
		{
			[Flags] public enum Flags { dark = 0x1, has_format = 0x2 }
			public Flags flags;
			[IfFlag(1)] public string format;
			[IfFlag(1)] public InputThemeBase theme;
		}

		[TLDef(0x8D9D742B, "account.getTheme#8d9d742b format:string theme:InputTheme document_id:long = Theme")]
		public class Account_GetTheme : ITLFunction<Theme>
		{
			public string format;
			public InputThemeBase theme;
			public long document_id;
		}

		[TLDef(0x285946F8, "account.getThemes#285946f8 format:string hash:int = account.Themes")]
		public class Account_GetThemes : ITLFunction<Account_ThemesBase>
		{
			public string format;
			public int hash;
		}

		[TLDef(0xB1B41517, "auth.exportLoginToken#b1b41517 api_id:int api_hash:string except_ids:Vector<int> = auth.LoginToken")]
		public class Auth_ExportLoginToken : ITLFunction<Auth_LoginTokenBase>
		{
			public int api_id;
			public string api_hash;
			public int[] except_ids;
		}

		[TLDef(0x95AC5CE4, "auth.importLoginToken#95ac5ce4 token:bytes = auth.LoginToken")]
		public class Auth_ImportLoginToken : ITLFunction<Auth_LoginTokenBase> { public byte[] token; }

		[TLDef(0xE894AD4D, "auth.acceptLoginToken#e894ad4d token:bytes = Authorization")]
		public class Auth_AcceptLoginToken : ITLFunction<Authorization> { public byte[] token; }

		[TLDef(0xB574B16B, "account.setContentSettings#b574b16b flags:# sensitive_enabled:flags.0?true = Bool")]
		public class Account_SetContentSettings : ITLFunction<bool>
		{
			[Flags] public enum Flags { sensitive_enabled = 0x1 }
			public Flags flags;
		}

		[TLDef(0x8B9B4DAE, "account.getContentSettings#8b9b4dae = account.ContentSettings")]
		public class Account_GetContentSettings : ITLFunction<Account_ContentSettings> { }

		[TLDef(0x11E831EE, "channels.getInactiveChannels#11e831ee = messages.InactiveChats")]
		public class Channels_GetInactiveChannels : ITLFunction<Messages_InactiveChats> { }

		[TLDef(0x65AD71DC, "account.getMultiWallPapers#65ad71dc wallpapers:Vector<InputWallPaper> = Vector<WallPaper>")]
		public class Account_GetMultiWallPapers : ITLFunction<WallPaperBase[]> { public InputWallPaperBase[] wallpapers; }

		[TLDef(0xB86E380E, "messages.getPollVotes#b86e380e flags:# peer:InputPeer id:int option:flags.0?bytes offset:flags.1?string limit:int = messages.VotesList")]
		public class Messages_GetPollVotes : ITLFunction<Messages_VotesList>
		{
			[Flags] public enum Flags { has_option = 0x1, has_offset = 0x2 }
			public Flags flags;
			public InputPeer peer;
			public int id;
			[IfFlag(0)] public byte[] option;
			[IfFlag(1)] public string offset;
			public int limit;
		}

		[TLDef(0xB5052FEA, "messages.toggleStickerSets#b5052fea flags:# uninstall:flags.0?true archive:flags.1?true unarchive:flags.2?true stickersets:Vector<InputStickerSet> = Bool")]
		public class Messages_ToggleStickerSets : ITLFunction<bool>
		{
			[Flags] public enum Flags { uninstall = 0x1, archive = 0x2, unarchive = 0x4 }
			public Flags flags;
			public InputStickerSet[] stickersets;
		}

		[TLDef(0x2E79D779, "payments.getBankCardData#2e79d779 number:string = payments.BankCardData")]
		public class Payments_GetBankCardData : ITLFunction<Payments_BankCardData> { public string number; }

		[TLDef(0xF19ED96D, "messages.getDialogFilters#f19ed96d = Vector<DialogFilter>")]
		public class Messages_GetDialogFilters : ITLFunction<DialogFilter[]> { }

		[TLDef(0xA29CD42C, "messages.getSuggestedDialogFilters#a29cd42c = Vector<DialogFilterSuggested>")]
		public class Messages_GetSuggestedDialogFilters : ITLFunction<DialogFilterSuggested[]> { }

		[TLDef(0x1AD4A04A, "messages.updateDialogFilter#1ad4a04a flags:# id:int filter:flags.0?DialogFilter = Bool")]
		public class Messages_UpdateDialogFilter : ITLFunction<bool>
		{
			[Flags] public enum Flags { has_filter = 0x1 }
			public Flags flags;
			public int id;
			[IfFlag(0)] public DialogFilter filter;
		}

		[TLDef(0xC563C1E4, "messages.updateDialogFiltersOrder#c563c1e4 order:Vector<int> = Bool")]
		public class Messages_UpdateDialogFiltersOrder : ITLFunction<bool> { public int[] order; }

		[TLDef(0xAB42441A, "stats.getBroadcastStats#ab42441a flags:# dark:flags.0?true channel:InputChannel = stats.BroadcastStats")]
		public class Stats_GetBroadcastStats : ITLFunction<Stats_BroadcastStats>
		{
			[Flags] public enum Flags { dark = 0x1 }
			public Flags flags;
			public InputChannelBase channel;
		}

		[TLDef(0x621D5FA0, "stats.loadAsyncGraph#621d5fa0 flags:# token:string x:flags.0?long = StatsGraph")]
		public class Stats_LoadAsyncGraph : ITLFunction<StatsGraphBase>
		{
			[Flags] public enum Flags { has_x = 0x1 }
			public Flags flags;
			public string token;
			[IfFlag(0)] public long x;
		}

		[TLDef(0x9A364E30, "stickers.setStickerSetThumb#9a364e30 stickerset:InputStickerSet thumb:InputDocument = messages.StickerSet")]
		public class Stickers_SetStickerSetThumb : ITLFunction<Messages_StickerSet>
		{
			public InputStickerSet stickerset;
			public InputDocumentBase thumb;
		}

		[TLDef(0x805D46F6, "bots.setBotCommands#805d46f6 commands:Vector<BotCommand> = Bool")]
		public class Bots_SetBotCommands : ITLFunction<bool> { public BotCommand[] commands; }

		[TLDef(0x5FE7025B, "messages.getOldFeaturedStickers#5fe7025b offset:int limit:int hash:int = messages.FeaturedStickers")]
		public class Messages_GetOldFeaturedStickers : ITLFunction<Messages_FeaturedStickersBase>
		{
			public int offset;
			public int limit;
			public int hash;
		}

		[TLDef(0xC0977421, "help.getPromoData#c0977421 = help.PromoData")]
		public class Help_GetPromoData : ITLFunction<Help_PromoDataBase> { }

		[TLDef(0x1E251C95, "help.hidePromoData#1e251c95 peer:InputPeer = Bool")]
		public class Help_HidePromoData : ITLFunction<bool> { public InputPeer peer; }

		[TLDef(0xFF7A9383, "phone.sendSignalingData#ff7a9383 peer:InputPhoneCall data:bytes = Bool")]
		public class Phone_SendSignalingData : ITLFunction<bool>
		{
			public InputPhoneCall peer;
			public byte[] data;
		}

		[TLDef(0xDCDF8607, "stats.getMegagroupStats#dcdf8607 flags:# dark:flags.0?true channel:InputChannel = stats.MegagroupStats")]
		public class Stats_GetMegagroupStats : ITLFunction<Stats_MegagroupStats>
		{
			[Flags] public enum Flags { dark = 0x1 }
			public Flags flags;
			public InputChannelBase channel;
		}

		[TLDef(0xEB2B4CF6, "account.getGlobalPrivacySettings#eb2b4cf6 = GlobalPrivacySettings")]
		public class Account_GetGlobalPrivacySettings : ITLFunction<GlobalPrivacySettings> { }

		[TLDef(0x1EDAAAC2, "account.setGlobalPrivacySettings#1edaaac2 settings:GlobalPrivacySettings = GlobalPrivacySettings")]
		public class Account_SetGlobalPrivacySettings : ITLFunction<GlobalPrivacySettings> { public GlobalPrivacySettings settings; }

		[TLDef(0x77FA99F, "help.dismissSuggestion#077fa99f suggestion:string = Bool")]
		public class Help_DismissSuggestion : ITLFunction<bool> { public string suggestion; }

		[TLDef(0x735787A8, "help.getCountriesList#735787a8 lang_code:string hash:int = help.CountriesList")]
		public class Help_GetCountriesList : ITLFunction<Help_CountriesListBase>
		{
			public string lang_code;
			public int hash;
		}

		[TLDef(0x24B581BA, "messages.getReplies#24b581ba peer:InputPeer msg_id:int offset_id:int offset_date:int add_offset:int limit:int max_id:int min_id:int hash:int = messages.Messages")]
		public class Messages_GetReplies : ITLFunction<Messages_MessagesBase>
		{
			public InputPeer peer;
			public int msg_id;
			public int offset_id;
			public DateTime offset_date;
			public int add_offset;
			public int limit;
			public int max_id;
			public int min_id;
			public int hash;
		}

		[TLDef(0x446972FD, "messages.getDiscussionMessage#446972fd peer:InputPeer msg_id:int = messages.DiscussionMessage")]
		public class Messages_GetDiscussionMessage : ITLFunction<Messages_DiscussionMessage>
		{
			public InputPeer peer;
			public int msg_id;
		}

		[TLDef(0xF731A9F4, "messages.readDiscussion#f731a9f4 peer:InputPeer msg_id:int read_max_id:int = Bool")]
		public class Messages_ReadDiscussion : ITLFunction<bool>
		{
			public InputPeer peer;
			public int msg_id;
			public int read_max_id;
		}

		[TLDef(0x29A8962C, "contacts.blockFromReplies#29a8962c flags:# delete_message:flags.0?true delete_history:flags.1?true report_spam:flags.2?true msg_id:int = Updates")]
		public class Contacts_BlockFromReplies : ITLFunction<UpdatesBase>
		{
			[Flags] public enum Flags { delete_message = 0x1, delete_history = 0x2, report_spam = 0x4 }
			public Flags flags;
			public int msg_id;
		}

		[TLDef(0x5630281B, "stats.getMessagePublicForwards#5630281b channel:InputChannel msg_id:int offset_rate:int offset_peer:InputPeer offset_id:int limit:int = messages.Messages")]
		public class Stats_GetMessagePublicForwards : ITLFunction<Messages_MessagesBase>
		{
			public InputChannelBase channel;
			public int msg_id;
			public int offset_rate;
			public InputPeer offset_peer;
			public int offset_id;
			public int limit;
		}

		[TLDef(0xB6E0A3F5, "stats.getMessageStats#b6e0a3f5 flags:# dark:flags.0?true channel:InputChannel msg_id:int = stats.MessageStats")]
		public class Stats_GetMessageStats : ITLFunction<Stats_MessageStats>
		{
			[Flags] public enum Flags { dark = 0x1 }
			public Flags flags;
			public InputChannelBase channel;
			public int msg_id;
		}

		[TLDef(0xF025BC8B, "messages.unpinAllMessages#f025bc8b peer:InputPeer = messages.AffectedHistory")]
		public class Messages_UnpinAllMessages : ITLFunction<Messages_AffectedHistory> { public InputPeer peer; }

	}
}
