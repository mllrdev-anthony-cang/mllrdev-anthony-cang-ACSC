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
    public class CustomerRepository: ICustomerRepository<Customer>
    {
        DBConnection dbStr = new DBConnection();
        
        public List<Customer> GetBy(Customer customer)
        {        
            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Query<Customer>(SqlView(customer)).ToList();
                return result;
            }
        }

        private string SqlView(Customer customer)
        {
            string sql = "SELECT TOP 1000 * FROM Customer WHERE MarkAs = 'Active'";
            var validlist = ValidateSearchField(customer);

            if(validlist.Count() < 1)
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
                    sql += $" Id = {customer.Id}";
                    break;
                }
                if (string.Equals(validitem, "FirstName")) sql += $" FirstName LIKE '{customer.FirstName}%'";
                if (string.Equals(validitem, "LastName")) sql += $" LastName LIKE '{customer.LastName}%'";
                if (string.Equals(validitem, "PhoneNumber")) sql += $" PhoneNumber LIKE '{customer.PhoneNumber}%'";
            }
            return sql;
        }

        private List<string> ValidateSearchField(Customer customer)
        {
                var list = new List<string>();

                if (customer.Id > 0) list.Add("Id");
                if (string.IsNullOrWhiteSpace(customer.FirstName) == false) list.Add(nameof(customer.FirstName));
                if (string.IsNullOrWhiteSpace(customer.LastName) == false) list.Add(nameof(customer.LastName));
                if (string.IsNullOrWhiteSpace(customer.PhoneNumber) == false) list.Add(nameof(customer.PhoneNumber));

                return list;
        }

        public bool Save(Customer customer)
        {
            bool success = false;
            string sql;

            if (customer.Validate == true)
            {
                if(customer.Id < 1)
                {
                    sql = "INSERT INTO Customer(FirstName, LastName, PhoneNumber, MarkAs) VALUES(@FirstName, @LastName, @PhoneNumber, @MarkAs)";
                }
                else
                {
                    sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber WHERE Id = @Id";
                }
                
                using (IDbConnection db = new SqlConnection(dbStr.ToString()))
                {
                    var result = db.Execute(sql, new {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        MarkAs = "Active"
                    });
                }
                success = true;
            }
            return success;
        }

        public bool Remove(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET MarkAs = @MarkAs WHERE Id = @Id";

            if (customer.Id < 1) return success;

            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Execute(sql, new
                {
                    Id = customer.Id,
                    MarkAs = "Removed"
                });
            }
            success = true;

            return success;
        }

        public string SearchOperation(Customer customer)
        {
            string message = string.Empty;

            if (string.IsNullOrWhiteSpace(customer.AllInString) == true)
            {
                return message = "Please enter a value before searching.";
            }

            var customers = GetBy(customer);

            if (customers.Count < 1)
            {
                message = "No records found.";
            }
            return message;
        }
        public string AddOperation(Customer customer)
        {
            string message = string.Empty;

            if (Save(customer) == true)
            {
                message = "New record added.";
            }
            else
            {
                message = "Please don't leave the text boxes empty.";
            }

            return message;

        }
        public string UpdateOperation(Customer oldPropVal, Customer newPropVal)
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
        public string DeleteOperation(Customer customer)
        {
            string message = string.Empty;

            if (Remove(customer) == true)
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
