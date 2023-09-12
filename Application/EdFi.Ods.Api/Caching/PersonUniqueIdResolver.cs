// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.Dtos;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching;

public class PersonUniqueIdResolver : PersonIdentifierResolverBase<int, string>, IPersonUniqueIdResolver
{
    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;

    public PersonUniqueIdResolver(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IPersonIdentifiersProvider personIdentifiersProvider,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> mapCache,
        Dictionary<string, bool> cacheSuppressionByPersonType)
        : base(personMapCacheInitializer, odsInstanceConfigurationContextProvider, mapCache, cacheSuppressionByPersonType)
    {
        _personIdentifiersProvider = personIdentifiersProvider;
    }

    public async Task ResolveUniqueIds(string personType, IDictionary<int, string> lookups)
    {
        await ResolveIdentifiers(personType, lookups);
    }

    protected override async Task<IEnumerable<PersonIdentifiersValueMap>> LoadPersonUnresolvedIdentifiers(
        string personType,
        ICollection<int> identifiersToLoad)
    {
        return await _personIdentifiersProvider.GetPersonUniqueIds(personType, identifiersToLoad.ToArray());
    }

    protected override PersonMapType MapType
    {
        get => PersonMapType.UniqueIdByUsi;
    }

    protected override void SetResolvedIdentifier(IDictionary<int, string> lookups, PersonIdentifiersValueMap personIdentifiers)
    {
        lookups[personIdentifiers.Usi] = personIdentifiers.UniqueId;
    }
}