// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Security
{
    /// <summary>
    /// Contains contextual information about the current API caller.
    /// </summary>
    public class ApiKeyContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApiKeyContext"/> class as default constructor.
        /// </summary>
        public ApiKeyContext() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ApiKeyContext"/> class.
        /// </summary>
        public ApiKeyContext(
            string apiKey,
            string claimSetName,
            IList<int> educationOrganizationIds,
            IList<string> namespacePrefixes,
            IList<string> profiles,
            string studentIdentificationSystemDescriptor,
            short? creatorOwnershipTokenId,
            IList<short> ownershipTokenIds,
            IList<int> odsInstanceIds,
            int apiClientId)
        {
            ApiKey = apiKey;
            ClaimSetName = claimSetName;
            EducationOrganizationIds = educationOrganizationIds ?? Array.Empty<int>();
            NamespacePrefixes = namespacePrefixes ?? Array.Empty<string>();
            StudentIdentificationSystemDescriptor = studentIdentificationSystemDescriptor;
            Profiles = profiles ?? Array.Empty<string>();
            CreatorOwnershipTokenId = creatorOwnershipTokenId;
            OwnershipTokenIds = ownershipTokenIds ?? Array.Empty<short>();
            OdsInstanceIds = odsInstanceIds ?? Array.Empty<int>();
            ApiClientId = apiClientId;
        }

        public IList<short> OwnershipTokenIds { get; }

        public IList<int> OdsInstanceIds { get; }

        public short? CreatorOwnershipTokenId { get; }

        public string ApiKey { get; }

        public string ClaimSetName { get; }

        public IList<int> EducationOrganizationIds { get; }

        public IList<string> NamespacePrefixes { get; }

        public IList<string> Profiles { get; }

        public string StudentIdentificationSystemDescriptor { get; }

        public int ApiClientId { get; }

        /// <summary>
        /// Returns an empty, uninitialized <see cref="ApiKeyContext"/> instance.
        /// </summary>
        public static ApiKeyContext Empty { get; } = new();
    }
}
