// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
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

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public class EdFiOdsPreUpdateListener : IPreUpdateEventListener
{
    private readonly JsonSerializerSettings _jsonSerializerSettings;
    private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiOdsPreUpdateListener));
    private readonly bool _serializationEnabled;

    public EdFiOdsPreUpdateListener(IOptions<MvcNewtonsoftJsonOptions> jsonOptions, ApiSettings apiSettings)
    {
        _serializationEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ResourceSerialization.GetConfigKeyName());

        if (_serializationEnabled)
        {
            _jsonSerializerSettings = new JsonSerializerSettings(jsonOptions.Value.SerializerSettings);
            _jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
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
                var lastModifiedDate = persister.Get<DateTime>(@event.State, "LastModifiedDate");
                aggregateRoot.LastModifiedDate = lastModifiedDate;

                // Produce the JSON
                var resourceData = JsonHelper.SerializeAndCompressResourceData(aggregateRoot, _jsonSerializerSettings);
                aggregateRoot.Json = resourceData;

                // Update the state
                persister.Set(@event.State, "Json", aggregateRoot.Json);

                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"JSON for updated entity: {CompressionHelper.DecompressStream(new MemoryStream(resourceData, 8, resourceData.Length - 8))}");
                }
            }
        }

        return false;
    }
}
