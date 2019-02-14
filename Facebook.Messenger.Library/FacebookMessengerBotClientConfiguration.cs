using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library
{
    public sealed class FacebookMessengerBotClientConfiguration
    {
        public static readonly string API_VERSION = "v2.6";

        public static readonly string BASE_API_URL = $"https://graph.facebook.com/{API_VERSION}";

        public static readonly string BASE_API_MESSEGES_URL = $"{BASE_API_URL}/me/messages";
    }
}
