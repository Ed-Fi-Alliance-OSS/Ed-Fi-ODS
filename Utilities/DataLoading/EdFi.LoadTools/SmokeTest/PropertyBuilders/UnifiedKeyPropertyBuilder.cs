// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class UnifiedKeyPropertyBuilder : BaseBuilder
    {
        public UnifiedKeyPropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (!IsValueTypeOrString(propertyInfo.PropertyType))
            {
                return false;
            }

            // Try to find the property value within a referenced resource
            foreach (var objProperty in obj.GetType().GetProperties())
            {
                if (TryFindPropertyRecursive(propertyInfo, objProperty.GetValue(obj), out var result))
                {
                    propertyInfo.SetValue(obj, result);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Recursively searches a given <see cref="PropertyInfo"/> within a given object.
        /// Does not detect circular references.
        /// </summary>
        private static bool TryFindPropertyRecursive(PropertyInfo property, object obj, out object result)
        {
            result = null;

            if (obj == null || IsValueTypeOrString(obj.GetType()))
            {
                return false;
            }

            if (obj is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (TryFindPropertyRecursive(property, item, out result))
                    {
                        return true;
                    }
                }

                return false;
            }

            var objProperties = obj.GetType().GetProperties();

            var matchingProperty = objProperties
                .FirstOrDefault(p => p.Name.Equals(property.Name) && p.PropertyType == property.PropertyType);

            if (matchingProperty != null)
            {
                // Found the searched property at the current level
                result = matchingProperty.GetValue(obj);
                return true;
            }

            foreach (var objProperty in objProperties)
            {
                if (TryFindPropertyRecursive(property, objProperty.GetValue(obj), out result))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValueTypeOrString(Type type)
            => type.IsValueType || type == typeof(string);
    }
}
