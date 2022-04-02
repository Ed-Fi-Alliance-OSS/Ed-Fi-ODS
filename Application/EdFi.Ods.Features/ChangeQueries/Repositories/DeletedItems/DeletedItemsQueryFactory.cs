// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueryFactory : IDeletedItemsQueryFactory
    {
        private const string SourceTableAlias = "src";
        private readonly IDatabaseNamingConvention _namingConvention;

        private readonly ConcurrentDictionary<FullName, Query> _queryByResourceName = new ConcurrentDictionary<FullName, Query>();
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public DeletedItemsQueryFactory(
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
        {
            _namingConvention = namingConvention;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        public Query CreateMainQuery(Resource resource)
        {
            // Optimize by caching the constructed query
            var templateQuery = _queryByResourceName.GetOrAdd(resource.FullName, fn => CreateTemplateQuery(resource));

            // Copy the query before returning it (to preserve original)
            return templateQuery.Clone();
        }

        private Query CreateTemplateQuery(Resource resource)
        {
            var entity = resource.Entity;

            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            var templateQuery = QueryFactoryHelper.CreateBaseTrackedChangesQuery(_namingConvention, entity)
                .Select(
                    $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName("Id")}",
                    $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}")
                .Select(QueryFactoryHelper.IdentifyingColumns(identifierProjections, columnGroups: ColumnGroups.OldValue))
                .OrderBy(
                    $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}");

            QueryFactoryHelper.ApplyDiscriminatorCriteriaForDerivedEntities(templateQuery, entity, _namingConvention);

            // Deletes-specific query filters
            ApplySourceTableExclusionForUndeletedItems();
            ApplyDeletesOnlyCriteria();

            return templateQuery;

            void ApplySourceTableExclusionForUndeletedItems()
            {
                // Source table exclusion to prevent items that have been re-added during the same change window from showing up as deletes
                templateQuery.LeftJoin(
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

                templateQuery.WhereNull(
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

                templateQuery.WhereNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{columnName}");
            }
        }
    }
}
