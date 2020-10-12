// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using Microsoft.AspNetCore.Authorization;

namespace EdFi.Ods.Api.Extensions.Authorization
{
    public static class AuthorizationPolicyBuilderExtension
    {
        public static AuthorizationPolicyBuilder UserRequireCustomClaim(this AuthorizationPolicyBuilder builder,string claimType)
        {
            return builder.AddRequirements(new EdFiAuthorizationRequirement(claimType));           
        }
    }
}
#endif