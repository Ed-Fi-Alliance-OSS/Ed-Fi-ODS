// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

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
                // If the persistent entity is detached (deserialized from root record), attach it now 
                if (!Session.Contains(persistentEntity))
                {
                    await Session.LockAsync(persistentEntity, LockMode.None, cancellationToken).ConfigureAwait(false);
                }

                // Save the incoming entity
                await DeadlockPolicyHelper.RetryPolicy.ExecuteAsync(
                    async ctx =>
                    {
                        bool isRetry = false;
                        
                        if (ctx.TryGetValue("Retries", out object retryCount))
                        {
                            isRetry = true;
                            _logger.Info($"Retry #{retryCount}: Retrying update of '{typeof(TEntity).Name}'...");
                        }

                        using (ITransaction trans = Session.BeginTransaction())
                        {
                            await Session.UpdateAsync(persistentEntity, cancellationToken);
                            await trans.CommitAsync(cancellationToken);
                        }
                        
                        if (isRetry)
                        {
                            _logger.Info($"Retry #{retryCount}: Successfully updated '{typeof(TEntity).Name}' after {retryCount} retries...");
                        }
                    },
                    _retryPolicyContextData);
            }
        }
    }
}
