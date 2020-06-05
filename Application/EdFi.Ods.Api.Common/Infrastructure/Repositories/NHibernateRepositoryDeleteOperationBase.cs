// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using NHibernate;
using NHibernate.Context;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    public class NHibernateRepositoryDeleteOperationBase<TEntity>
        : NHibernateRepositoryOperationBase
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IETagProvider _eTagProvider;

        public NHibernateRepositoryDeleteOperationBase(ISessionFactory sessionFactory, IETagProvider eTagProvider)
            : base(sessionFactory)
        {
            _eTagProvider = eTagProvider;
        }

        protected async Task DeleteAsync(TEntity persistedEntity, string etag, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                if (persistedEntity == null)
                {
                    throw new NotFoundException("Resource to delete was not found.");
                }

                // only check last modified data
                if (!string.IsNullOrEmpty(etag))
                {
                    var lastModifiedDate = _eTagProvider.GetDateTime(etag);

                    if (!persistedEntity.LastModifiedDate.Equals(lastModifiedDate))
                    {
                        throw new ConcurrencyException("Resource was modified by another consumer.");
                    }
                }

                using (var trans = Session.BeginTransaction())
                {
                    try
                    {
                        var classMetadata = (AbstractEntityPersister) Session.SessionFactory.GetClassMetadata(typeof(TEntity));

                        string entityName = classMetadata.IsInherited
                            ? classMetadata.MappedSuperclass
                            : classMetadata.Name;

                        await Session.CreateQuery($"delete from {entityName} where Id = :id")
                            .SetParameter("id", persistedEntity.Id)
                            .ExecuteUpdateAsync(cancellationToken);

                        await trans.CommitAsync(cancellationToken);
                    }
                    catch (Exception)
                    {
                        await trans.RollbackAsync(cancellationToken);
                        throw;
                    }
                }
            }
        }
    }
}
