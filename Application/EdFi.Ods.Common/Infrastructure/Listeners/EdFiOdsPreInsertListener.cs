// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Compression;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Domain;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NHibernate.Event;

namespace EdFi.Ods.Common.Infrastructure.Listeners
{
    public class EdFiOdsPreInsertListener : IPreInsertEventListener
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPreInsertListener));
        private readonly bool _serializationEnabled;

        public EdFiOdsPreInsertListener(IOptions<MvcNewtonsoftJsonOptions> jsonOptions, ApiSettings apiSettings)
        {
            _serializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ResourceSerialization.GetConfigKeyName());

            if (_serializationEnabled)
            {
                _jsonSerializerSettings = new JsonSerializerSettings(jsonOptions.Value.SerializerSettings);
                _jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
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
                    var lastModifiedDate = persister.Get<DateTime>(@event.State, "LastModifiedDate");
                    aggregateRoot.LastModifiedDate = lastModifiedDate;

                    // Produce the JSON
                    var resourceData = MessagePackHelper.SerializeAndCompressResourceData(aggregateRoot);
                    // var resourceData = JsonHelper.SerializeAndCompressResourceData(aggregateRoot, _jsonSerializerSettings);
                    aggregateRoot.Json = resourceData;

                    // Update the state
                    persister.Set(@event.State, "Json", aggregateRoot.Json);

                    if (_logger.IsDebugEnabled)
                    {
                        _logger.Debug($"MessagePack bytes for updated entity: {resourceData.Length:N0}");
                        // _logger.Debug($"JSON for updated entity: {CompressionHelper.DecompressByteArray(resourceData)}");
                    }
                }
            }

            return false;
        }
    }
}
