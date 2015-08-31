using AcceptanceTests.TestMediators;
using OrderSystem.DomainLayer.Managers.Gateways;

namespace AcceptanceTests.TestDoubles.Spies.Managers.Gateways
{
    class WarehouseServiceGatewaySpy : WarehouseServiceGatewayBase
    {
        protected override void RemoveCore(string productName, int quantity)
        {
            if (TestMediator.PlaceOrderNotSupportedException != null)
                throw TestMediator.PlaceOrderNotSupportedException;
        }
    }
}
