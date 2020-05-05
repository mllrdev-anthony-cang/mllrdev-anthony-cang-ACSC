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

        public List<Order> Search(Order obj)
        {
            return ((IOrderRepository)Repository).Search(obj);
        }

        public new int Save(Order obj)
        {
            return Repository.Save(obj);
        }

        public new bool Update(Order obj)
        {
            return Repository.Update(obj);
        }

        public new bool Delete(int[] id)
        {
            return Repository.Delete(id);
        }
    }
}
