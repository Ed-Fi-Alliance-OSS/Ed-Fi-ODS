// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class AssemblyDataProvider : IAssemblyDataProvider
    {
        private const string AssemblyMetadataSearchString = "assemblyMetadata.json";
        private const string ExtensionsSearchString = "EdFi.Ods.Extensions.*.csproj";
        private const string ProfilesSearchString = "EdFi.Ods.Profiles.*.csproj";

        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));
        private readonly ICodeRepositoryProvider _codeRepositoryProvider;
        private readonly IDomainModelDefinitionsProviderProvider _domainModelDefinitionsProviderProvider;
        private readonly IDictionary<string, IDomainModelDefinitionsProvider> _domainModelsDefinitionsProvidersByProjectName;
        private readonly IJsonFileProvider _jsonFileProvider;
        private readonly IIncludePluginsProvider _includePluginsProvider;
        private readonly IExtensionLocationPluginsProvider _extensionLocationPluginsProviderProvider;

        public AssemblyDataProvider(
            ICodeRepositoryProvider codeRepositoryProvider,
            IJsonFileProvider jsonFileProvider,
            IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider,
            IIncludePluginsProvider includePluginsProvider,
            IExtensionLocationPluginsProvider extensionLocationPluginsProviderProvider)
        {
            _codeRepositoryProvider = Preconditions.ThrowIfNull(codeRepositoryProvider, nameof(codeRepositoryProvider));
            _jsonFileProvider = Preconditions.ThrowIfNull(jsonFileProvider, nameof(jsonFileProvider));

            _domainModelDefinitionsProviderProvider =
                Preconditions.ThrowIfNull(domainModelDefinitionsProviderProvider, nameof(domainModelDefinitionsProviderProvider));

            _domainModelsDefinitionsProvidersByProjectName =
                domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName();

            _includePluginsProvider = includePluginsProvider;

            _extensionLocationPluginsProviderProvider = extensionLocationPluginsProviderProvider;
        }

        public IEnumerable<AssemblyData> GetAll()
        {
            var assemblyData = new List<AssemblyData>();

            assemblyData.AddRange(GetKnownOdsRepositoryAssemblyData());
            assemblyData.AddRange(GetKnownImplementationAssemblyData());
            assemblyData.AddRange(GetExtensionPluginAssemblyData());
            assemblyData.AddRange(GetIncludedPluginAssemblyData());
            assemblyData.AddRange(GetDatabaseSpecificAssemblyData());

            // Convention based location for backwards compatibility
            assemblyData.AddRange(GetLegacyProfileAssemblyData());
            assemblyData.AddRange(GetLegacyExtensionAssemblyData());

            return assemblyData;
        }

        // last element is the assemblyName.
        private static string GetAssemblyName(string assemblyMetadataPath)
            => Path.GetDirectoryName(assemblyMetadataPath)
                ?.Split(Path.DirectorySeparatorChar)
                .LastOrDefault();

        private AssemblyData CreateAssemblyData(string assemblyMetadataPath)
        {
            var assemblyMetadata = _jsonFileProvider.Load<AssemblyMetadata>(assemblyMetadataPath);

            bool isExtension = assemblyMetadata.AssemblyModelType.EqualsIgnoreCase(TemplateSetConventions.Extension);

            string assemblyName = GetAssemblyName(assemblyMetadataPath);

            var schemaName = isExtension
                ? _domainModelsDefinitionsProvidersByProjectName[assemblyName]
                    .GetDomainModelDefinitions()
                    .SchemaDefinition.LogicalName
                : EdFiConventions.ProperCaseName;

            var assemblyData = new AssemblyData
            {
                AssemblyName = assemblyName,
                Path = Path.GetDirectoryName(assemblyMetadataPath),
                TemplateSet = assemblyMetadata.AssemblyModelType,
                IsProfile = assemblyMetadata.AssemblyModelType.EqualsIgnoreCase(TemplateSetConventions.Profile),
                SchemaName = schemaName,
                IsExtension = isExtension
            };

            return assemblyData;
        }

        public IEnumerable<AssemblyData> GetKnownOdsRepositoryAssemblyData()
        {
            _logger.Debug(
                $"Getting known assemblies from the '{CodeRepositoryConventions.EdFiOdsFolderName}' repository with the assemblyMetaData.json file");

            var odsPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Ods,
                CodeRepositoryConventions.Application);

            var odsAssemblyData = Directory.GetFiles(
                odsPath,
                AssemblyMetadataSearchString,
                SearchOption.AllDirectories);

            return odsAssemblyData.Select(CreateAssemblyData);
        }

        public IEnumerable<AssemblyData> GetKnownImplementationAssemblyData()
        {
            _logger.Debug(
                $"Getting known assemblies from the '{CodeRepositoryConventions.EdFiOdsImplementationFolderName}' repository with the assemblyMetaData.json file");

            var implementationPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Implementation,
                CodeRepositoryConventions.Application);

            var implementationAssemblyData = Directory.GetFiles(
                implementationPath,
                AssemblyMetadataSearchString,
                SearchOption.AllDirectories);

            return implementationAssemblyData.Select(CreateAssemblyData);
        }

        public IEnumerable<AssemblyData> GetExtensionPluginAssemblyData()
        {
            var extensionPaths = _extensionLocationPluginsProviderProvider
                .GetExtensionLocationPlugins();

            var extensionAssemblyData =
                extensionPaths
                    .Where(Directory.Exists)
                    .SelectMany(
                        extensionPath => Directory.GetFiles(
                            extensionPath,
                            AssemblyMetadataSearchString,
                            SearchOption.AllDirectories));

            return extensionAssemblyData.Select(CreateAssemblyData);
        }

        public IEnumerable<AssemblyData> GetIncludedPluginAssemblyData()
        {
            if (!_includePluginsProvider.IncludePlugins())
                return new List<AssemblyData>();

            var extensionsPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.ExtensionsRepositoryName,
                CodeRepositoryConventions.Extensions);

            var extensionAssemblyData = Directory.GetFiles(
                extensionsPath,
                AssemblyMetadataSearchString,
                SearchOption.AllDirectories);

            return extensionAssemblyData.Select(CreateAssemblyData);
        }

        public IEnumerable<AssemblyData> GetDatabaseSpecificAssemblyData()
        {
            // Add database specific code generation... this is a code smell but is a convention. Sql generation should be done in metaed.
            var databaseAssemblyData = new AssemblyData
            {
                AssemblyName = "ODS Database Specific",
                Path = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.Ods,
                    CodeRepositoryConventions.Database),
                TemplateSet = TemplateSetConventions.Database,
                IsProfile = false,
                IsExtension = false,
                SchemaName = EdFiConventions.PhysicalSchemaName
            };

            return new List<AssemblyData> {databaseAssemblyData};
        }

        public IEnumerable<AssemblyData> GetLegacyProfileAssemblyData()
        {
            // Convention based location of profiles (backwards compatibility)
            _logger.Debug($"Getting any profile assemblies from the implementation folder");

            var legacyProfilePath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Implementation,
                CodeRepositoryConventions.Application);

            var legacyProfileAssemblyData = Directory.GetFiles(
                    legacyProfilePath,
                    ProfilesSearchString,
                    SearchOption.AllDirectories)
                .Select(
                    x =>
                    {
                        string assemblyName = GetAssemblyName(x);

                        _logger.Debug($"Adding legacy assembly '{assemblyName}' for processing.");

                        return new AssemblyData
                        {
                            Path = Path.GetDirectoryName(x),
                            TemplateSet = TemplateSetConventions.Profile,
                            AssemblyName = assemblyName,
                            IsProfile = true,
                            IsExtension = false,
                            SchemaName = EdFiConventions.PhysicalSchemaName
                        };
                    });

            return legacyProfileAssemblyData;
        }

        public IEnumerable<AssemblyData> GetLegacyExtensionAssemblyData()
        {
            // Convention based location of extensions (backwards compatibility)
            _logger.Debug($"Getting any extension assemblies from the implementation folder");

            var legacyExtensionPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Implementation,
                CodeRepositoryConventions.Application);

            var legacyExtensionAssemblyData = Directory.GetFiles(
                    legacyExtensionPath,
                    ExtensionsSearchString,
                    SearchOption.AllDirectories)
                .Select(
                    x =>
                    {
                        string assemblyName = GetAssemblyName(x);

                        _logger.Debug($"Adding legacy assembly '{assemblyName}' for processing.");

                        string schemaName = _domainModelsDefinitionsProvidersByProjectName[assemblyName]
                            .GetDomainModelDefinitions()
                            .SchemaDefinition
                            .LogicalName;

                        return new AssemblyData
                        {
                            Path = Path.GetDirectoryName(x),
                            TemplateSet = TemplateSetConventions.Extension,
                            AssemblyName = assemblyName,
                            IsExtension = true,
                            IsProfile = false,
                            SchemaName = schemaName
                        };
                    });

            return legacyExtensionAssemblyData;
        }
    }
}
