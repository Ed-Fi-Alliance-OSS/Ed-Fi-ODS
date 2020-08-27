// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Provides keys to use when saving data into contextual storage.
    /// </summary>
    public static class AuthorizationContextKeys
    {
        public const string Action = "AuthorizationContext.Action";
        public const string Resource = "AuthorizationContext.Resource";
        public const string AuthorizationInjectedIntoPagedQuery = "AuthorizationContext.AuthorizationInjectedIntoPagedQuery";
    }
}
