// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using EdFi.Ods.Api.Pipelines.Factories;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Pipelines.Delete
{
    public class DeletePipelineStepsProvider : PipelineStepsProviderBase, IDeletePipelineStepsProvider
    {
        private readonly IDeletePipelineStepTypesProvider _pipelineStepTypesProvider;
        
        private readonly ConcurrentDictionary<Type, IStep[]> _closedPipelineStepsByResourceType 
            = new ConcurrentDictionary<Type, IStep[]>();

        public DeletePipelineStepsProvider(IServiceLocator serviceLocator, IDeletePipelineStepTypesProvider pipelineStepTypesProvider)
            : base(serviceLocator)
        {
            _pipelineStepTypesProvider = pipelineStepTypesProvider;
        }
        
        public IStep<DeleteContext, DeleteResult>[] GetSteps<TResourceModel, TEntityModel>()
        {
            return _closedPipelineStepsByResourceType.GetOrAdd(
                    typeof(TResourceModel),
                    t =>
                    {
                        var stepTypes = _pipelineStepTypesProvider.GetSteps();

                        // ReSharper disable once CoVariantArrayConversion
                        return ResolvePipelineSteps<DeleteContext, DeleteResult, TResourceModel, TEntityModel>(stepTypes);
                    })
                .Cast<IStep<DeleteContext, DeleteResult>>()
                .ToArray();
        }
    }
}
