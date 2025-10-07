// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using Microsoft.FeatureManagement;
using NHibernate.Event;

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public class EdFiOdsPreUpdateListener : IPreUpdateEventListener
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPreUpdateListener));
    private readonly bool _serializationEnabled;

    public EdFiOdsPreUpdateListener(IFeatureManager featureManager)
    {
        _serializationEnabled = featureManager.IsFeatureEnabled(ApiFeature.SerializedData);
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

                    try
                    {
                        // If the entity has key changes, skip the serialization for now
                        if (KeyChangeHelper.HasNewKeyValues(aggregateRoot))
                        {
                            // The entity is being updated with a new key value, so the aggregate data serialization is deferred
                            // until the final key change query is executed (see EdFiOdsPostUpdateEventListener)
                            _logger.Debug("Deferring aggregate data serialization for final primary key change query (UPDATE)...");

                            // Clear the aggregate data for now
                            aggregateRoot.AggregateData = null;
                            persister.Set(@event.State, ColumnNames.AggregateData, null);
                        }
                        else
                        {
                            // Update the entity with the last modified date before serializing so that it matches the record's value
                            DateTime originalLastModified = aggregateRoot.LastModifiedDate;
                            var lastModifiedDateForRecord = persister.Get<DateTime>(@event.State, ColumnNames.LastModifiedDate);
                            aggregateRoot.LastModifiedDate = lastModifiedDateForRecord;

                            try
                            {
                                _logger.Debug("Serializing aggregate data to storage (UPDATE)...");

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
                                // Restore the last modified date to the original value (to prevent NHibernate persistence errors)
                                aggregateRoot.LastModifiedDate = originalLastModified;
                            }
                        }
                    }
                    finally
                    {
                        // Stop defaulting the reported CreateDate for transient entities
                        CallContext.SetData("TransientSerializableCreateDateTime", null);
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
