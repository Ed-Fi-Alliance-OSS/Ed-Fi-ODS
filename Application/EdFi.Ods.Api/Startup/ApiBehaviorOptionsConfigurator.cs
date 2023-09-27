// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Startup;

public class ApiBehaviorOptionsConfigurator : IConfigureOptions<ApiBehaviorOptions>
{
    private readonly ILogContextAccessor _logContextAccessor;

    public ApiBehaviorOptionsConfigurator(ILogContextAccessor logContextAccessor)
    {
        _logContextAccessor = logContextAccessor;
    }

    public void Configure(ApiBehaviorOptions options)
    {
        options.InvalidModelStateResponseFactory = actionContext => 
            new BadRequestObjectResult(
                ErrorTranslator.GetErrorMessage(actionContext.ModelState, 
                (string)_logContextAccessor.GetValue("CorrelationId")));
    }
}
