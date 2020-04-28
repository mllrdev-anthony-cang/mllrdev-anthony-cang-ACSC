using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Repositories;
using ACSC.BL.Repositories.Interface;
using Dapper;

namespace ACSC.BL
{    
    internal class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        internal override string TableName => "Customer";

        public List<Customer> GetBy(Customer customer)
        {
            var generatedSQL = GenerateSQL(customer);
            return base.Get(customer, generatedSQL);
        }

        private string GenerateSQL(Customer customer)
        {
            string sql = $"SELECT TOP 1000 * FROM {TableName} WHERE {nameof(customer.MarkAs)} = '{MarkAsOption.Active}'";
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
                if (validlist.IndexOf(validitem) > 0)
                {
                    sql += " AND";
                }

                if (string.Equals(validitem, nameof(customer.Id)))
                {
                    sql += $" {nameof(customer.Id)} = {customer.Id}";
                    break;
                }
                else if (string.Equals(validitem, nameof(customer.FirstName)))
                {
                    sql += $" {nameof(customer.FirstName)} LIKE '{customer.FirstName}%'";
                }
                else if (string.Equals(validitem, nameof(customer.LastName)))
                {
                    sql += $" {nameof(customer.LastName)} LIKE '{customer.LastName}%'";
                }
                else if (string.Equals(validitem, nameof(customer.PhoneNumber)))
                {
                    sql += $" {nameof(customer.PhoneNumber)} LIKE '{customer.PhoneNumber}%'";
                }
            }

            return sql;
        }

        private List<string> ValidateSearchField(Customer customer)
        {
            var list = new List<string>();

            if (customer.Id > 0)
            {
                list.Add(nameof(customer.Id));
            }

            if (string.IsNullOrWhiteSpace(customer.FirstName) == false)
            {
                list.Add(nameof(customer.FirstName));
            }

            if (string.IsNullOrWhiteSpace(customer.LastName) == false)
            {
                list.Add(nameof(customer.LastName));
            }

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber) == false)
            {
                list.Add(nameof(customer.PhoneNumber));
            }

            return list;
        }

        public new int Save(Customer customer)
        {
            customer.MarkAs = $"{MarkAsOption.Active}";
            return base.Save(customer);
        }

        public new bool Update(Customer customer)
        {
            return base.Update(customer);
        }
        public new bool Delete(int[] id)
        {
            return base.Delete(id);
        }
    }
}
