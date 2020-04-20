using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface ICustomerManager: IManager<Customer>
    {
        List<Customer> GetBy(Customer obj);
        bool Save(Customer obj);
        bool Remove(Customer obj);
        string SearchOperation(Customer obj);
        string AddOperation(Customer obj);
        string UpdateOperation(Customer obj1, Customer obj2);
        string DeleteOperation(Customer obj);
    }
}
