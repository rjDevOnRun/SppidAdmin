using Oracle.ManagedDataAccess.Client;
using SppidAdminDataAccess.Selector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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


        public static DataTable LoadData(string connectionString, string sqlQuery)
        {
            // ref: https://errorin10.wordpress.com/2017/04/11/using-oracle-managed-data-access-in-asp-net-and-c/
            DataTable dataTable = new DataTable();
            try
            {
                //// Build Query (PlantItem - (4):PipeRun Type)
                //var sqlQuery = $"select * from SPPIDPLANTPID.t_plantitem pl where pl.plantitemtype = 4 and rownum < 100";

                // Init
                using (OracleConnection connection = new OracleConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    OracleCommand oracleCommand = connection.CreateCommand();
                    oracleCommand.CommandText = sqlQuery;
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    
                    dataTable.Load(reader);


                }
                return dataTable;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message + ex.StackTrace);
                return dataTable;
            }
        }


    }
}
