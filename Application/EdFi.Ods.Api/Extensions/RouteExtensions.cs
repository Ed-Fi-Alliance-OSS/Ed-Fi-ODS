// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Web.Http.Routing;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Api.Extensions
{
    public static class RouteExtensions
    {
        public static void SetDataTokenRouteName(this IHttpRoute route, string name) => route.SetDataTokenValue("Name", name);

        public static string GetDataTokenRouteName(this IHttpRoute route) => route.GetDataTokenValue<string>("Name");

        public static bool IsOpenApiMetadataRoute(this IHttpRoute route) => route.GetDataTokenRouteName()
                                                                                ?.StartsWith(EdFiConventions.OpenApiMetadataRouteNamePrefix) ?? false;

        private static void SetDataTokenValue(this IHttpRoute route, string key, string value) => route.DataTokens[key] = value;

        private static TValue GetDataTokenValue<TValue>(this IHttpRoute route, string key)
        {
            object value;

            if (route.DataTokens != null && route.DataTokens.TryGetValue(key, out value))
            {
                return (TValue) value;
            }

            return default(TValue);
        }
    }
}
