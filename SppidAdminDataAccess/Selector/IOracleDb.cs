using System.Collections.Generic;

namespace SppidAdminDataAccess.Selector
{
    public interface IOracleDb
    {
        string GetConnectionString(string connectionName);
        List<T> LoadData<T>(string sql);
        int SaveData<T>(string sql);
    }
}