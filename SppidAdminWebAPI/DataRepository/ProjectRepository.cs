using SppidAdminDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SppidAdminWebAPI.DataRepository
{
    public class ProjectRepository
    {
        internal static DataTable GetProjectsFromDatabase()
        {
            // Get Connection String to DB
            var connectionString = ConfigurationManager.ConnectionStrings["SpAdminDB"].ToString();

            // Build an Insert Query (with parameters)
            var sqlQuery = $"SELECT * FROM SpAdminDb.dbo.Projects";

            // Get Data
            SqlServerDb sqlDb = new SqlServerDb();
            DataTable dataTable = new DataTable();

            dataTable = sqlDb.LoadData(connectionString, sqlQuery);

            return dataTable;
        }
    }
}