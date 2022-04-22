// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Compilers;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using log4net;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public abstract class TrackedChangesQueriesPreparerBase : ITrackedChangesQueriesPreparer
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TrackedChangesQueriesPreparerBase));

        private readonly Compiler _sqlCompiler;
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;
        private readonly IDatabaseNamingConvention _namingConvention;

        protected TrackedChangesQueriesPreparerBase(
            Compiler sqlCompiler, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention)
        {
            _sqlCompiler = sqlCompiler;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
            _namingConvention = namingConvention;
        }

        public TrackedChangesQueries PrepareQueries(
            DbConnection connection,
            Query mainQuery,
            IQueryParameters queryParameters,
            Resource resource)
        {
            var db = new QueryFactory(connection, _sqlCompiler);

            if (_logger.IsDebugEnabled)
            {
                db.Logger = compiled => { _logger.Debug(compiled.ToString()); };
            }

            // Prepare the queries
            var queries = new TrackedChangesQueries(
                PrepareDataQuery(db, mainQuery, queryParameters, resource), 
                PrepareCountQuery(db, mainQuery, queryParameters));

            return queries;
        }

        protected abstract Query PrepareDataQuery(
            QueryFactory db,
            Query mainQuery,
            IQueryParameters queryParameters,
            Resource resource);
        
        protected virtual Query PrepareCountQuery(QueryFactory db, Query mainQuery, IQueryParameters queryParameters)
        {
            if (queryParameters.TotalCount)
            {
                var countQuery = db.FromQuery(mainQuery);
                ApplyChangeVersionCriteria(countQuery, queryParameters);

                return countQuery;
            }

            return null;
        }

        protected void ApplyPaging(Query query, IQueryParameters queryParameters)
        {
            query.Offset(queryParameters.Offset ?? 0);
            query.Limit(Math.Min(queryParameters.Limit ?? 25, _defaultPageSizeLimitProvider.GetDefaultPageSizeLimit()));
        }

        protected void ApplyChangeVersionCriteria(Query query, IQueryParameters queryParameters)
        {
            if (queryParameters.MinChangeVersion.HasValue || queryParameters.MaxChangeVersion.HasValue)
            {
                query.Where(
                    q => q.OrWhere(
                            q2 =>
                            {
                                if (queryParameters.MinChangeVersion.HasValue)
                                {
                                    q2.Where(
                                        $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}",
                                        ">=",
                                        new Parameter("@MinChangeVersion", queryParameters.MinChangeVersion));
                                }

                                if (queryParameters.MaxChangeVersion.HasValue)
                                {
                                    q2.Where(
                                        $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}",
                                        "<=",
                                        new Parameter("@MaxChangeVersion", queryParameters.MaxChangeVersion));
                                }

                                return q2;
                            })
                        .OrWhereNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}"));
            }
        }
    }
}
