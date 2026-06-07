// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Features.ExternalCache;

/// <summary>
/// Provides a two-tier cache with a short-lived in-process L1 cache in front of a distributed L2 cache.
/// </summary>
/// <typeparam name="TKey">The type of the cache key.</typeparam>
public class TieredCacheProvider<TKey> : ICacheProvider<TKey>, IAsyncCacheProvider<TKey>, IClearable
{
    private static readonly object NullValue = new();

    private readonly IMemoryCache _memoryCache;
    private readonly ICacheProvider<TKey> _distributedCacheProvider;
    private readonly IAsyncCacheProvider<TKey> _asyncDistributedCacheProvider;
    private readonly TimeSpan _l1CacheDuration;
    private readonly object _clearSync = new();
    private CancellationTokenSource _clearTokenSource = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="TieredCacheProvider{TKey}"/> class.
    /// </summary>
    /// <param name="memoryCache">The in-process L1 cache.</param>
    /// <param name="distributedCacheProvider">The distributed L2 cache provider.</param>
    /// <param name="l1CacheDuration">The duration for L1 cache entries.</param>
    public TieredCacheProvider(
        IMemoryCache memoryCache,
        ICacheProvider<TKey> distributedCacheProvider,
        TimeSpan l1CacheDuration)
        : this(memoryCache, distributedCacheProvider, l1CacheDuration, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TieredCacheProvider{TKey}"/> class.
    /// </summary>
    /// <param name="memoryCache">The in-process L1 cache.</param>
    /// <param name="distributedCacheProvider">The distributed L2 cache provider.</param>
    /// <param name="l1CacheDuration">The duration for L1 cache entries.</param>
    /// <param name="asyncDistributedCacheProvider">The asynchronous distributed L2 cache provider.</param>
    public TieredCacheProvider(
        IMemoryCache memoryCache,
        ICacheProvider<TKey> distributedCacheProvider,
        TimeSpan l1CacheDuration,
        IAsyncCacheProvider<TKey> asyncDistributedCacheProvider)
    {
        _memoryCache = memoryCache;
        _distributedCacheProvider = distributedCacheProvider;
        _l1CacheDuration = l1CacheDuration;
        _asyncDistributedCacheProvider = asyncDistributedCacheProvider;
    }

    /// <inheritdoc />
    public bool TryGetCachedObject(TKey key, out object value)
    {
        if (TryGetLocalCacheValue(key, out value))
        {
            return true;
        }

        if (_distributedCacheProvider.TryGetCachedObject(key, out value))
        {
            SetLocalCacheValue(key, value);
            return true;
        }

        value = null;
        return false;
    }

    /// <inheritdoc />
    public void SetCachedObject(TKey key, object obj)
    {
        SetLocalCacheValue(key, obj);
        _distributedCacheProvider.SetCachedObject(key, obj);
    }

    /// <inheritdoc />
    public void Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
    {
        SetLocalCacheValue(key, value);
        _distributedCacheProvider.Insert(key, value, absoluteExpiration, slidingExpiration);
    }

    /// <inheritdoc />
    public async Task<(bool found, object value)> TryGetCachedObjectAsync(TKey key)
    {
        if (TryGetLocalCacheValue(key, out var value))
        {
            return (true, value);
        }

        (bool found, object value) result = _asyncDistributedCacheProvider is not null
            ? await _asyncDistributedCacheProvider.TryGetCachedObjectAsync(key).ConfigureAwait(false)
            : TryGetCachedObjectUsingSynchronousProvider(key);

        if (result.found)
        {
            SetLocalCacheValue(key, result.value);
        }

        return result;
    }

    /// <inheritdoc />
    public async Task SetCachedObjectAsync(TKey key, object obj)
    {
        SetLocalCacheValue(key, obj);

        if (_asyncDistributedCacheProvider is not null)
        {
            await _asyncDistributedCacheProvider.SetCachedObjectAsync(key, obj).ConfigureAwait(false);
            return;
        }

        _distributedCacheProvider.SetCachedObject(key, obj);
    }

    /// <inheritdoc />
    public async Task InsertAsync(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
    {
        SetLocalCacheValue(key, value);

        if (_asyncDistributedCacheProvider is not null)
        {
            await _asyncDistributedCacheProvider.InsertAsync(key, value, absoluteExpiration, slidingExpiration).ConfigureAwait(false);
            return;
        }

        _distributedCacheProvider.Insert(key, value, absoluteExpiration, slidingExpiration);
    }

    /// <inheritdoc />
    public void Clear()
    {
        CancellationTokenSource tokenSourceToCancel;

        lock (_clearSync)
        {
            tokenSourceToCancel = _clearTokenSource;
            _clearTokenSource = new CancellationTokenSource();
        }

        tokenSourceToCancel.Cancel();
    }

    private (bool found, object value) TryGetCachedObjectUsingSynchronousProvider(TKey key)
    {
        bool found = _distributedCacheProvider.TryGetCachedObject(key, out var value);
        return (found, value);
    }

    private bool TryGetLocalCacheValue(TKey key, out object value)
    {
        if (_memoryCache.TryGetValue(key, out var cachedValue))
        {
            value = ReferenceEquals(cachedValue, NullValue)
                ? null
                : cachedValue;

            return true;
        }

        value = null;
        return false;
    }

    private void SetLocalCacheValue(TKey key, object value)
    {
        var entryOptions = new MemoryCacheEntryOptions();

        if (_l1CacheDuration > TimeSpan.Zero)
        {
            entryOptions.AbsoluteExpirationRelativeToNow = _l1CacheDuration;
        }
        else
        {
            entryOptions.AbsoluteExpiration = DateTimeOffset.MaxValue;
        }

        entryOptions.AddExpirationToken(new CancellationChangeToken(_clearTokenSource.Token));
        _memoryCache.Set(key, value ?? NullValue, entryOptions);
    }
}
