using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface IProductRepository<T> where T : class
    {
        
        List<T> GetBy(T obj);
        bool Save(T obj);
        bool Remove(T obj);
    }
}
