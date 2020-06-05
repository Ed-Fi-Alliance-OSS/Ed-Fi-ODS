// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace EdFi.Ods.Security.AuthorizationStrategies
{
    /// <summary>
    /// Creates context data from a source entity using the specified types, based on matching property names.
    /// </summary>
    /// <remarks>This class is threadsafe and uses shared static state to persist the dynamically created factory methods.</remarks>
    public class AuthorizationContextDataFactory
    {
        private static readonly ConcurrentDictionary<string, ExtractDelegate> FactoryMethodByMethodName =
            new ConcurrentDictionary<string, ExtractDelegate>();

        public TContextData CreateContextData<TContextData>(object entity, PropertyMapping[] propertyNameMap = null)
            where TContextData : class, new()
        {
            // Can't map anything if source is null
            if (entity == null)
            {
                return null;
            }

            Type sourceType = entity.GetType();
            Type contextDataType = typeof(TContextData);

            string methodName = sourceType.FullName.Replace('.', '_') + "_to_" + contextDataType.FullName.Replace('.', '_');

            var factoryDelegate = FactoryMethodByMethodName.GetOrAdd(
                methodName,
                mn => CreateDynamicExtractorMethod(mn, sourceType, contextDataType, propertyNameMap));

            // If no properties were present to be mapped, return a null context
            if (factoryDelegate == null)
            {
                return null;
            }

            var contextData = new TContextData();
            factoryDelegate.Invoke(entity, contextData);

            return contextData;
        }

        private static ExtractDelegate CreateDynamicExtractorMethod(
            string methodName,
            Type sourceType,
            Type targetType,
            PropertyMapping[] propertyNameMappings = null)
        {
            var sourceProperties = sourceType.GetProperties()
                                             .ToDictionary(x => x.Name, x => x);

            var targetProperties = targetType.GetProperties()
                                             .ToDictionary(x => x.Name, x => x);

            // If not supplied, autogenerate the mappings based on matching property names
            if (propertyNameMappings == null)
            {
                propertyNameMappings =
                    (from s in sourceProperties
                     from t in targetProperties
                     where s.Key == t.Key
                     select new PropertyMapping(s.Key, t.Key))
                   .ToArray();
            }
            else
            {
                ValidatePropertyMappings(
                    propertyNameMappings,
                    sourceType,
                    sourceProperties,
                    targetType,
                    targetProperties);
            }

            // If there are no properties to map, return null
            if (!propertyNameMappings.Any())
            {
                return null;
            }

            var m = new DynamicMethod(
                methodName,
                null,
                new[]
                {
                    typeof(object), typeof(object)
                },
                true);

            var il = m.GetILGenerator();

            il.DeclareLocal(targetType);
            il.DeclareLocal(sourceType);

            il.Emit(OpCodes.Nop);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Castclass, targetType);
            il.Emit(OpCodes.Stloc_0);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, sourceType);
            il.Emit(OpCodes.Stloc_1);

            foreach (var mapping in propertyNameMappings)
            {
                var sourceProperty = sourceProperties[mapping.SourcePropertyName];
                var targetProperty = targetProperties[mapping.TargetPropertyName];

                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ldloc_1);

                var sourceUnderlyingType = Nullable.GetUnderlyingType(sourceProperty.PropertyType);

                // Non-nullable type source
                il.Emit(OpCodes.Callvirt, sourceProperty.GetGetMethod());

                var targetUnderlyingType = Nullable.GetUnderlyingType(targetProperty.PropertyType);

                if (targetUnderlyingType != null && sourceUnderlyingType != null || targetUnderlyingType == null)
                {
                    // Non-nullable type target
                    il.Emit(OpCodes.Callvirt, targetProperty.GetSetMethod());
                }
                else
                {
                    // Nullable type target
                    il.Emit(
                        OpCodes.Newobj,
                        targetProperty.PropertyType.GetConstructor(
                            new[]
                            {
                                targetUnderlyingType
                            }));

                    il.Emit(OpCodes.Callvirt, targetProperty.GetSetMethod());
                }

                il.Emit(OpCodes.Nop);
            }

            il.Emit(OpCodes.Ret);

            var d = (ExtractDelegate) m.CreateDelegate(typeof(ExtractDelegate));

            return d;
        }

        private static void ValidatePropertyMappings(
            PropertyMapping[] propertyNameMappings,
            Type sourceType,
            Dictionary<string, PropertyInfo> sourceProperties,
            Type targetType,
            Dictionary<string, PropertyInfo> targetProperties)
        {
            var missingSourceProperties = propertyNameMappings
                                         .Select(x => x.SourcePropertyName)
                                         .Except(sourceProperties.Keys)
                                         .ToList();

            var missingTargetProperties = propertyNameMappings
                                         .Select(x => x.TargetPropertyName)
                                         .Except(targetProperties.Keys)
                                         .ToList();

            var sb = new StringBuilder();

            if (missingSourceProperties.Any())
            {
                string errorText = string.Join(
                    Environment.NewLine,
                    missingSourceProperties.Select(x => "    " + x));

                sb.AppendLine(
                    $"The following properties were not found on the source type '{sourceType.FullName}':{Environment.NewLine}{errorText}");
            }

            if (missingTargetProperties.Any())
            {
                string errorText = string.Join(
                    Environment.NewLine,
                    missingTargetProperties.Select(x => "    " + x));

                sb.AppendLine(
                    $"The following properties were not found on the target type '{targetType.FullName}':{Environment.NewLine}{errorText}");
            }

            if (sb.Length > 0)
            {
                throw new MissingMemberException($"The supplied property mappings were invalid.{Environment.NewLine}{sb}");
            }
        }

        private delegate void ExtractDelegate(object source, object target);
    }

    /// <summary>
    /// Represents a property mapping to be used in building a custom authorization context factory method.
    /// </summary>
    public class PropertyMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyMapping" /> class using the specified source and target property names.
        /// </summary>
        /// <param name="sourcePropertyName">The name of the source property on the entity class.</param>
        /// <param name="targetPropertyName">The name of the target property on the authorization context class).</param>
        public PropertyMapping(string sourcePropertyName, string targetPropertyName)
        {
            SourcePropertyName = sourcePropertyName;
            TargetPropertyName = targetPropertyName;
        }

        /// <summary>
        /// Gets the name of the source property on the entity class.
        /// </summary>
        public string SourcePropertyName { get; }

        /// <summary>
        /// Gets the name of the target property on the authorization context class).
        /// </summary>
        public string TargetPropertyName { get; }
    }
}
