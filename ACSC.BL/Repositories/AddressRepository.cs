using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Repositories.Interface;
using Dapper;

namespace ACSC.BL
{
    public class AddressRepository:IAddressRepository<Address>
    {
        DBConnection dbStr = new DBConnection();

        public List<Address> GetBy(Address address)
        {
            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Query<Address>(SqlView(address)).ToList();
                return result;
            }
        }
        private string SqlView(Address address)
        {
            string sql = $"SELECT TOP 1000 * FROM Address WHERE MarkAs = 'Active' AND CustomerId = {address.CustomerId}";
            var validlist = ValidateSearchField(address);

            if (validlist.Count() < 1)
            {
                return sql;
            }
            else
            {
                sql += " AND";
            }

            foreach (var validitem in validlist)
            {
                if (validlist.IndexOf(validitem) > 0) sql += " AND";

                if (string.Equals(validitem, "Id"))
                {
                    sql += $" Id = {address.Id}";
                    break;
                }

                if (string.Equals(validitem, nameof(address.HouseBuildingStreet))) sql += $" HouseBuildingStreet LIKE '%{address.HouseBuildingStreet}%'";
                if (string.Equals(validitem, nameof(address.Province))) sql += $" Province LIKE '%{address.Province}%'";
                if (string.Equals(validitem, nameof(address.CityMunicipality))) sql += $" CityMunicipality LIKE '%{address.CityMunicipality}%'";
                if (string.Equals(validitem, nameof(address.Barangay))) sql += $" Barangay LIKE '%{address.Barangay}%'";
            }
            return sql;
        }
        private List<string> ValidateSearchField(Address address)
        {
                var list = new List<string>();

                if (address.Id > 0) list.Add("Id");
                if (string.IsNullOrWhiteSpace(address.HouseBuildingStreet) == false) list.Add(nameof(address.HouseBuildingStreet));
                if (string.IsNullOrWhiteSpace(address.Province) == false) list.Add(nameof(address.Province));
                if (string.IsNullOrWhiteSpace(address.CityMunicipality) == false) list.Add(nameof(address.CityMunicipality));
                if (string.IsNullOrWhiteSpace(address.Barangay) == false) list.Add(nameof(address.Barangay));

                return list;
        }
        public bool Save(Address address)
        {
            bool success = false;
            string sql;

            if (address.Validate == true)
            {
                if (address.Id < 1)
                {
                    sql = "INSERT INTO Address" +
                        "(HouseBuildingStreet, Province, CityMunicipality, Barangay, CustomerId, MarkAs) " +
                        "VALUES" +
                        "(@HouseBuildingStreet, @Province, @CityMunicipality, @Barangay, @CustomerId, @MarkAs)";
                }
                else
                {
                    sql = "UPDATE Address SET " +
                        "HouseBuildingStreet = @HouseBuildingStreet, " +
                        "Province = @Province, " +
                        "CityMunicipality = @CityMunicipality, " +
                        "Barangay = @Barangay " +
                        "WHERE Id = @Id AND CustomerId = @CustomerId";
                }

                using (IDbConnection db = new SqlConnection(dbStr.ToString()))
                {
                    var result = db.Execute(sql, new
                    {
                        Id = address.Id,
                        HouseBuildingStreet = address.HouseBuildingStreet,
                        Province = address.Province,
                        CityMunicipality = address.CityMunicipality,
                        Barangay = address.Barangay,
                        CustomerId = address.CustomerId,
                        MarkAs = "Active"
                    });
                }
                success = true;
            }
            return success;
        }
        public bool Remove(Address address)
        {
            bool success = false;
            string sql = "UPDATE Address SET MarkAs = @MarkAs WHERE Id = @Id";

            if (address.Id < 1) return success;

            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Execute(sql, new
                {
                    Id = address.Id,
                    MarkAs = "Removed"
                });
            }
            success = true;

            return success;
        }
        public string SearchOperation(Address address)
        {
            string message = string.Empty;

            if (string.IsNullOrWhiteSpace(address.AllInString) == true)
            {
                return message = "Please enter a value before searching.";
            }

            var customers = GetBy(address);

            if (customers.Count < 1)
            {
                message = "No records found.";
            }
            return message;
        }
        public string AddOperation(Address address)
        {
            string message = string.Empty;

            if (Save(address) == true)
            {
                message = "New record added.";
            }
            else
            {
                message = "Please don't leave the text boxes empty.";
            }

            return message;

        }
        public string UpdateOperation(Address oldPropVal, Address newPropVal)
        {
            string message = string.Empty;

            if (string.Equals(oldPropVal.AllInString, newPropVal.AllInString) == true)
            {
                message = "No changes is made, please check.";
            }
            else if (Save(newPropVal) == true)
            {
                message = "Record updated.";
            }
            else
            {
                message = "Please don't leave the text boxes empty.";
            }
            return message;
        }
        public string DeleteOperation(Address address)
        {
            string message = string.Empty;

            if (Remove(address) == true)
            {
                message = "Record removed.";
            }
            else
            {
                message = "Failed! No record passed.";
            }
            return message;
        }

    }
}
