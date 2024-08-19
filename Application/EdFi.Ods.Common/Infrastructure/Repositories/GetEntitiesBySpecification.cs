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
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Common.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Multi;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class GetEntitiesBySpecification<TEntity>
        : NHibernateRepositoryOperationBase, IGetEntitiesBySpecification<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity, IMappable
    {
        private const string ChangeVersion = "ChangeVersion";
        public const string _Id = "Id";

        private static readonly IList<ResultItem<TEntity>> _emptyList = new List<ResultItem<TEntity>>();

        private readonly IPagedAggregateIdsCriteriaProvider<TEntity> _pagedAggregateIdsCriteriaProvider;
        private readonly ITotalCountCriteriaProvider<TEntity> _totalCountCriteriaProvider;
        private readonly IGetEntitiesByIds<TEntity> _getEntitiesByIds;

        public GetEntitiesBySpecification(
            ISessionFactory sessionFactory,
            IGetEntitiesByIds<TEntity> getEntitiesByIds,
            IPagedAggregateIdsCriteriaProvider<TEntity> pagedAggregateIdsCriteriaProvider,
            ITotalCountCriteriaProvider<TEntity> totalCountCriteriaProvider)
            : base(sessionFactory)
        {
            _getEntitiesByIds = getEntitiesByIds;
            _pagedAggregateIdsCriteriaProvider = pagedAggregateIdsCriteriaProvider;
            _totalCountCriteriaProvider = totalCountCriteriaProvider;
        }

        public async Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(TEntity specification,
            IQueryParameters queryParameters, CancellationToken cancellationToken)
        {
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
                        ResultMetadata = new ResultMetadata {TotalCount = specificationResult.TotalCount}
                    };
                }

                // Get only the results from the ODS for the items without JSON 
                Guid[] idsToLoad = specificationResult.ItemData
                    .Where(x => x.Json == null || x.LastModifiedDate != GetLastModifiedDate(x.Json))
                    .Select(x => x.Id).ToArray();

                List<ResultItem<TEntity>> resultWithOriginalOrder;

                if (idsToLoad.Length > 0)
                {
                    var entityResults = await _getEntitiesByIds.GetByIdsAsync(
                        idsToLoad,
                        cancellationToken);
                    
                    // Order results using original order (GetByIds sorts by Id)
                    resultWithOriginalOrder = specificationResult.ItemData
                        .GroupJoin(
                            entityResults, 
                            itemData => itemData.Id, 
                            entity => entity.Id, 
                            (itemData, entities) => new ResultItem<TEntity>(entities.SingleOrDefault(), itemData.Json))
                        .ToList();
                }
                else
                {
                    resultWithOriginalOrder = specificationResult.ItemData
                        .Select(i => new ResultItem<TEntity>(null, i.Json))
                        .ToList();
                }

                return new GetBySpecificationResult<TEntity>
                {
                    Results = resultWithOriginalOrder,
                    ResultMetadata = new ResultMetadata {TotalCount = specificationResult.TotalCount}
                };
            }

            DateTime GetLastModifiedDate(byte[] json)
            {
                // Convert the first 8 bytes to a long
                // long binary = BitConverter.ToInt64(json.AsSpan(0, 8)); //, 0);
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
                }

                if (idsTemplate != null && countTemplate != null)
                {
                    // Combine the SQL queries
                    var combinedSql = $"{idsTemplate.RawSql}; {countTemplate.RawSql}";

                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(idsTemplate.Parameters);
                    // parameters.AddDynamicParams(countTemplate.Parameters);

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
                        ItemData = itemDataResults 
                    };
                }

                var countResult = await Session.Connection.QuerySingleAsync<int>(countTemplate.RawSql, countTemplate.Parameters);

                return new SpecificationResult
                {
                    ItemData = Array.Empty<ItemData>(),
                    TotalCount = countResult 
                };
            }

            bool ItemsRequested() => !(queryParameters.Limit == 0);

            bool CountRequested() => queryParameters.TotalCount;

            QueryBuilder GetIdsQueryBuilder()
            {
                var idsQueryBuilder = _pagedAggregateIdsCriteriaProvider.GetQueryBuilder(specification, queryParameters);
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

        private class SpecificationResult
        {
            public IList<ItemData> ItemData { get; set; }
            public int TotalCount { get; set; }
        }

        private class ItemData
        {
            public Guid Id { get; set; }
            public byte[] Json { get; set; }
            public DateTime LastModifiedDate { get; set; }
        }
    }
}
