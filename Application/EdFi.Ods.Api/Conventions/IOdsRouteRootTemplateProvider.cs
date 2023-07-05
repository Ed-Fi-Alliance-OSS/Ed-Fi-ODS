// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Conventions;

/// <summary>
/// Defines a method for obtaining the root route template prefix for controllers using ODS-based routes.
/// </summary>
public interface IOdsRouteRootTemplateProvider
{
    /// <summary>
    /// Gets a value indicating whether the route route has an ODS context route template.
    /// </summary>
    bool HasOdsContextRouteTemplate { get; }

    /// <summary>
    /// Gets the root route template prefix to be applied to controllers.
    /// </summary>
    /// <returns>The root template prefix to be applied to the route, if applicable; otherwise <b>null</b>.</returns>
    string GetOdsRouteRootTemplate();
}
