// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using NHibernate;
using NHibernate.Id;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class CreateEntity<TEntity> : NHibernateRepositoryOperationBase, ICreateEntity<TEntity>
        where TEntity : AggregateRootWithCompositeKey
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(CreateEntity<TEntity>));
        private readonly Dictionary<string, object> _retryPolicyContextData;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;


        public CreateEntity(ISessionFactory sessionFactory, IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
            : base(sessionFactory)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;

            _retryPolicyContextData = new Dictionary<string, object>()
            {
                { "Logger", _logger },
                { "EntityTypeName", typeof(TEntity).Name },
            };
        }

        public async Task CreateAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                var metadata = SessionFactory.GetClassMetadata(typeof(TEntity));

                // Does the entity have assignable, single-valued Id?
                if (metadata.HasIdentifierProperty)
                {
                    var persister = metadata as IEntityPersister;

                    bool hasAssignableIdentifier = metadata.HasIdentifierProperty
                        && persister is { IdentifierGenerator: Assigned };

                    // the belief is that pulling the metadata should already have the entity as a POCO
                    var identifierValue = metadata.GetIdentifier(entity);
                    var identifierDefaultValue = metadata.IdentifierType.ReturnedClass.GetDefaultValue();

                    bool identifierValueAssigned = !object.Equals(identifierValue, identifierDefaultValue);

                    // If Id is assignable...
                    if (hasAssignableIdentifier)
                    {
                        // Make sure identifier has been assigned
                        if (!identifierValueAssigned)
                        {
                            var propertyName = _dataManagementResourceContextProvider.Get()
                                .Resource.IdentifyingProperties.Single()
                                .PropertyName;

                            throw new ValidationException(
                                new ValidationResult($"{propertyName} is required.", new []{ propertyName }),
                                validatingAttribute: null,
                                value: null);
                        }
                    }
                    else
                    {
                        // Make sure identifier has NOT been assigned
                        // NOTE: During normal API operations (mapping JSON resources to entities), this should actually never happen so we'll send it to a 500 status
                        if (identifierValueAssigned)
                        {
                            throw new Exception(
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

                // Save the incoming entity
                await DeadlockPolicyHelper.RetryPolicy.ExecuteAsync(
                    async ctx =>
                    {
                        using var trans = Session.BeginTransaction();

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
                    },
                    _retryPolicyContextData);

                bool IdHasValue()
                {
                    return !entity.Id.Equals(default(Guid));
                }
            }
        }
    }
}
