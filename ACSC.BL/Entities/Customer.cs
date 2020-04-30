using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Id { get; set; }
        public string MarkAs { get; set; }

        public bool IsValid
        {
            get
            {            
                bool isValid = true;
                
                if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    isValid = false;
                }                    

                return isValid;
            }
        }

        public string FullName
        {
            get
            {
                string fullname = $"{FirstName} {LastName}";
                return fullname;
            }            
        }

        public string AllInString
        {
            get
            {
                string customer = $"{FirstName}{LastName}{PhoneNumber}";
                return customer;
            }
        }
        
    }
}
