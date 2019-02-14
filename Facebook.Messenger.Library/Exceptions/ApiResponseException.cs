using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Facebook.Messenger.Library.Exceptions
{
    public class ApiResponseException : Exception
    {
        public virtual HttpStatusCode StatusCode { get; }

        public ApiResponseException(string errorMessage)
            : base(errorMessage)
        {
        }

        public ApiResponseException(string errorMessage, HttpStatusCode statusCode)
            : base(errorMessage)
        {
            StatusCode = statusCode;
        }

        public ApiResponseException(string errorMessage, HttpStatusCode statusCode, Exception innerException)
            : base(errorMessage, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
