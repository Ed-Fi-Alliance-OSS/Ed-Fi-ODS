// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Pipelines.GetMany;
using EdFi.Ods.Common;

namespace EdFi.Ods.Pipelines.GetMany
{
    public interface IGetManyPipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class
    {
        Task<GetManyResult<TResourceModel>> ProcessAsync(GetManyContext<TResourceModel, TEntityModel> context, CancellationToken cancellationToken);
    }
    
    public class GetManyPipeline<TResourceModel, TEntityModel>
        : PipelineBase<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>>, IGetManyPipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class
    {
        public GetManyPipeline(
            IGetManyPipelineStepsProvider pipelineStepsProvider,
            IExceptionTranslationProvider exceptionTranslationProvider)
            : base(pipelineStepsProvider.GetSteps<TResourceModel, TEntityModel>(), exceptionTranslationProvider) { }
    }
}
