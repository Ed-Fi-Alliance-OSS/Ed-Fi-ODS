// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Services.Authentication
{
    public class OAuthAuthenticationProvider : IAuthenticationProvider
    {
        private const string AuthenticationScheme = "Bearer";
        private const string ExpectedUseSandboxValue = "ExpectedUseSandboxValue";
        private readonly Lazy<bool?> _expectedUseSandboxValue;

        public OAuthAuthenticationProvider(
            IOAuthTokenValidator oauthTokenValidator,
            IApiKeyContextProvider apiKeyContextProvider,
            IClaimsIdentityProvider claimsIdentityProvider,
            IConfigValueProvider configValueProvider)
        {
            OAuthTokenValidator = oauthTokenValidator;
            ApiKeyContextProvider = apiKeyContextProvider;
            ClaimsIdentityProvider = claimsIdentityProvider;

            _expectedUseSandboxValue = new Lazy<bool?>(
                () => configValueProvider.GetValue(ExpectedUseSandboxValue) == null
                    ? (bool?) null
                    : Convert.ToBoolean(configValueProvider.GetValue(ExpectedUseSandboxValue)));
        }

        public IOAuthTokenValidator OAuthTokenValidator { get; set; }

        public IApiKeyContextProvider ApiKeyContextProvider { get; set; }

        public IClaimsIdentityProvider ClaimsIdentityProvider { get; set; }

        public async Task Authenticate(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                return;
            }

            // 3. If there are credentials but the filter does not recognize the 
            //    authentication scheme, do nothing.
            if (!authorization.Scheme.EqualsIgnoreCase(AuthenticationScheme))
            {
                return;
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing parameter", request);
                return;
            }

            // Validate the token and get the corresponding API key details
            var apiClientDetails = await OAuthTokenValidator.GetClientDetailsForTokenAsync(authorization.Parameter);

            if (!apiClientDetails.IsTokenValid)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
                return;
            }

            if (_expectedUseSandboxValue.Value.HasValue &&
                apiClientDetails.IsSandboxClient != _expectedUseSandboxValue.Value.Value)
            {
                var message = apiClientDetails.IsSandboxClient
                    ? "Sandbox credentials used in call to Production API"
                    : "Production credentials used in call to Sandbox API";

                context.ErrorResult = new AuthenticationFailureResult(message, request);
                return;
            }

            // Store API key details into context
            ApiKeyContextProvider.SetApiKeyContext(
                new ApiKeyContext(
                    apiClientDetails.ApiKey,
                    apiClientDetails.ClaimSetName,
                    apiClientDetails.EducationOrganizationIds,
                    apiClientDetails.NamespacePrefixes,
                    apiClientDetails.Profiles,
                    apiClientDetails.StudentIdentificationSystemDescriptor,
                    apiClientDetails.CreatorOwnershipTokenId,
                    apiClientDetails.OwnershipTokenIds));

            var claimsIdentity = ClaimsIdentityProvider.GetClaimsIdentity(
                apiClientDetails.EducationOrganizationIds,
                apiClientDetails.ClaimSetName,
                apiClientDetails.NamespacePrefixes,
                apiClientDetails.Profiles.ToList());

            context.Principal = new ClaimsPrincipal(claimsIdentity);
        }

        public async Task Challenge(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);

            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(AuthenticationScheme, Guid.Empty.ToString()));
            }

            context.Result = new ResponseMessageResult(result);
        }
    }
}
