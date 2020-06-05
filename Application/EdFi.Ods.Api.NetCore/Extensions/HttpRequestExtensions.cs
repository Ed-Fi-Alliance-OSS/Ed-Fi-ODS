// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Api.NetCore.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string RootUrl(this HttpRequest request, bool useProxyHeaders = false)
        {
            var uriBuilder = new UriBuilder(
                request.Scheme(useProxyHeaders),
                request.Host(useProxyHeaders),
                request.Port(useProxyHeaders),
                request.PathBase);

            return uriBuilder.Uri.AbsoluteUri.TrimEnd('/');
        }

        public static string Scheme(this HttpRequest request, bool useProxyHeaders = false)
        {
            string scheme = request.Scheme;

            if (!useProxyHeaders)
            {
                return scheme;
            }

            request.TryGetRequestHeader(HeaderConstants.XForwardedProto, out string proxyHeaderValue);

            // Pass through for any value provided, null means header wasn't found so default to request
            if (proxyHeaderValue != null)
            {
                scheme = proxyHeaderValue;
            }

            return scheme;
        }

        public static string Host(this HttpRequest request, bool useProxyHeaders = false)
        {
            string host = request.Host.Host;

            if (!useProxyHeaders)
            {
                return host;
            }

            request.TryGetRequestHeader(HeaderConstants.XForwardedHost, out string proxyHeaderValue);

            // Pass through for any value provided, null means header wasn't found so default to request
            if (proxyHeaderValue != null)
            {
                host = proxyHeaderValue;
            }

            return host;
        }

        public static int Port(this HttpRequest request, bool useProxyHeaders = false)
        {
            if (!useProxyHeaders)
            {
                return request.Host.Port ?? 80;
            }

            request.TryGetRequestHeader(HeaderConstants.XForwardedPort, out string proxyHeaderValue);

            return !int.TryParse(proxyHeaderValue, out int port)
                ? request.Host.Port ?? 80
                : port;
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
