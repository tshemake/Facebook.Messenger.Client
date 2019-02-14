using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Facebook.Messenger.Library.Requests
{
    public class RequestWithParameters : RequestBase
    {
        public static readonly JsonSerializerSettings ObjectSerializationSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public RequestWithParameters()
            : this(HttpMethod.Post)
        {
        }

        public RequestWithParameters(HttpMethod method)
            : base(method)
        {
        }

        public override HttpContent Serialize()
        {
            string payload = JsonConvert.SerializeObject(this, ObjectSerializationSettings);
            return new StringContent(payload, Encoding.UTF8, "application/json");
        }
    }
}
