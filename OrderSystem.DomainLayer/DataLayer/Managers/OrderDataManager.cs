using System;
using System.Collections.Generic;
using OrderSystem.DomainLayer.Models;
using System.Diagnostics;
using OrderSystem.DomainLayer.Exceptions;
using System.Linq;

namespace OrderSystem.DomainLayer.DataLayer.Managers
{
    internal sealed class OrderDataManager : OrderDataManagerBase
    {
        private Dictionary<string, ProductInStock> items = new Dictionary<string, ProductInStock>();

        protected override long AddProductToInventoryCore(string productName, int quantity)
        {
            Debug.WriteLine("OrderDataManager.AddProductToInventoryCore");
            Debug.Indent();
            Debug.WriteLine("productName: " + productName);
            Debug.WriteLine("quantity: " + quantity);
            Debug.Unindent();

            var id = 0L;

            if (items.ContainsKey(productName))
                id = UpdateProductQuantity(productName, quantity);
            else
            {
                id = Stopwatch.GetTimestamp();
                items.Add(productName, new ProductInStock(id, productName, quantity));
            }

            return id;
        }

        private long UpdateProductQuantity(string productName, int quantity)
        {
            var productInStock = items[productName];
            var id = productInStock.Id;
            items[productName] = new ProductInStock(id, productName, productInStock.Quantity + quantity);
            return id;
        }

        protected override string PlaceOrderCore(int customerId, long productId, int quantity)
        {
            Debug.WriteLine("OrderDataManager.CreateOrderRecordCore");
            Debug.Indent();
            Debug.WriteLine("customerId: " + customerId);
            Debug.WriteLine("productId: " + productId);
            Debug.WriteLine("quantity: " + quantity);
            Debug.Unindent();

            var productName = GetProductName(productId);            
            DeductInventory(productName, quantity);

            return Guid.NewGuid().ToString("N");
        }

        private string GetProductName(long productId)
        {
            return items.Values.Single(p => p.Id == productId).Name;
        }

        private void DeductInventory(string productName, int quantity)
        {
            var productInStock = items[productName];
            var balanceInStock = productInStock.Quantity - quantity;

            if (balanceInStock > 0)
                items[productName] = new ProductInStock(productInStock.Id, productName, balanceInStock);
        }       

        protected override IDictionary<string, ProductInStock> GetProductsInStockCore()
        {
            Debug.WriteLine("OrderDataManager.GetProductsInStockCore");
            return items;
        }

        protected override ProductInStock GetProductStockCore(long productId)
        {
            foreach (var kvp in items)
            {
                if (kvp.Value.Id == productId)
                    return kvp.Value;
            }

            return null;
        }
    }
}
