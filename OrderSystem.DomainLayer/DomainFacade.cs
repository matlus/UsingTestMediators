using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.Models;
using OrderSystem.DomainLayer.ServiceLocator;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OrderSystem.DomainLayer
{
    public sealed class DomainFacade
    {
        private readonly ServiceLocatorBase serviceLocator;

        private OrderManager orderManager;
        private OrderManager OrderManager { get { return orderManager ?? (orderManager = serviceLocator.CreateOrderManager()); } }

        [ExcludeFromCodeCoverage]
        public DomainFacade()
            :this(new ServiceLocatorProduction())
        {
        }

        internal DomainFacade(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public long AddProductToInventory(string productName, int quantity)
        {
            return OrderManager.AddProductToInventory(productName, quantity);
        }

        public IDictionary<string, ProductInStock> GetProductsInStock()
        {
            return OrderManager.GetProductsInStock();
        }

        public string PlaceOrder(int customerId, long productId, int quantity)
        {
            return OrderManager.PlaceOrder(customerId, productId, quantity);
        }
    }
}
