using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class UnSupportedProductCanNotBeAddedToInventoryException : OrderSystemBusinessBaseException
    {
        public UnSupportedProductCanNotBeAddedToInventoryException() { }
        public UnSupportedProductCanNotBeAddedToInventoryException(string message) : base(message) { }
        public UnSupportedProductCanNotBeAddedToInventoryException(string message, Exception inner) : base(message, inner) { }
        private UnSupportedProductCanNotBeAddedToInventoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
