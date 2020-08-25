// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Contexts;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Admin.Contexts
{
    public class IdentityContextFactory : IIdentityContextFactory
    {
        private readonly Dictionary<DatabaseEngine, Type> _identityContextTypeByDatabaseEngine =
            new Dictionary<DatabaseEngine, Type>
            {
                {DatabaseEngine.SqlServer, typeof(SqlServerIdentityContext)},
                {DatabaseEngine.Postgres, typeof(PostgresIdentityContext)}
            };

        private readonly DatabaseEngine _databaseEngine;

        private readonly IDatabaseConnectionStringProvider _connectionStringsProvider;

        public IdentityContextFactory(IAdminDatabaseConnectionStringProvider connectionStringsProvider,
            DatabaseEngine databaseEngine)
        {
            _connectionStringsProvider = connectionStringsProvider;
            _databaseEngine = databaseEngine;
        }

        public IdentityContext CreateContext()
        {
            if (_identityContextTypeByDatabaseEngine.TryGetValue(_databaseEngine, out Type contextType))
            {
                return Activator.CreateInstance(contextType, _connectionStringsProvider.GetConnectionString()) as IdentityContext;
            }

            throw new InvalidOperationException(
                $"Cannot create an IIdentityContext  for database type
                {_databaseEngine.DisplayName}");
        }
    }
}
#endif