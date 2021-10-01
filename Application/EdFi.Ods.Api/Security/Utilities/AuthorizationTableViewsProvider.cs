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
    public class AuthorizationTableViewsProvider : IAuthorizationTableViewsProvider
    {
        private readonly Lazy<IList<string>> _authorizationTableViews;
        private readonly ISessionFactory _sessionFactory;

        public AuthorizationTableViewsProvider(ISessionFactory sessionFactory)
        {
            _authorizationTableViews = new Lazy<IList<string>>(LoadAuthorizationTableViews);
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Returns a list of implemented authorization views and authorization tuple table
        /// </summary>
        /// <returns>List of valid authorization views and authorization tuple table </returns>
        public virtual IList<string> GetAuthorizationTableViews()
        {
            return _authorizationTableViews.Value;
        }

        private IList<string> LoadAuthorizationTableViews()
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
