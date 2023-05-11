// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Routing;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Defines a method for selecting the appropriate <see cref="OdsInstanceConfiguration" /> for processing the current request.
/// </summary>
public interface IOdsInstanceSelector
{
    /// <summary>
    /// Selects the appropriate ODS instance for processing the current request.
    /// </summary>
    /// <returns>The OdsInstanceConfiguration for the selected ODS.</returns>
    Task<OdsInstanceConfiguration> GetOdsInstanceAsync(RouteValueDictionary routeValues);
}
