// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Services.Metadata;

namespace EdFi.Ods.Api.Startup.HttpRouteConfigurations
{
    public class TokenInfoRouteConfiguration : IRouteConfiguration, IOpenApiMetadataRouteConfiguration
    {
        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            config.Routes.MapHttpRoute(
                name: "TokenInfo",
                routeTemplate: "oauth/token_info",
                defaults:
                new
                {
                    controller = "tokeninfo",
                }
            );
        }

        public void ConfigureOpenApiMetadataRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            // no route required
        }
    }
}
