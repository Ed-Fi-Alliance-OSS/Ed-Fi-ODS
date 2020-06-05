// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Extensions;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Common.Utils;

namespace EdFi.Ods.Api.Common.Caching
{
    public class DescriptorsCache : IDescriptorsCache
    {
        private const int DatabaseSynchronizationExpirationSeconds = 60;
        private const string DescriptorCacheKeyPrefix = "Descriptors";
        private const string InitializedKeyPrefix = "DescriptorsCache.Initialized";
        private const string LastSyncedKey = "DescriptorsCache.LastSynced";

        // This exists as a place to put a global singleton of the Descriptors Cache. Set during the Composite Root creation.
        public static Func<IDescriptorsCache> GetCache = () => null;

        private readonly object _cacheInitializationLocker = new object();

        private readonly ReaderWriterLockSlim _cacheLock = new ReaderWriterLockSlim();
        private readonly ICacheProvider _cacheProvider;
        private readonly IDescriptorLookupProvider _descriptorLookupProvider;
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;

        public DescriptorsCache(
            IDescriptorLookupProvider descriptorLookupProvider,
            ICacheProvider cacheProvider,
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider)
        {
            _descriptorLookupProvider = descriptorLookupProvider;
            _cacheProvider = cacheProvider;
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
        }

        private bool HasLastDatabaseSynchronizationExpired
        {
            get
            {
                var currentTime = SystemClock.Now();

                if (!_cacheProvider.TryGetCachedObject(GetLastSynchedKey(), out object lastSynced))
                {
                    lastSynced = DateTime.MinValue;
                }

                var totalSeconds = (currentTime - (DateTime) lastSynced).TotalSeconds;
                return totalSeconds > DatabaseSynchronizationExpirationSeconds;
            }
        }

        private int InstanceId => _edFiOdsInstanceIdentificationProvider.GetInstanceIdentification();

        public string GetValue(string descriptorName, int id)
        {
            EnsureCacheInitialized();

            // If no id supplied, return the default string value
            if (!DescriptorEntitySpecification.IsEdFiDescriptorEntity(descriptorName) || id == default(int))
            {
                return default(string);
            }

            var lookupKey = GetDescriptorLookupKeyById(descriptorName, id);

            if (TryGetCachedValue(lookupKey, out string codeValue))
            {
                return codeValue;
            }

            if (!TryRefreshSingleDescriptorCacheById(descriptorName, id)
                || !TryGetCachedValue(lookupKey, out codeValue))
            {
                // If a non-default result is provided, add it to the cache
                if (codeValue != default(string))
                {
                    UpdateDescriptorLookupCache(
                        CreateDescriptorLookup(descriptorName, id, codeValue));
                }
            }

            if (string.IsNullOrEmpty(codeValue))
            {
                throw new BadRequestException($"Unable to resolve id '{id}' to an existing resource {descriptorName}.");
            }

            return codeValue;
        }

        public int GetId(string descriptorName, string descriptorValue)
        {
            EnsureCacheInitialized();

            // If not a descriptor name or no value is supplied, return default int value.
            if (!DescriptorEntitySpecification.IsEdFiDescriptorEntity(descriptorName) || string.IsNullOrWhiteSpace(descriptorValue))
            {
                return default(int);
            }

            var lookupKey = GetDescriptorLookupKeyByValue(descriptorName, descriptorValue);

            if (TryGetCachedId(lookupKey, out int id))
            {
                return id;
            }

            if (!TryRefreshSingleDescriptorCache(descriptorName)
                || !TryGetCachedId(lookupKey, out id))
            {
                // If a non-default result is provided, add it to the cache
                if (id != default(int))
                {
                    UpdateDescriptorLookupCache(
                        CreateDescriptorLookup(descriptorName, id, descriptorValue));
                }
            }

            if (id == default(int))
            {
                throw new BadRequestException($"Unable to resolve value '{descriptorValue}' to an existing '{descriptorName}' resource.");
            }

            return id;
        }

