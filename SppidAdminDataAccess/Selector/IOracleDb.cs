using System.Collections.Generic;
using System.Data;

namespace SppidAdminDataAccess.Selector
{
    public interface IOracleDb
    {
        string GetConnectionString(string connectionName);

        DataTable LoadData(string connectionString, string sqlQuery);
    }
}