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
    public class PropertyInfoMetadataLookup : IPropertyInfoMetadataLookup
    {
        private readonly Dictionary<string, Entity> _entityDictionary;
        private readonly Dictionary<string, Resource> _resourceDictionary;
        private readonly List<string> _schemaNames;

        public PropertyInfoMetadataLookup(Dictionary<string, Entity> entityDictionary, Dictionary<string, Resource> resourceDictionary, List<string> schemaNames)
        {
            _entityDictionary = entityDictionary;
            _resourceDictionary = resourceDictionary;
            _schemaNames = schemaNames;
        }

        public OpenApiParameter GetMetadata(PropertyInfo propInfo)
        {
            string parentTypeName = Inflector.MakeInitialLowerCase(propInfo.DeclaringType?.Name);

            var resource = _resourceDictionary.Values.FirstOrDefault(
                r =>
                TypeNameHelper.CompareTypeNames(r.Name, parentTypeName, string.Empty, _schemaNames))
                ?.Definition;

            var property = resource?.Properties.FirstOrDefault(x => x.Key.Equals(
                Regex.Replace(propInfo.Name, @"_", string.Empty),
                StringComparison.InvariantCultureIgnoreCase)).Value;

            // check for any definition if we could not find the the property from the resource
            if (property == null)
            {
                resource = _entityDictionary.Values
                    .FirstOrDefault(r => r.Name.Equals(parentTypeName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Definition;
                property = resource?.Properties.FirstOrDefault(x => x.Key.Equals(
                    Regex.Replace(propInfo.Name, @"_", string.Empty),
                    StringComparison.InvariantCultureIgnoreCase)).Value;

            }

            var required = resource?.Required?.FirstOrDefault(
                p => p.Equals(
                    Regex.Replace(propInfo.Name, @"_", string.Empty),
                    StringComparison.InvariantCultureIgnoreCase));

            return new OpenApiParameter
            {
                Required = required != null,
                Schema = new OpenApiSchema { Minimum = property?.Minimum, Maximum = property?.Maximum, MinLength = property?.MinLength, MaxLength = property?.MaxLength }
            };
        }
    }
}
