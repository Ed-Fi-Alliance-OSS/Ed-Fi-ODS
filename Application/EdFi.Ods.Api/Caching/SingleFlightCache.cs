// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using log4net;
using Polly;
using Polly.Contrib.WaitAndRetry;
using System.Collections.Concurrent;
using System.Threading;

namespace EdFi.Ods.Api.Caching;

/// <summary>
/// Represents a caching mechanism that ensures only a single in-flight request is made for
/// a given key while other concurrent requests for the same key wait for the result of the first request.
/// </summary>
/// <typeparam name="TKey">The type of the key used to uniquely identify a cache entry. Must be non-nullable.</typeparam>
/// <typeparam name="TValue">The type of the value stored in the cache for each key.</typeparam>
public class SingleFlightCache<TKey, TValue> : ISingleFlightCache<TKey, TValue>, IClearable
    where TKey : notnull
{
    protected readonly ConcurrentDictionary<TKey, CacheEntry> Cache = new();
    
    private readonly ILog _logger = LogManager.GetLogger(typeof(SingleFlightCache<TKey, TValue>));

    protected readonly string Description;
    protected int HitsApproximate = 0;
    protected int MissesApproximate = 0;

    private readonly TimeSpan _createTimeout;
    private readonly TimeSpan _joinTimeout;

    private readonly AsyncPolicy _factoryRetryPolicyAsync;

    public SingleFlightCache(string description, TimeSpan createTimeout)
    {
        Description = description;

        _createTimeout = createTimeout == TimeSpan.Zero
            ? TimeSpan.FromSeconds(10)
            : createTimeout;
        
        _joinTimeout = TimeSpan.FromMilliseconds(_createTimeout.TotalMilliseconds * 1.5);

        const int RetryCount = 3;

        _factoryRetryPolicyAsync = _createTimeout == Timeout.InfiniteTimeSpan 
            ? Policy.NoOpAsync()
            : Policy.Handle<TimeoutException>()
            .WaitAndRetryAsync(
                Backoff.DecorrelatedJitterBackoffV2(
                    medianFirstRetryDelay: TimeSpan.FromMilliseconds(200), // Initial retry delay
                    retryCount: RetryCount),
                onRetryAsync: async (exception, timeSpan, retryAttempt, context) =>
                {
                    // Log the retry attempt
                    _logger.Warn(
                        $"Retry attempt {retryAttempt} of {RetryCount}: Retrying factory delegate in {timeSpan.TotalMilliseconds:N0} milliseconds due to exception: {exception.Message}");

                    // Placeholder for any custom async side-effect (if needed, replace with actual implementation)
                    await Task.CompletedTask;
                });
    }

    /// <inheritdoc cref="ISingleFlightCache{TKey,TValue}.GetOrCreateAsync{TArg}" />
    public virtual async Task<TValue> GetOrCreateAsync<TArg>(
        TKey key,
        Func<TKey, TArg, CancellationToken, Task<TValue>> factory,
        TArg factoryArgument,
        CancellationToken callerToken)
    {
        var entry = Cache.GetOrAdd(key, static (_, t) => new CacheEntry(t), callerToken);

        if (entry.TryGet(out var cached))
        {
            if (_logger.IsDebugEnabled)
            {
                HitsApproximate++;
            }

            return cached;
        }

        if (_logger.IsDebugEnabled)
        {
            MissesApproximate++;
        }

        await entry.ProduceAsync(factory, key, factoryArgument, _factoryRetryPolicyAsync, _createTimeout, callerToken)
            .ConfigureAwait(false);

        using var joinCts = new CancellationTokenSource(_joinTimeout);
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(callerToken, joinCts.Token);

        return await entry.WaitForResultAsync(linked.Token).ConfigureAwait(false);
    }

    public void Remove(TKey key) => Cache.TryRemove(key, out _);

    public virtual void Clear()
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Clearing cache '{Description}'...");
        
        Cache.Clear();

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                $"{nameof(ExpiringSingleFlightCache<TKey, TValue>)} cache '{Description}' cleared (of {Cache.Count} entries).");

            HitsApproximate = 0;
            MissesApproximate = 0;
        }
    }

    protected sealed class CacheEntry(CancellationToken _cacheExpirationToken)
    {
        private int _producerChosen; // 0 = none, 1 = chosen

        private readonly TaskCompletionSource<TValue> _tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public bool TryGet(out TValue value)
        {
            EnsureCacheNotExpired();

            if (_tcs.Task.IsCompletedSuccessfully)
            {
                value = _tcs.Task.Result;
                return true;
            }

            value = default;
            return false;
        }

        private void EnsureCacheNotExpired()
        {
            if (_cacheExpirationToken.IsCancellationRequested)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cache expiration detected (CacheEntry: {GetHashCode()})...");
                throw new OperationCanceledException("Cache has expired.", _cacheExpirationToken);
            }
        }

        public async Task ProduceAsync<TArg>(
            Func<TKey, TArg, CancellationToken, Task<TValue>> factory,
            TKey key,
            TArg factoryArgument,
            AsyncPolicy retryPolicy,
            TimeSpan createTimeout,
            CancellationToken callerToken)
        {
            // Attempt to become the producer (state transition)
            if (Interlocked.CompareExchange(ref _producerChosen, 1, 0) != 0)
            {
                return;
            }

            try
            {
                Console.WriteLine(
                    $"{Thread.CurrentThread.ManagedThreadId}: Becoming producer for entry '{key}' (CacheEntry: {GetHashCode()})...");

                // Execute the factory method with retry and timeout handling
                var createdValue = await retryPolicy.ExecuteAsync(
                    async pollyCt =>
                    {
                        using var createTimeoutCts = new CancellationTokenSource(createTimeout);

                        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(pollyCt, _cacheExpirationToken, createTimeoutCts.Token, callerToken);

                        try
                        {
                            // Await the factory execution
                            var value = await factory(key, factoryArgument, linkedCts.Token).ConfigureAwait(false);

                            EnsureCacheNotExpired();

                            Console.WriteLine(
                                $"{Thread.CurrentThread.ManagedThreadId}: Factory created value '{value}' for entry '{key}' (CacheEntry: {GetHashCode()})...");

                            return value;
                        }
                        catch (OperationCanceledException) when (createTimeoutCts.Token.IsCancellationRequested)
                        {
                            Console.WriteLine(
                                $"{Thread.CurrentThread.ManagedThreadId}: Timeout while creating value for cache item '{key}' (CacheEntry: {GetHashCode()})...");

                            throw new TimeoutException("Operation to create value for cache item timed out.");
                        }
                    },
                    callerToken)
                    .ConfigureAwait(false);

                // Set the computed value, update state, and signal waiting threads
                EnsureCacheNotExpired();
                _tcs.TrySetResult(createdValue);
            }
            catch (Exception ex)
            {
                // Handle any exceptions during value production
                EnsureCacheNotExpired();
                _tcs.TrySetException(ex);

                throw;
            }
        }

        public async Task<TValue> WaitForResultAsync(CancellationToken waitToken)
        {
            EnsureCacheNotExpired();

            using var linked = CancellationTokenSource.CreateLinkedTokenSource(waitToken, _cacheExpirationToken);

            try
            {
                return await _tcs.Task.WaitAsync(linked.Token).ConfigureAwait(false);
            }
            catch (TaskCanceledException ex) when (waitToken.IsCancellationRequested)
            {
                throw new TimeoutException("The wait period for obtaining the value from cache expired.", ex);
            }
            catch (TaskCanceledException ex) when (_cacheExpirationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException("Cache has expired.", ex);
            }
        }
    }
}
