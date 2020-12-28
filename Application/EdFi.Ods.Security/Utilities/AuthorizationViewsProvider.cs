using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Security.Utilities
{
    /// <summary>
    /// Retrieves authorization views from Ods database
    /// </summary>
    public class AuthorizationViewsProvider : IAuthorizationViewsProvider
    {
        private readonly Lazy<IList<string>> _authorizationViews;
        private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;

        public AuthorizationViewsProvider(IOdsDatabaseConnectionStringProvider connectionStringProvider)
        {
            _authorizationViews = new Lazy<IList<string>>(LoadAuthorizationViews);
            _connectionStringProvider = connectionStringProvider;
        }

        /// <summary>
        /// Returns a list of implemented authorization views
        /// </summary>
        /// <returns>List of valid authorization views</returns>
        public virtual IList<string> GetAuthorizationViews()
        {
            return _authorizationViews.Value;
        }

        private IList<string> LoadAuthorizationViews()
        {
            // TODO: API Simplification - Need to use generic mechanism for obtaining database connection
            using (var connection = new SqlConnection(_connectionStringProvider.GetConnectionString()))
            {
                connection.Open();
                
                return connection.Query(
                        "SELECT CONCAT(TABLE_SCHEMA,'.',TABLE_NAME) AS ViewName FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'auth'")
                    .Select(x => (string) x.ViewName)
                    .ToList();
            }
        }
    }
}
