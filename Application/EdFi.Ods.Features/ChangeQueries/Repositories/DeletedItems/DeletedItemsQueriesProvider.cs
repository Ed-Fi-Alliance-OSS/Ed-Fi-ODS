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

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueriesProvider : IDeletedItemsQueriesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletedItemsQueriesProvider));

        private readonly Compiler _sqlCompiler;
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly IDeletedItemsQueryMetadataProvider _deletedItemsQueryMetadataProvider;

        public DeletedItemsQueriesProvider(
            Compiler sqlCompiler, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention,
            IDeletedItemsQueryMetadataProvider deletedItemsQueryMetadataProvider)
        {
            _sqlCompiler = sqlCompiler;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
            _namingConvention = namingConvention;
            _deletedItemsQueryMetadataProvider = deletedItemsQueryMetadataProvider;
        }
        
        public DeletedItemsQueries GetQueries(DbConnection connection, Resource resource, IQueryParameters queryParameters)
        {
            var db = new QueryFactory(connection, _sqlCompiler);

            var templateQuery = _deletedItemsQueryMetadataProvider.GetTemplateQuery(resource);

            // Prepare the queries
            var deletedItemsQueries = new DeletedItemsQueries(GetDeletedItemsQuery(), GetCountQuery());
            return deletedItemsQueries;
            
            Query GetDeletedItemsQuery()
            {
                var deletesQuery = db.FromQuery(templateQuery);

                ApplyPaging(deletesQuery);
                ApplyChangeVersionCriteria(deletesQuery);

                if (_logger.IsDebugEnabled)
                {
                    var sqlResult = _sqlCompiler.Compile(deletesQuery);
                    _logger.Debug(sqlResult.Sql);
                }

                return deletesQuery;
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
