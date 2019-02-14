using Facebook.Messenger.Library.Core.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library
{
    public interface IFacebookMessengerBotClient
    {
        Task<SendApiResponse> SendTextMessageAsync(
            string recipientId,
            string text,
            Action<SendApiResponse> callback = null,
            Action<string, Exception> errorCallback = null,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<SendApiResponse> SendTextMessageAsync(
            string token,
            string recipientId,
            string text,
            Action<SendApiResponse> callback = null,
            Action<string, Exception> errorCallback = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
