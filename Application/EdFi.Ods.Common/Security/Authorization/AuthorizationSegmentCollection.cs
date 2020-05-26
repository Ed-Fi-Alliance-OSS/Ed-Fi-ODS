// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Represents a collection of authorization segments, separated by types (claims-based associations 
    /// and existing values associations).
    /// </summary>
    public class AuthorizationSegmentCollection
    {
        /// <summary>
        /// Gets the empty <see cref="AuthorizationSegmentCollection"/>.
        /// </summary>
        public static readonly AuthorizationSegmentCollection Empty =
            new AuthorizationSegmentCollection(
                new List<ClaimsAuthorizationSegment>(),
                new List<ExistingValuesAuthorizationSegment>());

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationSegmentCollection"/> class with the 
        /// supplied authorization segments.
        /// </summary>
        /// <param name="claimsAuthorizationSegments">A collection of segments indicating relationships required of the caller's claims.</param>
        /// <param name="existingValuesAuthorizationSegments">A collection of segments indicating related data that must already exist.</param>
        public AuthorizationSegmentCollection(
            IEnumerable<ClaimsAuthorizationSegment> claimsAuthorizationSegments,
            IEnumerable<ExistingValuesAuthorizationSegment> existingValuesAuthorizationSegments)
        {
            ClaimsAuthorizationSegments = claimsAuthorizationSegments.ToList()
                                                                     .AsReadOnly();

            ExistingValuesAuthorizationSegments = existingValuesAuthorizationSegments.ToList()
                                                                                     .AsReadOnly();
        }

        /// <summary>
        /// Gets the claims authorization segments.
        /// </summary>
        public IReadOnlyList<ClaimsAuthorizationSegment> ClaimsAuthorizationSegments { get; }

        /// <summary>
        /// Gets the existing values authorization segments.
        /// </summary>
        public IReadOnlyList<ExistingValuesAuthorizationSegment> ExistingValuesAuthorizationSegments { get; }
    }
}
