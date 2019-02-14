using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Facebook.Messenger.Library
{
    internal abstract class HttpClientHelper
    {
        private readonly HttpClientHandler _httpClientHander;
        public const int MaxConnectionsPerServer = int.MaxValue;

        protected HttpClientHelper()
        {
            _httpClientHander = new HttpClientHandler
            {
                MaxConnectionsPerServer = MaxConnectionsPerServer
            };
        }

        protected HttpClientHelper(IWebProxy webProxy)
        {
            _httpClientHander = new HttpClientHandler
            {
                Proxy = webProxy,
                UseProxy = true,
                MaxConnectionsPerServer = MaxConnectionsPerServer
            };
        }

        public virtual HttpClient CreateHttpClient()
        {
            if (_httpClientHander != null)
            {
                return new HttpClient(_httpClientHander);
            }
            return new HttpClient();
        }
    }
}
