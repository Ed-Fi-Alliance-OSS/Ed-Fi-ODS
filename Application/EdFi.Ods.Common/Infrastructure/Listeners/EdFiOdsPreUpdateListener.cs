// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
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
                var persister = @event.Persister;

                // Update the entity with the last modified date before serializing
                var lastModifiedDate = persister.Get<DateTime>(@event.State, ColumnNames.LastModifiedDate);
                aggregateRoot.LastModifiedDate = lastModifiedDate;

                // Produce the serialized data
                var aggregateData = MessagePackHelper.SerializeAndCompressAggregateData(aggregateRoot);
                aggregateRoot.AggregateData = aggregateData;

                // Update the state
                persister.Set(@event.State, ColumnNames.AggregateData, aggregateRoot.AggregateData);

                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"MessagePack bytes for updated entity: {aggregateData.Length:N0}");
                }
            }
        }

        return false;
    }
}
