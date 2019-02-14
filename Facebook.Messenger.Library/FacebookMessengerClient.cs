using Facebook.Messenger.Library.Requests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library
{
    public partial class FacebookMessengerBotClient : IFacebookMessengerBotClient
    {
        private readonly Bot _bot;
        private readonly ApiSender _sender;

        public FacebookMessengerBotClient(HttpClient httpClient = null)
        {
            _bot = new Bot();
            _sender = new ApiSender(httpClient);
        }

        public FacebookMessengerBotClient(IWebProxy webProxy)
        {
            _bot = new Bot();
            _sender = new ApiSender(webProxy);
        }

        public FacebookMessengerBotClient(string token, HttpClient httpClient = null)
        {
            _bot = new Bot();
            _bot.SetToken(token);

            _sender = new ApiSender(httpClient);
        }

        public FacebookMessengerBotClient(string token, IWebProxy webProxy)
        {
            _bot = new Bot();
            _bot.SetToken(token);

            _sender = new ApiSender(webProxy);
        }

        public void SetToken(string token)
        {
            _bot.SetToken(token);
        }

        private async Task<TResponse> SendRequestAsync<TResponse>(IRequest request, Action<TResponse> callback = null, Action<string, Exception> errorCallback = null, CancellationToken cancellationToken = new CancellationToken(), bool throwOnError = true)
        {
            var apiRequst = new ApiRequest<TResponse>(request, _bot.BaseRequestUrl);
            try
            {
                await _sender.SendAsync(apiRequst, callback, errorCallback, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                if (throwOnError) throw;
            }
            if (throwOnError) apiRequst.ThrowIfHasError();

            return apiRequst.Result;
        }

        private async Task<TResponse> SendRequestAsync<TResponse>(string token, IRequest request, Action<TResponse> callback = null, Action<string, Exception> errorCallback = null, CancellationToken cancellationToken = new CancellationToken(), bool throwOnError = true)
        {
            string url = Bot.TryGetBaseRequestUrl(token);
            ThrowIfInvalidUrl(url);

            var apiRequst = new ApiRequest<TResponse>(request, url);
            try
            {
                await _sender.SendAsync(apiRequst, callback, errorCallback, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                if (throwOnError) throw;
            }
            if (throwOnError) apiRequst.ThrowIfHasError();

            return apiRequst.Result;
        }

        private void ThrowIfInvalidUrl(string url)
        {
            if (!UriValidator.IsValidUri(url)) throw new UriFormatException(url);
        }
    }
}
