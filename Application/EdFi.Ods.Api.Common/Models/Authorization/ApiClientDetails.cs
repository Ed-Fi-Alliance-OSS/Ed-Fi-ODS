// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Api.Common.Models.Authorization
{
    public class ApiClientDetails
    {
        public ApiClientDetails()
        {
            EducationOrganizationIds = new List<int>();
            NamespacePrefixes = new List<string>();
            Profiles = new List<string>();
            OwnershipTokenIds = new List<short?>();
        }

        public string ApiKey { get; set; }

        public bool IsTokenValid
        {
            get => !string.IsNullOrWhiteSpace(ApiKey);
        }

        public IList<int> EducationOrganizationIds { get; set; }

        public int ApplicationId { get; set; }

        public string ClaimSetName { get; set; }

        public IList<string> NamespacePrefixes { get; set; }

        public IList<string> Profiles { get; set; }

        public bool IsSandboxClient { get; set; }

        public string StudentIdentificationSystemDescriptor { get; set; }

        public short? CreatorOwnershipTokenId { get; set; }

        public IList<short?> OwnershipTokenIds { get; set; }

        public static ApiClientDetails Create(IReadOnlyList<OAuthTokenClient> tokenClientRecords)
        {
            Preconditions.ThrowIfNull(tokenClientRecords, nameof(tokenClientRecords));

            var tokenClient = tokenClientRecords.FirstOrDefault();

            if (tokenClient == null)
            {
                return new ApiClientDetails();
            }

            var response = CreateInitialObjectFromFirstRecord(tokenClient);
            response = LoadAllEducationOrganizationIds(response);
            response = LoadAllVendorNamespacePrefixes(response);
            response = LoadAllProfileNames(response);
            response = LoadAllOwnershipTokenIds(response);

            return response;

            ApiClientDetails CreateInitialObjectFromFirstRecord(OAuthTokenClient input)
            {
                var dto = new ApiClientDetails
                {
                    ApiKey = input.Key,
                    ClaimSetName = input.ClaimSetName,
                    IsSandboxClient = input.UseSandbox,
                    StudentIdentificationSystemDescriptor = input.StudentIdentificationSystemDescriptor,
                    CreatorOwnershipTokenId = input.CreatorOwnershipTokenId
                };

                return dto;
            }

            ApiClientDetails LoadAllEducationOrganizationIds(ApiClientDetails dto)
            {
                tokenClientRecords
                    .Where(x => x.EducationOrganizationId.HasValue)
                    .Select(x => x.EducationOrganizationId.Value)
                    .Distinct()
                    .ForEach(x => dto.EducationOrganizationIds.Add(x));

                return dto;
            }

            ApiClientDetails LoadAllVendorNamespacePrefixes(ApiClientDetails dto)
            {
                tokenClientRecords
                    .Where(x => !string.IsNullOrWhiteSpace(x.NamespacePrefix))
                    .Select(x => x.NamespacePrefix)
                    .Distinct()
                    .ForEach(x => dto.NamespacePrefixes.Add(x));

                return dto;
            }

            ApiClientDetails LoadAllProfileNames(ApiClientDetails dto)
            {
                tokenClientRecords
                    .Where(x => !string.IsNullOrWhiteSpace(x.ProfileName))
                    .Select(x => x.ProfileName)
                    .Distinct()
                    .ForEach(x => dto.Profiles.Add(x));

                return dto;
            }

            ApiClientDetails LoadAllOwnershipTokenIds(ApiClientDetails dto)
            {
                tokenClientRecords
                    .Where(x => x.OwnershipTokenId.HasValue)
                    .Select(x => x.OwnershipTokenId.Value)
                    .Distinct()
                    .ForEach(x => dto.OwnershipTokenIds.Add(x));

                return dto;
            }
        }
    }
}
