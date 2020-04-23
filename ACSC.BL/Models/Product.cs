using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string MarkAs { get; set; }

        public bool isValid
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrWhiteSpace(Name)) isValid = false;
                if (string.IsNullOrWhiteSpace(Description)) isValid = false;
                if (CurrentPrice == null || Math.Round(Convert.ToDouble(CurrentPrice),2) <= 0) isValid = false;

                return isValid;
            }
        }

        public string AllInString
        {
            get
            {
                return $"{Name}{Description}{CurrentPrice}";
            }
        }        
        
    }
}
