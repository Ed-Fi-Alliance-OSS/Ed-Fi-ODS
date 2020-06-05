// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using NHibernate;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    public class NHibernateRepository<TEntity>
        : IRepository<TEntity>,
            IGetEntitiesByIds<TEntity>,
            IUpsertEntity<TEntity>,
            IGetEntitiesBySpecification<TEntity>,
            IDeleteEntityById<TEntity>,
            IDeleteEntityByKey<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        private readonly IDeleteEntityById<TEntity> _deleteEntityById;
        private readonly IDeleteEntityByKey<TEntity> _deleteEntityByKey;
        private readonly IGetEntitiesByIds<TEntity> _getEntitiesByIds;
        private readonly IGetEntitiesBySpecification<TEntity> _getEntitiesBySpecification;
        private readonly IUpsertEntity<TEntity> _upsertEntity;

        public NHibernateRepository(
            ISessionFactory sessionFactory,
            IGetEntitiesByIds<TEntity> getEntitiesByIds,
            IGetEntitiesBySpecification<TEntity> getEntitiesBySpecification,
            IUpsertEntity<TEntity> upsertEntity,
            IDeleteEntityById<TEntity> deleteEntityById,
            IDeleteEntityByKey<TEntity> deleteEntityByKey)
        {
            _getEntitiesByIds = getEntitiesByIds;
            _getEntitiesBySpecification = getEntitiesBySpecification;
            _upsertEntity = upsertEntity;
            _deleteEntityById = deleteEntityById;
            _deleteEntityByKey = deleteEntityByKey;

            SessionFactory = sessionFactory;
        }

        public ISessionFactory SessionFactory { get; }

        public async Task<IList<TEntity>> GetByIdsAsync(IList<Guid> ids, CancellationToken cancellationToken)
            => await _getEntitiesByIds.GetByIdsAsync(ids, cancellationToken);

        public async Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(TEntity specification,
            IQueryParameters queryParameters, CancellationToken cancellationToken)
            => await _getEntitiesBySpecification.GetBySpecificationAsync(specification, queryParameters, cancellationToken);

        public async Task<UpsertEntityResult<TEntity>> UpsertAsync(TEntity entity, bool enforceOptimisticLock,
            CancellationToken cancellationToken)
            => await _upsertEntity.UpsertAsync(entity, enforceOptimisticLock, cancellationToken);

        public async Task DeleteByIdAsync(Guid id, string etag, CancellationToken cancellationToken)
            => await _deleteEntityById.DeleteByIdAsync(id, etag, cancellationToken);

        public async Task DeleteByKeyAsync(TEntity specification, string etag, CancellationToken cancellationToken)
            => await _deleteEntityByKey.DeleteByKeyAsync(specification, etag, cancellationToken);
    }
}
