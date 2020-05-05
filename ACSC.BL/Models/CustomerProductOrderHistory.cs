using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Models
{
    public class CustomerProductOrderHistory
    {        
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string MinOrderDate { get; set; }
        public string MaxOrderDate { get; set; }

        //ProductId, CustomerId, ProductName, Purchase Price, Quantity, OrderDate, CustomerName.
    }
}
