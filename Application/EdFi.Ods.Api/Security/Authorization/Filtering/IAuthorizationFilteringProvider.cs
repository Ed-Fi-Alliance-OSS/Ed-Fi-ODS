// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Filtering;

/// <summary>
/// Defines methods for performing single-item and filter-based authorization appropriate to the claims, resource, action and possibly the entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
/// </summary>
public interface IAuthorizationFilteringProvider
{
    /// <summary>
    /// Authorizes a multiple-item read request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
    /// </summary>
    /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
    /// <param name="authorizationBasisMetadata"></param>
    /// <returns>A collection of filters to be applied to the query.</returns>
    IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering(
        EdFiAuthorizationContext authorizationContext,
        AuthorizationBasisMetadata authorizationBasisMetadata);
}
