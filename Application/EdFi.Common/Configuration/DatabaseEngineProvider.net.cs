#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Configuration
{
    public class DatabaseEngineProvider: IDatabaseEngineProvider
    {
        private readonly IConfigConnectionStringsProvider _connectionStringsProvider;

        public DatabaseEngineProvider(IConfigConnectionStringsProvider connectionStringsProvider)
        {
            _connectionStringsProvider = Preconditions.ThrowIfNull(connectionStringsProvider, nameof(connectionStringsProvider));
            DatabaseEngine = ParseDatabaseEngine();
        }

        public DatabaseEngine DatabaseEngine { get; }

       private DatabaseEngine ParseDatabaseEngine()
        {
            var databaseEngines = _connectionStringsProvider.ConnectionStringProviderByName
                .Select(pair => new KeyValuePair<string, DatabaseEngine>(pair.Key, DatabaseEngine.CreateFromProviderName(pair.Value)))
                .ToList();

            var grouping = databaseEngines
                .GroupBy(x => x.Value)
                .Select(g => new KeyValuePair<DatabaseEngine, int>(g.Key, g.Count()))
                .ToList();

            if (grouping.Count != 1)
            {
                throw new NotSupportedException($"Multiple database modes are not supported. Supported database providers: {ApiConfigurationConstants.PostgresProviderName}, or {ApiConfigurationConstants.SqlServerProviderName}.");
            }

            return grouping.Single().Key;
        }
    }
}
#endif