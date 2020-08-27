// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
            IEnumerable<int> educationOrganizationIds,
            IEnumerable<string> namespacePrefixes,
            IEnumerable<string> profiles,
            string studentIdentificationSystemDescriptor,
            short? creatorOwnershipTokenId,
            IEnumerable<short?> ownershipTokenIds)
        {
            ApiKey = apiKey;
            ClaimSetName = claimSetName;
            EducationOrganizationIds = educationOrganizationIds ?? new List<int>();
            NamespacePrefixes = namespacePrefixes;
            StudentIdentificationSystemDescriptor = studentIdentificationSystemDescriptor;
            Profiles = profiles ?? new List<string>();
            CreatorOwnershipTokenId = creatorOwnershipTokenId;
            OwnershipTokenIds = ownershipTokenIds ?? new List<short?>();
        }

        public IEnumerable<short?> OwnershipTokenIds { get; }

        public short? CreatorOwnershipTokenId { get; }

        public string ApiKey { get; }

        public string ClaimSetName { get; }

        public IEnumerable<int> EducationOrganizationIds { get; }

        public IEnumerable<string> NamespacePrefixes { get; }

        public IEnumerable<string> Profiles { get; }

        public string StudentIdentificationSystemDescriptor { get; }

        /// <summary>
        /// Returns an empty, uninitialized <see cref="ApiKeyContext"/> instance.
        /// </summary>
        public static ApiKeyContext Empty { get; } = new ApiKeyContext();
    }
}
