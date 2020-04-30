using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Models;
using ACSC.BL.Repositories;
using ACSC.BL.Repositories.Interface;
using Dapper;

namespace ACSC.BL
{
    internal class AddressRepository: BaseRepository<Address>, IAddressRepository
    {
        internal override string TableName => "Address";

        public List<Address> GetBy(Address address)
        {
            string generatedSQL = GenerateSQL(address);
            return base.Get(address, generatedSQL);
        }
        private string GenerateSQL(Address address)
        {
            string sql = $"SELECT TOP 1000 * FROM {TableName} WHERE {nameof(address.MarkAs)} = '{MarkAsOption.Active}' AND {nameof(address.CustomerId)} = {address.CustomerId}";
            var validatedFields = ValidateSearchField(address);

            if (validatedFields.Count() < 1)
            {
                return sql;
            }
            else
            {
                sql += " AND";
            }

            foreach (var validitem in validatedFields)
            {
                if (validatedFields.IndexOf(validitem) > 0)
                {
                    sql += " AND";
                }

                if (string.Equals(validitem, nameof(address.Id)))
                {
                    sql += $" {nameof(address.Id)} = {address.Id}";
                    break;
                }
                else if (string.Equals(validitem, nameof(address.HouseBuildingStreet)))
                {
                    sql += $" {nameof(address.HouseBuildingStreet)} LIKE '%{address.HouseBuildingStreet}%'";
                }
                else if (string.Equals(validitem, nameof(address.Province)))
                {
                    sql += $" {nameof(address.Province)} LIKE '%{address.Province}%'";
                }
                else if (string.Equals(validitem, nameof(address.CityMunicipality)))
                {
                    sql += $" {nameof(address.CityMunicipality)} LIKE '%{address.CityMunicipality}%'";
                }
                else if (string.Equals(validitem, nameof(address.Barangay)))
                {
                    sql += $" {nameof(address.Barangay)} LIKE '%{address.Barangay}%'";
                }
            }

            return sql;
        }
        private List<string> ValidateSearchField(Address address)
        {
            var list = new List<string>();

            if (address.Id > 0)
            {
                list.Add(nameof(address.Id));
            }

            if (string.IsNullOrWhiteSpace(address.HouseBuildingStreet) == false)
            {
                list.Add(nameof(address.HouseBuildingStreet));
            }

            if (string.IsNullOrWhiteSpace(address.Province) == false)
            {
                list.Add(nameof(address.Province));
            }

            if (string.IsNullOrWhiteSpace(address.CityMunicipality) == false)
            {
                list.Add(nameof(address.CityMunicipality));
            }

            if (string.IsNullOrWhiteSpace(address.Barangay) == false)
            {
                list.Add(nameof(address.Barangay));
            }

            return list;
        }

        public new int Save(Address address)
        {
            address.MarkAs = $"{MarkAsOption.Active}";
            return base.Save(address);
        }
        
        public new bool Update(Address address)
        {
            return base.Update(address);
        }
        public new bool Delete(int[] id)
        {
            return base.Delete(id);
        }      

    }
}
