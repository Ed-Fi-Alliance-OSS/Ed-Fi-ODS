// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Infrastructure.Pipelines.Steps
{
    public class GetModelsByIds<TContext, TResult, TResourceModel, TEntityModel>
        : IStep<TContext, TResult>
        where TContext : IHasPersistentModels<TEntityModel>, IHasIdentifiers<Guid>
        where TResult : PipelineResultBase
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier, IDateVersionedEntity, IMappable
    {
        private readonly IGetEntitiesByIds<TEntityModel> _repository;

        public GetModelsByIds(IGetEntitiesByIds<TEntityModel> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                // Load the entity
                var models = await _repository.GetByIdsAsync(context.Ids, cancellationToken);

                // If it wasn't found, throw an exception
                if (context.Ids.Count == 1 && models.Count == 0)
                {
                    string message = string.Format(
                        "Entity of type '{0}' with id of '{1}' was not found.",
                        typeof(TEntityModel).Name,
                        context.Ids[0]);

                    // Capture exception information, but don't throw it for performance reasons
                    result.Exception = new NotFoundException(
                        NotFoundException.DefaultItemDetail,
                        message,
                        typeof(TEntityModel).Name,
                        context.Ids[0].ToString());

                    return;
                }

                context.PersistentModels = models.Select(e => new ResultItem<TEntityModel>(e)).ToArray();;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
        }
    }
}
