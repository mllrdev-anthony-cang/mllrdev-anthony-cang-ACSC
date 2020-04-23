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

        public List<Address> GetBy(Address obj)
        {
            return ((IAddressRepository)Repository).GetBy(obj);            
        }

        public new int SaveEntity(Address obj)
        {
            return Repository.SaveEntity(obj);
        }

        public new bool UpdateEntity(Address obj)
        {
            return Repository.UpdateEntity(obj);
        }

        public new bool RemoveEntity(int[] id)
        {
            return Repository.RemoveEntity(id);
        }
    }
}
