// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Put;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps
{
    public class PersistEntityModel<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : PutContext<TResourceModel, TEntityModel> // TODO: Is there a PersistenceContext? Maybe only when supporting PUT creational semantics?
        where TResult : PutResult
        where TEntityModel : class, IHasIdentifier, IDateVersionedEntity
        where TResourceModel : IHasETag
    {
        private readonly IETagProvider _etagProvider;
        private readonly IUpsertEntity<TEntityModel> _upsertEntity;

        public PersistEntityModel(IUpsertEntity<TEntityModel> upsertEntity, IETagProvider etagProvider)
        {
            _upsertEntity = upsertEntity;
            _etagProvider = etagProvider;
        }

        public async Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            try
            {
                var updatedEntityResult = await _upsertEntity.UpsertAsync(
                    context.PersistentModel,
                    context.EnforceOptimisticLock, cancellationToken);

                context.PersistentModel = updatedEntityResult.Entity;

                // Set the resulting resource's identifier
                if (result.ResourceId == null)
                {
                    result.ResourceId = updatedEntityResult.Entity.Id;
                }

                result.ResourceWasCreated = updatedEntityResult.IsCreated;
                result.ResourceWasUpdated = updatedEntityResult.IsModified;
                result.ResourceWasPersisted = true;

                // Set the etag value
                result.ETag = _etagProvider.GetETag(updatedEntityResult.Entity);
            }

            catch (Exception ex)
            {
                result.Exception = ex;
            }
        }
    }
}
