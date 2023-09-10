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
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps;

public class ResolveUsis<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
{
    private readonly IPersonEntitySpecification _personEntitySpecification;
    private readonly IContextProvider<UsiLookupsByUniqueIdContext> _lookupContextProvider;
    private readonly IPersonUsiResolver _personUsiResolver;

    public ResolveUsis(
        IPersonEntitySpecification personEntitySpecification,
        IContextProvider<UsiLookupsByUniqueIdContext> lookupContextProvider,
        IPersonUsiResolver personUsiResolver)
    {
        _personEntitySpecification = personEntitySpecification;
        _lookupContextProvider = lookupContextProvider;
        _personUsiResolver = personUsiResolver;
    }

    public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
    {
        var uniqueIdLookupsByUsiContext = _lookupContextProvider.Get();

        if (!uniqueIdLookupsByUsiContext.Any())
        {
            return;
        }

        foreach (var kvp in uniqueIdLookupsByUsiContext.UsiByUniqueIdByPersonType)
        {
            await _personUsiResolver.ResolveUsis(kvp.Key, kvp.Value);
        }
    }
}
