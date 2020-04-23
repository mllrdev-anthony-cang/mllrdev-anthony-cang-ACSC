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

        public new int SaveEntity(Order obj)
        {
            return Repository.SaveEntity(obj);
        }

        public new bool UpdateEntity(Order obj)
        {
            return Repository.UpdateEntity(obj);
        }

        public new bool RemoveEntity(int[] id)
        {
            return Repository.RemoveEntity(id);
        }
    }
}
