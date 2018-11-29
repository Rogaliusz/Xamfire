using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Xamfire.Exceptions.Settings
{
    public class InvalidConfigException : XamfireException
    {
        public InvalidConfigException()
        {
        }

        public InvalidConfigException(string message) : base(message)
        {
        }

        public InvalidConfigException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidConfigException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
