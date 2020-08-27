// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Repositories;

namespace EdFi.Ods.Tests.EdFi.Ods.Common._Stubs.Repositories
{
    public class StubRepositoryBuilder<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        private readonly StubRepository<TEntity> _instance = new StubRepository<TEntity>();

        public StubRepositoryBuilder<TEntity> ResourceIsAlwaysModified
        {
            get
            {
                _instance.StubIsModified(true);
                return this;
            }
        }

        public StubRepositoryBuilder<TEntity> ResourceIsAlwaysCreated
        {
            get
            {
                _instance.StubIsCreated(true);
                return this;
            }
        }

        public StubRepositoryBuilder<TEntity> ResourceIsNeverCreatedOrModified
        {
            get
            {
                _instance.StubIsCreated(false);
                _instance.StubIsModified(false);
                return this;
            }
        }

        public static implicit operator StubRepository<TEntity>(StubRepositoryBuilder<TEntity> builder)
        {
            return builder._instance;
        }

        public StubRepositoryBuilder<TEntity> OnUpsertThrow(Exception e)
        {
            _instance.ExceptionToThrowOnUpsert = e;
            return this;
        }
    }

    public class StubRepository<TEntity> : IUpsertEntity<TEntity>
        where TEntity : IHasIdentifier, IDateVersionedEntity
    {
        private bool _stubIsCreated;
        private bool _stubIsModified;

        public Exception ExceptionToThrowOnUpsert { get; set; }

        public IList<TEntity> GetByIds(IList<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetBySpecification(TEntity specification, IQueryParameters queryParameters)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Guid id, string etag)
        {
            throw new NotImplementedException();
        }

        public void DeleteByKey(TEntity specification, string etag)
        {
            throw new NotImplementedException();
        }

        public void StubIsModified(bool value)
        {
            _stubIsModified = value;
        }

        public void StubIsCreated(bool value)
        {
            _stubIsCreated = value;
        }

        public Task<UpsertEntityResult<TEntity>> UpsertAsync(TEntity entity, bool enforceOptimisticLock,
            CancellationToken cancellationToken)
        {
            if (ExceptionToThrowOnUpsert != null)
            {
                throw ExceptionToThrowOnUpsert;
            }

            return Task.FromResult(new UpsertEntityResult<TEntity>
            {
                Entity = entity,
                IsModified =  _stubIsModified,
                IsCreated = _stubIsCreated
            });
        }
    }
}
