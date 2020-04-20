using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface IProductManager: IManager<Product>
    {
        List<Product> GetBy(Product obj);
        bool Save(Product obj);
        bool Remove(Product obj);
        string SearchOperation(Product obj);
        string AddOperation(Product obj);
        string UpdateOperation(Product obj1, Product obj2);
        string DeleteOperation(Product obj);
    }
}
