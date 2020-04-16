using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface IOrderManager: IManager<Order>
    {
        List<Order> GetBy(Order obj);
        bool Save(Order obj);
        bool Remove(Order obj);
        List<Order> GetLastId();
    }
}
