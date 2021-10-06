// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using NHibernate;

namespace EdFi.Ods.Api.Security.Utilities
{
    /// <summary>
    /// Retrieves authorization views and authorization tuple table from Ods database
    /// </summary>
    public class AuthorizationTablesAndViewsProvider : IAuthorizationTablesAndViewsProvider
    {
        private readonly Lazy<IList<string>> _authorizationTablesAndViews;
        private readonly ISessionFactory _sessionFactory;

        public AuthorizationTablesAndViewsProvider(ISessionFactory sessionFactory)
        {
            _authorizationTablesAndViews = new Lazy<IList<string>>(LoadAuthorizationTablesAndViews);
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Returns a list of implemented authorization views and authorization tuple table
        /// </summary>
        /// <returns>List of valid authorization views and authorization tuple table </returns>
        public virtual IList<string> GetAuthorizationTablesAndViews()
        {
            return _authorizationTablesAndViews.Value;
        }

        private IList<string> LoadAuthorizationTablesAndViews()
        {
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                return session.CreateSQLQuery(
                        "SELECT CONCAT(TABLE_SCHEMA,'.',TABLE_NAME) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'auth'")
                    .List<string>();
            }
        }
    }
}
