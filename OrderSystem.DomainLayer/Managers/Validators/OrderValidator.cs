﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.DomainLayer.Managers.Validators
{
    internal static class OrderValidator
    {
        internal static void EnsureOrderParameters(int customerId, string productName, int quantity)
        {
            // TODO: Validate all prameters and throw a specific business exception if there are validation issues, indicating clearly the issue(s) found.
        }
    }
}