// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Extensions
{
    public static class CollectionExtensions
    {
        private static readonly ConcurrentDictionary<Type, Type> _itemTypeByUnderlyingListType =
            new ConcurrentDictionary<Type, Type>();

        public static bool SynchronizeCollectionTo<T>(
            this ICollection<T> sourceList,
            ICollection<T> targetList,
            Action<T> onChildAdded,
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

            foreach (var item in itemsToAdd)
            {
                targetList.Add(item);

                onChildAdded?.Invoke(item);

                isModified = true;
            }

            return isModified;
        }

        public static void MapCollectionTo<TSource, TTarget>(
            this ICollection<TSource> sourceList,
            ICollection<TTarget> targetList,
            object parent = null)
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

            foreach (var sourceItem in sourceList.Distinct())
            {
                var targetItem = (TTarget) Activator.CreateInstance(itemType);

                if (parent != null)
                {
                    (targetItem as IChildEntity)?.SetParent(parent);
                }

                sourceItem.Map(targetItem);
                targetList.Add(targetItem);
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
#if NETFRAMEWORK
                type = listTypes[listTypes.Length - 1];
#else
                type = listTypes[^1];
#endif
                _itemTypeByUnderlyingListType[targetListType] = type;

                return type;
            }
        }
    }
}
