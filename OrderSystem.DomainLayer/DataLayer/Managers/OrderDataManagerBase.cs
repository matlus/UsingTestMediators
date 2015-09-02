using OrderSystem.DomainLayer.Models;
using System.Collections.Generic;

namespace OrderSystem.DomainLayer.DataLayer.Managers
{
    internal abstract class OrderDataManagerBase
    {
        public long AddProductToInventory(string productName, int quantity)
        {
            return AddProductToInventoryCore(productName, quantity);
        }

        public IDictionary<string,ProductInStock> GetProductsInStock()
        {
            return GetProductsInStockCore();
        }

        public ProductInStock GetProductStock(long productId)
        {
            return GetProductStockCore(productId);
        }

        public string PlaceOrder(int customerId, long productId, int quantity)
        {
            return PlaceOrderCore(customerId, productId, quantity);
        }

        protected abstract long AddProductToInventoryCore(string productName, int quantity);
        protected abstract IDictionary<string, ProductInStock> GetProductsInStockCore();
        protected abstract ProductInStock GetProductStockCore(long productId);
        protected abstract string PlaceOrderCore(int customerId, long productId, int quantity);
    }
}
