using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Managers.Gateways
{
    internal sealed class WarehouseServiceGateway : WarehouseServiceGatewayBase
    {
        protected override void RemoveCore(string productName, int quantity)
        {
            System.Diagnostics.Debug.WriteLine("WarehouseServiceGateway.RemoveCore");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("productName: " + productName);
            System.Diagnostics.Debug.WriteLine("quantity: " + quantity);
            System.Diagnostics.Debug.Unindent();
        }
    }
}
