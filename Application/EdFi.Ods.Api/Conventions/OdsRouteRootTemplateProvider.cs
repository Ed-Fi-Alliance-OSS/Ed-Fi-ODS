// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;

namespace EdFi.Ods.Api.Conventions;

/// <summary>
/// Obtains the root route template prefix for controllers using ODS-based routes.
/// </summary>
public class OdsRouteRootTemplateProvider : IOdsRouteRootTemplateProvider
{
    private readonly ApiSettings _apiSettings;

    public OdsRouteRootTemplateProvider(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings;
    }

    /// <inheritdoc cref="IOdsRouteRootTemplateProvider.GetOdsRouteRootTemplate" />
    public string GetOdsRouteRootTemplate()
    {
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
}
