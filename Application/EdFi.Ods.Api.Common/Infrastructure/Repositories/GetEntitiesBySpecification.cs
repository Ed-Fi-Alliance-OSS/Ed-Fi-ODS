// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using NHibernate;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Multi;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
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
                var idQueryCriteria = _pagedAggregateIdsCriteriaProvider.GetCriteriaQuery(specification, queryParameters);
                SetChangeQueriesCriteria(idQueryCriteria);

                var queryBatch = Session.CreateQueryBatch()
                    .Add<Guid>(idQueryCriteria);

                // If requested, get a total count of available records
                if (queryParameters.TotalCount)
                {
                    var countQueryCriteria = _totalCountCriteriaProvider.GetCriteriaQuery(specification, queryParameters);
                    SetChangeQueriesCriteria(countQueryCriteria);

                    queryBatch.Add<long>(countQueryCriteria);
                }

                // Get final, paged list of Ids based on order
                var ids = await queryBatch.GetResultAsync<Guid>(0, cancellationToken);

                var totalCount = queryParameters.TotalCount
                    ? (await queryBatch.GetResultAsync<long>(1, cancellationToken)).First()
                    : 0;

                return new SpecificationResult { Ids = ids, TotalCount = totalCount};

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
        }

        private class SpecificationResult
        {
            public IList<Guid> Ids { get; set; }
            public long TotalCount { get; set; }
        }
    }
}
