// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace EdFi.Ods.Api.Providers
{
    public class OAuthTokenAuthenticator : IOAuthTokenAuthenticator
    {
        private const string ExpectedUseSandboxValue = "ExpectedUseSandboxValue";

        private readonly IClaimsIdentityProvider _claimsIdentityProvider;
        private readonly Lazy<bool?> _expectedUseSandboxValue;
        private readonly ILog _logger = LogManager.GetLogger(typeof(OAuthTokenAuthenticator));
        private readonly IApiClientDetailsProvider _apiClientDetailsProvider;

        public OAuthTokenAuthenticator(IApiClientDetailsProvider apiClientDetailsProvider,
            IClaimsIdentityProvider claimsIdentityProvider,
            IConfigurationRoot config)
        {
            _apiClientDetailsProvider = apiClientDetailsProvider;
            _claimsIdentityProvider = claimsIdentityProvider;

            _expectedUseSandboxValue = new Lazy<bool?>(
                () => config.GetSection(ExpectedUseSandboxValue).Value == null
                    ? (bool?) null
                    : Convert.ToBoolean(config.GetSection(ExpectedUseSandboxValue).Value));
        }

        /// <inheritdoc cref="IOAuthTokenAuthenticator.AuthenticateAsync" />
        public async Task<AuthenticateResult> AuthenticateAsync(string token, string authorizationScheme)
        {
            ApiClientDetails apiClientDetails;

            try
            {
                // If there are credentials that the filter understands, try to validate them.
                apiClientDetails = await _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(token);
                
                if (!apiClientDetails.IsTokenValid)
                {
                    return AuthenticateResult.Fail("Invalid token");
                }
            }
            catch (DistributedCacheException)
            {
                throw;
            }
            catch (CachingInterceptorCacheKeyGenerationException ex)
            {
                _logger.Debug(ex);
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (_expectedUseSandboxValue.Value.HasValue &&
                apiClientDetails.IsSandboxClient != _expectedUseSandboxValue.Value.Value)
            {
                string message = apiClientDetails.IsSandboxClient
                    ? "Sandbox credentials used in call to Production API"
                    : "Production credentials used in call to Sandbox API";

                return AuthenticateResult.Fail(message);
            }

            var identity = _claimsIdentityProvider.GetClaimsIdentity(apiClientDetails.ClaimSetName);

            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, CreateAuthenticationProperties(), authorizationScheme);
            return AuthenticateResult.Success(ticket);

            AuthenticationProperties CreateAuthenticationProperties()
            {
                var parameters = new Dictionary<string, object>()
                {
                    {
                        "ApiClientContext", 
                        new ApiClientContext(
                            apiClientDetails.ApiKey,
                            apiClientDetails.ClaimSetName,
                            apiClientDetails.EducationOrganizationIds,
                            apiClientDetails.NamespacePrefixes,
                            apiClientDetails.Profiles,
                            apiClientDetails.StudentIdentificationSystemDescriptor,
                            apiClientDetails.CreatorOwnershipTokenId,
                            apiClientDetails.OwnershipTokenIds,
                            apiClientDetails.OdsInstanceIds,
                            apiClientDetails.ApiClientId)
                    }
                };

                var items = new Dictionary<string, string>() { { ".expires", apiClientDetails.ExpiresUtc.ToString("O") } };

                return new AuthenticationProperties(items, parameters);
            }
        }
    }
}