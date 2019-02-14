using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Requests;
using Facebook.Messenger.Library.Responses;
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
        public async Task<SendApiResponse> SendTextMessageAsync(
            string recipientId,
            string text,
            Action<SendApiResponse> callback = null,
            Action<string, Exception> errorCallback = null,
            CancellationToken cancellationToken = default(CancellationToken)
        ) =>
            await SendRequestAsync<SendApiResponse>(new SendMessageRequest(recipientId, text), callback, errorCallback, cancellationToken);

        public async Task<SendApiResponse> SendTextMessageAsync(
            string token,
            string recipientId,
            string text,
            Action<SendApiResponse> callback = null, 
            Action<string, Exception> errorCallback = null,
            CancellationToken cancellationToken = default(CancellationToken)
        ) =>
            await SendRequestAsync<SendApiResponse>(token, new SendMessageRequest(recipientId, text), callback, errorCallback, cancellationToken);
    }
}
