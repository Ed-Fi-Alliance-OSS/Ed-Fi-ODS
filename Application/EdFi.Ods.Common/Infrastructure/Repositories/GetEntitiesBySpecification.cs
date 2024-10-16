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
        public const string _Id = "Id";
        private static IList<TEntity> EmptyList = new List<TEntity>();

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

                if (specificationResult.Ids.Count == 0)
                {
                    return new GetBySpecificationResult<TEntity>
                    {
                        Results = EmptyList,
                        ResultMetadata = new ResultMetadata
                        {
                            TotalCount = specificationResult.TotalCount,
                            NextPageToken = null
                        }
                    };
                }

                // Get the full results
                var aggregateIds = specificationResult.Ids.Select(x => x.AggregateId).ToList();

                var result = await _getEntitiesByAggregateIds.GetByAggregateIdsAsync(aggregateIds, cancellationToken);

                string nextPageToken = null;

                if (queryParameters.MinAggregateId != null)
                {
                    nextPageToken = PagingHelpers.GetPageToken(
                        specificationResult.Ids[^1].AggregateId + 1,
                        queryParameters.MaxAggregateId!.Value);
                }

                return new GetBySpecificationResult<TEntity>
                {
                    Results = result,
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
                    return new SpecificationResult { Ids = Array.Empty<PageIds>() };
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

                    var ids = (await multi.ReadAsync<PageIds>()).ToList();
                    var totalCount = await multi.ReadSingleAsync<int>();

                    return new SpecificationResult
                    {
                        Ids = ids, 
                        TotalCount = totalCount
                    };
                }

                if (idsTemplate != null)
                {
                    var idsResults = await Session.Connection.QueryAsync<PageIds>(idsTemplate.RawSql, idsTemplate.Parameters);
                    
                    return new SpecificationResult
                    {
                        Ids = idsResults.ToArray() 
                    };
                }

                var countResult = await Session.Connection.QuerySingleAsync<int>(countTemplate.RawSql, countTemplate.Parameters);

                return new SpecificationResult
                {
                    Ids = Array.Empty<PageIds>(),
                    TotalCount = countResult 
                };
                
                QueryBuilder GetIdsQueryBuilder()
                {
                    var idsQueryBuilder = _pagedAggregateIdsCriteriaProvider.GetQueryBuilder(
                        aggregateRootEntity,
                        specification,
                        queryParameters,
                        additionalParameters);

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

            bool ItemsRequested() => !(queryParameters.Limit == 0);

            bool CountRequested() => queryParameters.TotalCount;
        }

        private class PageIds
        {
            public Guid Id { get; set; }
            public int AggregateId { get; set; }
        }

        private class SpecificationResult
        {
            public IList<PageIds> Ids { get; set; }
            public int TotalCount { get; set; }
        }
    }
}
