namespace OrderSystem.DomainLayer.Managers.Gateways
{
    internal abstract class WarehouseServiceGatewayBase
    {
        public void Remove(string productName, int quantity)
        {
            RemoveCore(productName, quantity);
        }

        protected abstract void RemoveCore(string productName, int quantity);
    }
}
