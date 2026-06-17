// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.LoadTools.Engine
{
    public static class DestructiveTestConfigurationDefaults
    {
        public const int DefaultNumericFallbackMax = 999;

        // Non-overridden EducationOrganization ids are generated starting here, well above the generic
        // 1..DefaultNumericFallbackMax fallback range, so they do not collide with EdOrg ids that already
        // exist when the smoke tests run against a populated template.
        public const int EducationOrganizationFallbackStart = 1000;
    }
}
