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
using EdFi.Ods.Common.Security;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using log4net;
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
        private readonly IFilterCriteriaApplicatorProvider _authorizationCriteriaApplicatorProvider;
        private readonly IFilterApplicationDetailsProvider _filterApplicationDetailsProvider;

        private readonly ILog _logger;

        protected AggregateRootCriteriaProviderAuthorizationDecoratorBase(
            IAggregateRootCriteriaProvider<TEntity> decoratedInstance,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IFilterCriteriaApplicatorProvider authorizationCriteriaApplicatorProvider,
            IFilterApplicationDetailsProvider filterApplicationDetailsProvider)
        {
            _decoratedInstance = decoratedInstance;
            _authorizationFilterContextProvider = authorizationFilterContextProvider;
            _authorizationCriteriaApplicatorProvider = authorizationCriteriaApplicatorProvider;
            _filterApplicationDetailsProvider = filterApplicationDetailsProvider;

            // Log entries for the concrete type
            _logger = LogManager.GetLogger(GetType());
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

            EnsureRequestAuthorized();

            return criteria;

            JoinType DetermineJoinType()
            {
                var countOfAuthorizationFiltersWithViewBasedFilters = authorizationFiltering.Count(
                    af => af.Filters.Select(afd =>
                        {
                            if (_filterApplicationDetailsProvider.TryGetFilterApplicationDetails(afd.FilterName, out var filterDetails))
                            {
                                return filterDetails;
                            };

                            unsupportedAuthorizationFilters.Add(afd.FilterName);

                            return null;
                        })
                        .Where(x => x != null)
                        .OfType<ViewFilterApplicationDetails>()
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
                    conjunctionFiltersApplied |= TryApplyAndFilters(mainConjunction, andStrategy.Filters);
                    conjunctionFiltersApplied |= TryApplyOrFilters(mainConjunction, andStrategy.Filters);
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
                    var strategyConjunction = new Conjunction(); // Combine with 'AND'

                    disjunctionFiltersApplied |= TryApplyAndFilters(strategyConjunction, orStrategy.Filters);
                    disjunctionFiltersApplied |= TryApplyOrFilters(strategyConjunction, orStrategy.Filters);

                    mainDisjunction.Add(strategyConjunction);
                }

                return disjunctionFiltersApplied;
            }

            bool TryApplyAndFilters(Conjunction conjunction, IReadOnlyList<AuthorizationFilterDetails> filters)
            {
                bool filterApplied = false;
                
                var andFilters = filters.Where(x => x.Operator == FilterOperator.And);

                foreach (var filterDetails in andFilters)
                {
                    if (!_authorizationCriteriaApplicatorProvider.TryGetCriteriaApplicator(
                            filterDetails.FilterName,
                            typeof(TEntity),
                            out IReadOnlyList<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>> applicators))
                    {
                        unsupportedAuthorizationFilters.Add(filterDetails.FilterName);

                        continue;
                    }
                
                    // Invoke the filter applicators against the current query
                    foreach (var applicator in applicators)
                    {
                        // Make claim values available under various names used by different contexts (NOTE: long term goal would be to eliminate this variation) 
                        var parameterValues = new Dictionary<string, object>
                        {
                            {RelationshipAuthorizationConventions.ClaimsParameterName, filterDetails.ClaimValues},
                        };

                        // Apply the authorization strategy filter
                        applicator(criteria, conjunction, parameterValues, joinType);
                        
                        filterApplied = true;
                    }
                }

                return filterApplied;
            }

            bool TryApplyOrFilters(Conjunction conjunction, IReadOnlyList<AuthorizationFilterDetails> filters)
            {
                bool filterApplied = false;
                
                // Combine these filters with OR
                var disjunction = new Disjunction();

                var orFilters = filters.Where(x => x.Operator == FilterOperator.Or).ToArray();
            
                foreach (var filterDetails in orFilters)
                {
                    if (!_authorizationCriteriaApplicatorProvider.TryGetCriteriaApplicator(
                            filterDetails.FilterName,
                            typeof(TEntity),
                            out IReadOnlyList<Action<ICriteria, Junction, IDictionary<string, object>, JoinType>> applicators))
                    {
                        unsupportedAuthorizationFilters.Add(filterDetails.FilterName);

                        continue;
                    }

                    // Invoke the filter applicators against the current query
                    foreach (var applicator in applicators)
                    {
                        // Make claim values available under various names used by different contexts (NOTE: long term goal would be to eliminate this variation) 
                        var parameterValues = new Dictionary<string, object>
                        {
                            { "SourceEducationOrganizationId", filterDetails.ClaimValues },
                            { filterDetails.ClaimEndpointName, filterDetails.ClaimValues },
                        };

                        // Apply the authorization strategy filter
                        applicator( criteria, disjunction, parameterValues, joinType);

                        filterApplied = true;
                    }
                }

                if (filterApplied)
                {
                    conjunction.Add(disjunction);
                }

                return filterApplied;
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

            void EnsureRequestAuthorized()
            {
                if (unsupportedAuthorizationFilters.Any() && !conjunctionFiltersWereApplied && !disjunctionFiltersWereApplied)
                {
                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug(
                            $"Unable to authorize access to '{typeof(TEntity).FullName}' because none of the following authorization filters were defined: '{string.Join($"', '", unsupportedAuthorizationFilters)}'.");
                    }

                    string[] distinctClaimEndpointNames = authorizationFiltering
                        .SelectMany(s => s.Filters.Select(f => f.ClaimEndpointName))
                        .Distinct()
                        .OrderBy(x => x)
                        .ToArray();

                    // TODO: Multiple authorization strategy support -- is there a better way to message the error (which used to combine claim endpoints from a single auth strategy)?
                    throw new EdFiSecurityException(
                        $"Unable to authorize the request because there is no authorization support for associating the "
                        + $"API client's associated claim values (of '{string.Join("', '", distinctClaimEndpointNames)}') with the requested resource ('{typeof(TEntity).Name}').");
                }
            }
        }
    }
}
