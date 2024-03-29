// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that uses the <see cref="IContextProvider{OdsInstanceConfiguration}" /> to set the appropriate ODS context
/// for processing the current request.
/// </summary>
public class OdsInstanceIdentificationMiddleware : IMiddleware
{
    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;
    private readonly IOdsInstanceSelector _odsInstanceSelector;
    private readonly ILogContextAccessor _logContextAccessor;

    private readonly ILog _logger = LogManager.GetLogger(typeof(OdsInstanceIdentificationMiddleware));

    public OdsInstanceIdentificationMiddleware(
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IOdsInstanceSelector odsInstanceSelector,
        ILogContextAccessor logContextAccessor)
    {
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _odsInstanceSelector = odsInstanceSelector;
        _logContextAccessor = logContextAccessor;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            var odsInstanceConfiguration = await _odsInstanceSelector.GetOdsInstanceAsync(context.Request.RouteValues);

            if (odsInstanceConfiguration != null)
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"Setting ODS instance '{odsInstanceConfiguration.OdsInstanceId}' (with hash id '{odsInstanceConfiguration.OdsInstanceHashId}') into context...");
                }

                _odsInstanceConfigurationContextProvider.Set(odsInstanceConfiguration);
            }

            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            _logger.Error(ex.Message);

            string correlationId = _logContextAccessor.GetCorrelationId();
            ex.CorrelationId = correlationId;

            await context.Response.WriteProblemDetailsAsync(ex);
        }
    }
}
