// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Pipelines;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Pipelines.Put;

namespace EdFi.Ods.Api.Pipelines
{
    public abstract class
        CreateOrUpdatePipeline<TResourceModel, TEntityModel> : ICreateOrUpdatePipeline<TResourceModel, TEntityModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier, new()
    {
        private readonly PutPipeline<TResourceModel, TEntityModel> _pipeline;

        protected CreateOrUpdatePipeline(IPipelineFactory factory)
        {
            _pipeline = factory.CreatePutPipeline<TResourceModel, TEntityModel>();
        }

        public async Task<PutResult> ProcessAsync(
            PutContext<TResourceModel, TEntityModel> context,
            CancellationToken cancellationToken)
        {
            return await _pipeline.ProcessAsync(context, cancellationToken);
        }
    }
}
