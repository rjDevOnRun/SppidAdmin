using SppidAdminDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static SppidAdminGlobals.Enums;

namespace SppidAdminWebAPI.DataRepository
{
    public class SpItemRepository
    {
        // Reference:  https://stackoverflow.com/questions/27551249/how-to-use-a-oracle-database-in-asp-net-without-entity-framework
        internal static DataTable GetPlantItemsFromDatabase(ItemType item)
        {
            // Get Connection String to DB
            //var connectionString = ConfigurationManager.ConnectionStrings["SpAdminDB"].ToString();
            var connectionString = "user id = system; password = Oracle01; Data source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = RJDELL)(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = SPPIDORCL)))";

            // Build Query (PlantItem - (4):PipeRun Type)
            var sqlQuery = $"select * from SPPIDPLANTPID.t_plantitem pl where pl.plantitemtype = {(int)item} and rownum < 100";

            DataTable dt = new DataTable();
            dt = OracleDb.LoadData(connectionString, sqlQuery);

            return dt;

        }
    }
}