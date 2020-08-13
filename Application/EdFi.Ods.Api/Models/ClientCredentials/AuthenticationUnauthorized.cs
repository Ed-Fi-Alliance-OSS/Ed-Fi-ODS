﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Threading.Tasks;
using EdFi.Ods.Api.Models.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Models.ClientCredentials
{
    public class AuthenticationUnauthorized : IActionResult
    {
        private readonly HttpRequest _httpRequest;

        public AuthenticationUnauthorized(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public Task ExecuteResultAsync(ActionContext context)
            => Task.FromResult(new UnauthorizedObjectResult(new TokenError(TokenErrorType.InvalidClient)));
    }
}
#endif