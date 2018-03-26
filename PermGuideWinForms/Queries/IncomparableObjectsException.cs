using System;
using System.Runtime.Serialization;

namespace PermGuideWinForms.Queries
{
    [Serializable]
    public class IncomparableObjectsException : Exception
    {
        public IncomparableObjectsException() :
            base("Тип должен реализовывать интерфейс IComparable<T>.")
        {
        }

        public IncomparableObjectsException(string message) : base(message)
        {
        }

        public IncomparableObjectsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncomparableObjectsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}