// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Resource;
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
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
        private readonly IPersonTypesProvider _personTypesProvider;

        public RelationshipsAuthorizationStrategyFilterDefinitionsFactory(
            IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider,
            IApiClientContextProvider apiClientContextProvider,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
            IPersonTypesProvider personTypesProvider)
        {
            _educationOrganizationIdNamesProvider = educationOrganizationIdNamesProvider;
            _apiClientContextProvider = apiClientContextProvider;
            _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
            _personTypesProvider = personTypesProvider;
        }
        
        public virtual IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions()
        {
            return CreateAllEducationOrganizationToPersonFilters()
                .Concat(CreateAllEducationOrganizationToEducationOrganizationFilters())
                .ToArray();
        }

        protected IEnumerable<ViewBasedAuthorizationFilterDefinition> CreateAllEducationOrganizationToPersonFilters(
            string authorizationPathModifier = null,
            Func<string, bool> shouldIncludePersonType = null)
        {
            string[] personUsiNames = _personTypesProvider.PersonTypes
                .Where(usiName => shouldIncludePersonType == null || shouldIncludePersonType(usiName))
                // Sort the person types to ensure a determinate alias generation during filter definition
                .OrderBy(p => p)
                .Select(personType => $"{personType}USI")
                .ToArray();
            
            return personUsiNames.Select(usiName => 
                new ViewBasedAuthorizationFilterDefinition(
                    $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{usiName}{authorizationPathModifier}",
                    $"EducationOrganizationIdTo{usiName}{authorizationPathModifier}",
                    EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                    usiName,
                    ApplyTrackedChangesAuthorizationCriteria,
                    AuthorizeInstance,
                    _viewBasedSingleItemAuthorizationQuerySupport
                ));
        }

        protected IEnumerable<ViewBasedAuthorizationFilterDefinition> CreateAllEducationOrganizationToEducationOrganizationFilters()
        {
            string[] concreteEdOrgIdNames = _educationOrganizationIdNamesProvider.GetAllNames(); 
            
            return concreteEdOrgIdNames
                // Sort the edorg id names to ensure a determinate alias generation during filter definition
                .OrderBy(n => n)
                .Select(concreteEdOrgId => 
                    new ViewBasedAuthorizationFilterDefinition(
                        $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{concreteEdOrgId}",
                        "EducationOrganizationIdToEducationOrganizationId",
                        EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                        EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                        ApplyTrackedChangesAuthorizationCriteria,
                        AuthorizeInstance,
                        _viewBasedSingleItemAuthorizationQuerySupport))
                // Add filter definitions for using the EdOrg hierarchy inverted
                .Concat(concreteEdOrgIdNames
                    // Sort the edorg id names to ensure a determinate alias generation during filter definition
                    .OrderBy(n => n)
                    .Select(concreteEdOrgId => 
                        new ViewBasedAuthorizationFilterDefinition(
                            $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{concreteEdOrgId}{RelationshipAuthorizationConventions.InvertedSuffix}",
                            "EducationOrganizationIdToEducationOrganizationId",
                            EducationOrganizationAuthorizationViewConstants.TargetColumnName,
                            EducationOrganizationAuthorizationViewConstants.SourceColumnName,
                            ApplyTrackedChangesAuthorizationCriteria,
                            AuthorizeInstance,
                            _viewBasedSingleItemAuthorizationQuerySupport)));
        }

        private InstanceAuthorizationResult AuthorizeInstance(
            EdFiAuthorizationContext authorizationContext,
            AuthorizationFilterContext filterContext)
        {
            if (filterContext.SubjectEndpointValue == null)
            {
                if (filterContext.SubjectEndpointName.EndsWith("USI"))
                {
                    var subjectSubstring = filterContext.SubjectEndpointName.Substring(
                        0, filterContext.SubjectEndpointName.Length - 3);

                    throw new SecurityAuthorizationException(
                        SecurityAuthorizationException.DefaultDetail,
                        $"Either the referenced '{subjectSubstring}' was not found or no relationships have been established between the caller's education organization id claims ({string.Join(", ", filterContext.ClaimParameterValues)}) and the referenced '{subjectSubstring}'.");
                }

                throw new SecurityAuthorizationException(
                    SecurityAuthorizationException.DefaultDetail,
                    $"Access to the resource item could not be authorized because the '{filterContext.SubjectEndpointName}' of the resource is empty.");
            }

            // If the subject's endpoint name is an Education Organization Id, we can try to authenticate it here.
            if (_educationOrganizationIdNamesProvider.IsEducationOrganizationIdName(filterContext.SubjectEndpointName))
            {
                // NOTE: Could consider caching the EdOrgToEdOrgId tuple table.
                // If the EdOrgId values match, then we can report the filter as successfully authorized
                if (_apiClientContextProvider.GetApiClientContext()
                    .EducationOrganizationIds.Contains((long) filterContext.SubjectEndpointValue))
                {
                    return InstanceAuthorizationResult.Success();
                }
            }

            return InstanceAuthorizationResult.NotPerformed();
        }

        private static void ApplyTrackedChangesAuthorizationCriteria(
            AuthorizationFilterDefinition filterDefinition, 
            AuthorizationFilterContext filterContext, 
            Resource resource, 
            int filterIndex,
            QueryBuilder queryBuilder,
            bool useOuterJoins)
        {
            if (filterDefinition is not ViewBasedAuthorizationFilterDefinition viewBasedFilterDefinition)
            {
                 throw new Exception($"Expected a view-based filter definition of type '{nameof(ViewBasedAuthorizationFilterDefinition)}'.");
            }

            string viewName = viewBasedFilterDefinition.ViewName;

            string trackedChangesPropertyName = resource.Entity.IsDerived 
                ? GetBasePropertyNameForSubjectEndpointName() 
                : filterContext.SubjectEndpointName;

            if (useOuterJoins)
            {
                queryBuilder.LeftJoin(
                    $"auth.{viewName} AS rba{filterIndex}",
                    $"c.Old{trackedChangesPropertyName}",
                    $"rba{filterIndex}.{viewBasedFilterDefinition.ViewTargetEndpointName}");

                // Apply claim value criteria
                queryBuilder.OrWhereIn($"rba{filterIndex}.{viewBasedFilterDefinition.ViewSourceEndpointName}", filterContext.ClaimParameterValues);
            }
            else
            {
                queryBuilder.Join(
                    $"auth.{viewName} AS rba{filterIndex}",
                    $"c.Old{trackedChangesPropertyName}",
                    $"rba{filterIndex}.{viewBasedFilterDefinition.ViewTargetEndpointName}");

                // Apply claim value criteria
                queryBuilder.WhereIn($"rba{filterIndex}.{viewBasedFilterDefinition.ViewSourceEndpointName}", filterContext.ClaimParameterValues);
            }
            
            string GetBasePropertyNameForSubjectEndpointName()
            {
                if (!resource.Entity.PropertyByName.TryGetValue(filterContext.SubjectEndpointName, out var entityProperty))
                {
                    throw new Exception(
                        $"Unable to find property '{filterContext.SubjectEndpointName}' on entity '{resource.Entity.FullName}'.");
                }

                return entityProperty.BaseProperty.PropertyName;
            }
        }
    }
}
