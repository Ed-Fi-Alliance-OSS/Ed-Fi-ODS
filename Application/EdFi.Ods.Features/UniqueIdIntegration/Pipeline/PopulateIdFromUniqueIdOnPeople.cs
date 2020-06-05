// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Features.UniqueIdIntegration.Pipeline
{
    public class PopulateIdFromUniqueIdOnPeople<TContext, TResult, TResourceModel, TEntityModel> 
        : IStep<TContext, TResult>
        where TContext : IHasPersistentModel<TEntityModel>, IHasResource<TResourceModel>
        where TResourceModel : IHasETag
        where TEntityModel : class, IHasIdentifierSource
        where TResult : PipelineResultBase
    {
        private readonly IPersonUniqueIdToIdCache _personUniqueIdToIdCache;

        public PopulateIdFromUniqueIdOnPeople(IPersonUniqueIdToIdCache personUniqueIdToIdCache)
        {
            _personUniqueIdToIdCache = personUniqueIdToIdCache;
        }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            if (!PersonEntitySpecification.IsPersonEntity(typeof(TResourceModel)))
            {
                return Task.CompletedTask;
            }

            var entityWithId = context.PersistentModel as IHasIdentifier;

            if (entityWithId == null || entityWithId.Id != default(Guid))
            {
                return Task.CompletedTask;
            }

            var uniqueId = ((IIdentifiablePerson) context.Resource).UniqueId;
            var id = _personUniqueIdToIdCache.GetId(typeof(TResourceModel).Name, uniqueId);

            entityWithId.Id = id;

            // Mark identifier as being system supplied
            var entityWithIdSource = context.PersistentModel as IHasIdentifierSource;
            entityWithIdSource.IdSource = IdentifierSource.SystemSupplied;

            return Task.CompletedTask;
        }
    }
}
