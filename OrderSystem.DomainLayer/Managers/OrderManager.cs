using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using OrderSystem.DomainLayer.Managers.Validators;
using OrderSystem.DomainLayer.ServiceLocator;

namespace OrderSystem.DomainLayer.Managers
{
    internal sealed class OrderManager
    {
        private readonly ServiceLocatorBase serviceLocator;

        private DataFacade dataFacade;
        private DataFacade DataFacade { get { return dataFacade ?? (dataFacade = serviceLocator.CreateDataFacade()); } }

        private WarehouseServiceGatewayBase warehouseServiceGateway;
        private WarehouseServiceGatewayBase WarehouseServiceGateway { get { return warehouseServiceGateway ?? (warehouseServiceGateway = serviceLocator.CreateWarehouseServiceGateway()); } }

        private EmailerBase emailer;
        private EmailerBase Emailer { get { return emailer ?? (emailer = serviceLocator.CreateEmailer()); } }

        public OrderManager(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public string PlaceOrder(int customerId, string productName, int quantity)
        {
            OrderValidator.EnsureOrderParameters(customerId, productName, quantity);
            WarehouseServiceGateway.Remove(productName, quantity);
            var orderNumber = DataFacade.CreateOrderRecord(customerId, productName, quantity);
            Emailer.SendEmail(customerId, subject: "Order Confirmation", body: "Your order: " + orderNumber + ", has been received and confirmed. The shipment is on its way!");
            return orderNumber;
        }
    }
}
