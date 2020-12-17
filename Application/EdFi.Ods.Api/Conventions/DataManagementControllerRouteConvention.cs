// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Reflection;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.DataManagement;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Api.Conventions
{
    public class DataManagementControllerRouteConvention : IApplicationModelConvention
    {
        private readonly ApiSettings _apiSettings;

        public DataManagementControllerRouteConvention(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public void Apply(ApplicationModel application)
        {
            var routePrefix = new AttributeRouteModel {Template = CreateRouteTemplate()};

            var dataManagementController = application.Controllers
                .FirstOrDefault(x => x.ControllerType == typeof(DataManagementResourceController).GetTypeInfo());

            if (dataManagementController == null)
            {
                throw new Exception($"Controller '{nameof(DataManagementResourceController)}' not found.");
            }

            foreach (var selector in dataManagementController.Selectors)
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        routePrefix,
                        selector.AttributeRouteModel);
                }
            }

            string CreateRouteTemplate()
            {
                string template = $"{RouteConstants.DataManagementRoutePrefix}/";

                if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
                {
                    template += RouteConstants.SchoolYearFromRoute;
                }

                if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
                {
                    template += RouteConstants.InstanceIdFromRoute;
                    template += RouteConstants.SchoolYearFromRoute;
                }

                return template;
            }
        }
    }
}