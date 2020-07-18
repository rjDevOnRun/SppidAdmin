using SppidAdminDataAccess.Selector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppidAdminDataAccess.Types
{
    public class SqlServerDb : ISqlServerDb
    {
        public string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public List<T> LoadData<T>(string sql)
        {

            return new List<T>();
        }

        public int SaveData<T>(string sql)
        {

            return 0;
        }


        // -----------------------------------------------------------------------------
        // DAPPER methods below 
        //  (but I am not going to use it in this project):
        // -----------------------------------------------------------------------------
        //public static List<T> LoadData<T>(string sql)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Query<T>(sql).ToList();
        //    }
        //}

        //public static int SaveData<T>(string sql, T data)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Execute(sql, data);
        //    }
        //}
    }
}
