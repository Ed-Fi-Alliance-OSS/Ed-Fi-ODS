// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Common.Configuration
{
    public class ApiMode : Enumeration<ApiMode, string>
    {
        public static readonly ApiMode Sandbox = new ApiMode(ApiConfigurationConstants.Sandbox, "Sandbox");
        public static readonly ApiMode YearSpecific = new ApiMode(ApiConfigurationConstants.YearSpecific, "Year Specific");
        public static readonly ApiMode InstanceYearSpecific = new ApiMode(ApiConfigurationConstants.InstanceYearSpecific, "Instance Year Specific");
        public static readonly ApiMode SharedInstance = new ApiMode(ApiConfigurationConstants.SharedInstance, "Shared Instance");
        public static readonly ApiMode DistrictSpecific = new ApiMode(ApiConfigurationConstants.DistrictSpecific, "District Specific");

        public ApiMode(string value, string displayName)
            : base(value, displayName) { }
    }
}
