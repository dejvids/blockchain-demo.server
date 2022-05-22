using System;
using System.Runtime.Serialization;

namespace Blockcchain_demo.Shared.Exceptions
{
    [Serializable]
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException()
        {
        }

        public InvalidConfigurationException(string? message) : base(message)
        {
        }

        public InvalidConfigurationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}