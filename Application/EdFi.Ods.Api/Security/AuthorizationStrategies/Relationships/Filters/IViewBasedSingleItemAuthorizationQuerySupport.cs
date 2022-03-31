// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.Common;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;

/// <summary>
/// Defines methods for supporting database engine-specific authorization of entity instances using a view-based authorization query. 
/// </summary>
public interface IViewBasedSingleItemAuthorizationQuerySupport
{
    /// <summary>
    /// Gets the SQL for a particular view-based filter definition.
    /// </summary>
    /// <param name="filterDefinition"></param>
    /// <param name="filterContext"></param>
    /// <returns>The SELECT statement to be incorporated into an EXISTS clause in an authorization query.</returns>
    string GetItemExistenceCheckSql(
        ViewBasedAuthorizationFilterDefinition filterDefinition,
        AuthorizationFilterContext filterContext);

    /// <summary>
    /// Provides an opportunity for implementations to apply
    /// </summary>
    /// <param name="cmd">The <see cref="DbCommand" /> instance being prepared for execution of the authorization query.</param>
    /// <param name="authorizationContext">The <see cref="EdFiAuthorizationContext" /> instance, providing access to API client details.</param>
    void ApplyClaimsParametersToCommand(DbCommand cmd, EdFiAuthorizationContext authorizationContext);
}