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

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueryBuilderFactory : IDeletedItemsQueryBuilderFactory
    {
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        private const string SourceTableAlias = "src";

        private readonly ConcurrentDictionary<FullName, QueryBuilder> _queryBuilderByResourceName =
            new ConcurrentDictionary<FullName, QueryBuilder>();

        private readonly Func<QueryBuilder> _createQueryBuilder;

        public DeletedItemsQueryBuilderFactory(
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider,
            Func<QueryBuilder> createQueryBuilder)
        {
            _namingConvention = namingConvention;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
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
            var entity = resource.Entity;

            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            var baselineDeletedItemsQuery = QueryFactoryHelper.CreateBaseTrackedChangesQuery(_createQueryBuilder, _namingConvention, entity)
                .Select(
                    $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}",
                    $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}")
                .Select(QueryFactoryHelper.IdentifyingColumns(identifierProjections, columnGroups: ColumnGroups.OldValue))
                .OrderBy(
                    $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}");

            QueryFactoryHelper.ApplyDiscriminatorCriteriaForDerivedEntities(baselineDeletedItemsQuery, entity, _namingConvention);

            // Deletes-specific query filters
            ApplySourceTableExclusionForUndeletedItems();
            ApplyDeletesOnlyCriteria();

            return baselineDeletedItemsQuery;

            void ApplySourceTableExclusionForUndeletedItems()
            {
                // Source table exclusion to prevent items that have been re-added during the same change window from showing up as deletes
                baselineDeletedItemsQuery.LeftJoin(
                    $"{_namingConvention.Schema(entity)}.{_namingConvention.TableName(entity)} AS {SourceTableAlias}",
                    join =>
                    {
                        foreach (var projection in identifierProjections)
                        {
                            @join.On(
                                $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{projection.ChangeTableJoinColumnName}",
                                $"{SourceTableAlias}.{projection.SourceTableJoinColumnName}");
                        }

                        return @join;
                    });

                baselineDeletedItemsQuery.WhereNull(
                    string.Concat(SourceTableAlias, ".", identifierProjections.First().SourceTableJoinColumnName));
            }

            void ApplyDeletesOnlyCriteria()
            {
                // Only return deletes
                var firstIdentifierProperty = (entity.IsDerived
                    ? entity.BaseEntity
                    : entity).Identifier.Properties.First();

                string columnName = _namingConvention.ColumnName(
                    $"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{firstIdentifierProperty.PropertyName}");

                baselineDeletedItemsQuery.WhereNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{columnName}");
            }
        }
    }
}
