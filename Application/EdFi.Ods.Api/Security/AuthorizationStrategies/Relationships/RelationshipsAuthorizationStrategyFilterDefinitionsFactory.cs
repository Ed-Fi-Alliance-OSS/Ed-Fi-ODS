// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.NHibernateConfiguration;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Implements a filter configurator that uses the semantic API model to generate filters with default behavior
    /// for all permutations of education organizations and person types.  
    /// </summary>
    public class RelationshipsAuthorizationStrategyFilterDefinitionsFactory : IAuthorizationFilterDefinitionsFactory
    {
        private readonly IEducationOrganizationIdNamesProvider _educationOrganizationIdNamesProvider;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;

        public RelationshipsAuthorizationStrategyFilterDefinitionsFactory(
            IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
            IApiKeyContextProvider apiKeyContextProvider,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport)
        {
            _educationOrganizationIdNamesProvider = educationOrganizationIdNamesProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
            _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        }
        
        public virtual IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
        {
            return CreateAllEducationOrganizationToPersonFilters()
                .Concat(CreateAllEducationOrganizationToEducationOrganizationFilters())
                .Concat(CreateEducationOrganizationToSelfPropertyValueFilters()) // NOTE: These may not actually be used (and if so, could be removed)
                .ToArray();
            
            IEnumerable<ViewBasedAuthorizationFilterDefinition> CreateAllEducationOrganizationToPersonFilters()
            {
                string[] personUsiNames = PersonEntitySpecification.ValidPersonTypes
                    // Sort the person types to ensure a determinate alias generation during filter definition
                    .OrderBy(p => p)
                    .Select(personType => $"{personType}USI")
                    .ToArray();
            
                return personUsiNames.Select(usiName => 
                    new ViewBasedAuthorizationFilterDefinition(
                        $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{usiName}",
                        $"EducationOrganizationIdTo{usiName}",
                        usiName,
                        usiName,
                        AuthorizeInstance,
                        _viewBasedSingleItemAuthorizationQuerySupport
                    ));
            }

            IEnumerable<ViewBasedAuthorizationFilterDefinition> CreateAllEducationOrganizationToEducationOrganizationFilters()
            {
                string[] concreteEdOrgIdNames = _educationOrganizationIdNamesProvider.GetAllNames(); 
            
                return concreteEdOrgIdNames
                    // Sort the edorg id names to ensure a determinate alias generation during filter definition
                    .OrderBy(n => n)
                    .Select(concreteEdOrgId => 
                    new ViewBasedAuthorizationFilterDefinition(
                        $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{concreteEdOrgId}",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        concreteEdOrgId,
                        AuthorizeInstance,
                        _viewBasedSingleItemAuthorizationQuerySupport));
            }

            IEnumerable<AuthorizationFilterDefinition> CreateEducationOrganizationToSelfPropertyValueFilters()
            {
                return _educationOrganizationIdNamesProvider.GetConcreteNames()
                    .Select(propertyName => 
                        new AuthorizationFilterDefinition(
                            $"{propertyName}To{propertyName}",
                            $"{{currentAlias}}.{propertyName} IN (:{propertyName})",
                            (criteria, whereJunction, parameters, joinType) => whereJunction.ApplyPropertyFilters(parameters, propertyName),
                            AuthorizeInstance,
                            (t, p) => p.HasPropertyNamed(propertyName)));
            }
        }

        protected InstanceAuthorizationResult AuthorizeInstance(
            EdFiAuthorizationContext authorizationContext,
            AuthorizationFilterContext filterContext)
        {
            if (filterContext.SubjectEndpointValue == null)
            {
                // This should never happen
                throw new EdFiSecurityException(
                    $"Access to the resource item could not be authorized because the '{filterContext.SubjectEndpointName}' of the resource is empty.");
            }

            // If the subject's endpoint name is an Education Organization Id, we can try to authenticate it here.
            if (_educationOrganizationIdNamesProvider.IsEducationOrganizationIdName(filterContext.SubjectEndpointName))
            {
                // NOTE: Could consider caching the EdOrgToEdOrgId tuple table.
                // If the EdOrgId values match, then we can report the filter as successfully authorized
                if (_apiKeyContextProvider.GetApiKeyContext()
                    .EducationOrganizationIds.Contains((int) filterContext.SubjectEndpointValue))
                {
                    return InstanceAuthorizationResult.Success();
                }
            }

            return InstanceAuthorizationResult.NotPerformed();
        }
    }
}
