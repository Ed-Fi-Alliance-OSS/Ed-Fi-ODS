// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EdFi.Ods.Features.MultiTenancy;

/// <summary>
/// Adds the tenant identifier route segment to the route of tenant-specific controllers.
/// </summary>
public class MultiTenantRouteConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        var routePrefix = new AttributeRouteModel { Template = RouteConstants.TenantIdentifierRoutePrefix };

        foreach (var controller in application.Controllers)
        {
            // Don't apply tenant prefix to the version controller which should always be at the root
            if (controller.ControllerType.AsType() == typeof(VersionController))
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
    }
}
