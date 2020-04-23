using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface IOrderItemRepository: IRepository<OrderItem>
    {
        List<OrderItem> GetBy(OrderItem obj);
    }
}
