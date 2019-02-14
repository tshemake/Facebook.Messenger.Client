using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Facebook.Messenger.Library
{
    internal class HttpClientHelperFactory
    {
        public static readonly Lazy<HttpClientHelperFactory> _instance = new Lazy<HttpClientHelperFactory>(() => new HttpClientHelperFactory());
        public static HttpClientHelperFactory Instance => _instance.Value;

        protected HttpClientHelperFactory()
        {
        }

        public virtual HttpClientHelper CreateHttpClientHelper()
        {
            return new HttpClientHelperImpl();
        }

        public virtual HttpClientHelper CreateHttpClientHelper(IWebProxy webProxy)
        {
            return new HttpClientHelperImpl(webProxy);
        }

        private class HttpClientHelperImpl : HttpClientHelper
        {
            public HttpClientHelperImpl()
            {
            }

            public HttpClientHelperImpl(IWebProxy webProxy)
                : base(webProxy)
            {
            }
        }
    }
}
