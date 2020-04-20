using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class OrderManager : BaseManager<Order>, IOrderManager
    {
        public override IRepository<Order> Repository => new OrderRepository();

        public List<Order> GetBy(Order obj)
        {
            return ((IOrderRepository)Repository).GetBy(obj);
        }

        public List<Order> GetLastId()
        {
            return ((IOrderRepository)Repository).GetLastId();
        }

        public bool Remove(Order obj)
        {
            return ((IOrderRepository)Repository).Remove(obj);
        }

        public bool Save(Order obj)
        {
            return ((IOrderRepository)Repository).Save(obj);
        }
    }
}
