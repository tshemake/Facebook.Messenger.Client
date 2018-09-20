using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Exceptions
{
    public class FacebookException : Exception
    {
        public FacebookException(string message)
            : base(message)
        {
        }

        public FacebookException(string message, string type, int code, int subCode)
            : base(message)
        {
            Type = type;
            Code = code;
            SubCode = subCode;
        }

        public string Type { get; set; }
        public int Code { get; set; }
        public int SubCode { get; set; }
    }
}
