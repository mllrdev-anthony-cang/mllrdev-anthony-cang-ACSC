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
    public class CustomerOrderHistoryManager: BaseManager<CustomerProductOrderHistory>, ICustomerOrderHistoryManager
    {
        public override IRepository<CustomerProductOrderHistory> Repository => new CustomerOrderHistoryRepository();

        public List<CustomerProductOrderHistory> Search(CustomerProductOrderHistory obj)
        {
            //throw new NotImplementedException();
            return ((ICustomerOrderHistoryRepository)Repository).Search(obj);
        }

        public new int Save(CustomerProductOrderHistory obj)
        {
            throw new NotImplementedException();
        }

        public new bool Update(CustomerProductOrderHistory obj)
        {
            throw new NotImplementedException();
        }
    }
}
