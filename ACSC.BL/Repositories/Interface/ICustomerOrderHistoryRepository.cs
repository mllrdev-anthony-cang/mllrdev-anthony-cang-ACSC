using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Models;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager.Interface
{
    public interface ICustomerOrderHistoryRepository : IRepository<CustomerProductOrderHistory>
    {
        List<CustomerProductOrderHistory> Search(CustomerProductOrderHistory obj);
    }
}
