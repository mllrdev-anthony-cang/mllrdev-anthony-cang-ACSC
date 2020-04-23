﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface IRepository<T> where T: class
    {
        int SaveEntity(T obj);
        bool UpdateEntity(T obj);
        bool RemoveEntity(int[] id);
    }
}
