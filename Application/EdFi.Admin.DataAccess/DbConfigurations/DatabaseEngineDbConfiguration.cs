using EdFi.Common.Configuration;
using Npgsql;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;

namespace EdFi.Admin.DataAccess.DbConfigurations
{
    public class DatabaseEngineDbConfiguration : DbConfiguration
    {
        public DatabaseEngineDbConfiguration(DatabaseEngine databaseEngine)
        {
            if (databaseEngine == DatabaseEngine.SqlServer)
            {
                SetProviderFactory(
                    providerInvariantName: SqlProviderServices.ProviderInvariantName,
                    providerFactory: SqlClientFactory.Instance);

                SetProviderServices(
                    providerInvariantName: SqlProviderServices.ProviderInvariantName,
                    provider: SqlProviderServices.Instance);
                SetDefaultConnectionFactory(connectionFactory: new SqlConnectionFactory());
            }
            else if (databaseEngine == DatabaseEngine.Postgres)
            {
                const string name = "Npgsql";

                SetProviderFactory(
                    providerInvariantName: name,
                    providerFactory: NpgsqlFactory.Instance);

                SetProviderServices(
                    providerInvariantName: name,
                    provider: NpgsqlServices.Instance);

                SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
            }
        }
    }
}
