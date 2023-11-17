// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.Conventions;

public class OpenApiMetadataRouteConvention : IApplicationModelConvention
{
    private readonly bool _isMultiTenantEnabled;
    private readonly string _odsContextRouteTemplate;
    private readonly IList<IOpenApiMetadataRouteInformation> _routeInformations;

    public OpenApiMetadataRouteConvention(
        ApiSettings apiSettings,
        IList<IOpenApiMetadataRouteInformation> routeInformations)
    {
        _isMultiTenantEnabled = apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.Value);
        _odsContextRouteTemplate = apiSettings.OdsContextRouteTemplate;
        _routeInformations = routeInformations;
    }

    public void Apply(ApplicationModel application)
    {
        var controller =
            application.Controllers.FirstOrDefault(
                x => x.ControllerType == typeof(OpenApiMetadataController).GetTypeInfo());

        if (controller != null)
        {
            // The controller has only one selector at this point, and if more are added this should break
            var selector = controller.Selectors.Single();

            // If ODS Context Route is configured, remove the route constraints so the server variables element can be populated correctly
            if (!string.IsNullOrEmpty(_odsContextRouteTemplate))
            {
                var routeTemplateWithoutConstraints = new string(OdsContextRouteTemplateHelpers.GetOdsContextPathChars(_odsContextRouteTemplate).ToArray());

                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel.Template =
                        selector.AttributeRouteModel.Template?.Replace(
                            _odsContextRouteTemplate, $"{routeTemplateWithoutConstraints}");
                }
            }

            // If MultiTenant is enabled, we need to match the route exactly so the TenantConfiguration can be loaded correctly
            if (_isMultiTenantEnabled)
            {
                foreach (var routeInformation in _routeInformations)
                {
                    var prefixTemplate = new AttributeRouteModel
                    {
                        Template = selector.AttributeRouteModel?.Template.TrimSuffix("/metadata")
                    };

                    var routeTemplate = new AttributeRouteModel
                    {
                        Template = routeInformation.GetRouteInformation().Template
                    };

                    var routeSelector = new SelectorModel
                    {
                        AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            prefixTemplate,
                            routeTemplate)
                    };

                    if (controller.Selectors.Any(x => x.AttributeRouteModel?.Template == routeSelector.AttributeRouteModel?.Template))
                        continue;

                    controller.Selectors.Add(routeSelector);
                }
            }
        }
    }
}
