using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Polly;
    using Polly.Retry;

    public class PollyHttpClient
    {
        private static readonly RetryPolicy<HttpResponseMessage> _retryPolicy = Policy.Handle<HttpRequestException>()
            .Or<TaskCanceledException>()
            .OrResult<HttpResponseMessage>(r => !r.StatusCode.IsSuccessfulRequest())
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), OnRetry());

        private static Action<DelegateResult<HttpResponseMessage>, TimeSpan, int, Context> OnRetry() => (result, time, retryCount, context) => { };

        public static async Task<HttpResponseMessage> PostAsync(HttpClient httpClient, HttpRequestMessage request, CancellationToken cancellationToken)
            => await _retryPolicy.ExecuteAsync(async () =>
            {
                return await httpClient.SendAsync(request, cancellationToken);
            });
    }
}
