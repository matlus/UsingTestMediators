using AcceptanceTests.TestMediators;
using OrderSystem.DomainLayer.Managers.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
