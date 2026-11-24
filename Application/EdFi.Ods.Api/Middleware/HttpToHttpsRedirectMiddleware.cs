// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Redirects HTTP GET and HEAD requests to HTTPS, and rejects other HTTP requests with a 400 Bad Request, because
/// redirecting them would make clients resend their data (including any credentials) without noticing. Unlike the built-in HTTPS redirection middleware, the redirect does not depend on
/// the server knowing its HTTPS port, and it uses the same host override as the URLs that the API returns.
/// </summary>
public class HttpToHttpsRedirectMiddleware
{
    public static readonly PathString HealthCheckPath = new("/health");

    private const int DefaultHttpsPort = 443;

    private readonly RequestDelegate _next;
    private readonly ILogContextAccessor _logContextAccessor;
    private readonly ReverseProxySettings _reverseProxySettings;
    private readonly int? _httpsPort;

    public HttpToHttpsRedirectMiddleware(RequestDelegate next, ApiSettings apiSettings, ILogContextAccessor logContextAccessor)
    {
        _next = next;
        _logContextAccessor = logContextAccessor;
        _reverseProxySettings = apiSettings.GetReverseProxySettings();

        // The port of the request itself (or X-Forwarded-Port) is the HTTP port, so it is not used for the redirect
        _httpsPort = apiSettings.HttpsRedirectionPort
            ?? (_reverseProxySettings.UseReverseProxyHeaders ? _reverseProxySettings.OverrideForForwardingHostPort : null);
    }

    public Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;

        // Health probes usually call the server directly over HTTP
        if (request.IsHttps || request.Path.Equals(HealthCheckPath, StringComparison.OrdinalIgnoreCase))
        {
            return _next(context);
        }

        string host = request.Host(_reverseProxySettings);

        var hostString = _httpsPort is null or DefaultHttpsPort
            ? new HostString(host)
            : new HostString(host, _httpsPort.Value);

        string httpsUrl = UriHelper.BuildAbsolute("https", hostString, request.PathBase, request.Path, request.QueryString);

        if (!HttpMethods.IsGet(request.Method) && !HttpMethods.IsHead(request.Method))
        {
            return context.Response.WriteProblemDetailsAsync(
                new BadRequestException($"HTTPS is required. Send the request to '{httpsUrl}'.")
                {
                    CorrelationId = _logContextAccessor.GetCorrelationId()
                });
        }

        context.Response.StatusCode = StatusCodes.Status307TemporaryRedirect;
        context.Response.Headers.Location = httpsUrl;

        return Task.CompletedTask;
    }
}
