using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Facebook.Messenger.Library;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.WebhookEvents;
using Flurl;
using Flurl.Http;
using Polly;

namespace Facebook.Messenger.Client.Infrastructure
{
    public class FacebookMessengerService : Agent
    {
        private static Policy exponentialRetryPolicy = 
            Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2, attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));

        public override async Task SendTextMessageAsync(MessageRecievedEvent<MessageResponse> message)
        {
            await AsyncHelper.RedirectToThreadPool();

            await exponentialRetryPolicy.ExecuteAsync(() => 
                GraphApiUrl
                    .AppendPathSegment("v2.6/me/messages")
                    .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                    .PostJsonAsync(message));
        }

        public override async Task<long> MessageCreativesRequestAsync<T>(BroadcastRequest<T> message)
        {
            await AsyncHelper.RedirectToThreadPool();

            var messageCreatives = await exponentialRetryPolicy.ExecuteAsync(() =>
                GraphApiUrl
                    .AppendPathSegment("v2.6/me/message_creatives")
                    .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                    .PostJsonAsync(message)
                    .ReceiveJson<BroadcastResponse>());

            return messageCreatives.MessageCreativeId;
        }

        public override async Task<long> SendBroadcastMessagesAsync(BroadcastMessageRequest message)
        {
            var messageBroadcast = await exponentialRetryPolicy.ExecuteAsync(() =>
                GraphApiUrl
                    .AppendPathSegment("v2.6/me/broadcast_messages")
                    .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                    .PostJsonAsync(message)
                    .ReceiveJson<BroadcastMessageResponse>());

            return messageBroadcast.BroadcastId;
        }
    }
}