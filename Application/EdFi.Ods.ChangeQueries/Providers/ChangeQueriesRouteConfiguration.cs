#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Extensions;

namespace EdFi.Ods.ChangeQueries.Providers
{
    public class ChangeQueriesRouteConfiguration : IRouteConfiguration
    {
        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            var routeConstraints = useSchoolYear
                ? (object) new
                           {
                               controller = @"(availablechangeversions)", schoolYearFromRoute = @"^\d{4}$"
                           }
                : new
                  {
                      controller = @"(availablechangeversions)"
                  };

            var schoolYearSegment = useSchoolYear
                ? "{schoolYearFromRoute}/"
                : string.Empty;

            config.Routes.MapHttpRoute(
                name: "ChangeQueries",
                routeTemplate: "changeQueries/v{changeQueriesVersion}/" + schoolYearSegment + "{controller}",
                defaults: new
                          {
                              changeQueriesVersion = ChangeQueriesConstants.FeatureVersion
                          },
                constraints: routeConstraints);

            var resourceTypesConstraint = useSchoolYear
                ? (object) new
                           {
                               resourceType = @"(changequeries)", schoolYearFromRoute = @"^\d{4}$"
                           }
                : new
                  {
                      resourceType = @"(changequeries)"
                  };

            config.Routes.MapHttpRoute(
                name: ChangeQueriesConstants.ChangeQueriesMetadataRouteName,
                routeTemplate: "metadata/{otherName}/v{changeQueriesVersion}/" + schoolYearSegment + "swagger.json",
                defaults: new
                          {
                              controller = "openapimetadata", action = "get", changeQueriesVersion = ChangeQueriesConstants.FeatureVersion,
                              otherName = "changequeries"
                          },
                constraints: resourceTypesConstraint
            ).SetDataTokenRouteName(ChangeQueriesConstants.ChangeQueriesMetadataRouteName);

            ConfigureDeletedChangeQueriesRoute(config, useSchoolYear);
        }

        private void ConfigureDeletedChangeQueriesRoute(HttpConfiguration config, bool useSchoolYear)
        {
            config.Routes.MapHttpRoute(
                name: "DeletedChangeQueriesCollection",
                routeTemplate: "data/v{apiVersion}/" + (useSchoolYear
                                   ? "{schoolYearFromRoute}/"
                                   : string.Empty) + "{schema}/{resource}/{controller}",
                defaults: new
                          {
                              apiVersion = ApiVersionConstants.Ods,
                              identityVersion = ApiVersionConstants.Identity,
                              action = "get",
                              controller = "@(deletes)"
                          },
                constraints: useSchoolYear
                    ? CreateDeletedChangeQueriesSchoolYearRouteConstraints()
                    : CreateDeletedChangeQueriesRouteConstraints());
        }

        private static object CreateDeletedChangeQueriesSchoolYearRouteConstraints()
        {
            return new
                   {
                       resource = @"^((?!(identities)).)*$",
                       schoolYearFromRoute = @"^\d{4}$"
                   };
        }

        private static object CreateDeletedChangeQueriesRouteConstraints()
        {
            return new
                   {
                       resource = @"^((?!(identities)).)*$"
                   };
        }
    }
}
#endif

