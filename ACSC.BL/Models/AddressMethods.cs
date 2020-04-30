using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL.Models
{
    public class AddressMethods
    {
        public bool IsValid(Address address)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(address.HouseBuildingStreet) || string.IsNullOrWhiteSpace(address.Province)
                || string.IsNullOrWhiteSpace(address.CityMunicipality) || string.IsNullOrWhiteSpace(address.Barangay) || address.CustomerId < 1)
            {
                isValid = false;
            }

            return isValid;           
        }

        public string FullAddress(Address address)
        {          
            return $"{address.HouseBuildingStreet}, {address.Barangay}, {address.CityMunicipality}, {address.Province}";            
        }
        public string AllInString(Address address)
        {           
            return $"{address.HouseBuildingStreet}{address.Province}{address.CityMunicipality}{address.Barangay}";            
        }
    }
}
