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
using log4net;
using NHibernate.SqlCommand;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides an abstract implementation for applying authorization filters to <see cref="ICriteria"/> queries on aggregate roots.
    /// </summary>
    /// <typeparam name="TEntity">The type of the aggregate root entity being queried.</typeparam>
    public abstract class AggregateRootCriteriaProviderDecoratorBase<TEntity>
        : IAggregateRootCriteriaProvider<TEntity>
        where TEntity : class
    {
        private readonly IAggregateRootCriteriaProvider<TEntity> _decoratedInstance;
        private readonly IAuthorizationFilterContextProvider _authorizationFilterContextProvider;
        private readonly IFilterCriteriaApplicatorProvider _authorizationCriteriaApplicatorProvider;

        private readonly ILog _logger;

        protected AggregateRootCriteriaProviderDecoratorBase(
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

            var authorizationFilters = _authorizationFilterContextProvider.GetFilterContext();

            // This behavior was introduced to handle support for multiple EdOrg types, but this logic must handle all
            // authorizations performed. Currently, there are no other authorization strategies that use multiple claim types
            // so this is functional today, but would need to be revisited if such an authorization strategy was introduced.
            string[] distinctClaimEndpointNames =
                authorizationFilters
                    .Select(s => s.ClaimEndpointName)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToArray();

            bool hasMultipleClaimEndpoints = distinctClaimEndpointNames.Length > 1;

            var allFiltersGroupedBySubjectName = authorizationFilters.GroupBy(
                x => x.SubjectEndpointName,
                x => x);

            // ICriterions combined using AND
            var conjunction = new Conjunction();

            foreach (var subjectNameGrouping in allFiltersGroupedBySubjectName)
            {
                // ICriterions combined using OR
                var disjunction = new Disjunction();

                var unsupportedAuthorizationFilters = new List<string>();

                bool authorizationFilterApplied = false;
                
                foreach (var filterDetails in subjectNameGrouping)
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
                            {"SourceEducationOrganizationId", filterDetails.ClaimValues},
                            {filterDetails.ClaimEndpointName, filterDetails.ClaimValues},
                        };

                        applicator(criteria, disjunction, parameterValues, hasMultipleClaimEndpoints ? JoinType.LeftOuterJoin : JoinType.InnerJoin);
                        authorizationFilterApplied = true;
                    }
                }

                if (unsupportedAuthorizationFilters.Any() && !authorizationFilterApplied)
                {
                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug($"Unable to authorize access to '{typeof(TEntity).FullName}' because none of the following authorization filters were defined: '{string.Join($"', '", unsupportedAuthorizationFilters)}'.");
                    }

                    throw new EdFiSecurityException(
                        $"Unable to authorize the request because there is no authorization support for associating the "
                        + $"API client's associated claim values (of '{string.Join("', '", distinctClaimEndpointNames)}') with the requested resource ('{typeof(TEntity).Name}').");
                }

                conjunction.Add(disjunction);
            }

            criteria.Add(conjunction);

            return criteria;
        }
    }
}
