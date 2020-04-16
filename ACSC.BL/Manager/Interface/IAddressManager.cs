using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface IAddressManager : IManager<Address>
    {
        List<Address> GetBy(Address obj);
        bool Save(Address obj);
        bool Remove(Address obj);
        string SearchOperation(Address obj);
        string AddOperation(Address obj);
        string UpdateOperation(Address obj1, Address obj2);
        string DeleteOperation(Address obj);
    }
}
