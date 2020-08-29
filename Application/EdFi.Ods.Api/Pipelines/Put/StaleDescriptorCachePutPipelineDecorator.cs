// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Pipelines.Put
{
    public class StaleDescriptorCachePutPipelineDecorator<TResourceModel, TEntityModel>
        : IPutPipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier
    {
        private readonly IPutPipeline<TResourceModel, TEntityModel> _decoratedInstance;
        private readonly IDescriptorsCache _descriptorsCache;

        public StaleDescriptorCachePutPipelineDecorator(
            IPutPipeline<TResourceModel, TEntityModel> decoratedInstance,
            IDescriptorsCache descriptorCache)
        {
            _decoratedInstance = decoratedInstance;
            _descriptorsCache = descriptorCache;
        }

        public async Task<PutResult> ProcessAsync(PutContext<TResourceModel, TEntityModel> context, CancellationToken cancellationToken)
        {
            var result = await _decoratedInstance.ProcessAsync(context, cancellationToken);

            while (result.ExceptionTranslation is ReferentialConstraintViolationExceptionTranslationResult referentialViolationResult)
            {
                // Force refresh of the offending descriptor value
                if (_descriptorsCache.TryRefreshSingleDescriptorCache(referentialViolationResult.ReferencedTableName))
                {
                    // Retry the operation
                    result = await _decoratedInstance.ProcessAsync(context, cancellationToken);
                }
            }

            return result;
        }
    }

    // public class StalePersonCachePutPipelineDecorator<TResourceModel, TEntityModel>
    //     : IPutPipeline<TResourceModel, TEntityModel>
    //     where TResourceModel : IHasETag
    //     where TEntityModel : class, IHasIdentifier
    // {
    //     private readonly IPutPipeline<TResourceModel, TEntityModel> _decoratedInstance;
    //     private readonly IPersonUniqueIdToUsiCache _uniqueIdToUsiCache;
    //
    //     public StalePersonCachePutPipelineDecorator(
    //         IPutPipeline<TResourceModel, TEntityModel> decoratedInstance,
    //         IPersonUniqueIdToUsiCache uniqueIdToUsiCache)
    //     {
    //         _decoratedInstance = decoratedInstance;
    //         _uniqueIdToUsiCache = uniqueIdToUsiCache;
    //     }
    //
    //     public async Task<PutResult> ProcessAsync(PutContext<TResourceModel, TEntityModel> context, CancellationToken cancellationToken)
    //     {
    //         var result = await _decoratedInstance.ProcessAsync(context, cancellationToken);
    //
    //         while (result.ExceptionTranslation is ReferentialConstraintViolationExceptionTranslationResult referentialViolationResult)
    //         {
    //             // Force refresh of the offending descriptor value
    //             if (_uniqueIdToUsiCache.TryRefreshSingleDescriptorCache(referentialViolationResult.ReferencedTableName))
    //             {
    //                 // Retry the operation
    //                 result = await _decoratedInstance.ProcessAsync(context, cancellationToken);
    //             }
    //         }
    //
    //         return result;
    //     }
    // }
}
