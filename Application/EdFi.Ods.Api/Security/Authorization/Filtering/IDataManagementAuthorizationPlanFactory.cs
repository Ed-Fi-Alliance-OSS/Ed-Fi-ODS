// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Filtering;

/// <summary>
/// Defines methods for performing single-item and filter-based authorization appropriate to the claims, resource, action and possibly the entity instance supplied in the <see cref="DataManagementRequestContext"/>.
/// </summary>
public interface IDataManagementAuthorizationPlanFactory
{
    /// <summary>
    /// Authorizes a multiple-item read request using the specified action for the resource identified in the <see cref="DataManagementRequestContext"/> (and supplemented 
    /// with other pertinent information available in the call context).
    /// </summary>
    /// <param name="actionUri">The URI representation of the action being performed by the current request.</param>
    /// <returns>A plan containing relevant context for authorization and the filters to be applied to the query.</returns>
    DataManagementAuthorizationPlan CreateAuthorizationPlan(string actionUri);

    /// <summary>
    /// Authorizes a single-item request using the specified action, entity instance and authorization phase for the resource
    /// identified in the <see cref="DataManagementRequestContext"/> (and supplemented with other pertinent information available
    /// in the call context).
    /// </summary>
    /// <param name="actionUri">The URI representation of the action being performed by the current request.</param>
    /// <param name="entity">The entity instance containing the data to be authorized.</param>
    /// <param name="authorizationPhase">An indication of whether this entity represents the proposed (new) or existing data.</param>
    /// <returns>A plan containing relevant context for authorization and the filters to be applied to the query.</returns>
    DataManagementAuthorizationPlan CreateAuthorizationPlan(
        string actionUri,
        object entity,
        AuthorizationPhase authorizationPhase);
    
    /// <summary>
    /// Authorizes the inclusion of the specified resource (e.g. such as while processing a composite response) and action
    /// (supplemented with other pertinent information available in the call context).
    /// </summary>
    /// <param name="resource">The <see cref="Resource" /> on which authorization is being performed. If null, the data management contextual resource will be used.</param>
    /// <param name="actionUri">The URI representation of the action being performed by the current request.</param>
    /// <returns>A plan containing relevant context for authorization and the filters to be applied to the query.</returns>
    /// <remarks>This overload was added specifically to provide for authorization of "child" resources of a composite definition
    /// while processing the queries for obtaining the data for the composite response. In this case, the contextual resource is
    /// not relevant as this will be driven by the composite definition.
    /// </remarks>
    DataManagementAuthorizationPlan CreateAuthorizationPlan(Resource resource, string actionUri);
}
