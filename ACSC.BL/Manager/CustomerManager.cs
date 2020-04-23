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

        public List<Customer> GetBy(Customer obj)
        {
            return ((ICustomerRepository)Repository).GetBy(obj);
        }
        public new int SaveEntity(Customer obj)
        {
            return Repository.SaveEntity(obj);
        }

        public new bool UpdateEntity(Customer obj)
        {
            return Repository.UpdateEntity(obj);
        }

        public new bool RemoveEntity(int[] id)
        {
            return Repository.RemoveEntity(id);
        }
    }
}
