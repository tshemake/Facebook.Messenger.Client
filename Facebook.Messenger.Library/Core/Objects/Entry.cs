using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Entry
    {
        /// <summary>
        /// ID Страницы
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Время обновления (время периода в миллисекундах)
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        /// <summary>
        /// Массив, содержащий один объект messaging. Внимание: хотя это и массив, он будет содержать только один объект messaging.
        /// </summary>
        [JsonProperty(PropertyName = "messaging")]
        public ICollection<Messaging> Messages { get; set; }
    }
}
