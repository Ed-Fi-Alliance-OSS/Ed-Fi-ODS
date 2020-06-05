// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.HttpRouteConfigurations
{
    public class IdentityRouteConfiguration : IRouteConfiguration, IOpenApiMetadataRouteConfiguration
    {
        public void ConfigureOpenApiMetadataRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            config.Routes.MapHttpRoute(
                       name: "OpenApiMetadataIdentity",
                       routeTemplate: "metadata/{otherName}/v{identityVersion}/" + RouteConfigurationHelper.CreateSchoolYearSegment(useSchoolYear) +
                                      "swagger.json",
                       defaults: RouteConfigurationHelper.CreateOpenApiMetadataDefaults(),
                       constraints: RouteConfigurationHelper.CreateSchoolYearConstraint(useSchoolYear)
                   )
                  .SetDataTokenRouteName(MetadataRouteConstants.Identity);
        }

        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            var routeConstraints = RouteConfigurationHelper.CreateSchoolYearConstraint(useSchoolYear);

            var schoolYearSegment = useSchoolYear
                ? "{schoolYearFromRoute}/"
                : string.Empty;

            config.Routes.MapHttpRoute(
                name: "IdentitiesCreate",
                routeTemplate: "identity/v{identityVersion}/" + schoolYearSegment + "identities",
                defaults: new
                {
                    identityVersion = ApiVersionConstants.Identity,
                    controller = "Identities",
                    action = "Create"
                },
                constraints: routeConstraints
            );

            config.Routes.MapHttpRoute(
                name: "IdentitiesFind",
                routeTemplate: "identity/v{identityVersion}/" + schoolYearSegment + "identities/find",
                defaults: new
                {
                    identityVersion = ApiVersionConstants.Identity,
                    controller = "Identities",
                    action = "Find"
                },
                constraints: routeConstraints
            );

            config.Routes.MapHttpRoute(
                name: "IdentitiesSearch",
                routeTemplate: "identity/v{identityVersion}/" + schoolYearSegment + "identities/search",
                defaults: new
                {
                    identityVersion = ApiVersionConstants.Identity,
                    controller = "Identities",
                    action = "Search"
                },
                constraints: routeConstraints
            );

            config.Routes.MapHttpRoute(
                name: "IdentitiesGetById",
                routeTemplate: "identity/v{identityVersion}/" + schoolYearSegment + "identities/{id}",
                defaults: new
                {
                    identityVersion = ApiVersionConstants.Identity,
                    controller = "Identities",
                    action = "GetById"
                },
                constraints: routeConstraints
            );

            config.Routes.MapHttpRoute(
                name: "IdentitiesSearchResult",
                routeTemplate: "identity/v{identityVersion}/" + schoolYearSegment + "identities/results/{id}",
                defaults: new
                {
                    identityVersion = ApiVersionConstants.Identity,
                    controller = "Identities",
                    action = "Result"
                },
                constraints: routeConstraints
            );
        }
    }
}
