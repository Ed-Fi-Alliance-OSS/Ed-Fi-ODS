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

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueriesProvider : IKeyChangesQueriesProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(KeyChangesQueriesProvider));

        private readonly Compiler _sqlCompiler;
        private readonly IDefaultPageSizeLimitProvider _defaultPageSizeLimitProvider;
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly IKeyChangesQueryMetadataProvider _keyChangesQueryMetadataProvider;

        public KeyChangesQueriesProvider(
            Compiler sqlCompiler, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider,
            IDatabaseNamingConvention namingConvention,
            IKeyChangesQueryMetadataProvider keyChangesQueryMetadataProvider)
        {
            _sqlCompiler = sqlCompiler;
            _defaultPageSizeLimitProvider = defaultPageSizeLimitProvider;
            _namingConvention = namingConvention;
            _keyChangesQueryMetadataProvider = keyChangesQueryMetadataProvider;
        }
        
        public TrackedChangesQueries GetQueries(DbConnection connection, Resource resource, IQueryParameters queryParameters)
        {
            var db = new QueryFactory(connection, _sqlCompiler);

            if (_logger.IsDebugEnabled)
            {
                db.Logger = compiled =>
                {
                    _logger.Debug(compiled.ToString());
                };
            }
            
            var templateQuery = _keyChangesQueryMetadataProvider.GetTemplateQuery(resource);

            // Prepare the queries
            var keyChangesQueries = new TrackedChangesQueries(GetKeyChangesQuery(), GetCountQuery());
            
            return keyChangesQueries;
            
            Query GetKeyChangesQuery()
            {
                var keyChangesQuery = db.FromQuery(templateQuery);

                ApplyPaging(keyChangesQuery);
                ApplyChangeVersionCriteria(keyChangesQuery);

                if (_logger.IsDebugEnabled)
                {
                    var sqlResult = _sqlCompiler.Compile(keyChangesQuery);
                    _logger.Debug(sqlResult.Sql);
                }

                return keyChangesQuery;
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
