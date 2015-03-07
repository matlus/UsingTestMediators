using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer
{
    public class DomainFacade
    {
        private readonly ServiceLocatorBase serviceLocator;

        private OrderManager orderManager;
        private OrderManager OrderManager { get { return orderManager ?? (orderManager = serviceLocator.CreateOrderManager()); } }

        private InventoryManager inventoryManager;
        private InventoryManager InventoryManager { get { return inventoryManager ?? (inventoryManager = serviceLocator.CreateInventoryManager()); } }

        public DomainFacade()
            :this(new ServiceLocatorProduction())
        {
        }

        internal DomainFacade(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public string PlaceOrder(int customerId, string productName, int quantity)
        {
            return OrderManager.PlaceOrder(customerId, productName, quantity);
        }

        public void AddProductToInventory(int productId, int quantity)
        {
            InventoryManager.AddProductToInventory(productId, quantity);
        }
    }
}
