// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Pipelines.Delete;
using EdFi.Ods.Pipelines.Get;
using EdFi.Ods.Pipelines.GetMany;
using EdFi.Ods.Pipelines.Put;

namespace EdFi.Ods.Pipelines.Factories
{
    public interface IPipelineFactory
    {
        IGetPipeline<TResourceModel, TEntityModel> CreateGetPipeline<TResourceModel, TEntityModel>()
            where TResourceModel : class, IHasETag
            where TEntityModel : class;

        IGetManyPipeline<TResourceModel, TEntityModel> CreateGetManyPipeline<TResourceModel, TEntityModel>()
            where TResourceModel : IHasETag
            where TEntityModel : class;

        IPutPipeline<TResourceModel, TEntityModel> CreatePutPipeline<TResourceModel, TEntityModel>()
            where TEntityModel : class, IHasIdentifier, new()
            where TResourceModel : IHasETag;

        IDeletePipeline<TResourceModel, TEntityModel> CreateDeletePipeline<TResourceModel, TEntityModel>();
    }
}
