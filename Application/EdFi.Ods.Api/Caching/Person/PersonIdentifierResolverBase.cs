// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
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

    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;

    private readonly TLookup[] _cacheInitializationMarkerKeyForLookup;
    private readonly TResolved[] _cacheInitializationMarkerKeyForResolved;

    private readonly ILog _logger;
    private readonly bool _performBackgroundInitialization;

    protected PersonIdentifierResolverBase(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TLookup, TResolved> mapCache,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TResolved, TLookup> reverseMapCache,
        ICacheInitializationMarkerKeyProvider<TLookup> cacheInitializationMarkerKeyForLookupProvider, 
        ICacheInitializationMarkerKeyProvider<TResolved> cacheInitializationMarkerKeyForResolvedProvider, 
        Dictionary<string, bool> cacheSuppressionByPersonType,
        bool useProgressiveLoading)
    {
        _logger = LogManager.GetLogger(GetType());

        _personMapCacheInitializer = personMapCacheInitializer;
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _mapCache = mapCache;
        _reverseMapCache = reverseMapCache;
        _cacheSuppressionByPersonType = cacheSuppressionByPersonType;

        _performBackgroundInitialization = !useProgressiveLoading;
        
        _cacheInitializationMarkerKeyForLookup = new[] { cacheInitializationMarkerKeyForLookupProvider.CacheKey };
        _cacheInitializationMarkerKeyForResolved = new [] { cacheInitializationMarkerKeyForResolvedProvider.CacheKey };
    }

    protected abstract PersonMapType MapType { get; }
    
    protected async Task ResolveIdentifiersAsync(string personType, IDictionary<TLookup, TResolved> lookups)
    {
        ICollection<TLookup> identifiersToLoad = null;
        var suppliedLookupIdentifiers = lookups.Keys;

        // All lookup values in current context must be loaded from the ODS since cached map initialization isn't yet complete
        identifiersToLoad = IsCacheSuppressed(personType)
            ? suppliedLookupIdentifiers
            : await ResolveIdentifiersFromCache();

        // If there are any values that still need to be loaded directly from the ODS...
        if (identifiersToLoad != null)
        {
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
                    loadedIdentifierMappings.Select(x => (x.value, x.key)).ToArray()));

            // Note: While we may want to validate that all values have been resolved, the behavior of the API when the resolution
            // fails (primarily for UniqueId values passed in PUT/POST requests) is appropriate without this extra validation. 
        }

        async Task<ICollection<TLookup>> ResolveIdentifiersFromCache()
        {
            ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;

            TLookup[] cacheLookupIdentifiers;

            if (_performBackgroundInitialization)
            {
                cacheLookupIdentifiers = suppliedLookupIdentifiers.Concat(_cacheInitializationMarkerKeyForLookup).ToArray();
            }
            else
            {
                cacheLookupIdentifiers = suppliedLookupIdentifiers.ToArray();
            }

            // Resolve uniqueIds from the map cache
            var resolvedIdentifiers = await _mapCache.GetMapEntriesAsync((odsInstanceHashId, personType, MapType), cacheLookupIdentifiers);

            // Assign resolved values to the supplied dictionary
            resolvedIdentifiers.ForEach(
                (resolvedIdentifier, i, args) =>
                {
                    // The last entry is always the check to see if cache value has been background initialized -- don't process that entry normally
                    if (args.performBackgroundInitialization && i == args.resolvedIdentifiersLength - 1)
                    {
                        return;
                    }
                    
                    if (resolvedIdentifier == null || resolvedIdentifier.Equals(default(TResolved)))
                    {
                        // Need to load unresolved entries from the ODS
                        AddUniqueIdToLoad(args.cacheLookupIdentifiers[i]);
                    }
                    else
                    {
                        // Record the resolved identifier
                        args.lookups[args.cacheLookupIdentifiers[i]] = resolvedIdentifier;
                    }
                    
                    void AddUniqueIdToLoad(TLookup lookupValue)
                    {
                        identifiersToLoad ??= new List<TLookup>();
                        identifiersToLoad.Add(lookupValue);
                    }
                },
                // Args to avoid closure
                (cacheLookupIdentifiers, 
                    lookups, 
                    identifiersToLoad, 
                    resolvedIdentifiersLength: resolvedIdentifiers.Length,
                    performBackgroundInitialization: _performBackgroundInitialization));

            // Check to see if cache needs to be initialized by checking the resolution of the marker value
            if (_performBackgroundInitialization && resolvedIdentifiers[^1] == null)
            {
                try
                {
                    // Add the entries indicating that background initialization has been initiated/performed
                    await Task.WhenAll(
                        _mapCache.SetMapEntriesAsync(
                            (odsInstanceHashId, personType, MapType),
                            new[] { (_cacheInitializationMarkerKeyForLookup[0], _cacheInitializationMarkerKeyForResolved[0]) }),
                        _reverseMapCache.SetMapEntriesAsync(
                            (odsInstanceHashId, personType, MapType.Inverse()),
                            new[] { (_cacheInitializationMarkerKeyForResolved[0], _cacheInitializationMarkerKeyForLookup[0]) }));
                }
                catch (Exception ex)
                {
                    _logger.Error("An error occurred while attempting to add the 'initialization' marker cache entry to the cache.", ex);
                }

                // Initiate cache initialization of the entire UniqueId/USI map for the ODS
                // NOTE: Do NOT await this here, let it run in the background
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                _personMapCacheInitializer.InitializePersonMapAsync(odsInstanceHashId, personType);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }

            return identifiersToLoad;
        }
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
