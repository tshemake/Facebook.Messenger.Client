using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library
{
    public class FacebookApi
    {
        private const string BASE_API_URL = "https://graph.facebook.com/v2.6/me/messages";

        private string _pageAccessToken;

        public FacebookApi(string pageAccessToken)
        {
            if (string.IsNullOrEmpty(pageAccessToken))
            {
                throw new ArgumentNullException(nameof(pageAccessToken));
            }
            _pageAccessToken = pageAccessToken;
        }

        public async Task<bool> SendMessage(string pageAccessToken, string recipientId, string text)
        {
            string url = $"{BASE_API_URL}?access_token={pageAccessToken}";
            bool isSuccessful = false;

            object contents = new
            {
                messaging_type = "RESPONSE",
                recipient = new
                {
                    id = recipientId
                },
                message = new
                {
                    text
                }
            };

            isSuccessful = await SendPostRequest(url, contents);

            return isSuccessful;
        }

        public async Task<bool> SendMessage(string recipientId, string text)
        {
            return await SendMessage(this._pageAccessToken, recipientId, text);
        }

        private async Task<bool> SendPostRequest<T>(string url, T dataToSend)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(dataToSend, JsonSerializerSettings);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                return response.IsSuccessStatusCode;
            }
        }

        public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
    }
}
