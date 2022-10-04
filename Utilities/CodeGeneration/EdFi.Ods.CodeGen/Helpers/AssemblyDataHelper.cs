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
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.CodeGen.Helpers
{
    public class AssemblyDataHelper
    {
        private readonly IJsonFileProvider _jsonFileProvider;
        private readonly IDictionary<string, IDomainModelDefinitionsProvider> _domainModelsDefinitionsProvidersByProjectName;

        public AssemblyDataHelper(
            IJsonFileProvider jsonFileProvider,
            IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider)
        {
            _jsonFileProvider = Preconditions.ThrowIfNull(jsonFileProvider, nameof(jsonFileProvider));

            Preconditions.ThrowIfNull(domainModelDefinitionsProviderProvider, nameof(domainModelDefinitionsProviderProvider));

            _domainModelsDefinitionsProvidersByProjectName =
                domainModelDefinitionsProviderProvider.DomainModelDefinitionsProvidersByProjectName();
        }

        // last element is the assemblyName.
        public string GetAssemblyName(string assemblyMetadataPath)
            => Path.GetDirectoryName(assemblyMetadataPath)
                ?.Split(Path.DirectorySeparatorChar)
                .LastOrDefault();

        public AssemblyData CreateAssemblyData(string assemblyMetadataPath)
        {
            var assemblyMetadata = _jsonFileProvider.Load<AssemblyMetadata>(assemblyMetadataPath);

            bool isExtension = assemblyMetadata.AssemblyModelType.EqualsIgnoreCase(TemplateSetConventions.Extension);

            string assemblyName = GetAssemblyName(assemblyMetadataPath);

            var schemaName = isExtension
                ? ExtensionsConventions.GetProperCaseNameForLogicalName(
                    _domainModelsDefinitionsProvidersByProjectName[assemblyName]
                        .GetDomainModelDefinitions()
                        .SchemaDefinition.LogicalName)
                : EdFiConventions.ProperCaseName;

            var assemblyData = new AssemblyData
            {
                AssemblyName = assemblyName,
                Path = Path.GetDirectoryName(assemblyMetadataPath),
                TemplateSet = assemblyMetadata.AssemblyModelType,
                SchemaName = schemaName,
                IsExtension = isExtension
            };

            return assemblyData;
        }
    }
}
