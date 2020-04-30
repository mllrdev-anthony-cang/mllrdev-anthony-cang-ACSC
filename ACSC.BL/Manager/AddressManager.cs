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

        public new int Save(Address obj)
        {
            return Repository.Save(obj);
        }

        public new bool Update(Address obj)
        {
            return Repository.Update(obj);
        }

        public new bool Delete(int[] id)
        {
            return Repository.Delete(id);
        }
    }
}
