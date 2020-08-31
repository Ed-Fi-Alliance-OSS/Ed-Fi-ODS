// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Features.OpenApiMetadata.Models
{
    public class OpenApiMetadataRequest
    {
        public string ResourceType { get; set; }

        public string ProfileName { get; set; }

        public string SchemaName { get; set; }

        public string CompositeCategoryName { get; set; }

        public int? SchoolYearFromRoute { get; set; }

        public string OtherName { get; set; }

        public string GetFeedName()
        {
            if (ResourceType != null)
            {
                return $"{OpenApiMetadataSections.SwaggerUi}-{ResourceType}";
            }

            if (ProfileName != null)
            {
                return $"{OpenApiMetadataSections.Profiles}-{ProfileName}";
            }

            if (CompositeCategoryName != null)
            {
                return $"{OpenApiMetadataSections.Composites}-{CompositeCategoryName}";
            }

            if (OtherName != null)
            {
                return $"{OpenApiMetadataSections.Other}-{OtherName}";
            }

            if (SchemaName != null)
            {
                var section = !SchemaName.Equals(EdFiConventions.UriSegment)
                    ? OpenApiMetadataSections.Extensions
                    : OpenApiMetadataSections.SdkGen;

                return $"{section}-{SchemaName}";
            }

            return $"{OpenApiMetadataSections.SdkGen}-all";
        }
    }
}
