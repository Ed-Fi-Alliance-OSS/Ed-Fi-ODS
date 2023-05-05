// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Database;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;
using EdFi.Security.DataAccess.Providers;
using log4net;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Implements a database connection provider that returns the Security database connection string uisng the tenant
/// configuration currently in context.
/// </summary>
public class MultiTenantSecurityDatabaseConnectionStringProvider : ISecurityDatabaseConnectionStringProvider
{
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    private readonly ILog _logger = LogManager.GetLogger(typeof(MultiTenantSecurityDatabaseConnectionStringProvider));

    public MultiTenantSecurityDatabaseConnectionStringProvider(
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    /// <inheritdoc cref="IDatabaseConnectionStringProvider.GetConnectionString" />
    public string GetConnectionString()
    {
        var tenantConfiguration = _tenantConfigurationContextProvider.Get();

        if (tenantConfiguration == null)
        {
            throw new InvalidOperationException("The current tenant configuration has not been initialized.");
        }

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug($"Obtaining security database connection string for tenant '{tenantConfiguration.TenantIdentifier}'...");
        }

        return tenantConfiguration?.SecurityConnectionString;
    }
}
