using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACSC.BL.Manager.Interface;
using ACSC.BL.Models;
using ACSC.BL.Repositories.Interface;

namespace ACSC.BL.Repositories
{
    internal class CustomerOrderHistoryRepository: BaseRepository<CustomerProductOrderHistory> , ICustomerOrderHistoryRepository
    {
        internal override string TableName => "[OrderItem]";

        public List<CustomerProductOrderHistory> Search(CustomerProductOrderHistory obj)
        {
            var generatedSQL = GenerateSQL(obj);
            return base.Get(obj, generatedSQL);
        }     

        private string GenerateSQL(CustomerProductOrderHistory obj)
        {
            string sql = $"SELECT TOP 1000 " +
                $"O.ProductId, X.CustomerId, P.Name AS 'ProductName', O.PurchasePrice, O.Quantity, X.OrderDate, CONCAT(C.FirstName, ' ', C.LastName) AS 'CustomerName' " +
                $"FROM[OrderItem] O " +
                $"INNER JOIN Product P ON P.Id = O.ProductId " +
                $"INNER JOIN[Order] X ON X.Id = O.OrderId " +
                $"INNER JOIN Customer C ON C.Id = X.CustomerId " +
                $"WHERE O.MarkAs = 'Active'";
            var validlist = ValidateSearchField(obj);

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
                if (validlist.IndexOf(validitem) > 0)
                {
                    sql += " AND";
                }

                if (string.Equals(validitem, nameof(obj.ProductId)))
                {
                    sql += $" O.{nameof(obj.ProductId)} = {obj.ProductId}";                    
                }
                else if (string.Equals(validitem, nameof(obj.CustomerId)))
                {
                    sql += $" X.{nameof(obj.CustomerId)} = {obj.CustomerId}";
                }
                else if (string.Equals(validitem, $"{nameof(obj.MinOrderDate)}{nameof(obj.MaxOrderDate)}"))
                {
                    sql += $" X.{nameof(obj.OrderDate)} BETWEEN '{obj.MinOrderDate}' AND '{obj.MaxOrderDate}'";
                }
            }

            return sql;
        }
        private List<string> ValidateSearchField(CustomerProductOrderHistory obj)
        {
            var list = new List<string>();

            if (obj.CustomerId > 0)
            {
                list.Add(nameof(obj.CustomerId));
            }

            if (obj.ProductId > 0)
            {
                list.Add(nameof(obj.ProductId));
            }

            if (string.IsNullOrWhiteSpace(obj.MinOrderDate) == false && string.IsNullOrWhiteSpace(obj.MaxOrderDate) == false)
            {
                list.Add($"{nameof(obj.MinOrderDate)}{nameof(obj.MaxOrderDate)}");
            }

            return list;
        }
        int IRepository<CustomerProductOrderHistory>.Save(CustomerProductOrderHistory obj)
        {
            throw new NotImplementedException();
        }
        bool IRepository<CustomerProductOrderHistory>.Update(CustomerProductOrderHistory obj)
        {
            throw new NotImplementedException();
        }        
        bool IRepository<CustomerProductOrderHistory>.Delete(int[] id)
        {
            throw new NotImplementedException();
        }
    }
}
