// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Models
{
    public class TokenInfo
    {
        public bool Active { get; private set; }

        [JsonProperty("client_id")]
        public string ApiKey { get; private set; }

        [JsonProperty("namespace_prefixes")]
        public IEnumerable<string> NamespacePrefixes { get; private set; }

        [JsonProperty("education_organizations")]
        public IEnumerable<object> EducationOrganizations { get; private set; }

        [JsonProperty("student_identification_system")]
        public string StudentIdentificationSystem { get; private set; }

        [JsonProperty("assigned_profiles")]
        public IEnumerable<string> AssignedProfiles { get; private set; }

        public static TokenInfo Create(ApiKeyContext apiKeyContext,
            IList<EducationOrganizationIdentifiers> educationOrganizationIdentifiers)
        {
            return new TokenInfo
            {
                Active = true,
                ApiKey = apiKeyContext.ApiKey,
                NamespacePrefixes = apiKeyContext.NamespacePrefixes,
                AssignedProfiles = apiKeyContext.Profiles,
                StudentIdentificationSystem = apiKeyContext.StudentIdentificationSystemDescriptor,
                EducationOrganizations = educationOrganizationIdentifiers
                    .Select(
                        x => new
                        {
                            education_organization_id = x.EducationOrganizationId,
                            state_education_organization_id = x.StateEducationAgencyId,
                            local_education_agency_id = x.LocalEducationAgencyId,
                            school_id = x.SchoolId,
                            community_organization_id = x.CommunityOrganizationId,
                            community_provider_id = x.CommunityProviderId,
                            post_secondary_institution_id = x.PostSecondaryInstitutionId,
                            university_id = x.UniversityId,
                            teacher_preparation_provider_id = x.TeacherPreparationProviderId,
                            name_of_institution = x.NameOfInstitution,
                            type = x.FullEducationOrganizationType
                        })
                    .ToArray()
            };
        }
    }
}
