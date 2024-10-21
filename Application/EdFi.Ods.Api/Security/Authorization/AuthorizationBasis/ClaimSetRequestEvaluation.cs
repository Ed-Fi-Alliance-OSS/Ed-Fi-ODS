// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

public class ClaimSetRequestEvaluation
{
    /// <summary>
    /// Indicates whether the claims-based check was successful for the requested resource and action.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// The security exception to be thrown, in the event of a failure.
    /// </summary>
    public SecurityAuthorizationException SecurityException { get; set; }

    /// <summary>
    /// The requested action.
    /// </summary>
    public string RequestedAction { get; set; }

    /// <summary>
    /// The possible resource claim URIs for the requested resource (i.e. schema-less (legacy) and schema-based representations).
    /// </summary>
    public IList<string> RequestedResourceUris { get; set; }

    /// <summary>
    /// Claim set-specific authorization metadata (which includes claim set-specific overrides) for claims assigned to the
    /// claim set that intersect with the <see cref="DefaultResourceClaimLineage"/> and can be used to authorize the request.
    /// </summary>
    public IList<ClaimSetResourceClaimMetadata> ClaimSetResourceClaimLineage { get; set; }

    /// <summary>
    /// Default authorization metadata for the full lineage of resource claims that can be used to authorize the request.
    /// </summary>
    public IList<DefaultResourceClaimMetadata> DefaultResourceClaimLineage { get; set; }
}
