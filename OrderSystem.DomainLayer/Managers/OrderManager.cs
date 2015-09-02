using System.Collections.Generic;
using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using OrderSystem.DomainLayer.Managers.Validators;
using OrderSystem.DomainLayer.Models;
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

        public long AddProductToInventory(string productName, int quantity)
        {
            return DataFacade.AddProductToInventory(productName, quantity);
        }

        internal IDictionary<string, ProductInStock> GetProductsInStock()
        {
            return DataFacade.GetProductsInStock();
        }

        public string PlaceOrder(int customerId, long productId, int quantity)
        {
            OrderValidator.EnsureOrderParameters(customerId, productId, quantity);            
            var orderNumber = DataFacade.PlaceOrder(customerId, productId, quantity);
            WarehouseServiceGateway.Ship(orderNumber);
            Emailer.SendEmail(customerId, subject: "Order Confirmation", body: "Your order: " + orderNumber + ", has been received and confirmed. The shipment is on its way!");
            return orderNumber;
        }
    }
}
