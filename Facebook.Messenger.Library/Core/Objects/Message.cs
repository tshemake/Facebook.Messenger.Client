using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Message
    {
        public string Mid { get; set; }
        public string Text { get; set; }
        public QuickReply QuickReply { get; set; }
        public int? Seq { get; set; } = null;
    }
}
