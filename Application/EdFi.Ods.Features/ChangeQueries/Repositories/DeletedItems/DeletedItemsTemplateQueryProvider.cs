// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsTemplateQueryProvider : TrackedChangesTemplateQueryProviderBase, IDeletedItemsTemplateQueryProvider
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        private const string SourceTableAlias = "src";

        public DeletedItemsTemplateQueryProvider(IDatabaseNamingConvention namingConvention)
            : base(namingConvention)
        {
            _namingConvention = namingConvention;
        }

        protected override void ApplyScenarioSpecificFilters(Query templateQuery, Entity entity, QueryProjection[] identifierProjections)
        {
            // Deletes-specific query filters
            ApplySourceTableExclusionForUndeletedItems();
            ApplyDeletesOnlyCriteria();
            
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

                templateQuery.WhereNull(string.Concat(SourceTableAlias, ".", identifierProjections.First().SourceTableJoinColumnName));
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
