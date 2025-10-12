// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Security.DataAccess.Providers;

namespace EdFi.Ods.Api.IntegrationTestHarness.Migrations;

/// <summary>
/// Implements an <see cref="ISecurityDatabaseConnectionStringCatalog" /> that returns a connection string
/// for each of the tenant-specific EdFi_Security databases in a multitenant deployment.
/// </summary>
public class MultiTenantSecurityDatabaseConnectionStringCatalog : ISecurityDatabaseConnectionStringCatalog
{
    private readonly ISecurityDatabaseConnectionStringProvider _securityConnectionStringProvider;
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;
    private readonly ITenantConfigurationMapProvider _tenantConfigurationMapProvider;

    public MultiTenantSecurityDatabaseConnectionStringCatalog(
        ISecurityDatabaseConnectionStringProvider securityConnectionStringProvider,
        ITenantConfigurationMapProvider tenantConfigurationMapProvider,
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _securityConnectionStringProvider = securityConnectionStringProvider;
        _tenantConfigurationMapProvider = tenantConfigurationMapProvider;
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    /// <summary>
    /// Gets a connection string for each of the tenant-specific EdFi_Security databases in a multitenant deployment.
    /// </summary>
    /// <returns></returns>
    public string[] GetConnectionStrings()
    {
        List<string> connectionStrings = new();

        foreach (var tenantConfigurationMap in _tenantConfigurationMapProvider.GetMap())
        {
            _tenantConfigurationContextProvider.Set(tenantConfigurationMap.Value);
            connectionStrings.Add(_securityConnectionStringProvider.GetConnectionString());
            _tenantConfigurationContextProvider.Set(null);
        }

        return connectionStrings.ToArray();
    }
}
