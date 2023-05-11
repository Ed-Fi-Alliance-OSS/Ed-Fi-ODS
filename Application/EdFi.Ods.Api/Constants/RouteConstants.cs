// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Constants
{
    public static class RouteConstants
    {
        public const string DataManagementRoutePrefix = $"data/v{ApiVersionConstants.Ods}";
        public const string TenantIdentifierRoutePrefix = @"{tenantIdentifier:regex(^[[A-Za-z0-9-]]+$)}/";
    }
}
