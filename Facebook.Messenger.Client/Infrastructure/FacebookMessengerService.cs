using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Facebook.Messenger.Library;
using Facebook.Messenger.Library.Core.Objects;
using Flurl;
using Flurl.Http;

namespace Facebook.Messenger.Client.Infrastructure
{
    public class FacebookMessengerService : Agent
    {
        public override async Task SendTextMessageAsync(MessageRecievedEvent<MessageResponse> message)
        {
            await GraphApiUrl
                .AppendPathSegment("v2.6/me/messages")
                .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                .PostJsonAsync(message);
        }
    }
}