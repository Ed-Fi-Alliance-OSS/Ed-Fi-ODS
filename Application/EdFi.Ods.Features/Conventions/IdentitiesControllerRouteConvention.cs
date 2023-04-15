// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.IdentityManagement;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using IdentitiesController = EdFi.Ods.Features.Controllers.IdentitiesController;

namespace EdFi.Ods.Features.Conventions
{
    public class IdentitiesControllerRouteConvention : IApplicationModelConvention
    {
        private readonly ApiSettings _apiSettings;

        public IdentitiesControllerRouteConvention(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public void Apply(ApplicationModel application)
        {
            var controller =
                application.Controllers.SingleOrDefault(x => x.ControllerType == typeof(IdentitiesController).GetTypeInfo());

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
                string template = $"{IdentityManagementConstants.IdentityRoutePrefix}/";

                return template;
            }
        }
    }
}
