// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EdFi.Security.DataAccess.Models;

namespace EdFi.Security.DataAccess.Repositories;

/// <summary>
/// Defines higher-level methods for obtaining security metadata for making authorization decisions.
/// </summary>
/// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-security".</remarks>
[Intercept("cache-security")]
public interface ISecurityRepository
{
    Action GetActionByName(string actionName);

    AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName);

    IList<ClaimSetResourceClaimAction> GetClaimsForClaimSet(string claimSetName);

    /// <summary>
    /// Gets the lineage up the taxonomy of resource claim URIs for the specified resource.
    /// </summary>
    /// <param name="resourceUri">The resource URI representing the resource.</param>
    /// <returns>The resource claim URIs.</returns>
    IList<string> GetResourceClaimLineage(string resourceUri);

    /// <summary>
    /// Gets the authorization metadata of the lineage up the taxonomy of resource claims
    /// for the specified resource.
    /// </summary>
    /// <param name="resourceClaimUri">The resource claim URI representing the resource.</param>
    /// <returns>The resource claim authorization metadata.</returns>
    IList<ResourceClaimAction> GetResourceClaimLineageMetadata(string resourceClaimUri, string action);

    ResourceClaim GetResourceByResourceName(string resourceName);
}
