// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Infrastructure.Listeners;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Serialization;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class GetEntitiesBySpecification<TEntity>
        : NHibernateRepositoryOperationBase, IGetEntitiesBySpecification<TEntity>
        where TEntity : AggregateRootWithCompositeKey
    {
        private static readonly IList<TEntity> _emptyList = Array.Empty<TEntity>();

        private readonly ILog _logger = LogManager.GetLogger(typeof(GetEntitiesBySpecification<TEntity>));

        private readonly IAggregateRootQueryBuilderProvider _pagedAggregateIdsCriteriaProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IEntityDeserializer _entityDeserializer;
        private readonly IGetEntitiesByAggregateIds<TEntity> _getEntitiesByAggregateIds;
        private bool _serializationEnabled;

        public GetEntitiesBySpecification(
            ISessionFactory sessionFactory,
            IGetEntitiesByAggregateIds<TEntity> getEntitiesByAggregateIds,
            [FromKeyedServices(PagedAggregateIdsQueryBuilderProvider.RegistrationKey)]
            IAggregateRootQueryBuilderProvider pagedAggregateIdsCriteriaProvider,
            IDomainModelProvider domainModelProvider,
            IEntityDeserializer entityDeserializer,
            ApiSettings apiSettings)
            : base(sessionFactory)
        {
            _getEntitiesByAggregateIds = getEntitiesByAggregateIds;
            _pagedAggregateIdsCriteriaProvider = pagedAggregateIdsCriteriaProvider;
            _domainModelProvider = domainModelProvider;
            _entityDeserializer = entityDeserializer;

            _serializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.SerializedData.GetConfigKeyName());
        }

        public async Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(
            TEntity specification,
            IQueryParameters queryParameters,
            IDictionary<string, string> additionalParameters,
            CancellationToken cancellationToken)
        {
            var entityFullName = specification.GetApiModelFullName();

            if (!_domainModelProvider.GetDomainModel().EntityByFullName.TryGetValue(entityFullName, out var aggregateRootEntity))
            {
                throw new Exception($"Unable to find API model entity for '{entityFullName}'.");
            }

            using (new SessionScope(SessionFactory))
            {
                // Get the identifiers for a subsequent IN query
                // Do not attempt to combine this into a single ICriteria query, as it will result in a separate query for each row
                // This approach yields all the data in 2 trips to the database (one for the Ids, and a second for all the aggregates)
                var specificationResult = await GetPagedAggregateIdsAsync();

                if (specificationResult.PageItems.Count == 0)
                {
                    return new GetBySpecificationResult<TEntity>
                    {
                        Results = _emptyList,
                        ResultMetadata = new ResultMetadata
                        {
                            TotalCount = specificationResult.TotalCount,
                            NextPageToken = null
                        }
                    };
                }

                bool nhibernateLoadRequired = !_serializationEnabled;

                // First, process results for items that are deserializable
                if (_serializationEnabled)
                {
                    // Try to deserialize all deserializable items
                    foreach (var itemRawData in specificationResult.PageItems)
                    {
                        if (!itemRawData.IsDeserializable)
                        {
                            nhibernateLoadRequired = true;

                            continue;
                        }

                        // Deserialize the entity
                        var deserializedInstance = await _entityDeserializer.DeserializeAsync<TEntity>(itemRawData);

                        if (deserializedInstance != null)
                        {
                            itemRawData.EntityInstance = deserializedInstance;
                        }
                        else
                        {
                            nhibernateLoadRequired = true;
                            itemRawData.AggregateData = null;
                        }
                    }
                }

                if (nhibernateLoadRequired)
                {
                    var aggregateIdsToLoad = specificationResult.PageItems
                        .Where(i => i.EntityInstance == null)
                        .Select(i => i.AggregateId)
                        .ToList();
                    
                    // Load entities using NHibernate
                    var entityResults = await _getEntitiesByAggregateIds.GetByAggregateIdsAsync(
                        aggregateIdsToLoad,
                        cancellationToken);

                    // Results will be ordered by AggregateId
                    int pageItemIndex = 0;
                    int entityResultsIndex = 0;

                    while (pageItemIndex < specificationResult.PageItems.Count && entityResultsIndex < entityResults.Count)
                    {
                        var pageItem = specificationResult.PageItems[pageItemIndex];
                        var entity = entityResults[entityResultsIndex];

                        // If the AggregateIds match, assign the entity to the ItemData object
                        if (pageItem.AggregateId == entity.AggregateId)
                        {
                            pageItem.EntityInstance = entity;

                            pageItemIndex++;
                            entityResultsIndex++;
                        }
                        // If the page item's AggregateId is smaller, move to the next page item
                        else if (pageItem.AggregateId < entity.AggregateId)
                        {
                            pageItemIndex++;
                        }
                        else
                        {
                            // If the EntityResult's AggregateId is smaller, move to the next EntityResult
                            // But this should never happen, so throw an exception
                            throw new InvalidOperationException("Unexpected entity encountered in entity results.");
                        }
                    }
                }

                string nextPageToken = PagingHelpers.GetPageToken(
                    specificationResult.PageItems[^1].AggregateId + 1,
                    queryParameters.MaxAggregateId ?? int.MaxValue);

                return new GetBySpecificationResult<TEntity>
                {
                    Results = specificationResult.PageItems.Select(i => i.EntityInstance).ToList(),
                    ResultMetadata = new ResultMetadata
                    {
                        TotalCount = specificationResult.TotalCount,
                        NextPageToken = nextPageToken
                    },
                };
            }

            async Task<SpecificationResult<TEntity>> GetPagedAggregateIdsAsync()
            {
                // Short circuit any work if no items requested, and no count to perform. 
                if (!ItemsRequested() && !CountRequested())
                {
                    return new SpecificationResult<TEntity>
                    {
                        PageItems = Array.Empty<ItemRawData<TEntity>>()
                    };
                }

                // If any items requested, get the requested page of Ids
                QueryBuilder idsQueryBuilder = null;

                SqlBuilder.Template idsTemplate = null;

                if (ItemsRequested())
                {
                    idsQueryBuilder = GetIdsQueryBuilder();
                    idsTemplate = idsQueryBuilder.BuildTemplate();
                }

                SqlBuilder.Template countTemplate = null;

                // If requested, get a total count of available records
                if (CountRequested())
                {
                    countTemplate = (idsQueryBuilder ?? GetIdsQueryBuilder()).BuildCountTemplate();

                    if (countTemplate.Parameters is DynamicParameters countTemplateParameters)
                    {
                        if (countTemplateParameters.ParameterNames.Contains("MinAggregateId"))
                        {
                            throw new BadRequestParameterException(BadRequestException.DefaultDetail, ["Total count cannot be determined while using cursor paging (when pageToken is specified)."]);
                        }
                    }
                }

                if (idsTemplate != null && countTemplate != null)
                {
                    // Combine the SQL queries
                    var combinedSql = $"{idsTemplate.RawSql}; {countTemplate.RawSql}";

                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(idsTemplate.Parameters);

                    await using var multi = await Session.Connection.QueryMultipleAsync(combinedSql, parameters);

                    var itemDataResults = (await multi.ReadAsync<ItemRawData<TEntity>>()).ToArray();
                    var totalCount = await multi.ReadSingleAsync<int>();

                    return new SpecificationResult<TEntity>
                    {
                        PageItems = itemDataResults, 
                        TotalCount = totalCount
                    };
                }

                if (idsTemplate != null)
                {
                    var itemDataResults =
                        (await Session.Connection.QueryAsync<ItemRawData<TEntity>>(idsTemplate.RawSql, idsTemplate.Parameters)).ToArray();

                    return new SpecificationResult<TEntity>
                    {
                        PageItems = itemDataResults,
                    };
                }

                var countResult = await Session.Connection.QuerySingleAsync<int>(countTemplate.RawSql, countTemplate.Parameters);

                return new SpecificationResult<TEntity>
                {
                    PageItems = Array.Empty<ItemRawData<TEntity>>(),
                    TotalCount = countResult 
                };

                QueryBuilder GetIdsQueryBuilder()
                {
                    var queryBuilder = _pagedAggregateIdsCriteriaProvider.GetQueryBuilder(
                        aggregateRootEntity,
                        specification,
                        queryParameters,
                        additionalParameters);

                    queryBuilder.ApplyChangeVersionCriteria(queryParameters);

                    return queryBuilder;
                }
            }

            bool ItemsRequested() => !(queryParameters.Limit == 0);

            bool CountRequested() => queryParameters.TotalCount;
        }

        private class SpecificationResult<T>
        {
            public IList<ItemRawData<T>> PageItems { get; set; }
            public int TotalCount { get; set; }
        }
    }
}
