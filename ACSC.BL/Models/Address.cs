using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL
{
    public class Address
    {
        public int Id { get; set; }
        public string HouseBuildingStreet { get; set; }
        public string Province { get; set; }
        public string CityMunicipality { get; set; }
        public string Barangay { get; set; }
        public int CustomerId { get; set; }
        public string MarkAs { get; set; }
        public bool isValid
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrWhiteSpace(HouseBuildingStreet)) isValid = false;
                if (string.IsNullOrWhiteSpace(Province)) isValid = false;
                if (string.IsNullOrWhiteSpace(CityMunicipality)) isValid = false;
                if (string.IsNullOrWhiteSpace(Barangay)) isValid = false;
                if (CustomerId < 1) isValid = false;

                return isValid;
            }
        }

        public string FullAddress
        {
            get
            {
                return $"{HouseBuildingStreet}, {Barangay}, {CityMunicipality}, {Province}";
            }
        }

        public string AllInString
        {
            get
            {
                return $"{HouseBuildingStreet}{Province}{CityMunicipality}{Barangay}";                
            }
        }
        
    }
}
