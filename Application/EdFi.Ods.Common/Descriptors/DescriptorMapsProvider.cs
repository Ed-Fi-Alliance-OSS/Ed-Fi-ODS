// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Builds the <see cref="DescriptorMaps" /> from the collection of <see cref="DescriptorDetails" /> instances obtained from the ODS.
/// </summary>
public class DescriptorMapsProvider : IDescriptorMapsProvider
{
    private readonly IDescriptorDetailsProvider _descriptorDetailsProvider;
    private readonly IContextProvider<OdsInstanceConfiguration> _contextProvider;

    // Cache stampede protection keyed by OdsInstance. The Interceptor still provides the
    // long-lived caching; this dictionary holds the Lazy only for the duration of a single
    // in-flight load.
    private readonly ConcurrentDictionary<ulong, Lazy<DescriptorMaps>> _flights = new();

    public DescriptorMapsProvider(
        IDescriptorDetailsProvider descriptorDetailsProvider,
        IContextProvider<OdsInstanceConfiguration> contextProvider)
    {
        _descriptorDetailsProvider = descriptorDetailsProvider;
        _contextProvider = contextProvider;
    }

    /// <inheritdoc cref="IDescriptorMapsProvider.GetMaps" />
    public DescriptorMaps GetMaps()
    {
        ulong key = ComputeFlightKey();

        var flight = _flights.GetOrAdd(
            key,
            _ => new Lazy<DescriptorMaps>(LoadMaps, LazyThreadSafetyMode.ExecutionAndPublication));

        try
        {
            return flight.Value;
        }
        finally
        {
            _flights.TryRemove(new KeyValuePair<ulong, Lazy<DescriptorMaps>>(key, flight));
        }
    }

    private ulong ComputeFlightKey()
    {
        var context = _contextProvider.Get();

        // Without context, we cannot generate a key
        if (context == null)
        {
            throw new InvalidOperationException(
                $"No context has been set for value of type '{nameof(OdsInstanceConfiguration)}'.");
        }

        return context.OdsInstanceHashId;
    }

    private DescriptorMaps LoadMaps()
    {
        var allDescriptors = _descriptorDetailsProvider.GetAllDescriptorDetails();

        // Create dictionary, allowing for 10% growth of known entries before resizing
        var descriptorIdByUri = new ConcurrentDictionary<string, (string descriptorName, int descriptorId)>(
            Environment.ProcessorCount,
            (int)(allDescriptors.Count * 1.1),
            StringComparer.OrdinalIgnoreCase);

        // Create dictionary, allowing for 10% growth of known entries before resizing
        var uriByDescriptorId = new ConcurrentDictionary<int, (string descriptorName, string uri)>(
            Environment.ProcessorCount,
            (int)(allDescriptors.Count * 1.1));

        foreach (var descriptorDetails in allDescriptors)
        {
            descriptorIdByUri.TryAdd(descriptorDetails.Uri, (descriptorDetails.DescriptorName, descriptorDetails.DescriptorId));
            uriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, (descriptorDetails.DescriptorName, descriptorDetails.Uri));
        }

        return new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
    }
}
