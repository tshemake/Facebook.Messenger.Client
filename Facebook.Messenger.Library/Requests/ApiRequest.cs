using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Exceptions;
using Facebook.Messenger.Library.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Facebook.Messenger.Library.Requests
{
    internal class ApiRequest<TResponseType>
    {
        public static readonly JsonSerializer JsonObjectTypeSerializer = JsonSerializer.Create();
        public static readonly JsonSerializerSettings ObjectSerializationSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy { OverrideSpecifiedNames = true }
            }
        };

        private readonly IRequest _request;
        private readonly string _requestUrl;

        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public TResponseType Result { get; private set; }

        public ApiRequest(IRequest request, string url)
        {
            _request = request;
            _requestUrl = url;
        }

        public HttpRequestMessage OnSend()
        {
            return new HttpRequestMessage(_request.Method, _requestUrl)
            {
                Content = _request.ToHttpContent()
            };
        }

        public async Task OnResponseAsync(HttpResponseMessage response)
        {
            var apiResponse = await ReadContentAsJsonAsync<ApiResponse<TResponseType>>(response)
                    ?? new ApiResponse<TResponseType>
                    {
                        Ok = false,
                        Description = "Пустой ответ"
                    };
            if (!apiResponse.Ok)
                OnError(apiResponse.ErrorCode, apiResponse.Description);

            Result = apiResponse.Result;
        }

        private static async Task<T> ReadContentAsJsonAsync<T>(HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();
            return FromJson<T>(content);
        }

        private static T FromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, ObjectSerializationSettings);
        }

        public void OnError(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public void ThrowIfHasError()
        {
            if (ErrorCode != 0)
            {
                HandleError();
            }
        }

        private void HandleError()
        {
            Debug.WriteLine($"Произошла ошибка {ErrorCode} - {ErrorMessage}");
            throw new ApiRequestException(ErrorMessage, ErrorCode);
        }
    }
}
