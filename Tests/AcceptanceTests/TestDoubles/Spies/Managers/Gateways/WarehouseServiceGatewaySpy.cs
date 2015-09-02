using AcceptanceTests.TestMediators;
using OrderSystem.DomainLayer.Managers.Gateways;

namespace AcceptanceTests.TestDoubles.Spies.Managers.Gateways
{
    class WarehouseServiceGatewaySpy : WarehouseServiceGatewayBase
    {
        protected override void ShipCore(string orderNumber)
        {
            if (TestMediator.PlaceOrderNotSupportedException != null)
                throw TestMediator.PlaceOrderNotSupportedException;
        }
    }
}
