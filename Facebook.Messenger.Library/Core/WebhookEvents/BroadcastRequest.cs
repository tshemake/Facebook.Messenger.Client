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
    /// <typeparam name="T"></typeparam>
    public class BroadcastRequest<T> : Serializable
    {
        /// <summary>
        /// Сообщения для отправки.
        /// </summary>
        [JsonProperty(PropertyName = "messages")]
        public List<T> Messages { get; set; }
    }
}
