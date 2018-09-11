using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    public class Event : Serializable
    {
        /// <summary>
        /// Значение будет page
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public string Entity { get; set; }

        /// <summary>
        /// Массив, содержащий данные события
        /// </summary>
        [JsonProperty(PropertyName = "entry")]
        public ICollection<Entry> Entries { get; set; }
    }
}
