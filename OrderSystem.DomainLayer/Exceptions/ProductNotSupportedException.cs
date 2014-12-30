using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public sealed class ProductNotSupportedException : OrderSystemBusinessBaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotSupportedExceptionException"/> class.
        /// </summary>
        public ProductNotSupportedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotSupportedExceptionException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ProductNotSupportedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotSupportedExceptionException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public ProductNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductNotSupportedExceptionException"/> class.
        /// </summary>
        /// <param name="info">The serialization information instance.</param>
        /// <param name="context">The serialization streaming context instance.</param>
        private ProductNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
