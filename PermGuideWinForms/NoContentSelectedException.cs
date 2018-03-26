using System;
using System.Runtime.Serialization;

namespace PermGuideWinForms
{
    [Serializable]
    internal class NoContentSelectedException : Exception
    {
        public NoContentSelectedException()
        {
        }

        public NoContentSelectedException(string message) : base(message)
        {
        }

        public NoContentSelectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoContentSelectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}