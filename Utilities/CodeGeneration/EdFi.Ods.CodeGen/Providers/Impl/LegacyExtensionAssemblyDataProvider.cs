// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.CodeGen.Conventions;
using EdFi.Ods.CodeGen.Helpers;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using log4net;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class LegacyExtensionAssemblyDataProvider : IAssemblyDataProvider
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(AssembliesProvider));

        private readonly AssemblyDataHelper _assemblyDataHelper;
        private readonly ICodeRepositoryProvider _codeRepositoryProvider;
        private readonly IDictionary<string, IDomainModelDefinitionsProvider> _domainModelsDefinitionsProvidersByProjectName;

        public const string ExtensionsSearchString = "EdFi.Ods.Extensions.*.csproj";

        public LegacyExtensionAssemblyDataProvider(
            AssemblyDataHelper assemblyDataHelper,
            ICodeRepositoryProvider codeRepositoryProvider,
            IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider)
        {
            _assemblyDataHelper = Preconditions.ThrowIfNull(assemblyDataHelper, nameof(assemblyDataHelper));
            _codeRepositoryProvider = Preconditions.ThrowIfNull(codeRepositoryProvider, nameof(codeRepositoryProvider));
            Preconditions.ThrowIfNull(domainModelDefinitionsProviderProvider, nameof(domainModelDefinitionsProviderProvider));

            _domainModelsDefinitionsProvidersByProjectName =
                domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName();
        }

        public IEnumerable<AssemblyData> Get()
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
                        string assemblyName = _assemblyDataHelper.GetAssemblyName(x);

                        string schemaName = ExtensionsConventions.GetProperCaseNameForLogicalName(
                            _domainModelsDefinitionsProvidersByProjectName[assemblyName]
                                .GetDomainModelDefinitions()
                                .SchemaDefinition
                                .LogicalName);

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
