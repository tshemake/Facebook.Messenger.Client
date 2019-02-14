using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library
{
    internal static class ASCIIEncoding
    {
        public static int SizeInBytes(string chars)
        {
            if (chars == null)
                throw new ArgumentNullException(nameof(chars));

            return Encoding.Unicode.GetByteCount(chars);
        }
    }
}
