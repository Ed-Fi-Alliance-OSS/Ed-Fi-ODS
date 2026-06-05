// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.Common.Conventions;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl;

/// <summary>
/// Provides a base class for creating a collection of metadata providers based on the solution folder structure and
/// projects using conventions in use by the Ed-Fi ODS API solution.
/// </summary>
/// <typeparam name="TMetadataProvider">The Type of the metadata providers to be created.</typeparam>
public abstract class MetadataProvidersFactoryBase<TMetadataProvider>
{
    private readonly IExtensionVersionsPathProvider _extensionVersionsPathProvider;
    private readonly IStandardVersionPathProvider _standardVersionPathProvider;
    private readonly IExtensionPluginsProvider _extensionPluginsProviderProvider;
        
    private readonly string _solutionPath;
    private readonly ILog Logger = LogManager.GetLogger(typeof(DomainModelDefinitionProvidersProvider));

    protected MetadataProvidersFactoryBase(
        ICodeRepositoryProvider codeRepositoryProvider,
        IExtensionPluginsProvider extensionPluginsProviderProvider,
        IExtensionVersionsPathProvider extensionVersionsPathProvider, 
        IStandardVersionPathProvider standardVersionPathProvider)
    {
        _solutionPath = Path.Combine(
            codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Implementation),
            "Application");

        _extensionPluginsProviderProvider = extensionPluginsProviderProvider;
        _extensionVersionsPathProvider = extensionVersionsPathProvider;
        _standardVersionPathProvider = standardVersionPathProvider;
    }

    protected abstract string StandardMetadataFileRelativePath { get; } 
    protected abstract string ExtensionMetadataFileRelativePath { get; } 
    protected abstract bool MetadataIsRequired { get; }
    
    protected abstract TMetadataProvider CreateProviderForMetadataFile(string metadataFilePath);

    protected Dictionary<string, TMetadataProvider> CreateMetadataProviderByProjectName()
    {
        string edFiOdsImplementationApplicationPath = _solutionPath;

        int index = _solutionPath.LastIndexOf(CodeRepositoryConventions.EdFiOdsImplementationFolderName);

        string edFiOdsApplicationPath = _solutionPath
            .Remove(index, CodeRepositoryConventions.EdFiOdsImplementationFolderName.Length)
            .Insert(index, CodeRepositoryConventions.EdFiOdsFolderName);

        DirectoryInfo[] directoriesToEvaluate = GetProjectDirectoriesToEvaluate(edFiOdsImplementationApplicationPath)
            .Concat(GetProjectDirectoriesToEvaluate(edFiOdsApplicationPath))
            .ToArray();

        var extensionPaths = _extensionPluginsProviderProvider.GetExtensionLocationPlugins();

        extensionPaths.ToList()
            .ForEach(
                x =>
                {
                    if (!Directory.Exists(x))
                    {
                        throw new Exception($"Unable to find extension Location project path  at location {x}.");
                    }

                    directoriesToEvaluate = directoriesToEvaluate.Concat(GetProjectDirectoriesToEvaluate(x))
                        .Append(new DirectoryInfo(x))
                        .ToArray();
                });

        var modelProjects = directoriesToEvaluate.Where(p => p.Name.IsExtensionAssembly() || p.Name.IsStandardAssembly());

        var metadataProviderByProject = new Dictionary<string, TMetadataProvider>(StringComparer.OrdinalIgnoreCase);

        foreach (var modelProject in modelProjects)
        {
            var metadataFile = GetMetadataFileInfo(
                modelProject,
                _standardVersionPathProvider.StandardVersionPath(),
                () => _extensionVersionsPathProvider.ExtensionVersionsPath(modelProject.FullName));

            if (!metadataFile.Exists)
            {
                if (MetadataIsRequired)
                {
                    throw new Exception(
                        $"Unable to find model definitions file for extensions project {modelProject.Name} at location {metadataFile.FullName}.");
                }

                // Metadata is optional, and was not found.
                continue;
            }

            Logger.Debug($"Loading Metadata from '{metadataFile}'.");

            if (metadataProviderByProject.ContainsKey(modelProject.Name))
            {
                throw new Exception($"Cannot process duplicate extension projects for '{modelProject.Name}'.");
            }

            metadataProviderByProject.Add(
                modelProject.Name,
                CreateProviderForMetadataFile(metadataFile.FullName));
        }

        return metadataProviderByProject;

        DirectoryInfo[] GetProjectDirectoriesToEvaluate(string basePath)
        {
            var directory = new DirectoryInfo(basePath);

            if (directory.Exists)
            {
                return directory.GetDirectories("", SearchOption.AllDirectories);
            }

            return Array.Empty<DirectoryInfo>();
        }
    }

    private FileInfo GetMetadataFileInfo(DirectoryInfo modelProject, string standardVersionPath, Func<string> extensionsVersionPath)
    {
        if (modelProject.Name.IsStandardAssembly())
        {
            return new FileInfo(Path.Combine(modelProject.FullName, 
                standardVersionPath, 
                StandardMetadataFileRelativePath));
        }

        return new FileInfo(Path.Combine(extensionsVersionPath(),
            standardVersionPath, 
            ExtensionMetadataFileRelativePath));
    }
}
