// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching;

public abstract class PersonIdentifierResolverBase<TLookup, TResolved>
{
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TLookup, TResolved> _mapCache;
    private readonly Dictionary<string, bool> _cacheSuppressionByPersonType;

    private readonly IPersonMapCacheInitializer _personMapCacheInitializer;
    
    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;

    protected PersonIdentifierResolverBase(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), TLookup, TResolved> mapCache,
        Dictionary<string, bool> cacheSuppressionByPersonType)
    {
        _personMapCacheInitializer = personMapCacheInitializer;
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _mapCache = mapCache;
        _cacheSuppressionByPersonType = cacheSuppressionByPersonType;
    }

    protected abstract PersonMapType MapType { get; }
    
    protected async Task ResolveIdentifiers(string personType, IDictionary<TLookup, TResolved> lookups)
    {
        ICollection<TLookup> identifiersToLoad = null;
        var suppliedLookupIdentifiers = lookups.Keys.ToArray();

        // All lookup values in current context must be loaded from the ODS since cached map initialization isn't yet complete
        identifiersToLoad = IsCacheSuppressed(personType)
            ? suppliedLookupIdentifiers
            : ResolveIdentifiersFromCache();

        // If there are any values that still need to be loaded directly from the ODS...
        if (identifiersToLoad != null)
        {
            var results = await LoadPersonUnresolvedIdentifiers(personType, identifiersToLoad);

            foreach (var result in results)
            {
                SetResolvedIdentifier(lookups, result);
            }
            
            // TODO: We may need to validate that all values have been resolved, though this may be more important for UniqueId to USI (PUT/POST requests)
        }

        ICollection<TLookup> ResolveIdentifiersFromCache()
        {
            ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;

            // Ensure cache initialization of the entire UniqueId/USI map for the ODS
            var initializationTask = _personMapCacheInitializer.EnsurePersonMapsInitialized(odsInstanceHashId, personType);

            // If the cache initialization has completed, use the cache to resolve the values first
            if (initializationTask == null || initializationTask.IsCompleted)
            {
                // Resolve uniqueIds from the map cache
                var resolvedIdentifiers = _mapCache.GetMapEntries((odsInstanceHashId, personType, MapType), suppliedLookupIdentifiers);

                // Assign resolved values to the supplied dictionary
                resolvedIdentifiers.ForEach(
                    (resolvedIdentifier, i, args) =>
                    {
                        if (resolvedIdentifier == null || resolvedIdentifier.Equals(default))
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
    /// Sets the entry in the supplied <param name="lookups" /> dictionary from the <see cref="PersonIdentifiersValueMap" />
    /// appropriately for the current implementations <see cref="MapType" />.  
    /// </summary>
    /// <param name="lookups">The dictionary containing the values to be resolved for the current request.</param>
    /// <param name="personIdentifiers">The UniqueId/USI values for a person in the ODS.</param>
    protected abstract void SetResolvedIdentifier(IDictionary<TLookup, TResolved> lookups, PersonIdentifiersValueMap personIdentifiers);

    protected abstract Task<IEnumerable<PersonIdentifiersValueMap>> LoadPersonUnresolvedIdentifiers(
        string personType,
        ICollection<TLookup> identifiersToLoad);
}
