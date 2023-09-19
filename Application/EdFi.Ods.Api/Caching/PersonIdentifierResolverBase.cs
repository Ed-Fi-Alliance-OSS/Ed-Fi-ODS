// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching;

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

    protected PersonIdentifierResolverBase(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TLookup, TResolved> mapCache,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TResolved, TLookup> reverseMapCache,
        Dictionary<string, bool> cacheSuppressionByPersonType)
    {
        _personMapCacheInitializer = personMapCacheInitializer;
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _mapCache = mapCache;
        _reverseMapCache = reverseMapCache;
        _cacheSuppressionByPersonType = cacheSuppressionByPersonType;
    }

    protected abstract PersonMapType MapType { get; }
    
    protected async Task ResolveIdentifiersAsync(string personType, IDictionary<TLookup, TResolved> lookups)
    {
        ICollection<TLookup> identifiersToLoad = null;
        var suppliedLookupIdentifiers = lookups.Keys.ToArray();

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
                _mapCache.SetMapEntriesAsync((odsInstanceHashId, personType, MapType), loadedIdentifierMappings),
                
                _reverseMapCache.SetMapEntriesAsync(
                    (odsInstanceHashId, personType, MapType.Inverse()),
                    loadedIdentifierMappings.Select(x => (x.value, x.key)).ToArray()));

            // Note: We may want to validate that all values have been resolved, though the behavior of the API when the
            // resolution fails (primarily for UniqueId values passed in PUT/POST requests) is appropriate without this extra validation. 
        }

        async Task<ICollection<TLookup>> ResolveIdentifiersFromCache()
        {
            ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;

            // Ensure cache initialization of the entire UniqueId/USI map for the ODS
            var initializationTask = _personMapCacheInitializer.EnsurePersonMapsInitialized(odsInstanceHashId, personType);

            // If the cache initialization has completed, use the cache to resolve the values first
            if (initializationTask == null || initializationTask.IsCompleted)
            {
                // Resolve uniqueIds from the map cache
                var resolvedIdentifiers = await _mapCache.GetMapEntriesAsync((odsInstanceHashId, personType, MapType), suppliedLookupIdentifiers);

                // Assign resolved values to the supplied dictionary
                resolvedIdentifiers.ForEach(
                    (resolvedIdentifier, i, args) =>
                    {
                        if (resolvedIdentifier == null || resolvedIdentifier.Equals(default(TResolved)))
                        {
                            // Need to look up in the ODS
                            AddUniqueIdToLoad(args.suppliedLookupIdentifiers[i]);
                        }
                        else
                        {
                            lookups[args.suppliedLookupIdentifiers[i]] = resolvedIdentifier;
                        }
                    },
                    (suppliedLookupIdentifiers, identifiersToLoad));

                void AddUniqueIdToLoad(TLookup lookupValue)
                {
                    identifiersToLoad ??= new List<TLookup>();
                    identifiersToLoad.Add(lookupValue);
                }
            }
            else
            {
                // All lookup values in current context must be loaded from the ODS since cached map initialization isn't yet complete
                identifiersToLoad = suppliedLookupIdentifiers;
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
