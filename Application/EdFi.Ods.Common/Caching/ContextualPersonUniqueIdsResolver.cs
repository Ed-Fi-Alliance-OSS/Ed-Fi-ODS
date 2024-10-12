// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Caching;

public class ContextualPersonUniqueIdsResolver : IContextualPersonUniqueIdsResolver
{
    private readonly IContextProvider<UniqueIdLookupsByUsiContext> _lookupContextProvider;
    private readonly IPersonUniqueIdResolver _personUniqueIdResolver;

    public ContextualPersonUniqueIdsResolver(
        IContextProvider<UniqueIdLookupsByUsiContext> lookupContextProvider,
        IPersonUniqueIdResolver personUniqueIdResolver)
    {
        _lookupContextProvider = lookupContextProvider;
        _personUniqueIdResolver = personUniqueIdResolver;
    }

    public async Task ResolveAllUniqueIdsAsync()
    {
        var uniqueIdLookupsByUsiContext = _lookupContextProvider.Get();
        await uniqueIdLookupsByUsiContext.ResolveAllUniqueIds(_personUniqueIdResolver);
    }
}
