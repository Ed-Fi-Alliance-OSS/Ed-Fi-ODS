// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;

namespace EdFi.Ods.Common.Context
{
    /// <summary>
    /// Provides context storage that is backed by a <see cref="Hashtable"/>.
    /// </summary>
    public class HashtableContextStorage : IContextStorage
    {
        /// <summary>
        /// Provides access to the underlying <see cref="Hashtable"/>.
        /// </summary>
        public Hashtable UnderlyingHashtable { get; } = new Hashtable();

        /// <summary>
        /// Saves a value using into context using the specified key.
        /// </summary>
        /// <param name="key">The key to use when storing/retrieving the value.</param>
        /// <param name="value">The value to be stored.</param>
        public void SetValue(string key, object value)
        {
            UnderlyingHashtable[key] = value;
        }

        /// <summary>
        /// Gets a value by key from context converted to the type specified by <see cref="T"/>, or the default value for the type if not present.
        /// </summary>
        /// <typeparam name="T">The data type to which the value should be converted.</typeparam>
        /// <param name="key">The key associated with the value to return.</param>
        /// <returns>The value from context if present; otherwise the default value for the type.</returns>
        public T GetValue<T>(string key)
        {
            return (T) (UnderlyingHashtable[key] ?? default(T));
        }
    }
}
