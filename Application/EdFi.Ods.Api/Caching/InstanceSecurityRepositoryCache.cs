using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using EdFi.Common;
using EdFi.Common.Utils;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Caching;
using EdFi.Security.DataAccess.Caching;
using EdFi.Security.DataAccess.Contexts;

namespace EdFi.Ods.Api.Caching
{
    //NOTE: This class is placed in EdFi.Ods.Api to remove cyclic dependency on MemoryCacheProvider etc.
    public class InstanceSecurityRepositoryCache : IInstanceSecurityRepositoryCache
    {
        // This exists as a place to put a global singleton of the SecurityRepository Cache.
        public static Func<IInstanceSecurityRepositoryCache> GetCache = () => null;

        private const int DatabaseSynchronizationExpirationSeconds = 3600; // seconds in an hour
        private const string InitializedKeyPrefix = "SecurityRepositoriesCache.Initialized";
        private const string LastSyncedKey = "SecurityRepositoriesCache.LastSynced";
        private const string EdFiOdsApi = "Ed-Fi ODS API";

        private readonly object _cacheInitializationLocker = new object();

        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly ISecurityContextFactory _securityContextFactory;
        private readonly ICacheProvider _cacheProvider;

        public InstanceSecurityRepositoryCache(ISecurityContextFactory securityContextFactory, ICacheProvider cacheProvider)
        {
            _securityContextFactory = Preconditions.ThrowIfNull(securityContextFactory, nameof(securityContextFactory));
            _cacheProvider = Preconditions.ThrowIfNull(cacheProvider, nameof(cacheProvider));
        }

        #region Cache Code
        private void EnsureCacheInitialized(string instanceId)
        {
            object initializedAsObject;

            string cacheKey = GetCurrentCacheInitializedKey(instanceId);

            if (!_cacheProvider.TryGetCachedObject(cacheKey, out initializedAsObject))
            {
                // Make sure there is only one cache set being initialized at a time
                lock (_cacheInitializationLocker)
                {
                    if (!_cacheProvider.TryGetCachedObject(cacheKey, out initializedAsObject))
                    {
                        TryRefreshCache(instanceId, force: true);

                        _cacheProvider.SetCachedObject(cacheKey, true);
                    }
                }
            }
        }

        private bool HasLastDatabaseSynchronizationExpired(string instanceId)
        {
            var currentTime = SystemClock.Now();

            if (!_cacheProvider.TryGetCachedObject(GetLastSynchedKey(instanceId), out object lastSynced))
            {
                lastSynced = DateTime.MinValue;
            }

            var totalSeconds = (currentTime - (DateTime)lastSynced).TotalSeconds;
            return totalSeconds > DatabaseSynchronizationExpirationSeconds;
        }

        private string GetCurrentCacheInitializedKey(string instanceId)
        {
            return InitializedKeyPrefix + "." + instanceId;
        }

        private string GetLastSynchedKey(string instanceId)
        {
            return LastSyncedKey + "." + instanceId;
        }

        private bool TryRefreshCache(string instanceId, bool force = false)
        {

            if (force || HasLastDatabaseSynchronizationExpired(instanceId))
            {
                _cacheLock.EnterUpgradeableReadLock();

                try
                {
                    if (force || HasLastDatabaseSynchronizationExpired(instanceId))
                    {
                        _cacheLock.EnterWriteLock();

                        try
                        {

                            LoadSecurityConfigurationFromDatabaseAndAddToCache(instanceId);

                            _cacheProvider.SetCachedObject(GetLastSynchedKey(instanceId), SystemClock.Now());
                        }
                        finally
                        {
                            _cacheLock.ExitWriteLock();
                        }
                    }

                    return true;
                }
                finally
                {
                    _cacheLock.ExitUpgradeableReadLock();
                }
            }

            return false;
        }

        private void LoadSecurityConfigurationFromDatabaseAndAddToCache(string instanceId)
        {
            using (var context = _securityContextFactory.CreateContext())
            {
                var application = context.Applications.First(
                    app => app.ApplicationName.Equals(EdFiOdsApi, StringComparison.InvariantCultureIgnoreCase));

                var actions = context.Actions.ToList();

                var claimSets = context.ClaimSets
                    .Include(cs => cs.Application)
                    .ToList();

                var resourceClaims = context.ResourceClaims
                    .Include(rc => rc.Application)
                    .Include(rc => rc.ParentResourceClaim)
                    .Where(rc => rc.Application.ApplicationId.Equals(application.ApplicationId))
                    .ToList();

                var authorizationStrategies = context.AuthorizationStrategies
                    .Include(auth => auth.Application)
                    .Where(auth => auth.Application.ApplicationId.Equals(application.ApplicationId))
                    .ToList();

                var claimSetResourceClaims = context.ClaimSetResourceClaimActions
                    .Include(csrc => csrc.Action)
                    .Include(csrc => csrc.ClaimSet)
                    .Include(csrc => csrc.ResourceClaim)
                    .Include(csrc => csrc.AuthorizationStrategyOverrides)
                    .Where(csrc => csrc.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                    .ToList();

                var resourceClaimAuthorizationMetadata = context.ResourceClaimActions
                    .Include(rca => rca.Action)
                    .Include(rca => rca.AuthorizationStrategies)
                    .Include(rca => rca.ResourceClaim)
                    .Where(rca => rca.ResourceClaim.Application.ApplicationId.Equals(application.ApplicationId))
                    .ToList();

                var repo = new InstanceSecurityRepositoryCacheObject(
                    application,
                    actions,
                    claimSets,
                    resourceClaims,
                    authorizationStrategies,
                    claimSetResourceClaims,
                    resourceClaimAuthorizationMetadata);

                _cacheProvider.SetCachedObject(instanceId, repo);
            }
        }

        private bool TryGetCachedRepo(string lookupKey, out InstanceSecurityRepositoryCacheObject securityRepositoryCacheObject)
        {
            _cacheLock.EnterReadLock();

            try
            {
                return _cacheProvider.TryGetCachedObject(lookupKey, out securityRepositoryCacheObject);
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }
        }
        #endregion

        public InstanceSecurityRepositoryCacheObject GetSecurityRepository(string instanceId)
        {
            EnsureCacheInitialized(instanceId);
            TryRefreshCache(instanceId); //NOTE: To refresh if cache expired
            if (!TryGetCachedRepo(instanceId, out InstanceSecurityRepositoryCacheObject repositoryCacheObject))
            {
                throw new InvalidOperationException("Expected InstanceSecurityRepositoryCacheObject not found even after ensuring cache was initialized");
            }
            return repositoryCacheObject;
        }
    }
}
