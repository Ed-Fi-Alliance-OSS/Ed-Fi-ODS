// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Api.Constants
{
    public static class MetadataRouteConstants
    {
        public static string ResourceTypes => EdFiConventions.GetOpenApiMetadataRouteName("ResourceTypes");

        public static string Profiles => EdFiConventions.GetOpenApiMetadataRouteName("Profiles");

        public static string Composites => EdFiConventions.GetOpenApiMetadataRouteName("Composites");

        public static string Schema => EdFiConventions.GetOpenApiMetadataRouteName("Schema");

        public static string All => EdFiConventions.GetOpenApiMetadataRouteName("All");

        public static string Identity => EdFiConventions.GetOpenApiMetadataRouteName("Identity");
    }
}
