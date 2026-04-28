// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using log4net;

namespace EdFi.Ods.Common.Descriptors;

public class DescriptorResolver : IDescriptorResolver
{
    private readonly IDescriptorDetailsProvider _descriptorDetailsProvider;
    private readonly IDescriptorMapsProvider _descriptorMapsProvider;

    private readonly ILog _logger = LogManager.GetLogger(typeof(DescriptorResolver));

    public DescriptorResolver(
        IDescriptorMapsProvider descriptorMapsProvider,
        IDescriptorDetailsProvider descriptorDetailsProvider)
    {
        _descriptorMapsProvider = descriptorMapsProvider;
        _descriptorDetailsProvider = descriptorDetailsProvider;
    }

    public int GetDescriptorId(string descriptorName, string uri)
    {
        if (uri == null)
        {
            _logger.Warn($"GetDescriptorId returning default for descriptor '{descriptorName}': supplied uri is null.");
            return default;
        }
        
        var descriptorMaps = _descriptorMapsProvider.GetMaps();

        if (!descriptorMaps.DescriptorIdByUri.TryGetValue(uri, out var descriptorBrief))
        {
            var descriptorDetails = _descriptorDetailsProvider.GetDescriptorDetails(descriptorName, uri);

            if (descriptorDetails != null)
            {
                // Add the details to the existing descriptor maps
                descriptorMaps.DescriptorIdByUri.TryAdd(descriptorDetails.Uri, (descriptorName, descriptorDetails.DescriptorId));
                descriptorMaps.UriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, (descriptorName, descriptorDetails.Uri));

                if (descriptorDetails.DescriptorId == default)
                {
                    _logger.Warn($"GetDescriptorId resolved descriptor '{descriptorName}' uri '{uri}' to a default DescriptorId (0) via database lookup. DescriptorMaps count: {descriptorMaps.DescriptorIdByUri.Count}.");
                }

                return descriptorDetails.DescriptorId;
            }

            _logger.Warn($"GetDescriptorId returning default for descriptor '{descriptorName}': uri '{uri}' was not found in the DescriptorMaps or the database. DescriptorMaps count: {descriptorMaps.DescriptorIdByUri.Count}.");
            return default;
        }

        if (descriptorBrief.descriptorName != descriptorName)
        {
            // This is a descriptor uri for a different descriptor type
            _logger.Warn($"GetDescriptorId returning default for descriptor '{descriptorName}': uri '{uri}' is registered for a different descriptor type ('{descriptorBrief.descriptorName}'). DescriptorMaps count: {descriptorMaps.DescriptorIdByUri.Count}.");
            return default;
        }

        if (descriptorBrief.descriptorId == default)
        {
            _logger.Warn($"GetDescriptorId resolved descriptor '{descriptorName}' uri '{uri}' to a default DescriptorId (0) from the DescriptorMaps. DescriptorMaps count: {descriptorMaps.DescriptorIdByUri.Count}.");
        }

        return descriptorBrief.descriptorId;
    }

    public string GetUri(string descriptorName, int descriptorId)
    {
        if (descriptorId == default)
        {
            return default;
        }
        
        var descriptorMaps = _descriptorMapsProvider.GetMaps();

        if (!descriptorMaps.UriByDescriptorId.TryGetValue(descriptorId, out var descriptorBrief))
        {
            var descriptorDetails = _descriptorDetailsProvider.GetDescriptorDetails(descriptorName, descriptorId);

            if (descriptorDetails != null)
            {
                // Add the details to the existing descriptor maps
                descriptorMaps.DescriptorIdByUri.TryAdd(descriptorDetails.Uri, (descriptorName, descriptorDetails.DescriptorId));
                descriptorMaps.UriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, (descriptorName, descriptorDetails.Uri));

                return descriptorDetails.Uri;
            }

            return default;
        }

        if (descriptorBrief.descriptorName != descriptorName)
        {
            // This is a descriptor id for a different descriptor type
            return default;
        }

        return descriptorBrief.uri;
    }
}
