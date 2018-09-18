using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Objects
{
    public static class Types
    {
        /// <summary>
        /// Тип отправляемого сообщения
        /// </summary>
        public static class Messaging
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
            public const string RESPONSE = "RESPONSE";
            /// <summary>
            /// Сообщение не является ответом. Такой тип может быть
            /// у рекламных и обычных сообщений, отправленных в
            /// стандартный 24-часовой период или в рамках правила
            /// "24 + 1".
            /// </summary>
            public const string UPDATE = "UPDATE";
            /// <summary>
            /// Сообщение не является рекламным и отправляется
            /// вне стандартного 24-часового периода с тегом
            /// сообщения. Сообщение должно использоваться только
            /// в ситуациях, которые подразумевает этот тег.
            /// </summary>
            public const string MESSAGE_TAG = "MESSAGE_TAG";
        }

        /// <summary>
        /// Тип push-уведомлений
        /// </summary>
        /// <remarks>
        /// По умолчанию используется REGULAR.
        /// </remarks>
        public static class Notification
        {
            /// <summary>
            /// Звук/вибрация
            /// </summary>
            public const string REGULAR = "REGULAR";
            /// <summary>
            /// Только уведомление на экране
            /// </summary>
            public const string SILENT_PUSH = "SILENT_PUSH";
            /// <summary>
            /// Без уведомлений
            /// </summary>
            public const string NO_PUSH = "NO_PUSH";
        }

        public static class Topics
        {
            public const string PAGE = "page";
            public const string USER = "user";
        }

        public static class Payload
        {
            public const string IMAGE = "image";
            public const string AUDIO = "audio";
            public const string VIDEO = "video";
            public const string FILE = "file";
        }
    }
}
