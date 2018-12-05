using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Exceptions
{
    public static class ExceptionMessages
    {
        public const string INVALID_CONFIG_FILE = "google-services.json is missing or has invalid build type";
        public const string MISSING_IMPLEMENTATION = "IFirebase settings interface wasn't injected";
        public const string XAMFIRE_WAS_NOT_INITALIZED = "IFirebase settings interface wasn't injected";

        public const string INVALID_CREDENTIALS = "Credentials are incorrect";

        public const string PRIMARY_KEY_WAS_NOT_SET = "Primary key must be set before document operations. Set it in method 'Configure' in your context";
    }
}
