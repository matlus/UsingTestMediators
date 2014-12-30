using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.ServiceLocator
{
    internal abstract class ServiceLocatorBase
    {
        public OrderManager CreateOrderManager()
        {
            return CreateOrderManagerCore();
        }

        public EmailerBase CreateEmailer()
        {
            return CreateEmailerCore();
        }

        public WarehouseServiceGatewayBase CreateWarehouseServiceGateway()
        {
            return CreateWarehouseServiceGatewayCore();
        }

        public DataFacade CreateDataFacade()
        {
            return CreateDataFacadeCore();
        }

        public OrderDataManagerBase CreateOrderDataManager()
        {
            return CreateOrderDataManagerCore();
        }

        protected abstract OrderManager CreateOrderManagerCore();
        protected abstract EmailerBase CreateEmailerCore();
        protected abstract WarehouseServiceGatewayBase CreateWarehouseServiceGatewayCore();
        protected abstract DataFacade CreateDataFacadeCore();
        protected abstract OrderDataManagerBase CreateOrderDataManagerCore();
    }
}
