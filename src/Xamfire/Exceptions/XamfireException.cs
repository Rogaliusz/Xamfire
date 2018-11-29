using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Xamfire.Exceptions
{
    public abstract class XamfireException : Exception
    {
        public XamfireException()
        {
        }

        public XamfireException(string message) : base(message)
        {
        }

        public XamfireException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XamfireException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
