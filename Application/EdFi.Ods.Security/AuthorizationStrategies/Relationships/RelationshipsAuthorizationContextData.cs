// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Security.AuthorizationStrategies.Relationships
{
    /// <summary>
    /// Contains the pertinent Ed-Fi data necessary for making authorization decisions.
    /// </summary>
    public class RelationshipsAuthorizationContextData
    {
        // Education Organizations
        public int? EducationOrganizationId { get; set; }

        public int? StateEducationAgencyId { get; set; }

        public int? EducationServiceCenterId { get; set; }

        public int? LocalEducationAgencyId { get; set; }

        public int? SchoolId { get; set; }

        public int? EducationOrganizationNetworkId { get; set; }

        public int? CommunityOrganizationId { get; set; }

        public int? CommunityProviderId { get; set; }

        public int? PostSecondaryInstitutionId { get; set; }

        // For TPDM Extension Support
        public int? UniversityId { get; set; }

        // For TPDM Extension Support
        public int? TeacherPreparationProviderId { get; set; }

        // People
        public int? StaffUSI { get; set; }

        public int? StudentUSI { get; set; }

        public int? ParentUSI { get; set; }

        // Education Organization Type (set after resolved to concrete type id)
        public string ConcreteEducationOrganizationIdPropertyName { get; set; }

        public virtual RelationshipsAuthorizationContextData Clone()
        {
            var clone = new AuthorizationContextDataFactory()
               .CreateContextData<RelationshipsAuthorizationContextData>(this);

            return clone;
        }
    }
}
