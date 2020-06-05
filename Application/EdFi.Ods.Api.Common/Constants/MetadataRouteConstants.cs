// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Api.Common.Constants
{
    public static class MetadataRouteConstants
    {
        public static string ResourceTypes
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("ResourceTypes");
        }

        public static string Profiles
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("Profiles");
        }

        public static string Composites
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("Composites");
        }

        public static string Schema
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("Schema");
        }

        public static string All
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("All");
        }

        public static string Bulk
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("Bulk");
        }

        public static string Identity
        {
            get => EdFiConventions.GetOpenApiMetadataRouteName("Identity");
        }
    }
}
