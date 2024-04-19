// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class UpsertEntity<TEntity> : NHibernateRepositoryOperationBase, IUpsertEntity<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IHasIdentifierSource, IDateVersionedEntity, ISynchronizable
    {
        private readonly ICreateEntity<TEntity> _createEntity;
        private readonly IGetEntityById<TEntity> _getEntityById;
        private readonly IGetEntityByKey<TEntity> _getEntityByKey;
        private readonly IUpdateEntity<TEntity> _updateEntity;
        private readonly IContextProvider<UniqueIdLookupsByUsiContext> _lookupContextProvider;
        private readonly IPersonUniqueIdResolver _personUniqueIdResolver;
        private readonly IContextProvider<DataPolicyException> _dataPolicyExceptionContextProvider;

        public UpsertEntity(
            ISessionFactory sessionFactory,
            IGetEntityById<TEntity> getEntityById,
            IGetEntityByKey<TEntity> getEntityByKey,
            ICreateEntity<TEntity> createEntity,
            IUpdateEntity<TEntity> updateEntity,
            IContextProvider<UniqueIdLookupsByUsiContext> lookupContextProvider,
            IPersonUniqueIdResolver personUniqueIdResolver,
            IContextProvider<DataPolicyException> dataPolicyExceptionContextProvider)
            : base(sessionFactory)
        {
            _getEntityById = getEntityById;
            _getEntityByKey = getEntityByKey;
            _createEntity = createEntity;
            _updateEntity = updateEntity;
            _lookupContextProvider = lookupContextProvider;
            _personUniqueIdResolver = personUniqueIdResolver;
            _dataPolicyExceptionContextProvider = dataPolicyExceptionContextProvider;
        }

        public async Task<UpsertEntityResult<TEntity>> UpsertAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                var isCreated = false;
                var isModified = false;

                // Go try to get the existing entity
                TEntity persistedEntity = null;

                // Do we have an 'Id' value present?
                bool idHasValue = !entity.Id.Equals(default(Guid));

                if (idHasValue)
                {
                    // Look up by provided Id
                    persistedEntity = await _getEntityById.GetByIdAsync(entity.Id, cancellationToken);

                    // If attempt to look up by Id failed, don't allow create to proceed if Id was supplied by API client
                    if (persistedEntity == null && entity.IdSource == IdentifierSource.ClientSupplied)
                    {
                        throw new NotFoundException("scenario66.");
                    }
                }
                else
                {
                    // Get it by primary key
                    persistedEntity = await _getEntityByKey.GetByKeyAsync(entity, cancellationToken);
                }

                // If there is no existing entity...
                if (persistedEntity == null)
                {
                    // Check for a data policy exception detected during mapping processing from resource model to entity model
                    var dataPolicyExceptionFromMapping = _dataPolicyExceptionContextProvider.Get();

                    // If there was a data policy violation detected, throw the exception now that we know we're creating the aggregate
                    if (dataPolicyExceptionFromMapping != null)
                    {
                        throw dataPolicyExceptionFromMapping;
                    }

                    // Create the entity
                    await _createEntity.CreateAsync(entity, enforceOptimisticLock, cancellationToken);
                    persistedEntity = entity;
                    isCreated = true;
                }
                else
                {
                    // Update the entity
                    if (enforceOptimisticLock)
                    {
                        if (!persistedEntity.LastModifiedDate.Equals(entity.LastModifiedDate))
                        {
                            throw new ConcurrencyException("scenario24.");
                        }
                    }

                    // Resolve UniqueIds from USIs now that we may have some values
                    var uniqueIdLookupsByUsiContext = _lookupContextProvider.Get();
                    await uniqueIdLookupsByUsiContext.ResolveAllUniqueIds(_personUniqueIdResolver);

                    // Synchronize using strongly-typed generated code
                    isModified = entity.Synchronize(persistedEntity);

                    // Force aggregate root to be touched with an updated date if aggregate has been modified
                    if (isModified)
                    {
                        // Make root dirty, NHibernate will override the value during insert (through a hook)
                        persistedEntity.LastModifiedDate = persistedEntity.LastModifiedDate.AddSeconds(1);
                    }

                    await _updateEntity.UpdateAsync(persistedEntity, cancellationToken);
                }

                return new UpsertEntityResult<TEntity>
                {
                    Entity = persistedEntity,
                    IsCreated = isCreated,
                    IsModified = isModified
                };
            }
        }
    }
}
