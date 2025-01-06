// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Api.Conventions;

/// <summary>
/// Obtains the root route template prefix for controllers using ODS-based routes.
/// </summary>
public class OdsRouteRootTemplateProvider : IOdsRouteRootTemplateProvider
{
    private readonly IFeatureManager _featureManager;
    private readonly ApiSettings _apiSettings;

    public OdsRouteRootTemplateProvider(IFeatureManager featureManager, ApiSettings apiSettings)
    {
        _featureManager = featureManager;
        _apiSettings = apiSettings;
    }

    /// <inheritdoc cref="IOdsRouteRootTemplateProvider.GetOdsRouteRootTemplate" />
    public string GetOdsRouteRootTemplate()
    {
        string odsContextRouteTemplate = _apiSettings.OdsContextRouteTemplate;

        if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
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
}
