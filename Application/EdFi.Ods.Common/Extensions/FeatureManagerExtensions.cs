// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Constants;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Common.Extensions;

public static class FeatureManagerExtensions
{
    public static bool IsFeatureEnabled(this IFeatureManager featureManager, string featureName)
    {
        return featureManager.IsEnabledAsync(featureName).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    public static bool IsFeatureEnabled(this IFeatureManager featureManager, ApiFeature feature)
    {
        return featureManager.IsEnabledAsync(feature.Value).ConfigureAwait(false).GetAwaiter().GetResult();
    }
}
