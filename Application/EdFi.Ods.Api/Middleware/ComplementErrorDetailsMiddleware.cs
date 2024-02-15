// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Logging;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that inspects the response and complements missing response details.
/// </summary>
public class ComplementErrorDetailsMiddleware : IMiddleware
{
    private readonly ILogContextAccessor _logContextAccessor;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ComplementErrorDetailsMiddleware));

    public ComplementErrorDetailsMiddleware(
        ILogContextAccessor logContextAccessor)
    {
        _logContextAccessor = logContextAccessor;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);

        if (context.Response is { StatusCode: 404, HasStarted: false })
        {
            var problemDetails = new NotFoundException(
                NotFoundException.DefaultDetail,
                $"Path '{context.Request.Path}' does not exist. Check the resource name and try again.");

            string correlationId = (string)_logContextAccessor.GetValue(CorrelationConstants.LogContextKey);
            problemDetails.CorrelationId = correlationId;

            await context.Response.WriteProblemDetailsAsync(problemDetails);

            _logger.Error(problemDetails.Message);
        }

        if (context.Response is { StatusCode: 405, HasStarted: false })
        {
            var problemDetails = context.Request.Method == "POST" ? 
                new MethodNotAllowedException(MethodNotAllowedException.DefaultPostDetail) :
                new MethodNotAllowedException();

            string correlationId = (string)_logContextAccessor.GetValue(CorrelationConstants.LogContextKey);
            problemDetails.CorrelationId = correlationId;

            await context.Response.WriteProblemDetailsAsync(problemDetails);

            _logger.Error(problemDetails.Message);
        }
    }
}
