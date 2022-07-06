// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

using static EdFi.Ods.Features.ChangeQueries.ChangeQueriesDatabaseConstants;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public static class QueryFactoryHelper
    {
        public static void ApplyDiscriminatorCriteriaForDerivedEntities(
            QueryBuilder queryBuilder,
            Entity entity,
            IDatabaseNamingConvention namingConvention)
        {
            // Add discriminator criteria, for derived types with a Discriminator on the base type only
            if (entity.IsDerived)
            {
                queryBuilder.Where($"{TrackedChangesAlias}.{namingConvention.ColumnName("Discriminator")}", entity.FullName.ToString());
            }
        }
        
        public static string[] IdentifyingColumns(
            QueryProjection[] identifierProjections,
            string oldColumnAlias = TrackedChangesAlias, 
            string newColumnAlias = TrackedChangesAlias,
            ColumnGroups columnGroups = ColumnGroups.OldValue | ColumnGroups.NewValue)
        {
            string[] selectColumns = identifierProjections.SelectMany(x => x.SelectColumns)
                .Where(sc => (sc.ColumnGroup & columnGroups) != 0)
                .Select(sc => $"{(sc.ColumnGroup == ColumnGroups.OldValue ? oldColumnAlias : newColumnAlias)}.{sc.ColumnName}")
                .ToArray();

            return selectColumns;
        }
        
        public static QueryBuilder CreateBaseTrackedChangesQuery(
            Func<QueryBuilder> createQueryBuilder,
            IDatabaseNamingConvention namingConvention,
            Entity entity)
        {
            var (changeTableSchema, changeTableName) = entity.IsDerived
                ? (TrackedChangesSchemaPrefix + namingConvention.Schema(entity.BaseEntity),
                    namingConvention.TableName(entity.BaseEntity))
                : (TrackedChangesSchemaPrefix + namingConvention.Schema(entity),
                    namingConvention.TableName(entity));

            var templateQuery = createQueryBuilder().From($"{changeTableSchema}.{changeTableName} AS {TrackedChangesAlias}");

            return templateQuery;
        }
    }
}