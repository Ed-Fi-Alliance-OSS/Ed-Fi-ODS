// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Security.DataAccess.Contexts
{
    public class SecurityContextFactory : ISecurityContextFactory
    {
        private readonly IApiConfigurationProvider _configurationProvider;
        private readonly IDictionary<DatabaseEngine, Type> _securityContextTypeByDatabaseEngine =
            new Dictionary<DatabaseEngine, Type>
            {
                {DatabaseEngine.SqlServer, typeof(SqlServerSecurityContext)},
                {DatabaseEngine.Postgres, typeof(PostgresSecurityContext)}
            };

        public SecurityContextFactory(IApiConfigurationProvider configurationProvider)
        {
            _configurationProvider = Preconditions.ThrowIfNull(configurationProvider, nameof(configurationProvider));
        }

        public ISecurityContext CreateContext()
        {
            if (_securityContextTypeByDatabaseEngine.TryGetValue(_configurationProvider.DatabaseEngine, out Type contextType))
            {
                return Activator.CreateInstance(contextType) as ISecurityContext;
            }

            throw new InvalidOperationException(
                $"Cannot create an SecurityContext for database type {_configurationProvider.DatabaseEngine.DisplayName}");
        }
    }
}
#endif