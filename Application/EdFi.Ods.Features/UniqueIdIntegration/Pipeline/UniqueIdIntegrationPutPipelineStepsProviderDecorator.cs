// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Features.UniqueIdIntegration.Pipeline
{
    /// <summary>
    /// Implements a <see cref="EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories.IPutPipelineStepsProvider"/> decorator that inserts a step to
    /// populate the GUID-based Id from the supplied UniqueId for person-type resources.
    /// </summary>
    public class UniqueIdIntegrationPutPipelineStepsProviderDecorator : IPutPipelineStepsProvider
    {
        private readonly IPutPipelineStepsProvider _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueIdIntegrationPutPipelineStepsProviderDecorator"/> class using
        /// a supplied provider to be decorated.
        /// </summary>
        /// <param name="next">The decorated provider.</param>
        public UniqueIdIntegrationPutPipelineStepsProviderDecorator(IPutPipelineStepsProvider next)
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
                             typeof(PersistEntityModel<,,,>),
                             typeof(PopulateIdFromUniqueIdOnPeople<,,,>))
                        .ToArray();
        }
    }
}
