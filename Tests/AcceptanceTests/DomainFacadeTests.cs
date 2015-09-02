using AcceptanceTests.ServiceLocator;
using AcceptanceTests.TestDoubles.Spies.Managers.Gateways;
using AcceptanceTests.TestDoubles.Spies.Managers.InfrastructureServices;
using AcceptanceTests.TestMediators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem.DomainLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using OrderSystem.DomainLayer.Exceptions;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
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
            serviceLocator.EmailerFactory = () => new Emailer();
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
        public void DomainFacade_PlaceOrder_WhenOrderPlacedWithSupportedProduct_ShouldPlaceOrder()
        {
            // Arrange
            var irrelevantProductName = "Product_" + Guid.NewGuid().ToString("N");
            var originalQuantityInStock = 50;
            var productId = domainFacadeUnderTest.AddProductToInventory(irrelevantProductName, originalQuantityInStock);
            var irrelevantCustomerId = 99;
            var orderQuantity = originalQuantityInStock - 5;

            // Act
            var orderNumber = domainFacadeUnderTest.PlaceOrder(irrelevantCustomerId, productId, orderQuantity);

            // Assert
            Assert.IsNotNull(orderNumber);
            var productsInStock = domainFacadeUnderTest.GetProductsInStock();
            var quantityInStock = productsInStock[irrelevantProductName].Quantity;
            Assert.AreEqual(originalQuantityInStock - orderQuantity, quantityInStock);
            //Assert.AreEqual(1, TestMediator.PlaceOrderOrderConfirmationEmailsSentCount, "Expected Exactly 1 Order Confirmation email to have been sent. But found: " + TestMediator.PlaceOrderOrderConfirmationEmailsSentCount.ToString() + ", emails were sent");
        }

        [TestMethod]
        [TestCategory("Acceptance Test")]
        public void DomainFacade_PlaceOrder_WhenOrderPlacedWithNonSupportedProduct_ShouldThrow()
        {
            // Arrange
            var nonSupportedId = -99999;
            var irrelevantCustomerId = 1;
            var irrelevantQuantity = 1;
            TestMediator.PlaceOrderNotSupportedException = new ProductNotSupportedException("This product, is Not Supported");

            // Act
            try
            {
                var orderNumber = domainFacadeUnderTest.PlaceOrder(irrelevantCustomerId, nonSupportedId, irrelevantQuantity);
                Assert.Fail("We were expecting an exception of type: ProductNotSupportedException, but no exception was thrown");
            }
            catch (ProductNotSupportedException e)
            {
                // Assert
                var expectedMessagePart = "Not Supported";
                Assert.IsTrue(e.Message.Contains(expectedMessagePart), "A ProductNotSupportedException was Thrown as expected. However, the exception message was expected to contain: " + expectedMessagePart + ", but the actual exception message was: " + e.Message);
            }
        }

        [TestMethod]
        [TestCategory("Acceptance Test")]
        public void DomainFacade_RetrieveQuantityInStock_WhenProductQuantityExists_ShouldReturnNonZeroQuantity()
        {
            // Arrange
            var expectedQuantiyInStock = 4;

            // Act
            var actualQuantityInStock = 3;

            // Assert
            Assert.AreEqual(expectedQuantiyInStock, actualQuantityInStock, string.Format("The expected quantity of the product in stock was : {0}, but the actual quantity found was: {1}", expectedQuantiyInStock, actualQuantityInStock));
        }
    }
}
