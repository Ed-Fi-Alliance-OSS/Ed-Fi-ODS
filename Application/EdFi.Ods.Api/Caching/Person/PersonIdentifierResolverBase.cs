// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using log4net;

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Provides a base class for common behavior needed for person identifier resolution (see <see cref="IPersonUniqueIdResolver"/>
/// and <see cref="IPersonUsiResolver"/>).
/// </summary>
/// <typeparam name="TLookup">The type of the identifier being used for the lookup.</typeparam>
/// <typeparam name="TResolved">The type of the identifier being resolved.</typeparam>
public abstract class PersonIdentifierResolverBase<TLookup, TResolved>
{
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TLookup, TResolved> _mapCache;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TResolved, TLookup> _reverseMapCache;
    private readonly Dictionary<string, bool> _cacheSuppressionByPersonType;
    private readonly IPersonMapCacheInitializer _personMapCacheInitializer;
    private readonly IDistributedLockProvider _distributedLockProvider;
    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;
    private readonly TLookup[] _cacheInitializationMarkerKeyForLookup;
    private readonly ILog _logger;
    private readonly bool _performBackgroundInitialization;

    protected PersonIdentifierResolverBase(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IDistributedLockProvider distributedLockProvider,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TLookup, TResolved> mapCache,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TResolved, TLookup> reverseMapCache,
        ICacheInitializationMarkerKeyProvider<TLookup> cacheInitializationMarkerKeyForLookupProvider,
        Dictionary<string, bool> cacheSuppressionByPersonType,
        bool useProgressiveLoading)
    {
        _logger = LogManager.GetLogger(GetType());
        _personMapCacheInitializer = personMapCacheInitializer;
        _distributedLockProvider = distributedLockProvider;
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _mapCache = mapCache;
        _reverseMapCache = reverseMapCache;
        _cacheSuppressionByPersonType = cacheSuppressionByPersonType;
        _performBackgroundInitialization = !useProgressiveLoading;
        _cacheInitializationMarkerKeyForLookup = [cacheInitializationMarkerKeyForLookupProvider.CacheKey];
    }

    protected abstract PersonMapType MapType { get; }

    protected async Task ResolveIdentifiersAsync(string personType, IDictionary<TLookup, TResolved> lookups)
    {
        TLookup[] suppliedLookupIdentifiers = [.. lookups.Keys];

        // All lookup values in current context must be loaded from the ODS since cached map initialization isn't yet complete
        ICollection<TLookup> identifiersToLoad = IsCacheSuppressed(personType)
            ? suppliedLookupIdentifiers
            : await ResolveIdentifiersFromCacheAsync();

        if (identifiersToLoad is null || identifiersToLoad.Count == 0)
        {
            return;
        }

        // There are any values that still need to be loaded directly from the ODS...
        var loadedIdentifierMappings = (await LoadUnresolvedPersonIdentifiersAsync(personType, identifiersToLoad))
            .Select(ExtractKeyValueTuple)
            .ToArray();

        // Update the contextual dictionary for the current request
        foreach (var loadedIdentifierMapping in loadedIdentifierMappings)
        {
            lookups[loadedIdentifierMapping.key] = loadedIdentifierMapping.value;
        }

        // Update the underlying caches with the key/value pairs it doesn't have
        ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;

        await Task.WhenAll(
            _mapCache.SetMapEntriesAsync(
                (odsInstanceHashId, personType, MapType),
                loadedIdentifierMappings),
            _reverseMapCache.SetMapEntriesAsync(
                (odsInstanceHashId, personType, MapType.Inverse()),
                [.. loadedIdentifierMappings.Select(x => (x.value, x.key))]));
        // Note: While we may want to validate that all values have been resolved, the behavior of the API when the resolution
        // fails (primarily for UniqueId values passed in PUT/POST requests) is appropriate without this extra validation. 

        async Task<ICollection<TLookup>> ResolveIdentifiersFromCacheAsync()
        {
            ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;
            TLookup[] cacheLookupIdentifiers = _performBackgroundInitialization
                ? [.. suppliedLookupIdentifiers, .. _cacheInitializationMarkerKeyForLookup]
                : [.. suppliedLookupIdentifiers];

            // Resolve uniqueIds from the map cache
            TResolved[] resolvedIdentifiers = await _mapCache.GetMapEntriesAsync((odsInstanceHashId, personType, MapType), cacheLookupIdentifiers);
            List<TLookup> unresolvedIdentifiers = null;

            // The last entry is always the check to see if cache value has been background initialized -- don't process that entry normally
            int lookupsToProcess = _performBackgroundInitialization ? resolvedIdentifiers.Length - 1 : resolvedIdentifiers.Length;

            // Assign resolved values to the supplied dictionary
            for (int i = 0; i < lookupsToProcess; i++)
            {
                if (IsUnresolved(resolvedIdentifiers[i]))
                {
                    unresolvedIdentifiers ??= [];
                    unresolvedIdentifiers.Add(cacheLookupIdentifiers[i]);
                }
                else
                {
                    // Record the resolved identifier
                    lookups[cacheLookupIdentifiers[i]] = resolvedIdentifiers[i];
                }
            }

            // Check to see if cache needs to be initialized by checking the resolution of the marker value
            if (_performBackgroundInitialization && IsUnresolved(resolvedIdentifiers[^1]))
            {
                string lockKey = $"cache-init-lock:{odsInstanceHashId}:{personType}:{MapType}";

                if (await _distributedLockProvider.TryAcquireLockAsync(lockKey, TimeSpan.FromMinutes(5)))
                {
                    try
                    {
                        // NOTE: Do NOT await this Task -- let it run in the background
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                        // Initiate cache initialization of the entire UniqueId/USI map for the ODS
                        var initializationTask = _personMapCacheInitializer.InitializePersonMapAsync(
                            odsInstanceHashId,
                            personType,
                            lockKey,
                            CancellationToken.None);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

                        _ = initializationTask.ContinueWith(
                            t => _logger.Error(
                                $"An error occurred while initializing the '{personType}' cache in the background for ODS instance '{odsInstanceHashId}'.",
                                t.Exception),
                            TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(
                            $"Unable to start background cache initialization for '{personType}' in ODS instance '{odsInstanceHashId}'.",
                            ex);

                        try
                        {
                            await _distributedLockProvider.ReleaseLockAsync(lockKey);
                        }
                        catch (Exception releaseEx)
                        {
                            _logger.Error(
                                $"An error occurred while releasing the Redis initialization lock '{lockKey}' after failed start.",
                                releaseEx);
                        }
                    }
                }
            }

            return unresolvedIdentifiers;
        }

        static bool IsUnresolved(TResolved resolvedIdentifier)
            => resolvedIdentifier is null || EqualityComparer<TResolved>.Default.Equals(resolvedIdentifier, default);
    }

    private bool IsCacheSuppressed(string personType)
        => _cacheSuppressionByPersonType.TryGetValue(personType, out bool isSuppressed) && isSuppressed;

    /// <summary>
    /// Gets the key/value tuple from the <see cref="PersonIdentifiersValueMap" /> appropriately for the <see cref="MapType" />.
    /// </summary>
    /// <param name="personIdentifiers">The UniqueId/USI values for a person in the ODS to be converted to a key/value tuple.</param>
    protected abstract (TLookup key, TResolved value) ExtractKeyValueTuple(PersonIdentifiersValueMap personIdentifiers);

    protected abstract Task<IEnumerable<PersonIdentifiersValueMap>> LoadUnresolvedPersonIdentifiersAsync(
        string personType,
        ICollection<TLookup> identifiersToLoad);
}
