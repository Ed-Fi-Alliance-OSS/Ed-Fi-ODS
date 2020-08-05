// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdFi.TestObjects._Extensions
{
    public static class TypeExtensions
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> propertyInfosByType = new ConcurrentDictionary<Type, PropertyInfo[]>();

        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            return propertyInfosByType.GetOrAdd(
                type,
                t =>
                {
                    if (!t.IsInterface)
                    {
                        return t.GetProperties(
                            BindingFlags.FlattenHierarchy
                            | BindingFlags.Public | BindingFlags.Instance);
                    }

                    var propertyInfoList = new List<PropertyInfo>();

                    var considered = new List<Type>();
                    var queue = new Queue<Type>();
                    considered.Add(t);
                    queue.Enqueue(t);

                    while (queue.Count > 0)
                    {
                        var subType = queue.Dequeue();

                        foreach (var subInterface in subType.GetInterfaces())
                        {
                            if (considered.Contains(subInterface))
                            {
                                continue;
                            }

                            considered.Add(subInterface);
                            queue.Enqueue(subInterface);
                        }

                        var typeProperties = subType.GetProperties(
                            BindingFlags.FlattenHierarchy
                            | BindingFlags.Public
                            | BindingFlags.Instance);

                        var newPropertyInfos = typeProperties
                           .Where(x => !propertyInfoList.Contains(x));

                        propertyInfoList.InsertRange(0, newPropertyInfos);
                    }

                    return propertyInfoList.ToArray();
                });
        }

        public static bool IsCustomClass(this Type type)
        {
            return type.IsClass && !type.Namespace.StartsWith("System");
        }

        public static bool IsScalarProperty(this Type type)
        {
            return type == typeof(string) || type.IsValueType;
        }
    }
}
