using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class CustomerManager: BaseManager<Customer>, ICustomerManager
    {
        public override IRepository<Customer> Repository => new CustomerRepository();

        public string AddOperation(Customer obj)
        {
            return ((ICustomerRepository)Repository).AddOperation(obj);
        }

        public string DeleteOperation(Customer obj)
        {
            return ((ICustomerRepository)Repository).DeleteOperation(obj);
        }

        public List<Customer> GetBy(Customer obj)
        {
            return ((ICustomerRepository)Repository).GetBy(obj);
        }

        public bool Remove(Customer obj)
        {
            return ((ICustomerRepository)Repository).Remove(obj);
        }

        public bool Save(Customer obj)
        {
            return ((ICustomerRepository)Repository).Save(obj);
        }

        public string SearchOperation(Customer obj)
        {
            return ((ICustomerRepository)Repository).SearchOperation(obj);
        }

        public string UpdateOperation(Customer obj1, Customer obj2)
        {
            return ((ICustomerRepository)Repository).UpdateOperation(obj1,obj2);
        }
    }
}
