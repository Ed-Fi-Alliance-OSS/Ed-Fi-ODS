// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that inspects the response for known errors that are not yet in Problem Details format and prepares
/// the responses, as necessary.
/// </summary>
public class ProblemDetailsErrorEnrichmentMiddleware : IMiddleware
{
    private readonly ILogContextAccessor _logContextAccessor;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ProblemDetailsErrorEnrichmentMiddleware));

    public ProblemDetailsErrorEnrichmentMiddleware(
        ILogContextAccessor logContextAccessor)
    {
        _logContextAccessor = logContextAccessor;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);

        // If the response hasn't started, this indicates it's not a Problem Details response body yet
        if (context.Response is { StatusCode: 404, HasStarted: false })
        {
            var problemDetails = new NotFoundException(
                "scenario64.",
                $"Path '{context.Request.Path}' does not exist. Check the resource name and try again.");

            string correlationId = _logContextAccessor.GetCorrelationId();
            problemDetails.CorrelationId = correlationId;

            await context.Response.WriteProblemDetailsAsync(problemDetails);

            _logger.Error(problemDetails.Message);

            return;
        }

        // If the response hasn't started, this indicates it's not a Problem Details response body yet
        if (context.Response is { StatusCode: 405, HasStarted: false })
        {
            var problemDetails = new MethodNotAllowedException(
                $"scenario51.")
            {
                CorrelationId = _logContextAccessor.GetCorrelationId()
            };

            await context.Response.WriteProblemDetailsAsync(problemDetails);

            _logger.Error(problemDetails.Message);
        }
    }
}
