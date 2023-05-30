// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public class TrackedChangesQueryFactoryAuthorizationDecoratorBase
    {
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;

        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IAuthorizationFilterDefinitionProvider _authorizationFilterDefinitionProvider;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;

        protected TrackedChangesQueryFactoryAuthorizationDecoratorBase(
            IAuthorizationContextProvider authorizationContextProvider,
            IApiClientContextProvider apiClientContextProvider,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _apiClientContextProvider = apiClientContextProvider;
            _authorizationFilteringProvider = authorizationFilteringProvider;
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
            _authorizationFilterDefinitionProvider = authorizationFilterDefinitionProvider;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;

            domainModelEnhancer.Enhance(domainModelProvider.GetDomainModel());
        }

        protected void ApplyAuthorizationFilters(Resource resource, QueryBuilder queryBuilder)
        {
            Type entityType = ((dynamic)resource.Entity).NHibernateEntityType;

            if (entityType == null)
            {
                throw new SecurityException(
                    $"Unable to perform authorization because entity type for '{resource.Entity.FullName}' could not be identified.");
            }

            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();

            var apiClientContext = _apiClientContextProvider.GetApiClientContext();

            string[] resourceClaimUris = _authorizationContextProvider.GetResourceUris();
            string requestActionUri = _authorizationContextProvider.GetAction();

            var authorizationContext = new EdFiAuthorizationContext(
                apiClientContext,
                _dataManagementResourceContextProvider.Get().Resource,
                resourceClaimUris,
                requestActionUri,
                entityType);

            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                apiClientContext.ClaimSetName,
                resourceClaimUris,
                requestActionUri);

            var authorizationFiltering =
                _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);

            var unsupportedAuthorizationFilters = new HashSet<string>();

            // If there are multiple authorization strategies with views, we must use left outer joins and null/not null checks
            var joinType = DetermineJoinType();

            var filterIndex = 0;

            ApplyAuthorizationStrategiesCombinedWithAndLogic();
            ApplyAuthorizationStrategiesCombinedWithOrLogic();

            return;

            JoinType DetermineJoinType()
            {
                var countOfAuthorizationFiltersWithViewBasedFilters = authorizationFiltering.Count(
                    af => af.Filters.Select(
                            afd =>
                            {
                                if (_authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                                        afd.FilterName,
                                        out var filterDetails))
                                {
                                    return filterDetails;
                                }

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

            void ApplyAuthorizationStrategiesCombinedWithAndLogic()
            {
                var andStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.And).ToArray();

                // Combine 'AND' strategies
                if (andStrategies.Any())
                {
                    queryBuilder.Where(
                        nestedAndQueryBuilder =>
                        {
                            foreach (var andStrategy in andStrategies)
                            {
                                if (!TryApplyFilters(nestedAndQueryBuilder, andStrategy.Filters))
                                {
                                    // All filters for AND strategies must be applied, and if not, this is an error condition
                                    throw new Exception(
                                        $"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                                }
                            }

                            return nestedAndQueryBuilder;
                        });
                }
            }

            void ApplyAuthorizationStrategiesCombinedWithOrLogic()
            {
                var orStrategies = authorizationFiltering.Where(x => x.Operator == FilterOperator.Or).ToArray();

                // Combine 'OR' strategies
                bool orFiltersApplied = false;

                if (orStrategies.Any())
                {
                    queryBuilder.OrWhere(
                        nestedOrQueryBuilder =>
                        {
                            foreach (var orStrategy in orStrategies)
                            {
                                if (TryApplyFilters(nestedOrQueryBuilder, orStrategy.Filters))
                                {
                                    orFiltersApplied = true;
                                }
                            }

                            return nestedOrQueryBuilder;
                        });
                }

                // If we have some OR strategies with filters defined, but no filters were applied, this is an error condition
                if (orStrategies.SelectMany(s => s.Filters).Any() && !orFiltersApplied)
                {
                    throw new Exception(
                        $"The following authorization filters are not recognized: {string.Join(" ", unsupportedAuthorizationFilters)}");
                }
            }

            bool TryApplyFilters(QueryBuilder nestedQueryBuilder, IReadOnlyList<AuthorizationFilterContext> filterContexts)
            {
                bool allFiltersCanBeApplied = true;

                foreach (var filterDetails in filterContexts)
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

                foreach (var filterContext in filterContexts)
                {
                    _authorizationFilterDefinitionProvider.TryGetAuthorizationFilterDefinition(
                        filterContext.FilterName,
                        out var filterDefinition);

                    var applicator = filterDefinition.TrackedChangesCriteriaApplicator;

                    // var parameterValues = new Dictionary<string, object>
                    // {
                    //     { filterContext.ClaimParameterName, filterContext.ClaimParameterValues }
                    // };

                    // Apply the authorization strategy filter
                    applicator(
                        filterDefinition,
                        filterContext,
                        resource,
                        filterIndex,
                        nestedQueryBuilder,
                        joinType != JoinType.InnerJoin);

                    filterIndex++;
                    filtersApplied = true;
                }

                return filtersApplied;
            }
        }

        private enum JoinType
        {
            InnerJoin = 1,
            LeftOuterJoin,
        }
    }
}
