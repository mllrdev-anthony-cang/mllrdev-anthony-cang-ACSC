﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Repositories.Interface
{
    public interface IAddressRepository: IRepository<Address>
    {
        List<Address> Search(Address obj);
    }
}
