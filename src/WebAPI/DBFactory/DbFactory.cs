using System.Configuration;
using System.Data.Common;

namespace DBFactory
{
    public abstract class DbFactory
    {
        #region Private methods
        private static DbProviderFactory GetFactory(string configName)
        {
            string provider = ConfigurationManager.ConnectionStrings[configName].ProviderName;
            return DbProviderFactories.GetFactory(provider);
        }
        #endregion

        #region Public methods
        public static DbConnection CreateConnection()
        {
            return CreateConnection("BDFirebird");
        }

        public static DbConnection CreateConnection(string configName)
        {
            DbProviderFactory factory = GetFactory(configName);
            string connectionString = ConfigurationManager.ConnectionStrings[configName].ConnectionString;
            DbConnection connection = factory.CreateConnection();

            if (connection != null)
                connection.ConnectionString = connectionString;
            return connection;
        }
        #endregion
    }
}