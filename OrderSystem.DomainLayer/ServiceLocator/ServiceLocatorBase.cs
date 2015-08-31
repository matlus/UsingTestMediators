using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;

namespace OrderSystem.DomainLayer.ServiceLocator
{
    internal abstract class ServiceLocatorBase
    {
        public OrderManager CreateOrderManager()
        {
            return CreateOrderManagerCore();
        }

        public InventoryManager CreateInventoryManager()
        {
            return CreateInventoryManagerCore();
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
        protected abstract InventoryManager CreateInventoryManagerCore();
        protected abstract EmailerBase CreateEmailerCore();
        protected abstract WarehouseServiceGatewayBase CreateWarehouseServiceGatewayCore();
        protected abstract DataFacade CreateDataFacadeCore();
        protected abstract OrderDataManagerBase CreateOrderDataManagerCore();
    }
}
