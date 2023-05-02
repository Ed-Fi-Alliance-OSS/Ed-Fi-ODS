// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Api.Conventions
{
    public class DataManagementControllerRouteConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var routePrefix = new AttributeRouteModel {Template = CreateRouteTemplate()};

            foreach (ControllerModel controller in application.Controllers)
            {
                // apply only to data management controllers
                if (!controller.IsDataManagementController())
                {
                    continue;
                }

                foreach (var selector in controller.Selectors)
                {
                    if (selector.AttributeRouteModel != null)
                    {
                        selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            routePrefix,
                            selector.AttributeRouteModel);
                    }
                }
            }

            string CreateRouteTemplate()
            {
                string template = $"{RouteConstants.DataManagementRoutePrefix}/";

                return template;
            }
        }
    }
}