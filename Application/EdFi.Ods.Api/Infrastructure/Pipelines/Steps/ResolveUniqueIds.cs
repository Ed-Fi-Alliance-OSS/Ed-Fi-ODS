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

/// <summary>
/// Implements a pipeline step that resolves the UniqueIds from the collection of USIs saved into the current USI lookup context.
/// </summary>
/// <typeparam name="TContext"></typeparam>
/// <typeparam name="TResult"></typeparam>
/// <typeparam name="TResourceModel"></typeparam>
/// <typeparam name="TEntityModel"></typeparam>
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
        await uniqueIdLookupsByUsiContext.ResolveAllUniqueIds(_personUniqueIdResolver);
    }
}
