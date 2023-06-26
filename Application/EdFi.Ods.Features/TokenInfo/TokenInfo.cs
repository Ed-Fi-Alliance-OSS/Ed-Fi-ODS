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
        public IReadOnlyList<string> NamespacePrefixes { get; private set; }

        [JsonProperty("education_organizations")]
        public IReadOnlyList<OrderedDictionary> EducationOrganizations { get; private set; }

        [JsonProperty("student_identification_system")]
        public string StudentIdentificationSystem { get; private set; }

        [JsonProperty("assigned_profiles")]
        public IReadOnlyList<string> AssignedProfiles { get; private set; }

        public static TokenInfo Create(ApiClientContext apiClientContext,
            IList<TokenInfoEducationOrganizationData> tokenInfoData)
        {
            var dataGroupedByEdOrgId = tokenInfoData
                .GroupBy(
                    x => (x.EducationOrganizationId, x.NameOfInstitution, x.Discriminator),
                    x =>
                    {
                        string type = x.AncestorDiscriminator.Split('.')[1];
                        string idPropertyName = Inflector.AddUnderscores($"{type}Id");

                        return new { PropertyName = idPropertyName, EducationOrganizationId = x.AncestorEducationOrganizationId };
                    });

            var tokenInfoEducationOrganizations = new List<OrderedDictionary>();

            foreach (var grouping in dataGroupedByEdOrgId)
            {
                var entry = new OrderedDictionary();

                var (educationOrganizationId, nameOfInstitution, discriminator) = grouping.Key;

                // Add properties for current claim value
                entry["education_organization_id"] = educationOrganizationId;
                entry["name_of_institution"] = nameOfInstitution;
                entry["type"] = discriminator;

                // Add related ancestor EducationOrganizationIds
                foreach (var ancestorEducationOrganization in grouping)
                {
                    entry[ancestorEducationOrganization.PropertyName] = ancestorEducationOrganization.EducationOrganizationId;
                }

                tokenInfoEducationOrganizations.Add(entry);
            }

            return new TokenInfo
            {
                Active = true,
                ApiKey = apiClientContext.ApiKey,
                NamespacePrefixes = apiClientContext.NamespacePrefixes.ToArray(),
                AssignedProfiles = apiClientContext.Profiles.ToArray(),
                StudentIdentificationSystem = apiClientContext.StudentIdentificationSystemDescriptor,
                EducationOrganizations = tokenInfoEducationOrganizations.ToArray()
            };
        }
    }
}
