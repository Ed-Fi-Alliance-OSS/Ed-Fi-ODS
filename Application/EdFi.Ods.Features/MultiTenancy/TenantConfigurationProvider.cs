// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Supplies <see cref="TenantConfiguration" /> from the application's configuration data.
/// </summary>
public class TenantConfigurationProvider : ITenantConfigurationProvider
{
    private readonly Lazy<Dictionary<string, TenantConfiguration>> _tenantConfigurationByIdentifier;

    public TenantConfigurationProvider(IConfiguration configuration)
    {
        _tenantConfigurationByIdentifier = new Lazy<Dictionary<string, TenantConfiguration>>(
            () =>
            {
                var tenantsSection = configuration.Get<TenantsSection>();

                var tenantConfigurationByIdentifier = tenantsSection.Tenants.ToDictionary(
                    t => t.TenantIdentifier,
                    t => new TenantConfiguration
                        {
                            TenantIdentifier = t.TenantIdentifier,
                            AdminConnectionString = t.ConnectionStrings.EdFi_Admin,
                            SecurityConnectionString = t.ConnectionStrings.EdFi_Security
                        },
                    StringComparer.OrdinalIgnoreCase);

                return tenantConfigurationByIdentifier;
            });
    }

    /// <inheritdoc cref="ITenantConfigurationProvider.GetAllConfigurations" />
    public IList<TenantConfiguration> GetAllConfigurations()
    {
        return _tenantConfigurationByIdentifier.Value.Values.ToList();
    }

    /// <inheritdoc cref="ITenantConfigurationProvider.TryGetConfiguration" />
    public bool TryGetConfiguration(string tenantIdentifier, out TenantConfiguration tenantConfiguration)
    {
        return _tenantConfigurationByIdentifier.Value.TryGetValue(tenantIdentifier, out tenantConfiguration);
    }
}
