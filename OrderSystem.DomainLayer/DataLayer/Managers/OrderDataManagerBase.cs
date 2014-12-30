using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.DataLayer.Managers
{
    internal abstract class OrderDataManagerBase
    {
        public string CreateOrderRecord(int customerId, string productName, int quantity)
        {
            return CreateOrderRecordCore(customerId, productName, quantity);
        }

        protected abstract string CreateOrderRecordCore(int customerId, string productName, int quantity);
    }
}
