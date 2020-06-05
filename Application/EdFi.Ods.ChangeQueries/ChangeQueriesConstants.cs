// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.ChangeQueries
{
    public class ChangeQueriesConstants
    {
        public const string FeatureName = "ChangeQueries";
        public const string FeatureVersion = "1";

        /// <summary>
        /// Metadata Route name for Change Queries
        /// </summary>
        public static readonly string ChangeQueriesMetadataRouteName = EdFiConventions.GetOpenApiMetadataRouteName(FeatureName);
    }
}
