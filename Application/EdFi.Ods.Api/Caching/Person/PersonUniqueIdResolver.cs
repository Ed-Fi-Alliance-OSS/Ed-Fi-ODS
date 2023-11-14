// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching.Person;

/// <summary>
/// Resolves UniqueIds for supplied USIs.
/// </summary>
public class PersonUniqueIdResolver : PersonIdentifierResolverBase<int, string>, IPersonUniqueIdResolver
{
    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;

    public PersonUniqueIdResolver(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IPersonIdentifiersProvider personIdentifiersProvider,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> mapCache,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> reverseMapCache,
        ICacheInitializationMarkerKeyProvider<int> cacheInitializationMarkerKeyForLookupProvider, 
        ICacheInitializationMarkerKeyProvider<string> cacheInitializationMarkerKeyForResolvedProvider, 
        Dictionary<string, bool> cacheSuppressionByPersonType,
        bool useProgressiveLoading)
        : base(
            personMapCacheInitializer,
            odsInstanceConfigurationContextProvider,
            mapCache,
            reverseMapCache,
            cacheInitializationMarkerKeyForLookupProvider,
            cacheInitializationMarkerKeyForResolvedProvider,
            cacheSuppressionByPersonType,
            useProgressiveLoading)
    {
        _personIdentifiersProvider = personIdentifiersProvider;
    }

    /// <inheritdoc cref="IPersonUniqueIdResolver.ResolveUniqueIdsAsync" />
    public async Task ResolveUniqueIdsAsync(string personType, IDictionary<int, string> lookups)
    {
        await ResolveIdentifiersAsync(personType, lookups);
    }

    protected override async Task<IEnumerable<PersonIdentifiersValueMap>> LoadUnresolvedPersonIdentifiersAsync(
        string personType,
        ICollection<int> identifiersToLoad)
    {
        return await _personIdentifiersProvider.GetPersonUniqueIdsAsync(personType, identifiersToLoad.ToArray());
    }

    protected override PersonMapType MapType
    {
        get => PersonMapType.UniqueIdByUsi;
    }

    protected override (int key, string value) ExtractKeyValueTuple(PersonIdentifiersValueMap personIdentifiers)
    {
        return (personIdentifiers.Usi, personIdentifiers.UniqueId);
    }
}
