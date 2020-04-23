using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        public override IRepository<Product> Repository => new ProductRepository();
        
        public List<Product> GetBy(Product obj)
        {
            return ((IProductRepository)Repository).GetBy(obj);
        }
        public new int SaveEntity(Product obj)
        {
            return Repository.SaveEntity(obj);
        }

        public new bool UpdateEntity(Product obj)
        {
            return Repository.UpdateEntity(obj);
        }

        public new bool RemoveEntity(int[] id)
        {
            return Repository.RemoveEntity(id);
        }
    }
}
