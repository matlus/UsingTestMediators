using OrderSystem.DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
