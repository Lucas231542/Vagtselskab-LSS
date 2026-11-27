using Microsoft.Data.SqlClient;

namespace VagtLib.Lib
{
    public class DBConnecter
    {
        private readonly string _connectionString;

        public DBConnecter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}