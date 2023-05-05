// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Infrastructure;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Features.ChangeQueries.Providers
{
    /// <summary>
    /// Implements an <see cref="AvailableChangeVersionProvider"/> that get the ids of the earliest (oldest) and most
    /// recent (newest) change version available using a standard SQL query executed using the connection
    /// provided by NHibernate.
    /// </summary>
    public class AvailableChangeVersionProvider : IAvailableChangeVersionProvider
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly IOdsDatabaseConnectionStringProvider _odsDatabaseConnectionStringProvider;

        public AvailableChangeVersionProvider(
            DbProviderFactory dbProviderFactory,
            IOdsDatabaseConnectionStringProvider odsDatabaseConnectionStringProvider)
        {
            _dbProviderFactory = dbProviderFactory;
            _odsDatabaseConnectionStringProvider = odsDatabaseConnectionStringProvider;
        }

        /// <summary>
        /// Gets the ids of the earliest (oldest) and most recent (newest) change events available.
        /// </summary>
        /// <returns>A newly created <see cref="AvailableChangeVersion"/> instance.</returns>
        public async Task<AvailableChangeVersion> GetAvailableChangeVersion()
        {
            var cmdSql =
                $@"SELECT {ChangeQueriesDatabaseConstants.SchemaName}.GetMaxChangeVersion() as NewestChangeVersion";

            await using var conn = _dbProviderFactory.CreateConnection();

            conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetReadReplicaConnectionString()
                ?? _odsDatabaseConnectionStringProvider.GetConnectionString();

            await conn.OpenAsync();

            var maxChangeVersion = await conn.ExecuteScalarAsync<long>(cmdSql);
            
            return new AvailableChangeVersion { NewestChangeVersion = maxChangeVersion };
        }
    }
}
