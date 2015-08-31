using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

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
