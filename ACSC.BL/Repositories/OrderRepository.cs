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
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        internal override string TableName => "[Order]";

        public List<Order> GetBy(Order order)
        {
            return base.GetByEntity(order, SqlView(order));
        }

        private string SqlView(Order order)
        {
            string sql = $"SELECT TOP 1000 O.Id, O.AddressId, O.CustomerId, O.TotalAmount, O.OrderDate, " +
                $"CONCAT(C.FirstName ,' ', C.LastName) AS 'CustomerName', C.PhoneNumber AS 'CustomerPhoneNumber', " +
                $"CONCAT(A.HouseBuildingStreet,', ',A.Barangay,', ',A.CityMunicipality,', ',A.Province) AS ShippingAddress FROM [Order] AS O " +
                $"INNER JOIN [Customer] AS C ON C.Id = O.CustomerId " +
                $"INNER JOIN [Address] AS A ON A.Id = O.AddressId " +
                $"WHERE O.MarkAs = 'Active'";
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
                if (validlist.IndexOf(validitem) > 0)
                {
                    sql += " AND";
                }

                if (string.Equals(validitem, "Id"))
                {
                    sql += $" Id = {order.Id}";
                    break;
                }
                else if (string.Equals(validitem, nameof(order.CustomerId)))
                {
                    sql += $" O.CustomerId = {order.CustomerId}";
                }
                else if (string.Equals(validitem, nameof(order.AddressId)))
                {
                    sql += $" O.AddressId = {order.AddressId}";
                }
                else if (string.Equals(validitem, $"{nameof(order.MinOrderDate)}{nameof(order.MaxOrderDate)}"))
                {
                    sql += $" O.OrderDate BETWEEN '{order.MinOrderDate}' AND '{order.MaxOrderDate}'";
                }
                else if (string.Equals(validitem, nameof(order.CustomerName)))
                {
                    sql += $" CONCAT(C.FirstName ,' ', C.LastName) LIKE '%{order.CustomerName}%'";
                }
                else if (string.Equals(validitem, nameof(order.CustomerPhoneNumber)))
                {
                    sql += $" C.PhoneNumber LIKE '%{order.CustomerPhoneNumber}%'";
                }
                else if (string.Equals(validitem, nameof(order.ShippingAddress)))
                {
                    sql += $" CONCAT(A.HouseBuildingStreet,', ',A.Barangay,', ',A.CityMunicipality,', ',A.Province) LIKE '%{order.ShippingAddress}%'";
                }
            }

            return sql;
        }

        private List<string> ValidateSearchField(Order order)
        {            
            var list = new List<string>();

            if (order.Id > 0)
            {
                list.Add(nameof(order.Id));
            }

            if (order.CustomerId > 0)
            {
                list.Add(nameof(order.CustomerId));
            }

            if (order.AddressId > 0)
            {
                list.Add(nameof(order.AddressId));
            }

            if (string.IsNullOrWhiteSpace(order.MinOrderDate) == false && string.IsNullOrWhiteSpace(order.MaxOrderDate) == false)
            {
                list.Add($"{nameof(order.MinOrderDate)}{nameof(order.MaxOrderDate)}");
            }

            if (string.IsNullOrEmpty(order.CustomerName) == false)
            {
                list.Add(nameof(order.CustomerName));
            }

            if (string.IsNullOrEmpty(order.CustomerPhoneNumber) == false)
            {
                list.Add(nameof(order.CustomerPhoneNumber));
            }

            if (string.IsNullOrEmpty(order.ShippingAddress) == false)
            {
                list.Add(nameof(order.ShippingAddress));
            }

            return list;
        }

        public new int SaveEntity(Order order)
        {
            order.MarkAs = $"{MarkAsOption.Active}";
            return base.SaveEntity(order);
        }

        bool IRepository<Order>.UpdateEntity(Order order)
        {
            return base.UpdateEntity(order);
        }

        bool IRepository<Order>.RemoveEntity(int[] id)
        {
            return base.RemoveEntity(id);
        }
    }
}
