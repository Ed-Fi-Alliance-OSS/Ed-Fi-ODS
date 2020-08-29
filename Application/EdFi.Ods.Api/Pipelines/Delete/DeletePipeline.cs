// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.ExceptionHandling;

namespace EdFi.Ods.Pipelines.Delete
{
    public interface IDeletePipeline<TResourceModel, TEntityModel>
    {
        Task<DeleteResult> ProcessAsync(DeleteContext context, CancellationToken cancellationToken);
    }

    public class DeletePipeline<TResourceModel, TEntityModel> : PipelineBase<DeleteContext, DeleteResult>, IDeletePipeline<TResourceModel, TEntityModel>
    {
        public DeletePipeline(
            IDeletePipelineStepsProvider pipelineStepsProvider,
            IExceptionTranslationProvider exceptionTranslationProvider)
            : base(pipelineStepsProvider.GetSteps<TResourceModel, TEntityModel>(), exceptionTranslationProvider) { }
    }
}
