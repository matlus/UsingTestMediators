namespace OrderSystem.DomainLayer.Managers.Gateways
{
    internal abstract class WarehouseServiceGatewayBase
    {
        public void Ship(string orderNumber)
        {
            ShipCore(orderNumber);
        }

        protected abstract void ShipCore(string orderNumber);
    }
}
