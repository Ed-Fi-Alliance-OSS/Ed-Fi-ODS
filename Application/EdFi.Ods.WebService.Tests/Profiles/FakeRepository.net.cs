// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Repositories;
using EdFi.TestObjects;
using TechTalk.SpecFlow;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class FakeRepository<TEntity>
        : IGetEntityById<TEntity>,
            IUpsertEntity<TEntity>,
            IGetEntitiesBySpecification<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        private readonly ITestObjectFactory _factory;

        public FakeRepository(ITestObjectFactory testObjectFactory)
        {
            _factory = testObjectFactory;
        }

        public IDictionary<Guid, TEntity> EntitiesById
        {
            get
            {
                string featureContextKey = typeof(TEntity).Name + "FakeRepositoryDictionary";

                IDictionary<Guid, TEntity> entitiesById;

                if (!FeatureContext.Current.TryGetValue(featureContextKey, out entitiesById))
                {
                    entitiesById = new Dictionary<Guid, TEntity>();
                    FeatureContext.Current.Set(entitiesById, featureContextKey);
                }

                return entitiesById;
            }
        }

        public async Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(
            TEntity specification,
            IQueryParameters queryParameters,
            CancellationToken cancellationToken)
        {
            if (EntitiesById.Count == 0)
            {
                await GetByIdAsync(Guid.NewGuid(), cancellationToken);
            }

            return
                new GetBySpecificationResult<TEntity>
                {
                    Results = EntitiesById.Values.ToList()
                };
        }

        /// <summary>
        /// Gets a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The value of the unique identifier.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            TEntity value;

            if (EntitiesById.TryGetValue(id, out value))
            {
                return Task.FromResult(value);
            }

            var entity = _factory.Create<TEntity>();
            entity.Id = id;

            EntitiesById[entity.Id] = entity;
            return Task.FromResult(entity);
        }

        public Task<UpsertEntityResult<TEntity>> UpsertAsync(TEntity entity, bool enforceOptimisticLock,
            CancellationToken cancellationToken)
        {
            bool isModified = false;
            bool isCreated = false;

            // If the entity already exists, synchronize the entity the same way the real repository does
            if (EntitiesById.TryGetValue(entity.Id, out TEntity existingEntity))
            {
                (entity as ISynchronizable).Synchronize(existingEntity);
                isModified = true;
            }
            else
            {
                EntitiesById[entity.Id] = entity;
                isCreated = true;
            }

            return Task.FromResult(new UpsertEntityResult<TEntity>
            {
                Entity = entity,
                IsModified = isModified,
                IsCreated = isCreated
            });
        }
    }
}
#endif