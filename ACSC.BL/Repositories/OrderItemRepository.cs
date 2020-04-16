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
    internal class OrderItemRepository: BaseRepository<OrderItem> ,IOrderItemRepository
    {
        internal override string TableName => "[OrderItem]";

        public List<OrderItem> GetBy(OrderItem orderitem)
        {
            var result = _connection.Query<OrderItem>(SqlView(orderitem)).ToList();
            return result;
            
        }

        private string SqlView(OrderItem orderitem)
        {
            string sql = $"SELECT TOP 1000 * FROM OrderItem WHERE MarkAs = 'Active'";
            sql = "SELECT TOP 1000 O.OrderId, O.ProductId, O.PurchasePrice, O.Quantity, " +
                "P.Name AS 'OrderItemProductName', P.Description AS 'OrderItemProductDescription' FROM [OrderItem] O " +
                "INNER JOIN Product P ON P.Id = O.ProductId WHERE O.MarkAs = 'Active'";
            var validlist = ValidateSearchField(orderitem);

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
                if (string.Equals(validitem, nameof(orderitem.OrderId))) sql += $" O.OrderId = {orderitem.OrderId}";
                if (string.Equals(validitem, nameof(orderitem.ProductId))) sql += $" O.ProductId = {orderitem.ProductId}";
            }
            return sql;
        }


        private List<string> ValidateSearchField(OrderItem orderitem)
        {
                var list = new List<string>();

                if (orderitem.OrderId > 0) list.Add(nameof(orderitem.OrderId));
                if (orderitem.ProductId > 0) list.Add(nameof(orderitem.ProductId));

                return list;
            
        }

        public bool Save(OrderItem orderitem)
        {
            bool success = false;
            string sql;

            if (orderitem.Validate == true)
            {
                var existlist = GetBy(orderitem);
                if (existlist.Count() < 1)
                {
                    sql = "INSERT INTO OrderItem" +
                        "(OrderId, ProductId, PurchasePrice, Quantity, MarkAs) " +
                        "VALUES" +
                        "(@OrderId, @ProductId, @PurchasePrice, @Quantity, @MarkAs)";
                }
                else
                {
                    sql = "UPDATE OrderItem SET " +
                        "PurchasePrice = @PurchasePrice, " +
                        "Quantity = @Quantity " +
                        "WHERE OrderId = @OrderId AND ProductId = @ProductId";
                }

                var result = _connection.Execute(sql, new
                {
                    OrderId = orderitem.OrderId,
                    ProductId = orderitem.ProductId,
                    PurchasePrice = orderitem.PurchasePrice,
                    Quantity = orderitem.Quantity,
                    MarkAs = "Active"
                });
                
                success = true;
            }
            return success;
        }

        public bool Remove(OrderItem orderitem)
        {
            bool success = false;
            string sql = "UPDATE OrderItem SET MarkAs = @MarkAs WHERE OrderId = @OrderId AND ProductId = @ProductId";

            if (orderitem.OrderId < 1 || orderitem.ProductId < 1) return success;

            var result = _connection.Execute(sql, new
             {
                 OrderId = orderitem.OrderId,
                 ProductId = orderitem.ProductId,
                 MarkAs = "Removed"
             });
            
            success = true;

            return success;
        }
    }
}
