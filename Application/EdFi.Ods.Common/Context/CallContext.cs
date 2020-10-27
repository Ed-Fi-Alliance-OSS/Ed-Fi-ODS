// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Threading;

namespace EdFi.Ods.Common.Context
{
    /// <summary>
    /// Provides a way to set contextual data that flows with the call and
    /// async context of a test or invocation.
    /// </summary>
    public static class CallContext
    {
        private static readonly ConcurrentDictionary<string, AsyncLocal<object>> _state =
            new ConcurrentDictionary<string, AsyncLocal<object>>();

        /// <summary>
        /// Stores a given object and associates it with the specified name.
        /// </summary>
        /// <param name="name">The name with which to associate the new item in the call context.</param>
        /// <param name="data">The object to store in the call context.</param>
        public static void SetData(string name, object data)
        {
            var asyncLocal = _state.GetOrAdd(name, n => new AsyncLocal<object>());
            asyncLocal.Value = data;
        }

        /// <summary>
        /// Retrieves an object with the specified name from the <see cref="CallContext"/>.
        /// </summary>
        /// <param name="name">The name of the item in the call context.</param>
        /// <returns>The object in the call context associated with the specified name, or <see langword="null"/> if not found.</returns>
        public static object GetData(string name)
        {
            if (_state.TryGetValue(name, out AsyncLocal<object> data))
            {
                return data.Value;
            }

            return null;
        }
    }
}
