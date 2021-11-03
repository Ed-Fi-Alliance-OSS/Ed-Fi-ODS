// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using EdFi.Common.Inflection;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Security;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.TokenInfo
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
            IList<TokenInfoData> tokenInfoData)
        {
            var dataGroupedByEdOrgId = tokenInfoData
                                        .GroupBy(x => (x.ClaimEducationOrganizationId, x.ClaimNameOfInstitution, x.ClaimDiscriminator), x => x);

            var tokenInfoEducationOrganizations = new List<OrderedDictionary>();

            foreach (var grouping in dataGroupedByEdOrgId)
            {
                var entry = new OrderedDictionary();

                var (educationOrganizationId, nameOfInstitution, discriminator) = grouping.Key;

                // Add properties for current claim value
                entry["education_organization_id"] = educationOrganizationId;

                // Add alternate related EducationOrganizationIds
                foreach (var alternateEducationOrganization in grouping)
                {
                    string type = alternateEducationOrganization.Discriminator.Split('.')[1];
                    string idPropertyName = Inflector.AddUnderscores($"{type}Id");

                    entry[idPropertyName] = alternateEducationOrganization.EducationOrganizationId;
                }

                entry["name_of_institution"] = nameOfInstitution;
                entry["type"] = discriminator;

                tokenInfoEducationOrganizations.Add(entry);
            }

            return new TokenInfo
            {
                Active = true,
                ApiKey = apiKeyContext.ApiKey,
                NamespacePrefixes = apiKeyContext.NamespacePrefixes,
                AssignedProfiles = apiKeyContext.Profiles,
                StudentIdentificationSystem = apiKeyContext.StudentIdentificationSystemDescriptor,
                EducationOrganizations = tokenInfoEducationOrganizations.ToArray()
            };
        }

    }
}
