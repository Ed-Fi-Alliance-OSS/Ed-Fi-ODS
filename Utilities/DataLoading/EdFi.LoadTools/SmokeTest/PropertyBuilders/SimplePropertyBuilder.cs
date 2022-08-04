// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     if a type is nullable, skip it.
    /// </summary>
    public class SimplePropertyBuilder : BaseBuilder
    {
        private int _counter = 50; // Start from 50 to not collide with existing EdOrgIds if running over the populated template
        private readonly Dictionary<string, object> _unifiedKeyValue;

        public SimplePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup, IDestructiveTestConfiguration configuration)
            : base(metadataLookup)
        {
            _unifiedKeyValue = new(
                configuration.UnifiedProperties.Distinct(StringComparer.OrdinalIgnoreCase)
                    .Select(up => new KeyValuePair<string, object>(up, null)), StringComparer.OrdinalIgnoreCase);
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (IsTypeMatch<bool>(propertyInfo))
            {
                propertyInfo.SetValue(obj, GetOrAdd(propertyInfo.Name, false));
                return true;
            }

            if (IsTypeMatch<int>(propertyInfo) || IsTypeMatch<long>(propertyInfo) || IsTypeMatch<double>(propertyInfo))
            {
                if (IsRequired(propertyInfo))
                {
                    propertyInfo.SetValue(obj, GetOrAdd(propertyInfo.Name, _counter++));
                }

                return true;
            }

            return false;
        }

        private object GetOrAdd(string propertyName, object defaultValue)
        {
            var value = _unifiedKeyValue.GetValueOrDefault(propertyName) ?? defaultValue;

            if (_unifiedKeyValue.ContainsKey(propertyName) && _unifiedKeyValue[propertyName] == null)
            {
                _unifiedKeyValue[propertyName] = value;
            }

            return value;
        }
    }
}
