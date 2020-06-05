// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.NetCore.Models.ClientCredentials
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
