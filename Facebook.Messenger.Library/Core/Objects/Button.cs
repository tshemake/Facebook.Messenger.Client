using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Button
    {
        public Button(string type)
        {
            Type = type;
        }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; private set; }
    }
}
