// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;

namespace EdFi.Ods.Common.Descriptors;

public class DescriptorMaps
{
    public DescriptorMaps(
        ConcurrentDictionary<string, int> descriptorIdByUri,
        ConcurrentDictionary<int, string> uriByDescriptorId)
    {
        DescriptorIdByUri = descriptorIdByUri;
        UriByDescriptorId = uriByDescriptorId;
    }

    public ConcurrentDictionary<string, int> DescriptorIdByUri { get; }

    public ConcurrentDictionary<int, string> UriByDescriptorId { get; }
}
