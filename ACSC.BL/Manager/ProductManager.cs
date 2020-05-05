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
        
        public List<Product> Search(Product obj)
        {
            return ((IProductRepository)Repository).Search(obj);
        }
        public new int Save(Product obj)
        {
            return Repository.Save(obj);
        }

        public new bool Update(Product obj)
        {
            return Repository.Update(obj);
        }

        public new bool Delete(int[] id)
        {
            return Repository.Delete(id);
        }
    }
}
