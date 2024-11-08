// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using NHibernate.Event;

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public class EdFiOdsPreUpdateListener : IPreUpdateEventListener
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPreUpdateListener));
    private readonly bool _serializationEnabled;

    public EdFiOdsPreUpdateListener(ApiSettings apiSettings)
    {
        _serializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.SerializedData.GetConfigKeyName());
    }

    public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
    {
        var result = OnPreUpdate(@event);

        return Task.FromResult(result);
    }

    public bool OnPreUpdate(PreUpdateEvent @event)
    {
        if (_serializationEnabled)
        {
            if (@event.Entity is AggregateRootWithCompositeKey aggregateRoot)
            {
                try
                {
                    var persister = @event.Persister;

                    // Get the established current date/time from context for absolute date/time consistency within the aggregate
                    DateTime currentDateTime = (DateTime) (CallContext.GetData("CurrentDateTime") ?? DateTime.UtcNow);

                    // Update the entity (and state for persistence) with the same LastModifiedDate before serializing
                    aggregateRoot.LastModifiedDate = currentDateTime;
                    persister.Set(@event.State, ColumnNames.LastModifiedDate, currentDateTime);

                    // Produce the serialized data and update the persistence state
                    var aggregateData = MessagePackHelper.SerializeAndCompressAggregateData(aggregateRoot);
                    aggregateRoot.AggregateData = aggregateData;
                    persister.Set(@event.State, ColumnNames.AggregateData, aggregateData);

                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug($"MessagePack bytes for updated entity: {aggregateData.Length:N0}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"An unexpected error occurred while serializing entity data on entity '{@event.Entity.GetType().Name}'...", ex);

                    throw;
                }
            }
        }

        return false;
    }
}
