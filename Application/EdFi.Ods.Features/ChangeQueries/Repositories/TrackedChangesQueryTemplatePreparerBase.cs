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
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public abstract class TrackedChangesQueryTemplatePreparerBase : ITrackedChangesQueryTemplatePreparer
    {
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;
        private readonly ITrackedChangesQueryBuilderFactory _queryBuilderFactory;
        protected readonly string ChangeVersionColumnName;

        protected readonly string IdColumnName;

        protected TrackedChangesQueryTemplatePreparerBase(
            ITrackedChangesQueryBuilderFactory queryBuilderFactory,
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention)
        {
            _queryBuilderFactory = queryBuilderFactory;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;

            IdColumnName = namingConvention.ColumnName("Id");
            ChangeVersionColumnName = namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName);
        }

        public TrackedChangesQueryTemplates PrepareQueryTemplates(IQueryParameters queryParameters, Resource resource)
        {
            var queryBuilder = _queryBuilderFactory.CreateQueryBuilder(resource);

            // Finalize the query builders, cloning them and then applying request-specific parameters
            var dataQueryBuilder = FinalizeDataQueryBuilder(queryBuilder.Clone(), queryParameters, resource);

            var queries = new TrackedChangesQueryTemplates(
                dataQueryBuilder.BuildTemplate(),
                queryParameters.TotalCount ? dataQueryBuilder.BuildCountTemplate() : null);

            return queries;
        }

        protected abstract QueryBuilder FinalizeDataQueryBuilder(
            QueryBuilder queryBuilder,
            IQueryParameters queryParameters,
            Resource resource);

        protected void ApplyPaging(QueryBuilder queryBuilder, IQueryParameters queryParameters)
        {
            queryBuilder.LimitOffset(
                limit: queryParameters.Limit ?? _defaultPageSizeLimitProvider.GetDefaultPageSizeLimit(),
                offset: queryParameters.Offset ?? 0);
        }

        protected void ApplyChangeVersionCriteria(QueryBuilder queryBuilder, IQueryParameters queryParameters)
        {
            if (queryParameters.MinChangeVersion.HasValue || queryParameters.MaxChangeVersion.HasValue)
            {
                queryBuilder.Where(
                    q => q.OrWhere(
                            q2 =>
                            {
                                if (queryParameters.MinChangeVersion.HasValue)
                                {
                                    q2.Where(
                                        $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{ChangeVersionColumnName}",
                                        ">=",
                                        new Parameter("@MinChangeVersion", queryParameters.MinChangeVersion));
                                }

                                if (queryParameters.MaxChangeVersion.HasValue)
                                {
                                    q2.Where(
                                        $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{ChangeVersionColumnName}",
                                        "<=",
                                        new Parameter("@MaxChangeVersion", queryParameters.MaxChangeVersion));
                                }

                                return q2;
                            })
                        .OrWhereNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{ChangeVersionColumnName}"));
            }
        }
    }
}
