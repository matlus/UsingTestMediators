namespace OrderSystem.DomainLayer.Managers.Gateways
{
    internal sealed class WarehouseServiceGateway : WarehouseServiceGatewayBase
    {
        protected override void ShipCore(string orderNumber)
        {
            System.Diagnostics.Debug.WriteLine("WarehouseServiceGateway.ShipCore");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("Order Number: " + orderNumber);
            System.Diagnostics.Debug.Unindent();
        }
    }
}
