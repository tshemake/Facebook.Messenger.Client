using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;

namespace Facebook.Messenger.Library
{
    public abstract class Agent
    {
        public static string PAGE_ACCESS_TOKEN = Environment.GetEnvironmentVariable("PAGE_ACCESS_TOKEN");
        public static string VERIFY_TOKEN = Environment.GetEnvironmentVariable("VERIFY_TOKEN");

        public const string GraphApiUrl = "https://graph.facebook.com";

        public abstract Task SendTextMessageAsync(MessageRecievedEvent<MessageResponse> message);
    }
}
