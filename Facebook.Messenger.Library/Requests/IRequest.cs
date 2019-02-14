using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Facebook.Messenger.Library.Requests
{
    public interface IRequest
    {
        HttpMethod Method { get; }

        HttpContent ToHttpContent();
    }
}
