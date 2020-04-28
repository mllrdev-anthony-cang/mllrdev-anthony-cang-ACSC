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
            var generatedSQL = GenerateSQL(orderitem);
            return base.Get(orderitem, generatedSQL);
            //return _connection.Query<OrderItem>(generatedSQL).ToList();    

        }

        private string GenerateSQL(OrderItem orderitem)
        {            
            string sql = "SELECT TOP 1000 O.OrderId, O.ProductId, O.PurchasePrice, O.Quantity, " +
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
                if (validlist.IndexOf(validitem) > 0)
                {
                    sql += " AND";
                }

                if (string.Equals(validitem, nameof(orderitem.OrderId)))
                {
                    sql += $" O.OrderId = {orderitem.OrderId}";
                }
                else if (string.Equals(validitem, nameof(orderitem.ProductId)))
                {
                    sql += $" O.ProductId = {orderitem.ProductId}";
                }
            }

            return sql;
        }


        private List<string> ValidateSearchField(OrderItem orderitem)
        {
            var list = new List<string>();

            if (orderitem.OrderId > 0)
            {
                list.Add(nameof(orderitem.OrderId));
            }

            if (orderitem.ProductId > 0)
            {
                list.Add(nameof(orderitem.ProductId));
            }

            return list;
            
        }

        public new int Save(OrderItem orderitem)
        {
            orderitem.MarkAs = $"{MarkAsOption.Active}";
            return base.Save(orderitem);
        }

        bool IRepository<OrderItem>.Update(OrderItem obj)
        {
            throw new NotImplementedException();
        }

        bool IRepository<OrderItem>.Delete(int[] id)
        {
            throw new NotImplementedException();
        }
    }
}
