using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Models;
using OrderSystem.DomainLayer.ServiceLocator;
using System.Collections.Generic;

namespace OrderSystem.DomainLayer.DataLayer
{
    internal sealed class DataFacade
    {
        private readonly ServiceLocatorBase serviceLocator;

        private OrderDataManagerBase orderDataManager;
        private  OrderDataManagerBase OrderDataManager { get { return orderDataManager ?? (orderDataManager = serviceLocator.CreateOrderDataManager()); } }

        public DataFacade(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public long AddProductToInventory(string productName, int quantity)
        {
            return OrderDataManager.AddProductToInventory(productName, quantity);
        }

        public string PlaceOrder(int customerId, long productId, int quantity)
        {
            return OrderDataManager.PlaceOrder(customerId, productId, quantity);
        }

        public IDictionary<string, ProductInStock> GetProductsInStock()
        {
            return OrderDataManager.GetProductsInStock();
        }
    }
}
