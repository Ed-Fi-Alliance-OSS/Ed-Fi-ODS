// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Defines methods for obtaining tenant configurations.
/// </summary>
/// <remarks>Implementations of this interface must be configured with a named <see cref="IInterceptor" /> registration of "cache-tenants".</remarks>
[Intercept("cache-tenants")]
public interface ITenantConfigurationProvider
{
    /// <summary>
    /// Gets all tenant configurations.
    /// </summary>
    /// <returns>A list of tenant configurations.</returns>
    IList<TenantConfiguration> GetAllConfigurations();
    
    /// <summary>
    /// Attempts to load the tenant configuration for the supplied tenant identifier.
    /// </summary>
    /// <param name="tenantIdentifier">The identifier for the tenant.</param>
    /// <param name="tenantConfiguration">The tenant's configuration, if found.</param>
    /// <returns><b>true</b> if the tenant was found; otherwise <b>false</b>.</returns>
    bool TryGetConfiguration(string tenantIdentifier, out TenantConfiguration tenantConfiguration);
}