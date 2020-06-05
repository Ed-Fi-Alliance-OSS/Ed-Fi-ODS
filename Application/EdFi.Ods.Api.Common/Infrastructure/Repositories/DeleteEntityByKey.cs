// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
    public class DeleteEntityByKey<TEntity> : NHibernateRepositoryDeleteOperationBase<TEntity>, IDeleteEntityByKey<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntityByKey<TEntity> _getEntityByKey;

        public DeleteEntityByKey(
            ISessionFactory sessionFactory,
            IGetEntityByKey<TEntity> getEntityByKey,
            IETagProvider eTagProvider)
            : base(sessionFactory, eTagProvider)
        {
            _getEntityByKey = getEntityByKey;
        }

        public async Task DeleteByKeyAsync(TEntity specification, string etag, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                // First we must load the entity
                var persistedEntity = await _getEntityByKey.GetByKeyAsync(specification, cancellationToken);

                await DeleteAsync(persistedEntity, etag, cancellationToken);
            }
        }
    }
}
