// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IEnumerable<AssemblyData> GetAll()
        {
            return GetKnownAssemblyData()

                // Convention based location for backwards compatibility
                .Concat(GetDatabaseSpecificAssemblyData())
                .Concat(GetLegacyProfileAssemblyData())
                .Concat(GetLegacyExtensionAssemblyData());
        }

        public IEnumerable<AssemblyData> GetKnownAssemblyData()
        {
            var searchPaths = new List<string>
            {
                _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.Ods,
                    CodeRepositoryConventions.Application),
                _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.Implementation,
                    CodeRepositoryConventions.Application)
            };

            searchPaths.AddRange(_extensionLocationPluginsProviderProvider.GetExtensionLocationPlugins().Where(Directory.Exists));

            if (_includePluginsProvider.IncludePlugins())
            {
                searchPaths.Add(
                    _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                        CodeRepositoryConventions.ExtensionsRepositoryName,
                        CodeRepositoryConventions.Extensions));
            }

            var assemblyData = searchPaths.SelectMany(
                    x =>
                    Directory.GetFiles(
                        x,
                        AssemblyMetadataSearchString,
                        SearchOption.AllDirectories))
                .Select(CreateAssemblyData)
                .ToList();

            assemblyData.ForEach(x => _logger.Debug($"Found file matching '{AssemblyMetadataSearchString}' at '{x.Path}'"));

            return assemblyData;
        }

        public IEnumerable<AssemblyData> GetDatabaseSpecificAssemblyData()
        {
            // Add database specific code generation... this is a code smell but is a convention. Sql generation should be done in metaed.
            var assemblyData = new AssemblyData
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

            _logger.Debug($"Created '{assemblyData.AssemblyName}' assembly data for '{assemblyData.Path}'");

            return new List<AssemblyData> { assemblyData };
        }

        public IEnumerable<AssemblyData> GetLegacyProfileAssemblyData()
        {
            // Convention based location of profiles (backwards compatibility)
            var legacyProfilePath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Implementation,
                CodeRepositoryConventions.Application);

            var assemblyData = Directory.GetFiles(
                    legacyProfilePath,
                    ProfilesSearchString,
                    SearchOption.AllDirectories)
                .Select(
                    x => new AssemblyData
                    {
                        Path = Path.GetDirectoryName(x),
                        TemplateSet = TemplateSetConventions.Profile,
                        AssemblyName = GetAssemblyName(x),
                        IsProfile = true,
                        IsExtension = false,
                        SchemaName = EdFiConventions.PhysicalSchemaName
                    }).ToList();

            assemblyData.ForEach(x => _logger.Debug($"Found file matching '{ProfilesSearchString}' at '{x.Path}'"));

            return assemblyData;
        }

        public IEnumerable<AssemblyData> GetLegacyExtensionAssemblyData()
        {
            // Convention based location of extensions (backwards compatibility)
            var legacyExtensionPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                CodeRepositoryConventions.Implementation,
                CodeRepositoryConventions.Application);

            var assemblyData = Directory.GetFiles(
                    legacyExtensionPath,
                    ExtensionsSearchString,
                    SearchOption.AllDirectories)
                .Select(
                    x =>
                    {
                        string assemblyName = GetAssemblyName(x);

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
                    }).ToList();

            assemblyData.ForEach(x => _logger.Debug($"Found file matching '{ExtensionsSearchString}' at '{x.Path}'"));

            return assemblyData;
        }
    }
}
