// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Caching;

public class ContextualPersonUsisResolver : IContextualPersonUsisResolver
{
    private readonly IContextProvider<UsiLookupsByUniqueIdContext> _lookupContextProvider;
    private readonly IPersonUsiResolver _personUsiResolver;

    public ContextualPersonUsisResolver(
        IContextProvider<UsiLookupsByUniqueIdContext> lookupContextProvider,
        IPersonUsiResolver personUsiResolver)
    {
        _lookupContextProvider = lookupContextProvider;
        _personUsiResolver = personUsiResolver;
    }

    public async Task ResolveAllUsis()
    {
        var uniqueIdLookupsByUsiContext = _lookupContextProvider.Get();
        await uniqueIdLookupsByUsiContext.ResolveAllUsis(_personUsiResolver);
    }
}
