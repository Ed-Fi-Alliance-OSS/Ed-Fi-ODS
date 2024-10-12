// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps;

/// <summary>
/// Implements a pipeline step that resolves the USIs from the collection of UniqueIds saved into the current UniqueId lookup context.
/// </summary>
public class ResolveUsis<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
{
    private readonly IContextualPersonUsisResolver _contextualPersonUsisResolver;

    public ResolveUsis(IContextualPersonUsisResolver contextualPersonUsisResolver)
    {
        _contextualPersonUsisResolver = contextualPersonUsisResolver;
    }

    public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
    {
        await _contextualPersonUsisResolver.ResolveAllUsis();
    }
}
