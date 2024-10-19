// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Autofac.Features.Indexed;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Queries.Criteria;
using EdFi.Ods.Common.Providers.Queries.Paging;
using NHibernate;

namespace EdFi.Ods.Common.Providers.Queries
{
    /// <summary>
    /// Builds a query that retrieves the Ids for the next page of data.
    /// </summary>
    public class PagedAggregateIdsQueryBuilderProvider : NHibernateRepositoryOperationBase, IAggregateRootQueryBuilderProvider
    {
        public const string RegistrationKey = "PagedAggregateIds";

        private readonly IIndex<PagingStrategy, IPagingStrategy> _pagingStrategies;
        private readonly IAggregateRootQueryCriteriaApplicator[] _additionalParametersCriteriaApplicator;
        private readonly Dialect _dialect;
        private readonly DatabaseEngine _databaseEngine;

        private readonly ConcurrentDictionary<ulong, QueryBuilder> _queryBuilderByEntity = new();
        private readonly bool _resourceSerializationEnabled;

        public PagedAggregateIdsQueryBuilderProvider(
            IIndex<PagingStrategy, IPagingStrategy> pagingStrategies,
            IAggregateRootQueryCriteriaApplicator[] additionalParametersCriteriaApplicator,
            ISessionFactory sessionFactory, 
            Dialect dialect,
            DatabaseEngine databaseEngine,
            ApiSettings apiSettings)
            : base(sessionFactory)
        {
            _resourceSerializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ResourceSerialization.GetConfigKeyName());

            _pagingStrategies = pagingStrategies;
            _additionalParametersCriteriaApplicator = additionalParametersCriteriaApplicator;
            _dialect = dialect;
            _databaseEngine = databaseEngine;
        }

        /// <summary>
        /// Get a <see cref="QueryBuilder"/> containing the query that retrieves the Ids for the next page of data.
        /// </summary>
        /// <param name="aggregateRootEntity"></param>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <param name="additionalParameters">Additional query string parameters provided by the API client which aren't properties on the resource nor common parameters.</param>
        /// <returns>The <see cref="QueryBuilder"/> instance representing the query.</returns>
        public QueryBuilder GetQueryBuilder(
            Entity aggregateRootEntity,
            AggregateRootWithCompositeKey specification,
            IQueryParameters queryParameters,
            IDictionary<string, string> additionalParameters)
        {
            // Initialize paging information
            var pagingParameters = new PagingParameters(queryParameters);

            // Get the base query
            var idQueryBuilder = GetQueryBuilder(aggregateRootEntity, pagingParameters);

            // Add special query fields
            AggregateQueryBuilderHelpers.ProcessCommonQueryParameters(idQueryBuilder, queryParameters);

            // Apply additional parameters, as applicable
            foreach (var applicator in _additionalParametersCriteriaApplicator)
            {
                applicator.ApplyAdditionalParameters(idQueryBuilder, aggregateRootEntity, specification, additionalParameters);
            }

            return idQueryBuilder;
        }

        private QueryBuilder GetQueryBuilder(Entity aggregateRootEntity, PagingParameters pagingParameters)
        {
            if (!_pagingStrategies.TryGetValue(pagingParameters.PagingStrategy, out var pagingStrategy))
            {
                throw new NotSupportedException($"Paging strategy '{pagingParameters.PagingStrategy}' is not supported.");
            }

            ulong queryHash = XxHash3Code.Combine(aggregateRootEntity.FullName.ToString(), (int) pagingParameters.PagingStrategy);

            var cloneableQuery = _queryBuilderByEntity.GetOrAdd(
                queryHash,
                static (hash, args) =>
                {
                    var (dialect, databaseEngine, aggregateRootEntity, pagingParameters, pagingStrategy, resourceSerializationEnabled) = args;

                    var idQueryBuilder = new QueryBuilder(dialect);

                    // Get the fully qualified physical table name
                    var schemaTableName = $"{aggregateRootEntity.Schema}.{aggregateRootEntity.TableName(databaseEngine)}";

                    string rootTableAlias = aggregateRootEntity.IsDerived
                        ? "b"
                        : "r";

                    idQueryBuilder
                        .From(schemaTableName.Alias("r"))
                        .Select($"{rootTableAlias}.AggregateId");

                    if (resourceSerializationEnabled)
                    {
                        idQueryBuilder
                            .Select($"{rootTableAlias}.Json")
                            .Select($"{rootTableAlias}.LastModifiedDate");
                    }

                    // NOTE: Optimization opportunity - th ederived entity may not be needed unless there is criteria to be applied that uses the derived type.
                    // This would eliminate a join with every page. Will need to include Discriminator value in join in lieu of join to base.

                    // Add the join to the base type
                    if (aggregateRootEntity.IsDerived)
                    {
                        idQueryBuilder.Join(
                            $"{aggregateRootEntity.BaseEntity.Schema}.{aggregateRootEntity.BaseEntity.TableName(databaseEngine)} AS b",
                            j =>
                            {
                                foreach (var propertyMapping in aggregateRootEntity.BaseAssociation.PropertyMappings)
                                {
                                    j.On(
                                        $"r.{propertyMapping.ThisProperty.ColumnNameByDatabaseEngine[databaseEngine]}",
                                        $"b.{propertyMapping.OtherProperty.ColumnNameByDatabaseEngine[databaseEngine]}");
                                }

                                return j;
                            });
                    }

                    pagingStrategy.ApplyPaging(idQueryBuilder, pagingParameters);

                    // Order the results
                    idQueryBuilder.OrderBy($"{rootTableAlias}.AggregateId");

                    return idQueryBuilder;
                },
                (_dialect, _databaseEngine, aggregateRootEntity, pagingParameters, pagingStrategy, _resourceSerializationEnabled));

            var idQueryBuilder = cloneableQuery.Clone();
            pagingStrategy.ApplyPagingParameters(idQueryBuilder.Parameters, pagingParameters);

            return idQueryBuilder;
        }
    }
}
