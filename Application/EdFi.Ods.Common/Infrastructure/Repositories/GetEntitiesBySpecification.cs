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
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class GetEntitiesBySpecification<TEntity>
        : NHibernateRepositoryOperationBase, IGetEntitiesBySpecification<TEntity>
        where TEntity : AggregateRootWithCompositeKey, IMappable
    {
        private const string ChangeVersion = "ChangeVersion";
        private static readonly IList<ResultItem<TEntity>> _emptyList = Array.Empty<ResultItem<TEntity>>();

        private readonly IAggregateRootQueryBuilderProvider _pagedAggregateIdsCriteriaProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IGetEntitiesByAggregateIds<TEntity> _getEntitiesByAggregateIds;

        public GetEntitiesBySpecification(
            ISessionFactory sessionFactory,
            IGetEntitiesByAggregateIds<TEntity> getEntitiesByAggregateIds,
            [FromKeyedServices(PagedAggregateIdsQueryBuilderProvider.RegistrationKey)]
            IAggregateRootQueryBuilderProvider pagedAggregateIdsCriteriaProvider,
            IDomainModelProvider domainModelProvider)
            : base(sessionFactory)
        {
            _getEntitiesByAggregateIds = getEntitiesByAggregateIds;
            _pagedAggregateIdsCriteriaProvider = pagedAggregateIdsCriteriaProvider;
            _domainModelProvider = domainModelProvider;
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

                if (specificationResult.ItemData.Count == 0)
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

                // Get only the results from the ODS for the items without JSON, or with mismatching LastModifiedDate value 
                int[] aggregateIdsToLoad = specificationResult.ItemData
                    .Where(x => x.Json == null || x.LastModifiedDate != GetLastModifiedDate(x.Json))
                    .Select(x => x.AggregateId)
                    .ToArray();

                List<ResultItem<TEntity>> results;

                if (aggregateIdsToLoad.Length == 0)
                {
                    results = specificationResult.ItemData
                        .Select(i => new ResultItem<TEntity>(null, i.Json))
                        .ToList();
                }
                else
                {
                    var entityResults = await _getEntitiesByAggregateIds.GetByAggregateIdsAsync(
                        aggregateIdsToLoad,
                        cancellationToken);

                    results = new();

                    // Results will be ordered by AggregateId
                    int itemDataIndex = 0;
                    int entityResultIndex = 0;

                    while (itemDataIndex < specificationResult.ItemData.Count && entityResultIndex < entityResults.Count)
                    {
                        var itemData = specificationResult.ItemData[itemDataIndex];
                        var entity = entityResults[entityResultIndex];

                        // If the AggregateIds match, assign the entity to the ItemData object
                        if (itemData.AggregateId == entity.AggregateId)
                        {
                            results.Add(new ResultItem<TEntity>(entity));

                            // itemData.Entity = entity;
                            itemDataIndex++;
                            entityResultIndex++;
                        }
                        // If the ItemData's AggregateId is smaller, move to the next ItemData
                        else if (itemData.AggregateId < entity.AggregateId)
                        {
                            results.Add(new ResultItem<TEntity>(null, itemData.Json));
                            itemDataIndex++;
                        }
                        // If the EntityResult's AggregateId is smaller, move to the next EntityResult
                        else
                        {
                            throw new InvalidOperationException("Unexpected entity encountered in entity results.");
                            // entityResultIndex++;
                        }
                    }
                }

                string nextPageToken = null;

                if (queryParameters.MinAggregateId != null)
                {
                    nextPageToken = PagingHelpers.GetPageToken(
                        specificationResult.ItemData[^1].AggregateId + 1,
                        queryParameters.MaxAggregateId!.Value);
                }

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

            DateTime GetLastModifiedDate(byte[] json)
            {
                // Convert the first 8 bytes to a long
                long binary = BitConverter.ToInt64(json, 0);

                // Deserialize the DateTime
                return DateTime.FromBinary(binary);
            }

            async Task<SpecificationResult> GetPagedAggregateIdsAsync()
            {
                // Short circuit any work if no items requested, and no count to perform. 
                if (!ItemsRequested() && !CountRequested())
                {
                    return new SpecificationResult
                    {
                        ItemData = Array.Empty<ItemData>()
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
                            throw new BadRequestParameterException(BadRequestException.DefaultDetail, ["Total count cannot be determined while using key set paging."]);
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
                    
                    var itemDataResults = (await multi.ReadAsync<ItemData>()).ToArray();
                    var totalCount = await multi.ReadSingleAsync<int>();

                    return new SpecificationResult
                    {
                        ItemData = itemDataResults, 
                        TotalCount = totalCount
                    };
                }

                if (idsTemplate != null)
                {
                    var itemDataResults =
                        (await Session.Connection.QueryAsync<ItemData>(idsTemplate.RawSql, idsTemplate.Parameters)).ToArray();

                    return new SpecificationResult
                    {
                        ItemData = itemDataResults,
                    };
                }

                var countResult = await Session.Connection.QuerySingleAsync<int>(countTemplate.RawSql, countTemplate.Parameters);

                return new SpecificationResult
                {
                    ItemData = Array.Empty<ItemData>(),
                    TotalCount = countResult 
                };
                
                QueryBuilder GetIdsQueryBuilder()
                {
                    var idsQueryBuilder = _pagedAggregateIdsCriteriaProvider.GetQueryBuilder(
                        aggregateRootEntity,
                        specification,
                        queryParameters,
                        additionalParameters);

                    ApplyChangeQueriesCriteria(idsQueryBuilder);

                    return idsQueryBuilder;

                    void ApplyChangeQueriesCriteria(QueryBuilder queryBuilder)
                    {
                        if (queryParameters.MinChangeVersion.HasValue)
                        {
                            queryBuilder.Where(ChangeVersion, ">=", queryParameters.MinChangeVersion.Value);
                        }

                        if (queryParameters.MaxChangeVersion.HasValue)
                        {
                            queryBuilder.Where(ChangeVersion, "<=", queryParameters.MaxChangeVersion.Value);
                        }
                    }
                }
            }

            bool ItemsRequested() => !(queryParameters.Limit == 0);

            bool CountRequested() => queryParameters.TotalCount;
        }

        private class SpecificationResult
        {
            public IList<ItemData> ItemData { get; set; }
            public int TotalCount { get; set; }
        }
        
        private class ItemData
        {
            public int AggregateId { get; set; }

            public byte[] Json { get; set; }
            public DateTime LastModifiedDate { get; set; }

            public TEntity Entity { get; set; }
        }
    }
}
