using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook.Messenger.Library
{
    public static class UriValidator
    {
        public static bool IsValidUri(string uri, UriKind allowedUriKind = UriKind.Absolute)
        {
            if (!Uri.TryCreate(uri, allowedUriKind, out var checkedUri))
            {
                return false;
            }
            if (checkedUri.IsAbsoluteUri)
            {
                IEnumerable<string> validSchemes = new[] { "http", "https" };
                return validSchemes.Any(s => s == checkedUri.Scheme);
            }
            return true;
        }
    }
}
