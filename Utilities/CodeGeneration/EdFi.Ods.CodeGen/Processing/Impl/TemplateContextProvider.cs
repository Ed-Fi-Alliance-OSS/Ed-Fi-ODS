// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.CodeGen.Models;
using EdFi.Ods.CodeGen.Providers;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.CodeGen.Processing.Impl
{
    public class TemplateContextProvider : ITemplateContextProvider
    {
        private readonly Lazy<List<IDomainModelDefinitionsProvider>> _domainModelDefinitionProviders;
        private readonly ConcurrentDictionary<string, TemplateContext> _templateContextByAssemblyName = new();

        public TemplateContextProvider(IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider)
        {
            IDomainModelDefinitionsProviderProvider domainModelDefinitionsProviderProvider1 = Preconditions.ThrowIfNull(
                domainModelDefinitionsProviderProvider,
                nameof(domainModelDefinitionsProviderProvider));

            _domainModelDefinitionProviders =
                new Lazy<List<IDomainModelDefinitionsProvider>>(
                    () => domainModelDefinitionsProviderProvider1.DomainModelDefinitionProviders()
                        .ToList());
        }

        public TemplateContext Create(AssemblyData assemblyData)
        {
            Preconditions.ThrowIfNull(assemblyData, nameof(assemblyData));

            return _templateContextByAssemblyName
                .GetOrAdd(
                    assemblyData.AssemblyName,
                    k => GetTemplateContext(assemblyData));
        }

        private TemplateContext GetTemplateContext(AssemblyData assemblyData)
        {
            var domainModelProvider = CreateDomainModelProvider(assemblyData);

            var schemaNameMap = domainModelProvider.GetDomainModel()
                .SchemaNameMapProvider.GetSchemaMapByProperCaseName(assemblyData.SchemaName);

            return new TemplateContext
            {
                ProjectPath = assemblyData.Path,
                IsExtension = assemblyData.IsExtension,
                SchemaProperCaseName = schemaNameMap.ProperCaseName,
                DomainModelProvider = domainModelProvider,
                SchemaPhysicalName = schemaNameMap.PhysicalName
            };
        }

        private IDomainModelProvider CreateDomainModelProvider(AssemblyData assemblyData)
        {
            // Always include EdFi, and only include the extension definition provider if we are generating in an extension schema context
            return new DomainModelProvider(
                GetDomainModelDefinitionProviders(assemblyData.SchemaName),
                Array.Empty<IDomainModelDefinitionsTransformer>());
        }

        private List<IDomainModelDefinitionsProvider> GetDomainModelDefinitionProviders(string schemaName)
        {
            return _domainModelDefinitionProviders.Value
                .Where(p => IsProviderMatchingSchema(p) || IsProviderContainingEdFiSchemaDefinitions(p))
                .ToList();

            bool IsProviderContainingEdFiSchemaDefinitions(IDomainModelDefinitionsProvider x)
                => x.GetDomainModelDefinitions().SchemaDefinition.LogicalName.EqualsIgnoreCase(EdFiConventions.LogicalName);

            bool IsProviderMatchingSchema(IDomainModelDefinitionsProvider x)
                => schemaName.EqualsIgnoreCase(
                    ExtensionsConventions.GetProperCaseNameForLogicalName(
                        x.GetDomainModelDefinitions().SchemaDefinition.LogicalName));
        }
    }
}
