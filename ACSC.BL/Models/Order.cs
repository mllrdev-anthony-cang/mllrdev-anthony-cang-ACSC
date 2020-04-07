using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string MinOrderDate { get; set; }
        public string MaxOrderDate { get; set; }

        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string ShippingAddress { get; set; }
        public bool Validate
        {
            get
            {
                bool valid = true;

                if (CustomerId < 1) valid = false;
                if (AddressId < 1) valid = false;
                if (OrderDate == null) valid = false;
                if (Math.Round(Convert.ToDouble(TotalAmount), 2) <= 0) valid = false;
                //if (OrderItems.Count() < 1) valid = false;

                return valid;
            }
        }
        
    }
}
