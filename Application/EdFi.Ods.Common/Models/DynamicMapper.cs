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
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Common.Models
{
    /// <summary>
    /// Creates context data from a source entity using the specified types, based on matching property names.
    /// </summary>
    /// <remarks>This class is threadsafe and uses shared static state to persist the dynamically created factory methods.</remarks>
    public static class DynamicMapper
    {
        private static readonly ConcurrentDictionary<string, ExtractDelegate> _factoryMethodByMethodName = new();
        private static readonly ConcurrentDictionary<(Type sourceType, Type targetType), string> _factoryMethodNameByTypes = new();

        public static TContextData CreateContextData<TContextData>(
            object entity,
            PropertyMapping[] propertyNameMap = null,
            Func<string, IEnumerable<string>, PropertyMapping[]> getContextDataPropertyMappings = null)
            where TContextData : class, new()
        {
            // Can't map anything if source is null
            if (entity == null)
            {
                return null;
            }

            var targetInstance = Activator.CreateInstance<TContextData>();

            return (TContextData) MapToTarget(
                entity,
                targetInstance,
                typeof(TContextData),
                propertyNameMap,
                getContextDataPropertyMappings);
        }

        public static object MapToTarget(
            object sourceInstance,
            object targetInstance,
            Type targetType,
            PropertyMapping[] propertyNameMap = null,
            Func<string, IEnumerable<string>, PropertyMapping[]> getContextDataPropertyMappings = null)
        {
            // Can't map anything if source is null
            if (sourceInstance == null)
            {
                return null;
            }

            Type sourceType = sourceInstance.GetType();

            string methodName = _factoryMethodNameByTypes.GetOrAdd((sourceType, targetType), types => 
                $"{types.sourceType.FullName!.Replace('.', '_')}_to_{types.targetType.FullName!.Replace('.', '_')}");

            var factoryDelegate = _factoryMethodByMethodName.GetOrAdd(
                methodName,
                mn => CreateDynamicExtractorMethod(mn, sourceType, targetType, propertyNameMap, getContextDataPropertyMappings));

            // If no properties were present to be mapped, return a null context
            if (factoryDelegate == null)
            {
                return null;
            }

            factoryDelegate.Invoke(sourceInstance, targetInstance);

            return targetInstance;
        }

        /// <summary>
        /// Creates a method dynamically for extracting the authorization context data for the supplied <see cref="sourceType" /> and <see cref="targetType" />. 
        /// </summary>
        /// <param name="methodName">The name of the method to be created dynamically.</param>
        /// <param name="sourceType">The <see cref="Type" /> of the source object.</param>
        /// <param name="targetType">The <see cref="Type" /> of the target (authorization context data) object.</param>
        /// <param name="propertyNameMappings">Explicit property name mappings.</param>
        /// <param name="getContextDataPropertyMappings">A function that given a source property, returns the target property name to which is should be assigned.</param>
        /// <returns>The dynamically created method/delegate.</returns>
        /// <exception cref="SecurityAuthorizationException">Occurs when the supplied mapping function creates multiple mappings to the same target property.</exception>
        private static ExtractDelegate CreateDynamicExtractorMethod(
            string methodName,
            Type sourceType,
            Type targetType,
            PropertyMapping[] propertyNameMappings = null,
            Func<string, IEnumerable<string>, PropertyMapping[]> getContextDataPropertyMappings = null)
        {
            var sourceProperties = GetTypeProperties(sourceType);
            var targetProperties = GetTypeProperties(targetType);

            // If explicit propertyNameMappings are NOT supplied...
            if (propertyNameMappings == null)
            {
                // If property name mapping delegate is NOT supplied...
                if (getContextDataPropertyMappings == null)
                {
                    // ... autogenerate the mappings based on matching property names
                    propertyNameMappings =
                        (from s in sourceProperties
                            from t in targetProperties
                            where s.Key == t.Key
                            select new PropertyMapping(s.Key, t.Key))
                        .ToArray();
                }
                else
                {
                    // Build property mappings using supplied function
                    string entityFullName = $"{sourceType.GetCustomAttribute<SchemaAttribute>()?.Schema ?? "(Unknown Schema)"}.{sourceType.Name}";
                        
                    // Build the property mappings using the supplied lambda, eliminating any properties that aren't given a mapping
                    propertyNameMappings = getContextDataPropertyMappings(entityFullName, sourceProperties.Keys);
                    
                    ValidatePropertyMappings(
                        propertyNameMappings,
                        sourceType,
                        sourceProperties,
                        targetType,
                        targetProperties);
                }
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

            return CreateDelegate(methodName, sourceType, targetType, propertyNameMappings, sourceProperties,
                targetProperties);

            Dictionary<string, PropertyInfo> GetTypeProperties(Type type)
            {
                if (type.IsInterface)
                {
                    // Process the interface and the interfaces it implements directly (but not recursively)
                    return type.GetProperties().Concat(type.GetInterfaces().SelectMany(i => i.GetProperties()))
                        .ToDictionary(p => p.Name, p => p);
                }
                
                return type.GetProperties().ToDictionary(x => x.Name, x => x);
            }
        }

        private static ExtractDelegate CreateDelegate(
            string methodName,
            Type sourceType,
            Type targetType,
            PropertyMapping[] propertyNameMappings,
            Dictionary<string, PropertyInfo> sourceProperties,
            Dictionary<string, PropertyInfo> targetProperties)
        {
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
                    il.Emit(OpCodes.Newobj, targetProperty.PropertyType.GetConstructor([targetUnderlyingType]));

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
            EnsureNoMultipleMappingsToSameTargetProperty();
            EnsureNoMissingPropertiesInMappings();

            void EnsureNoMultipleMappingsToSameTargetProperty()
            {
                // Look for any attempts to map multiple source properties to the same target property
                var propertyMappingsByTargetPropertyName = propertyNameMappings.GroupBy(pm => pm.TargetPropertyName).ToArray();

                var multipleMappingsToTargetProperty = propertyMappingsByTargetPropertyName.Where(g => g.Count() > 1).ToArray();

                if (multipleMappingsToTargetProperty.Any())
                {
                    throw new ArgumentException(
                        $"More than one source property was mapped to the same target property '{multipleMappingsToTargetProperty.First().Key}'.",
                        nameof(propertyNameMappings));
                }
            }

            void EnsureNoMissingPropertiesInMappings()
            {
                // Look for missing members
                var missingSourceProperties = propertyNameMappings.Select(x => x.SourcePropertyName).Except(sourceProperties.Keys).ToList();

                var missingTargetProperties = propertyNameMappings.Select(x => x.TargetPropertyName).Except(targetProperties.Keys).ToList();

                var sb = new StringBuilder();

                if (missingSourceProperties.Any())
                {
                    string errorText = string.Join(Environment.NewLine, missingSourceProperties.Select(x => "    " + x));

                    sb.AppendLine(
                        $"The following properties were not found on the source type '{sourceType.FullName}':{Environment.NewLine}{errorText}");
                }

                if (missingTargetProperties.Any())
                {
                    string errorText = string.Join(Environment.NewLine, missingTargetProperties.Select(x => "    " + x));

                    sb.AppendLine(
                        $"The following properties were not found on the target type '{targetType.FullName}':{Environment.NewLine}{errorText}");
                }

                if (sb.Length > 0)
                {
                    throw new MissingMemberException($"The supplied property mappings were invalid.{Environment.NewLine}{sb}");
                }
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
