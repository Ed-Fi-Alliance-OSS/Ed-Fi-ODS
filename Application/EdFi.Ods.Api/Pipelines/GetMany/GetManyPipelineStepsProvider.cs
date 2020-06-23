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
using EdFi.Ods.Pipelines.GetMany;

namespace EdFi.Ods.Api.Pipelines.GetMany
{
    public class GetManyPipelineStepsProvider : PipelineStepsProviderBase, IGetManyPipelineStepsProvider
    {
        private readonly IGetBySpecificationPipelineStepTypesProvider _pipelineStepTypesProvider;
        
        private readonly ConcurrentDictionary<Type, IStep[]> _closedPipelineStepsByResourceType =
            new ConcurrentDictionary<Type, IStep[]>();

        public GetManyPipelineStepsProvider(
            IServiceLocator serviceLocator,
            IGetBySpecificationPipelineStepTypesProvider pipelineStepTypesProvider)
            : base(serviceLocator)
        {
            _pipelineStepTypesProvider = pipelineStepTypesProvider;
        }

        public IStep<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>>[] GetSteps<TResourceModel,
            TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class
        {
            return _closedPipelineStepsByResourceType.GetOrAdd(
                    typeof(TResourceModel),
                    t =>
                    {
                        var stepTypes = _pipelineStepTypesProvider.GetSteps();

                        // ReSharper disable once CoVariantArrayConversion
                        return ResolvePipelineSteps<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>,
                            TResourceModel, TEntityModel>(stepTypes);
                    })
                .Cast<IStep<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>>>()
                .ToArray();
        }
    }
}
