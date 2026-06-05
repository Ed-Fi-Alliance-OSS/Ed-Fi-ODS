// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Metadata.Custom;

/// <summary>
/// Implements <see cref="IDomainModelCustomMetadataProvider"/> that loads the custom metadata from an embedded resource
/// matching one of the expected names used (by convention) for the metadata (either "ApiModel-CustomMetadata.json"
/// for the Ed-Fi Standard or "ApiModel-EXTENSION-CustomMetadata.json" for an extension).
/// </summary>
public class EmbeddedResourceDomainModelCustomMetadataProvider : IDomainModelCustomMetadataProvider
{
    private readonly Assembly _sourceAssembly;
    
    public EmbeddedResourceDomainModelCustomMetadataProvider(Assembly sourceAssembly)
    {
        _sourceAssembly = sourceAssembly;
    }
    
    public bool TryLoadCustomMetadata(out DomainModelCustomMetadata domainModelCustomMetadata)
    {
        var resourceName = _sourceAssembly.GetManifestResourceNames()
            .SingleOrDefault(rn => rn.EndsWith("ApiModel-CustomMetadata.json")
                || rn.EndsWith("ApiModel-EXTENSION-CustomMetadata.json"));

        if (string.IsNullOrWhiteSpace(resourceName))
        {
            domainModelCustomMetadata = null;

            return false;
        }

        string json;

        using (var stream = _sourceAssembly.GetManifestResourceStream(resourceName))
        {
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
        }

        domainModelCustomMetadata = JsonConvert.DeserializeObject<DomainModelCustomMetadata>(
            json,
            new JsonSerializerSettings
            {
                Error = (sender, args) => throw new Exception(
                    "Unable to deserialize Custom Metadata from embedded resource.")
            });

        return true;
    }
}
