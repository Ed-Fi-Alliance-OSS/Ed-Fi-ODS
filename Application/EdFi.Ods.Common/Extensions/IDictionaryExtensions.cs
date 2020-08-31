// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets a value from a dictionary based on the specified key, or throws a standardized
        /// or custom exception message indicating the missing key value.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> of the key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the values.</typeparam>
        /// <param name="dictionary">The dictionary containing the value being requested.</param>
        /// <param name="key">The key identifying the value to be retrieved.</param>
        /// <param name="messageFormat">An optional exception message format specifier where the
        /// requested key value will automatically be supplied as the '{0}' parameter.</param>
        /// <param name="args">Optional additional arguments for a custom format specifier on the
        /// exception message, starting with argument '{1}'.</param>
        /// <returns>The value for the supplied key if it exists.</returns>
        /// <remarks>Generally it is considered to be a more secure development practice to
        /// not reveal potentially sensistive information in error messages, and this is why
        /// the .NET Dictionary implementation does not provide this in the exception message
        /// when a key is not found. However, there are times when the information contained
        /// is not sensitive and supplying the key or additional details in the exception message
        /// are helpful. It is for this usage scenario that this method exists. Please use it responsibly.</remarks>
        public static TValue GetValueOrThrow<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey key,
            string messageFormat = null,
            params object[] args)
        {
            return (dictionary as IReadOnlyDictionary<TKey, TValue>)
               .GetValueOrThrow(key, messageFormat, args);
        }

        /// <summary>
        /// Gets the value of the entry for the specified key, or the default value for the type if not found.
        /// </summary>
        /// <typeparam name="TKey">The Type used as the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">The Type of values stored in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The value of the key for the item to be retrieved.</param>
        /// <returns>The value of the entry for the specified key, or the default value for the type if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key)
        {
            TValue value;

            if (!source.TryGetValue(key, out value))
            {
                return default(TValue);
            }

            return value;
        }

        /// <summary>
        /// Gets the value of the entry for the specified key, or the supplied "default" value if not found.
        /// </summary>
        /// <typeparam name="TKey">The Type used as the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">The Type of values stored in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The value of the key for the item to be retrieved.</param>
        /// <param name="defaultValue">The default value to be returned if the entry is not present.</param>
        /// <returns>The value of the entry for the specified key, or the default value for the type if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue value;

            if (!source.TryGetValue(key, out value))
            {
                return defaultValue;
            }

            return value;
        }
    }

    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Gets a value from a dictionary based on the specified key, or throws a standardized
        /// or custom exception message indicating the missing key value.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> of the key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the values.</typeparam>
        /// <param name="dictionary">The dictionary containing the value being requested.</param>
        /// <param name="key">The key identifying the value to be retrieved.</param>
        /// <param name="messageFormat">An optional exception message format specifier where the
        /// requested key value will automatically be supplied as the '{0}' parameter.</param>
        /// <param name="args">Optional additional arguments for a custom format specifier on the
        /// exception message, starting with argument '{1}'.</param>
        /// <returns>The value for the supplied key if it exists.</returns>
        /// <remarks>Generally it is considered to be a more secure development practice to
        /// not reveal potentially sensistive information in error messages, and this is why
        /// the .NET Dictionary implementation does not provide this in the exception message
        /// when a key is not found. However, there are times when the information contained
        /// is not sensitive and supplying the key or additional details in the exception message
        /// are helpful. It is for this usage scenario that this method exists. Please use it responsibly.</remarks>
        public static TValue GetValueOrThrow<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            string messageFormat = null,
            params object[] args)
        {
            return (dictionary as IReadOnlyDictionary<TKey, TValue>)
               .GetValueOrThrow(key, messageFormat, args);
        }

        /// <summary>
        /// Gets the value of the entry for the specified key, or the default value for the type if not found.
        /// </summary>
        /// <typeparam name="TKey">The Type used as the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">The Type of values stored in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The value of the key for the item to be retrieved.</param>
        /// <returns>The value of the entry for the specified key, or the default value for the type if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            TValue value;

            if (!source.TryGetValue(key, out value))
            {
                return default(TValue);
            }

            return value;
        }

        /// <summary>
        /// Gets the value of the entry for the specified key, or the supplied "default" value if not found.
        /// </summary>
        /// <typeparam name="TKey">The Type used as the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">The Type of values stored in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The value of the key for the item to be retrieved.</param>
        /// <param name="defaultValue">The default value to be returned if the entry is not present.</param>
        /// <returns>The value of the entry for the specified key, or the default value for the type if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue value;

            if (!source.TryGetValue(key, out value))
            {
                return defaultValue;
            }

            return value;
        }
    }

    public static class IReadOnlyDictionaryExtensions
    {
        /// <summary>
        /// Gets a value from a dictionary based on the specified key, or throws a standardized
        /// or custom exception message indicating the missing key value.
        /// </summary>
        /// <typeparam name="TKey">The <see cref="Type"/> of the key.</typeparam>
        /// <typeparam name="TValue">The <see cref="Type"/> of the values.</typeparam>
        /// <param name="dictionary">The dictionary containing the value being requested.</param>
        /// <param name="key">The key identifying the value to be retrieved.</param>
        /// <param name="messageFormat">An optional exception message format specifier where the
        /// requested key value will automatically be supplied as the '{0}' parameter.</param>
        /// <param name="args">Optional additional arguments for a custom format specifier on the
        /// exception message, starting with argument '{1}'.</param>
        /// <returns>The value for the supplied key if it exists.</returns>
        /// <remarks>Generally it is considered to be a more secure development practice to
        /// not reveal potentially sensistive information in error messages, and this is why
        /// the .NET Dictionary implementation does not provide this in the exception message
        /// when a key is not found. However, there are times when the information contained
        /// is not sensitive and supplying the key or additional details in the exception message
        /// are helpful. It is for this usage scenario that this method exists. Please use it responsibly.</remarks>
        public static TValue GetValueOrThrow<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key,
            string messageFormat = null,
            params object[] args)
        {
            TValue value;

            if (!dictionary.TryGetValue(key, out value))
            {
                var combinedArgs = new List<object>();
                combinedArgs.Add(key);
                combinedArgs.AddRange(args);

                throw new KeyNotFoundException(
                    string.Format(
                        messageFormat ?? "The key '{0}' could not be found in the dictionary.",
                        combinedArgs.ToArray()));
            }

            return value;
        }

#if NETSTANDARD2_0 || NETFRAMEWORK
        /// <summary>
        /// Gets the value of the entry for the specified key, or the default value for the type if not found.
        /// </summary>
        /// <typeparam name="TKey">The Type used as the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">The Type of values stored in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The value of the key for the item to be retrieved.</param>
        /// <returns>The value of the entry for the specified key, or the default value for the type if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, TKey key)
        {
            TValue value;

            if (!source.TryGetValue(key, out value))
            {
                return default(TValue);
            }

            return value;
        }

        /// <summary>
        /// Gets the value of the entry for the specified key, or the supplied "default" value if not found.
        /// </summary>
        /// <typeparam name="TKey">The Type used as the key in the dictionary.</typeparam>
        /// <typeparam name="TValue">The Type of values stored in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The value of the key for the item to be retrieved.</param>
        /// <param name="defaultValue">The default value to be returned if the entry is not present.</param>
        /// <returns>The value of the entry for the specified key, or the default value for the type if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue value;

            if (!source.TryGetValue(key, out value))
            {
                return defaultValue;
            }

            return value;
        }
#endif
    }
}
