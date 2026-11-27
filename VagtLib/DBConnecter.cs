
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace VagtLib.Lib
{
    public class DBConnecter
    {
        public DBConnecter(string? connectionString)
        {
        }

        public SqlConnection GetConnection()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<DBConnecter>()
                .Build();

            string connectionString = config["DefaultConnection"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("ConnectionString blev ikke fundet!");
            }

            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(connectionString);

            builder.InitialCatalog = "vilken_enterprises_dk_db_DBMS";

            return new SqlConnection(builder.ConnectionString);
        }
    }
}
