// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Common.Extensions
{
    public static class TypeExtensions
    {
        private static readonly Dictionary<Type, object> defaultValuesByType = new Dictionary<Type, object>();

        private static readonly Dictionary<Type, Type> itemTypesByGenericListType = new Dictionary<Type, Type>();

        public static T GetDefaultValue<T>()
        {
            return (T) GetDefaultValue(typeof(T));
        }

        public static object GetDefaultValue(this Type type)
        {
            object value;

            if (!defaultValuesByType.TryGetValue(type, out value))
            {
                lock (defaultValuesByType)
                {
                    if (type.IsValueType)
                    {
                        value = Activator.CreateInstance(type);
                    }
                    else
                    {
                        value = null;
                    }

                    defaultValuesByType[type] = value;
                }
            }

            return value;
        }

        public static Type GetItemType(this Type type)
        {
            Type itemType;

            if (!itemTypesByGenericListType.TryGetValue(type, out itemType))
            {
                itemType = type.GetGenericArguments()
                               .FirstOrDefault();

                itemTypesByGenericListType[type] = itemType;
            }

            return itemTypesByGenericListType[type];
        }

        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Gets the non-nullable type (if applicable) for the given type.
        /// </summary>
        /// <param name="type">The type to be evaluated.</param>
        /// <returns>The non-nullable type or the original type (if already non-nullable).</returns>
        public static Type GetNonNullableType(this Type type)
        {
            Type underlyingType = null;

            if (type.IsGenericType)
            {
                underlyingType = Nullable.GetUnderlyingType(type);
            }

            return underlyingType ?? type;
        }

        public static bool IsAssignableFromGeneric(this Type genericType, Type type)
        {
            return
                type.GetInterfaces()
                    .Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                || type.IsGenericType && type.GetGenericTypeDefinition() == genericType
                || type.BaseType != null && IsAssignableFromGeneric(genericType, type.BaseType);
        }
    }
}
