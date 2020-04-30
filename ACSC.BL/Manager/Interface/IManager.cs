using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Manager.Interface
{
    public interface IManager<T> where T : class
    {
        int Save(T obj);
        bool Update(T obj);
        bool Delete(int[] id);
    }
}
