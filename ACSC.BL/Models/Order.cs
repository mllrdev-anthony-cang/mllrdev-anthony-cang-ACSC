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
        public string MarkAs { get; set; }
        public bool isValid
        {
            get
            {
                bool isValid = true;

                if (CustomerId < 1) isValid = false;
                if (AddressId < 1) isValid = false;
                if (OrderDate == null) isValid = false;
                if (Math.Round(Convert.ToDouble(TotalAmount), 2) <= 0) isValid = false;
                //if (OrderItems.Count() < 1) valid = false;

                return isValid;
            }
        }
        
    }
}
