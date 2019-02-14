using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Domain
{
    public static class Events
    {
        public class WebhookVerifiedSuccess
        {
            public Guid Id { get; set; }
            public string Token { get; set; }
            public string Challenge { get; set; }
            public string Mode { get; set; }
        }

        public class WebhookVerifiedFailed
        {
            public Guid Id { get; set; }
            public string Token { get; set; }
            public string Challenge { get; set; }
            public string Mode { get; set; }
        }
    }
}
