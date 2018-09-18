using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Payloads
{
    public class ReceiptTemplatePayload : TemplatePayload
    {
        public ReceiptTemplatePayload() : base("receipt")
        {
        }

        [JsonProperty("recipient_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientName { get; set; }

        [JsonProperty("merchant_name", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantName { get; set; }

        [JsonProperty("order_number", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderNumber { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("payment_method", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentMethod { get; set; }

        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp { get; set; }

        [JsonProperty("order_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderUrl { get; set; }

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<ReceiptElement> Elements { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        public Summary Summary { get; set; }

        [JsonProperty("adjustments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Adjustment> Adjustments { get; set; }
    }
}
