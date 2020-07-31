// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Startup.HttpRouteConfigurations
{
    public class ProfilesRouteConfiguration : IRouteConfiguration, IOpenApiMetadataRouteConfiguration
    {
        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
           // no other routes are configured.
        }

        public void ConfigureOpenApiMetadataRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            var schoolYearConstraint = RouteConfigurationHelper.CreateSchoolYearConstraint(useSchoolYear);
            var apiDefaults = RouteConfigurationHelper.CreateOpenApiMetadataDefaults();
            string schoolYearSegment = RouteConfigurationHelper.CreateSchoolYearSegment(useSchoolYear);

            config.Routes.MapHttpRoute(
                       name: MetadataRouteConstants.Profiles,
                       routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "profiles/{profileName}/swagger.json",
                       defaults: RouteConfigurationHelper.CreateOpenApiMetadataDefaults(),
                       constraints: schoolYearConstraint
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Profiles);
        }
    }
}
