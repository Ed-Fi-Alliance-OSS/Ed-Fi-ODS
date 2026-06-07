// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Exceptions;
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
public class AsyncExternalCacheProvider<TKey>(
    IDistributedCache distributedCache,
    TimeSpan slidingExpiration,
    TimeSpan absoluteExpiration) : IAsyncCacheProvider<TKey>
{
    private const string DefaultExceptionMessage = "Unable to access distributed cache.";

    private readonly IDistributedCache _distributedCache = distributedCache;
    private readonly TimeSpan _absoluteExpiration = absoluteExpiration;
    private readonly TimeSpan _slidingExpiration = slidingExpiration;
    private readonly ILog _logger = LogManager.GetLogger(typeof(AsyncExternalCacheProvider<TKey>));

    /// <inheritdoc />
    public async Task<(bool found, object value)> TryGetCachedObjectAsync(TKey key)
    {
        try
        {
            var keyAsString = GetKeyAsString(key);
            var cachedValue = await _distributedCache.GetStringAsync(keyAsString).ConfigureAwait(false);

            if (string.IsNullOrEmpty(cachedValue))
            {
                return (false, null);
            }

            object value = keyAsString.StartsWith(ApiClientDetailsCacheKeyProvider.CacheKeyPrefix, StringComparison.Ordinal)
                ? JsonConvert.DeserializeObject<ApiClientDetails>(cachedValue)
                : ExternalCacheSerializationHelper.Deserialize(cachedValue, _logger);

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
        try
        {
            await _distributedCache.SetStringAsync(
                    GetKeyAsString(key),
                    ExternalCacheSerializationHelper.Serialize(obj),
                    CreateDistributedCacheEntryOptions())
                .ConfigureAwait(false);
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
        try
        {
            await _distributedCache.SetStringAsync(
                    GetKeyAsString(key),
                    ExternalCacheSerializationHelper.Serialize(value),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpiration = absoluteExpiration < DateTime.MaxValue ? absoluteExpiration : null,
                        SlidingExpiration = slidingExpiration > TimeSpan.Zero ? slidingExpiration : null
                    })
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new DistributedCacheException(DefaultExceptionMessage, ex);
        }
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
