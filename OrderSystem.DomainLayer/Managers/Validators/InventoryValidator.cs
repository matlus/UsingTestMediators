using OrderSystem.DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Managers.Validators
{
    internal class InventoryValidator
    {
        public static void EnsureProductIsSupported(int productId)
        {
            throw new UnSupportedProductCanNotBeAddedToInventoryException("No Product with an id of: " + productId.ToString() + ", is supported. Can not add unsupported product to inventory");
        }
    }
}
