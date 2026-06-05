// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using EdFi.Ods.Common.Metadata.Custom;
using Newtonsoft.Json;

namespace EdFi.Ods.CodeGen.Providers.Impl;

public class FileBasedDomainModelCustomMetadataProvider : IDomainModelCustomMetadataProvider
{
    private readonly string _metadataFilePath;

    public FileBasedDomainModelCustomMetadataProvider(string metadataFilePath)
    {
        _metadataFilePath = metadataFilePath;
    }

    public bool TryLoadCustomMetadata(out DomainModelCustomMetadata domainModelCustomMetadata)
    {
        if (!File.Exists(_metadataFilePath))
        {
            throw new FileNotFoundException($"Metadata file '{_metadataFilePath}' not found.");
        }

        var json = File.ReadAllText(_metadataFilePath);

        domainModelCustomMetadata = JsonConvert.DeserializeObject<DomainModelCustomMetadata>(
            json,
            new JsonSerializerSettings
            {
                Error = (sender, args) => throw new Exception(
                    $"Unable to deserialize custom metadata from '{_metadataFilePath}'.")
            });
            
        return true;
    }
}
