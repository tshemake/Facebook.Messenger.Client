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
    /// Отправка рекламных сообщений
    /// </summary>
    public class BroadcastResponse : Serializable
    {
        /// <summary>
        /// Уникальный ID оформления сообщения.
        /// </summary>
        [JsonProperty(PropertyName = "message_creative_id")]
        public long MessageCreativeId { get; set; }
    }
}
