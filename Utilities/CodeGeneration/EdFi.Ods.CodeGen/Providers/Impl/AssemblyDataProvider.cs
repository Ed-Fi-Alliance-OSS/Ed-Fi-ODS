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
using EdFi.Ods.Common.Extensions;
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
        private readonly IIncludePluginsProvider _includeExtensionsProvider;
        public AssemblyDataProvider(
            ICodeRepositoryProvider codeRepositoryProvider,
            IJsonFileProvider jsonFileProvider,
            IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider,
            IIncludePluginsProvider includeExtensionsProvider)
        {
            _codeRepositoryProvider = Preconditions.ThrowIfNull(codeRepositoryProvider, nameof(codeRepositoryProvider));
            _jsonFileProvider = Preconditions.ThrowIfNull(jsonFileProvider, nameof(jsonFileProvider));

            _domainModelDefinitionsProviderProvider =
                Preconditions.ThrowIfNull(domainModelDefinitionsProviderProvider, nameof(domainModelDefinitionsProviderProvider));

            _domainModelsDefinitionsProvidersByProjectName =
                domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName();

            _includeExtensionsProvider = includeExtensionsProvider;
        }

        public IEnumerable<AssemblyData> Get()
        {
            _logger.Debug($"Getting all paths to assemblyMetadata.json");

            // List of known assemblies with the assemblyMetaData.json file
            var assemblyDatas = Directory.GetFiles(
                    _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                        CodeRepositoryConventions.Implementation,
                        CodeRepositoryConventions.Application),
                    AssemblyMetadataSearchString,
                    SearchOption.AllDirectories)
                .Concat(
                    Directory.GetFiles(
                        _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                            CodeRepositoryConventions.Ods,
                            "Application"),
                        AssemblyMetadataSearchString,
                        SearchOption.AllDirectories))
                .Select(Create)
                .ToList();

            if (_includeExtensionsProvider.IncludePlugins())
            {
                var extensionsPath = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                    CodeRepositoryConventions.ExtensionsFolderName,
                    "Extensions");

                if (Directory.Exists(extensionsPath))
                {
                    assemblyDatas.AddRange(
                        Directory.GetFiles(
                                extensionsPath,
                                AssemblyMetadataSearchString,
                                SearchOption.AllDirectories)
                            .Select(Create)
                            .ToList()
                    );
                }
            }

            // Add database specific code generation... this is a code smell but is a convention. Sql generation should be done in metaed.
            assemblyDatas.Add(
                new AssemblyData
                {
                    AssemblyName = "ODS Database Specific",
                    Path = _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                        CodeRepositoryConventions.Ods,
                        CodeRepositoryConventions.Database),
                    TemplateSet = TemplateSetConventions.Database,
                    IsProfile = false,
                    IsExtension = false,
                    SchemaName = EdFiConventions.PhysicalSchemaName
                });

            // Convention based location of profiles and extensions (backwards compatibility)
            _logger.Debug($"Getting any extension and profile assemblies from the implementation folder");

            var legacyAssemblyDatas = Directory.GetFiles(
                    _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                        CodeRepositoryConventions.Implementation,
                        CodeRepositoryConventions.Application),
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
                    })
                .Concat(
                    Directory.GetFiles(
                            _codeRepositoryProvider.GetResolvedCodeRepositoryByName(
                                CodeRepositoryConventions.Implementation,
                                CodeRepositoryConventions.Application),
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
                            }))
                .ToList();

            foreach (AssemblyData legacyAssemblyData in legacyAssemblyDatas
                .Where(a => !assemblyDatas.Any(x => x.AssemblyName.EqualsIgnoreCase(a.AssemblyName))))
            {
                _logger.Debug($"Adding legacy assembly {legacyAssemblyData.AssemblyName} for processing.");
                assemblyDatas.Add(legacyAssemblyData);
            }

            return assemblyDatas;

            AssemblyData Create(string assemblyMetadataPath)
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
        }

        // last element is the assemblyName.
        private static string GetAssemblyName(string assemblyMetadataPath)
            => Path.GetDirectoryName(assemblyMetadataPath)
                ?.Split(Path.DirectorySeparatorChar)
                .LastOrDefault();
    }
}
