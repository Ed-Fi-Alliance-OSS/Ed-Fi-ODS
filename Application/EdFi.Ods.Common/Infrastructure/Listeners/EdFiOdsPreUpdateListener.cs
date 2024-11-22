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
                    DateTime currentDateTime = (DateTime)(CallContext.GetData("CurrentDateTime") ?? DateTime.UtcNow);

                    // Set a date context that will cause all transient entities to report the assigned date without affecting the entity itself
                    CallContext.SetData("TransientSerializableCreateDateTime", currentDateTime);

                    // Update the entity with the last modified date before serializing
                    DateTime originalLastModified = aggregateRoot.LastModifiedDate;
                    var lastModifiedDate = persister.Get<DateTime>(@event.State, ColumnNames.LastModifiedDate);
                    aggregateRoot.LastModifiedDate = lastModifiedDate;

                    try
                    {
                        // Produce the serialized data
                        var aggregateData = MessagePackHelper.SerializeAndCompressAggregateData(aggregateRoot);
                        aggregateRoot.AggregateData = aggregateData;

                        // Update the persistence state
                        persister.Set(@event.State, ColumnNames.AggregateData, aggregateData);

                        if (_logger.IsDebugEnabled)
                        {
                            _logger.Debug($"MessagePack bytes for updated entity: {aggregateData.Length:N0}");
                        }
                    }
                    finally
                    {
                        // Stop defaulting the reported CreateDate for transient entities
                        CallContext.SetData("TransientSerializableCreateDateTime", null);

                        // Restore the last modified date to the original value
                        aggregateRoot.LastModifiedDate = originalLastModified;
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
