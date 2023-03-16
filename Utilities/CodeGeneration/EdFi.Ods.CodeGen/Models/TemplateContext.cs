// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common;
using EdFi.Ods.CodeGen.Models.Configuration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.CodeGen.Models
{
    public class TemplateContext
    {
        /// <summary>
        /// Returns DomainModelProvider constructed with
        /// IDomainModelDefinitionsProviders from all Assemblies
        /// </summary>
        /// <returns></returns>
        public IDomainModelProvider DomainModelProvider { get; set; }

        /// <summary>
        /// Returns current project path being generated for.
        /// </summary>
        /// <returns></returns>
        public string ProjectPath { get; set; }

        /// <summary>
        /// Indicates if an entity should be rendered
        /// for the schema context we are currently within.
        /// eg Extension schema or Standard edfi schema
        /// </summary>
        /// <returns></returns>
        public Func<Entity, bool> ShouldRenderEntity
        {
            get => entity => ShouldRenderForSchema(entity.Schema);
        }

        /// <summary>
        /// Indicates if a resource should be rendered
        /// for the schema context we are currently within.
        /// eg Extension schema or Standard edfi schema
        /// </summary>
        /// <returns></returns>
        public Func<ResourceClassBase, bool> ShouldRenderResourceClass
        {
            get => resource =>
            {
                try
                {
                    return ShouldRenderForSchema(resource.FullName.Schema);
                }
                catch (ArgumentNullException ex)
                {
                    throw new InvalidOperationException(
                        $"Schema for resource '{resource.Name}' was null. Could not determine whether it should be rendered.",
                        ex);
                }
            };
        }

        /// <summary>
        /// Checks if we are within an extension code generation context.
        /// </summary>
        /// <returns></returns>
        public bool IsExtension { get; set; }

        /// <summary>
        /// Checks if we are within a standard code generation context.
        /// </summary>
        /// <returns></returns>
        public bool IsEdFi
        {
            get => !IsExtension;
        }

        /// <summary>
        /// Returns correct proper case name for project
        /// context we are generating code for. eg Extensions vs. Standard
        /// </summary>
        /// <returns></returns>
        public string SchemaProperCaseName { get; set; }

        /// <summary>
        /// Returns correct physical schema name for project
        /// context we are generating code for. eg Extensions vs. Standard
        /// </summary>
        /// <returns></returns>
        public string SchemaPhysicalName { get; set; }

        public TemplateSet TemplateSet { get; private set; }

        public void With(TemplateSet templateSet)
        {
            Preconditions.ThrowIfNull(templateSet, nameof(templateSet));
            TemplateSet = templateSet;
        }

        public string GetSchemaProperCaseNameForResource(ResourceClassBase resource)
        {
            Preconditions.ThrowIfNull(resource, nameof(resource));

            return resource.IsEdFiStandardResource
                ? SchemaProperCaseName
                : GetSchemaNameMapProvider()
                    .GetSchemaMapByPhysicalName(resource.FullName.Schema)
                    .ProperCaseName;

            ISchemaNameMapProvider GetSchemaNameMapProvider()
                => DomainModelProvider?.GetDomainModel()
                    .SchemaNameMapProvider;
        }

        public string GetSchemaProperCaseNameForExtension(Extension extension)
        {
            Preconditions.ThrowIfNull(extension, nameof(extension));

            return extension.ObjectType.ResourceModel.SchemaNameMapProvider
                .GetSchemaMapByPhysicalName(extension.ObjectType.FullName.Schema)
                .ProperCaseName;
        }

        private bool ShouldRenderForSchema(string schema) => schema == SchemaPhysicalName;
    }
}
