// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides an abstract implementation for applying authorization filters to queries on aggregate roots built using the <see cref="QueryBuilder"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the aggregate root entity being queried.</typeparam>
    public class PagedAggregateIdsCriteriaProviderAuthorizationDecorator<TEntity>
        : IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        private readonly IPagedAggregateIdsCriteriaProvider<TEntity> _decoratedInstance;
        private readonly IAuthorizationFilterContextProvider _authorizationFilterContextProvider;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;

        protected PagedAggregateIdsCriteriaProviderAuthorizationDecorator(
            IPagedAggregateIdsCriteriaProvider<TEntity> decoratedInstance,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider)
        {
            _decoratedInstance = decoratedInstance;
            _authorizationFilterContextProvider = authorizationFilterContextProvider;
            _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
        }

        /// <summary>
        /// Applies the authorization filtering criteria to the query created by the decorated instance.
        /// </summary>
        /// <param name="specification">An instance of the entity representing the parameters to the query.</param>
        /// <param name="queryParameters">The parameter values to apply to the query.</param>
        /// <returns>The criteria created by the decorated instance.</returns>
        public QueryBuilder GetQueryBuilder(TEntity specification, IQueryParameters queryParameters)
        {
            var queryBuilder = _decoratedInstance.GetQueryBuilder(specification, queryParameters);

            var authorizationFiltering = _authorizationFilterContextProvider.GetFilterContext();

            var unsupportedAuthorizationFilters = new HashSet<string>();

            // If there are multiple relationship-based authorization strategies with views (that are combined with OR), we must use left outer joins and null/not null checks
            var relationshipBasedAuthViewJoinType = DetermineRelationshipBasedAuthViewJoinType();

            ApplyAuthorizationStrategiesCombinedWithAndLogic();
            ApplyAuthorizationStrategiesCombinedWithOrLogic();

            return queryBuilder;

            JoinType DetermineRelationshipBasedAuthViewJoinType()
            {
                // Relationship-based authorization filters are combined using OR, Custom auth-view filters are combined using AND
                var countOfRelationshipBasedAuthorizationFilters = authorizationFiltering.Count(
                    af => af.Operator == FilterOperator.Or && af.Filters.Select(afd =>
                        {
                            if (_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(afd.FilterName, out var filterDetails))
                            {
                                return filterDetails;
                            };

                            unsupportedAuthorizationFilters.Add(afd.FilterName);

                            return null;
                        })
                        .Where(x => x != null)
                        .OfType<ViewBasedAuthorizationFilterDefinition>()
                        .Any());

                return countOfRelationshipBasedAuthorizationFilters > 1
                    ? JoinType.LeftOuterJoin
                    : JoinType.InnerJoin;
            }

            void ApplyAuthorizationStrategiesCombinedWithAndLogic()
            {
                var andStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.And).ToArray();

                // Combine 'AND' strategies
                foreach (var andStrategy in andStrategies)
                {
                    if (!TryApplyFilters(queryBuilder, andStrategy.Filters, andStrategy.AuthorizationStrategy, JoinType.InnerJoin))
                    {
                        // All filters for AND strategies must be applied, and if not, this is an error condition
                        throw new Exception($"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                    }
                }
            }

            void ApplyAuthorizationStrategiesCombinedWithOrLogic()
            {
                var orStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.Or).ToArray();

                bool disjunctionFiltersApplied = false;

                // Combine 'OR' strategies
                queryBuilder.Where(
                    disjunctionBuilder =>
                    {
                        foreach (var orStrategy in orStrategies)
                        {
                            disjunctionBuilder.OrWhere(
                                filtersConjunctionBuilder =>
                                {
                                    // Combine filters with 'AND'
                                    if (TryApplyFilters(
                                            filtersConjunctionBuilder,
                                            orStrategy.Filters,
                                            orStrategy.AuthorizationStrategy,
                                            relationshipBasedAuthViewJoinType))
                                    {
                                        disjunctionFiltersApplied = true;
                                    }

                                    return filtersConjunctionBuilder;
                                });
                        }

                        return disjunctionBuilder;
                    });

                // If we have some OR strategies with filters defined, but no filters were applied, this is an error condition
                if (orStrategies.SelectMany(s => s.Filters).Any() && !disjunctionFiltersApplied)
                {
                    throw new Exception($"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                }
            }

            bool TryApplyFilters(
                QueryBuilder conjunctionQueryBuilder,
                IReadOnlyList<AuthorizationFilterContext> filters,
                IAuthorizationStrategy authorizationStrategy,
                JoinType joinType)
            {
                bool allFiltersCanBeApplied = true;
                
                foreach (var filterDetails in filters)
                {
                    if (!_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                            filterDetails.FilterName,
                            out var ignored))
                    {
                        unsupportedAuthorizationFilters.Add(filterDetails.FilterName);

                        allFiltersCanBeApplied = false;
                    }
                }

                if (!allFiltersCanBeApplied)
                {
                    return false;
                }

                bool filtersApplied = false;
                
                foreach (var filterContext in filters)
                {
                    _authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                        filterContext.FilterName,
                        out var filterDefinition);

                    var parameterValues = filterContext.ClaimParameterName == null
                        ? new Dictionary<string, object>()
                        : new Dictionary<string, object>
                            {
                                { filterContext.ClaimParameterName, filterContext.ClaimParameterValues }
                            };

                    // Apply the authorization strategy filter
                    filterDefinition.CriteriaApplicator(
                        queryBuilder,
                        conjunctionQueryBuilder,
                        filterContext.SubjectEndpointNames,
                        parameterValues,
                        joinType,
                        authorizationStrategy);

                    filtersApplied = true;
                }
                
                return filtersApplied;
            }
        }
    }
}
