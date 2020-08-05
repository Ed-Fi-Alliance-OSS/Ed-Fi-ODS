// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using EdFi.Ods.Common.Conventions;

namespace EdFi.Ods.Common.Extensions
{
    /// <summary>
    /// Extension methods created to support the operations on the IHasExtensions interface
    /// </summary>
    public static class IHasExtensionsExtensions
    {
        private static readonly ConcurrentDictionary<ExtensionKey, Type> _extensionTypeByExtensionKey
            = new ConcurrentDictionary<ExtensionKey, Type>();

        public static Func<Type, string, object> CreateTargetExtensionObject = DoCreateTargetExtensionObject;

        private static object DoCreateTargetExtensionObject(Type targetType, string extensionName)
        {
            // Get target extension type
            var targetExtensionType = _extensionTypeByExtensionKey.GetOrAdd(
                new ExtensionKey(targetType, extensionName),
                key =>
                {
                    string assemblyQualifiedName =
                        ExtensionsConventions.GetExtensionClassAssemblyQualifiedName(key.EdFiStandardType, key.ExtensionName);

                    return Type.GetType(assemblyQualifiedName);
                });

            // Create the target extension object
            return targetExtensionType != null
                ? Activator.CreateInstance(targetExtensionType)
                : null;
        }

        /// <summary>
        /// Extension method to support the Synchronization operation on extensions
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SynchronizeExtensionsTo<TSource, TTarget>(this TSource source, TTarget target)
            where TSource : ISynchronizable, IHasExtensions
            where TTarget : IHasExtensions
        {
            if (source == null || source.Extensions == null)
            {
                return false;
            }

            if (target == null || target.Extensions == null)
            {
                return false;
            }

            bool isModified = false;

            var sourceSynchSupport = source as IExtensionsSynchronizationSourceSupport;

            if (sourceSynchSupport == null)
            {
                throw new Exception(
                    $"The source type '{source.GetType().FullName}' does not implement the {typeof(IExtensionsSynchronizationSourceSupport).Name} interface which is required for synchronizing extensions.");
            }

            // Iterate through the target's extensions
            foreach (string extensionName in target.Extensions.Keys)
            {
                // If the source contains the extension and it is supported as a source for synchronization
                if (sourceSynchSupport.IsExtensionSupported(extensionName))
                {
                    if (!source.Extensions.Contains(extensionName))
                    {
                        throw new Exception(
                            $"The extension '{extensionName}' is supported as a synchronization source but the extension was not provided.");
                    }

                    // Get the source extension object
                    var sourceExtensionObjectList = source.Extensions[extensionName] as IList;

                    if (sourceExtensionObjectList == null)
                    {
                        throw new Exception($"Synchronization source extension '{extensionName}' was not an IList implementation.");
                    }

                    var sourceExtensionObject = sourceExtensionObjectList[0] as ISynchronizable;

                    if (sourceExtensionObject == null)
                    {
                        object obj = source.Extensions[extensionName];

                        throw new Exception(
                            $"The source entity extension type '{obj.GetType().FullName}' does not implement the {typeof(ISynchronizable).Name} interface which is required for synchronizing extensions.");
                    }

                    // Get the target extension object (always an NHibernate persistent bag)
                    var targetExtensionObjectList = target.Extensions[extensionName] as IList;

                    if (targetExtensionObjectList == null)
                    {
                        throw new Exception($"Synchronization target extension '{extensionName}' was not an IList implementation.");
                    }

                    ISynchronizable targetExtensionObject;

                    // Is there an extension object in the bag?
                    if (targetExtensionObjectList.Count == 0)
                    {
                        // No target extensions object yet exists in the persistent list (i.e. it's not a required extension)
                        // Create it now based on the source extension object type (synchronization always happens between NHibernate entities)
                        // ... and add it to the list
                        targetExtensionObject = (ISynchronizable) Activator.CreateInstance(sourceExtensionObject.GetType());
                        targetExtensionObjectList.Add(targetExtensionObject);
                        ((IChildEntity) targetExtensionObject).SetParent(target);
                    }
                    else
                    {
                        // Get the existing target extensions object (i.e. it's a required extension object, which is created when the entity in instantiated)
                        targetExtensionObject = targetExtensionObjectList[0] as ISynchronizable;
                    }

                    if (targetExtensionObject == null)
                    {
                        object obj = targetExtensionObjectList[0];

                        throw new Exception(
                            $"The target entity extension type '{obj.GetType().FullName}' does not implement the {typeof(ISynchronizable).Name} interface which is required for synchronizing extensions.");
                    }

                    // Synchronize the extension object to the target extension object
                    isModified |= sourceExtensionObject.Synchronize(targetExtensionObject);
                }
            }

            return isModified;
        }

        /// <summary>
        /// Extension method to support the Mapping operation on extensions
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void MapExtensionsTo<TSource, TTarget>(this TSource source, TTarget target)
            where TSource : IMappable, IHasExtensions
            where TTarget : IHasExtensions
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            // If source has no extensions present, don't map anything and leave target in its initialized state
            if (source.Extensions == null)
            {
                return;
            }

            var sourceSynchSupport = source as IExtensionsSynchronizationSourceSupport;

            if (sourceSynchSupport == null)
            {
                throw new ArgumentException(
                    $"The source type '{source.GetType().FullName}' does not implement the {nameof(IExtensionsSynchronizationSourceSupport)} interface and cannot be mapped.");
            }

