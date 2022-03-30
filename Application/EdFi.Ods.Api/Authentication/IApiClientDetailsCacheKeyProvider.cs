// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Authentication;

/// <summary>
/// Defines a method for building the cache key for caching the API client details for a particular token.
/// </summary>
public interface IApiClientDetailsCacheKeyProvider
{
    /// <summary>
    /// Gets the cache key to use for caching the supplied token.
    /// </summary>
    /// <param name="token">The API client's bearer token.</param>
    /// <returns>The cache key to use for the associated cache entry.</returns>
    string GetCacheKey(string token);
}
