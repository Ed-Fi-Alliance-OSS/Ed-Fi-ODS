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
using EdFi.Ods.Pipelines.Get;

namespace EdFi.Ods.Api.Pipelines.Get
{
    public class GetPipelineStepsProvider : PipelineStepsProviderBase, IGetPipelineStepsProvider
    {
        private readonly IGetPipelineStepTypesProvider _pipelineStepTypesProvider;
        
        private readonly ConcurrentDictionary<Type, IStep[]> _closedPipelineStepsByResourceType =
            new ConcurrentDictionary<Type, IStep[]>();

        public GetPipelineStepsProvider(
            IServiceLocator serviceLocator,
            IGetPipelineStepTypesProvider pipelineStepTypesProvider)
            : base(serviceLocator)
        {
            _pipelineStepTypesProvider = pipelineStepTypesProvider;
        }

        public IStep<GetContext<TEntityModel>, GetResult<TResourceModel>>[] GetSteps<TResourceModel, TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class
        {
            return _closedPipelineStepsByResourceType.GetOrAdd(
                    typeof(TResourceModel),
                    t =>
                    {
                        var stepTypes = _pipelineStepTypesProvider.GetSteps();

                        // ReSharper disable once CoVariantArrayConversion
                        return ResolvePipelineSteps<GetContext<TEntityModel>, GetResult<TResourceModel>,
                            TResourceModel, TEntityModel>(stepTypes);
                    })
                .Cast<IStep<GetContext<TEntityModel>, GetResult<TResourceModel>>>()
                .ToArray();
        }
    }
}
