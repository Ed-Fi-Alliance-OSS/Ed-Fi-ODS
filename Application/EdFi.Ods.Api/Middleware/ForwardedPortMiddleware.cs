// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace EdFi.Ods.Api.Middleware;

/// <summary>
/// Captures the X-Forwarded-Port header, which the ASP.NET Core forwarded headers middleware does not process, when
/// the request comes from a trusted proxy (as defined by the configured <see cref="ForwardedHeadersOptions"/>).
/// </summary>
/// <remarks>
/// Must run before the forwarded headers middleware, which replaces the connection's remote IP address with the
/// client's address.
/// </remarks>
public class ForwardedPortMiddleware
{
    public const string ForwardedPortItemKey = "EdFi.Ods.Api.ForwardedPort";

    private readonly RequestDelegate _next;
    private readonly ForwardedHeadersOptions _options;

    public ForwardedPortMiddleware(RequestDelegate next, IOptions<ForwardedHeadersOptions> options)
    {
        _next = next;
        _options = options.Value;
    }

    public Task InvokeAsync(HttpContext context)
    {
        if (IsTrustedProxy(context.Connection.RemoteIpAddress)
            && context.Request.TryGetRequestHeader(HeaderConstants.XForwardedPort, out string forwardedPort)
            && int.TryParse(forwardedPort, out int port))
        {
            context.Items[ForwardedPortItemKey] = port;
        }

        return _next(context);
    }

    private bool IsTrustedProxy(IPAddress remoteIpAddress)
    {
        if (_options.KnownProxies.Count == 0 && _options.KnownIPNetworks.Count == 0)
        {
            return true;
        }

        if (remoteIpAddress is null)
        {
            return false;
        }

        if (remoteIpAddress.IsIPv4MappedToIPv6)
        {
            remoteIpAddress = remoteIpAddress.MapToIPv4();
        }

        return _options.KnownProxies.Any(p => p.Equals(remoteIpAddress) || p.Equals(remoteIpAddress.MapToIPv6()))
            || _options.KnownIPNetworks.Any(n => n.Contains(remoteIpAddress));
    }
}
