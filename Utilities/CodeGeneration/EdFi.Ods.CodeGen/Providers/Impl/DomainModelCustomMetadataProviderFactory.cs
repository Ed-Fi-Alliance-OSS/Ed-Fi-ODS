// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using EdFi.Ods.Common.Metadata.Custom;

namespace EdFi.Ods.CodeGen.Providers.Impl;

/// <summary>
/// Implements <see cref="IDomainModelCustomMetadataProviderFactory"/> that loads custom metadata from files discovered in the solution
/// folder structure and any extension paths.
/// </summary>
public class DomainModelCustomMetadataProviderFactory
    : MetadataProvidersFactoryBase<IDomainModelCustomMetadataProvider>, IDomainModelCustomMetadataProviderFactory
{
    private readonly Lazy<Dictionary<string, IDomainModelCustomMetadataProvider>> _domainModelCustomMetadataProviderByProjectName;
        
    public DomainModelCustomMetadataProviderFactory(
        ICodeRepositoryProvider codeRepositoryProvider,
        IExtensionPluginsProvider extensionPluginsProviderProvider,
        IExtensionVersionsPathProvider extensionVersionsPathProvider,
        IStandardVersionPathProvider standardVersionPathProvider)
        : base(
            codeRepositoryProvider,
            extensionPluginsProviderProvider,
            extensionVersionsPathProvider,
            standardVersionPathProvider)
    {
        _domainModelCustomMetadataProviderByProjectName =
            new Lazy<Dictionary<string, IDomainModelCustomMetadataProvider>>(CreateMetadataProviderByProjectName);
    }

    protected override string StandardMetadataFileRelativePath
    {
        get => Path.Combine("Artifacts", "Metadata", "ApiModel-CustomMetadata.json");
    }

    protected override string ExtensionMetadataFileRelativePath
    {
        get => Path.Combine("Artifacts", "Metadata", "ApiModel-EXTENSION-CustomMetadata.json");
    }

    protected override bool MetadataIsRequired
    {
        get => false;
    }

    protected override IDomainModelCustomMetadataProvider CreateProviderForMetadataFile(string metadataFilePath)
    {
        return new FileBasedDomainModelCustomMetadataProvider(metadataFilePath);
    }

    public IEnumerable<IDomainModelCustomMetadataProvider> CreateProviders()
    {
        return _domainModelCustomMetadataProviderByProjectName.Value.Values;
    }
}
