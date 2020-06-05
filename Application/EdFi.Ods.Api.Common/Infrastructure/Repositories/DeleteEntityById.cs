// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using NHibernate;
using NHibernate.Context;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    public class DeleteEntityById<TEntity>
        : NHibernateRepositoryDeleteOperationBase<TEntity>, IDeleteEntityById<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntityById<TEntity> _getEntityById;

        public DeleteEntityById(ISessionFactory sessionFactory, IGetEntityById<TEntity> getEntityById, IETagProvider eTagProvider)
            : base(sessionFactory, eTagProvider)
        {
            _getEntityById = getEntityById;
        }

        public async Task DeleteByIdAsync(Guid id, string etag, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                // First we must load the entity (this call is also used by the authorization decorators
                // to authorize according to the value returned by the GetById method).
                var persistedEntity = await _getEntityById.GetByIdAsync(id, cancellationToken);

                await DeleteAsync(persistedEntity, etag, cancellationToken);
            }
        }
    }
}
