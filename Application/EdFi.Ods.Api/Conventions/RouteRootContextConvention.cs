// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using log4net;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Api.Conventions
{
    public class RouteRootContextConvention : IApplicationModelConvention
    {
        private readonly ApiSettings _apiSettings;
        
        private readonly ILog _logger = LogManager.GetLogger(typeof(RouteRootContextConvention));

        public RouteRootContextConvention(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }
        
        public void Apply(ApplicationModel application)
        {
            foreach (ControllerModel controller in application.Controllers)
            {
                var routeRootContextAttribute = controller.Attributes.OfType<RouteRootContextAttribute>().SingleOrDefault();

                if (routeRootContextAttribute != null)
                {
                    string routeRootTemplate = GetRouteRootTemplate(routeRootContextAttribute.ContextType);

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

                string GetRouteRootTemplate(RouteContextType context)
                {
                    switch (context)
                    {
                        case RouteContextType.Tenant:
                            if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.Value))
                            {
                                return RouteConstants.TenantIdentifierRoutePrefix;
                            }
                             
                            return null;
                        
                        case RouteContextType.Ods:
                            // TODO: ODS-5800
                            string apiSettingsOdsContextRouteTemplate = string.Empty;

                            if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.Value))
                            {
                                return $"{RouteConstants.TenantIdentifierRoutePrefix}{apiSettingsOdsContextRouteTemplate?.Trim('/')}".EnsureSuffixApplied("/");
                            }

                            if (!string.IsNullOrEmpty(apiSettingsOdsContextRouteTemplate))
                            {
                                return apiSettingsOdsContextRouteTemplate.EnsureSuffixApplied("/");
                            }

                            return null;
                    }

                    return null;
                }
            }
        }
    }
}
