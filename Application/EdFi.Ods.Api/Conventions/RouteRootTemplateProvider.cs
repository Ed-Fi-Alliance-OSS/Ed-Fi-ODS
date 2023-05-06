// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;

namespace EdFi.Ods.Api.Conventions;

/// <summary>
/// Obtains the root route template prefix for controllers using the specified <see cref="RouteContextType" />.
/// </summary>
public class RouteRootTemplateProvider : IRouteRootTemplateProvider
{
    private readonly ApiSettings _apiSettings;

    public RouteRootTemplateProvider(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;
    }

    /// <inheritdoc cref="IRouteRootTemplateProvider.GetRouteRootTemplate" />
    public string GetRouteRootTemplate(RouteContextType context)
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
                string odsContextRouteTemplate = _apiSettings.OdsContextRouteTemplate;

                if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.Value))
                {
                    return $"{RouteConstants.TenantIdentifierRoutePrefix}{odsContextRouteTemplate?.Trim('/')}"
                        .EnsureSuffixApplied("/");
                }

                if (!string.IsNullOrEmpty(odsContextRouteTemplate))
                {
                    return odsContextRouteTemplate.EnsureSuffixApplied("/");
                }

                return null;
        }

        return null;
    }
}
