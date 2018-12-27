using System.Configuration;
using System.Data.SqlClient;

namespace Helpers
{
    public static class ConnectionHelper
    {
        public static string GetSqlConnectionString()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.DataSource = ConfigurationManager.AppSettings["server"]; //iz App.config se čita Server
            sqlBuilder.InitialCatalog = ConfigurationManager.AppSettings["database"];
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = ConfigurationManager.AppSettings["sqlusername"];
            sqlBuilder.Password = EncryptionHelper.Decrypt(ConfigurationManager.AppSettings["sqlpassword"]);
            return sqlBuilder.ToString();
        }
    }
}
