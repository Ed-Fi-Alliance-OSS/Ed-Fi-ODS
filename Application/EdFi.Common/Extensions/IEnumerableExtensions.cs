// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Converts the provided enumerable collection into a read-only list, preserving read-only 
        /// semantics, but eliminating the need for downstream ".ToList()" calls to prevent possible 
        /// repeat enumerations of the source.
        /// </summary>
        /// <typeparam name="T">The collection's item type.</typeparam>
        /// <param name="enumerable">The source collection.</param>
        /// <returns>A read-only list.</returns>
        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList()
                             .AsReadOnly();
        }

        public static IEnumerable<T> InsertBefore<T>(
            this IEnumerable<T> source,
            T insertionPoint,
            T itemToInsert)
        {
            if (!source.Contains(insertionPoint))
            {
                throw new ArgumentException(
                    "Item could not be inserted because the insertion point item was not found in the collection.");
            }

            return source.TakeWhile(x => !x.Equals(insertionPoint))
                         .Concat(
                              new[]
                              {
                                  itemToInsert
                              })
                         .Concat(source.SkipWhile(x => !x.Equals(insertionPoint)));
        }

        public static IEnumerable<T> InsertAfter<T>(
            this IEnumerable<T> source,
            T insertionPoint,
            T itemToInsert)
        {
            if (!source.Contains(insertionPoint))
            {
                throw new ArgumentException(
                    "Item could not be inserted because the insertion point item was not found in the collection.");
            }

            if (source.Last()
                      .Equals(insertionPoint))
            {
                return source.Concat(
                    new[]
                    {
                        itemToInsert
                    });
            }

            return source.TakeWhile(x => !x.Equals(insertionPoint))
                         .Concat(
                              new[]
                              {
                                  insertionPoint, itemToInsert
                              })
                         .Concat(
                              source.SkipWhile(x => !x.Equals(insertionPoint))
                                    .Skip(1));
        }

        public static IEnumerable<T> InsertAtHead<T>(
            this IEnumerable<T> source,
            T itemToInsert)
        {
            yield return itemToInsert;

            foreach (var item in source)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> Concat<T>(
            this IEnumerable<T> source,
            T item)
        {
            return source.Concat(
                new[]
                {
                    item
                });
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T instance)
        {
            return source.Except(
                new[]
                {
                    instance
                });
        }

        /// <summary>
        /// Indicates whether all the items in the supplied sequence are the same value.
        /// </summary>
        /// <param name="values">The sequence to be evaluated.</param>
        /// <typeparam name="T">The type of values in the sequence.</typeparam>
        /// <returns><b>true</b> if all the values in the sequence are the same, or the sequence is empty; otherwise <b>false</b>.</returns>
        public static bool AllEqual<T>(this IEnumerable<T> values)
        {
            ArgumentNullException.ThrowIfNull(values);
            
            if (!values.Any())
                return true;
            
            T first = values.First();
            
            return values
                .Skip(1)
                .All(v => first.Equals(v));
        }

        /// <summary>
        /// Indicates whether all the strings in the supplied sequence are the same value.
        /// </summary>
        /// <param name="values">The sequence to be evaluated.</param>
        /// <param name="comparer">The <see cref="StringComparer" /> to use for the comparison (defaults to <see cref="StringComparer.Ordinal" />).</param>
        /// <returns><b>true</b> if all the values in the sequence are the same, or the sequence is empty; otherwise <b>false</b>.</returns>
        public static bool AllEqual(this IEnumerable<string> values, StringComparer comparer = null)
        {
            ArgumentNullException.ThrowIfNull(values);
            
            comparer ??= StringComparer.Ordinal;
            
            if (!values.Any())
                return true;
            
            string first = values.First();
            
            return values
                .Skip(1)
                .All(v => comparer.Equals(first, v));
        }

        /// <summary>
        /// Indicates whether the supplied value is the default value for its type.
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <typeparam name="T">The Type of the value.</typeparam>
        /// <returns><b>true</b> if the value is the default value for the type; otherwise <b>false</b>.</returns>
        public static bool IsDefaultValue<T>(this T value)
        {
            return value == null || value.Equals(default(T));
        }
    }
}
