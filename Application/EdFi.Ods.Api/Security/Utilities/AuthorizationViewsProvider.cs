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
    /// Retrieves authorization views from Ods database
    /// </summary>
    public class AuthorizationViewsProvider : IAuthorizationViewsProvider
    {
        private readonly Lazy<IList<string>> _authorizationViews;
        private readonly ISessionFactory _sessionFactory;

        public AuthorizationViewsProvider(ISessionFactory sessionFactory)
        {
            _authorizationViews = new Lazy<IList<string>>(LoadAuthorizationViews);
            _sessionFactory = sessionFactory;
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
            using (var session = _sessionFactory.OpenStatelessSession())
            {
                return session.CreateSQLQuery(
                        "SELECT CONCAT(TABLE_SCHEMA,'.',TABLE_NAME) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'auth'")
                    .List<string>();
            }
        }
    }
}
