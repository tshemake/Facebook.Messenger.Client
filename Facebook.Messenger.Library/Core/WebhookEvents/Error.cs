using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    public class Error
    {
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }
        [JsonProperty(PropertyName = "error_subcode", NullValueHandling = NullValueHandling.Ignore)]
        public int ErrorSubcode { get; set; }
        [JsonProperty(PropertyName = "fbtrace_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FBTraceId { get; set; }
    }
}
