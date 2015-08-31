using OrderSystem.DomainLayer.Exceptions;

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
