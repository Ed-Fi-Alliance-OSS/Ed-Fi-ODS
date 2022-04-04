// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Ods.Features.Redis
{
    internal class SecurityRepository : ISecurityRepository
    {
        public const string SecurityCacheKey = "SecurityRepository";
        public const string ActionsHashField = "Actions";
        public const string AuthorizationStrategiesHashField = "AuthorizationStrategies";
        public const string ClaimSetResourceClaimsHashField = "ClaimSetResourceClaims";
        public const string ResourceClaimsHashField = "ResourceClaims";
        public const string ResourceClaimActionsHashField = "ResourceClaimActions";
        private readonly IRedisCacheProvider _cacheProvider;

        private readonly int _cacheTimeoutInMinutes;
        private readonly ISecurityRepositoryInitializer _securityRepositoryInitializer;

        public SecurityRepository(
            int cacheTimeoutInMinutes,
            IRedisCacheProvider cacheProvider,
            ISecurityRepositoryInitializer securityRepositoryInitializer)
        {
            _cacheTimeoutInMinutes = cacheTimeoutInMinutes;
            _cacheProvider = cacheProvider;
            _securityRepositoryInitializer = securityRepositoryInitializer;
        }

        public Action GetActionByHttpVerb(string httpVerb)
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

        public Action GetActionByName(string actionName)
        {
            List<Action> actions = GetCachedObjectWithRefreshIfNeeded<List<Action>>(ActionsHashField);

            return actions.First(
                a => a.ActionName.Equals(actionName, StringComparison.InvariantCultureIgnoreCase));
        }

        public AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName)
        {
            List<AuthorizationStrategy> authorizationStrategies =
                GetCachedObjectWithRefreshIfNeeded<List<AuthorizationStrategy>>(
                    AuthorizationStrategiesHashField);

            return authorizationStrategies.First(
                a => a.AuthorizationStrategyName
                    .Equals(authorizationStrategyName, StringComparison.InvariantCultureIgnoreCase));
        }

        IEnumerable<ClaimSetResourceClaimAction> ISecurityRepository.GetClaimsForClaimSet(string claimSetName)
        {
            List<ClaimSetResourceClaimAction> claimSetResourceClaims =
                GetCachedObjectWithRefreshIfNeeded<List<ClaimSetResourceClaimAction>>(
                    ClaimSetResourceClaimsHashField);

            return claimSetResourceClaims.Where(
                c => c.ClaimSet.ClaimSetName
                    .Equals(claimSetName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<string> GetResourceClaimLineage(string resourceUri)
        {
            List<ResourceClaim> resourceClaims =
                GetCachedObjectWithRefreshIfNeeded<List<ResourceClaim>>(ResourceClaimsHashField);

            return GetResourceClaimLineageForResourceClaim(resourceUri, resourceClaims)
                .Select(c => c.ClaimName);
        }

        IEnumerable<ResourceClaimAction> ISecurityRepository.GetResourceClaimLineageMetadata(
            string resourceClaimUri,
            string action)
        {
            List<ResourceClaimAction> resourceClaimActions =
                GetCachedObjectWithRefreshIfNeeded<List<ResourceClaimAction>>(ResourceClaimActionsHashField);

            List<ResourceClaim> resourceClaims =
                GetCachedObjectWithRefreshIfNeeded<List<ResourceClaim>>(ResourceClaimsHashField);

            var strategies = new List<ResourceClaimAction>();

            AddStrategiesForResourceClaimLineage(strategies, resourceClaimUri, action, resourceClaimActions, resourceClaims);

            return strategies;
        }

        public ResourceClaim GetResourceByResourceName(string resourceName)
        {
            List<ResourceClaim> resourceClaims =
                GetCachedObjectWithRefreshIfNeeded<List<ResourceClaim>>(ResourceClaimsHashField);

            return resourceClaims.FirstOrDefault(
                rc => rc.ResourceName.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase));
        }

        public void LoadRecordOwnershipData()
        {
            throw new NotImplementedException();
        }

        public void LoadMultipleAuthorizationStrategyData()
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<ResourceClaim> GetResourceClaimLineageForResourceClaim(
            string resourceClaimUri,
            List<ResourceClaim> resourceClaims)
        {
            var resourceClaimLineage = new List<ResourceClaim>();

            ResourceClaim resourceClaim;

            try
            {
                resourceClaim = resourceClaims
                    .SingleOrDefault(
                        rc => rc.ClaimName
                            .Equals(resourceClaimUri, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (InvalidOperationException ex)
            {
                // Use InvalidOperationException wrapper with custom message over InvalidOperationException
                // thrown by Linq to communicate back to caller the problem with the configuration.
                throw new InvalidOperationException(
                    $"Multiple resource claims with a claim name of '{resourceClaimUri}' were found in the Ed-Fi API's security configuration. Authorization cannot be performed.",
                    ex);
            }

            if (resourceClaim != null)
            {
                resourceClaimLineage.Add(resourceClaim);

                if (resourceClaim.ParentResourceClaim != null)
                {
                    resourceClaimLineage.AddRange(
                        GetResourceClaimLineageForResourceClaim(
                            resourceClaim.ParentResourceClaim.ClaimName,
                            resourceClaims));
                }
            }

            return resourceClaimLineage;
        }

        private static void AddStrategiesForResourceClaimLineage(
            List<ResourceClaimAction> strategies,
            string resourceClaimUri,
            string action,
            List<ResourceClaimAction> resourceClaimActions,
            List<ResourceClaim> resourceClaims)
        {
            //check for exact match on resource and action
            var claimAndStrategy = resourceClaimActions
                .SingleOrDefault(
                    rcas =>
                        rcas.ResourceClaim.ClaimName.Equals(
                            resourceClaimUri,
                            StringComparison.InvariantCultureIgnoreCase) &&
                        rcas.Action.ActionUri.Equals(action, StringComparison.InvariantCultureIgnoreCase));

            // Add the claim/strategy if it was found
            if (claimAndStrategy != null)
            {
                strategies.Add(claimAndStrategy);
            }

            var resourceClaim = resourceClaims.FirstOrDefault(
                rc => rc.ClaimName.Equals(resourceClaimUri, StringComparison.InvariantCultureIgnoreCase));

            // if there's a parent resource, recurse
            if (resourceClaim?.ParentResourceClaim != null)
            {
                AddStrategiesForResourceClaimLineage(
                    strategies,
                    resourceClaim.ParentResourceClaim.ClaimName,
                    action,
                    resourceClaimActions,
                    resourceClaims);
            }
        }

        private T GetCachedObjectWithRefreshIfNeeded<T>(string hashField)
        {
            // first try
            if (_cacheProvider.TryGetCachedObjectFromHash(SecurityCacheKey, hashField, out T object1))
            {
                return object1;
            }

            // cache miss -> refresh cache
            _securityRepositoryInitializer.RefreshCacheIfNeeded(_cacheTimeoutInMinutes);

            // second try
            if (_cacheProvider.TryGetCachedObjectFromHash(SecurityCacheKey, hashField, out T object2))
            {
                return object2;
            }

            throw new InvalidOperationException($"Unable to read {hashField} from cache.");
        }
    }
}
