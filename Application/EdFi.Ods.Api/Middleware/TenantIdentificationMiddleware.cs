// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that extracts the tenant identifier from the route values and sets the tenant's configuration into context.
/// </summary>
public class TenantIdentificationMiddleware : IMiddleware
{
    private readonly ITenantConfigurationMapProvider _tenantConfigurationMapProvider;
    private readonly IContextProvider<TenantConfiguration> _tenantConfigurationContextProvider;
    private readonly ILogContextAccessor _logContextAccessor;
    private readonly ILog _logger = LogManager.GetLogger(typeof(TenantIdentificationMiddleware));

    public TenantIdentificationMiddleware(ILogContextAccessor logContextAccessor,
        ITenantConfigurationMapProvider tenantConfigurationMapProvider,
        IContextProvider<TenantConfiguration> tenantConfigurationContextProvider)
    {
        _logContextAccessor = logContextAccessor;
        _tenantConfigurationMapProvider = tenantConfigurationMapProvider;
        _tenantConfigurationContextProvider = tenantConfigurationContextProvider;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.RouteValues.TryGetValue("tenantIdentifier", out var tenantIdentifierAsObject) && tenantIdentifierAsObject != null)
        {
            if (_tenantConfigurationMapProvider.GetMap().TryGetValue((string) tenantIdentifierAsObject, out var tenantConfiguration))
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"Setting tenant '{(string) tenantIdentifierAsObject}' into context...");
                }

                _tenantConfigurationContextProvider.Set(tenantConfiguration);
            }
            else
            {
                var tenantIdentifierPart = "";
                
                if (tenantIdentifierAsObject is string tenantIdentifierString)
                {
                    tenantIdentifierPart = $"'{tenantIdentifierString}' ";
                }
                
                var problemDetails = new NotFoundException(
                    NotFoundException.DefaultDetail,
                    $"The selected tenant {tenantIdentifierPart}does not exist. Check the tenant name and try again.");

                string correlationId = _logContextAccessor.GetCorrelationId();
                problemDetails.CorrelationId = correlationId;

                await context.Response.WriteProblemDetailsAsync(problemDetails);

                _logger.Error(problemDetails.Message);

                return;
            }
        }

        await next.Invoke(context);
    }
}
