// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace EdFi.Ods.WebApi.IntegrationTests
{
    public class FakedOAuthTokenAuthenticator : IOAuthTokenAuthenticator
    {
        private const string ClaimSetName = "Ed-Fi Sandbox";
        private readonly Lazy<ApiKeyContext> _apiKeyContext;
        private readonly Lazy<int[]> _educationOrganizationIds;
        private readonly Lazy<ClaimsIdentity> _identity;
        private readonly Lazy<List<string>> _namespacePrefixes;

        public FakedOAuthTokenAuthenticator(IClaimsIdentityProvider claimsIdentityProvider)
        {
            _namespacePrefixes = new Lazy<List<string>>(() => new List<string> { "uri://ed-fi.org" });
            _educationOrganizationIds = new Lazy<int[]>(() => new [] { 255901 });

            _identity = new Lazy<ClaimsIdentity>(
                () => claimsIdentityProvider.GetClaimsIdentity(ClaimSetName));

            _apiKeyContext = new Lazy<ApiKeyContext>(
                () => new ApiKeyContext(
                    Guid.NewGuid().ToString("n"),
                    ClaimSetName,
                    _educationOrganizationIds.Value,
                    _namespacePrefixes.Value,
                    null,
                    null,
                    null,
                    null,
                    new[] { 1 },
                    0));
        }

        public Task<AuthenticateResult> AuthenticateAsync(string token, string authorizationScheme)
        {
            var principal = new ClaimsPrincipal(_identity.Value);
            var ticket = new AuthenticationTicket(principal, CreateAuthenticationProperties(), authorizationScheme);
            return Task.FromResult(AuthenticateResult.Success(ticket));

            AuthenticationProperties CreateAuthenticationProperties()
            {
                var parameters = new Dictionary<string, object>()
                {
                    {
                        "ApiKeyContext", _apiKeyContext.Value
                    }
                };

                var items = new Dictionary<string, string>() { { ".expires", DateTime.UtcNow.AddYears(1).ToString("O") } };

                return new AuthenticationProperties(items, parameters);
            }
        }
    }
}
