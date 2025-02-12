// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Listeners;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Http;
using NHibernate;

namespace EdFi.Ods.Common.Repositories;

public class EntityDeserializer : IEntityDeserializer
{
    private readonly ISurrogateIdMutator[] _surrogateIdMutators;
    private readonly ISessionFactory _sessionFactory;
    private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
    private readonly IDeserializationContextProvider _deserializationContextProvider;

    private readonly ILog _logger = LogManager.GetLogger(typeof(EntityDeserializer));

    private long _deserializationFailedCount;
    private DateTime _lastDeserializationWarningTime;
    private readonly TimeSpan _deserializationWarningPeriod = TimeSpan.FromMinutes(5);

    public EntityDeserializer(
        ISurrogateIdMutator[] surrogateIdMutators,
        ISessionFactory sessionFactory,
        IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
        IDeserializationContextProvider deserializationContextProvider)
    {
        _surrogateIdMutators = surrogateIdMutators;
        _sessionFactory = sessionFactory;
        _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        _deserializationContextProvider = deserializationContextProvider;
    }

    public async Task<TEntity> DeserializeAsync<TEntity>(IItemRawData itemRawData)
    {
        TEntity entity;

        // Indicate that deserialization is starting
        _deserializationContextProvider.SetState(true);

        try
        {
            // Deserialize the entity
            entity = MessagePackHelper.DecompressAndDeserializeAggregate<TEntity>(itemRawData.AggregateData);
        }
        catch (Exception ex)
        {
            Interlocked.Increment(ref _deserializationFailedCount);

            // Determine if "quiet" period for logging warnings has elapsed
            if (DateTime.Now > (_lastDeserializationWarningTime + _deserializationWarningPeriod))
            {
                // Reset the tracking variables
                _lastDeserializationWarningTime = DateTime.Now;
                var failedCount = Interlocked.Exchange(ref _deserializationFailedCount, 0);

                string messageCountAddendum = null;

                if (failedCount > 1)
                {
                    messageCountAddendum = $" and {failedCount - 1:N0} other item(s) since last warning";
                }

                // Prevent exceptions during deserialization from failing the processing -- revert to returning a null instance
                _logger.Warn($"Unable to deserialize entity of type '{typeof(TEntity).Name}' (with AggregateId of {itemRawData.AggregateId}){messageCountAddendum}. Falling back to load through NHibernate repository. HINT: Serialized data is in an inconsistent state. Clear the values in the 'AggregateData' column for the affected records. Next warning won't occur until '{_lastDeserializationWarningTime.Add(_deserializationWarningPeriod)}'...", ex);
            }

            return default;
        }
        finally
        {
            // Indicate that deserialization is finished
            _deserializationContextProvider.SetState(false);
        }

        // Apply surrogate id mutators to set the surrogate id value onto the entity if not already assigned yet
        foreach (var mutator in _surrogateIdMutators)
        {
            if (mutator.TrySetSurrogateId(entity, itemRawData))
            {
                break;
            }
        }

        // If we're going to use the deserialized entity with NHibernate, bring it into the current session
        if (_dataManagementResourceContextProvider.Get().HttpMethod != HttpMethods.Get)
        {
            // Add the entity to the current session and, importantly, snapshot it.
            using var scope = new SessionScope(_sessionFactory);
            await scope.Session.LockAsync(entity, LockMode.None).ConfigureAwait(false);
        }

        return entity;
    }
}
