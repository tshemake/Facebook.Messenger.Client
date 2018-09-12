using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public abstract class Serializable
    {
        public string ToJson() => JsonConvert.SerializeObject(this,
            Formatting.None,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

        public override string ToString() => ToJson();
    }
}
