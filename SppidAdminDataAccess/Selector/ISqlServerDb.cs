using System.Collections.Generic;
using System.Data;

namespace SppidAdminDataAccess.Selector
{
    public interface ISqlServerDb
    {
        string GetConnectionString(string connectionName);

        DataTable LoadData(string connectionString, string sqlQuery);
    }
}