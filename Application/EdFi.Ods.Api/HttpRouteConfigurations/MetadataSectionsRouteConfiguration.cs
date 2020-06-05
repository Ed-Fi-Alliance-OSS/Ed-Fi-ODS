// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.HttpRouteConfigurations
{
    public class MetadataSectionsRouteConfiguration : IRouteConfiguration, IOpenApiMetadataRouteConfiguration
    {
        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            config.Routes.MapHttpRoute(
                name: "MetadataSections",
                routeTemplate: "metadata/" + (useSchoolYear
                    ? "{schoolYearFromRoute}"
                    : string.Empty),
                defaults: new
                {
                    controller = "openapimetadata",
                    action = "getsections",
                    apiVersion = ApiVersionConstants.Ods,
                    identityVersion = ApiVersionConstants.Identity
                },
                constraints: RouteConfigurationHelper.CreateSchoolYearConstraint(useSchoolYear)
            );
        }

        public void ConfigureOpenApiMetadataRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            // no open api routes are defined
        }
    }
}
