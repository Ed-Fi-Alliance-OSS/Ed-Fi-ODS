// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Utils.Extensions;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.Claims
{
    public class ClaimsIdentityProvider : IClaimsIdentityProvider
    {
        private readonly IApiKeyContextProvider _apiKeyContextProvider;
        private readonly ISecurityRepository _securityRepository;

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

            return GetClaimsIdentity(
                apiKeyContext.EducationOrganizationIds,
                apiKeyContext.ClaimSetName,
                apiKeyContext.NamespacePrefixes,
                apiKeyContext.Profiles.ToList());
        }

        public ClaimsIdentity GetClaimsIdentity(
            IEnumerable<int> educationOrganizationIds,
            string claimSetName,
            IEnumerable<string> namespacePrefixes,
            IReadOnlyList<string> assignedProfileNames)
        {
            var nonEmptyNamespacePrefixes = namespacePrefixes.Where(np => !string.IsNullOrWhiteSpace(np)).ToList();

            var resourceClaims = _securityRepository.GetClaimsForClaimSet(claimSetName);

            // Group the resource claims by name to combine actions (and by claim set name if multiple claim sets are supported in the future)
            var resourceClaimsByClaimName = resourceClaims.GroupBy(c => c.ResourceClaim.ClaimName);

            // Create a list of resource claims to be issued.
            var claims = resourceClaimsByClaimName.Select(
                    g => new
                    {
                        ClaimName = g.Key,
                        ClaimValue = new EdFiResourceClaimValue
                        {
                            Actions = g.Select(
                                    x => new ResourceAction(
                                        x.Action.ActionUri,
                                        x.AuthorizationStrategyOverride == null
                                            ? null
                                            : x.AuthorizationStrategyOverride.AuthorizationStrategyName,
                                        x.ValidationRuleSetNameOverride))
                                .ToArray(),
                            EducationOrganizationIds = educationOrganizationIds.ToList()
                        }
                    })
                .Select(x => JsonClaimHelper.CreateClaim(x.ClaimName, x.ClaimValue))
                .ToList();

            // NamespacePrefixes
            nonEmptyNamespacePrefixes.ForEach(
                namespacePrefix => claims.Add(new Claim(EdFiOdsApiClaimTypes.NamespacePrefix, namespacePrefix)));

            // Add Assigned Profile names
            assignedProfileNames.ForEach(profileName => claims.Add(new Claim(EdFiOdsApiClaimTypes.Profile, profileName)));

            return new ClaimsIdentity(claims, EdFiAuthenticationTypes.OAuth);
        }
    }
}
