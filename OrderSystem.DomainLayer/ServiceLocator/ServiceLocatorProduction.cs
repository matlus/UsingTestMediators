using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using System.Diagnostics.CodeAnalysis;

namespace OrderSystem.DomainLayer.ServiceLocator
{
    [ExcludeFromCodeCoverage]
    internal sealed class ServiceLocatorProduction : ServiceLocatorBase
    {
        protected override OrderManager CreateOrderManagerCore()
        {
            return new OrderManager(this);
        }

        protected override EmailerBase CreateEmailerCore()
        {
            return new Emailer();
        }

        protected override WarehouseServiceGatewayBase CreateWarehouseServiceGatewayCore()
        {
            return new WarehouseServiceGateway();
        }

        protected override DataFacade CreateDataFacadeCore()
        {
            return new DataFacade(this);
        }

        protected override OrderDataManagerBase CreateOrderDataManagerCore()
        {
            return new OrderDataManager();
        }
    }
}
