// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Caching
{
    public class EducationOrganizationIdentifiers
    {
        private EducationOrganizationIdentifiers(int educationOrganizationId)
        {
            EducationOrganizationId = educationOrganizationId;
        }

        public EducationOrganizationIdentifiers() { }

        public EducationOrganizationIdentifiers(
            int educationOrganizationId,
            string educationOrganizationType,
            int? stateEducationAgencyId = null,
            int? educationServiceCenterId = null,
            int? localEducationAgencyId = null,
            int? schoolId = null,
            int? communityOrganizationId = null,
            int? communityProviderId = null,
            int? postSecondaryInstitutionId = null,
            // For TPDM Extension Support
            int? universityId = null,
            int? teacherPreparationProviderId = null)
        {
            EducationOrganizationId = educationOrganizationId;
            EducationOrganizationType = educationOrganizationType;
            StateEducationAgencyId = stateEducationAgencyId;
            EducationServiceCenterId = educationServiceCenterId;
            LocalEducationAgencyId = localEducationAgencyId;
            SchoolId = schoolId;
            CommunityOrganizationId = communityOrganizationId;
            CommunityProviderId = communityProviderId;
            PostSecondaryInstitutionId = postSecondaryInstitutionId;
            // For TPDM Extension Support
            UniversityId = universityId;
            TeacherPreparationProviderId = teacherPreparationProviderId;
        }

        public int EducationOrganizationId { get; private set; }

        public string EducationOrganizationType { get; private set; }

        public int? StateEducationAgencyId { get; private set; }

        public int? EducationServiceCenterId { get; private set; }

        public int? LocalEducationAgencyId { get; private set; }

        public int? SchoolId { get; private set; }

        public int? CommunityOrganizationId { get; private set; }

        public int? CommunityProviderId { get; private set; }

        public int? PostSecondaryInstitutionId { get; private set; }

        // For TPDM Extension Support
        public int? UniversityId { get; private set; }

        // For TPDM Extension Support
        public int? TeacherPreparationProviderId { get; private set; }

        public bool IsDefault => EducationOrganizationId == default(int)
                                 && EducationServiceCenterId == null
                                 && EducationOrganizationType == null
                                 && LocalEducationAgencyId == null
                                 && SchoolId == null
                                 && StateEducationAgencyId == null
                                 && CommunityOrganizationId == null
                                 && CommunityProviderId == null
                                 && PostSecondaryInstitutionId == null
                                 // For TPDM Extension Support
                                 && UniversityId == null
                                 && TeacherPreparationProviderId == null;

        public static EducationOrganizationIdentifiers CreateLookupInstance(int educationOrganizationId)
        {
            return new EducationOrganizationIdentifiers(educationOrganizationId);
        }
    }
}
