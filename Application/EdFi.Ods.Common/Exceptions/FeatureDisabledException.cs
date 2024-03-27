// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Exceptions;

public class FeatureDisabledException : SystemConfigurationException
{
    // Fields containing override values for Problem Details
    private const string TypePart = "feature-disabled";
    private const string TitleText = "Feature Disabled";

    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureDisabledException"/> class using the supplied feature name and the default status (500).
    /// </summary>
    /// <param name="featureName">The name of the feature that has been disabled.</param>
    public FeatureDisabledException(string featureName)
        : base(GetDetail(featureName), GetDetail(featureName))
    {
        Status = base.Status;
        FeatureName = featureName;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FeatureDisabledException"/> class using the supplied feature name and response status code.
    /// </summary>
    /// <param name="featureName">The name of the feature that has been disabled.</param>
    /// <param name="status">The status code to be reported with this occurrence of the error.</param>
    public FeatureDisabledException(string featureName, int status)
        : base(GetDetail(featureName), GetDetail(featureName))
    {
        Status = status;
        FeatureName = featureName;
    }

    private static string GetDetail(string featureName) => $"The '{featureName}' feature is disabled.";

    public string FeatureName { get; init; }

    public override int Status { get; }

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
