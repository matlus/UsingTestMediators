using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
