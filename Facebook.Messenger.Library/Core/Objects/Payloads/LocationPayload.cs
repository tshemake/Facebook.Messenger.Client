using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Payloads
{
    public class LocationPayload : IPayload
    {
        public LocationPayload()
        {
        }

        public LocationPayload(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        [JsonProperty("coordinates", NullValueHandling = NullValueHandling.Ignore)]
        public Coordinates Coordinates { get; set; }
    }
}
