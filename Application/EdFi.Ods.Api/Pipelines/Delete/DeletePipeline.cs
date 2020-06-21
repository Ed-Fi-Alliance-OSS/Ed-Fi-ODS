// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Pipelines.Delete
{
    public class DeletePipeline : PipelineBase<DeleteContext, DeleteResult>
    {
        public DeletePipeline(
            IStep<DeleteContext, DeleteResult>[] steps,
            IExceptionTranslationProvider exceptionTranslationProvider)
            : base(steps, exceptionTranslationProvider) { }
    }
}
