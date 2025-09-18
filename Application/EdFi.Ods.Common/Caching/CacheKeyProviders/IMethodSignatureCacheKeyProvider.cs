// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;

namespace EdFi.Ods.Common.Caching.CacheKeyProviders;

/// <summary>
/// Defines a contract for creating a unique cache key based on the method signature
/// and its arguments.
/// </summary>
public interface IMethodSignatureCacheKeyProvider
{
    /// <summary>
    /// Generates a unique cache key based on the provided method information and arguments.
    /// </summary>
    /// <param name="method">The method information for which the cache key is being generated.</param>
    /// <param name="args">The arguments of the method used in generating the cache key.</param>
    /// <returns>A unique 64-bit integer representing the cache key for the method and its arguments.</returns>
    ulong GetKey(MethodInfo method, object[] args);
}
