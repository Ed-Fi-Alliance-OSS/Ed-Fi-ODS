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
    // Number of trailing token characters preserved for correlation; the rest is replaced with the marker.
    private const int VisibleTokenChars = 6;
    private const string RedactionMarker = "xxxxxx";

    /// <summary>
    /// Returns a log-safe rendering of a cache key. For ApiClientDetails cache keys
    /// (<c>ApiClientDetails.&lt;apiClientKey&gt;</c>) the embedded API client credential is replaced with a
    /// redaction marker, preserving only the last few characters for correlation
    /// (e.g. <c>ApiClientDetails.xxxxxx7f3a9c</c>) so the full token never reaches the logs. All other keys
    /// (e.g. descriptor <see cref="ulong"/> ids and Person map-cache tuple keys) carry no secret and are
    /// rendered with <see cref="object.ToString"/>.
    /// </summary>
    /// <param name="key">The cache key to render.</param>
    public static string SanitizeKeyForLogging(object key)
    {
        if (key is null)
        {
            return "<null>";
        }

        if (key is not string s || !s.StartsWith(ApiClientDetailsCacheKeyProvider.CacheKeyPrefix, StringComparison.Ordinal))
        {
            return key.ToString();
        }

        string token = s[ApiClientDetailsCacheKeyProvider.CacheKeyPrefix.Length..];

        string tail = token.Length > VisibleTokenChars
            ? token[^VisibleTokenChars..]
            : string.Empty;

        return ApiClientDetailsCacheKeyProvider.CacheKeyPrefix + RedactionMarker + tail;
    }
}
