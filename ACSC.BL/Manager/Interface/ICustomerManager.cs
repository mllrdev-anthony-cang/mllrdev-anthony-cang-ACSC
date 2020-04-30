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
    }
}
