using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class MessageRecievedEvent<T> : Serializable where T : IMessage
    {
        /// <summary>
        /// Тип отправляемого сообщения.
        /// </summary>
        [JsonProperty(PropertyName = "messaging_type")]
        public Types.Messaging MessageType { get; set; } = Types.Messaging.RESPONSE;
        [JsonProperty(PropertyName = "recipient")]
        public Recipient Recipient { get; set; }
        [JsonProperty(PropertyName = "message")]
        public T Message { get; set; }
        [JsonProperty(PropertyName = "notification_type")]
        public Types.Notification NotificationType { get; set; } = Types.Notification.REGULAR;
    }
}
