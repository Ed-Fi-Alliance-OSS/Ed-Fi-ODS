// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Api.Pipelines.Factories;
using EdFi.Ods.Common;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Pipelines.Common;
using EdFi.Ods.Pipelines.Put;

namespace EdFi.Ods.Api.Pipelines.Put
{
    public class PutPipelineStepsProvider : PipelineStepsProviderBase, IPutPipelineStepsProvider
    {
        private readonly IPutPipelineStepTypesProvider _pipelineStepTypesProvider;
        
        private readonly ConcurrentDictionary<Type, IStep[]> _closedPipelineStepsByResourceType =
            new ConcurrentDictionary<Type, IStep[]>();

        public PutPipelineStepsProvider(IServiceLocator serviceLocator, IPutPipelineStepTypesProvider pipelineStepTypesProvider)
            : base(serviceLocator)
        {
            _pipelineStepTypesProvider = pipelineStepTypesProvider;
        }

        public IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] GetSteps<TResourceModel, TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class, IHasIdentifier
        {
            return _closedPipelineStepsByResourceType.GetOrAdd(
                    typeof(TResourceModel),
                    t =>
                    {
                        var stepTypes = _pipelineStepTypesProvider.GetSteps();

                        return ResolvePipelineSteps<PutContext<TResourceModel, TEntityModel>, PutResult, TResourceModel, TEntityModel>(stepTypes);
                    })
                .Cast<IStep<PutContext<TResourceModel, TEntityModel>, PutResult>>()
                .ToArray();
        }
    }
}
