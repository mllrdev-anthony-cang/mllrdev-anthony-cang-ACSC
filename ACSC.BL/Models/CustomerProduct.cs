using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Models
{
    public class CustomerProduct
    {
        public string ProductName { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
