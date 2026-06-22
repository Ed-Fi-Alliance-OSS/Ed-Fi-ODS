// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Produces log-safe renderings of cache keys.
/// </summary>
internal static class CacheKeyLogSanitizer
{
    /// <summary>
    /// Returns a log-safe rendering of a cache key, redacting the API client credential embedded in
    /// ApiClientDetails cache keys (<c>ApiClientDetails.&lt;apiClientKey&gt;</c>) so it never reaches the logs.
    /// Non-string keys (e.g. descriptor <see cref="ulong"/> ids and Person map-cache tuple keys) carry no
    /// secret and are rendered with <see cref="object.ToString"/>.
    /// </summary>
    /// <param name="key">The cache key to render.</param>
    public static string Redact(object key)
    {
        if (key is null)
        {
            return "<null>";
        }

        return key is string s && s.StartsWith(ApiClientDetailsCacheKeyProvider.CacheKeyPrefix, StringComparison.Ordinal)
            ? ApiClientDetailsCacheKeyProvider.CacheKeyPrefix + "<redacted>"
            : key.ToString();
    }
}
