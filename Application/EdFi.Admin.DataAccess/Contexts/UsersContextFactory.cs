// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class UsersContextFactory : IUsersContextFactory
    {
        private readonly Dictionary<DatabaseEngine, Type> _usersContextTypeByDatabaseEngine;

        private readonly IApiConfigurationProvider _configurationProvider;

        public UsersContextFactory(IApiConfigurationProvider configurationProvider) {
            _configurationProvider = Preconditions.ThrowIfNull(configurationProvider, nameof(configurationProvider));

            _usersContextTypeByDatabaseEngine = new Dictionary<DatabaseEngine, Type>
            {
                { DatabaseEngine.SqlServer, typeof(SqlServerUsersContext) },
                { DatabaseEngine.Postgres, typeof(PostgresUsersContext) }
            };
        }

        public IUsersContext CreateContext()
        {
            if (_usersContextTypeByDatabaseEngine.TryGetValue(_configurationProvider.DatabaseEngine, out Type contextType))
            {
                return Activator.CreateInstance(contextType) as IUsersContext;
            }

            throw new InvalidOperationException($"Cannot create an IUsersContext for database type {_configurationProvider.DatabaseEngine.DisplayName}");
        }
    }
}
