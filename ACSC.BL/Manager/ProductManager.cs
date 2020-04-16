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

        public bool Save(Product obj)
        {
            return ((IProductRepository)Repository).Save(obj);
        }

        public bool Remove(Product obj)
        {
            return ((IProductRepository)Repository).Remove(obj);
        }

        public string SearchOperation(Product obj)
        {
            return ((IProductRepository)Repository).SearchOperation(obj);
        }

        public string AddOperation(Product obj)
        {
            return ((IProductRepository)Repository).AddOperation(obj);
        }

        public string UpdateOperation(Product obj1, Product obj2)
        {
            return ((IProductRepository)Repository).UpdateOperation(obj1, obj2);
        }

        public string DeleteOperation(Product obj)
        {
            return ((IProductRepository)Repository).DeleteOperation(obj);
        }
    }
}
