// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Common;
using EdFi.Common.Inflection;
using Swashbuckle.Swagger;

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

        public Parameter GetMetadata(PropertyInfo propInfo)
        {
            string parentTypeName = Inflector.MakeInitialLowerCase(propInfo.DeclaringType?.Name);

            var resource = _resourceDictionary.Values.FirstOrDefault(
                r =>
                TypeNameHelper.CompareTypeNames(r.Name, parentTypeName, string.Empty, _schemaNames))
                ?.Definition;

            var property = resource?.properties.FirstOrDefault(x => x.Key.Equals(
                Regex.Replace(propInfo.Name, @"_", string.Empty),
                StringComparison.InvariantCultureIgnoreCase)).Value;

            // check for any definition if we could not find the the property from the resource
            if (property == null)
            {
                resource = _entityDictionary.Values
                    .FirstOrDefault(r => r.Name.Equals(parentTypeName, StringComparison.InvariantCultureIgnoreCase))
                    ?.Definition;
                property = resource?.properties.FirstOrDefault(x => x.Key.Equals(
                    Regex.Replace(propInfo.Name, @"_", string.Empty),
                    StringComparison.InvariantCultureIgnoreCase)).Value;

            }

            var required = resource?.required.FirstOrDefault(
                p => p.Equals(
                    Regex.Replace(propInfo.Name, @"_", string.Empty),
                    StringComparison.InvariantCultureIgnoreCase));

            return new Parameter { required = required != null, minimum = property?.minimum, maximum = property?.maximum, minLength = property?.minLength, maxLength = property?.maxLength };
        }
    }
}
