// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Adds security headers to every response, so that they are present whichever server hosts the API (Kestrel or IIS).
/// </summary>
public class SecurityHeadersMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityHeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context)
    {
        // Set the headers when the response starts, so that they survive a cleared response (e.g. an error page)
        context.Response.OnStarting(AddSecurityHeaders, context.Response);

        return _next(context);
    }

    private static Task AddSecurityHeaders(object state)
    {
        var response = (HttpResponse) state;

        response.Headers[HeaderNames.XContentTypeOptions] = "nosniff";
        response.Headers[HeaderNames.XFrameOptions] = "DENY";

        return Task.CompletedTask;
    }
}
