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

namespace EdFi.Ods.WebApi.CompositeSpecFlowTests
{
    public class FakedAuthenticationProvider : IAuthenticationProvider
    {
        private const string ClaimSetName = "Ed-Fi Sandbox";
        private readonly Lazy<ApiKeyContext> _apiKeyContext;
        private readonly Lazy<List<int>> _educationOrganizationIds;
        private readonly Lazy<ClaimsIdentity> _identity;
        private readonly Lazy<List<string>> _namespacePrefixes;

        public FakedAuthenticationProvider(IClaimsIdentityProvider claimsIdentityProvider)
        {
            _namespacePrefixes = new Lazy<List<string>>(() => new List<string> {"uri://ed-fi.org"});
            _educationOrganizationIds = new Lazy<List<int>>(() => new List<int> {255901});

            _identity = new Lazy<ClaimsIdentity>(
                () => claimsIdentityProvider
                    .GetClaimsIdentity(
                        _educationOrganizationIds.Value, ClaimSetName, _namespacePrefixes.Value, new List<string>(), new List<short?>()));

            _apiKeyContext = new Lazy<ApiKeyContext>(
                () => new ApiKeyContext(
                    Guid.NewGuid().ToString("n"),
                    ClaimSetName,
                    _educationOrganizationIds.Value,
                    _namespacePrefixes.Value,
                    null,
                    null,
                    null,
                    null));
        }

        public Task<AuthenticationResult> GetAuthenticationResultAsync(AuthenticationHeaderValue authHeader)
        {
            return Task.FromResult(
                new AuthenticationResult
                {
                    ClaimsIdentity = _identity.Value,
                    ApiKeyContext = _apiKeyContext.Value
                });
        }
    }
}
