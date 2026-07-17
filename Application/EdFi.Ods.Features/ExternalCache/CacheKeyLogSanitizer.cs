// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Produces log-safe renderings of cache keys and of exceptions whose messages may embed cache keys.
/// </summary>
public static class CacheKeyLogSanitizer
{
    // Number of hex characters of the SHA-256 hash preserved for log correlation.
    private const int CorrelationHashChars = 8;

    // Matches an ApiClientDetails cache key embedded in free text (e.g. a StackExchange.Redis timeout
    // message such as "Timeout performing GET ApiClientDetails.<token>").
    private static readonly Regex _apiClientDetailsKeyRegex = new(
        Regex.Escape(ApiClientDetailsCacheKeyProvider.CacheKeyPrefix) + @"[^\s,'""]+",
        RegexOptions.Compiled);

    /// <summary>
    /// Returns a log-safe rendering of a cache key. For ApiClientDetails cache keys
    /// (<c>ApiClientDetails.&lt;token&gt;</c>) the embedded credential — a live OAuth access token — is replaced
    /// with a short one-way SHA-256 hash (e.g. <c>ApiClientDetails.&lt;hashed:1A2B3C4D&gt;</c>) so no portion of
    /// the token ever reaches the logs while hit/miss entries for the same token remain correlatable. All other
    /// keys (e.g. descriptor <see cref="ulong"/> ids and Person map-cache tuple keys) carry no secret and are
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

        return ApiClientDetailsCacheKeyProvider.CacheKeyPrefix + HashForCorrelation(token);
    }

    /// <summary>
    /// Returns a log-safe, single-line summary of an exception (type name and sanitized message, no stack
    /// trace) for expected, transient conditions logged at Warn — where a full stack trace per request during
    /// an outage adds noise rather than signal. Any embedded ApiClientDetails cache key is replaced with its
    /// one-way hash.
    /// </summary>
    /// <param name="ex">The exception to summarize.</param>
    public static string SanitizeExceptionMessageForLogging(Exception ex)
    {
        if (ex is null)
        {
            return "<null>";
        }

        return $"{ex.GetType().Name}: {RedactApiClientDetailsKeys(ex.Message)}";
    }

    /// <summary>
    /// Returns a log-safe rendering of an exception's full detail (type, message, stack trace and inner
    /// exceptions) with any embedded ApiClientDetails cache key replaced with its one-way hash. Used on Error
    /// paths where the stack trace matters.
    /// </summary>
    /// <param name="ex">The exception to render.</param>
    public static string SanitizeExceptionForLogging(Exception ex)
    {
        if (ex is null)
        {
            return "<null>";
        }

        return RedactApiClientDetailsKeys(ex.ToString());
    }

    private static string RedactApiClientDetailsKeys(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return _apiClientDetailsKeyRegex.Replace(
            text,
            match => ApiClientDetailsCacheKeyProvider.CacheKeyPrefix
                + HashForCorrelation(match.Value[ApiClientDetailsCacheKeyProvider.CacheKeyPrefix.Length..]));
    }

    private static string HashForCorrelation(string token)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(token));

        return $"<hashed:{Convert.ToHexString(hash)[..CorrelationHashChars]}>";
    }
}
