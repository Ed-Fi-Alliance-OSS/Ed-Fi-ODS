// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps
{
    public class GetEntityModelById<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasIdentifier, IHasPersistentModel<TEntityModel>
        where TResult : PipelineResultBase
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier, IDateVersionedEntity, IMappable
    {
        private readonly IGetEntityById<TEntityModel> _repository;

        public GetEntityModelById(IGetEntityById<TEntityModel> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                // Load the entities
                var model = await _repository.GetByIdAsync(context.Id, cancellationToken);

                if (model == null)
                {
                    string message = string.Format(
                        "Entity of type '{0}' with id of '{1}' was not found.",
                        typeof(TEntityModel).Name,
                        context.Id);
                    
                    // Capture exception information, but don't throw it for performance reasons
                    result.Exception = new NotFoundException(
                        NotFoundException.DefaultItemDetail,
                        message,
                        typeof(TEntityModel).Name,
                        context.Id.ToString());

                    return;
                }

                context.PersistentModel = model;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
        }
    }
}
