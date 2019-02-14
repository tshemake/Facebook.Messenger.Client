using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library.Exceptions
{
    public class ApiRequestException : Exception
    {
        public virtual int ErrorCode { get; }

        public ApiRequestException(string errorMessage)
            : base(errorMessage)
        {
        }

        public ApiRequestException(string errorMessage, int errorCode)
            : base(errorMessage)
        {
            ErrorCode = errorCode;
        }

        public ApiRequestException(string errorMessage, int errorCode, Exception innerException)
            : base(errorMessage, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
