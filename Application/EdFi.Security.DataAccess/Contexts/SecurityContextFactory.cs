// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Common.Configuration;
using EdFi.Security.DataAccess.Providers;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Security.DataAccess.Contexts
{
    public class SecurityContextFactory : ISecurityContextFactory
    {
        private readonly ISecurityDatabaseConnectionStringProvider _connectionStringProvider;
        private readonly DatabaseEngine _databaseEngine;
        private readonly IDictionary<DatabaseEngine, Type> _securityContextTypeByDatabaseEngine =
            new Dictionary<DatabaseEngine, Type>
            {
                { DatabaseEngine.SqlServer, typeof(SqlServerSecurityContext) },
                { DatabaseEngine.Postgres, typeof(PostgresSecurityContext) }
            };

        public SecurityContextFactory(ISecurityDatabaseConnectionStringProvider connectionStringProvider,
            DatabaseEngine databaseEngine)
        {
            _connectionStringProvider = connectionStringProvider;
            _databaseEngine = databaseEngine;
        }

        public Type GetSecurityContextType()
        {
            if (_securityContextTypeByDatabaseEngine.TryGetValue(_databaseEngine, out Type contextType))
            {
                return contextType;
            }

            throw new InvalidOperationException(
                $"No SecurityContext defined for database type {_databaseEngine.DisplayName}");
        }

        public ISecurityContext CreateContext()
        {
            if (_databaseEngine == DatabaseEngine.SqlServer)
            {
                return Activator.CreateInstance(
                        GetSecurityContextType(),
                        new DbContextOptionsBuilder<SqlServerSecurityContext>()
                            .UseSqlServer(_connectionStringProvider.GetConnectionString())
                            .Options) as
                    ISecurityContext;
            }

            if (_databaseEngine == DatabaseEngine.Postgres)
            {
                return Activator.CreateInstance(
                        GetSecurityContextType(),
                        new DbContextOptionsBuilder<PostgresSecurityContext>()
                            .UseNpgsql(_connectionStringProvider.GetConnectionString())
                            .UseLowerCaseNamingConvention()
                            .Options) as
                    ISecurityContext;
            }

            throw new InvalidOperationException(
                $"Cannot create an SecurityContext for database type {_databaseEngine.DisplayName}");
        }
    }
}