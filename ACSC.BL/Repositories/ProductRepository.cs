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
    public class ProductRepository: IProductRepository<Product>
    {
        DBConnection dbStr = new DBConnection();

        public List<Product> GetBy(Product product)
        {
            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Query<Product>(SqlView(product)).ToList();
                return result;
            }
        }

        public string SqlView(Product product)
        {
            string sql = $"SELECT TOP 1000 * FROM Product WHERE MarkAs = 'Active'";
            var validlist = ValidateSearchField(product);

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
                    sql += $" Id = {product.Id}";
                    break;
                }
                if (string.Equals(validitem, nameof(product.Name))) sql += $" Name LIKE '{product.Name}%'";
                if (string.Equals(validitem, nameof(product.Description))) sql += $" Description LIKE '{product.Description}%'";
                if (string.Equals(validitem, $"{nameof(product.MinPrice)}{nameof(product.MaxPrice)}")) sql += $" CurrentPrice BETWEEN {product.MinPrice} AND {product.MaxPrice}";
            }
            return sql;
        }

        private List<string> ValidateSearchField(Product product)
        {
                var list = new List<string>();

                if (product.Id > 0) list.Add("Id");
                if (string.IsNullOrWhiteSpace(product.Name) == false) list.Add(nameof(product.Name));
                if (string.IsNullOrWhiteSpace(product.Description) == false) list.Add(nameof(product.Description));
                if ((product.MinPrice != null) && (product.MaxPrice != null)) list.Add($"{nameof(product.MinPrice)}{nameof(product.MaxPrice)}");

                return list;
        }

        public bool Save(Product product)
        {
            bool success = false;
            string sql;

            if (product.Validate == true)
            {
                if (product.Id < 1)
                {
                    sql = "INSERT INTO Product" +
                        "(Name, Description, CurrentPrice, MarkAs) " +
                        "VALUES" +
                        "(@Name, @Description, @CurrentPrice, @MarkAs)";
                }
                else
                {
                    sql = "UPDATE Product SET " +
                        "Name = @Name, " +
                        "Description = @Description, " +
                        "CurrentPrice = @CurrentPrice " +
                        "WHERE Id = @Id";
                }

                using (IDbConnection db = new SqlConnection(dbStr.ToString()))
                {
                    var result = db.Execute(sql, new
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        CurrentPrice = product.CurrentPrice,
                        MarkAs = "Active"
                    });
                }
                success = true;
            }
            return success;
        }

        public bool Remove(Product product)
        {
            bool success = false;
            string sql = "UPDATE Product SET MarkAs = @MarkAs WHERE Id = @Id";

            if (product.Id < 1) return success;

            using (IDbConnection db = new SqlConnection(dbStr.ToString()))
            {
                var result = db.Execute(sql, new
                {
                    Id = product.Id,
                    MarkAs = "Removed"
                });
            }
            success = true;

            return success;
        }

        public string SearchOperation(Product product)
        {
            string message = string.Empty;

            if (string.IsNullOrWhiteSpace(product.AllInString) == true && product.MaxPrice == null && product.MinPrice == null)
            {
                return message = "Please enter a value before searching.";                
            }

            var products = GetBy(product);

            if (products.Count < 1)
            {
                message = "No records found.";
            }
            return message;            
        }
        public string AddOperation(Product product)
        {
            string message = string.Empty;
                       
            if (Save(product) == true)
            {
                message = "New record added.";
            }
            else
            {
                message = "Please don't leave the text boxes empty.";
            }

            return message;

        }
        public string UpdateOperation(Product oldPropVal, Product newPropVal)
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
        public string DeleteOperation(Product product)
        {
            string message = string.Empty;
            
            if (Remove(product) == true)
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
