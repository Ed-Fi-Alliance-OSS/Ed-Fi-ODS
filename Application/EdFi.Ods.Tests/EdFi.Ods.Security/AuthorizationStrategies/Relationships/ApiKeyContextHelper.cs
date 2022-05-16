// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Security;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

public static class ApiKeyContextHelper
{
    public static ApiKeyContext GetApiKeyContextWithEdOrgIds(params int[] educationOrganizationIds)
    {
        return new ApiKeyContext("key", "theClaimSet", educationOrganizationIds, 
            Array.Empty<string>(),
            Array.Empty<string>(), 
            string.Empty,
            null,
            Array.Empty<short?>());
    }
}
