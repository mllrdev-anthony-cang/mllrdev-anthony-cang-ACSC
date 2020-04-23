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
    internal class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        internal override string TableName => "Product";
        
        public List<Product> GetBy(Product product)
        {
            return base.GetByEntity(product, SqlView(product));
        }

        public string SqlView(Product product)
        {
            string sql = $"SELECT TOP 1000 * FROM {TableName} WHERE {nameof(product.MarkAs)} = '{MarkAsOption.Active}'";
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
                if (validlist.IndexOf(validitem) > 0)
                {
                    sql += " AND";
                }

                if (string.Equals(validitem, nameof(product.Id)))
                {
                    sql += $" Id = {product.Id}";
                    break;
                }
                else if (string.Equals(validitem, nameof(product.Name)))
                {
                    sql += $" {nameof(product.Name)} LIKE '{product.Name}%'";
                }
                else if (string.Equals(validitem, nameof(product.Description)))
                {
                    sql += $" {nameof(product.Description)} LIKE '{product.Description}%'";
                }
                else if (string.Equals(validitem, $"{nameof(product.MinPrice)}{nameof(product.MaxPrice)}"))
                {
                    sql += $" {nameof(product.CurrentPrice)} BETWEEN {product.MinPrice} AND {product.MaxPrice}";
                }
            }

            return sql;
        }

        private List<string> ValidateSearchField(Product product)
        {
            var list = new List<string>();

            if (product.Id > 0)
            {
                list.Add("Id");
            }

            if (string.IsNullOrWhiteSpace(product.Name) == false)
            {
                list.Add(nameof(product.Name));
            }

            if (string.IsNullOrWhiteSpace(product.Description) == false)
            {
                list.Add(nameof(product.Description));
            }

            if ((product.MinPrice != null) && (product.MaxPrice != null))
            {
                list.Add($"{nameof(product.MinPrice)}{nameof(product.MaxPrice)}");
            }

            return list;
        }

       
        public new int SaveEntity(Product product)
        {
            product.MarkAs = $"{MarkAsOption.Active}";
            return base.SaveEntity(product);
        }

        public new bool UpdateEntity(Product product)
        {
            return base.UpdateEntity(product);
        }

        public new bool RemoveEntity(int[] id)
        {
            return base.RemoveEntity(id);
        }
    }
}
