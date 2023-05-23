// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Defines a method for obtaining a map of tenant configurations keyed by a case-insensitive match on the tenant's identifier.
/// </summary>
/// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-tenants".</remarks>
// [Intercept("cache-tenants")]
public interface ITenantConfigurationMapProvider
{
    /// <summary>
    /// Gets a map of tenant configurations by tenant identifier.
    /// </summary>
    /// <returns>A map of tenant configurations by tenant identifier.</returns>
    IDictionary<string, TenantConfiguration> GetMap();
}
