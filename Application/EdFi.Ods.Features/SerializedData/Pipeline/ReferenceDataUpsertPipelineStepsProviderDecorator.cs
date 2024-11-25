// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Features.UniqueIdIntegration.Pipeline;

namespace EdFi.Ods.Features.SerializedData.Pipeline;

/// <summary>
/// Implements a <see cref="IUpsertPipelineStepsProvider"/> decorator that inserts a step to initialize the context for reference data lookups.
/// </summary>
public class ReferenceDataUpsertPipelineStepsProviderDecorator : IUpsertPipelineStepsProvider
{
    private readonly IUpsertPipelineStepsProvider _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="UniqueIdIntegrationUpsertPipelineStepsProviderDecorator"/> class using
    /// a supplied provider to be decorated.
    /// </summary>
    /// <param name="next">The decorated provider.</param>
    public ReferenceDataUpsertPipelineStepsProviderDecorator(IUpsertPipelineStepsProvider next)
    {
        _next = next;
    }

    /// <summary>
    /// Gets the types representing the steps, inserting a population step before the existing
    /// validation step.
    /// </summary>
    /// <returns></returns>
    public Type[] GetSteps()
    {
        return _next.GetSteps()
            .InsertBefore(
                typeof(MapResourceModelToEntityModel<,,,>),
                typeof(InitializeReferenceDataLookupContext<,,,>))
            .ToArray();
    }
}
