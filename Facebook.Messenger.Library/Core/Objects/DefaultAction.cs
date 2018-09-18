using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class DefaultAction
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("messenger_extensions", NullValueHandling = NullValueHandling.Ignore)]
        public string MessengerExtensions { get; set; }

        [JsonProperty("webview_height_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string WebviewHeightRatio { get; set; }

        [JsonProperty("fallback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RallbackUrl { get; set; }
    }
}
