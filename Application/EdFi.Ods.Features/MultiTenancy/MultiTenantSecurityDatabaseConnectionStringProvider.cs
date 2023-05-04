// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Database;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Context;
using EdFi.Security.DataAccess.Providers;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Implements a database connection provider that returns the Security database connection string uisng the tenant
/// configuration currently in context.
/// </summary>
public class MultiTenantSecurityDatabaseConnectionStringProvider : ISecurityDatabaseConnectionStringProvider
{
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    public MultiTenantSecurityDatabaseConnectionStringProvider(
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    /// <inheritdoc cref="IDatabaseConnectionStringProvider.GetConnectionString" />
    public string GetConnectionString()
    {
        return _tenantConfigurationContextProvider.Get()?.SecurityConnectionString;
    }
}
