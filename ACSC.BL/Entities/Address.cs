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
        public bool IsValid
        {
            get
            {
                bool isValid = true;

                if (string.IsNullOrWhiteSpace(HouseBuildingStreet) || string.IsNullOrWhiteSpace(Province) 
                    || string.IsNullOrWhiteSpace(CityMunicipality) || string.IsNullOrWhiteSpace(Barangay) || CustomerId < 1)
                {
                    isValid = false;
                }                        

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
