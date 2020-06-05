// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.GetDeletedResource
{
    public class GetDeletedResourcePipeline<TEntityModel>:PipelineBase<GetDeletedResourceContext<TEntityModel>, GetDeletedResourceResult>
        where TEntityModel : class
    {
        public GetDeletedResourcePipeline(IStep<GetDeletedResourceContext<TEntityModel>, GetDeletedResourceResult>[] steps)
            : base(steps)
        {
        }
    }
}
