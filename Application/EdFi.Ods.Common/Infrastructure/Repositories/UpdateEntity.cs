// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using log4net;
using NHibernate;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class UpdateEntity<TEntity> : NHibernateRepositoryOperationBase, IUpdateEntity<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(UpdateEntity<TEntity>));
        private readonly Dictionary<string, object> _retryPolicyContextData;

        public UpdateEntity(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
            _retryPolicyContextData = new Dictionary<string, object>()
            {
                { "Logger", _logger },
                { "EntityTypeName", typeof(TEntity).Name },
            };
        }

        public async Task UpdateAsync(TEntity persistentEntity, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                await DeadlockPolicyHelper.RetryPolicy.ExecuteAsync(
                    async ctx =>
                    {
                        using var trans = Session.BeginTransaction();

                        try
                        {
                            await Session.UpdateAsync(persistentEntity, cancellationToken);
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
            }
        }
    }
}
