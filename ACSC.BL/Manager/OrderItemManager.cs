using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class OrderItemManager : BaseManager<OrderItem>, IOrderItemManager
    {
        public override IRepository<OrderItem> Repository => new OrderItemRepository();

        public List<OrderItem> Search(OrderItem obj)
        {
            return ((IOrderItemRepository)Repository).Search(obj);
        }

        public new int Save(OrderItem obj)
        {
            return Repository.Save(obj);
        }
    }
}
