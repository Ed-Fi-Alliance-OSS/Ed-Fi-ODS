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

        public GetEntitiesBySpecification(
            ISessionFactory sessionFactory,
            IGetEntitiesByAggregateIds<TEntity> getEntitiesByAggregateIds,
            [FromKeyedServices(PagedAggregateIdsQueryBuilderProvider.RegistrationKey)]
            IAggregateRootQueryBuilderProvider pagedAggregateIdsCriteriaProvider,
            IDomainModelProvider domainModelProvider,
            IEntityDeserializer entityDeserializer)
            : base(sessionFactory)
        {
            _getEntitiesByAggregateIds = getEntitiesByAggregateIds;
            _pagedAggregateIdsCriteriaProvider = pagedAggregateIdsCriteriaProvider;
            _domainModelProvider = domainModelProvider;
            _entityDeserializer = entityDeserializer;
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

                if (specificationResult.RawItems.Count == 0)
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

                // Get only the results from the ODS for the items without serialized aggregate data, or with mismatching LastModifiedDate value 
                var aggregateIdsToLoad = specificationResult.RawItems
                    .Where(x => !x.IsDeserializable())
                    .Select(x => x.AggregateId)
                    .ToList();

                List<TEntity> results = new();

                int nonDeserializableCount = aggregateIdsToLoad.Count;

                if (nonDeserializableCount == 0)
                {
                    // Build result items using exclusively deserialized items
                    foreach (var itemRawData in specificationResult.RawItems)
                    {
                        var deserializedInstance = await _entityDeserializer.DeserializeAsync<TEntity>(itemRawData);

                        if (deserializedInstance != null)
                        {
                            results.Add(deserializedInstance);
                        }
                        else
                        {
                            itemRawData.AggregateData = null;
                            aggregateIdsToLoad.Add(itemRawData.AggregateId);
                        }
                    }
                }

                // Do we have an NHibernate
                if (aggregateIdsToLoad.Count > 0)
                {
                    // If we had deserialization issues, we need ensure the list is sorted in AggregateId order
                    if (nonDeserializableCount != aggregateIdsToLoad.Count)
                    {
                        aggregateIdsToLoad.Sort();
                    }

                    // Load entities using NHibernate
                    var entityResults = await _getEntitiesByAggregateIds.GetByAggregateIdsAsync(
                        aggregateIdsToLoad,
                        cancellationToken);

                    // Results will be ordered by AggregateId
                    int itemDataIndex = 0;
                    int entityResultIndex = 0;

                    while (itemDataIndex < specificationResult.RawItems.Count && entityResultIndex < entityResults.Count)
                    {
                        var itemData = specificationResult.RawItems[itemDataIndex];
                        var entity = entityResults[entityResultIndex];

                        // If the AggregateIds match, assign the entity to the ItemData object
                        if (itemData.AggregateId == entity.AggregateId)
                        {
                            results.Add(entity);

                            itemDataIndex++;
                            entityResultIndex++;
                        }
                        // If the ItemData's AggregateId is smaller, move to the next ItemData
                        else if (itemData.AggregateId < entity.AggregateId)
                        {
                            var deserializedInstance = await _entityDeserializer.DeserializeAsync<TEntity>(itemData);
                            results.Add(deserializedInstance);
                            
                            itemDataIndex++;
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
                    specificationResult.RawItems[^1].AggregateId + 1,
                    queryParameters.MaxAggregateId ?? int.MaxValue);

                return new GetBySpecificationResult<TEntity>
                {
                    Results = results,
                    ResultMetadata = new ResultMetadata
                    {
                        TotalCount = specificationResult.TotalCount,
                        NextPageToken = nextPageToken
                    },
                };
            }

            async Task<SpecificationResult> GetPagedAggregateIdsAsync()
            {
                // Short circuit any work if no items requested, and no count to perform. 
                if (!ItemsRequested() && !CountRequested())
                {
                    return new SpecificationResult
                    {
                        RawItems = Array.Empty<ItemRawData>()
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

                    var itemDataResults = (await multi.ReadAsync<ItemRawData>()).ToArray();
                    var totalCount = await multi.ReadSingleAsync<int>();

                    return new SpecificationResult
                    {
                        RawItems = itemDataResults, 
                        TotalCount = totalCount
                    };
                }

                if (idsTemplate != null)
                {
                    var itemDataResults =
                        (await Session.Connection.QueryAsync<ItemRawData>(idsTemplate.RawSql, idsTemplate.Parameters)).ToArray();

                    return new SpecificationResult
                    {
                        RawItems = itemDataResults,
                    };
                }

                var countResult = await Session.Connection.QuerySingleAsync<int>(countTemplate.RawSql, countTemplate.Parameters);

                return new SpecificationResult
                {
                    RawItems = Array.Empty<ItemRawData>(),
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

        private class SpecificationResult
        {
            public IList<ItemRawData> RawItems { get; set; }
            public int TotalCount { get; set; }
        }
    }
}
