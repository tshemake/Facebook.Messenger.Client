using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Library.Core.Objects
{
    public static class Types
    {
        /// <summary>
        /// Тип отправляемого сообщения
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Messaging
        {
            /// <summary>
            /// Сообщение отправляется в ответ на другое сообщение.
            /// Такой тип может быть у рекламных и обычных сообщений,
            /// отправленных в стандартный 24-часовой период или в
            /// рамках правила "24 + 1".
            /// </summary>
            /// <remarks>
            /// Например, если пользователь
            /// запрашивает подтверждение резерва или обновление статуса,
            /// используйте этот тег в ответном сообщении.
            /// </remarks>
            [JsonProperty("RESPONSE")]
            RESPONSE,
            /// <summary>
            /// Сообщение не является ответом. Такой тип может быть
            /// у рекламных и обычных сообщений, отправленных в
            /// стандартный 24-часовой период или в рамках правила
            /// "24 + 1".
            /// </summary>
            [JsonProperty("UPDATE")]
            UPDATE,
            /// <summary>
            /// Сообщение не является рекламным и отправляется
            /// вне стандартного 24-часового периода с тегом
            /// сообщения. Сообщение должно использоваться только
            /// в ситуациях, которые подразумевает этот тег.
            /// </summary>
            [JsonProperty("MESSAGE_TAG")]
            MESSAGE_TAG
        }

        /// <summary>
        /// Тип push-уведомлений
        /// </summary>
        /// <remarks>
        /// По умолчанию используется REGULAR.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Notification
        {
            /// <summary>
            /// Звук/вибрация
            /// </summary>
            [JsonProperty("REGULAR")]
            REGULAR,
            /// <summary>
            /// Только уведомление на экране
            /// </summary>
            [JsonProperty("SILENT_PUSH")]
            SILENT_PUSH,
            /// <summary>
            /// Без уведомлений
            /// </summary>
            [JsonProperty("NO_PUSH")]
            NO_PUSH
        }

        public static class Topics
        {
            public const string PAGE = "page";
            public const string USER = "user";
            public const string ERROR = "error";
        }

        public static class Payload
        {
            public const string IMAGE = "image";
            public const string AUDIO = "audio";
            public const string VIDEO = "video";
            public const string FILE = "file";
            public const string LOCATION = "location";
            public const string FALLBACK = "fallback";
            public const string TEMPLATE = "template";
        }

        public static class Template
        {
            public const string GENERIC = "generic";
            public const string BUTTON = "button";
            public const string RECEIPT = "receipt";
        }
    }
}
