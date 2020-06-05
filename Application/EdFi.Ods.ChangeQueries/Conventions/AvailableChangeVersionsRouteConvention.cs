// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.ChangeQueries.Controllers;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.ChangeQueries.Conventions
{
    public class AvailableChangeVersionsRouteConvention : IApplicationModelConvention
    {
        private readonly ApiSettings _apiSettings;

        public AvailableChangeVersionsRouteConvention(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public void Apply(ApplicationModel application)
        {
            var controller =
                application.Controllers.FirstOrDefault(
                    x => x.ControllerType == typeof(AvailableChangeVersionsController).GetTypeInfo());

            if (controller != null)
            {
                var routeSuffix = new AttributeRouteModel {Template = CreateRouteTemplate()};

                foreach (var selector in controller.Selectors)
                {
                    if (selector.AttributeRouteModel != null)
                    {
                        selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            selector.AttributeRouteModel,
                            routeSuffix);
                    }
                }
            }

            string CreateRouteTemplate()
            {
                string template = $"v{ChangeQueriesConstants.FeatureVersion}/";

                if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
                {
                    template += RouteConstants.SchoolYearFromRoute;
                }

                return template + "availablechangeversions/";
            }
        }
    }
}
#endif
