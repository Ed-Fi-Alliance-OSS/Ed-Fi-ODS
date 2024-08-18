// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Extensions
{
    public static class TypeExtensions
    {
        private static readonly ConcurrentDictionary<Type, object> _defaultValuesByType = new();
        private static readonly ConcurrentDictionary<Type, Type> _itemTypesByGenericListType = new();
        private static readonly ConcurrentDictionary<Type, FullName> _fullNameByEntityType = new();

        public static T GetDefaultValue<T>()
        {
            return (T) GetDefaultValue(typeof(T));
        }

        public static object GetDefaultValue(this Type type)
        {
            return _defaultValuesByType.GetOrAdd(
                type,
                t =>
                {
                    if (type.IsValueType)
                    {
                        return Activator.CreateInstance(type);
                    }
                    else
                    {
                        return null;
                    }
                });
        }

        public static Type GetItemType(this Type type)
        {
            return _itemTypesByGenericListType.GetOrAdd(type, t =>
                type.GetGenericArguments().FirstOrDefault());
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

        public static IEnumerable<PropertyInfo> GetSignatureProperties(this Type type)
        {
            return type.GetProperties()
                .Where(
                    p => Attribute.IsDefined(p, typeof(DomainSignatureAttribute), true));
        }

        public static FullName GetApiModelFullName(this Type entityType)
        {
            return _fullNameByEntityType.GetOrAdd(
                entityType,
                static t =>
                {
                    var schema = t.GetCustomAttribute<SchemaAttribute>(false)?.Schema
                        ?? throw new Exception($"The '{nameof(SchemaAttribute)}' was not found on entity type '{t.FullName}'.");

                    var fullName = new FullName(schema, t.Name);

                    return fullName;
                });
        }

        public static FullName GetApiModelFullName<TEntity>(this TEntity entity)
        {
            Type entityType = typeof(TEntity);

            return GetApiModelFullName(entityType);
        }

        public static bool IsScalar(this Type type)
        {
            return type.IsValueType || type == typeof(string);
        }
    }
}
