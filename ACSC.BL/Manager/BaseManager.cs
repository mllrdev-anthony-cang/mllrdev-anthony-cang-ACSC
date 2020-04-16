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
        
    }
}
