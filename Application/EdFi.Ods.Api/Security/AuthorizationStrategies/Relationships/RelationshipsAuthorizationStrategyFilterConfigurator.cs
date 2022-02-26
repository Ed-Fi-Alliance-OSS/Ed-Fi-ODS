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
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Implements a filter configurator that uses the semantic API model to generate filters with default behavior
    /// for all permutations of education organizations and person types.  
    /// </summary>
    public class RelationshipsAuthorizationStrategyFilterConfigurator : INHibernateFilterConfigurator
    {
        private readonly IEducationOrganizationIdNamesProvider _educationOrganizationIdNamesProvider;

        public RelationshipsAuthorizationStrategyFilterConfigurator(IEducationOrganizationIdNamesProvider educationOrganizationIdNamesProvider)
        {
            _educationOrganizationIdNamesProvider = educationOrganizationIdNamesProvider;
        }
        
        public IReadOnlyList<FilterApplicationDetails> GetFilters()
        {
            return CreateAllEducationOrganizationToPersonFilters()
                .Concat(CreateAllEducationOrganizationToEducationOrganizationFilters())
                .Concat(CreateEducationOrganizationToSelfPropertyValueFilters())
                .ToArray();
            
            IEnumerable<ViewFilterApplicationDetails> CreateAllEducationOrganizationToPersonFilters()
            {
                string[] personUsiNames = PersonEntitySpecification.ValidPersonTypes.Select(personType => $"{personType}USI").ToArray();
            
                return personUsiNames.Select(usiName => 
                    new ViewFilterApplicationDetails(
                        $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{usiName}",
                        $"EducationOrganizationIdTo{usiName}",
                        usiName,
                        usiName));
            }

            IEnumerable<ViewFilterApplicationDetails> CreateAllEducationOrganizationToEducationOrganizationFilters()
            {
                string[] concreteEdOrgIdNames = _educationOrganizationIdNamesProvider.GetAllNames(); 
            
                return concreteEdOrgIdNames.Select(concreteEdOrgId => 
                    new ViewFilterApplicationDetails(
                        $"{RelationshipAuthorizationConventions.FilterNamePrefix}To{concreteEdOrgId}",
                        "EducationOrganizationIdToEducationOrganizationId",
                        "TargetEducationOrganizationId",
                        concreteEdOrgId));
            }

            IEnumerable<FilterApplicationDetails> CreateEducationOrganizationToSelfPropertyValueFilters()
            {
                return _educationOrganizationIdNamesProvider.GetConcreteNames()
                    .Select(propertyName => 
                        new FilterApplicationDetails(
                            $"{propertyName}To{propertyName}",
                            $"{propertyName} IN (:{propertyName})",
                            $"{{currentAlias}}.{propertyName} IN (:{propertyName})",
                            (c, w, p, jt) => w.ApplyPropertyFilters(p, propertyName),
                            (t, p) => p.HasPropertyNamed(propertyName)));
            }
        }
    }
}
