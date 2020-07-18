using SppidAdminDataAccess.Selector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SppidAdminDataAccess.Types
{
    public class OracleDb : IOracleDb
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
    }
}
