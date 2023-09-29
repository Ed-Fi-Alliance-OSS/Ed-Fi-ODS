// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Providers.Criteria;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides an abstract implementation for applying authorization filters to <see cref="ICriteria"/> queries on aggregate roots.
    /// </summary>
    /// <typeparam name="TEntity">The type of the aggregate root entity being queried.</typeparam>
    public abstract class AggregateRootCriteriaProviderAuthorizationDecoratorBase<TEntity>
        : IAggregateRootCriteriaProvider<TEntity>
        where TEntity : class
    {
        private readonly IAggregateRootCriteriaProvider<TEntity> _decoratedInstance;
        private readonly IAuthorizationFilterContextProvider _authorizationFilterContextProvider;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;

        protected AggregateRootCriteriaProviderAuthorizationDecoratorBase(
            IAggregateRootCriteriaProvider<TEntity> decoratedInstance,
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
        public ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters)
        {
            var criteria = _decoratedInstance.GetCriteriaQuery(specification, queryParameters);

            var authorizationFiltering = _authorizationFilterContextProvider.GetFilterContext();

            var unsupportedAuthorizationFilters = new HashSet<string>();

            // Create the "AND" junction
            var mainConjunction = new Conjunction();
            
            // Create the "OR" junction
            var mainDisjunction = new Disjunction();

            // If there are multiple authorization strategies with views, we must use left outer joins and null/not null checks
            var joinType = DetermineJoinType();

            bool conjunctionFiltersWereApplied = ApplyAuthorizationStrategiesCombinedWithAndLogic();
            bool disjunctionFiltersWereApplied = ApplyAuthorizationStrategiesCombinedWithOrLogic();

            ApplyJunctionsToCriteriaQuery();

            return criteria;

            JoinType DetermineJoinType()
            {
                var countOfAuthorizationFiltersWithViewBasedFilters = authorizationFiltering.Count(
                    af => af.Filters.Select(afd =>
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

                return countOfAuthorizationFiltersWithViewBasedFilters > 1
                    ? JoinType.LeftOuterJoin
                    : JoinType.InnerJoin;
            }

            bool ApplyAuthorizationStrategiesCombinedWithAndLogic()
            {
                var andStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.And).ToArray();

                // Combine 'AND' strategies
                bool conjunctionFiltersApplied = false;

                foreach (var andStrategy in andStrategies)
                {
                    if (!TryApplyFilters(mainConjunction, andStrategy.Filters))
                    {
                        // All filters for AND strategies must be applied, and if not, this is an error condition
                        throw new Exception($"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                    }

                    conjunctionFiltersApplied = true;
                }

                return conjunctionFiltersApplied;
            }

            bool ApplyAuthorizationStrategiesCombinedWithOrLogic()
            {
                var orStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.Or).ToArray();

                // Combine 'OR' strategies
                bool disjunctionFiltersApplied = false;

                foreach (var orStrategy in orStrategies)
                {
                    var filtersConjunction = new Conjunction(); // Combine filters with 'AND'

                    if (TryApplyFilters(filtersConjunction, orStrategy.Filters))
                    {
                        mainDisjunction.Add(filtersConjunction);

                        disjunctionFiltersApplied = true;
                    }
                }

                // If we have some OR strategies with filters defined, but no filters were applied, this is an error condition
                if (orStrategies.SelectMany(s => s.Filters).Any() && !disjunctionFiltersApplied)
                {
                    throw new Exception($"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                }
                
                return disjunctionFiltersApplied;
            }

            bool TryApplyFilters(Conjunction conjunction, IReadOnlyList<AuthorizationFilterContext> filters)
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
                        out var filterApplicationDetails);

                    var applicator = filterApplicationDetails.CriteriaApplicator;
                    
                    var parameterValues = new Dictionary<string, object>
                    {
                        { filterContext.ClaimParameterName, filterContext.ClaimParameterValues }
                    };

                    // Apply the authorization strategy filter
                    applicator(criteria, conjunction, filterContext.SubjectEndpointName, parameterValues, joinType);

                    filtersApplied = true;
                }
                
                return filtersApplied;
            }

            void ApplyJunctionsToCriteriaQuery()
            {
                if (disjunctionFiltersWereApplied)
                {
                    if (conjunctionFiltersWereApplied)
                    {
                        mainConjunction.Add(mainDisjunction);
                    }
                    else
                    {
                        criteria.Add(mainDisjunction);
                    }
                }

                if (conjunctionFiltersWereApplied)
                {
                    criteria.Add(mainConjunction);
                }
            }
        }
    }
}
