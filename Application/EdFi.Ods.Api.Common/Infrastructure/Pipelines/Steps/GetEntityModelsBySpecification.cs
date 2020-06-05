// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.GetMany;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class GetEntityModelsBySpecification<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : GetManyContext<TResourceModel, TEntityModel>
        where TResult : PipelineResultBase
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntitiesBySpecification<TEntityModel> _repository;

        public GetEntityModelsBySpecification(IGetEntitiesBySpecification<TEntityModel> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                // Load the entities
                var specificationResult = await _repository.GetBySpecificationAsync(
                    context.PersistentModel, context.QueryParameters, cancellationToken);

                context.PersistentModels = specificationResult.Results;
                result.ResultMetadata = specificationResult.ResultMetadata;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
        }
    }
}
