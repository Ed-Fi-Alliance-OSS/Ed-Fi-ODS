// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Dynamic;
using EdFi.Common.Extensions;
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
            IList<EducationOrganizationIdentifiers> educationOrganizationIdentifiers)
        {
            var educationOrganizationIdentifierList = new List<dynamic>();
            foreach (var educationOrganizationIdentifier in educationOrganizationIdentifiers)
            {
                string propertyName = educationOrganizationIdentifier.EducationOrganizationType + "Id";
                propertyName = propertyName.NormalizeCompositeTermForDisplay().Replace(' ', '_').ToLower();

                dynamic expandObjectInstance = new ExpandoObject();
                var edOrgIdentifier = expandObjectInstance as IDictionary<string, object>;

                AddProperty(edOrgIdentifier, "education_organization_id", educationOrganizationIdentifier.EducationOrganizationId);
                AddProperty(edOrgIdentifier, "local_education_agency_id", educationOrganizationIdentifier.EducationOrganizationId);

                if (!educationOrganizationIdentifier.EducationOrganizationId.Equals(educationOrganizationIdentifier.LocalEducationAgencyId))
                {
                    AddProperty(edOrgIdentifier, propertyName, educationOrganizationIdentifier.LocalEducationAgencyId); 
                }
                  
                AddProperty(edOrgIdentifier, "name_of_institution", educationOrganizationIdentifier.NameOfInstitution);
                AddProperty(edOrgIdentifier, "type", educationOrganizationIdentifier.EducationOrganizationType);

                educationOrganizationIdentifierList.Add(edOrgIdentifier);
            }

            return new TokenInfo
            {
                Active = true,
                ApiKey = apiKeyContext.ApiKey,
                NamespacePrefixes = apiKeyContext.NamespacePrefixes,
                AssignedProfiles = apiKeyContext.Profiles,
                StudentIdentificationSystem = apiKeyContext.StudentIdentificationSystemDescriptor,
                EducationOrganizations = educationOrganizationIdentifierList.ToArray()
            };
        }

        private static void AddProperty(IDictionary<string, object> expandoDictionary, string propertyName, object propertyValue)
        {
            if (expandoDictionary.ContainsKey(propertyName))
                expandoDictionary[propertyName] = propertyValue;
            else
                expandoDictionary.Add(propertyName, propertyValue);
        }
    }
}
