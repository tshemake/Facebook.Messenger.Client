using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Summary
    {
        [JsonProperty("subtotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Subtotal { get; set; }

        [JsonProperty("shipping_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ShippingCost { get; set; }

        [JsonProperty("total_tax", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TotalTax { get; set; }

        [JsonProperty("total_cost", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TotalCost { get; set; }
    }
}
