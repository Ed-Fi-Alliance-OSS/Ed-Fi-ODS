// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Redirects HTTP requests to HTTPS. Unlike the built-in HTTPS redirection middleware, the redirect does not depend on
/// the server knowing its HTTPS port, and it uses the same host override as the URLs that the API returns.
/// </summary>
public class HttpToHttpsRedirectMiddleware
{
    public static readonly PathString HealthCheckPath = new("/health");

    private const int DefaultHttpsPort = 443;

    private readonly RequestDelegate _next;
    private readonly ReverseProxySettings _reverseProxySettings;
    private readonly int? _httpsPort;

    public HttpToHttpsRedirectMiddleware(RequestDelegate next, ApiSettings apiSettings)
    {
        _next = next;
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

        context.Response.StatusCode = StatusCodes.Status307TemporaryRedirect;
        context.Response.Headers.Location = UriHelper.BuildAbsolute(
            "https", hostString, request.PathBase, request.Path, request.QueryString);

        return Task.CompletedTask;
    }
}
