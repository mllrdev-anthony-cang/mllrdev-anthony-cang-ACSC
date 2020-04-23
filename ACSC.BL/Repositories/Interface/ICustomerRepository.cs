using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        List<Customer> GetBy(Customer obj);
    }
}
