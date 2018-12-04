using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Xamfire.Exceptions.Auth
{
    public class FailRegisterException : XamfireException
    {
        public FailRegisterException()
        {
        }

        public FailRegisterException(string message) : base(message)
        {
        }

        public FailRegisterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FailRegisterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
