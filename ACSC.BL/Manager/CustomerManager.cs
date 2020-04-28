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
        public new int Save(Customer obj)
        {
            return Repository.Save(obj);
        }

        public new bool Update(Customer obj)
        {
            return Repository.Update(obj);
        }

        public new bool Delete(int[] id)
        {
            return Repository.Delete(id);
        }
    }
}
