using AcceptanceTests.ServiceLocator;
using AcceptanceTests.TestDoubles.Spies.Managers.InfrastructureServices;
using AcceptanceTests.TestMediators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem.DomainLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Exceptions;
using OrderSystem.DomainLayer.Managers.Gateways;
using System;

namespace AcceptanceTests
{
    [TestClass]
    public class DomainFacadeTests
    {
        private static DomainFacade domainFacadeUnderTest;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var serviceLocator = new ServiceLocatorForUnitTesting();
            serviceLocator.OrderDataManagerFactory = () => new OrderDataManager();
            serviceLocator.EmailerFactory = () => new EmailerSpy();
            serviceLocator.WarehouseServiceGatewayFactory = () => new WarehouseServiceGateway();

            domainFacadeUnderTest = new DomainFacade(serviceLocator);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestMediator.Reset();
        }

        [TestMethod]
        [TestCategory("Acceptance Test")]
        public void DomainFacade_PlaceOrder_WhenOrderPlacedWithValidParameters_ShouldPlaceOrder()
        {
            // Arrange
            var irrelevantProductName = "Product_" + Guid.NewGuid().ToString("N");
            var quantityAddedToStock = 50;
            var productId = domainFacadeUnderTest.AddProductToInventory(irrelevantProductName, quantityAddedToStock);
            var irrelevantCustomerId = 99;
            var orderQuantity = quantityAddedToStock - 5;
            var expectedQuanityInStock = quantityAddedToStock - orderQuantity;

            // Act
            var orderNumber = domainFacadeUnderTest.PlaceOrder(irrelevantCustomerId, productId, orderQuantity);

            var productsInStock = domainFacadeUnderTest.GetProductsInStock();
            var actualQuantityInStock = productsInStock[irrelevantProductName].Quantity;

            // Assert
            Assert.IsNotNull(orderNumber);            
            Assert.AreEqual(expectedQuanityInStock, actualQuantityInStock, "The quantity in stock, afer placing an order, was expected to be: " + expectedQuanityInStock.ToString() + ". However, the actual quantity in stock was found to be: " + actualQuantityInStock.ToString());
            Assert.AreEqual(1, TestMediator.PlaceOrderOrderConfirmationEmailsSentCount, "Expected Exactly 1 Order Confirmation email to have been sent. But found: " + TestMediator.PlaceOrderOrderConfirmationEmailsSentCount.ToString() + ", emails were sent");
        }

        [TestMethod]
        [TestCategory("Acceptance Test")]
        public void DomainFacade_PlaceOrder_WhenOrderPlacedWithProductThatIsNotSupported_ShouldThrow()
        {
            // Arrange
            var nonSupportedId = -99999;
            var irrelevantCustomerId = 99;
            var irrelevantQuantity = 1;            

            // Act
            try
            {
                var orderNumber = domainFacadeUnderTest.PlaceOrder(irrelevantCustomerId, nonSupportedId, irrelevantQuantity);
                Assert.Fail("We were expecting an exception of type: ProductNotSupportedException, but no exception was thrown");
            }
            catch (ProductNotSupportedException e)
            {
                // Assert
                var expectedMessagePart = "is Not Supported";
                Assert.IsTrue(e.Message.Contains(expectedMessagePart), "A ProductNotSupportedException was Thrown as expected. However, the exception message was expected to contain: " + expectedMessagePart + ", but the actual exception message was: " + e.Message);
            }
        }

        [TestMethod]
        [TestCategory("Acceptance Test")]
        public void DomainFacade_RetrieveQuantityInStock_WhenProductQuantityExists_ShouldReturnNonZeroQuantity()
        {
            // Arrange
            var productName = "Product_" + Guid.NewGuid().ToString("N");
            var expectedQuantiyInStock = 4;
            domainFacadeUnderTest.AddProductToInventory(productName, expectedQuantiyInStock);

            // Act
            var productsInStock = domainFacadeUnderTest.GetProductsInStock();
            var actualQuantityInStock = productsInStock[productName].Quantity;

            // Assert
            Assert.AreEqual(expectedQuantiyInStock, actualQuantityInStock, string.Format("The expected quantity of the product in stock was : {0}, but the actual quantity found was: {1}", expectedQuantiyInStock, actualQuantityInStock));
        }
    }
}
