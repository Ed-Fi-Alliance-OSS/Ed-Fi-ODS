// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Security.DataAccess.Models;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.Repositories
{
    /// <summary>
    /// Provides higher level access to raw security metadata.
    /// </summary>
    public class SecurityRepository : ISecurityRepository
    {
        private readonly ISecurityTableGateway _securityTableGateway;

        public SecurityRepository(ISecurityTableGateway securityTableGateway)
        {
            _securityTableGateway = securityTableGateway ?? throw new ArgumentNullException(nameof(securityTableGateway));
        }

        public virtual Action GetActionByName(string actionName)
        {
            return _securityTableGateway.GetActions().First(a => a.ActionName.Equals(actionName, StringComparison.OrdinalIgnoreCase));
        }

        public virtual AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName)
        {
            int applicationId = GetApplicationId();

            return _securityTableGateway.GetAuthorizationStrategies(applicationId).First(
                a => a.AuthorizationStrategyName.Equals(authorizationStrategyName, StringComparison.OrdinalIgnoreCase));
        }

        public virtual IList<ClaimSetResourceClaimAction> GetClaimsForClaimSet(string claimSetName)
        {
            int applicationId = GetApplicationId();

            return _securityTableGateway.GetClaimSetResourceClaimActions(applicationId)
                .Where(c => c.ClaimSet.ClaimSetName.Equals(claimSetName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Gets the lineage up the taxonomy of resource claim URIs for the specified resource.
        /// </summary>
        /// <param name="resourceClaimUri">The resource claim URI representing the resource.</param>
        /// <returns>The lineage of resource claim URIs.</returns>
        public virtual IList<string> GetResourceClaimLineage(string resourceClaimUri)
        {
            return GetResourceClaimLineageForResourceClaim(resourceClaimUri)
                .Select(c => c.ClaimName)
                .ToList();
        }

        private IEnumerable<ResourceClaim> GetResourceClaimLineageForResourceClaim(string resourceClaimUri)
        {
            var resourceClaimLineage = new List<ResourceClaim>();

            ResourceClaim resourceClaim;

            try
            {
                int applicationId = GetApplicationId();

                resourceClaim = _securityTableGateway.GetResourceClaims(applicationId)
                    .SingleOrDefault(rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.OrdinalIgnoreCase));
            }
            catch (InvalidOperationException ex)
            {
                // Use InvalidOperationException wrapper with custom message over InvalidOperationException
                // thrown by Linq to communicate back to caller the problem with the configuration.
                throw new InvalidOperationException($"Multiple resource claims with a claim name of '{resourceClaimUri}' were found in the Ed-Fi API's security configuration. Authorization cannot be performed.", ex);
            }

            if (resourceClaim != null)
            {
                resourceClaimLineage.Add(resourceClaim);

                if (resourceClaim.ParentResourceClaim != null)
                {
                    resourceClaimLineage.AddRange(GetResourceClaimLineageForResourceClaim(resourceClaim.ParentResourceClaim.ClaimName));
                }
            }

            return resourceClaimLineage;
        }

        private int GetApplicationId() => _securityTableGateway.GetApplication().ApplicationId;

        /// <summary>
        /// Gets the authorization metadata of the lineage up the resource claim taxonomy for the specified resource claim.
        /// </summary>
        /// <param name="resourceClaimUri">The resource claim URI for which metadata is to be retrieved.</param>
        /// <returns>The resource claim's lineage of authorization metadata.</returns>
        public virtual IList<ResourceClaimAction> GetResourceClaimLineageMetadata(string resourceClaimUri, string action)
        {
            var strategies = new List<ResourceClaimAction>();

            AddStrategiesForResourceClaimLineage(strategies, resourceClaimUri, action);

            return strategies;
        }

        private void AddStrategiesForResourceClaimLineage(List<ResourceClaimAction> strategies, string resourceClaimUri, string action)
        {
            int applicationId = GetApplicationId();

            //check for exact match on resource and action
            var claimAndStrategy = _securityTableGateway.GetResourceClaimActionAuthorizations(applicationId)
                .SingleOrDefault(
                    rcas =>
                        rcas.ResourceClaim.ClaimName.Equals(resourceClaimUri, StringComparison.OrdinalIgnoreCase)
                        && rcas.Action.ActionUri.Equals(action, StringComparison.OrdinalIgnoreCase));

            // Add the claim/strategy if it was found
            if (claimAndStrategy != null)
            {
                strategies.Add(claimAndStrategy);
            }

            var resourceClaim = _securityTableGateway.GetResourceClaims(applicationId)
                .FirstOrDefault(rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.OrdinalIgnoreCase));

            // if there's a parent resource, recurse
            if (resourceClaim is { ParentResourceClaim: not null })
            {
                AddStrategiesForResourceClaimLineage(strategies, resourceClaim.ParentResourceClaim.ClaimName, action);
            }
        }

        public virtual ResourceClaim GetResourceByResourceName(string resourceName)
        {
            int applicationId = GetApplicationId();

            return _securityTableGateway.GetResourceClaims(applicationId)
                .FirstOrDefault(rc => rc.ResourceName.Equals(resourceName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
