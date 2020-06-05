// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EdFi.Ods.Api.Extensions
{
    public static class RequestExtensions
    {
        private const string XForwardedProto = "X-Forwarded-Proto";
        private const string XForwardedHost = "X-Forwarded-Host";
        private const string XForwardedPort = "X-Forwarded-Port";

        public static string RootUrl(this HttpRequestMessage request, bool useProxyHeaders = false)
        {
            var uriBuilder = new UriBuilder(
                request.Scheme(useProxyHeaders),
                request.Host(useProxyHeaders),
                request.Port(useProxyHeaders),
                request.VirtualPath());

            return uriBuilder.Uri.AbsoluteUri.TrimEnd('/');
        }

        /// <summary>
        /// Returns the scheme associated with the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useProxyHeaders"></param>
        /// <returns></returns>
        public static string Scheme(this HttpRequestMessage request, bool useProxyHeaders = false)
        {
            string scheme = request.RequestUri.Scheme;

            if (!useProxyHeaders)
            {
                return scheme;
            }

            string proxyHeaderValue = GetHeaderValue(request, XForwardedProto);

            // Pass through for any value provided, null means header wasn't found so default to request
            if (proxyHeaderValue != null)
            {
                scheme = proxyHeaderValue;
            }

            return scheme;
        }

        /// <summary>
        /// Returns the host and port associated with the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useProxyHeaders"></param>
        /// <returns></returns>
        public static string Host(this HttpRequestMessage request, bool useProxyHeaders = false)
        {
            string host = request.RequestUri.Host;

            if (!useProxyHeaders)
            {
                return host;
            }

            string proxyHeaderValue = GetHeaderValue(request, XForwardedHost);

            // Pass through for any value provided, null means header wasn't found so default to request
            if (proxyHeaderValue != null)
            {
                host = proxyHeaderValue;
            }

            return host;
        }

        /// <summary>
        /// Returns the port associated with the request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useProxyHeaders"></param>
        /// <returns></returns>
        public static int Port(this HttpRequestMessage request, bool useProxyHeaders = false)
        {
            if (!useProxyHeaders)
            {
                return request.RequestUri.Port;
            }

            int port;

            if (!int.TryParse(GetHeaderValue(request, XForwardedPort), out port))
            {
                port = request.RequestUri.Port;
            }

            return port;
        }

        /// <summary>
        /// Returns the virtual path associated with the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string VirtualPath(this HttpRequestMessage request)
        {
            var virtualPathRoot = request.GetRequestContext()
                .VirtualPathRoot;

            return virtualPathRoot.EndsWith("/")
                ? virtualPathRoot
                : virtualPathRoot + "/";
        }

        /// <summary>
        /// Retrieves the header value from the request for a specific key.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headerName"></param>
        /// <returns></returns>
        public static string GetHeaderValue(HttpRequestMessage request, string headerName)
        {
            return request.Headers.TryGetValues(headerName, out IEnumerable<string> values)
                ? values.FirstOrDefault()
                : null;
        }
    }
}
