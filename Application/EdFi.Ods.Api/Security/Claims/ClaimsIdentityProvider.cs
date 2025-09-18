// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Caching.SingleFlight;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Security.Claims
{
    public class ClaimsIdentityProvider : IClaimsIdentityProvider
    {
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly ISecurityRepository _securityRepository;

        private const string ServicesClaimNamePrefix = "http://ed-fi.org/ods/identity/claims/services/";

        public ClaimsIdentityProvider(IApiClientContextProvider apiClientContextProvider, ISecurityRepository securityRepository)
        {
            _apiClientContextProvider = apiClientContextProvider;
            _securityRepository = securityRepository;
        }

        public ClaimsIdentity GetClaimsIdentity()
        {
            // Get the Education Organization Ids for the current context
            var apiClientContext = _apiClientContextProvider.GetApiClientContext();

            if (apiClientContext == null || apiClientContext == ApiClientContext.Empty)
            {
                throw new SecurityAuthorizationException(
                    SecurityAuthorizationException.DefaultTechnicalProblemDetail + " No information was available about the caller.",
                    "No API client details were available for performing authorization.")
                {
                    InstanceTypeParts = ["no-client-details"]
                };
            }

            return GetClaimsIdentity(apiClientContext.ClaimSetName);
        }

        // Clear pre-built claims from memory every 30 minutes (but if underlying security metadata changes more frequently, new claims will be built and used instead)
        private readonly ExpiringSingleFlightCache<IList<ClaimSetResourceClaimAction>, IEnumerable<Claim>> _claimsByResourceClaimActions
            = new("Claim Set Resource Claims", TimeSpan.FromMinutes(30), TimeSpan.FromSeconds(60));

        public ClaimsIdentity GetClaimsIdentity(string claimSetName)
        {
            var resourceClaimsActions = _securityRepository.GetClaimsForClaimSet(claimSetName);

            var serviceClaims = _claimsByResourceClaimActions.GetOrCreateAsync(resourceClaimsActions,
                (key, rca, ct) =>
                {
                    // Group the resource claims by name to combine actions (and by claim set name if multiple claim sets are supported in the future)
                    var servicesResourceClaimsByClaimName = rca
                        .Where(rc => rc.ResourceClaim.ClaimName.StartsWith(ServicesClaimNamePrefix))
                        .GroupBy(c => c.ResourceClaim.ClaimName);

                    // Create a list of service claims to be issued.
                    return Task.FromResult(servicesResourceClaimsByClaimName.Select(
                            g => 
                                new ClaimSetResourceClaimMetadata(g.Key,
                                    g
                                        .Select(x => new ResourceAction(x.Action.ActionUri))
                                        .ToArray()
                                ))
                        .Select(x => new Claim(x.ClaimName, string.Join(",", x.Actions.Select(a => a.Name))))
                        .ToList()
                        .AsEnumerable());
                }, resourceClaimsActions, CancellationToken.None)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();;

            return new ClaimsIdentity(serviceClaims, EdFiAuthenticationTypes.OAuth);
        }
    }
}
