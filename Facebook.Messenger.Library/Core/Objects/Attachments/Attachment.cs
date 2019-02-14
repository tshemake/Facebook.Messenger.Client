using Facebook.Messenger.Library.Core.Objects.Payloads;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    /// <summary>
    /// The type of an <see cref="Attachment"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum AttachmentType
    {
        Unknown = 0,

        [EnumMember(Value = "generic")]
        Generic,

        [EnumMember(Value = "fallback")]
        Fallback,

        [EnumMember(Value = "button")]
        Button,

        [EnumMember(Value = "image")]
        Image,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "video")]
        Video,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "template")]
        Template,

        [EnumMember(Value = "location")]
        Location,

        [EnumMember(Value = "receipt")]
        Receipt
    }

    public class Attachment : IAttachment
    {
        [JsonProperty("type", Required = Required.Always)]
        public AttachmentType Type { get; private set; }

        public Attachment(AttachmentType type)
        {
            Type = type;
        }
    }

    public class Attachment<T> : Attachment where T : IPayload
    {
        public Attachment(AttachmentType type) : base(type)
        {
        }

        [JsonProperty("payload", Required = Required.Always)]
        public T Payload { get; set; }
    }
}