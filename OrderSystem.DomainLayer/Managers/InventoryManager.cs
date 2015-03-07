using OrderSystem.DomainLayer.Managers.Validators;
using OrderSystem.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Managers
{
    internal sealed class InventoryManager
    {
        private readonly ServiceLocatorBase serviceLocator;

        public InventoryManager(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void AddProductToInventory(int productId, int quantity)
        {
            InventoryValidator.EnsureProductIsSupported(productId);
            // Now add the product to the inventory
        }
    }
}
