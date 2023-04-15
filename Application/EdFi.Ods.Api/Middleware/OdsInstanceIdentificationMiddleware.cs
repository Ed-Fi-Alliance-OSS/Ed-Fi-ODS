// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that uses the <see cref="IContextProvider{OdsInstanceConfiguration}" /> to set the appropriate ODS context
/// for processing the current request.
/// </summary>
public class OdsInstanceIdentificationMiddleware : IMiddleware
{
    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationProvider;
    private readonly IOdsInstanceSelector _odsInstanceSelector;

    public OdsInstanceIdentificationMiddleware(
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationProvider,
        IOdsInstanceSelector odsInstanceSelector)
    {
        _odsInstanceConfigurationProvider = odsInstanceConfigurationProvider;
        _odsInstanceSelector = odsInstanceSelector;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var odsInstanceConfiguration = await _odsInstanceSelector.GetOdsInstanceAsync();

        if (odsInstanceConfiguration != null)
        {
            _odsInstanceConfigurationProvider.Set(odsInstanceConfiguration);
        }

        await next.Invoke(context);
    }
}