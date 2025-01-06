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
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using Microsoft.FeatureManagement;
using NHibernate.Event;

namespace EdFi.Ods.Common.Infrastructure.Listeners
{
    public class EdFiOdsPreInsertListener : IPreInsertEventListener
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPreInsertListener));
        private readonly bool _serializationEnabled;

        public EdFiOdsPreInsertListener(IFeatureManager featureManager)
        {
            _serializationEnabled = featureManager.IsFeatureEnabled(ApiFeature.SerializedData);
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            var result = OnPreInsert(@event);

            return Task.FromResult(result);
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var persister = @event.Persister;

            // Get the established current date/time from context for absolute date/time consistency within the aggregate
            DateTime currentDateTime = (DateTime) (CallContext.GetData("CurrentDateTime") ?? DateTime.UtcNow);

            // Set the CreateDate persistence state
            persister.Set(@event.State, ColumnNames.CreateDate, currentDateTime);

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
                    try
                    {
                        // Get the LastModifiedDate assigned by NHibernate
                        DateTime originalLastModifiedDate = aggregateRoot.LastModifiedDate;

                        // Set additional properties on entity so that they're reflected correctly in serialized data
                        aggregateRoot.CreateDate = currentDateTime;
                        aggregateRoot.LastModifiedDate = persister.Get<DateTime>(@event.State, ColumnNames.LastModifiedDate);

                        // Set a date context that will cause all transient entities to report the assigned date without affecting the entity itself
                        CallContext.SetData("TransientSerializableCreateDateTime", currentDateTime);

                        try
                        {
                            // Produce the serialized data
                            var resourceData = MessagePackHelper.SerializeAndCompressAggregateData(aggregateRoot);
                            aggregateRoot.AggregateData = resourceData;

                            // Update the state with serialized aggregate data
                            persister.Set(@event.State, ColumnNames.AggregateData, aggregateRoot.AggregateData);

                            if (_logger.IsDebugEnabled)
                            {
                                _logger.Debug($"MessagePack bytes for updated entity: {resourceData.Length:N0}");
                            }
                        }
                        finally
                        {
                            // Stop defaulting the reported CreateDate for transient entities
                            CallContext.SetData("TransientSerializableCreateDateTime", null);

                            // Reset CreateDate property to default value so that entity appears transient (until PostInsertListener event)
                            aggregateRoot.CreateDate = default;

                            // Restore LastModifiedDate on the entity
                            aggregateRoot.LastModifiedDate = originalLastModifiedDate;
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
}
