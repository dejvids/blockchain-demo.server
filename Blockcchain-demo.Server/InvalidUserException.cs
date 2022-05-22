using System;
using System.Runtime.Serialization;

namespace Blockcchain_demo.Server
{
    [Serializable]
    internal class InvalidUserException : Exception
    {
        public InvalidUserException()
        {
        }

        public InvalidUserException(string? message) : base(message)
        {
        }

        public InvalidUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}