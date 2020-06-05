// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Api.Common.Constants;

namespace EdFi.Ods.Api.HttpRouteConfigurations
{
    public static class RouteConfigurationHelper
    {
        public static object CreateSchoolYearConstraint(bool useSchoolYear)
        {
            return useSchoolYear
                ? new {schoolYearFromRoute = @"^\d{4}$"}
                : null;
        }

        public static object CreateSchemaNameConstraint(bool useSchoolYear, string schemaNameConstraints)
        {
            return useSchoolYear
                ? (object) new
                {
                    schoolYearFromRoute = @"^\d{4}$",
                    schemaName = $@"({schemaNameConstraints})"
                }
                : new {schemaName = $@"({schemaNameConstraints})"};
        }

        public static object CreateRouteConstraints()
        {
            return new
            {
                controller = @"^((?!(identities)).)*$",
            };
        }

        public static object CreateSchoolYearRouteConstraints()
        {
            return new
            {
                //do not use this path for the swagger, and other controllers not needing school year
                controller = @"^((?!(identities)).)*$",
                schoolYearFromRoute = @"^\d{4}$",
            };
        }

        public static object CreateIdRouteConstraints()
        {
            return new
            {
                controller = @"^((?!(identities)).)*$",
                id = @"^((?!(deletes)).)*$"
            };
        }

        public static object CreateSchoolYearWithIdRouteConstraints()
        {
            return new
            {
                //do not use this path for the swagger, and other controllers not needing school year
                controller = @"^((?!(identities)).)*$",
                schoolYearFromRoute = @"^\d{4}$",
                id = @"^((?!(deletes)).)*$"
            };
        }

        public static object CreateResourceTypesConstraints(bool useSchoolYear)
        {
            return useSchoolYear
                ? (object) new
                {
                    resourceType = @"(resources|descriptors)",
                    schoolYearFromRoute = @"^\d{4}$"
                }
                : new {resourceType = @"(resources|descriptors)"};
        }

        public static string CreateSchoolYearSegment(bool useSchoolYear)
        {
            return useSchoolYear
                ? "{schoolYearFromRoute}/"
                : string.Empty;
        }

        public static object CreateOpenApiMetadataDefaults()
        {
            return new
            {
                controller = "openapimetadata",
                apiVersion = ApiVersionConstants.Ods,
                identityVersion = ApiVersionConstants.Identity,
                compositeVersion = ApiVersionConstants.Composite,
                action = "get"
            };
        }
    }
}
