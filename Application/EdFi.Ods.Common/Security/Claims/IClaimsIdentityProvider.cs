// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Security.Claims;

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Defines a method for obtaining a <see cref="ClaimsIdentity"/> instance for building a <see cref="ClaimsPrincipal"/>.
    /// </summary>
    public interface IClaimsIdentityProvider
    {
        /// <summary>
        /// Gets a <see cref="ClaimsIdentity"/> instance for building a <see cref="ClaimsPrincipal"/>.
        /// </summary>
        /// <returns>The <see cref="ClaimsIdentity"/>.</returns>
        ClaimsIdentity GetClaimsIdentity();

        /// <summary>
        /// Gets a <see cref="ClaimsIdentity"/> instance for building a <see cref="ClaimsPrincipal"/>.
        /// </summary>
        /// <param name="localEducationAgencyIds">The EducationOrganizationIds with which the caller is associated.</param>
        /// <param name="claimSetName">The name of the claimset (i.e. role) assigned to the caller.</param>
        /// <param name="vendorNamespacePrefixes">The namespace prefix(es) assigned to the caller by the API host.</param>
        /// <param name="assignedProfileNames">The list of API Profiles assigned to the caller.</param>
        /// <returns>The <see cref="ClaimsIdentity"/>.</returns>
        ClaimsIdentity GetClaimsIdentity(
            IEnumerable<int> localEducationAgencyIds,
            string claimSetName,
            IEnumerable<string> vendorNamespacePrefixes,
            IReadOnlyList<string> assignedProfileNames);
    }

    /// <summary>
    /// Defines authentication types supported by the Ed-Fi solution.
    /// </summary>
    public class EdFiAuthenticationTypes
    {
        /// <summary>
        /// The authentication type associated with the Ed-Fi OAuth implementation (which is applied to the <see cref="ClaimsIdentity"/> when it's created).
        /// </summary>
        public const string OAuth = "OAuth";
    }
}
