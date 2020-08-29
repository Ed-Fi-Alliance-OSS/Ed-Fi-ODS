// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Pipelines.Get;
using EdFi.Ods.Common;

namespace EdFi.Ods.Pipelines.Get
{
    public interface IGetPipeline<TResourceModel, TEntityModel>
        where TResourceModel : class, IHasETag
        where TEntityModel : class
    {
        Task<GetResult<TResourceModel>> ProcessAsync(GetContext<TEntityModel> context, CancellationToken cancellationToken);
    }

    public class GetPipeline<TResourceModel, TEntityModel> : PipelineBase<GetContext<TEntityModel>, GetResult<TResourceModel>>, IGetPipeline<TResourceModel, TEntityModel>
        where TResourceModel : class, IHasETag
        where TEntityModel : class
    {
        public GetPipeline(
            IGetPipelineStepsProvider pipelineStepsProvider,
            IExceptionTranslationProvider exceptionTranslationProvider)
            : base(pipelineStepsProvider.GetSteps<TResourceModel, TEntityModel>().ToArray(), exceptionTranslationProvider) { }
    }
}
