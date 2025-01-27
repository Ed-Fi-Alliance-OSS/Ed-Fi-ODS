// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Defines a method for obtaining a map of tenant configurations keyed by a case-insensitive match on the tenant's identifier.
/// </summary>
public interface ITenantConfigurationMapProvider
{
    /// <summary>
    /// Gets a map of tenant configurations keyed by tenant identifier.
    /// </summary>
    /// <returns>A map of tenant configurations keyed by tenant identifier.</returns>
    IDictionary<string, TenantConfiguration> GetMap();
}
