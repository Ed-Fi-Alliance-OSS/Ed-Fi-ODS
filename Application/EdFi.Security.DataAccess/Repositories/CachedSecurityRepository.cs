// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using EdFi.Common.Extensions;
using EdFi.Common.Utils;
using EdFi.Security.DataAccess.Contexts;
using EdFi.Security.DataAccess.Models;
using Action = EdFi.Security.DataAccess.Models.Action;

namespace EdFi.Security.DataAccess.Repositories
{
    public class CachedSecurityRepository : SecurityRepository
    {
        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly int _cacheTimeoutInMinutes;

        private DateTime _lastCacheUpdate;

        public CachedSecurityRepository(ISecurityContextFactory securityContextFactory, int cacheTimeoutInMinutes)
            : base(securityContextFactory)
        {
            if (cacheTimeoutInMinutes <= 0)
            {
                throw new ArgumentException("Cache Timeout in minutes must be a positive number.", nameof(cacheTimeoutInMinutes));
            }

            _cacheTimeoutInMinutes = cacheTimeoutInMinutes;

            // Current implementation of the base expects to initialize the data immediately, so reflect that with a cache update
            _lastCacheUpdate = SystemClock.Now();
        }

        private bool ShouldUpdateCache
        {
            get => _lastCacheUpdate.IsDefaultValue() || SystemClock.Now() >= _lastCacheUpdate.AddMinutes(_cacheTimeoutInMinutes);
        }

        public override Action GetActionByHttpVerb(string httpVerb)
            => VerifyCacheAndExecute(() => base.GetActionByHttpVerb(httpVerb));

        public override Action GetActionByName(string actionName)
            => VerifyCacheAndExecute(() => base.GetActionByName(actionName));

        public override AuthorizationStrategy GetAuthorizationStrategyByName(string authorizationStrategyName)
            => VerifyCacheAndExecute(() => base.GetAuthorizationStrategyByName(authorizationStrategyName));

        public override IEnumerable<ClaimSetResourceClaimAction> GetClaimsForClaimSet(string claimSetName)
            => VerifyCacheAndExecute(() => base.GetClaimsForClaimSet(claimSetName));

        public override IEnumerable<string> GetResourceClaimLineage(string resourceUri)
            => VerifyCacheAndExecute(() => base.GetResourceClaimLineage(resourceUri));

        public override IEnumerable<ResourceClaimAction>
            GetResourceClaimLineageMetadata(string resourceClaimUri, string action)
            => VerifyCacheAndExecute(() => base.GetResourceClaimLineageMetadata(resourceClaimUri, action));

        public override ResourceClaim GetResourceByResourceName(string resourceName)
            => VerifyCacheAndExecute(() => base.GetResourceByResourceName(resourceName));

        private T VerifyCacheAndExecute<T>(Func<T> executionFunction)
        {
            RefreshCacheIfNeeded();
            return executionFunction();
        }

        private void RefreshCacheIfNeeded()
        {
            if (!ShouldUpdateCache)
            {
                return;
            }

            _cacheLock.EnterUpgradeableReadLock();

            try
            {
                if (!ShouldUpdateCache)
                {
                    return;
                }

                _cacheLock.EnterWriteLock();

                try
                {
                    LoadSecurityConfigurationFromDatabase();
                    _lastCacheUpdate = SystemClock.Now();
                }
                finally
                {
                    _cacheLock.ExitWriteLock();
                }
            }
            finally
            {
                _cacheLock.ExitUpgradeableReadLock();
            }
        }
    }
}
