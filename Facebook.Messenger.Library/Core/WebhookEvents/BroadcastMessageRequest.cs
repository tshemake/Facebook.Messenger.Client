using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    /// <summary>
    /// Рассылка сообщений нескольким адресатам
    /// </summary>
    public class BroadcastMessageRequest : Serializable
    {
        /// <summary>
        /// ID message_creative_id оформления сообщения для
        /// отправки нескольким адресатам.
        /// </summary>
        [JsonProperty(PropertyName = "message_creative_id")]
        public long MessageCreativeId { get; set; }
        [JsonProperty(PropertyName = "notification_type")]
        public Types.Notification NotificationType { get; set; } = Types.Notification.Regular;
        [JsonProperty(PropertyName = "messaging_type")]
        public string MessagingType { get; set; } = Types.Messaging.MESSAGE_TAG;
        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; } = "NON_PROMOTIONAL_SUBSCRIPTION";
    }
}
