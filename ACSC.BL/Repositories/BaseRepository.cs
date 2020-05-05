using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ACSC.BL.Repositories
{
    internal abstract class BaseRepository<T> where T: class
    {
        internal abstract string TableName { get; }
        internal SqlConnection _connection;
        internal static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        internal BaseRepository()
        {
            try
            {
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBACSC"].ConnectionString);
                //_connection.Open();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            
        }
        internal enum MarkAsOption{ Active,Removed }
        internal List<T> Get(T obj, string sql)
        {
            
            try
            {
                var result = _connection.Query<T>(sql).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return null;
            }
        }

        internal int Save(T obj)
        {           

            try
            {
                //string[] excludedProperties = { "id", "isvalid", "fulladdress", "allinstring", "fullname", "minprice", "maxprice", "orderitems", "minorderdate", "maxorderdate",
                    //"customername", "customerphonenumber", "shippingaddress","orderitemproductname","orderitemproductdescription" };
                var properties = obj.GetType().GetProperties().Where(e => string.Equals(e.Name.ToLower(),"id") == false);
                //var fields = string.Join(", ", properties.Select(e => e.Name));
                //var values = string.Join(", ", properties.Select(e => $"@{e.Name}"));
                string sql = $"INSERT INTO {TableName} ({string.Join(", ", properties.Select(e => e.Name))}) VALUES ({string.Join(", ", properties.Select(e => $"@{e.Name}"))});";
                //string[] tableWithNoIdentity = { "[orderitem]" };

                if(string.Equals(TableName, "[orderitem]") == true)
                {
                    return _connection.Execute(sql, obj);
                }
                else
                {
                    sql += " SELECT @@IDENTITY";
                    return _connection.ExecuteScalar<int>(sql, obj);
                }
                
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return 0;
            }
        }

        internal bool Update(T obj)
        {
            try
            {
                string[] exclude = { "id", "markas" };
                var properties = obj.GetType().GetProperties().Where(e => exclude.Contains(e.Name.ToLower()) == false);
                var values = string.Join(", ", properties.Select(e => $"{e.Name} = @{e.Name}"));
                string sql = $"UPDATE {TableName} SET {values} WHERE Id = @Id";
                return _connection.Execute(sql, obj) > 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return false;
            }
        }

        internal bool Delete(int[] id)
        {           
            
            try
            {
                string sql = $"UPDATE {TableName} SET MarkAs = '{MarkAsOption.Removed}' WHERE Id IN ({string.Join(", ", id)})";
                return _connection.Execute(sql) > 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return false;
            }
        }
        
    }
}
