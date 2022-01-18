using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Security.DataAccess.Models;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.Repositories
{
    //NOTE: This class is placed in EdFi.Ods.Api to remove cyclic dependency on InstanceSecurityRepositoryCache
    public class InstanceSecurityRepository : ISecurityRepository
    {
        private readonly IInstanceIdContextProvider _instanceIdContextProvider;

        public InstanceSecurityRepository(IInstanceIdContextProvider instanceIdContextProvider)
        {
            _instanceIdContextProvider = Preconditions.ThrowIfNull(instanceIdContextProvider, nameof(instanceIdContextProvider));
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
            var instanceId = _instanceIdContextProvider.GetInstanceId();
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            var instanceSecurityRepoCacheObject = InstanceSecurityRepositoryCache.GetCache()
                .GetSecurityRepository(instanceId);

            return instanceSecurityRepoCacheObject.Actions.First(a => a.ActionName.Equals(actionName, StringComparison.InvariantCultureIgnoreCase));
        }

        public virtual AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName)
        {
            var instanceId = _instanceIdContextProvider.GetInstanceId();
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            var instanceSecurityRepoCacheObject = InstanceSecurityRepositoryCache.GetCache()
                .GetSecurityRepository(instanceId);

            return instanceSecurityRepoCacheObject.AuthorizationStrategies.First(
                a => a.AuthorizationStrategyName.Equals(authorizationStrategyName, StringComparison.InvariantCultureIgnoreCase));
        }

        public virtual IEnumerable<ClaimSetResourceClaim> GetClaimsForClaimSet(string claimSetName)
        {
            var instanceId = _instanceIdContextProvider.GetInstanceId();
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            var instanceSecurityRepoCacheObject = InstanceSecurityRepositoryCache.GetCache()
                .GetSecurityRepository(instanceId);

            return instanceSecurityRepoCacheObject.ClaimSetResourceClaims.Where(c => c.ClaimSet.ClaimSetName.Equals(claimSetName, StringComparison.InvariantCultureIgnoreCase));
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
            var instanceId = _instanceIdContextProvider.GetInstanceId();
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            var instanceSecurityRepoCacheObject = InstanceSecurityRepositoryCache.GetCache()
                .GetSecurityRepository(instanceId);

            var resourceClaimLineage = new List<ResourceClaim>();

            ResourceClaim resourceClaim;

            try
            {
                resourceClaim = instanceSecurityRepoCacheObject.ResourceClaims
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
        /// <param name="action">The action for claim.</param>
        /// <returns>The resource claim's lineage of authorization metadata.</returns>
        public virtual IEnumerable<ResourceClaimAuthorizationMetadata> GetResourceClaimLineageMetadata(string resourceClaimUri, string action)
        {
            var strategies = new List<ResourceClaimAuthorizationMetadata>();

            AddStrategiesForResourceClaimLineage(strategies, resourceClaimUri, action);

            return strategies;
        }

        private void AddStrategiesForResourceClaimLineage(List<ResourceClaimAuthorizationMetadata> strategies, string resourceClaimUri, string action)
        {
            var instanceId = _instanceIdContextProvider.GetInstanceId();
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            var instanceSecurityRepoCacheObject = InstanceSecurityRepositoryCache.GetCache()
                .GetSecurityRepository(instanceId);

            //check for exact match on resource and action
            var claimAndStrategy = instanceSecurityRepoCacheObject.ResourceClaimAuthorizationMetadata
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
                instanceSecurityRepoCacheObject.ResourceClaims.FirstOrDefault(rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.InvariantCultureIgnoreCase));

            // if there's a parent resource, recurse
            if (resourceClaim != null && resourceClaim.ParentResourceClaim != null)
            {
                AddStrategiesForResourceClaimLineage(strategies, resourceClaim.ParentResourceClaim.ClaimName, action);
            }
        }

        public virtual ResourceClaim GetResourceByResourceName(string resourceName)
        {
            var instanceId = _instanceIdContextProvider.GetInstanceId();
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new InvalidOperationException("Expected instanceId is null or empty.");
            }

            var instanceSecurityRepoCacheObject = InstanceSecurityRepositoryCache.GetCache()
                .GetSecurityRepository(instanceId);

            return instanceSecurityRepoCacheObject.ResourceClaims.FirstOrDefault(rc => rc.ResourceName.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}