using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface IOrderItemManager : IManager<OrderItem>
    {
        List<OrderItem> Search(OrderItem obj);
    }
}
