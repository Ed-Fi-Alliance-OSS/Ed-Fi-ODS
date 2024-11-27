// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Infrastructure.Pipelines;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Features.SerializedData.Repositories;

namespace EdFi.Ods.Features.SerializedData.Pipeline;

public class ResolveReferenceData<TContext, TResult, TResourceModel, TEntityModel>
    : IStep<TContext, TResult>
{
    private readonly IReferenceDataResolver _referenceDataResolver;

    public ResolveReferenceData(IReferenceDataResolver referenceDataResolver)
    {
        _referenceDataResolver = referenceDataResolver;
    }

    public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
    {
        await _referenceDataResolver.ResolveReferenceDataAsync();
    }
}
