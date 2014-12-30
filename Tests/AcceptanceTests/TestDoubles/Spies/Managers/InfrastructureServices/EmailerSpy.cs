using AcceptanceTests.TestMediators;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.TestDoubles.Spies.Managers.InfrastructureServices
{
    class EmailerSpy : EmailerBase
    {
        protected override void SendEmailCore(int customerId, string subject, string body)
        {
            TestMediator.PlaceOrderOrderConfirmationEmailsSentCount++;
        }
    }
}
