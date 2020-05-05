using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface IAddressManager : IManager<Address>
    {
        List<Address> Search(Address obj);
    }
}
