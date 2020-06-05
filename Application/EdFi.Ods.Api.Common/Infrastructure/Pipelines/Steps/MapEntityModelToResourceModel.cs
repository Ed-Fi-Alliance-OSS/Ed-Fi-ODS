// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class MapEntityModelToResourceModel<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>
        where TResult : PipelineResultBase, IHasResource<TResourceModel>
        where TResourceModel : IHasETag, new()
        where TEntityModel : class, IMappable
    {
        public void Execute(TContext context, TResult result)
        {
            // NOTE this step will always run synchronously so we are not moving the logic to the async method.
            try
            {
                var resource = new TResourceModel();

                context.PersistentModel.Map(resource);

                result.Resource = resource;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            Execute(context, result);
            return Task.CompletedTask;
        }
    }
}
