// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class RelationshipsWithEdOrgsAndPeopleAuthorizationStrategyFilterConfigurator
        : INHibernateFilterConfigurator
    {
        /// <summary>
        /// Gets the NHibernate filter definitions and a functional delegate for determining when to apply them.
        /// </summary>
        /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and entity mappings.</returns>
        public IReadOnlyList<FilterApplicationDetails> GetFilters()
        {
            var filters = new List<FilterApplicationDetails>
                          {
                              // Local Education Agency/School to Person relationships
                              RelationshipsAuthorizationFilters.EducationServiceCenterIdToStudentUSI,
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToStudentUSI,
                              RelationshipsAuthorizationFilters.SchoolIdToStudentUSI,
                              RelationshipsAuthorizationFilters.EducationServiceCenterIdToStaffUSI,
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToStaffUSI,
                              RelationshipsAuthorizationFilters.SchoolIdToStaffUSI,
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToParentUSI,
                              RelationshipsAuthorizationFilters.ParentUSIToSchoolId,

                              // EdOrg to EdOrg relationships
                              RelationshipsAuthorizationFilters.EducationServiceCenterIdToLocalEducationAgencyId,
                              RelationshipsAuthorizationFilters.EducationServiceCenterIdToSchoolId,
                              RelationshipsAuthorizationFilters.EducationOrganizationIdToLocalEducationAgencyId,
                              RelationshipsAuthorizationFilters.EducationOrganizationIdToSchoolId,
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToSchoolId,
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToOrganizationDepartmentId,
                              RelationshipsAuthorizationFilters.EducationServiceCenterIdToLocalEducationAgencyId,
                              RelationshipsAuthorizationFilters.OrganizationDepartmentIdToSchoolId,
                              RelationshipsAuthorizationFilters.CommunityOrganizationIdToEducationOrganizationId,
                              RelationshipsAuthorizationFilters.CommunityProviderIdToEducationOrganizationId,
                              RelationshipsAuthorizationFilters.CommunityOrganizationIdToCommunityProviderId,
                              RelationshipsAuthorizationFilters.EducationOrganizationIdToPostSecondaryInstitutionId,

                              // Property-based filter authorizations (for direct API Client associations)
                              RelationshipsAuthorizationFilters.EducationServiceCenterIdToEducationServiceCenterId,
                              RelationshipsAuthorizationFilters.LocalEducationAgencyIdToLocalEducationAgencyId,
                              RelationshipsAuthorizationFilters.SchoolIdToSchoolId,
                              RelationshipsAuthorizationFilters.CommunityProviderIdToCommunityProviderId,
                              RelationshipsAuthorizationFilters.CommunityOrganizationIdToCommunityOrganizationId,
                              RelationshipsAuthorizationFilters.PostSecondaryInstitutionIdToPostSecondaryInstitutionId,
                              RelationshipsAuthorizationFilters.StateEducationAgencyIdToStateEducationAgencyId,

                          };

            return filters;
        }
    }
}
