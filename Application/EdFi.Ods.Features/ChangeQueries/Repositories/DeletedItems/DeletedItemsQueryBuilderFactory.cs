// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

using static EdFi.Ods.Features.ChangeQueries.ChangeQueriesDatabaseConstants;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueryBuilderFactory : IDeletedItemsQueryBuilderFactory
    {
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        private const string SourceTableAlias = "src";
        private const string CurrentTableAliasPrefix = "curr";

        private readonly ConcurrentDictionary<FullName, QueryBuilder> _queryBuilderByResourceName = new();

        private readonly Func<QueryBuilder> _createQueryBuilder;
        private readonly Func<ParameterIndexer, QueryBuilder> _createQueryBuilderWithIndexer;

        public DeletedItemsQueryBuilderFactory(
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider,
            Func<QueryBuilder> createQueryBuilder,
            Func<ParameterIndexer, QueryBuilder> createQueryBuilderWithIndexer)
        {
            _namingConvention = namingConvention;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
            _createQueryBuilder = createQueryBuilder;
            _createQueryBuilderWithIndexer = createQueryBuilderWithIndexer;
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

            // USIs needing translation to "current" values
            var subjectUsiProperties = entity.Identifier.Properties
                .Where(p => p.DefiningProperty.Entity.IsPersonEntity())
                .ToArray();

            QueryBuilder baselineDeletedItemsQuery; 

            if (subjectUsiProperties.Any())
            {
                // Build the CTE query
                var cteQuery = QueryFactoryHelper.CreateBaseTrackedChangesQuery(_createQueryBuilder, _namingConvention, entity);
                cteQuery.Select($"{TrackedChangesAlias}.*");

                int i = 0;
                
                foreach (var usiProperty in subjectUsiProperties)
                {
                    string uniqueIdName = usiProperty.PropertyName.ReplaceSuffix("USI", "UniqueId");

                    string tableName = _namingConvention.TableName(usiProperty.DefiningProperty.Entity);
                    string schemaName = _namingConvention.Schema(usiProperty.DefiningProperty.Entity);
                    
                    cteQuery.LeftJoin(
                        $"{schemaName}.{tableName}".Alias($"{CurrentTableAliasPrefix}{i}"),
                        $"{TrackedChangesAlias}.{_namingConvention.ColumnName($"Old{uniqueIdName}")}",
                        $"{CurrentTableAliasPrefix}{i}.{_namingConvention.ColumnName(uniqueIdName)}");

                    // Current USI
                    cteQuery.Select(
                        $"{CurrentTableAliasPrefix}{i}.{_namingConvention.ColumnName(usiProperty.DefiningProperty)} AS {_namingConvention.ColumnName($"Current{usiProperty.PropertyName}")}");

                    i++;
                }

                string cteName = "TranslatedTrackedChanges";

                QueryFactoryHelper.ApplyDiscriminatorCriteriaForDerivedEntities(cteQuery, entity, _namingConvention);

                baselineDeletedItemsQuery = _createQueryBuilderWithIndexer(cteQuery.ParameterIndexer)
                    .From(cteName.Alias(TrackedChangesAlias))
                    .With(cteName, cteQuery);
            }
            else
            {
                baselineDeletedItemsQuery = QueryFactoryHelper.CreateBaseTrackedChangesQuery(_createQueryBuilder, _namingConvention, entity);
                QueryFactoryHelper.ApplyDiscriminatorCriteriaForDerivedEntities(baselineDeletedItemsQuery, entity, _namingConvention);
            }

            baselineDeletedItemsQuery
                .Select(
                    $"{TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}",
                    $"{TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeVersionColumnName)}")
                .Select(QueryFactoryHelper.IdentifyingColumns(identifierProjections, columnGroups: ColumnGroups.OldValue))
                .Distinct()
                .OrderBy(
                    $"{TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeVersionColumnName)}");

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
                                $"{TrackedChangesAlias}.{projection.ChangeTableJoinColumnName}",
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
                    $"{NewKeyValueColumnPrefix}{firstIdentifierProperty.PropertyName}");

                baselineDeletedItemsQuery.WhereNull($"{TrackedChangesAlias}.{columnName}");
            }
        }
    }
}
