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

        /// <summary>
        /// Состояние сообщения, отображаемое
        /// для пользователя
        /// </summary>
        /// <remarks>
        /// Не удается отправить с message. Необходимо
        /// отправить как отдельный запрос.
        /// </remarks>
        /// <remarks>
        /// При использовании sender_actionrecipient
        /// должно быть единственным другим набором
        /// свойств в запросе.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SenderAction
        {
            /// <summary>
            /// Показать пузырек ввода
            /// </summary>
            [JsonProperty("typing_on")]
            TypingOn,
            /// <summary>
            /// Убрать пузырек ввода
            /// </summary>
            [JsonProperty("typing_off")]
            TypingOff,
            /// <summary>
            /// Показать значок подтверждения
            /// </summary>
            [JsonProperty("mark_seen")]
            MarkSeen
        }
    }
}
