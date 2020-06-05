// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Constants
{
    public class ApiFeature : Enumeration<ApiFeature, string>
    {
        public static readonly ApiFeature Extensions = new ApiFeature("extensions", "Extensions");
        public static readonly ApiFeature ChangeQueries = new ApiFeature("changeQueries", "Change Queries");
        public static readonly ApiFeature OpenApiMetadata = new ApiFeature("openApiMetadata", "Open Api Metadata");
        public static readonly ApiFeature AggregateDependencies = new ApiFeature("aggregateDependencies", "Aggregate Dependencies");
        public static readonly ApiFeature Composites = new ApiFeature("composites", "Composites");
        public static readonly ApiFeature Profiles = new ApiFeature("profiles", "Profiles");
        public static readonly ApiFeature OwnershipBasedAuthorization = new ApiFeature("ownershipBasedAuthorization", "Ownership Based Authorization");
        public static readonly ApiFeature UniqueIdValidation = new ApiFeature("uniqueIdValidation", "Unique Identification Validation");

        public ApiFeature(string value, string displayName)
            : base(value, displayName) { }

        // Returns the key used by the config file. Note this is always the value.
        public string GetConfigKeyName() => Value;
    }
}
