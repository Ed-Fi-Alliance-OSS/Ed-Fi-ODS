// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Dtos;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using NHibernate;
using NHibernate.Id;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Api.Common.Infrastructure.Repositories
{
    public class CreateEntity<TEntity> : ValidatingNHibernateRepositoryOperationBase, ICreateEntity<TEntity>
        where TEntity : AggregateRootWithCompositeKey
    {
        public CreateEntity(ISessionFactory sessionFactory, IEnumerable<IEntityValidator> validators)
            : base(sessionFactory, validators) { }

        public async Task CreateAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                var metadata = SessionFactory.GetClassMetadata(typeof(TEntity));

                // Does the entity have assignable, single-valued Id?
                if (metadata.HasIdentifierProperty)
                {
                    var persister = metadata as AbstractEntityPersister;

                    bool hasAssignableIdentifier = metadata.HasIdentifierProperty
                        && persister != null
                        && persister.IdentifierGenerator is Assigned;

                    // the belief is that pulling the metadata should already have the entity as a POCO
                    var identifierValue = metadata.GetIdentifier(entity);
                    var identifierDefaultValue = metadata.IdentifierType.ReturnedClass.GetDefaultValue();

                    bool identifierValueAssigned = !identifierValue.Equals(identifierDefaultValue);

                    // If Id is assignable...
                    if (hasAssignableIdentifier)
                    {
                        // Make sure identifier has been assigned
                        if (!identifierValueAssigned)
                        {
                            throw new BadRequestException(
                                $"Value for resource's identifier property '{metadata.IdentifierPropertyName}' is required.");
                        }
                    }
                    else
                    {
                        // Make sure identifier has NOT been assigned
                        if (identifierValueAssigned)
                        {
                            throw new BadRequestException(
                                $"Value for the auto-assigned identifier property '{metadata.IdentifierPropertyName}' cannot be assigned by the client (value was '{identifierValue}'.)");
                        }
                    }
                }
                else
                {
                    // Do we have an 'Id' value present?
                    bool idHasValue = IdHasValue();

                    // The primary key is a composite key, so the Id must be a GUID which is client-assignable
                    // However, if the client indicated we should enforce optimistic locking and provided an etag
                    // value, this indicates that the resource has been deleted by another process and should not 
                    // be recreated.  Instead, an exception should be thrown.
                    if (idHasValue && enforceOptimisticLock)
                    {
                        throw new ObjectNotFoundException(
                            $"Aggregate identified by '{entity.Id}' could not be found for update (it may have been deleted by another consumer).", entity.GetType());
                    }

                    // New GUID identifiers are assigned by the NHibernate IPreInsertEventListener implementation
                }

                ValidateEntity(entity);

                // Save the incoming entity
                using (var trans = Session.BeginTransaction())
                {
                    try
                    {
                        await Session.SaveAsync(entity, cancellationToken);
                    }
                    catch (Exception)
                    {
                        await trans.RollbackAsync(cancellationToken);
                        throw;
                    }
                    finally
                    {
                        if (!trans.WasRolledBack)
                        {
                            await trans.CommitAsync(cancellationToken);
                        }
                    }
                }

                bool IdHasValue()
                {
                    return !entity.Id.Equals(default(Guid));
                }
            }
        }
    }
}
