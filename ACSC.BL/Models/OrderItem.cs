﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string MarkAs { get; set; }
        public string OrderItemProductName { get; set; }
        public string OrderItemProductDescription { get; set; }
        
        public bool isValid
        {
            get
            {
                bool isValid = true;

                if (OrderId < 1) isValid = false;
                if (ProductId < 1) isValid = false;
                if (Math.Round(Convert.ToDouble(Quantity), 0) <= 0) isValid = false;
                if (Math.Round(Convert.ToDouble(PurchasePrice), 2) <= 0) isValid = false;

                return isValid;
            }
        }

    }
}
