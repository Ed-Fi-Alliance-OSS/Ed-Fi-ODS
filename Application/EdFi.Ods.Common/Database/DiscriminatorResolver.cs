// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Database;

/// <summary>
/// Resolves discriminator values for abstract entities by querying the database.
/// Uses the established Ed-Fi QueryBuilder pattern for database abstraction across all database engines.
/// </summary>
public class DiscriminatorResolver : IDiscriminatorResolver
{
    private readonly IOdsDatabaseConnectionStringProvider _connectionStringProvider;
    private readonly DbProviderFactory _dbProviderFactory;
    private readonly Dialect _dialect;
    private readonly DatabaseEngine _databaseEngine;

    public DiscriminatorResolver(
        IOdsDatabaseConnectionStringProvider connectionStringProvider,
        DbProviderFactory dbProviderFactory,
        Dialect dialect,
        DatabaseEngine databaseEngine)
    {
        _connectionStringProvider = connectionStringProvider;
        _dbProviderFactory = dbProviderFactory;
        _dialect = dialect;
        _databaseEngine = databaseEngine;
    }

    public IReadOnlyList<string> GetDistinctDiscriminators(
        string schema,
        string tableName,
        Entity parentEntity,
        Guid parentId,
        int maxResults = 1)
    {
        try
        {
            using var conn = CreateConnection();
            conn.Open();

            var naturalKeyValues = ResolveNaturalKeys(conn, schema, parentEntity, parentId);
            if (naturalKeyValues == null || !naturalKeyValues.Any())
            {
                return Array.Empty<string>();
            }

            // Query for discriminators for dependent table
            return QueryDiscriminators(conn, schema, tableName, naturalKeyValues, maxResults);
        }
        catch
        {
            // Swallow errors in discriminator resolution; not critical to core operation
            return Array.Empty<string>();
        }

        DbConnection CreateConnection()
        {
            var conn = _dbProviderFactory.CreateConnection();
            conn.ConnectionString = _connectionStringProvider.GetConnectionString();

            return conn;
        }

        Dictionary<string, object> ResolveNaturalKeys(
            DbConnection conn,
            string schema,
            Entity parentEntity,
            Guid parentId)
        {
            // Build SELECT for identifier properties (e.g., StudentUSI for Student)
            var identifiers = parentEntity.Identifier.Properties.Select(p => p.PropertyName).ToList();
            if (!identifiers.Any()) return null;

            var qb = new QueryBuilder(_dialect)
                .From($"{schema}.{parentEntity.TableName(_databaseEngine)}")
                .Select(identifiers.ToArray())
                .Where("Id", parentId);

            var template = qb.BuildTemplate();

            var result = conn.QueryFirstOrDefault(template.RawSql, template.Parameters);
            if (result == null) return null;

            var keys = new Dictionary<string, object>();
            var resultDict = (IDictionary<string, object>)result;

            foreach (var identifier in identifiers)
            {
                if (resultDict.TryGetValue(identifier, out var value))
                {
                    keys[identifier] = value;
                }
            }

            return keys;
        }

        IReadOnlyList<string> QueryDiscriminators(
            DbConnection conn,
            string schema,
            string tableName,
            Dictionary<string, object> naturalKeys,
            int maxResults)
        {
            var qb = new QueryBuilder(_dialect)
                .From($"{schema}.{tableName}")
                .Select("Discriminator")
                .Distinct();

            foreach (var key in naturalKeys)
            {
                qb.Where(key.Key, key.Value);
            }

            var template = qb.BuildTemplate();

            var discriminators = conn.Query<string>(template.RawSql, template.Parameters);

            return discriminators.ToList();
        }
    }
}
