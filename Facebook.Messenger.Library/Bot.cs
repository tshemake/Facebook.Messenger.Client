using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library
{
    public class Bot
    {
        private readonly object syncHandle = new object();
        public int Id { get; private set; }
        public string Token { get; set; }
        public string BaseRequestUrl => string.IsNullOrEmpty(Token) ?
            string.Empty : $"{FacebookMessengerBotClientConfiguration.BASE_API_MESSEGES_URL}?access_token={Token}";

        public void SetToken(string token)
        {
            if (string.IsNullOrEmpty(token)
                && !EnvironmentSettings.GetEnvironmentVariable("PAGE_ACCESS_TOKEN", out token))
                throw new ArgumentNullException("Токен не может быть null или пустым", nameof(token));

            lock (syncHandle)
            {
                Token = token;
            }
        }


        public static string TryGetBaseRequestUrl(string token)
        {
            return string.IsNullOrEmpty(token) ? $"{FacebookMessengerBotClientConfiguration.BASE_API_MESSEGES_URL}?access_token={token}" : null;
        }
    }
}
