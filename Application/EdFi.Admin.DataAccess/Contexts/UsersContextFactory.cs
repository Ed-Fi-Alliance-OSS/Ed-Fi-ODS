// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
#if NETFRAMEWORK
using EdFi.Ods.Common;
#endif
using EdFi.Ods.Common.Configuration;
#if NETSTANDARD
using EdFi.Ods.Common.Database;
#endif

namespace EdFi.Admin.DataAccess.Contexts
{
    public class UsersContextFactory : IUsersContextFactory
    {
        private readonly Dictionary<DatabaseEngine, Type> _usersContextTypeByDatabaseEngine = new Dictionary<DatabaseEngine, Type>
        {
            {DatabaseEngine.SqlServer, typeof(SqlServerUsersContext)},
            {DatabaseEngine.Postgres, typeof(PostgresUsersContext)}
        };

        private readonly DatabaseEngine _databaseEngine;

#if NETFRAMEWORK
        public UsersContextFactory(IApiConfigurationProvider configurationProvider)
        {
            Preconditions.ThrowIfNull(configurationProvider, nameof(configurationProvider));
            _databaseEngine = configurationProvider.DatabaseEngine;
        }
#elif NETSTANDARD
        private readonly IDatabaseConnectionStringProvider _connectionStringsProvider;

        public UsersContextFactory(IAdminDatabaseConnectionStringProvider connectionStringsProvider, DatabaseEngine databaseEngine)
        {
            _connectionStringsProvider = connectionStringsProvider;
            _databaseEngine = databaseEngine;
        }
#endif

        public IUsersContext CreateContext()
        {
            if (_usersContextTypeByDatabaseEngine.TryGetValue(_databaseEngine, out Type contextType))
            {
#if NETFRAMEWORK
                return Activator.CreateInstance(contextType) as IUsersContext;
#elif NETSTANDARD
                return Activator.CreateInstance(contextType, _connectionStringsProvider.GetConnectionString()) as IUsersContext;
#endif
            }

            throw new InvalidOperationException(
                $"Cannot create an IUsersContext for database type {_databaseEngine.DisplayName}");
        }
    }
}
