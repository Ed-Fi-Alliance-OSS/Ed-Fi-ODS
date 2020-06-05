using System;
using System.Collections.Generic;
using NHibernate;

namespace EdFi.Ods.Security.Utilities
{
    /// <summary>
    /// Retrieves authorization views from Ods database
    /// </summary>
    public class AuthorizationViewsProvider : IAuthorizationViewsProvider
    {
        private Lazy<List<string>> _authorizationViews;
        private readonly ISessionFactory _sessionFactory;

        public AuthorizationViewsProvider(ISessionFactory sessionFactory)
        {
            _authorizationViews = new Lazy<List<string>>(LoadAuthorizationViews);
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Returns a list of implemented authorization views
        /// </summary>
        /// <returns>List of valid authorization views</returns>
        public virtual IReadOnlyList<string> GetAuthorizationViews()
        {
            return _authorizationViews.Value;
        }

        private List<string> LoadAuthorizationViews()
        {
            var views = new List<string>();

            using (var session = _sessionFactory.OpenStatelessSession())
            {
                var cmd = session.Connection.CreateCommand();

                cmd.CommandText = "SELECT CONCAT(TABLE_SCHEMA,'.',TABLE_NAME) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'auth'";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    views.Add(reader[0] as string);
                }
            }

            return views;
        }
    }
}
