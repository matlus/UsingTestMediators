using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystem.DomainLayer;
using AcceptanceTests.ServiceLocator;
using OrderSystem.DomainLayer.Managers;
using OrderSystem.DomainLayer.Managers.InfraStructureServices;
using OrderSystem.DomainLayer.Managers.Gateways;
using OrderSystem.DomainLayer.DataLayer;
using OrderSystem.DomainLayer.DataLayer.Managers;
using AcceptanceTests.TestMediators;
using AcceptanceTests.TestDoubles.Spies.Managers.InfrastructureServices;
using OrderSystem.DomainLayer.Exceptions;
using AcceptanceTests.TestDoubles.Spies.Managers.Gateways;

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
            serviceLocator.WarehouseServiceGatewayFactory = () => new WarehouseServiceGatewaySpy();

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


            // Act
            var orderNumber = domainFacadeUnderTest.PlaceOrder(1, "A Mind of its Own", 1);

            // Assert
            Assert.IsNotNull(orderNumber);
            Assert.AreEqual(1, TestMediator.PlaceOrderOrderConfirmationEmailsSentCount, "Expected Exactly 1 Order Confirmation email to have been sent. But found: " + TestMediator.PlaceOrderOrderConfirmationEmailsSentCount.ToString() + ", emails were sent");
        }

        [TestMethod]
        [TestCategory("Acceptance Test")]
        public void DomainFacade_PlaceOrder_WhenOrderPlacedWithNonSupportedProduct_ShouldThrow()
        {
            // Arrange
            var nonSupportedProduct = "xxxxxxxx";
            TestMediator.PlaceOrderNotSupportedException = new ProductNotSupportedException("This product, is Not Supported");

            // Act
            try
            {
                var orderNumber = domainFacadeUnderTest.PlaceOrder(1, nonSupportedProduct, 1);
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
        [ExpectedException(typeof(UnSupportedProductCanNotBeAddedToInventoryException))]
        public void DomainFacade_AddProductToInventory_WhenProductBeingAddedIsNotSupported_ShouldThrow()
        {
            // Arrange

            // Act
            domainFacadeUnderTest.AddProductToInventory(-1, 10);
            Assert.Fail("An UnSupportedProductCanNotBeAddedToInventoryException was expected to be throw, but no Exception was thrown");

            // Assert
        }
    }
}
