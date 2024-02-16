// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.Common.Inflection;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using Microsoft.OpenApi.Models;

namespace EdFi.LoadTools.SmokeTest
{
    public class PropertyInfoMetadataLookup(Dictionary<string, Entity> entityDictionary,
        Dictionary<string, Resource> resourceDictionary, List<string> schemaNames)
        : IPropertyInfoMetadataLookup
    {
        private string _propertyName;
        private string _parentTypeName;

        public OpenApiParameter GetMetadata(PropertyInfo propInfo)
        {
            _propertyName = RemoveEscapePrefixesFromPropertyName(propInfo.Name);
            _parentTypeName = Inflector.MakeInitialLowerCase(propInfo.DeclaringType?.Name);

            var resource = resourceDictionary.Values.FirstOrDefault(
                    r =>
                        TypeNameHelper.CompareTypeNames(r.Name, _parentTypeName, string.Empty, schemaNames))
                ?.Definition;

            var property = resource?.Properties.FirstOrDefault(
                x => x.Key.Equals(
                    _propertyName,
                    StringComparison.OrdinalIgnoreCase)).Value;

            // check for any definition if we could not find the the property from the resource
            if (property == null)
            {
                resource = entityDictionary.Values
                    .FirstOrDefault(
                        r => r.Name.Equals(
                            _parentTypeName, StringComparison.OrdinalIgnoreCase))
                    ?.Definition;

                property = resource?.Properties.FirstOrDefault(
                    x => x.Key.Equals(
                        _propertyName,
                        StringComparison.OrdinalIgnoreCase)).Value;
            }

            var required = resource?.Required?.FirstOrDefault(
                p => p.Equals(
                    _propertyName,
                    StringComparison.OrdinalIgnoreCase));

            return new OpenApiParameter
            {
                Required = required != null,
                Schema = new OpenApiSchema
                {
                    Minimum = property?.Minimum,
                    Maximum = property?.Maximum,
                    MinLength = property?.MinLength,
                    MaxLength = property?.MaxLength
                }
            };
        }

        /// <summary>
        /// Removes the escape prefix ("Var") added by the OpenApi client code generation utility to property names which are also reserved words in C# (i.e. "Namespace"). 
        /// </summary>
        /// <param name="openApiPropertyName">The property name from the generated API client model.</param>
        /// <returns>The property name with the prefix added during OpenApi client code generation removed.</returns>
        private static string RemoveEscapePrefixesFromPropertyName(string openApiPropertyName)
            => Regex.Replace(
                Regex.Replace(openApiPropertyName, "^VarNamespace$", "Namespace")
                , @"_", string.Empty);
    }
}
