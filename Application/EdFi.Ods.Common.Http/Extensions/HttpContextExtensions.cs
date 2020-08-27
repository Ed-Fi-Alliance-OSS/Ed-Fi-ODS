// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;
using System.Web;

namespace EdFi.Ods.Common.Http.Extensions
{
    public static class HttpContextExtensions
    {
        public static string UseReverseProxyHeadersConfigKey = "UseReverseProxyHeaders";
        private static readonly Lazy<bool> _useProxyHeaders = new Lazy<bool>(SetProxyHeaderConfigValue);

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

        private static bool SetProxyHeaderConfigValue()
        {
            bool tempConfigValue;
            bool.TryParse(ConfigurationManager.AppSettings[UseReverseProxyHeadersConfigKey], out tempConfigValue);
            return tempConfigValue;
        }
    }
}
