using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class QuickReply
    {
        /// <summary>
        /// Настраиваемые данные, которые предоставляет приложение.
        /// </summary>
        /// <remarks>
        /// Полезные данные quick_reply отправляются в текстовом сообщении, только если пользователь нажмет кнопку быстрого ответа.
        /// </remarks>
        public string Payload { get; set; }
    }
}
