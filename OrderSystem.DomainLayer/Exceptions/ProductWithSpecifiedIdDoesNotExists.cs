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
    public sealed class ProductWithSpecifiedIdDoesNotExists : OrderSystemBusinessBaseException
    {
        public ProductWithSpecifiedIdDoesNotExists() { }
        public ProductWithSpecifiedIdDoesNotExists(string message) : base(message) { }
        public ProductWithSpecifiedIdDoesNotExists(string message, Exception inner) : base(message, inner) { }
        private ProductWithSpecifiedIdDoesNotExists(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
