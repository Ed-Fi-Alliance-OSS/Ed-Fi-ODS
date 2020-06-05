#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.HttpRouteConfigurations
{
    public class ApiDefaultRouteConfiguration : IRouteConfiguration, IOpenApiMetadataRouteConfiguration
    {
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        public ApiDefaultRouteConfiguration(ISchemaNameMapProvider schemaNameMapProvider)
        {
            _schemaNameMapProvider = Preconditions.ThrowIfNull(schemaNameMapProvider, nameof(schemaNameMapProvider));
        }

        public void ConfigureOpenApiMetadataRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            var schemas = _schemaNameMapProvider.GetSchemaNameMaps()
                .Select(x => x.UriSegment.ToLowerInvariant())
                .ToList();

            string schemaNameConstraints = string.Join("|", schemas);

            var schoolYearConstraint = RouteConfigurationHelper.CreateSchoolYearConstraint(useSchoolYear);
            var resourceTypesConstraint = RouteConfigurationHelper.CreateResourceTypesConstraints(useSchoolYear);
            var apiDefaults = RouteConfigurationHelper.CreateOpenApiMetadataDefaults();
            string schoolYearRoute = RouteConfigurationHelper.CreateSchoolYearSegment(useSchoolYear);

            ConfigureResourceTypeMetadataRoutes(config, apiDefaults, resourceTypesConstraint, schoolYearRoute);
            ConfigureComprehensiveMetadataRoute(config, apiDefaults, schoolYearConstraint, schoolYearRoute);
            ConfigureDependencyMetadataRoute(config, schoolYearConstraint, schoolYearRoute);

            ConfigureSchemaSpecificMetadataRoute(
                config,
                RouteConfigurationHelper.CreateSchemaNameConstraint(useSchoolYear, schemaNameConstraints),
                schoolYearRoute);
        }

        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            var apiDefaults = new
            {
                apiVersion = ApiVersionConstants.Ods,
                identityVersion = ApiVersionConstants.Identity
            };

            config.Routes.MapHttpRoute(
                name: "ApiDefaultCollection",
                routeTemplate: "data/v{apiVersion}/" + (useSchoolYear
                    ? "{schoolYearFromRoute}/"
                    : string.Empty) + "{schema}/{controller}",
                defaults: apiDefaults,
                constraints: useSchoolYear
                    ? RouteConfigurationHelper.CreateSchoolYearRouteConstraints()
                    : RouteConfigurationHelper.CreateRouteConstraints());

            config.Routes.MapHttpRoute(
                name: "ApiDefaultItem",
                routeTemplate: "data/v{apiVersion}/" + (useSchoolYear
                    ? "{schoolYearFromRoute}/"
                    : string.Empty) + "{schema}/{controller}/{id}",
                defaults: apiDefaults,
                constraints: useSchoolYear
                    ? RouteConfigurationHelper.CreateSchoolYearWithIdRouteConstraints()
                    : RouteConfigurationHelper.CreateIdRouteConstraints());

            config.Routes.MapHttpRoute(
                name: "Root",
                routeTemplate: "",
                defaults: new
                {
                    controller = "Version",
                    action = "Index"
                });
        }

        private void ConfigureSchemaSpecificMetadataRoute(
            HttpConfiguration config,
            object schoolYearConstraint,
            string schoolYearRoute)
        {
            string schoolYearSegment = schoolYearRoute;
            var constraints = schoolYearConstraint;

            config.Routes.MapHttpRoute(
                    name: "OpenApiMetadataSchema",
                    routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "{schemaName}/swagger.json",
                    defaults: RouteConfigurationHelper.CreateOpenApiMetadataDefaults(),
                    constraints: constraints
                )
                .SetDataTokenRouteName(MetadataRouteConstants.Schema);
        }

        private void ConfigureDependencyMetadataRoute(HttpConfiguration config, object constraints, string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                    name: "AggregateDependencies",
                    routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "dependencies",
                    defaults: new
                    {
                        controller = "aggregatedependency",
                        apiVersion = ApiVersionConstants.Ods,
                        action = "get"
                    },
                    constraints: constraints
                )
                .SetDataTokenRouteName(RouteConstants.Dependencies);
        }

        private void ConfigureResourceTypeMetadataRoutes(
            HttpConfiguration config,
            object defaults,
            object constraints,
            string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                    name: "OpenApiMetadataResourceTypes",
                    routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "{resourceType}/swagger.json",
                    defaults: defaults,
                    constraints: constraints
                )
                .SetDataTokenRouteName(MetadataRouteConstants.ResourceTypes);
        }

        private void ConfigureComprehensiveMetadataRoute(
            HttpConfiguration config,
            object defaults,
            object constraints,
            string schoolYearSegment)
        {
            config.Routes.MapHttpRoute(
                    name: "OpenApiMetadata",
                    routeTemplate: "metadata/data/v{apiVersion}/" + schoolYearSegment + "swagger.json",
                    defaults: defaults,
                    constraints: constraints
                )
                .SetDataTokenRouteName(MetadataRouteConstants.All);
        }
    }
}
#endif