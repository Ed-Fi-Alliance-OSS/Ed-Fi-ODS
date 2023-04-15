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
        var descriptorMaps = _descriptorMapsProvider.GetMaps();

        if (!descriptorMaps.DescriptorIdByUri.TryGetValue(uri, out int descriptorId))
        {
            var descriptorDetails = _descriptorDetailsProvider.GetDescriptorDetails(descriptorName, uri);

            if (descriptorDetails != null)
            {
                // Add the details to the existing descriptor maps
                descriptorMaps.DescriptorIdByUri.TryAdd(descriptorDetails.Uri, descriptorDetails.DescriptorId);
                descriptorMaps.UriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, descriptorDetails.Uri);

                return descriptorDetails.DescriptorId;
            }

            return default;
        }

        return descriptorId;
    }

    public string GetUri(string descriptorName, int descriptorId)
    {
        var descriptorMaps = _descriptorMapsProvider.GetMaps();

        if (!descriptorMaps.UriByDescriptorId.TryGetValue(descriptorId, out string uri))
        {
            var descriptorDetails = _descriptorDetailsProvider.GetDescriptorDetails(descriptorName, descriptorId);

            if (descriptorDetails != null)
            {
                // Add the details to the existing descriptor maps
                descriptorMaps.DescriptorIdByUri.TryAdd(descriptorDetails.Uri, descriptorDetails.DescriptorId);
                descriptorMaps.UriByDescriptorId.TryAdd(descriptorDetails.DescriptorId, descriptorDetails.Uri);

                return descriptorDetails.Uri;
            }

            return default;
        }

        return uri;
    }
}
