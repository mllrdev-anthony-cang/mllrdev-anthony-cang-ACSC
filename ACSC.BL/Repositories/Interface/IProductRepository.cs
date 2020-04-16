using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface IProductRepository: IRepository<Product>
    {
        List<Product> GetBy(Product product);
        bool Save(Product product);
        bool Remove(Product product);
        string SearchOperation(Product product);
        string AddOperation(Product product);
        string UpdateOperation(Product product1, Product product2);
        string DeleteOperation(Product product);
    }
}
