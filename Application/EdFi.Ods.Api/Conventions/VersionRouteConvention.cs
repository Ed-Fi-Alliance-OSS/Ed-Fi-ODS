// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Reflection;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Api.Conventions;

public class VersionRouteConvention : IApplicationModelConvention
{
    private readonly bool _isMultiTenantEnabled;
    private readonly string _odsContextRouteTemplate;

    public VersionRouteConvention(ApiSettings apiSettings)
    {
        _isMultiTenantEnabled = apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.Value);
        _odsContextRouteTemplate = apiSettings.OdsContextRouteTemplate;
    }

    public void Apply(ApplicationModel application)
    {
        var controller =
            application.Controllers.FirstOrDefault(
                x => x.ControllerType == typeof(VersionController).GetTypeInfo());

        if (controller != null)
        {
            // The controller has only one selector at this point, and if more are added this should break
            var selector = controller.Selectors.Single();

            // If multi-tenant feature enabled, add a new selector
            if (_isMultiTenantEnabled)
            {
                var tenantOnlyRoutePrefix = new AttributeRouteModel {Template = "{tenantIdentifier}" };

                var tenantOnlySelector = new SelectorModel
                {
                    AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        selector.AttributeRouteModel,
                        tenantOnlyRoutePrefix)
                };

                controller.Selectors.Add(tenantOnlySelector);
            }
            
            if (!string.IsNullOrEmpty(_odsContextRouteTemplate))
            {
                var odsContextRoutePrefix = new AttributeRouteModel
                {
                    Template = _isMultiTenantEnabled ? $"{{tenantIdentifier}}/{_odsContextRouteTemplate}" : _odsContextRouteTemplate
                };
                
                var odsInstanceSelector = new SelectorModel
                {
                    AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        selector.AttributeRouteModel,
                        odsContextRoutePrefix)
                };

                controller.Selectors.Add(odsInstanceSelector);
            }
        }
    }
}
