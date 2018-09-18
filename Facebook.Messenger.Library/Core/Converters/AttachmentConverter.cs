using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Facebook.Messenger.Library.Core.Converters
{
    public class AttachmentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Attachment);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = default(Attachment);
            var attachment = JObject.Load(reader);
            var type = (attachment["type"] as JValue)?.Value.ToString();
            switch (type)
            {
                case Types.Payload.IMAGE:
                    result = new ImageAttachment();
                    break;
                case Types.Payload.VIDEO:
                    result = new VideoAttachment();
                    break;
                case Types.Payload.AUDIO:
                    result = new AudioAttachment();
                    break;
                case Types.Payload.FILE:
                    result = new FileAttachment();
                    break;
            }
            serializer.Populate(attachment.CreateReader(), result);

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
