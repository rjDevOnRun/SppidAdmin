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

            // Init
            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
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

                    dt.Load(dr, LoadOption.OverwriteChanges);
                    dr.Close();

                }
                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message + ex.StackTrace);
                return dt;
            }
        }
    }
}