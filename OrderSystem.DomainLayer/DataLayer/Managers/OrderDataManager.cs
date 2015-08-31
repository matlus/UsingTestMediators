using System;

namespace OrderSystem.DomainLayer.DataLayer.Managers
{
    internal sealed class OrderDataManager : OrderDataManagerBase
    {
        protected override string CreateOrderRecordCore(int customerId, string productName, int quantity)
        {
            System.Diagnostics.Debug.WriteLine("OrderManager.CreateOrderRecordCore");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("customerId: " + customerId);
            System.Diagnostics.Debug.WriteLine("productName: " + productName);
            System.Diagnostics.Debug.WriteLine("quantity: " + quantity);
            System.Diagnostics.Debug.Unindent();

            return Guid.NewGuid().ToString("N");
        }
    }
}
