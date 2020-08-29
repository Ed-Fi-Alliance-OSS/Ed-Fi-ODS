// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Pipelines.Common;
using EdFi.Ods.Pipelines.GetMany;

namespace EdFi.Ods.Api.Pipelines.GetMany
{
    public interface IGetManyPipelineStepsProvider
    {
        IStep<GetManyContext<TResourceModel, TEntityModel>, GetManyResult<TResourceModel>>[] GetSteps<TResourceModel,
            TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class;
    }
}
