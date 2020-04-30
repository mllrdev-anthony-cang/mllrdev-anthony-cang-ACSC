using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Models;
using ACSC.BL.Repositories;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class CustomerOrderHistoryManager: BaseManager<CustomerOrderHistory>, ICustomerOrderHistoryManager
    {
        public override IRepository<CustomerOrderHistory> Repository => new CustomerOrderHistoryRepository();

        public List<CustomerOrderHistory> GetBy(CustomerOrderHistory obj)
        {
            //throw new NotImplementedException();
            return ((ICustomerOrderHistoryRepository)Repository).GetBy(obj);
        }

        public new int Save(CustomerOrderHistory obj)
        {
            throw new NotImplementedException();
        }

        public new bool Update(CustomerOrderHistory obj)
        {
            throw new NotImplementedException();
        }
    }
}
