// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Api.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string RootUrl(this HttpRequest request, ReverseProxySettings reverseProxySettings)
        {
            var uriBuilder = new UriBuilder(
                request.Scheme(reverseProxySettings),
                request.Host(reverseProxySettings),
                request.Port(reverseProxySettings),
                request.PathBase);

            return uriBuilder.Uri.AbsoluteUri.TrimEnd('/');
        }

        public static string Scheme(this HttpRequest request, ReverseProxySettings reverseProxySettings)
        {
            string scheme = request.Scheme;

            if (!reverseProxySettings.UseReverseProxyHeaders)
            {
                return scheme;
            }

            request.TryGetRequestHeader(HeaderConstants.XForwardedProto, out string proxyHeaderValue);

            // Pass through for any value provided, null means header wasn't found so default to request
            if (proxyHeaderValue != null)
            {
                scheme = proxyHeaderValue;
            }

            // The x-forwarded-proto header can contain a single originating protocol or, in some 
            // cases, multiple protocols. See ODS-5481 for more information. We care about the
            // _first_ protocol listed.
            if (scheme == null) { return "http"; }

            return scheme.Split(',')[0];
        }

        public static string Host(this HttpRequest request, ReverseProxySettings reverseProxySettings)
        {
            // Use actual request host when not configured for use behind a reverse proxy
            if (!reverseProxySettings.UseReverseProxyHeaders)
            {
                return request.Host.Host;
            }

            // Use override value if available
            if (!string.IsNullOrWhiteSpace(reverseProxySettings.OverrideForForwardingHostServer))
            {
                return reverseProxySettings.OverrideForForwardingHostServer;
            }

            // Try to extract a X-Forwarded-Host value
            if (request.TryGetRequestHeader(HeaderConstants.XForwardedHost, out string proxyHeaderValue) &&
             !string.IsNullOrWhiteSpace(proxyHeaderValue))
            {
                // Return the forwarding host
                return proxyHeaderValue;
            }

            return request.Host.Host;
        }

        public static int Port(this HttpRequest request, ReverseProxySettings reverseProxySettings)
        {
            // User actual request host when not configured for use behind a reverse proxy
            if (!reverseProxySettings.UseReverseProxyHeaders)
            {
                return request.Host.Port ?? getDefaultPort();
            }

            // Use override value if available
            if (reverseProxySettings.OverrideForForwardingHostPort.HasValue)
            {
                return reverseProxySettings.OverrideForForwardingHostPort.Value;
            }

            // Try to extract a X-Forwarded-Port value
            if (request.TryGetRequestHeader(HeaderConstants.XForwardedPort, out string proxyHeaderValue) &&
                int.TryParse(proxyHeaderValue, out int port))
            {
                // Return the forwarding port
                return port;
            }

            // Try to send the requested port
            if (request.Host.Port.HasValue)
            {
                return request.Host.Port.Value;
            }

            return getDefaultPort();             

            int getDefaultPort()
            {
                return Scheme(request, reverseProxySettings) == "https" ? 443 : 80;
            }
        }

        public static string VirtualPath(this HttpRequest request)
        {
            return request.VirtualPath().EnsureSuffixApplied("/");
        }

        public static bool TryGetRequestHeader(this HttpRequest request, string headerName, out string value)
        {
            value = null;

            if (request == null || !request.Headers.TryGetValue(headerName, out StringValues values))
            {
                return false;
            }

            value = values.FirstOrDefault();

            return !string.IsNullOrEmpty(value);
        }
    }
}
