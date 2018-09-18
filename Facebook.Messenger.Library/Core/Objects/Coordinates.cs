using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Coordinates
    {
        /// <summary>
        /// Широта
        /// </summary>
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude { get; set; }
        /// <summary>
        /// Долгота
        /// </summary>
        [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude { get; set; }
    }
}
