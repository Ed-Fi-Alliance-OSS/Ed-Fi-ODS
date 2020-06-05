// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.ChangeQueries.Models;
using EdFi.Ods.ChangeQueries.SqlServer;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.ChangeQueries.Providers
{
    /// <summary>
    /// Implements an <see cref="AvailableChangeVersionProvider"/> that get the ids of the earliest (oldest) and most 
    /// recent (newest) change version available using a standard SQL query executed using the connection
    /// provided by NHibernate.
    /// </summary>
    public class AvailableChangeVersionProvider : IAvailableChangeVersionProvider
    {
        private readonly ISessionFactory _sessionFactory;

        public AvailableChangeVersionProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Gets the ids of the earliest (oldest) and most recent (newest) change events available.
        /// </summary>
        /// <returns>A newly created <see cref="AvailableChangeVersion"/> instance.</returns>
        public AvailableChangeVersion GetAvailableChangeVersion()
        {
            var cmdSql =
                $@"SELECT {ChangeQueriesDatabaseConstants.SchemaName}.GetMaxChangeVersion() as NewestChangeVersion";

            AvailableChangeVersion result;

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                result = sessionScope.Session.CreateSQLQuery(cmdSql)
                                     .SetResultTransformer(Transformers.AliasToBean<AvailableChangeVersion>())
                                     .UniqueResult<AvailableChangeVersion>();
            }

            result.OldestChangeVersion = 0;

            return result;
        }
    }
}
