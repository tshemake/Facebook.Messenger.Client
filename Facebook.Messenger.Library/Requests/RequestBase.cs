using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Requests
{
    public abstract class RequestBase : IRequest
    {
        [JsonIgnore]
        public HttpMethod Method { get; }

        protected RequestBase(HttpMethod method)
        {
            Method = method;
        }

        public HttpContent ToHttpContent()
        {
            return Serialize();
        }

        public abstract HttpContent Serialize();
    }
}
