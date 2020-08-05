// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Extensions
{
    public static class CollectionExtensions
    {
        private static readonly ConcurrentDictionary<Type, Type> _itemTypeByUnderlyingListType = new ConcurrentDictionary<Type, Type>();

        public static bool SynchronizeCollectionTo<T>(
            this ICollection<T> sourceList,
            ICollection<T> targetList,
            Action<T> onChildAdded,
            Func<T, bool> includeItem = null)
            where T : ISynchronizable //<T>
        {
            bool isModified = false;

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
            var itemsToUpdate =
                (from p in targetList.Where(i => includeItem == null || includeItem(i))
                 from s in sourceList.Where(i => includeItem == null || includeItem(i))
                 where p.Equals(s)
                 select new
                        {
                            Submitted = s, Persisted = p
                        })
               .ToList();

            foreach (var pair in itemsToUpdate)
            {
                isModified |= pair.Submitted.Synchronize(pair.Persisted);
            }

            // Find items to add
            var itemsToAdd =
                sourceList.Where(i => includeItem == null || includeItem(i))
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
            var itemType = GetItemType(targetListType);

            foreach (var sourceItem in sourceList.Distinct())
            {
                var targetItem = (TTarget) Activator.CreateInstance(itemType);

                if (parent != null)
                    (targetItem as IChildEntity)?.SetParent(parent);

                sourceItem.Map(targetItem);
                targetList.Add(targetItem);
            }
        }

        private static Type GetItemType(Type targetListType)
        {
            Type itemType;

            if (!_itemTypeByUnderlyingListType.TryGetValue(targetListType, out itemType))
            {
                var listTypes = targetListType.GetGenericArguments();

                if (listTypes.Length == 0)
                {
                    throw new ArgumentException(
                        string.Format("Target list type of '{0}' does not have any generic arguments.", targetListType.FullName));
                }

                // Assumption: ItemType is last generic argument (most of the time this will be a List<T>, 
                // but it could be a CovariantIListAdapter<TBase, TDerived>.  We want the last generic argument type.
                itemType = listTypes[listTypes.Length - 1];
                _itemTypeByUnderlyingListType[targetListType] = itemType;
            }

            return itemType;
        }
    }
}
