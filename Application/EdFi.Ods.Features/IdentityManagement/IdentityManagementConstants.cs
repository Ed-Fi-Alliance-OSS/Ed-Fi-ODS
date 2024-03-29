﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Features.IdentityManagement
{
    public class IdentityManagementConstants
    {
        public const string FeatureName = "IdentityManagement";
        public const string DeprecatedFeatureName = "Identity";

        public const string FeatureVersion = "2";

        public const string IdentityRoutePrefix = $"identity/v{FeatureVersion}";

        public static readonly string IdentityMetadataRouteName =
            EdFiConventions.GetOpenApiMetadataRouteName(DeprecatedFeatureName);
    }
}
