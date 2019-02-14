using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    /// <summary>
    /// The type of an <see cref="Update"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum TopicType
    {
        /// <summary>
        /// Update Type is unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The <see cref="Update"/>.
        /// </summary>
        [EnumMember(Value = "page")]
        Page,

        /// <summary>
        /// The <see cref="Update"/>.
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// The <see cref="Update"/>.
        /// </summary>
        [EnumMember(Value = "error")]
        Error,
    }

    public class Update : Serializable
    {
        /// <summary>
        /// The object's type
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public TopicType Entity { get; set; }

        /// <summary>
        /// Массив, содержащий данные события
        /// </summary>
        /// <remarks>
        /// Вы должны удостовериться, что ваш код проводит итерацию по этому
        /// массиву для обработки всех событий.
        /// </remarks>
        [JsonProperty(PropertyName = "entry")]
        public ICollection<Entry> Entries { get; set; }
    }
}
