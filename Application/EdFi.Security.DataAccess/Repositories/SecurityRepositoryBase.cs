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
    public abstract class SecurityRepositoryBase
    {
        protected Application Application { get; private set; }

        protected List<Action> Actions { get; private set; }

        protected List<ClaimSet> ClaimSets { get; private set; }

        protected List<ResourceClaim> ResourceClaims { get; private set; }

        protected List<AuthorizationStrategy> AuthorizationStrategies { get; private set; }

        protected List<ClaimSetResourceClaim> ClaimSetResourceClaims { get; private set; }

        protected List<ResourceClaimAuthorizationMetadata> ResourceClaimAuthorizationMetadata { get; private set; }

        protected void Initialize(
            Application application,
            List<Action> actions,
            List<ClaimSet> claimSets,
            List<ResourceClaim> resourceClaims,
            List<AuthorizationStrategy> authorizationStrategies,
            List<ClaimSetResourceClaim> claimSetResourceClaims,
            List<ResourceClaimAuthorizationMetadata> resourceClaimAuthorizationMetadata)
        {
            Application = application;
            Actions = actions;
            ClaimSets = claimSets;
            ResourceClaims = resourceClaims;
            AuthorizationStrategies = authorizationStrategies;
            ClaimSetResourceClaims = claimSetResourceClaims;
            ResourceClaimAuthorizationMetadata = resourceClaimAuthorizationMetadata;
        }

        public virtual Action GetActionByHttpVerb(string httpVerb)
        {
            string actionName = string.Empty;

            switch (httpVerb)
            {
                case "GET":
                    actionName = "Read";
                    break;
                case "POST":
                    actionName = "Create";
                    break;
                case "PUT":
                    actionName = "Update";
                    break;
                case "DELETE":
                    actionName = "Delete";
                    break;
            }

            return GetActionByName(actionName);
        }

        public virtual Action GetActionByName(string actionName)
        {
            return Actions.First(a => a.ActionName.Equals(actionName, StringComparison.InvariantCultureIgnoreCase));
        }

        public virtual AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName)
        {
            return AuthorizationStrategies.First(
                a => a.AuthorizationStrategyName.Equals(authorizationStrategyName, StringComparison.InvariantCultureIgnoreCase));
        }

        public virtual IEnumerable<ClaimSetResourceClaim> GetClaimsForClaimSet(string claimSetName)
        {
            return ClaimSetResourceClaims.Where(c => c.ClaimSet.ClaimSetName.Equals(claimSetName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Gets the lineage up the taxonomy of resource claim URIs for the specified resource.
        /// </summary>
        /// <param name="resourceClaimUri">The resource claim URI representing the resource.</param>
        /// <returns>The lineage of resource claim URIs.</returns>
        public virtual IEnumerable<string> GetResourceClaimLineage(string resourceClaimUri)
        {
            return GetResourceClaimLineageForResourceClaim(resourceClaimUri)
               .Select(c => c.ClaimName);
        }

        private IEnumerable<ResourceClaim> GetResourceClaimLineageForResourceClaim(string resourceClaimUri)
        {
            var resourceClaimLineage = new List<ResourceClaim>();

            ResourceClaim resourceClaim;

            try
            {
                resourceClaim = ResourceClaims
                    .SingleOrDefault(rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.InvariantCultureIgnoreCase));
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

        /// <summary>
        /// Gets the authorization metadata of the lineage up the resource claim taxonomy for the specified resource claim.
        /// </summary>
        /// <param name="resourceClaimUri">The resource claim URI for which metadata is to be retrieved.</param>
        /// <returns>The resource claim's lineage of authorization metadata.</returns>
        public virtual IEnumerable<ResourceClaimAuthorizationMetadata> GetResourceClaimLineageMetadata(string resourceClaimUri, string action)
        {
            var strategies = new List<ResourceClaimAuthorizationMetadata>();

            AddStrategiesForResourceClaimLineage(strategies, resourceClaimUri, action);

            return strategies;
        }

        private void AddStrategiesForResourceClaimLineage(List<ResourceClaimAuthorizationMetadata> strategies, string resourceClaimUri, string action)
        {
            //check for exact match on resource and action
            var claimAndStrategy = ResourceClaimAuthorizationMetadata
               .SingleOrDefault(
                    rcas =>
                        rcas.ResourceClaim.ClaimName.Equals(resourceClaimUri, StringComparison.InvariantCultureIgnoreCase)
                        && rcas.Action.ActionUri.Equals(action, StringComparison.InvariantCultureIgnoreCase));

            // Add the claim/strategy if it was found
            if (claimAndStrategy != null)
            {
                strategies.Add(claimAndStrategy);
            }

            var resourceClaim =
                ResourceClaims.FirstOrDefault(rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.InvariantCultureIgnoreCase));

            // if there's a parent resource, recurse
            if (resourceClaim != null && resourceClaim.ParentResourceClaim != null)
            {
                AddStrategiesForResourceClaimLineage(strategies, resourceClaim.ParentResourceClaim.ClaimName, action);
            }
        }

        public virtual ResourceClaim GetResourceByResourceName(string resourceName)
        {
            return ResourceClaims.FirstOrDefault(rc => rc.ResourceName.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
