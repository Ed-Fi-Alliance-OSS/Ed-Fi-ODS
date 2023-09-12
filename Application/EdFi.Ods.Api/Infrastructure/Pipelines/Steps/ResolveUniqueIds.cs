// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Pipelines;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps;

public class ResolveUniqueIds<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
{
    private readonly IContextProvider<UniqueIdLookupsByUsiContext> _lookupContextProvider;
    private readonly IPersonUniqueIdResolver _personUniqueIdResolver;

    public ResolveUniqueIds(
        IContextProvider<UniqueIdLookupsByUsiContext> lookupContextProvider,
        IPersonUniqueIdResolver personUniqueIdResolver)
    {
        _lookupContextProvider = lookupContextProvider;
        _personUniqueIdResolver = personUniqueIdResolver;
    }

    public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
    {
        var uniqueIdLookupsByUsiContext = _lookupContextProvider.Get();

        if (uniqueIdLookupsByUsiContext == null || !uniqueIdLookupsByUsiContext.Any())
        {
            return;
        }

        foreach (var kvp in uniqueIdLookupsByUsiContext.UniqueIdByUsiByPersonType)
        {
            await _personUniqueIdResolver.ResolveUniqueIds(kvp.Key, kvp.Value);
        }
    }
}