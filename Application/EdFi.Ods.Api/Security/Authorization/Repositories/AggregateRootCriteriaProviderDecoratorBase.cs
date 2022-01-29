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

        private readonly ILog _logger;

        protected AggregateRootCriteriaProviderAuthorizationDecoratorBase(
            IAggregateRootCriteriaProvider<TEntity> decoratedInstance,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IFilterCriteriaApplicatorProvider authorizationCriteriaApplicatorProvider)
        {
            _decoratedInstance = decoratedInstance;
            _authorizationFilterContextProvider = authorizationFilterContextProvider;
            _authorizationCriteriaApplicatorProvider = authorizationCriteriaApplicatorProvider;

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

            var unsupportedAuthorizationFilters = new List<string>();

            var andStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.And).ToArray();
            
            // Combine 'AND' strategies
            var rootConjunction = new Conjunction();
            bool conjunctionFiltersApplied = false;

            foreach (var andStrategy in andStrategies)
            {
                // var strategyConjunction = new Conjunction();
                
                conjunctionFiltersApplied |= TryApplyAndFilters(rootConjunction, andStrategy.Filters);
                conjunctionFiltersApplied |= TryApplyOrFilters(rootConjunction, andStrategy.Filters);
            }

            var orStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.Or).ToArray();
            
            // Combine 'OR' strategies
            var rootDisjunction = new Disjunction();
            bool disjunctionFiltersApplied = false;

            foreach (var orStrategy in orStrategies)
            {
                var strategyConjunction = new Conjunction(); // Combine with 'AND'
                
                disjunctionFiltersApplied |= TryApplyAndFilters(strategyConjunction, orStrategy.Filters);
                disjunctionFiltersApplied |= TryApplyOrFilters(strategyConjunction, orStrategy.Filters);

                rootDisjunction.Add(strategyConjunction);
            }

            if (disjunctionFiltersApplied)
            {
                if (conjunctionFiltersApplied)
                {
                    rootConjunction.Add(rootDisjunction);
                }
                else
                {
                    criteria.Add(rootDisjunction);
                }
            }
            
            if (conjunctionFiltersApplied)
            {
                criteria.Add(rootConjunction);
            }
            
            EnsureRequestAuthorized();

            return criteria;

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
                        var parameterValues = new Dictionary<string, object>
                        {
                            // TODO: Consider renaming all parameters to "ClaimValue" rather than the divergence that is now present, requiring both to be added to ensure correct parameter assignment.
                            // For Example: {"ClaimValue", filterDetails.ClaimValues}, in lieu of the next 2 lines. Will required additional changes to the filter definitions.
                            {"SourceEducationOrganizationId", filterDetails.ClaimValues},
                            {filterDetails.ClaimEndpointName, filterDetails.ClaimValues},
                        };

                        // Original logic --> applicator(criteria, conjunction, parameterValues, JoinType.InnerJoin);
                        
                        // Multiple auth strategy logic
                        applicator(criteria, conjunction, parameterValues, JoinType.LeftOuterJoin);
                        
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
                        var parameterValues = new Dictionary<string, object>
                        {
                            // TODO: Consider renaming all parameters to "ClaimValue" rather than the divergence that is now present, requiring both to be added to ensure correct parameter assignment.
                            // For Example: {"ClaimValue", filterDetails.ClaimValues}, in lieu of the next 2 lines. Will required additional changes to the filter definitions.
                            { "SourceEducationOrganizationId", filterDetails.ClaimValues },
                            { filterDetails.ClaimEndpointName, filterDetails.ClaimValues },
                        };

                        applicator( criteria, disjunction, parameterValues, JoinType.LeftOuterJoin);
                            // orFilters.Length > 1
                            //     ? JoinType.LeftOuterJoin
                            //     : JoinType.InnerJoin);

                        filterApplied = true;
                    }
                }

                if (filterApplied)
                {
                    conjunction.Add(disjunction);
                }

                return filterApplied;
            }

            void EnsureRequestAuthorized()
            {
                if (unsupportedAuthorizationFilters.Any() && !conjunctionFiltersApplied && !disjunctionFiltersApplied)
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
