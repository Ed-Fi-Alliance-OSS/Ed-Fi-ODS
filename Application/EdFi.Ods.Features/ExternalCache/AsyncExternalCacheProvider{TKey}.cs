// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Features.ExternalCache.Redis;
using log4net;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Implements asynchronous distributed cache access for external cache entries.
/// </summary>
/// <typeparam name="TKey">The type of cache key.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="AsyncExternalCacheProvider{TKey}"/> class.
/// </remarks>
/// <param name="distributedCache">The distributed cache.</param>
/// <param name="slidingExpiration">The sliding expiration to apply to set operations.</param>
/// <param name="absoluteExpiration">The absolute expiration to apply to set operations.</param>
/// <param name="resilience">The resilience pipeline for Redis operations, or <c>null</c> to call the cache directly.</param>
public class AsyncExternalCacheProvider<TKey>(
    IDistributedCache distributedCache,
    TimeSpan slidingExpiration,
    TimeSpan absoluteExpiration,
    RedisCacheResilience resilience = null) : IAsyncCacheProvider<TKey>, ICacheProvider<TKey>
{
    private const string DefaultExceptionMessage = "Unable to access distributed cache.";

    private readonly IDistributedCache _distributedCache = distributedCache;
    private readonly TimeSpan _absoluteExpiration = absoluteExpiration;
    private readonly TimeSpan _slidingExpiration = slidingExpiration;
    private readonly RedisCacheResilience _resilience = resilience;
    private readonly ILog _logger = LogManager.GetLogger(typeof(AsyncExternalCacheProvider<TKey>));

    /// <inheritdoc />
    public async Task<(bool found, object value)> TryGetCachedObjectAsync(TKey key)
    {
        try
        {
            var keyAsString = GetKeyAsString(key);
            var cachedValue = await ExecuteGetAsync(keyAsString).ConfigureAwait(false);

            if (string.IsNullOrEmpty(cachedValue))
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"[External] Distributed (L2) cache miss for key '{keyAsString}'.");
                }

                return (false, null);
            }

            object value = keyAsString.StartsWith(ApiClientDetailsCacheKeyProvider.CacheKeyPrefix, StringComparison.Ordinal)
                ? JsonConvert.DeserializeObject<ApiClientDetails>(cachedValue)
                : ExternalCacheSerializationHelper.Deserialize(cachedValue, _logger);

            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"[External] Distributed (L2) cache hit for key '{keyAsString}'.");
            }

            return (true, value);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            return (false, null);
        }
    }

    /// <inheritdoc />
    public async Task SetCachedObjectAsync(TKey key, object obj)
    {
        var keyAsString = GetKeyAsString(key);

        try
        {
            await ExecuteSetAsync(
                    keyAsString,
                    ExternalCacheSerializationHelper.Serialize(obj),
                    CreateDistributedCacheEntryOptions())
                .ConfigureAwait(false);
        }
        catch (Exception ex) when (DistributedCacheAvailability.IsUnavailable(ex))
        {
            // A failed cache write must not fail the request — skip caching when the cache is
            // temporarily unavailable (open circuit breaker or Redis connectivity failure).
            _logger.Warn($"Distributed cache unavailable; skipping cache write for key '{keyAsString}'.", ex);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new DistributedCacheException(DefaultExceptionMessage, ex);
        }
    }

    /// <inheritdoc />
    public async Task InsertAsync(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
    {
        var keyAsString = GetKeyAsString(key);

        try
        {
            await ExecuteSetAsync(
                    keyAsString,
                    ExternalCacheSerializationHelper.Serialize(value),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpiration = absoluteExpiration < DateTime.MaxValue ? absoluteExpiration : null,
                        SlidingExpiration = slidingExpiration > TimeSpan.Zero ? slidingExpiration : null
                    })
                .ConfigureAwait(false);
        }
        catch (Exception ex) when (DistributedCacheAvailability.IsUnavailable(ex))
        {
            _logger.Warn($"Distributed cache unavailable; skipping cache write for key '{keyAsString}'.", ex);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new DistributedCacheException(DefaultExceptionMessage, ex);
        }
    }

    // Runs the distributed-cache read through the Redis circuit breaker when resilience is configured,
    // so repeated failures fail fast once the circuit opens instead of blocking on the full timeout.
    private async Task<string> ExecuteGetAsync(string keyAsString)
    {
        if (_resilience is null)
        {
            return await _distributedCache.GetStringAsync(keyAsString).ConfigureAwait(false);
        }

        return await _resilience.Pipeline.ExecuteAsync(
                async _ => await _distributedCache.GetStringAsync(keyAsString).ConfigureAwait(false),
                CancellationToken.None)
            .ConfigureAwait(false);
    }

    private async Task ExecuteSetAsync(string keyAsString, string serializedValue, DistributedCacheEntryOptions options)
    {
        if (_resilience is null)
        {
            await _distributedCache.SetStringAsync(keyAsString, serializedValue, options).ConfigureAwait(false);
            return;
        }

        await _resilience.Pipeline.ExecuteAsync(
                async _ => await _distributedCache.SetStringAsync(keyAsString, serializedValue, options).ConfigureAwait(false),
                CancellationToken.None)
            .ConfigureAwait(false);
    }

    // ICacheProvider<TKey> is implemented so a single instance can be registered as BOTH the synchronous
    // and asynchronous cache provider. The AsyncCachingInterceptor uses a reference-equality check between
    // its sync and async providers to skip the blocking synchronous path (see AsyncCachingInterceptor.cs);
    // registering the same instance for both interfaces enables external-only (no L1) caching without a
    // blocking Redis call on the hot path. These synchronous members are therefore not expected to be
    // invoked on that path; they delegate to the asynchronous implementations for correctness if used.

    bool ICacheProvider<TKey>.TryGetCachedObject(TKey key, out object value)
    {
        (bool found, object cachedValue) = TryGetCachedObjectAsync(key).GetAwaiter().GetResult();
        value = cachedValue;
        return found;
    }

    void ICacheProvider<TKey>.SetCachedObject(TKey key, object obj)
    {
        SetCachedObjectAsync(key, obj).GetAwaiter().GetResult();
    }

    void ICacheProvider<TKey>.Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
    {
        InsertAsync(key, value, absoluteExpiration, slidingExpiration).GetAwaiter().GetResult();
    }

    private static string GetKeyAsString(TKey key)
    {
        return key is IFormattable formattable
            ? formattable.ToString(null, CultureInfo.InvariantCulture)
            : key.ToString();
    }

    private DistributedCacheEntryOptions CreateDistributedCacheEntryOptions()
    {
        return new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = _absoluteExpiration > TimeSpan.Zero ? _absoluteExpiration : null,
            SlidingExpiration = _slidingExpiration > TimeSpan.Zero ? _slidingExpiration : null
        };
    }

    private static class ExternalCacheSerializationHelper
    {
        private const string GuidPrefix = "(Guid)";
        private const string IntPrefix = "(int)";

        private static readonly JsonSerializerSettings DefaultSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string Serialize(object @object)
        {
            if (@object is Guid guid)
            {
                return $"{GuidPrefix}{guid.ToString("N", CultureInfo.InvariantCulture)}";
            }

            if (@object is int @int)
            {
                return $"{IntPrefix}{@int.ToString(CultureInfo.InvariantCulture)}";
            }

            return JsonConvert.SerializeObject(@object, DefaultSerializerSettings);
        }

        public static object Deserialize(string value, ILog logger)
        {
            if (value.StartsWith(GuidPrefix, StringComparison.InvariantCulture)
                && Guid.TryParse(value[GuidPrefix.Length..], out var guid))
            {
                return guid;
            }

            if (value.StartsWith(IntPrefix, StringComparison.InvariantCulture)
                && int.TryParse(value[IntPrefix.Length..], out var @int))
            {
                return @int;
            }

            try
            {
                return JsonConvert.DeserializeObject<DescriptorMaps>(value, DefaultSerializerSettings);
            }
            catch (JsonException e)
            {
                logger.Warn($"Exception during deserialization of the string \"{value}\". Message: \"{e.Message}\"");
                return null;
            }
        }
    }
}
