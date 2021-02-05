// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Features.Publishing
{
    public static class PublishingConstants
    {
        public const string FeatureName = "Publishing";

        public const string FeatureVersion = "1";

        public static readonly string PublishingMetadataRouteName = EdFiConventions.GetOpenApiMetadataRouteName(FeatureName);

        public static readonly string RoutePrefix = $"publishing/v{FeatureVersion}";
    }
}
