// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class GetEntityModelById<TContext, TResult, TResourceModel, TEntityModel> : IStep<TContext, TResult>
        where TContext : IHasIdentifier, IHasPersistentModel<TEntityModel>
        where TResult : PipelineResultBase
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntityById<TEntityModel> _repository;

        public GetEntityModelById(IGetEntityById<TEntityModel> repository)
        {
            _repository = repository;
        }

        public void Execute(TContext context, TResult result)
            => ExecuteAsync(context, result, CancellationToken.None).WaitSafely();

        public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                // Load the entities
                var model = await _repository.GetByIdAsync(context.Id, cancellationToken);

                if (model == null)
                {
                    string message = $"Entity of type '{typeof(TEntityModel).Name}' with the specified id was not found.";

                    // Capture exception information, but don't throw it for performance reasons
                    result.Exception = new NotFoundException(message, typeof(TEntityModel).Name, null);

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
