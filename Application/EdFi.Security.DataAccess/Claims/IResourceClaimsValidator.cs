// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Security.DataAccess.Models;

namespace EdFi.Security.DataAccess.Claims;

/// <summary>
/// Defines a method for validating the lineage up the taxonomy of a resource claim.
/// </summary>
public interface IResourceClaimsValidator
{
    /// <summary>
    /// Validate that the resource claim lineage for the resource claim is well-formed, ensuring
    /// that there are no cycles, which would cause an infinite loop when evaluating claims.
    /// Otherwise, an exception is thrown.
    /// </summary>
    /// <param name="resourceClaimUri">The URI of the resource claim for which to validate the resource claim lineage.</param>
    public void ValidateResourceClaimLineageForResourceClaim(string resourceClaimUri);
}
