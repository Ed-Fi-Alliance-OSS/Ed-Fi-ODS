// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure.Pipelines;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Put
{
    public class PutPipeline<TResourceModel, TEntityModel> : PipelineBase<PutContext<TResourceModel, TEntityModel>, PutResult>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier, IMappable
    {
        public PutPipeline(IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] steps)
            : base(steps) { }
    }
}
