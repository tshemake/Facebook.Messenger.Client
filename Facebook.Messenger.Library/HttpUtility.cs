using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Facebook.Messenger.Library
{
    internal static class HttpUtility
    {
        public static bool IsSuccessfulRequest(this HttpStatusCode statusCode)
        {
            return IsSuccessfulRequest((int)statusCode);
        }

        private static bool IsSuccessfulRequest(int statusCode)
        {
            return (statusCode >= 200 && statusCode <= 299) || statusCode == 304;
        }
    }
}
