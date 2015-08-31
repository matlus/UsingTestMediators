using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.ServiceLocator;

namespace OrderSystem.DomainLayer.DataLayer
{
    internal sealed class DataFacade
    {
        private readonly ServiceLocatorBase serviceLocator;

        private OrderDataManagerBase orderDataManager;
        private  OrderDataManagerBase OrderDataManager { get { return orderDataManager ?? (orderDataManager = serviceLocator.CreateOrderDataManager()); } }
        public DataFacade(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public string CreateOrderRecord(int customerId, string productName, int quantity)
        {
            return OrderDataManager.CreateOrderRecord(customerId, productName, quantity);
        }
    }
}
