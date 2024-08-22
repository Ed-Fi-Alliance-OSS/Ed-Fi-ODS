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
        private readonly IGetEntitiesByIds<TEntity> _getEntitiesByIds;

        public GetEntitiesBySpecification(
            ISessionFactory sessionFactory,
            IGetEntitiesByIds<TEntity> getEntitiesByIds,
            IPagedAggregateIdsCriteriaProvider<TEntity> pagedAggregateIdsCriteriaProvider)
            : base(sessionFactory)
        {
            _getEntitiesByIds = getEntitiesByIds;
            _pagedAggregateIdsCriteriaProvider = pagedAggregateIdsCriteriaProvider;
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
                    return new SpecificationResult { Ids = Array.Empty<Guid>() };
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

                    await using var multi = await Session.Connection.QueryMultipleAsync(combinedSql, parameters);

                    var ids = (await multi.ReadAsync<Guid>()).ToList();
                    var totalCount = await multi.ReadSingleAsync<int>();

                    return new SpecificationResult
                    {
                        Ids = ids, 
                        TotalCount = totalCount
                    };
                }

                if (idsTemplate != null)
                {
                    var idsResults = await Session.Connection.QueryAsync<IdOnly>(idsTemplate.RawSql, idsTemplate.Parameters);
                    return new SpecificationResult
                    {
                        Ids = idsResults.Select(d => d.Id).ToArray() 
                    };
                }

                var countResult = await Session.Connection.QuerySingleAsync<int>(countTemplate.RawSql, countTemplate.Parameters);

                return new SpecificationResult
                {
                    Ids = Array.Empty<Guid>(),
                    TotalCount = countResult 
                };
            }

            bool ItemsRequested() => !(queryParameters.Limit == 0);

            bool CountRequested() => queryParameters.TotalCount;

            QueryBuilder GetIdsQueryBuilder()
            {
                var idsQueryBuilder = _pagedAggregateIdsCriteriaProvider.GetQueryBuilder(specification, queryParameters);
                SetChangeQueriesCriteria(idsQueryBuilder);

                return idsQueryBuilder;

                void SetChangeQueriesCriteria(QueryBuilder queryBuilder)
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
            public IList<Guid> Ids { get; set; }
            public int TotalCount { get; set; }
        }

        private class IdOnly
        {
            public Guid Id { get; set; }
        }
    }
}
