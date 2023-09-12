// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching;

public class PersonUsiResolver : PersonIdentifierResolverBase<string, int>, IPersonUsiResolver
{
    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;

    public PersonUsiResolver(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IPersonIdentifiersProvider personIdentifiersProvider,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> mapCache,
        Dictionary<string, bool> cacheSuppressionByPersonType)
        : base(personMapCacheInitializer, odsInstanceConfigurationContextProvider, mapCache, cacheSuppressionByPersonType)
    {
        _personIdentifiersProvider = personIdentifiersProvider;
    }

    public async Task ResolveUsis(string personType, IDictionary<string, int> lookups)
    {
        await ResolveIdentifiers(personType, lookups);
    }

    protected override async Task<IEnumerable<PersonIdentifiersValueMap>> LoadPersonUnresolvedIdentifiers(
        string personType,
        ICollection<string> identifiersToLoad)
    {
        return await _personIdentifiersProvider.GetPersonUsis(personType, identifiersToLoad.ToArray());
    }

    protected override PersonMapType MapType
    {
        get => PersonMapType.UsiByUniqueId;
    }

    protected override void SetResolvedIdentifier(IDictionary<string, int> lookups, PersonIdentifiersValueMap personIdentifiers)
    {
        lookups[personIdentifiers.UniqueId] = personIdentifiers.Usi;
    }
}
