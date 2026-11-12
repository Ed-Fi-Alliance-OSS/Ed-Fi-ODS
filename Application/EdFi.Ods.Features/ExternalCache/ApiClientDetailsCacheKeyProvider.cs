// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Cryptography;
using System.Text;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Implements a cache key provider for caching API client details (for single-tenant deployments).
/// The token is hashed so that bearer tokens are never stored as plain text in the cache keys.
/// </summary>
public class ApiClientDetailsCacheKeyProvider : IApiClientDetailsCacheKeyProvider
{
    public const string CacheKeyPrefix = "ApiClientDetails.";

    /// <inheritdoc cref="IApiClientDetailsCacheKeyProvider.GetCacheKey" />
    public string GetCacheKey(string token)
    {
        return $"{CacheKeyPrefix}{HashToken(token)}";
    }

    /// <summary>
    /// Gets the hexadecimal SHA-256 hash of the supplied token.
    /// </summary>
    /// <param name="token">The API client's bearer token.</param>
    /// <returns>The hash of the token, as an upper-case hexadecimal string.</returns>
    internal static string HashToken(string token)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
    }
}
