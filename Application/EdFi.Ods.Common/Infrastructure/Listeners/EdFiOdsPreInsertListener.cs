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

namespace EdFi.Ods.Common.Infrastructure.Listeners
{
    public class EdFiOdsPreInsertListener : IPreInsertEventListener
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPreInsertListener));
        private readonly bool _serializationEnabled;

        public EdFiOdsPreInsertListener(ApiSettings apiSettings)
        {
            _serializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.SerializedData.GetConfigKeyName());
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            var result = OnPreInsert(@event);

            return Task.FromResult(result);
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var persister = @event.Persister;

            persister.Set(@event.State, "CreateDate", DateTime.UtcNow);

            if (@event.Entity is AggregateRootWithCompositeKey aggregateRoot)
            {
                int idIndex = persister.GetPropertyIndex("Id");

                // Create a new Guid if one was not assigned by client
                Guid assignedId = (Guid)@event.State[idIndex];

                if (assignedId == default)
                {
                    Guid newGuid = Guid.NewGuid();
                    @event.State[idIndex] = newGuid;

                    // TODO: Need to be verified that this step provides the aggregate's Id
                    // to derived classes that about to be inserted (e.g. EdOrg -> School).
                    // The derived class should have the same Id value in the table.
                    aggregateRoot.Id = newGuid;
                }

                if (_serializationEnabled)
                {
                    var lastModifiedDate = persister.Get<DateTime>(@event.State, ColumnNames.LastModifiedDate);
                    aggregateRoot.LastModifiedDate = lastModifiedDate;

                    // Produce the serialized data
                    var resourceData = MessagePackHelper.SerializeAndCompressAggregateData(aggregateRoot);
                    aggregateRoot.AggregateData = resourceData;

                    // Update the state
                    persister.Set(@event.State, ColumnNames.AggregateData, aggregateRoot.AggregateData);

                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug($"MessagePack bytes for updated entity: {resourceData.Length:N0}");
                    }
                }
            }

            return false;
        }
    }
}
