// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class FeatureDisabledException : SystemConfigurationException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "feature-disabled";
    private const string TitleText = "Feature Disabled";

    public FeatureDisabledException(string featureName)
        : base(GetDetail(featureName), GetDetail(featureName)) { }

    public FeatureDisabledException(string featureName, Exception innerException)
        : base(GetDetail(featureName), GetDetail(featureName), innerException) { }

    private static string GetDetail(string featureName) => $"The '{featureName}' feature is disabled.";

    // ---------------------------
    //  Boilerplate for overrides
    // ---------------------------
    public override string Title { get => TitleText; }
    protected override IEnumerable<string> GetTypeParts()
    {
        foreach (var part in base.GetTypeParts())
        {
            yield return part;
        }

        yield return TypePart;
    }
}
