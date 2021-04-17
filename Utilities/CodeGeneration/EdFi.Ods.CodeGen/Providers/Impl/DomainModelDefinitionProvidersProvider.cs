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
using EdFi.Ods.Common.Models;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class DomainModelDefinitionProvidersProvider : IDomainModelDefinitionsProviderProvider
    {
        private const string StandardModelsPath = @"Artifacts/Metadata/ApiModel.json";
        private const string ExtensionModelsPath = @"Artifacts/Metadata/ApiModel-EXTENSION.json";
        private readonly Lazy<Dictionary<string, IDomainModelDefinitionsProvider>> _domainModelDefinitionProvidersByProjectName;

        private readonly string _solutionPath;
        private readonly ILog Logger = LogManager.GetLogger(typeof(DomainModelDefinitionProvidersProvider));
        private readonly IExtensionPluginsProvider _extensionPluginsProviderProvider;
        private readonly IIncludePluginsProvider _includePluginsProvider;
        private readonly string _extensionsPath;

        public DomainModelDefinitionProvidersProvider(
            ICodeRepositoryProvider codeRepositoryProvider,
            IExtensionPluginsProvider extensionPluginsProviderProvider,
            IIncludePluginsProvider includePluginsProvider)
        {
            _solutionPath = codeRepositoryProvider.GetCodeRepositoryByName(CodeRepositoryConventions.Implementation)
                            + "\\Application";

            _extensionsPath = codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.ExtensionsRepositoryName,
                "Extensions");

            _domainModelDefinitionProvidersByProjectName =
                new Lazy<Dictionary<string, IDomainModelDefinitionsProvider>>(CreateDomainModelDefinitionsByPath);

            _extensionPluginsProviderProvider = extensionPluginsProviderProvider;

            _includePluginsProvider = includePluginsProvider;
        }

        /// <summary>
        /// Discover and instantiate all IDomainModelDefinitionsProviders in the solution
        /// Associate each provider with corresponding project type.
        /// </summary>
        /// <returns>An enumerable of IDomainModelDefinitionsProvider</returns>
        public IEnumerable<IDomainModelDefinitionsProvider> DomainModelDefinitionProviders()
        {
            return _domainModelDefinitionProvidersByProjectName.Value.Values;
        }

        public IDictionary<string, IDomainModelDefinitionsProvider> DomainModelDefinitionsProvidersByProjectName()
        {
            return _domainModelDefinitionProvidersByProjectName.Value;
        }

        private Dictionary<string, IDomainModelDefinitionsProvider> CreateDomainModelDefinitionsByPath()
        {
            DirectoryInfo[] directoriesToEvaluate;

            var domainModelDefinitionsByPath =
                new Dictionary<string, IDomainModelDefinitionsProvider>(StringComparer.InvariantCultureIgnoreCase);

            string edFiOdsImplementationApplicationPath = _solutionPath;

            string edFiOdsApplicationPath = _solutionPath.Replace(
                CodeRepositoryConventions.EdFiOdsImplementationFolderName,
                CodeRepositoryConventions.EdFiOdsFolderName);

            directoriesToEvaluate = GetProjectDirectoriesToEvaluate(edFiOdsImplementationApplicationPath)
                .Concat(GetProjectDirectoriesToEvaluate(edFiOdsApplicationPath))
                .ToArray();

            var extensionPaths = _extensionPluginsProviderProvider.GetExtensionLocationPlugins();

            extensionPaths.ToList().ForEach(
                x =>
                {
                    if (!Directory.Exists(x))
                    {
                        throw new Exception(
                            $"Unable to find extension Location project path  at location {x}.");
                    }

                    directoriesToEvaluate = directoriesToEvaluate
                        .Concat(GetProjectDirectoriesToEvaluate(x))
                        .Append(new DirectoryInfo(x)).ToArray();

                });

            if (_includePluginsProvider.IncludePlugins() && Directory.Exists(_extensionsPath))
            {
                directoriesToEvaluate = directoriesToEvaluate
                        .Concat(GetProjectDirectoriesToEvaluate(_extensionsPath))
                        .ToArray();
            }


            var modelProjects = directoriesToEvaluate
                .Where(p => p.Name.IsExtensionAssembly() || p.Name.IsStandardAssembly());

            foreach (var modelProject in modelProjects)
            {
                var modelsPath = modelProject.Name.IsStandardAssembly()
                    ? StandardModelsPath
                    : ExtensionModelsPath;

                var metadataFile = new FileInfo(Path.Combine(modelProject.FullName, modelsPath));

                Logger.Debug($"Loading ApiModels for {metadataFile}.");

                if (!metadataFile.Exists)
                {
                    throw new Exception(
                        $"Unable to find model definitions file for extensions project {modelProject.Name} at location {metadataFile.FullName}.");
                }

                if (domainModelDefinitionsByPath.ContainsKey(modelProject.Name))
                {
                    throw new Exception($"Cannot process duplicate extension projects for '{modelProject.Name}'.");
                }

                domainModelDefinitionsByPath.Add(
                        modelProject.Name,
                        new DomainModelDefinitionsJsonFileSystemProvider(metadataFile.FullName));
            }

            return domainModelDefinitionsByPath;

            DirectoryInfo[] GetProjectDirectoriesToEvaluate(string basePath)
            {
                var directory = new DirectoryInfo(basePath);

                if (directory.Exists)
                {
                    return directory.GetDirectories("", SearchOption.AllDirectories);
                }

                return new DirectoryInfo[0];
            }
        }
    }
}
