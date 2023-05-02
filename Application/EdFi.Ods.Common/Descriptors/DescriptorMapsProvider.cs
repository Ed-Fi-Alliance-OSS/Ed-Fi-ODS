// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Builds the <see cref="DescriptorMaps" /> from the collection of <see cref="DescriptorDetails" /> instances obtained from the ODS.
/// </summary>
public class DescriptorMapsProvider : IDescriptorMapsProvider
{
    private readonly IDescriptorDetailsProvider _descriptorDetailsProvider;

    public DescriptorMapsProvider(IDescriptorDetailsProvider descriptorDetailsProvider)
    {
        _descriptorDetailsProvider = descriptorDetailsProvider;
    }

    /// <inheritdoc cref="IDescriptorMapsProvider.GetMaps" />
    public DescriptorMaps GetMaps()
    {
        var allDescriptors = _descriptorDetailsProvider.GetAllDescriptorDetails();

        // Create dictionary, allowing for 10% growth of known entries before resizing
        var descriptorIdByUri = new ConcurrentDictionary<string, int>(
            Environment.ProcessorCount,
            (int)(allDescriptors.Count * 1.1),
            StringComparer.OrdinalIgnoreCase);

        // Create dictionary, allowing for 10% growth of known entries before resizing
        var uriByDescriptorId = new ConcurrentDictionary<int, string>(
            Environment.ProcessorCount,
            (int)(allDescriptors.Count * 1.1));

        foreach (var descriptorDetails in allDescriptors)
        {
            descriptorIdByUri.TryAdd(descriptorDetails.Uri, descriptorDetails.DescriptorId);
            uriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, descriptorDetails.Uri);
        }

        return new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
    }
}
