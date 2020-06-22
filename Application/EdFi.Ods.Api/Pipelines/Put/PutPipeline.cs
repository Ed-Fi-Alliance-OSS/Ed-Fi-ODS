// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Pipelines.Put
{
    public interface IPutPipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        Task<PutResult> ProcessAsync(PutContext<TResourceModel, TEntityModel> context, CancellationToken cancellationToken);

        // IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] Steps { get; set; }
    }

    public class PutPipeline<TResourceModel, TEntityModel>
        : PipelineBase<PutContext<TResourceModel, TEntityModel>, PutResult>, IPutPipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        public PutPipeline(
            IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] steps,
            IExceptionTranslationProvider exceptionTranslationProvider)
            : base(steps, exceptionTranslationProvider) { }

        // IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] IPutPipeline<TResourceModel, TEntityModel>.Steps
        // { 
        //     get => _steps;
        //     set => _steps = value;
        // }
    }

    public class StaleDescriptorCachePutPipelineDecorator<TResourceModel, TEntityModel>
        : IPutPipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        private readonly IPutPipeline<TResourceModel, TEntityModel> _decoratedInstance;
        private readonly IDescriptorsCache _descriptorsCache;

        public StaleDescriptorCachePutPipelineDecorator(
            IPutPipeline<TResourceModel, TEntityModel> decoratedInstance,
            // IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] steps,
            IDescriptorsCache descriptorCache)
        {
            _decoratedInstance = decoratedInstance;
            _descriptorsCache = descriptorCache;
            
            // TODO: Ugly spike code - Dealing with Castle shortcoming for supplying arguments into resolution with decorator
            // _decoratedInstance.Steps = steps;
        }

        // IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] IPutPipeline<TResourceModel, TEntityModel>.Steps
        // {
        //     get => _decoratedInstance.Steps;
        //     set => _decoratedInstance.Steps = value;
        // }

        public async Task<PutResult> ProcessAsync(PutContext<TResourceModel, TEntityModel> context, CancellationToken cancellationToken)
        {
            var result = await _decoratedInstance.ProcessAsync(context, cancellationToken);

            if (result.ExceptionTranslation is ReferentialConstraintViolationExceptionTranslationResult referentialViolationResult)
            {
                // Force refresh of the offending descriptor value
                if (_descriptorsCache.TryRefreshSingleDescriptorCache(referentialViolationResult.ReferencedTableName))
                {
                    // Retry the operation once
                    return await _decoratedInstance.ProcessAsync(context, cancellationToken);
                }
            }

            return result;
        }
    }
}
