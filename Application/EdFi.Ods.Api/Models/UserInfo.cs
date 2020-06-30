// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Api.Models
{
    public class UserInfo
    {
        public IEnumerable<object> EducationOrganizations { get; set; }

        public IEnumerable<int> EducationOrganizationIds { get; set; }

        public string StudentIdentificationSystem { get; set; }

        public IEnumerable<string> AssignedProfiles { get; set; }

        public IEnumerable<string> Namespaces { get; set; }

        public string ClaimSet { get; set; }

        public static UserInfo Create(ApiKeyContext apiKeyContext,
            IList<EducationOrganizationIdentifiers> educationOrganizationIdentifiers)
        {
            return new UserInfo
            {
                Namespaces = apiKeyContext.NamespacePrefixes,
                AssignedProfiles = apiKeyContext.Profiles,
                StudentIdentificationSystem = apiKeyContext.StudentIdentificationSystemDescriptor,
                EducationOrganizationIds = apiKeyContext.EducationOrganizationIds,
                EducationOrganizations = educationOrganizationIdentifiers
                    .Select(
                        x => new
                        {
                            x.EducationOrganizationId,
                            x.StateEducationAgencyId,
                            x.LocalEducationAgencyId,
                            x.SchoolId,
                            x.CommunityOrganizationId,
                            x.CommunityProviderId,
                            x.PostSecondaryInstitutionId,
                            x.UniversityId,
                            x.TeacherPreparationProviderId,
                            x.NameOfInstitution,
                            type = x.FullEducationOrganizationType
                        })
            };
        }
    }
}
