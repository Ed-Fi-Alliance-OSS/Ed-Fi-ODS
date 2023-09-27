// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Logging;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Implements middleware that inspects the request and captures a correlation identifier supplied in an HTTP header or query
/// string parameter (in that order of precedence).
/// </summary>
public class RequestCorrelationMiddleware : IMiddleware
{
    private readonly ILogContextAccessor _logContextAccessor;

    public RequestCorrelationMiddleware(ILogContextAccessor logContextAccessor)
    {
        _logContextAccessor = logContextAccessor;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Capture correlation from the header, if present
        if (context.Request.Headers.TryGetValue("correlation-id", out var headerValues))
        {
            _logContextAccessor.SetValue("CorrelationId", headerValues[0]);
        }
        else
        {
            // Capture correlation from the query string, if present
            if (context.Request.Query.TryGetValue("correlationId", out var queryStringValues))
            {
                _logContextAccessor.SetValue("CorrelationId",  queryStringValues[0]);
            }
        }

        await next(context);
    }
}