// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using System.Linq;
#if NETFRAMEWORK
using System;
using System.Web;

namespace EdFi.Ods.Admin.Extensions
{
    public static class HttpContextExtensions
    {
        public static string UseReverseProxyHeadersConfigKey = "UseReverseProxyHeaders";
        private static readonly Lazy<bool> _useProxyHeaders = new Lazy<bool>(SetProxyHeaderConfigValue);

        private const string XForwardedProto = "X-Forwarded-Proto";
        private const string XForwardedHost = "X-Forwarded-Host";
        private const string XForwardedPort = "X-Forwarded-Port";

        public static string ToAbsolutePath(this string relativePath, string hashFragment = null)
        {
            var request = HttpContext.Current.Request;
            string path;
            string query;

            if (relativePath == "~")
            {
                path = request.ApplicationPath.Trim('/');
                query = string.Empty;
            }
            else
            {
                var pathAndQuery = relativePath.Split(
                    new[]
                    {
                        '?'
                    },
                    2);

                path = pathAndQuery[0];
                query = pathAndQuery[1];
            }

            var absolutePathBuilder = new UriBuilder
                                      {
                                          Scheme = request.Scheme(_useProxyHeaders.Value), Host = request.Host(_useProxyHeaders.Value),
                                          Port = request.Port(_useProxyHeaders.Value), Path = path, Query = query, Fragment =
                                              string.IsNullOrWhiteSpace(hashFragment)
                                                  ? string.Empty
                                                  : hashFragment
                                      };

            return absolutePathBuilder.Uri.ToString()
                                      .TrimEnd('/');
        }

        public static string Scheme(this HttpRequest request, bool useProxyHeaders = false)
        {
            string scheme = request.Url.Scheme;

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

        public static int Port(this HttpRequest request, bool useProxyHeaders = false)
        {
            if (!useProxyHeaders)
            {
                return request.Url.Port;
            }

            int port;

            if (!int.TryParse(GetHeaderValue(request, XForwardedPort), out port))
            {
                port = request.Url.Port;
            }

            return port;
        }

        private static string GetHeaderValue(HttpRequest request, string headerName)
        {
            var values = request.Headers.GetValues(headerName);

            return values != null && values.Length > 0
                ? values.FirstOrDefault()
                : null;
        }

        public static string Host(this HttpRequest request, bool useProxyHeaders = false)
        {
            string host = request.Url.Host;

            if (!useProxyHeaders)
            {
                return host;
            }

            string proxyHeaderValue = GetHeaderValue(request, XForwardedHost);

            if (proxyHeaderValue != null)
            {
                host = proxyHeaderValue;
            }

            return host;
        }

        private static bool SetProxyHeaderConfigValue()
        {
            bool tempConfigValue;
            bool.TryParse(ConfigurationManager.AppSettings[UseReverseProxyHeadersConfigKey], out tempConfigValue);
            return tempConfigValue;
        }
    }
}
#endif
