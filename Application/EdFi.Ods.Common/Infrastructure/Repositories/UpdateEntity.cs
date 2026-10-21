// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using log4net;
using NHibernate;
using Polly;

namespace EdFi.Ods.Common.Infrastructure.Repositories
{
    public class UpdateEntity<TEntity> : NHibernateRepositoryOperationBase, IUpdateEntity<TEntity>
        where TEntity : DomainObjectBase, IHasIdentifier, IDateVersionedEntity
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(UpdateEntity<TEntity>));

        public UpdateEntity(ISessionFactory sessionFactory)
            : base(sessionFactory) { }

        public async Task UpdateAsync(TEntity persistentEntity, CancellationToken cancellationToken)
        {
            using (new SessionScope(SessionFactory))
            {
                // Save the current date/time to context for absolute date/time consistency within the aggregate
                CallContext.SetData("CurrentDateTime", DateTime.UtcNow);

                // Save the incoming entity
                var resilienceContext = ResilienceContextPool.Shared.Get(cancellationToken);
                resilienceContext.Properties.Set(DeadlockPolicyHelper.LoggerKey, _logger);
                resilienceContext.Properties.Set(DeadlockPolicyHelper.EntityTypeNameKey, typeof(TEntity).Name);

                try
                {
                    await DeadlockPolicyHelper.RetryPolicy.ExecuteAsync(
                        async ctx =>
                        {
                            bool isRetry = false;

                            if (ctx.Properties.TryGetValue(DeadlockPolicyHelper.RetriesKey, out int retryCount))
                            {
                                isRetry = true;
                                _logger.Info($"Retry #{retryCount}: Retrying update of '{typeof(TEntity).Name}'...");
                            }

                            using (ITransaction trans = Session.BeginTransaction())
                            {
                                // If the entity supports key changes and a key change is being made...
                                if (persistentEntity is IHasCascadableKeyValues { OriginalKeyValues: not null } persistentEntityWithKeyValues)
                                {
                                    // Restore the original key values to prevent NHibernate from handling the key change portion of the update
                                    persistentEntityWithKeyValues.RestoreOriginalKeyValues();
                                }

                                await Session.UpdateAsync(persistentEntity, cancellationToken);
                                await trans.CommitAsync(cancellationToken);
                            }

                            if (isRetry)
                            {
                                _logger.Info($"Retry #{retryCount}: Successfully updated '{typeof(TEntity).Name}' after {retryCount} retries...");
                            }
                        },
                        resilienceContext);
                }
                finally
                {
                    ResilienceContextPool.Shared.Return(resilienceContext);
                }

                // Clear the contextual current date/time explicitly
                CallContext.SetData("CurrentDateTime", null);
            }
        }
    }
}
