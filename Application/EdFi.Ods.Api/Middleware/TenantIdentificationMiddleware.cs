// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that extracts the tenant identifier from the route values and sets the tenant's configuration into context.
/// </summary>
public class TenantIdentificationMiddleware : IMiddleware
{
    private readonly ITenantConfigurationProvider _tenantConfigurationProvider;
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;

    public TenantIdentificationMiddleware(
        ITenantConfigurationProvider tenantConfigurationProvider,
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _tenantConfigurationProvider = tenantConfigurationProvider;
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.RouteValues.TryGetValue("tenantIdentifier", out var tenantIdentifierAsObject))
        {
            if (_tenantConfigurationProvider.TryGetConfiguration((string) tenantIdentifierAsObject, out var tenantConfiguration))
            {
                _tenantConfigurationContextProvider.Set(tenantConfiguration);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                return;
            }
        }

        await next.Invoke(context);
    }
}
