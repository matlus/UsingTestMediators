using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Managers.InfraStructureServices
{
    internal abstract class EmailerBase
    {
        public void SendEmail(int customerId, string subject, string body)
        {
            SendEmailCore(customerId, subject, body);
        }

        protected abstract void SendEmailCore(int customerId, string subject, string body);
    }
}
