// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Attributes;

namespace EdFi.Ods.Api.Conventions;

/// <summary>
/// Defines a method for obtaining the root route template prefix for controllers using the specified <see cref="RouteContextType" />.
/// </summary>
public interface IRouteRootTemplateProvider
{
    /// <summary>
    /// Gets the root route template prefix for controllers using the specified <see cref="RouteContextType"/>.
    /// </summary>
    /// <param name="context">The type of route context used by the controller.</param>
    /// <returns>The root template prefix to be applied to the route, if applicable; otherwise <b>null</b>.</returns>
    string GetRouteRootTemplate(RouteContextType context);
}
