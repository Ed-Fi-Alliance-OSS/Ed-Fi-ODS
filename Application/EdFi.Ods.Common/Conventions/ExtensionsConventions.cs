// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
#if NETFRAMEWORK
using Castle.Core.Internal;
#endif
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Conventions
{
    public static class ExtensionsConventions
    {
        private const string ExtensionSuffix = "Extension";
        private const string ExtensionCollectionName = "Extensions";

        /// <summary>
        /// This extension method will compute the fully-qualified assembly name given the extension-name, resource-name and the
        /// containing-classes
        /// </summary>
        /// <param name="extensionName"></param>
        /// <param name="resourceName"></param>
        /// <param name="containingClassName"></param>
        /// <returns>fully-qualified assembly name</returns>
        public static string GetExtensionResourceClassAssemblyQualifiedName(
            string extensionName,
            string resourceName,
            string containingClassName)
        {
            if (string.IsNullOrEmpty(extensionName))
            {
                throw new ArgumentNullException(nameof(extensionName));
            }

            string extensionAssemblyName = GetExtensionAssemblyName(extensionName);

            string @namespace = EdFiConventions.CreateResourceNamespace(
                EdFiConventions.ProperCaseName,
                resourceName,
                null,
                null,
                null,
                extensionName);

            string extensionResourceClassTypeName = $"{@namespace}.{GetExtensionClassName(containingClassName)}";

            return $"{extensionResourceClassTypeName}, {extensionAssemblyName}";
        }

        public static string GetExtensionClassAssemblyQualifiedName(Type edFiStandardType, string extensionName)
        {
            string @namespace;
            string extensionClassTypeName;
            string extensionAssemblyName;

            if (edFiStandardType.IsEdFiEntity())
            {
                string aggregateName = ParseAggregateNameFromEntityType(edFiStandardType);

                // As of this implementation:
                //   Entity:            EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi.{className}
                //   Extension Entity:  EdFi.Ods.Entities.NHibernate.StudentAggregate.Sample.{extensionClassName}
                @namespace = Namespaces.Entities.NHibernate.AggregateNamespaceForEntity(
                    Namespaces.Entities.NHibernate.BaseNamespace,
                    aggregateName,
                    extensionName);

                extensionClassTypeName = $"{@namespace}.{GetExtensionClassName(edFiStandardType.Name)}";

                extensionAssemblyName = GetExtensionAssemblyName(extensionName);
            }
            else
            {
                //If standard type exists in profile assembly, use edFiStandardType assembly name.
                //Otherwise, use extension conventions to determine assembly name.
                bool isProfileAssembly = EdFiConventions.IsProfileAssembly(edFiStandardType.Assembly);

                extensionAssemblyName = isProfileAssembly
                    ? edFiStandardType.Assembly.GetName()
                        .Name
                    : GetExtensionAssemblyName(extensionName);

                var profileName = string.Empty;

                if (isProfileAssembly)
                {
                    //In This case we are within a profile context
                    //the profile name is on the end of the assembly name
                    if (!string.IsNullOrWhiteSpace(edFiStandardType.Namespace))
                    {
                        profileName = edFiStandardType.Namespace.Split('.')
                            .Last();
                    }
                }

                var aggregateName = ParseAggregateNameFromResourceType(edFiStandardType);

                @namespace = EdFiConventions.CreateResourceNamespace(
                    EdFiConventions.ProperCaseName,
                    aggregateName,
                    profileName,
                    null,
                    null,
                    extensionName);

                extensionClassTypeName = $"{@namespace}.{GetExtensionClassName(edFiStandardType.Name)}";

                // Verify that suffix was trimmed, if not then provided type doesn't follow expected convention
                if (@namespace == edFiStandardType.Namespace)
                {
                    throw new Exception(
                        $"The namespace of the supplied Ed-Fi standard type '{edFiStandardType.FullName}' does not follow expected conventions.");
                }
            }

            return $"{extensionClassTypeName}, {extensionAssemblyName}";
        }

        private static string ParseAggregateNameFromEntityType(Type edFiStandardType)
        {
            int endPos = edFiStandardType.FullName.IndexOf("Aggregate.");

            if (endPos < 0)
            {
                throw new Exception(
                    $"{nameof(edFiStandardType)}'s namespace of '{edFiStandardType.FullName}' did not match the expected format for an Entity type.");
            }

            int startPos = edFiStandardType.FullName.Substring(0, endPos)
                .LastIndexOf(".");

            if (startPos < 0)
            {
                throw new Exception(
                    $"{nameof(edFiStandardType)}'s namespace of '{edFiStandardType.FullName}' did not match the expected format for an Entity type.");
            }

            string aggregateName = edFiStandardType.FullName.Substring(startPos + 1, endPos - startPos - 1);

            return aggregateName;
        }

        private static string ParseAggregateNameFromResourceType(Type edFiStandardType)
        {
            // EdFi.Ods.Api.Models.Resources.Staff.EdFi.StaffAddress
            if (!edFiStandardType.FullName?.StartsWith(Namespaces.Resources.BaseNamespace) ?? true)
            {
                throw new Exception(
                    $"{nameof(edFiStandardType)}'s namespace of '{edFiStandardType.FullName}' did not match the expected format for an Resource type.");
            }

            // Staff.EdFi.StaffAddress
            var baseNamespaceRemoved = edFiStandardType.FullName.Replace($"{Namespaces.Resources.BaseNamespace}.", string.Empty);

            // [Staff] . [EdFi] . [StaffAddress]
            var typeNameparts = baseNamespaceRemoved.Split('.');

            if (typeNameparts.Length <= 1)
            {
                throw new Exception(
                    $"{nameof(edFiStandardType)}'s namespace of '{edFiStandardType.FullName}' did not match the expected format for an Resource type.");
            }

            // [Staff] Aggregate
            return typeNameparts.First();
        }

        /// <summary>
        /// Determines if the assembly is an extension 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static bool IsExtensionAssembly(this Assembly assembly)
        {
            return assembly.FullName.IsExtensionAssembly();
        }

        /// <summary>
        /// Determines if the assembly name is an extension assembly
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static bool IsExtensionAssembly(this string assemblyName)
        {
            return assemblyName.StartsWithIgnoreCase(Namespaces.Extensions.BaseNamespace);
        }

        /// <summary>
        /// Computes the ProperCaseName value from an input Logical Name 
        /// </summary>
        /// <param name="logicalName"></param>
        /// <returns></returns>
        public static string GetProperCaseNameForLogicalName(string logicalName)
        {
            return logicalName.NormalizeCompositeTermForDisplay('-')
                .Replace(" ", string.Empty);
        }

        /// <summary>
        /// Gets the last segment of the provided assembly name, which by convention, should be the ProperCaseName.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns>The last segment of the provided assembly name, by convention.</returns>
        public static string GetProperCaseNameFromAssemblyName(string assemblyName)
        {
            return assemblyName.Split('.')
                .Last();
        }

        /// <summary>
        /// Gets the member name to be used in the dynamic NHibernate mapping for the supplied aggregate extension <see cref="Entity" />.
        /// </summary>
        /// <returns>The name to be used in the NHibernate dynamic mapping.</returns>
        public static string GetAggregateExtensionMemberName(Entity aggregateExtensionEntity)
        {
            if (!aggregateExtensionEntity.IsAggregateExtension)
            {
                throw new Exception($"The supplied '{nameof(aggregateExtensionEntity)}' was not an aggregate extension.");
            }

            string extensionName =
                aggregateExtensionEntity.DomainModel.SchemaNameMapProvider
                    .GetSchemaMapByPhysicalName(aggregateExtensionEntity.Schema)
                    .ProperCaseName;

            // Use the association's name (which incorporates the role name, if applicable)
            string roleName = aggregateExtensionEntity.ParentAssociation.Inverse.RoleName;
            string pluralName = aggregateExtensionEntity.PluralName;

            // Convention is to supply the SchemaProperCaseName and pluralized entity name (with role name retained, if present), concatenated.
            return $"{extensionName}_{roleName}{pluralName}";
        }

#if NETFRAMEWORK
        private static string GetExtensionClassTypeName(string @namespace, string extensionName, string className)
        {
            string extensionSegment = extensionName.IsNullOrEmpty()
                ? string.Empty
                : $".{extensionName}";

            return $"{@namespace}{extensionSegment}.{GetExtensionClassName(className)}";
        }
#endif
        public static string GetExtensionClassName(string className)
        {
            return $"{className}{ExtensionSuffix}";
        }

        public static string GetExtendedClassName(string extensionClassName)
            => extensionClassName.Replace(ExtensionSuffix, string.Empty);

        public static bool IsExtensionClassName(string className) => className.EndsWith(ExtensionSuffix);

        private static string GetExtensionAssemblyName(string extensionName)
        {
            return $"{Namespaces.Extensions.BaseNamespace}.{extensionName}";
        }

        public static bool IsExtensionCollectionProperty(this PropertyInfo propertyInfo)
        {
            return typeof(IDictionary).IsAssignableFrom(propertyInfo.PropertyType)
                   && propertyInfo.Name.EndsWithIgnoreCase(ExtensionCollectionName);
        }

        public static bool IsExtensionSchemaDirectory(string schemaDirectory)
        {
            return schemaDirectory.Contains(Namespaces.Extensions.BaseNamespace);
        }
    }
}
