using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using OrderSystem.DomainLayer.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.ServiceLocator
{
    class ServiceLocatorForUnitTesting : ServiceLocatorBase
    {
        public Func<EmailerBase> EmailerFactory { get; set; }
        public Func<WarehouseServiceGatewayBase> WarehouseServiceGatewayFactory { get; set; }
        public Func<OrderDataManagerBase> OrderDataManagerFactory { get; set; }

        protected override OrderManager CreateOrderManagerCore()
        {
            return new OrderManager(this);
        }

        protected override EmailerBase CreateEmailerCore()
        {
            if (EmailerFactory == null)
                throw new NotImplementedException("In order to use the CreateEmailer method in the ServiceLocatorForUnit Testing class, you MUST assign the EmailerFactory delegate with a valid delegate instance.");
            return EmailerFactory();
        }

        protected override WarehouseServiceGatewayBase CreateWarehouseServiceGatewayCore()
        {
            if (WarehouseServiceGatewayFactory == null)
                throw new NotImplementedException("In order to use the CreateWarehouseServiceGateway method in the ServiceLocatorForUnit Testing class, you MUST assign the WarehouseServiceGatewayFactory delegate with a valid delegate instance.");
            return WarehouseServiceGatewayFactory();
        }

        protected override DataFacade CreateDataFacadeCore()
        {
            return new DataFacade(this);
        }

        protected override OrderDataManagerBase CreateOrderDataManagerCore()
        {
            if (OrderDataManagerFactory == null)
                throw new NotImplementedException("In order to use the CreateOrderDataManager method in the ServiceLocatorForUnit Testing class, you MUST assign the OrderDataManagerFactory delegate with a valid delegate instance.");
            return OrderDataManagerFactory();
        }
    }
}
