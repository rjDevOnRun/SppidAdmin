﻿using SppidAdminDataAccess.Selector;
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

        public DataTable LoadData(string connectionString, string sqlQuery)
        {
            // Init
            SqlConnection sqlConnection = null;
            DataTable dataTable = new DataTable();
            try
            {
                // Establish connection (will dispose automatically)
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    // Open connection
                    sqlConnection.Open();

                    // Init Command
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    // Execute the Query
                    IDataReader dr = sqlCommand.ExecuteReader();

                    dataTable.Load(dr, LoadOption.OverwriteChanges);
                    dr.Close();

                }
                return dataTable;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message + ex.StackTrace);
                return dataTable;
            }
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
