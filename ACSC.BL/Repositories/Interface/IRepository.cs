using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface IRepository<T> where T: class
    {
        int Save(T obj);
        bool Update(T obj);
        bool Delete(int[] id);
    }
}
