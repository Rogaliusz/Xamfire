using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Xamfire.Exceptions.Auth
{
    public class InvalidCredentialsException : XamfireException
    {
        public InvalidCredentialsException()
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }

        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
