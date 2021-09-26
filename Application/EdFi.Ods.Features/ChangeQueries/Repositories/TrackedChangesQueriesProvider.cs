// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Generator.Database.NamingConventions;
using log4net;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public class TrackedChangesQueriesProvider : ITrackedChangesQueriesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TrackedChangesQueriesProvider));

        private readonly Compiler _sqlCompiler;
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;
        private readonly IDatabaseNamingConvention _namingConvention;

        public TrackedChangesQueriesProvider(
            Compiler sqlCompiler, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention)
        {
            _sqlCompiler = sqlCompiler;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
            _namingConvention = namingConvention;
        }
        
        public TrackedChangesQueries GetQueries(DbConnection connection, Resource resource, IQueryParameters queryParameters, Query templateQuery)
        {
            var db = new QueryFactory(connection, _sqlCompiler);

            if (_logger.IsDebugEnabled)
            {
                db.Logger = compiled =>
                {
                    _logger.Debug(compiled.ToString());
                };
            }
            
            // Prepare the queries
            var queries = new TrackedChangesQueries(GetDeletedItemsQuery(), GetCountQuery());
            return queries;
            
            Query GetDeletedItemsQuery()
            {
                var query = db.FromQuery(templateQuery);

                ApplyPaging(query);
                ApplyChangeVersionCriteria(query);

                if (_logger.IsDebugEnabled)
                {
                    var sqlResult = _sqlCompiler.Compile(query);
                    _logger.Debug(sqlResult.Sql);
                }

                return query;
            }

            Query GetCountQuery()
            {
                if (queryParameters.TotalCount)
                {
                    var countQuery = db.FromQuery(templateQuery);
                    ApplyChangeVersionCriteria(countQuery);

                    return countQuery;
                }

                return null;
            }

            void ApplyPaging(Query query)
            {
                query.Offset(queryParameters.Offset ?? 0);
                query.Limit(Math.Min(queryParameters.Limit ?? 25, _defaultPageSizeLimitProvider.GetDefaultPageSizeLimit()));
            }

            void ApplyChangeVersionCriteria(Query query)
            {
                if (queryParameters.MinChangeVersion.HasValue || queryParameters.MaxChangeVersion.HasValue)
                {
                    query.Where(
                        q => q.Where(
                                q2 =>
                                {
                                    if (queryParameters.MinChangeVersion.HasValue)
                                    {
                                        q2.Where(
                                            $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}",
                                            ">=",
                                            new Variable("@MinChangeVersion"));
                                    }

                                    if (queryParameters.MaxChangeVersion.HasValue)
                                    {
                                        q2.Where(
                                            $"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}",
                                            "<=",
                                            new Variable("@MaxChangeVersion"));
                                    }

                                    return q2;
                                })
                            .OrWhereNull($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{_namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName)}"));
                }

                if (queryParameters.MinChangeVersion.HasValue)
                {
                    query.Variables["@MinChangeVersion"] = queryParameters.MinChangeVersion;
                }

                if (queryParameters.MinChangeVersion.HasValue)
                {
                    query.Variables["@MaxChangeVersion"] = queryParameters.MaxChangeVersion;
                }
            }
        }
    }
}
