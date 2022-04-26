// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security;
using System.Security.Claims;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Authorization
{
    public class TrackedChangesQueryFactoryAuthorizationDecoratorBase
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IAuthorizationFilterApplicationDetailsProvider _authorizationFilterApplicationDetailsProvider;
        private readonly IEdFiAuthorizationProvider _edFiAuthorizationProvider;

        protected TrackedChangesQueryFactoryAuthorizationDecoratorBase(
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider edFiAuthorizationProvider,
            IDomainModelProvider domainModelProvider,
            IDomainModelEnhancer domainModelEnhancer,
            IAuthorizationFilterApplicationDetailsProvider authorizationFilterApplicationDetailsProvider)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _edFiAuthorizationProvider = edFiAuthorizationProvider;
            _authorizationFilterApplicationDetailsProvider = authorizationFilterApplicationDetailsProvider;

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

            var authorizationContext = new EdFiAuthorizationContext(
                ClaimsPrincipal.Current,
                _authorizationContextProvider.GetResourceUris(),
                _authorizationContextProvider.GetAction(),
                entityType);

            var filterContexts = _edFiAuthorizationProvider.GetAuthorizationFilters(authorizationContext);

            var filterIndex = 0;

            // Apply authorization filters
            foreach (var filterContext in filterContexts)
            {
                if (!_authorizationFilterApplicationDetailsProvider.TryGetAuthorizationFilterDefinition(
                        filterContext.FilterName,
                        out var filterApplicationDetails))
                {
                    throw new EdFiSecurityException($"Filter '{filterContext.FilterName}' was not found. Are you using the correct authorization strategy for the '{resource.FullName}' resource and the API client's claim set?");
                }

                filterApplicationDetails.TrackedChangesCriteriaApplicator(
                    filterApplicationDetails,
                    filterContext,
                    resource,
                    filterIndex,
                    queryBuilder);

                filterIndex++;
            }
        }
    }
}
