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
    public class OrderRepository : IOrderRepository<Order>
    {
        DBConnection dbStr = new DBConnection();

        public List<Order> GetBy(Order order)
        {
            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Query<Order>(SqlView(order)).ToList();
                return result;
            }
        }

        public List<Order> GetLastId()
        {
            
            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Query<Order>("SELECT TOP 1 * FROM [Order] ORDER BY Id DESC").ToList();
                return result;
            }
        }

        private string SqlView(Order order)
        {
            string sql = $"SELECT TOP 1000 O.Id, O.AddressId, O.CustomerId, O.TotalAmount, O.OrderDate, " +
                $"CONCAT(C.FirstName ,' ', C.LastName) AS 'CustomerName', C.PhoneNumber AS 'CustomerPhoneNumber', " +
                $"CONCAT(A.HouseBuildingStreet,', ',A.Barangay,', ',A.CityMunicipality,', ',A.Province) AS ShippingAddress FROM [Order] AS O " +
                "INNER JOIN [Customer] AS C ON C.Id = O.CustomerId " +
                "INNER JOIN [Address] AS A ON A.Id = O.AddressId " +
                "WHERE O.MarkAs = 'Active'";
            var validlist = ValidateSearchField(order);

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
                    sql += $" Id = {order.Id}";
                    break;
                }
                
                if (string.Equals(validitem, nameof(order.CustomerId))) sql += $" O.CustomerId = {order.CustomerId}";
                if (string.Equals(validitem, nameof(order.AddressId))) sql += $" O.AddressId = {order.AddressId}";
                if (string.Equals(validitem, $"{nameof(order.MinOrderDate)}{nameof(order.MaxOrderDate)}")) sql += $" O.OrderDate BETWEEN '{order.MinOrderDate}' AND '{order.MaxOrderDate}'";
                if (string.Equals(validitem, nameof(order.CustomerName))) sql += $" CONCAT(C.FirstName ,' ', C.LastName) LIKE '%{order.CustomerName}%'";
                if (string.Equals(validitem, nameof(order.CustomerPhoneNumber))) sql += $" C.PhoneNumber LIKE '%{order.CustomerPhoneNumber}%'";
                if (string.Equals(validitem, nameof(order.ShippingAddress))) sql += $" CONCAT(A.HouseBuildingStreet,', ',A.Barangay,', ',A.CityMunicipality,', ',A.Province) LIKE '%{order.ShippingAddress}%'";
            }
            return sql;
        }

        private List<string> ValidateSearchField(Order order)
        {            
                var list = new List<string>();

                if (order.Id > 0) list.Add(nameof(order.Id));
                if (order.CustomerId > 0) list.Add(nameof(order.CustomerId));
                if (order.AddressId > 0) list.Add(nameof(order.AddressId));
                if (string.IsNullOrWhiteSpace(order.MinOrderDate) == false && string.IsNullOrWhiteSpace(order.MaxOrderDate) == false) list.Add($"{nameof(order.MinOrderDate)}{nameof(order.MaxOrderDate)}");
                if (string.IsNullOrEmpty(order.CustomerName) == false) list.Add(nameof(order.CustomerName));
                if (string.IsNullOrEmpty(order.CustomerPhoneNumber) == false) list.Add(nameof(order.CustomerPhoneNumber));
                if (string.IsNullOrEmpty(order.ShippingAddress) == false) list.Add(nameof(order.ShippingAddress));

                return list;
        }

        public bool Save(Order order)
        {
            bool success = false;
            string sql;

            if (order.Validate == true)
            {
                if (order.Id < 1)
                {
                    sql = "INSERT INTO [Order]" +
                        "(CustomerId, AddressId, OrderDate, TotalAmount, MarkAs) " +
                        "VALUES" +
                        "(@CustomerId, @AddressId, @OrderDate, @TotalAmount, @MarkAs)";
                }
                else
                {
                    sql = "UPDATE [Order] SET " +
                        "OrderDate = @OrderDate, " +
                        "TotalAmount = @TotalAmount " +
                        "WHERE Id = @Id";
                }

                using (IDbConnection db = new SqlConnection(dbStr.ToString()))
                {
                    var result = db.Execute(sql, new
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        AddressId = order.AddressId,
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                        MarkAs = "Active"
                    });
                }
                success = true;
            }
            return success;
        }

        public bool Remove(Order order)
        {
            bool success = false;
            string sql = "UPDATE [Order] SET MarkAs = @MarkAs WHERE Id = @Id";

            if (order.Id < 1) return success;

            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Execute(sql, new
                {
                    Id = order.Id,
                    MarkAs = "Removed"
                });
            }
            success = true;

            return success;
        }
    }
}
