using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Xamfire.Exceptions.Network
{
    public class NoInternetConnectionException : XamfireException
    {
        public NoInternetConnectionException()
        {
        }

        public NoInternetConnectionException(string message) : base(message)
        {
        }

        public NoInternetConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NoInternetConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
