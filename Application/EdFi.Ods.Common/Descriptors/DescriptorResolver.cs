// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Descriptors;

public class DescriptorResolver : IDescriptorResolver
{
    private readonly IDescriptorDetailsProvider _descriptorDetailsProvider;
    private readonly IDescriptorMapsProvider _descriptorMapsProvider;

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

                return descriptorDetails.DescriptorId;
            }

            return default;
        }

        if (descriptorBrief.descriptorName != descriptorName)
        {
            // This is a descriptor uri for a different descriptor type
            return default;
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
