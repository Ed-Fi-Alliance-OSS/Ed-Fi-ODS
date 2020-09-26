// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Services.Authentication
{
    public class OAuthAuthenticationProvider : IAuthenticationProvider
    {
        private const string AuthenticationScheme = "Bearer";

        public OAuthAuthenticationProvider(
            IOAuthTokenValidator oauthTokenValidator,
            IApiKeyContextProvider apiKeyContextProvider,
            IClaimsIdentityProvider claimsIdentityProvider,
            IBearerTokenHeaderProcessor bearerTokenHeaderProcessor)
        {
            BearerTokenHeaderProcessor = bearerTokenHeaderProcessor;
            OAuthTokenValidator = oauthTokenValidator;
            ApiKeyContextProvider = apiKeyContextProvider;
            ClaimsIdentityProvider = claimsIdentityProvider;
        }

        public IBearerTokenHeaderProcessor BearerTokenHeaderProcessor { get; set; }

        public IOAuthTokenValidator OAuthTokenValidator { get; set; }

        public IApiKeyContextProvider ApiKeyContextProvider { get; set; }

        public IClaimsIdentityProvider ClaimsIdentityProvider { get; set; }

        public async Task Authenticate(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // Don't reprocess bearer token, if API key context has already been set
            if (!ApiKeyContextProvider.GetApiKeyContext().IsNullOrEmpty())
            {
                return;
            }
            
            var bearerTokenResult = await BearerTokenHeaderProcessor.ProcessAsync(context.Request, cancellationToken);

            if (bearerTokenResult.Error != null)
            {
                context.ErrorResult = bearerTokenResult.Error;
            }
            
            if (bearerTokenResult.ApiClientDetails != null)
            {
                var apiClientDetails = bearerTokenResult.ApiClientDetails;

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
