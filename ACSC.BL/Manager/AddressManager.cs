using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class AddressManager: BaseManager<Address>, IAddressManager
    {
        public override IRepository<Address> Repository => new AddressRepository();

        public string AddOperation(Address obj)
        {
            return ((IAddressRepository)Repository).AddOperation(obj);
        }

        public string DeleteOperation(Address obj)
        {
            return ((IAddressRepository)Repository).DeleteOperation(obj);
        }

        public List<Address> GetBy(Address obj)
        {
            return ((IAddressRepository)Repository).GetBy(obj);
        }

        public bool Remove(Address obj)
        {
            return ((IAddressRepository)Repository).Remove(obj);
        }

        public bool Save(Address obj)
        {
            return ((IAddressRepository)Repository).Save(obj);
        }

        public string SearchOperation(Address obj)
        {
            return ((IAddressRepository)Repository).SearchOperation(obj);
        }

        public string UpdateOperation(Address obj1, Address obj2)
        {
            return ((IAddressRepository)Repository).UpdateOperation(obj1,obj2);
        }
    }
}
