// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using EdFi.Security.DataAccess.Contexts;

namespace EdFi.Ods.Features.Redis
{
    internal class SecurityRepositoryInitializer : ISecurityRepositoryInitializer
    {
        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly IRedisCacheProvider _cacheProvider;
        private readonly ISecurityContextFactory _securityContextFactory;

        public SecurityRepositoryInitializer(
            ISecurityContextFactory securityContextFactory,
            IRedisCacheProvider cacheProvider)
        {
            _securityContextFactory = securityContextFactory;
            _cacheProvider = cacheProvider;
        }

        public void RefreshCacheIfNeeded(int cacheTimeoutInMinutes)
        {
            if (_cacheProvider.KeyExists(SecurityRepository.SecurityCacheKey))
            {
                return;
            }

            _cacheLock.EnterUpgradeableReadLock();

            try
            {
                if (_cacheProvider.KeyExists(SecurityRepository.SecurityCacheKey))
                {
                    return;
                }

                _cacheLock.EnterWriteLock();

                try
                {
                    LoadSecurityConfigurationFromDatabase(cacheTimeoutInMinutes);
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

        private void LoadSecurityConfigurationFromDatabase(int cacheTimeoutInMinutes)
        {
            using var context = _securityContextFactory.CreateContext();

            var application =
                context.Applications.First(
                    app =>
                        app.ApplicationName.Equals("Ed-Fi ODS API", StringComparison.InvariantCultureIgnoreCase));

            var actions = context.Actions.ToList();

            var resourceClaims = context.ResourceClaims.Include(rc => rc.Application)
                .Include(rc => rc.ParentResourceClaim)
                .Where(rc => rc.Application.ApplicationId.Equals(application.ApplicationId))
                .ToList();

            var authorizationStrategies = context.AuthorizationStrategies.Include(auth => auth.Application)
                .Where(auth => auth.Application.ApplicationId.Equals(application.ApplicationId))
                .ToList();

            var claimSetResourceClaims = context.ClaimSetResourceClaimActions.Include(csrc => csrc.Action)
                .Include(csrc => csrc.ClaimSet)
                .Include(csrc => csrc.ResourceClaim)
                .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                .ToList();

            var resourceClaimActions =
                context.ResourceClaimActions.Include(rcas => rcas.Action)
                    .Include(rcas => rcas.AuthorizationStrategies)
                    .Include(rcas => rcas.ResourceClaim)
                    .Where(
                        rcas =>
                            rcas.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                    .ToList();

            Dictionary<string, object> securityDictionary = new Dictionary<string, object>
            {
                { SecurityRepository.ActionsHashField, actions },
                { SecurityRepository.ResourceClaimsHashField, resourceClaims },
                { SecurityRepository.AuthorizationStrategiesHashField, authorizationStrategies },
                { SecurityRepository.ClaimSetResourceClaimsHashField, claimSetResourceClaims },
                { SecurityRepository.ResourceClaimActionsHashField, resourceClaimActions }
            };

            _cacheProvider.Insert(
                SecurityRepository.SecurityCacheKey,
                securityDictionary,
                DateTime.MaxValue,
                TimeSpan.FromMinutes(cacheTimeoutInMinutes));
        }
    }
}
