using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Address
    {
        [JsonProperty("street_1", NullValueHandling = NullValueHandling.Ignore)]
        public string Street1 { get; set; }

        [JsonProperty("street_2", NullValueHandling = NullValueHandling.Ignore)]
        public string Street2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    }
}
