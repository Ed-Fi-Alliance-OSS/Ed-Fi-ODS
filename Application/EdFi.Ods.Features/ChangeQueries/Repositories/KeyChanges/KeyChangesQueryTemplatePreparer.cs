// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueryTemplatePreparer : TrackedChangesQueryTemplatePreparerBase, IKeyChangesQueryTemplatePreparer
    {
        private readonly Func<QueryBuilder> _createQueryBuilder;
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public KeyChangesQueryTemplatePreparer(
            IKeyChangesQueryBuilderFactory queryBuilderFactory,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider,
            Func<QueryBuilder> createQueryBuilder)
            : base(queryBuilderFactory, defaultPageSizeLimitProvider, namingConvention)
        {
            _namingConvention = namingConvention;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
            _createQueryBuilder = createQueryBuilder;
        }

        protected override QueryBuilder FinalizeDataQueryBuilder(
            QueryBuilder queryBuilder,
            IQueryParameters queryParameters,
            Resource resource)
        {
            // Apply the change version filtering to the query (which is to be used as a CTE in this case)
            ApplyChangeVersionCriteria(queryBuilder, queryParameters);

            // Create the data query that uses the main query provided as a CTE
            var keyChangesDataQuery = CreateKeyChangesDataQueryBuilder(queryBuilder, resource);

            // Apply paging
            ApplyPaging(keyChangesDataQuery, queryParameters);

            return keyChangesDataQuery;
        }

        private QueryBuilder CreateKeyChangesDataQueryBuilder(QueryBuilder changeWindowVersionsCteQueryBuilder, Resource resource)
        {
            var entity = resource.Entity;

            string changeQueriesTableName =
                $"{ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix}{_namingConvention.Schema(entity)}.{_namingConvention.TableName(entity)}";

            string oldAlias =
                $"{_namingConvention.IdentifierName(ChangeQueriesDatabaseConstants.TrackedChangesAlias, suffix: "_old")}";

            string newAlias =
                $"{_namingConvention.IdentifierName(ChangeQueriesDatabaseConstants.TrackedChangesAlias, suffix: "_new")}";

            string changeWindowCteName = _namingConvention.IdentifierName("ChangeWindow");
            const string ChangeWindowAlias = "cw";

            string initialChangeVersionColumnName = _namingConvention.ColumnName("InitialChangeVersion");
            string finalChangeVersionColumnName = _namingConvention.ColumnName("FinalChangeVersion");

            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            var dataQuery = _createQueryBuilder()
                .From($"{changeWindowCteName} AS {ChangeWindowAlias}")
                .With(changeWindowCteName, changeWindowVersionsCteQueryBuilder)
                .Join(
                    $"{changeQueriesTableName} AS {oldAlias}",
                    j => j.On($"{ChangeWindowAlias}.{IdColumnName}", $"{oldAlias}.{IdColumnName}")
                        .On($"{ChangeWindowAlias}.{initialChangeVersionColumnName}", $"{oldAlias}.{ChangeVersionColumnName}"))
                .Join(
                    $"{changeQueriesTableName} AS {newAlias}",
                    j => j.On($"{ChangeWindowAlias}.{IdColumnName}", $"{newAlias}.{IdColumnName}")
                        .On($"{ChangeWindowAlias}.{finalChangeVersionColumnName}", $"{newAlias}.{ChangeVersionColumnName}"))
                .Select(
                    $"{ChangeWindowAlias}.{IdColumnName}",
                    $"{ChangeWindowAlias}.{finalChangeVersionColumnName} AS {ChangeVersionColumnName}")
                .Select(QueryFactoryHelper.IdentifyingColumns(identifierProjections, oldAlias, newAlias))
                .OrderBy($"{ChangeWindowAlias}.{finalChangeVersionColumnName}");

            return dataQuery;
        }
    }
}
