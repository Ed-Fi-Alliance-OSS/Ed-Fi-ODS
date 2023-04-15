// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.XsdMetadata
{
    public class XsdMetadataRouteConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var controller =
                application.Controllers.FirstOrDefault(x => x.ControllerType == typeof(XsdMetadataController).GetTypeInfo());

            if (controller != null)
            {
                var routePrefix = new AttributeRouteModel { Template = CreateRouteTemplate() };

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
                string template = $"metadata/";

                return template;
            }
        }
    }
}
