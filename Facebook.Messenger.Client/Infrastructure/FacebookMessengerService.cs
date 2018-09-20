using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Facebook.Messenger.Library;
using Facebook.Messenger.Library.Core.Exceptions;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.WebhookEvents;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Polly;

namespace Facebook.Messenger.Client.Infrastructure
{
    public class FacebookMessengerService : Agent
    {
        private static Policy exponentialRetryPolicy =
            Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    3,
                    attempt => TimeSpan.FromMilliseconds(100 * Math.Pow(2, attempt)));

        public override async Task<HttpResponseMessage> SendTextMessageAsync(MessageRecievedEvent<MessageResponse> message)
        {
            await AsyncHelper.RedirectToThreadPool();

            return await exponentialRetryPolicy.ExecuteAsync(() =>
                DoSendTextMessageAsync(message));
        }

        public async Task<HttpResponseMessage> DoSendTextMessageAsync(MessageRecievedEvent<MessageResponse> message)
        {
            await AsyncHelper.RedirectToThreadPool();

            var response = await GraphApiUrl
                .AppendPathSegment("v2.6/me/messages")
                .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                .PostJsonAsync(message);

            await ThrowOnTransientFailure(response);
            return response;
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

        private static Error CreateResultError(JObject value)
        {
            if (value.Property(Types.Topics.ERROR) == null) return null;
            var error = (JObject)value.Property(Types.Topics.ERROR).Value;
            var result = error.ToObject<Error>();
            return result;
        }

        private static async Task ThrowOnTransientFailure(HttpResponseMessage response)
        {
            if (((int)response.StatusCode) < 200 ||
                ((int)response.StatusCode) > 499)
                throw new HttpResponseException(response);
            var result = await AsJObjectAsync(response);
            if (result != null) {
                var error = CreateResultError(result);
                if (error != null) {
                    throw new FacebookException(error.Message, error.Type, error.Code, error.ErrorSubcode);
                }
            }
        }

        private static async Task<JObject> AsJObjectAsync(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}