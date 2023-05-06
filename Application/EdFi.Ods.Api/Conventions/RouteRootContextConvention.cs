// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Api.Attributes;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Api.Conventions
{
    /// <summary>
    /// Applies an appropriate root template to the routes of all controllers with the <see cref="RouteRootContextAttribute"/>
    /// applied. This attribute identifies controllers that are tenant-specific and/or ODS-context-specific and introduces
    /// an appropriate root template to their routes.
    /// </summary>
    public class RouteRootContextConvention : IApplicationModelConvention
    {
        private readonly IRouteRootTemplateProvider _routeRootTemplateProvider;

        public RouteRootContextConvention(IRouteRootTemplateProvider routeRootTemplateProvider)
        {
            _routeRootTemplateProvider = routeRootTemplateProvider;
        }

        public void Apply(ApplicationModel application)
        {
            foreach (ControllerModel controller in application.Controllers)
            {
                var routeRootContextAttribute = controller.Attributes.OfType<RouteRootContextAttribute>().SingleOrDefault();

                if (routeRootContextAttribute != null)
                {
                    string routeRootTemplate =
                        _routeRootTemplateProvider.GetRouteRootTemplate(routeRootContextAttribute.ContextType);

                    if (!string.IsNullOrEmpty(routeRootTemplate))
                    {
                        var routeRootTemplateModel = new AttributeRouteModel { Template = routeRootTemplate };

                        foreach (var selector in controller.Selectors)
                        {
                            if (selector.AttributeRouteModel != null)
                            {
                                selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                                    routeRootTemplateModel,
                                    selector.AttributeRouteModel);
                            }
                        }
                    }
                }
            }
        }
    }
}
