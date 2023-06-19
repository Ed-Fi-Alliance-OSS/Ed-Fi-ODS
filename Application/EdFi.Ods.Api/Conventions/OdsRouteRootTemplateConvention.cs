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
    /// Applies an appropriate root template to the routes of all controllers with the <see cref="ApplyOdsRouteRootTemplateAttribute"/>
    /// applied. This attribute identifies controllers that are tenant-specific and/or ODS-context-specific and introduces
    /// an appropriate root template to their routes.
    /// </summary>
    public class OdsRouteRootTemplateConvention : IApplicationModelConvention
    {
        private readonly IOdsRouteRootTemplateProvider _odsRouteRootTemplateProvider;

        public OdsRouteRootTemplateConvention(IOdsRouteRootTemplateProvider odsRouteRootTemplateProvider)
        {
            _odsRouteRootTemplateProvider = odsRouteRootTemplateProvider;
        }

        public void Apply(ApplicationModel application)
        {
            foreach (ControllerModel controller in application.Controllers)
            {
                var routeRootContextAttribute = controller.Attributes.OfType<ApplyOdsRouteRootTemplateAttribute>().SingleOrDefault();

                if (routeRootContextAttribute != null)
                {
                    string routeRootTemplate = _odsRouteRootTemplateProvider.GetOdsRouteRootTemplate();

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
