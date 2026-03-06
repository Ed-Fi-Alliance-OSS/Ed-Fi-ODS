// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     return an empty list of the given type
    /// </summary>
    public class ListPropertyBuilder : BaseBuilder
    {
        public ListPropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup)
        {
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (propertyType.IsGenericType && typeof(List<>).IsAssignableFrom(propertyType.GetGenericTypeDefinition()))
            {
                if (IsRequired(propertyInfo))
                {
                    try
                    {
                        propertyInfo.SetValue(obj, Activator.CreateInstance(propertyType));
                    }
                    catch
                    {
                        // Lists should always have parameterless constructors, but handle edge cases
                        try
                        {
                            propertyInfo.SetValue(obj, RuntimeHelpers.GetUninitializedObject(propertyType));
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }
    }
}
