// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.NetCore.Middleware;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Api.NetCore.Providers
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private const string ExpectedUseSandboxValue = "ExpectedUseSandboxValue";
        private const string AuthenticationScheme = "Bearer";

        private readonly IClaimsIdentityProvider _claimsIdentityProvider;
        private readonly Lazy<bool?> _expectedUseSandboxValue;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AuthenticationProvider));
        private readonly IOAuthTokenValidator _oAuthTokenValidator;

        public AuthenticationProvider(IOAuthTokenValidator oAuthTokenValidator,
            IClaimsIdentityProvider claimsIdentityProvider,
            IConfigurationRoot config)
        {
            _oAuthTokenValidator = oAuthTokenValidator;
            _claimsIdentityProvider = claimsIdentityProvider;

            _expectedUseSandboxValue = new Lazy<bool?>(
                () => config.GetSection(ExpectedUseSandboxValue).Value == null
                    ? (bool?) null
                    : Convert.ToBoolean(config.GetSection(ExpectedUseSandboxValue).Value));
        }

        public async Task<AuthenticationResult> GetAuthenticationResultAsync(AuthenticationHeaderValue authHeader)
        {
            ApiClientDetails apiClientDetails;

            try
            {
                // If there are credentials but the filter does not recognize the authentication scheme, do nothing.
                if (!authHeader.Scheme.EqualsIgnoreCase(AuthenticationScheme))
                {
                    _logger.Debug("Unknown auth header scheme");
                    return new AuthenticationResult {AuthenticateResult = AuthenticateResult.NoResult()};
                }

                // If the credentials are bad, set the error result.
                if (string.IsNullOrEmpty(authHeader.Parameter))
                {
                    _logger.Debug("Missing auth header parameter");

                    return new AuthenticationResult
                    {
                        AuthenticateResult = AuthenticateResult.Fail("Missing auth header parameter")
                    };
                }

                // If there are credentials that the filter understands, try to validate them.
                apiClientDetails = await _oAuthTokenValidator.GetClientDetailsForTokenAsync(authHeader.Parameter);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return new AuthenticationResult {AuthenticateResult = AuthenticateResult.Fail("Invalid Authorization Header")};
            }

            if (_expectedUseSandboxValue.Value.HasValue &&
                apiClientDetails.IsSandboxClient != _expectedUseSandboxValue.Value.Value)
            {
                string message = apiClientDetails.IsSandboxClient
                    ? "Sandbox credentials used in call to Production API"
                    : "Production credentials used in call to Sandbox API";

                return new AuthenticationResult {AuthenticateResult = AuthenticateResult.Fail(message)};
            }

            var identity = _claimsIdentityProvider.GetClaimsIdentity(
                apiClientDetails.EducationOrganizationIds,
                apiClientDetails.ClaimSetName,
                apiClientDetails.NamespacePrefixes,
                apiClientDetails.Profiles.ToList());

            var apiKeyContext = new ApiKeyContext(
                apiClientDetails.ApiKey,
                apiClientDetails.ClaimSetName,
                apiClientDetails.EducationOrganizationIds,
                apiClientDetails.NamespacePrefixes,
                apiClientDetails.Profiles,
                apiClientDetails.StudentIdentificationSystemDescriptor,
                apiClientDetails.CreatorOwnershipTokenId,
                apiClientDetails.OwnershipTokenIds);

            return new AuthenticationResult
            {
                ClaimsIdentity = identity,
                ApiKeyContext = apiKeyContext
            };
        }
    }
}
