using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects.Attachments;
using Facebook.Messenger.Library.Core.Objects.Attachments.Converters;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Message : Serializable, IMessage
    {
        /// <summary>
        /// ID сообщения
        /// </summary>
        [JsonProperty(PropertyName = "mid", NullValueHandling = NullValueHandling.Ignore)]
        public string Mid { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
        /// <summary>
        /// Sequence number
        /// </summary>
        [JsonProperty(PropertyName = "seq", NullValueHandling = NullValueHandling.Ignore)]
        public int? Seq { get; set; }
        /// <summary>
        /// Дополнительные настраиваемые данные, которые предоставляет приложение,
        /// отправившее сообщение
        /// </summary>
        [JsonProperty("quick_reply")]
        public QuickReply QuickReply { get; set; }
        /// <summary>
        /// Indicates the message sent from the page itself
        /// </summary>
        [JsonProperty("is_echo", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEcho { get; set; }
        /// <summary>
        /// Массив, содержащий данные вложения
        /// </summary>
        [JsonProperty("attachments", ItemConverterType = typeof(AttachmentConverter))]
        public List<Attachment> Attachments { get; set; }
    }
}
