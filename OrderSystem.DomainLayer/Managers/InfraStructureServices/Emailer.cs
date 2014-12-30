using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Managers.InfraStructureServices
{
    internal sealed class Emailer : EmailerBase
    {
        protected override void SendEmailCore(int customerId, string subject, string body)
        {
            System.Diagnostics.Debug.WriteLine("Emailer.SendEmailCore");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("customerId: " + customerId);
            System.Diagnostics.Debug.WriteLine("subject: " + subject);
            System.Diagnostics.Debug.WriteLine("body: " + body);
            System.Diagnostics.Debug.Unindent();
        }
    }
}