        // Manages Lazy invocation of the TryRefreshCache to prevent premature initialization (where component
        // is resolved (but not invoked) from outside of the context of a API request.
        private void EnsureCacheInitialized()
        {
            object initializedAsObject;

            string cacheKey = GetCurrentCacheInitializedKey();

            if (!_cacheProvider.TryGetCachedObject(cacheKey, out initializedAsObject))
            {
                // Make sure there is only one cache set being initialized at a time
                lock (_cacheInitializationLocker)
                {
                    if (!_cacheProvider.TryGetCachedObject(cacheKey, out initializedAsObject))
                    {
                        TryRefreshCache(force: true);

                        _cacheProvider.SetCachedObject(cacheKey, true);
                    }
                }
            }
        }

        private string GetDescriptorLookupKeyByValue(string descriptorName, string descriptorValue)
        {
            return $"{InstanceId}|{DescriptorCacheKeyPrefix}.{descriptorName}.ByValue.{descriptorValue.ToLowerInvariant()}";
        }

        private string GetDescriptorLookupKeyById(string descriptorName, int id)
        {
            return $"{InstanceId}|{DescriptorCacheKeyPrefix}.{descriptorName}.ById.{id}";
        }

        private string GetCurrentCacheInitializedKey()
        {
            return InitializedKeyPrefix + "." + InstanceId;
        }

        private string GetLastSynchedKey()
        {
            return LastSyncedKey + "." + InstanceId;
        }

        /// <summary>
        /// Attempts to refresh the cache instance using the database connection for the current authorization context
        /// </summary>
        private bool TryRefreshCache(bool force = false)
        {
            if (force || HasLastDatabaseSynchronizationExpired)
            {
                _cacheLock.EnterUpgradeableReadLock();

                try
                {
                    if (force || HasLastDatabaseSynchronizationExpired)
                    {
                        _cacheLock.EnterWriteLock();

                        try
                        {
                            // Load Descriptors
                            var descriptorCacheDataDictionary = _descriptorLookupProvider.GetAllDescriptorLookups();

                            foreach (var descriptorCacheData in descriptorCacheDataDictionary.SelectMany(dcd => dcd.Value))
                            {
                                UpdateDescriptorLookupCache(descriptorCacheData);
                            }

                            _cacheProvider.SetCachedObject(GetLastSynchedKey(), SystemClock.Now());
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

        private void UpdateDescriptorLookupCache(DescriptorLookup descriptorLookup)
        {
            //Cache by two keys for descriptors, one for the full value and one for the id
            var descriptorValueKey =
                GetDescriptorLookupKeyByValue(
                    descriptorLookup.DescriptorName,
                    descriptorLookup.DescriptorValue);

            _cacheProvider.SetCachedObject(descriptorValueKey, descriptorLookup.Id);

            var idKey = GetDescriptorLookupKeyById(
                descriptorLookup.DescriptorName,
                descriptorLookup.Id);

            _cacheProvider.SetCachedObject(idKey, descriptorLookup.DescriptorValue);
        }

        private bool TryRefreshSingleDescriptorCacheById(string descriptorName, int id)
        {
            var descriptorLookup = _descriptorLookupProvider.GetSingleDescriptorLookupById(descriptorName, id);

            if (descriptorLookup == null)
            {
                return false;
            }

            UpdateDescriptorLookupCache(descriptorLookup);
            TryRefreshCache();

            return true;
        }

        private bool TryRefreshSingleDescriptorCache(string descriptorName)
        {
            var descriptorLookups = _descriptorLookupProvider.GetDescriptorLookupsByDescriptorName(descriptorName);

            if (descriptorLookups == null || !descriptorLookups.Any())
            {
                return false;
            }

            descriptorLookups.ToList()
                             .ForEach(UpdateDescriptorLookupCache);

            TryRefreshCache();

            return true;
        }

        private bool TryGetCachedId(string lookupKey, out int id)
        {
            _cacheLock.EnterReadLock();

            try
            {
                return CacheProviderExtensions.TryGetCachedObject(_cacheProvider, lookupKey, out id);
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }
        }

        private bool TryGetCachedValue(string lookupKey, out string value)
        {
            _cacheLock.EnterReadLock();

            try
            {
                return CacheProviderExtensions.TryGetCachedObject(_cacheProvider, lookupKey, out value);
            }
            finally
            {
                _cacheLock.ExitReadLock();
            }
        }

        private DescriptorLookup CreateDescriptorLookup(string descriptorName, int id, string descriptorValue)
        {
            return new DescriptorLookup
                   {
                       Id = id, DescriptorName = descriptorName, DescriptorValue = descriptorValue
                   };
        }
    }
}
