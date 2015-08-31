using OrderSystem.DomainLayer.Exceptions;

namespace AcceptanceTests.TestMediators
{
    static class TestMediator
    {
        public static int PlaceOrderOrderConfirmationEmailsSentCount { get; set; }
        public static ProductNotSupportedException PlaceOrderNotSupportedException { get; set; }

        public static void Reset()
        {
            PlaceOrderOrderConfirmationEmailsSentCount = 0;
            PlaceOrderNotSupportedException = null;
        }
    }
}
