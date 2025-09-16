// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using log4net;

namespace EdFi.Ods.Api.Caching;

public class ExpiringSingleFlightFactoryCacheProvider<TKey, TValue> : SingleFlightFactoryCacheProvider<TKey, TValue>
{
    private Timer _timer;
    private readonly TimeSpan _expirationPeriod;
    private readonly Action _expirationCallback;

    private readonly bool _cacheEnabled = true;

    private readonly ILog _logger = LogManager.GetLogger(typeof(ExpiringSingleFlightFactoryCacheProvider<TKey, TValue>));

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpiringSingleFlightFactoryCacheProvider{TKey,TValue}" /> class using the
    /// specified recurring expiration period.
    /// </summary>
    /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
    /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
    /// <param name="factoryTimeout">The timeout period for a factory operation (to initialize a cache entry).</param>
    public ExpiringSingleFlightFactoryCacheProvider(string description, TimeSpan expirationPeriod, TimeSpan factoryTimeout = default)
        : this(description, expirationPeriod, expirationCallback: null, factoryTimeout) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpiringSingleFlightFactoryCacheProvider{TKey,TValue}" /> class using the
    /// specified recurring expiration period.
    /// </summary>
    /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
    /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
    /// <param name="factoryTimeout">The timeout period for a factory operation (to initialize a cache entry).</param>
    /// <param name="expirationCallback">Callback to invoke when the cache expires.</param>
    public ExpiringSingleFlightFactoryCacheProvider(
        string description,
        TimeSpan expirationPeriod,
        Action expirationCallback,
        TimeSpan factoryTimeout = default)
        : base(description, factoryTimeout)
    {
        _expirationPeriod = expirationPeriod;

        // If expiration period is less than 0 disable caching behavior.
        if (expirationPeriod.TotalSeconds < 0)
        {
            _logger.Debug($"Cache '{description}' is disabled...");
            _cacheEnabled = false;
        }
        // Set expiration period only if expiration period is not the default (0)
        else if (expirationPeriod.TotalSeconds > 0)
        {
            _timer = new Timer(CacheExpired, GetCurrentCacheExpirationCancellationToken(), expirationPeriod, expirationPeriod);
            _expirationCallback = expirationCallback;
        }
    }

    public override TValue GetOrCreate<TArg>(
        TKey key,
        Func<TKey, TArg, TValue> factory,
        TimeSpan singleFlightTimeout,
        TArg factoryArgument,
        CancellationToken callerCancellationToken = default)
    {
        // If caching has been disabled (by setting the expiration period to less than 0), call the factory directly.
        return !_cacheEnabled
            ? factory(key, factoryArgument)
            : base.GetOrCreate(key, factory, singleFlightTimeout, factoryArgument, callerCancellationToken);
    }

    public override void Clear()
    {
        // Clear the cache, create a new cancellation token source
        base.Clear();

        var newCancellationToken = GetCurrentCacheExpirationCancellationToken();

        // Create a new timer with the new expiration token
        var newTimer = new Timer(CacheExpired, newCancellationToken, _expirationPeriod, _expirationPeriod);

        Console.WriteLine(
            $"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): New timer created with expiration token (ct: {newCancellationToken.GetHashCode()}).");

        // Atomically swap timers
        var oldTimer = Interlocked.Exchange(ref _timer, newTimer);

        // Dispose of the old timer
        oldTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        oldTimer?.Dispose();
    }

    private void CacheExpired(object state)
    {
        CancellationToken cancellationToken = (CancellationToken) state;

        // Has the cache for this timer already been cleared explicitly?
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cached expiration period elapsed but cache associated with timer (ct: {cancellationToken.GetHashCode()}) was already cleared.");
            return;
        }

        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cached expiration period elapsed. Clearing cache '{Description}' (ct: {cancellationToken.GetHashCode()})...");

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{Description}' expired ({Cache.Count} entries cleared after {HitsApproximate} hits and {MissesApproximate} misses).");
        }
        
        // Clear the cache and invoke the expiration callback
        Clear();
        _expirationCallback?.Invoke();
    }
}
