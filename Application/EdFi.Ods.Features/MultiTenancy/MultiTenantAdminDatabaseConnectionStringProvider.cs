// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Database;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Implements an <see cref="IAdminDatabaseConnectionStringProvider" /> that returns the Admin database connection string
/// from the tenant configuration currently in context.
/// </summary>
public class MultiTenantAdminDatabaseConnectionStringProvider : IAdminDatabaseConnectionStringProvider
{
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    public MultiTenantAdminDatabaseConnectionStringProvider(
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

        return tenantConfiguration.AdminConnectionString;
    }
}
