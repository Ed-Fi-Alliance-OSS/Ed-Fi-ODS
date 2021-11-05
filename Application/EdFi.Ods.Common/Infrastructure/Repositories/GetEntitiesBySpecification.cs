// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private const string ChangeVersion = "ChangeVersion";
        public const string _Id = "Id";
        protected static IList<TEntity> EmptyList = new List<TEntity>();

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

                if (specificationResult.Ids.Count == 0)
                {
                    return new GetBySpecificationResult<TEntity>
                    {
                        Results = EmptyList,
                        ResultMetadata = new ResultMetadata {TotalCount = specificationResult.TotalCount}
                    };
                }

                // Get the full results
                var result = await _getEntitiesByIds.GetByIdsAsync(specificationResult.Ids, cancellationToken);

                // Restore original order of the result rows (GetByIds sorts by Id)
                var resultWithOriginalOrder = specificationResult.Ids
                    .Join(result, id => id, r => r.Id, (id, r) => r)
                    .ToList();

                return new GetBySpecificationResult<TEntity>
                {
                    Results = resultWithOriginalOrder,
                    ResultMetadata = new ResultMetadata {TotalCount = specificationResult.TotalCount}
                };
            }

            async Task<SpecificationResult> GetPagedAggregateIdsAsync()
            {
                // Short circuit any work if no items requested, and no count to perform. 
                if (!ItemsRequested() && !CountRequested())
                {
                    return new SpecificationResult { Ids = new Guid[0] };
                }

                var queryBatch = Session.CreateQueryBatch();

                // If any items requested, get the requested page of Ids
                if (ItemsRequested())
                {
                    var idQueryCriteria = _pagedAggregateIdsCriteriaProvider.GetCriteriaQuery(specification, queryParameters);
                    SetChangeQueriesCriteria(idQueryCriteria);

                    queryBatch.Add<object[]>(idQueryCriteria);
                }

                // If requested, get a total count of available records
                if (CountRequested())
                {
                    var countQueryCriteria = _totalCountCriteriaProvider.GetCriteriaQuery(specification, queryParameters);
                    SetChangeQueriesCriteria(countQueryCriteria);

                    queryBatch.Add<object>(countQueryCriteria);
                }

                int resultIndex = 0;
                
                var ids = ItemsRequested()
                    ? (await queryBatch.GetResultAsync<object[]>(resultIndex++, cancellationToken))
                        .Select(r => (Guid) r[0])
                        .ToArray()
                    : Array.Empty<Guid>();
                
                var totalCount = CountRequested()
                    ? ((await queryBatch.GetResultAsync<object>(resultIndex, cancellationToken)))
                        .Select(Convert.ToInt64)
                        .First()
                    : 0;

                return new SpecificationResult
                {
                    Ids = ids, 
                    TotalCount = totalCount
                };

                void SetChangeQueriesCriteria(ICriteria criteria)
                {
                    if (queryParameters.MinChangeVersion.HasValue)
                    {
                        criteria.Add(Restrictions.Ge(ChangeVersion, queryParameters.MinChangeVersion.Value));
                    }

                    if (queryParameters.MaxChangeVersion.HasValue)
                    {
                        criteria.Add(Restrictions.Le(ChangeVersion, queryParameters.MaxChangeVersion.Value));
                    }
                }
            }

            bool ItemsRequested() => !(queryParameters.Limit == 0);

            bool CountRequested() => queryParameters.TotalCount;
        }

        private class SpecificationResult
        {
            public IList<Guid> Ids { get; set; }
            public long TotalCount { get; set; }
        }
    }
}
