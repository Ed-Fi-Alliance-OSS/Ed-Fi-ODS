// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Pipelines;
using EdFi.Ods.Pipelines.Common;

namespace EdFi.Ods.Api.Pipelines.Steps
{
    public class MapResourceModelToEntityModel<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>, IHasResource<TResourceModel>
        where TResult : PipelineResultBase
        where TResourceModel : class, IMappable, IHasETag
        where TEntityModel : class, new()
    {
        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                if (context.Resource == default(TResourceModel))
                {
                    return Task.CompletedTask;
                }

                var model = new TEntityModel();
                context.Resource.Map(model);
                context.PersistentModel = model;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return Task.CompletedTask;
        }
    }
}