            var targetSynchSupport = target as IExtensionsSynchronizationSourceSupport;

            if (targetSynchSupport == null)
            {
                throw new ArgumentException(
                    $"The target type '{target.GetType().FullName}' does not implement the {nameof(IExtensionsSynchronizationSourceSupport)} interface and cannot be mapped.");
            }

            // Get all the extensions present in the source object
            //   For entities, this will be all the extensions loaded from the ODS
            //   For resources, this will be all the extensions submitted by the API client
            string[] extensionNames = new string[source.Extensions.Count];
            source.Extensions.Keys.CopyTo(extensionNames, 0);

            // Process extensions alphabetically from source to target
            foreach (string extensionName in extensionNames.OrderBy(x => x))
            {
                // If the extension isn't supported by the source, don't map it.
                //   For entities, all extensions present will be supported.
                //   For non-profile constrained resources, all extensions will be supported.
                //   For profile constrained resources, some extensions may not be supported.
                if (!sourceSynchSupport.IsExtensionSupported(extensionName))
                {
                    targetSynchSupport.SetExtensionSupported(extensionName, false);
                    continue;
                }

                // Mark the extension as available on the target
                targetSynchSupport.SetExtensionAvailable(extensionName, true);

                // Identify the source extension instance
                var sourceExtensionObject = GetMappableSourceExtensionObject(source, extensionName);

                // If no source extension object is present, do not instantiate and map the corresponding target.
                if (sourceExtensionObject == null)
                {
                    // This logic is used when mapping resources to transient entities to prevent subsequent
                    // synchronization against the persistent entity data
                    targetSynchSupport.SetExtensionSupported(extensionName, false);
                    continue;
                }

                // If the source entity extension is an implicit entity extension and it is empty, don't map for outbound serialization
                if ((sourceExtensionObject as IImplicitEntityExtension)?.IsEmpty() == true)
                    continue;

                // Identify the target extension instance
                //   For entities, this will force the API client-supplied extension in the resource to match to a known/registered entity extension type
                //   For resources, this will instantiate the appropriate resource extension loaded from the database.
                var targetExtensionObject = GetMappableTargetExtensionObject(target, extensionName);

                if (targetExtensionObject == null)
                {
                    continue;
                }

                // Map the extension objects
                sourceExtensionObject.Map(targetExtensionObject);

                // Set the parent back-reference (relevant only for entity extension classes)
                var targetExtensionObjectAsChildEntity = targetExtensionObject as IChildEntity;
                targetExtensionObjectAsChildEntity?.SetParent(target);

                // Wrap entities in a collection for persistence/mapping concerns
                // (This is only relevant for entities - we use implementation of the IHasPrimaryKeyValues interface to identify them)
                var targetExtensionObjectAsEntity = targetExtensionObject as IHasPrimaryKeyValues;

                if (targetExtensionObjectAsEntity != null)
                {
                    targetExtensionObject = new List<object> {targetExtensionObjectAsEntity};
                }

                // Resources don't have Extensions until they need them (initialized to null),
                // so initialize with an OrderedDictionary to maintain consistent JSON serialization order of multiple extensions
                if (target.Extensions == null)
                {
                    target.Extensions = new OrderedDictionary();
                }

                target.Extensions[extensionName] = targetExtensionObject;

                // Indicate that the extension is supported
                //   For entities, this will allow the transient entity just mapped to have the extension data subsequently synchronized to the persistent entity
                //   For resources, this will do nothing (resource implementations of this method is empty).
                targetSynchSupport.SetExtensionSupported(extensionName, true);
            }
        }

        private static IMappable GetMappableSourceExtensionObject<TSource>(TSource source, string extensionName)
            where TSource : IMappable, IHasExtensions
        {
            IMappable mappableSourceObject;

            // Get the source extension object
            var sourceExtensionsObject = source.Extensions[extensionName];

            // Support unwrapping a mapped collection into the extensions object
            var sourceExtensionsObjectAsList = sourceExtensionsObject as IList;

            if (sourceExtensionsObjectAsList != null)
            {
                // Extension exists for source but has nothing set, this is an error condition
                if (sourceExtensionsObjectAsList.Count == 0)
                    return null;

                mappableSourceObject = sourceExtensionsObjectAsList[0] as IMappable;
            }
            else
            {
                mappableSourceObject = sourceExtensionsObject as IMappable;
            }

            if (mappableSourceObject == null)
            {
                object obj = sourceExtensionsObjectAsList != null
                    ? sourceExtensionsObjectAsList[0]
                    : sourceExtensionsObject;

                throw new Exception(
                    $"The source extension '{obj.GetType()}' does not implement the {nameof(IMappable)} interface and so no source entity could be found for mapping.");
            }

            return mappableSourceObject;
        }

        private static object GetMappableTargetExtensionObject<TTarget>(TTarget target, string extensionName)
            where TTarget : IHasExtensions
        {
            Type targetType = target.GetType();
            var targetObject = CreateTargetExtensionObject(targetType, extensionName);

            // Set the parent for entities
            (targetObject as IChildEntity)?.SetParent(target);

            return targetObject;
        }

        private struct ExtensionKey
        {
            public ExtensionKey(Type edFiStandardType, string extensionName)
            {
                EdFiStandardType = edFiStandardType;
                ExtensionName = extensionName;
            }

            public Type EdFiStandardType { get; }

            public string ExtensionName { get; }
        }
    }
}
