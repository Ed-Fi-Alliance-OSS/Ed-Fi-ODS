// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Exceptions;

namespace EdFi.Ods.Common.Extensions
{
    public static class CollectionExtensions
    {
        private static readonly ConcurrentDictionary<Type, Type> _itemTypeByUnderlyingListType = new();

        public static bool SynchronizeCollectionTo<T>(
            this ICollection<T> sourceList,
            ICollection<T> targetList,
            Action<T> onChildAdded,
            bool itemCreatable,
            Func<T, bool> includeItem = null)
            where T : ISynchronizable //<T>
        {
            var isModified = false;

            // Find items to delete
            var itemsToDelete =
                targetList.Where(ti => includeItem == null || includeItem(ti))
                    .Where(
                        ti => sourceList.Where(i => includeItem == null || includeItem(i))
                            .All(si => !si.Equals(ti)))
                    .ToList();

            foreach (var item in itemsToDelete)
            {
                // This statement causes failure in NHibernate when no version column is present.
                //  --> (item as IChildEntity).SetParent(null);
                targetList.Remove(item);
                isModified = true;
            }

            // Copy properties on existing items
            var itemsToUpdate = targetList
                .Where(i => includeItem == null || includeItem(i))
                .SelectMany(
                    p => sourceList.Where(i => includeItem == null || includeItem(i)), (p, s) => new
                    {
                        p,
                        s
                    })
                .Where(@t => @t.p.Equals(@t.s))
                .Select(
                    @t => new
                    {
                        Submitted = @t.s,
                        Persisted = @t.p
                    })
                .ToList();

            isModified = itemsToUpdate.Aggregate(
                isModified, (current, pair) => current | pair.Submitted.Synchronize(pair.Persisted));

            // Find items to add
            var itemsToAdd = sourceList
                .Where(i => includeItem == null || includeItem(i))
                .Except(targetList.Where(i => includeItem == null || includeItem(i)))
                .ToList();

            if (itemsToAdd.Any())
            {
                if (!itemCreatable)
                {
                    string profileName = GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;

                    throw new DataPolicyException(profileName, itemsToAdd.First().GetType().Name);
                }
                
                foreach (var item in itemsToAdd)
                {
                    targetList.Add(item);

                    onChildAdded?.Invoke(item);

                    isModified = true;
                }
            }

            return isModified;
        }

        public static void MapCollectionTo<TSource, TTarget>(
            this ICollection<TSource> sourceList,
            ICollection<TTarget> targetList,
            bool itemCreatable = true,
            object parent = null,
            Func<TSource, bool> isItemIncluded = null)
            where TSource : IMappable
        {
            if (sourceList == null)
            {
                return;
            }

            if (targetList == null)
            {
                return;
            }

            var targetListType = targetList.GetType();
            var itemType = GetItemType();
            
            bool isFirstItem = true;
            bool isDeserializable = false;

            foreach (var sourceItem in sourceList.Where(i => isItemIncluded == null || isItemIncluded(i)))
            {
                if (!itemCreatable)
                {
                    // Use context provider to note the potential Data Policy Exception here (which applies only if the resource
                    // is being created, otherwise the SynchronizeCollectionTo method to the existing entity will handle any
                    // data policy violations).
                    if (GeneratedArtifactStaticDependencies.DataPolicyExceptionContextProvider.Get() == null)
                    {
                        string profileName = GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        GeneratedArtifactStaticDependencies.DataPolicyExceptionContextProvider.Set(new DataPolicyException(profileName, itemType.Name));
                    }
                }
                
                IDeserializable deserializable = null;

                if (isFirstItem)
                {
                    isFirstItem = false;
                    deserializable = sourceItem as IDeserializable;
                    isDeserializable = (deserializable != null);
                }
                else if (isDeserializable)
                {
                    deserializable = sourceItem as IDeserializable;
                }

                if (isDeserializable && deserializable?.TryDeserialize(out TTarget targetItem) == true)
                {
                    targetList.Add(targetItem);
                }
                else
                {
                    // Create and map the item
                    var mappedTargetItem = (TTarget) Activator.CreateInstance(itemType);

                    if (parent != null)
                    {
                        (mappedTargetItem as IChildEntity)?.SetParent(parent);
                    }

                    sourceItem.Map(mappedTargetItem);
                    targetList.Add(mappedTargetItem);
                }
            }

            Type GetItemType()
            {
                if (_itemTypeByUnderlyingListType.TryGetValue(targetListType, out Type type))
                {
                    return type;
                }

                var listTypes = targetListType.GetGenericArguments();

                if (listTypes.Length == 0)
                {
                    throw new ArgumentException(
                        $"Target list type of '{targetListType.FullName}' does not have any generic arguments.");
                }

                // Assumption: ItemType is last generic argument (most of the time this will be a List<T>,
                // but it could be a CovariantIListAdapter<TBase, TDerived>.  We want the last generic argument type.
                 type = listTypes[^1];
                _itemTypeByUnderlyingListType[targetListType] = type;

                return type;
            }
        }
    }
}
