// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common;
using EdFi.Common.Configuration;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class UsersContextFactory : IUsersContextFactory
    {
        private readonly Dictionary<DatabaseEngine, Type> _usersContextTypeByDatabaseEngine = new()
        {
            {DatabaseEngine.SqlServer, typeof(SqlServerUsersContext)},
            {DatabaseEngine.Postgres, typeof(PostgresUsersContext)}
        };

        private readonly DatabaseEngine _databaseEngine;

        private readonly IAdminDatabaseConnectionStringProvider _connectionStringsProvider;

        public UsersContextFactory(IAdminDatabaseConnectionStringProvider connectionStringsProvider, DatabaseEngine databaseEngine)
        {
            _connectionStringsProvider = Preconditions.ThrowIfNull(connectionStringsProvider, nameof(connectionStringsProvider));
            _databaseEngine =  Preconditions.ThrowIfNull(databaseEngine, nameof(databaseEngine));
        }

        public IUsersContext CreateContext()
        {
            if (_usersContextTypeByDatabaseEngine.TryGetValue(_databaseEngine, out Type contextType))
            {
                return Activator.CreateInstance(contextType, _connectionStringsProvider.GetConnectionString()) as IUsersContext;
            }

            throw new InvalidOperationException(
                $"Cannot create an IUsersContext for database type {_databaseEngine.DisplayName}");
        }
    }
}
