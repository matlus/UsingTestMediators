using AcceptanceTests.TestMediators;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;

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
