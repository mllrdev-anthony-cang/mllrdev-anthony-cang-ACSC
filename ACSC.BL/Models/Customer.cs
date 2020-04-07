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

        public bool Validate
        {
            get
            {            
            bool valid = true;

            if (string.IsNullOrWhiteSpace(FirstName)) valid = false;
            if (string.IsNullOrWhiteSpace(LastName)) valid = false;
            if (string.IsNullOrWhiteSpace(PhoneNumber)) valid = false;

            return valid;
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
