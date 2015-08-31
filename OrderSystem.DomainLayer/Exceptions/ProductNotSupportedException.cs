using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace OrderSystem.DomainLayer.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class ProductNotSupportedException : OrderSystemBusinessBaseException
    {
        public ProductNotSupportedException() {}
        public ProductNotSupportedException(string message) : base(message) {}
        public ProductNotSupportedException(string message, Exception inner) : base(message, inner) {}
        private ProductNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
