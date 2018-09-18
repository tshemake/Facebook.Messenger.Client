using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class MediaPayload
    {
        public MediaPayload()
        {

        }

        public MediaPayload(string url)
        {
            Url = url;
        }

        /// <summary>
        /// URL of media
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("sticker_id", NullValueHandling = NullValueHandling.Ignore)]
        public string StickerId { get; set; }
    }
}
