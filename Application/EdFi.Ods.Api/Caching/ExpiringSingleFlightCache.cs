// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Polly;

namespace EdFi.Ods.Api.Caching;

public class ExpiringSingleFlightCache<TKey, TValue> : SingleFlightCache<TKey, TValue>
{
    private Timer _timer;
    private readonly TimeSpan _expirationPeriod;
    private readonly Action _expirationCallback;

    private readonly bool _cacheEnabled = true;

    private CancellationTokenSource _cacheExpirationTokenSource = new(); // swapped on Clear()
    
    private readonly ILog _logger = LogManager.GetLogger(typeof(ExpiringSingleFlightCache<TKey, TValue>));

    private readonly AsyncPolicy _cacheExpiredRetryPolicyAsync;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpiringSingleFlightCache{TKey,TValue}" /> class using the
    /// specified recurring expiration period.
    /// </summary>
    /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
    /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
    /// <param name="createTimeout">The timeout period for a factory operation (to initialize a cache entry).</param>
    public ExpiringSingleFlightCache(string description, TimeSpan expirationPeriod, TimeSpan createTimeout)
        : this(description, expirationPeriod, expirationCallback: null, createTimeout) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpiringSingleFlightCache{TKey,TValue}" /> class using the
    /// specified recurring expiration period.
    /// </summary>
    /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
    /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
    /// <param name="createTimeout">The timeout period for a factory operation (to initialize a cache entry).</param>
    /// <param name="expirationCallback">Callback to invoke when the cache expires.</param>
    public ExpiringSingleFlightCache(
        string description,
        TimeSpan expirationPeriod,
        Action expirationCallback,
        TimeSpan createTimeout)
        : base(description, createTimeout)
    {
        _expirationPeriod = expirationPeriod;

        // If expiration period is less than 0 disable caching behavior.
        if (expirationPeriod < TimeSpan.Zero)
        {
            _logger.Debug($"Cache '{description}' is disabled...");
            _cacheEnabled = false;
        }
        // Set expiration period only if expiration period is not the default (0)
        else if (expirationPeriod > TimeSpan.Zero)
        {
            _timer = new Timer(CacheExpired, _cacheExpirationTokenSource.Token, expirationPeriod, expirationPeriod);
            _expirationCallback = expirationCallback;
        }
        
        _cacheExpiredRetryPolicyAsync = expirationPeriod <= TimeSpan.Zero 
            ? Policy.NoOpAsync()
            : Policy.Handle<OperationCanceledException>()
                .RetryAsync(
                    onRetry: (exception, retryAttempt, context) =>
                    {
                        // Log the retry attempt
                        _logger.Warn($"Cache expired while obtaining cache entry. Retrying once...");

                        // Optionally, you might perform additional async-side effects like notifying other parts of your system if needed
                        // await Task.CompletedTask; // Placeholder for custom async actions
                    });
    }

    public override async Task<TValue> GetOrCreateAsync<TArg>(
        TKey key,
        Func<TKey, TArg, CancellationToken, Task<TValue>> factory,
        TArg factoryArgument,
        CancellationToken callerToken)
    {
        // If caching is disabled, just execute the factory logic
        if (!_cacheEnabled)
        {
            return await factory(key, factoryArgument, callerToken);
        }

        // Incorporate the cancellation token into the token passed to the base GetOrCreateAsync method
        using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(callerToken, _cacheExpirationTokenSource.Token);
        
        // Attempt to retrieve the entry or add it if it doesn't exist, while retrying once if the cache expires
        return await _cacheExpiredRetryPolicyAsync.ExecuteAsync(
            async ct => await base.GetOrCreateAsync(key, factory, factoryArgument, ct),
            linkedTokenSource.Token);
    }

    public override void Clear()
    {
        // Clear the cache, create a new cancellation token source
        base.Clear();

        // Create a new cancellation token source
        var newCancellationTokenSource = new CancellationTokenSource();
        var oldCancellationTokenSource = Interlocked.Exchange(ref _cacheExpirationTokenSource, newCancellationTokenSource);

        // Dispose of the old token source
        oldCancellationTokenSource?.Dispose();
        
        // Create a new timer with the new expiration token
        var newTimer = new Timer(CacheExpired, newCancellationTokenSource.Token, _expirationPeriod, _expirationPeriod);

        Console.WriteLine(
            $"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): New timer created with expiration token (ct: {newCancellationTokenSource.Token.GetHashCode()}).");

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
