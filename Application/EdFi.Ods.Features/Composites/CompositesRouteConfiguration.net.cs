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
using EdFi.Ods.Api.HttpRouteConfigurations;
using EdFi.Ods.Api.Services.Metadata;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Features.OpenApiMetadata;

namespace EdFi.Ods.Features.Composites
{
    public class CompositesRouteConfiguration : IRouteConfiguration, IOpenApiMetadataRouteConfiguration
    {
        private readonly ICompositesMetadataProvider _compositesMetadataProvider;

        public CompositesRouteConfiguration(ICompositesMetadataProvider compositesMetadataProvider)
        {
            _compositesMetadataProvider = Preconditions.ThrowIfNull(compositesMetadataProvider, nameof(compositesMetadataProvider));
        }

        public void ConfigureOpenApiMetadataRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            // Set up Open API metadata routes
            var apiDefaults = new
                              {
                                  controller = "openapimetadata", compositeVersion = CompositesConstants.FeatureVersion, action = "get"
                              };

            var schoolYearConstraint = RouteConfigurationHelper.CreateSchoolYearConstraint(useSchoolYear);

            string schoolYearRoute = RouteConfigurationHelper.CreateSchoolYearSegment(useSchoolYear);

            config.Routes.MapHttpRoute(
                name: MetadataRouteConstants.Composites,
                routeTemplate: "metadata/composites/v{compositeVersion}/" + schoolYearRoute
                                                                          + "{organizationCode}/{compositeCategoryName}/swagger.json",
                defaults: apiDefaults,
                constraints: schoolYearConstraint
            ).SetDataTokenRouteName(MetadataRouteConstants.Composites);
        }

        public void ConfigureRoutes(HttpConfiguration config, bool useSchoolYear)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            string compositeRouteBase = "composites/v{compositeVersion}/" + (useSchoolYear
                                            ? "{schoolYearFromRoute}/"
                                            : string.Empty) + "{organizationCode}/{compositeCategory}/";

            // Construct the route constraint pattern for the composite categories defined.
            var compositeCategoryNames = Enumerable.ToList<string>(
                                                                      _compositesMetadataProvider.GetAllCategories()
                                                                          .Select(x => x.Name));

            // Don't add routes for composites, if none exit.
            if (!compositeCategoryNames.Any())
            {
                return;
            }

            string allCompositeCategoriesConstraintExpression = $@"^(?i)({string.Join("|", compositeCategoryNames)})$";

            // Define default route for all composites
            config.Routes.MapHttpRoute(
                name: "Composites",
                routeTemplate: compositeRouteBase + "{compositeName}/{id}",
                defaults: new
                          {
                              id = RouteParameter.Optional, controller = "CompositeResource"
                          },
                constraints: useSchoolYear
                    ? (object) new
                               {
                                   compositeCategory = allCompositeCategoriesConstraintExpression, schoolYearFromRoute = @"^\d{4}$"
                               }
                    : new
                      {
                          compositeCategory = allCompositeCategoriesConstraintExpression
                      }
            );

            var routeMetadataGroupedByCompositeCategory = _compositesMetadataProvider.GetAllRoutes();

            foreach (var routeGrouping in routeMetadataGroupedByCompositeCategory)
            {
                string categoryName = routeGrouping.Key.Name;
                int routeNumber = 1;

                foreach (var routeElt in routeGrouping.Value)
                {
                    string relativeRouteTemplate = routeElt.AttributeValue("relativeRouteTemplate")
                                                           .TrimStart('/');

                    config.Routes.MapHttpRoute(
                        name: $"{categoryName}Composites{routeNumber++}",
                        routeTemplate: compositeRouteBase + relativeRouteTemplate,
                        defaults: new
                                  {
                                      controller = "CompositeResource"
                                  },
                        constraints: new
                                     {
                                         compositeCategory = categoryName
                                     });
                }
            }
        }
    }
}
#endif