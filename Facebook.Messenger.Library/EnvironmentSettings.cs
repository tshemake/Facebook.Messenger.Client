using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library
{
    public static class EnvironmentSettings
    {
        public static bool GetEnvironmentVariable(string variable, out string result)
        {
            if (string.IsNullOrEmpty(variable)) throw new ArgumentNullException(nameof(variable));

            result = string.Empty;
            var value = Environment.GetEnvironmentVariable(variable);
            if (string.IsNullOrEmpty(value)) {
                return false;
            }
            result = value;
            return true;
        }
    }
}
