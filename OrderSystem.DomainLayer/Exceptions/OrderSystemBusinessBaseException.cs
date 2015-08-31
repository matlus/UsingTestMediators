using System;
using System.Runtime.Serialization;

namespace OrderSystem.DomainLayer.Exceptions
{
    [Serializable]
    public class OrderSystemBusinessBaseException : Exception
    {
        public OrderSystemBusinessBaseException() { }
        public OrderSystemBusinessBaseException(string message) : base(message) { }
        public OrderSystemBusinessBaseException(string message, Exception inner) : base(message, inner) { }
        protected OrderSystemBusinessBaseException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
