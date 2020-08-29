// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Pipelines.Common;
using EdFi.Ods.Pipelines.Put;

namespace EdFi.Ods.Api.Pipelines.Put
{
    public interface IPutPipelineStepsProvider
    {
        IStep<PutContext<TResourceModel, TEntityModel>, PutResult>[] GetSteps<TResourceModel, TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class, IHasIdentifier;
    }
}
