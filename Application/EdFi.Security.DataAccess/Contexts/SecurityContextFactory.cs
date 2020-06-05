// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETSTANDARD
using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;

namespace EdFi.Security.DataAccess.Contexts
{
    public class SecurityContextFactory : ISecurityContextFactory
    {
        private readonly ISecurityDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly DatabaseEngine _databaseEngine;
        private readonly IDictionary<DatabaseEngine, Type> _securityContextTypeByDatabaseEngine =
            new Dictionary<DatabaseEngine, Type>
            {
                {DatabaseEngine.SqlServer, typeof(SqlServerSecurityContext)},
                {DatabaseEngine.Postgres, typeof(PostgresSecurityContext)}
            };

        public SecurityContextFactory(ISecurityDatabaseConnectionStringProvider connectionStringProvider, DatabaseEngine databaseEngine)
        {
            _connectionStringProvider = connectionStringProvider;
            _databaseEngine = databaseEngine;
        }

        public ISecurityContext CreateContext()
        {
            if (_securityContextTypeByDatabaseEngine.TryGetValue(_databaseEngine, out Type contextType))
            {
                return Activator.CreateInstance(contextType, _connectionStringProvider.GetConnectionString()) as ISecurityContext;
            }

            throw new InvalidOperationException(
                $"Cannot create an SecurityContext for database type {_databaseEngine.DisplayName}");
        }
    }
}
#endif
