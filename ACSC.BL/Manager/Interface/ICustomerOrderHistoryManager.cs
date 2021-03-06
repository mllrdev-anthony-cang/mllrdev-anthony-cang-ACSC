﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Models;

namespace ACSC.BL.Manager.Interface
{
    public interface ICustomerOrderHistoryManager: IManager<CustomerOrderHistory>
    {
        List<CustomerOrderHistory> GetBy(CustomerOrderHistory obj);
    }
}
