// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Common.Security
{
    /// <summary>
    /// Provides details about an API client.
    /// </summary>
    public class ApiClientDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientDetails"/> class with default values and empty lists.
        /// </summary>
        public ApiClientDetails()
        {
            EducationOrganizationIds = new List<long>();
            NamespacePrefixes = new List<string>();
            Profiles = new List<string>();
            OwnershipTokenIds = new List<short>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClientDetails"/> class using the supplied values.
        /// </summary>
        /// <param name="apiClientId"></param>
        /// <param name="apiKey"></param>
        /// <param name="secret"></param>
        /// <param name="secretIsHashed"></param>
        /// <param name="claimSetName"></param>
        /// <param name="educationOrganizationIds"></param>
        /// <param name="namespacePrefixes"></param>
        /// <param name="profiles"></param>
        /// <param name="isSandboxClient"></param>
        /// <param name="studentIdentificationSystemDescriptor"></param>
        /// <param name="creatorOwnershipTokenId"></param>
        /// <param name="ownershipTokenIds"></param>
        /// <param name="odsInstanceIds"></param>
        /// <param name="expiresUtc"></param>
        public ApiClientDetails(
            int apiClientId,
            string apiKey,
            string secret,
            bool? secretIsHashed,
            string claimSetName,
            IList<long> educationOrganizationIds,
            IList<string> namespacePrefixes,
            IList<string> profiles,
            bool isSandboxClient,
            string studentIdentificationSystemDescriptor,
            short? creatorOwnershipTokenId,
            IList<short> ownershipTokenIds,
            IList<int> odsInstanceIds,
            DateTime expiresUtc)
        {
            ApiClientId = apiClientId;
            ApiKey = apiKey;
            Secret = secret;
            SecretIsHashed = secretIsHashed ?? false;
            EducationOrganizationIds = educationOrganizationIds;
            ClaimSetName = claimSetName;
            NamespacePrefixes = namespacePrefixes;
            Profiles = profiles;
            IsSandboxClient = isSandboxClient;
            StudentIdentificationSystemDescriptor = studentIdentificationSystemDescriptor;
            CreatorOwnershipTokenId = creatorOwnershipTokenId;
            OwnershipTokenIds = ownershipTokenIds;
            OdsInstanceIds = odsInstanceIds;
            ExpiresUtc = expiresUtc;
        }

        /// <summary>
        /// Gets or sets the assigned surrogate id of the API client.
        /// </summary>
        public int ApiClientId { get; set; }

        /// <summary>
        /// Gets or sets the API key for the client.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the secret for the client.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Indicates whether the secret is hashed.
        /// </summary>
        public bool SecretIsHashed { get; set; }
        
        /// <summary>
        /// Gets or sets the UTC expiration time of the token.
        /// </summary>
        public DateTime ExpiresUtc { get; set; }

        /// <summary>
        /// Indicates whether the API bearer token is valid and hasn't expired.
        /// </summary>
        public bool IsTokenValid
        {
            get => !string.IsNullOrWhiteSpace(ApiKey) && DateTime.UtcNow < ExpiresUtc;
        }

        /// <summary>
        /// Gets or sets the list of Education Organization Ids associated with the API key.
        /// </summary>
        public IList<long> EducationOrganizationIds { get; set; }

        /// <summary>
        /// Gets or sets the Claim Set name associated with the application for the client.
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
        public IList<short> OwnershipTokenIds { get; set; }

        /// <summary>
        /// Gets or sets the OdsInstanceIds for the client
        /// </summary>
        public IList<int> OdsInstanceIds { get; set; }
    }
}
