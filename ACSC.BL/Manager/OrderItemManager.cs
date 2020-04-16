﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Manager
{
    public class OrderItemManager : BaseManager<OrderItem>, IOrderItemManager
    {
        public override IRepository<OrderItem> Repository => new OrderItemRepository();

        public List<OrderItem> GetBy(OrderItem obj)
        {
            return ((IOrderItemRepository)Repository).GetBy(obj);
        }

        public bool Remove(OrderItem obj)
        {
            return ((IOrderItemRepository)Repository).Remove(obj);
        }

        public bool Save(OrderItem obj)
        {
            return ((IOrderItemRepository)Repository).Save(obj);
        }
    }
}
