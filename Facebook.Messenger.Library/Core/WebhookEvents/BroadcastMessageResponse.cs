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
    /// Оформление сообщения
    /// </summary>
    public class BroadcastMessageResponse : Serializable
    {
        /// <summary>
        /// Уникальный ID отправленных сообщений.
        /// </summary>
        [JsonProperty(PropertyName = "broadcast_id")]
        public long BroadcastId { get; set; }
    }
}
