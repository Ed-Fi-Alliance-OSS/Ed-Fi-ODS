// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Database;

namespace EdFi.Ods.Common.Descriptors;

/// <summary>
/// Builds the <see cref="DescriptorMaps" /> from the collection of <see cref="DescriptorDetails" /> instances obtained from the ODS.
/// </summary>
public class DescriptorMapsProvider : IDescriptorMapsProvider
{
    private readonly IDescriptorDetailsProvider _descriptorDetailsProvider;
    private readonly IDatabaseEngineSpecificEqualityComparerProvider<string> _equalityComparerProvider;

    public DescriptorMapsProvider(
        IDescriptorDetailsProvider descriptorDetailsProvider,
        IDatabaseEngineSpecificEqualityComparerProvider<string> equalityComparerProvider)
    {
        _descriptorDetailsProvider = descriptorDetailsProvider;
        _equalityComparerProvider = equalityComparerProvider;
    }

    /// <inheritdoc cref="IDescriptorMapsProvider.GetMaps" />
    public DescriptorMaps GetMaps()
    {
        var allDescriptors = _descriptorDetailsProvider.GetAllDescriptorDetails();

        var descriptorIdByUri = new ConcurrentDictionary<string, int>(
            Environment.ProcessorCount,
            // Allow for 10% growth of known entries before resizing
            (int)(allDescriptors.Count * 1.1),
            // Use same collation as the database engine
            _equalityComparerProvider.GetEqualityComparer()); 

        var uriByDescriptorId = new ConcurrentDictionary<int, string>(
            Environment.ProcessorCount,
            // Allow for 10% growth of known entries before resizing
            (int)(allDescriptors.Count * 1.1));

        foreach (var descriptorDetails in allDescriptors)
        {
            descriptorIdByUri.TryAdd(descriptorDetails.Uri, descriptorDetails.DescriptorId);
            uriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, descriptorDetails.Uri);
        }

        return new DescriptorMaps(descriptorIdByUri, uriByDescriptorId);
    }
}
