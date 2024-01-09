// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Startup;

public class ApiBehaviorOptionsConfigurator : IConfigureOptions<ApiBehaviorOptions>
{
    private readonly ILogContextAccessor _logContextAccessor;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly ErrorTranslator _errorTranslator;

    public ApiBehaviorOptionsConfigurator(ILogContextAccessor logContextAccessor,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        ErrorTranslator errorTranslator)
    {
        _logContextAccessor = logContextAccessor;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _errorTranslator = errorTranslator;
    }

    public void Configure(ApiBehaviorOptions options)
    {
        options.InvalidModelStateResponseFactory = actionContext =>
        {
            if (actionContext.ModelState.ValidationState == ModelValidationState.Invalid)
            {
                var problemDetails = _errorTranslator.GetProblemDetails(
                    _dataManagementResourceContextProvider.Get()?.Resource,
                    actionContext.ModelState);
                
                problemDetails.CorrelationId = (string)_logContextAccessor.GetValue(CorrelationConstants.LogContextKey);
                
                return new BadRequestObjectResult(problemDetails);
            }
            
            return null;
        };
    }
}
