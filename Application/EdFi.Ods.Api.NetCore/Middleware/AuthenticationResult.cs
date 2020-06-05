// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Security.Claims;
using EdFi.Ods.Common.Security;
using Microsoft.AspNetCore.Authentication;

namespace EdFi.Ods.Api.NetCore.Middleware {
    public class AuthenticationResult
    {
        public AuthenticateResult AuthenticateResult { get; set; }

        public ClaimsIdentity ClaimsIdentity { get; set; }

        public ApiKeyContext ApiKeyContext { get; set; }
    }
}
