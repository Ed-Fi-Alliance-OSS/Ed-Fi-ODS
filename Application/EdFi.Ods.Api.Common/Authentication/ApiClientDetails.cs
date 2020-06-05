// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Utils.Extensions;

namespace EdFi.Ods.Api.Common.Authentication
{
    /// <summary>
    /// Provides details about an API client after OAuth bearer token validation.
    /// </summary>
    public class ApiClientDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientDetails"/> class.
        /// </summary>
        public ApiClientDetails()
        {
            EducationOrganizationIds = new List<int>();
            NamespacePrefixes = new List<string>();
            Profiles = new List<string>();
            OwnershipTokenIds = new List<short?>();
        }

        /// <summary>
        /// Gets or sets the API key for the client.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Indicates whether the API bearer token was valid.
        /// </summary>
        public bool IsTokenValid
        {
            get => !string.IsNullOrWhiteSpace(ApiKey);
        }

        /// <summary>
        /// Gets or sets the list of Education Organization Ids associated with the API key.
        /// </summary>
        public IList<int> EducationOrganizationIds { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationId for the client.
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the Claim Set name of the application for the client
        /// </summary>
        public string ClaimSetName { get; set; }

        /// <summary>
        /// Gets or sets the NamespacePrefixes of the vendor of the application for the client
        /// </summary>
        public IList<string> NamespacePrefixes { get; set; }

        /// <summary>
        /// Gets or sets the Profiles that are assigned to the client
        /// </summary>
        public IList<string> Profiles { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating whether this API client should target a Sandbox database
        /// </summary>
        public bool IsSandboxClient { get; set; }

        /// <summary>
        /// Gets or sets the Student Identification System Descriptor
        /// </summary>
        public string StudentIdentificationSystemDescriptor { get; set; }
        
        /// <summary>
        /// Gets or sets the CreatorOwnershipTokenID for the given API client
        /// </summary>
        public short? CreatorOwnershipTokenId { get; set; }

        /// <summary>
        /// Gets or sets the OwnershipTokenIDs of the api client of the application for the client
        /// </summary>
        public IList<short?> OwnershipTokenIds { get; set; }

        /// <summary>
        /// Factory method to create a <see cref="ApiClientDetails"/> from a collection of <see cref="OAuthTokenClient"/>.
        /// </summary>
        /// <param name="tokenClientRecords"><see cref="OAuthTokenClient"/> records from the data layer</param>
        /// <returns>Single <see cref="ApiClientDetails"/> object with information about a client for a given token</returns>
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
                    .Where(x =>! string.IsNullOrWhiteSpace(x.ProfileName))
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
