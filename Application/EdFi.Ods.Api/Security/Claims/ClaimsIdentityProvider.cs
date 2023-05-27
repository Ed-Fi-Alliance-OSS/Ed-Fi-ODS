// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Security.Claims
{
    public class ClaimsIdentityProvider : IClaimsIdentityProvider
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly ISecurityRepository _securityRepository;

        private const string ServicesClaimNamePrefix = "http://ed-fi.org/ods/identity/claims/services/";

        public ClaimsIdentityProvider(IApiKeyContextProvider apiKeyContextProvider, ISecurityRepository securityRepository)
        {
            _apiKeyContextProvider = apiKeyContextProvider;
            _securityRepository = securityRepository;
        }

        public ClaimsIdentity GetClaimsIdentity()
        {
            // Get the Education Organization Ids for the current context
            var apiKeyContext = _apiKeyContextProvider.GetApiKeyContext();

            if (apiKeyContext == null || apiKeyContext == ApiKeyContext.Empty)
            {
                throw new EdFiSecurityException("No API key information was available for authorization.");
            }

            return GetClaimsIdentity(apiKeyContext.ClaimSetName);
        }

        // Clear pre-built claims every 30 minutes (but if underlying security metadata changes more frequently, new claims will be built and reused)
        private readonly ExpiringConcurrentDictionaryCacheProvider<IReadOnlyList<ClaimSetResourceClaimAction>> _claimsByResourceClaimActions
            = new("Claims", TimeSpan.FromMinutes(30));

        public ClaimsIdentity GetClaimsIdentity(string claimSetName)
        {
            var resourceClaims = _securityRepository.GetClaimsForClaimSet(claimSetName);

            if (!_claimsByResourceClaimActions.TryGetCachedObject(resourceClaims, out object value))
            {
                // Group the resource claims by name to combine actions (and by claim set name if multiple claim sets are supported in the future)
                var servicesResourceClaimsByClaimName = resourceClaims
                    .Where(rc => rc.ResourceClaim.ClaimName.StartsWith(ServicesClaimNamePrefix))
                    .GroupBy(c => c.ResourceClaim.ClaimName);

                // Create a list of service claims to be issued.
                var claims = servicesResourceClaimsByClaimName.Select(
                        g => new EdFiResourceClaim(g.Key,
                            new EdFiResourceClaimValue
                            {
                                Actions = g.Select(
                                        x => new ResourceAction(
                                            x.Action.ActionUri,
                                            x.AuthorizationStrategyOverrides
                                                ?.Select(y => y.AuthorizationStrategy.AuthorizationStrategyName)
                                                .ToArray(),
                                            x.ValidationRuleSetNameOverride))
                                    .ToArray()
                            }))
                    .Select(x => new Claim(x.ClaimName, string.Join(",", x.ClaimValue.Actions.Select(a => a.Name))))
                    .ToList();
                
                _claimsByResourceClaimActions.SetCachedObject(resourceClaims, claims);

                return new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth);
            }

            return new ClaimsIdentity(value as IReadOnlyList<Claim>, EdFiAuthenticationTypes.OAuth);
        }
    }
}