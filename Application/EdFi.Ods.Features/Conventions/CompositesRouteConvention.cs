// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using CompositeResourceController = EdFi.Ods.Features.Controllers.CompositeResourceController;

namespace EdFi.Ods.Features.Conventions
{
    public class CompositesRouteConvention : IApplicationModelConvention
    {
        private readonly ApiSettings _apiSettings;
        private readonly ICompositesMetadataProvider _compositesMetadataProvider;

        public CompositesRouteConvention(ICompositesMetadataProvider compositesMetadataProvider, ApiSettings apiSettings)
        {
            _compositesMetadataProvider = compositesMetadataProvider;
            _apiSettings = apiSettings;
        }

        public void Apply(ApplicationModel application)
        {
            var controller =
                application.Controllers.FirstOrDefault(
                    x => x.ControllerType == typeof(CompositeResourceController).GetTypeInfo());

            // composites/v{compositeVersion}/{school year if year specific}/{organizationCode}/{compositeCategoryName (regex constraint}/{compositeName}/{id?}
            // the composite category is constrained by a regex expression
            // the id is optional
            // the attribute on the controller is composites
            if (controller != null)
            {
                var defaultRouteSuffix = new AttributeRouteModel {Template = CreateRouteTemplate() + "{compositeName}/{id?}"};

                // the composite controller has only one selector and if more are added this should break

                var selector = controller.Selectors.SingleOrDefault();

                if (selector.AttributeRouteModel != null)
                {
                    // composites have children routes that need to be added to the controller.
                    var routeMetadataGroupedByCompositeCategory = _compositesMetadataProvider.GetAllRoutes();

                    foreach (var routeGrouping in routeMetadataGroupedByCompositeCategory)
                    {
                        foreach (var routeElt in routeGrouping.Value)
                        {
                            string relativeRouteTemplate = routeElt.AttributeValue("relativeRouteTemplate")
                                .TrimStart('/');

                            var routeSuffix = new AttributeRouteModel {Template = CreateRouteTemplate() + relativeRouteTemplate};

                            var childSelector = new SelectorModel
                            {
                                AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                                    selector.AttributeRouteModel,
                                    routeSuffix)
                            };

                            controller.Selectors.Add(childSelector);
                        }
                    }

                    // set the base selector with the correct route
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        selector.AttributeRouteModel,
                        defaultRouteSuffix);
                }
            }

            string CreateRouteTemplate()
            {
                string template = $"v{ApiVersionConstants.Composite}/";

                if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
                {
                    template += RouteConstants.SchoolYearFromRoute;
                }

                var compositeCategoryNames = _compositesMetadataProvider
                    .GetAllCategories()
                    .Select(x => x.Name)
                    .ToList<string>();

                string allCompositeCategoriesConstraintExpression = $@"^(?i)({string.Join("|", compositeCategoryNames)})$";

                string categoryName = "{organizationCode}/{compositeCategory}/";

                template += categoryName;

                return template;
            }
        }
    }
}
#endif
