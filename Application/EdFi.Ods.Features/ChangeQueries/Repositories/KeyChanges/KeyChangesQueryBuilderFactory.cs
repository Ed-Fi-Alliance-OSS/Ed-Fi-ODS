// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueryBuilderFactory : IKeyChangesQueryBuilderFactory
    {
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly Func<QueryBuilder> _createQueryBuilder;

        private readonly ConcurrentDictionary<FullName, QueryBuilder> _queryBuilderByResourceName =
            new ConcurrentDictionary<FullName, QueryBuilder>();

        public KeyChangesQueryBuilderFactory(IDatabaseNamingConvention namingConvention, Func<QueryBuilder> createQueryBuilder)
        {
            _namingConvention = namingConvention;
            _createQueryBuilder = createQueryBuilder;
        }

        public QueryBuilder CreateQueryBuilder(Resource resource)
        {
            // Optimize by caching the constructed query
            var baselineQueryBuilder = _queryBuilderByResourceName.GetOrAdd(
                resource.FullName,
                fn => CreateBaselineQueryBuilder(resource));

            // Copy the baseline query builder before returning it (to preserve original for future use)
            return baselineQueryBuilder.Clone();
        }

        private QueryBuilder CreateBaselineQueryBuilder(Resource resource)
        {
            // Derive column names
            string idColumnFqn = $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}";

            var changeVersionColumnFqn =
                $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}";

            string initialChangeVersionColumnName = _namingConvention.ColumnName("InitialChangeVersion");
            string finalChangeVersionColumnName = _namingConvention.ColumnName("FinalChangeVersion");

            var entity = resource.Entity;

            // Build the CTE query
            var changeWindowVersionsCteQuery = QueryFactoryHelper.CreateBaseTrackedChangesQuery(_createQueryBuilder, _namingConvention, entity)
                .Select(idColumnFqn)
                .SelectRaw($"MIN({changeVersionColumnFqn}) AS {initialChangeVersionColumnName}")
                .SelectRaw($"MAX({changeVersionColumnFqn}) AS {finalChangeVersionColumnName}")
                .GroupBy(idColumnFqn);

            QueryFactoryHelper.ApplyDiscriminatorCriteriaForDerivedEntities(
                changeWindowVersionsCteQuery,
                entity,
                _namingConvention);

            // Apply criteria for only including key changes
            var firstIdentifierProperty = (entity.IsDerived
                ? entity.BaseEntity
                : entity).Identifier.Properties.First();

            string columnName = _namingConvention.ColumnName(
                $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{firstIdentifierProperty.PropertyName}");

            changeWindowVersionsCteQuery.WhereNotNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{columnName}");

            return changeWindowVersionsCteQuery;
        }
    }
}
