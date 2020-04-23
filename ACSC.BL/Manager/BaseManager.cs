using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public abstract class BaseManager<T> where T: class
    {
        public abstract IRepository<T> Repository { get; }
        
        public int SaveEntity(T obj)
        {
            return Repository.SaveEntity(obj);
        }

        public bool UpdateEntity(T obj)
        {
            return Repository.UpdateEntity(obj);
        }

        public bool RemoveEntity(int[] id)
        {
            return Repository.RemoveEntity(id);
        }
    }
}
