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
    public sealed class ProductNotSupportedException : OrderSystemBusinessBaseException
    {
        public ProductNotSupportedException() {}
        public ProductNotSupportedException(string message) : base(message) {}
        public ProductNotSupportedException(string message, Exception inner) : base(message, inner) {}
        private ProductNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
