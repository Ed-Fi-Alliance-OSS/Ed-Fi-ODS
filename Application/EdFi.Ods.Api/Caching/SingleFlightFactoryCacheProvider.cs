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
using Polly.Retry;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;
using EdFi.Ods.Common.Caching.SingleFlight;

namespace EdFi.Ods.Api.Caching;

public class SingleFlightFactoryCacheProvider<TKey, TValue> : ISingleFlightCache<TKey, TValue>, IClearable
    where TKey : notnull
{
    // ReSharper disable once StaticMemberInGenericType
    private static readonly TimeSpan _defaultFactoryTimeout = TimeSpan.FromSeconds(30);

    protected readonly ConcurrentDictionary<TKey, CacheEntry> Cache = new();
    private CancellationTokenSource _cacheExpirationTokenSource = new(); // swapped on Clear()
    
    private readonly ILog _logger = LogManager.GetLogger(typeof(SingleFlightFactoryCacheProvider<TKey, TValue>));

    protected readonly string Description;
    protected int HitsApproximate = 0;
    protected int MissesApproximate = 0;

    private readonly TimeSpan _factoryTimeout;

    private readonly RetryPolicy _factoryRetryPolicy;
    private readonly RetryPolicy _cacheEntryRetryPolicy;

    public SingleFlightFactoryCacheProvider(string description, TimeSpan factoryTimeout)
    {
        Description = description;

        _factoryTimeout = factoryTimeout == default
            ? _defaultFactoryTimeout
            : factoryTimeout;

        _factoryRetryPolicy = Policy.Handle<TimeoutException>()
            .WaitAndRetry(
                Backoff.ExponentialBackoff(
                    initialDelay: _factoryTimeout / 2, // Initial retry delay
                    retryCount: 4),
                onRetry: (exception, timeSpan, retryAttempt, context) =>
                {
                    _logger.Warn(
                        $"Retry attempt {retryAttempt} of 4: Retrying factory delegate in {timeSpan.TotalSeconds} seconds due to exception: {exception.Message}");
                });

        _cacheEntryRetryPolicy = Policy.Handle<OperationCanceledException>()
            .WaitAndRetry(
                Backoff.ExponentialBackoff(
                    initialDelay: TimeSpan.FromMilliseconds(10), // Initial retry delay
                    retryCount: 5),
                onRetry: (exception, timeSpan, retryAttempt, context) =>
                {
                    _logger.Warn(
                        $"Retry attempt {retryAttempt} of 4: Retrying expired cache entry access in {timeSpan.TotalSeconds} seconds due to exception: {exception.Message}");
                });
    }

    protected CancellationToken GetCurrentCacheExpirationCancellationToken() => _cacheExpirationTokenSource.Token;
    
    public virtual TValue GetOrCreate<TArg>(
        TKey key,
        Func<TKey, TArg, TValue> factory,
        TimeSpan singleFlightTimeout,
        TArg factoryArgument,
        CancellationToken callerCancellationToken = default)
    {
        return _cacheEntryRetryPolicy.Execute(() =>
        {
            // Capture the token to be able to detect cache expiration while processing
            var cacheExpirationToken = _cacheExpirationTokenSource.Token;

            // TODO: Consider removal of tokens in favor of all waits being controlled by the producer and factory timeout
            // var cts = new CancellationTokenSource(singleFlightTimeout);
            // var ct = cts.Token;

            // Fast path: only allocates a CacheEntry on a miss
            var entry = Cache.GetOrAdd(key, static (_, token) => new CacheEntry(token), cacheExpirationToken);

            // Try to read the entry before producing
            if (entry.TryGet(out var value))
            {
                return value;
            }

            // Try to become the producer (no allocation here)
            entry.Produce(factory, key, factoryArgument, _factoryRetryPolicy, _factoryTimeout);

            // All callers (including the producer) converge here to read the result
            using var linkedTokenSource =
                CancellationTokenSource.CreateLinkedTokenSource(callerCancellationToken, cacheExpirationToken);

            return entry.WaitForResult(linkedTokenSource.Token);
        });
    }

    public void Remove(TKey key) => Cache.TryRemove(key, out _);

    // public object GetOrCreate<TArg>(
    //     TKey key,
    //     Func<TKey, TArg, object> factory,
    //     TimeSpan singleFlightTimeout,
    //     TArg factoryArgument)
    // {
    //     throw new NotImplementedException();
    // }

    public virtual void Clear()
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Clearing cache '{Description}'...");
        
        using var oldCancellationTokenSource = Interlocked.Exchange(ref _cacheExpirationTokenSource, new CancellationTokenSource());
        Cache.Clear();
        
        // Allow in-flight producers/waiters to detect expiration of the cache
        oldCancellationTokenSource.Cancel();

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                $"{nameof(ExpiringSingleFlightFactoryCacheProvider<TKey, TValue>)} cache '{Description}' cleared (of {Cache.Count} entries).");

            HitsApproximate = 0;
            MissesApproximate = 0;
        }
    }

    protected sealed class CacheEntry(CancellationToken _cacheExpirationToken)
    {
        // Enumeration here isn't possible due to the use of Volatile.Read/Write
        private const int StateInit = 0;
        private const int StateProducing = 1;
        private const int StateReady = 2;
        private const int StateFailed = 3;
        private const int StateExpired = 4;

        // 0 = Init, 1 = Producing, 2 = Ready, 3 = Failed
        private int _state;

        private TValue _value;
        private Exception _error;
        private ManualResetEventSlim _event; // allocated only on contended wait

        private readonly TaskCompletionSource<TValue> _tcs =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        
        public bool TryGet(out TValue value)
        {
            EnsureCacheNotExpired();

            if (Volatile.Read(ref _state) == StateReady)
            {
                value = _value;
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
                throw new OperationCanceledException("Cache has expired.");
            }
        }

        // Called by exactly one producer
        public void Produce<TArg>(
            Func<TKey, TArg, TValue> factory,
            TKey key,
            TArg factoryArgument,
            RetryPolicy retryPolicy,
            TimeSpan factoryTimeout)
        {
            // Try to become the producer by performing state transition (if another thread is already producing or has produced a result this will fail)
            if (Interlocked.CompareExchange(ref _state, StateProducing, StateInit) != StateInit)
            {
                return;
            }

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Becoming producer for entry '{key}' (CacheEntry: {GetHashCode()})...");

            try
            {
                // Execute the factory method, respecting the timeout
                var computedValue = retryPolicy.Execute(() =>
                {
                    // Execute the factory method, respecting the timeout
                    var factoryTask = Task.Run(() => factory(key, factoryArgument));

                    if (factoryTask.Wait(factoryTimeout))
                    {
                        var value = factoryTask.ConfigureAwait(false).GetAwaiter().GetResult();

                        EnsureCacheNotExpired();

                        Console.WriteLine(
                            $"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Factory created value of '{value}' for entry '{key}' (CacheEntry: {GetHashCode()})...");

                        return value;
                    }

                    Console.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Timeout waiting for factory to create value for cache item '{key}' (CacheEntry: {GetHashCode()})...");

                    throw new TimeoutException("Operation to create value for cache item timed out.");
                });

                EnsureCacheNotExpired();

                _value = computedValue;
                Volatile.Write(ref _state, StateReady);
                _event?.Set();
            }
            catch (Exception ex)
            {
                EnsureCacheNotExpired();

                _error = ex;
                Volatile.Write(ref _state, StateFailed);
                _event?.Set();

                throw;
            }
        }

        // Called by waiters (including non-producers)
        public TValue WaitForResult(CancellationToken ct)
        {
            EnsureCacheNotExpired();

            // Fast path
            var state = Volatile.Read(ref _state);

            if (state == StateReady)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cache entry found in 'Ready' state with value '{_value}' available (CacheEntry: {GetHashCode()})...");
                return _value;
            }

            if (state == StateFailed)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cache entry found in 'Error' state. Rethrowing exception for cache initialization failure (CacheEntry: {GetHashCode()})...");

                ExceptionDispatchInfo.Capture(_error!).Throw();
            }

            // Short spin to avoid allocating an event under light contention
            var spinner = new SpinWait();

            for (int i = 0; i < 8; i++)
            {
                EnsureCacheNotExpired();

                spinner.SpinOnce();
                state = Volatile.Read(ref _state);

                if (state == StateReady)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cache entry found in 'Ready' state (after short spin) with value '{_value}' available (CacheEntry: {GetHashCode()})...");
                    return _value;
                }

                if (state == StateFailed)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Cache entry found in 'Error' state (after short spin). Rethrowing exception for cache initialization failure (CacheEntry: {GetHashCode()})...");
                    ExceptionDispatchInfo.Capture(_error!).Throw();
                }
            }

            EnsureCacheNotExpired();

            // Slow path: allocate the event only once
            var @event = _event;

            if (@event is null)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Creating event for cache entry (CacheEntry: {GetHashCode()})...");

                var createdEvent = new ManualResetEventSlim(false);
                var previousEvent = Interlocked.CompareExchange(ref _event, createdEvent, null);

                @event = previousEvent ?? createdEvent;

                // If we lost the race, dispose of our newly created event
                if (previousEvent is not null)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Lost the race for event creation -- disposing of unused event (CacheEntry: {GetHashCode()})...");
                    createdEvent.Dispose();
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): WON the race for event creation (CacheEntry: {GetHashCode()})...");
                }
            }

            EnsureCacheNotExpired();

            // If now ready or failed, skip waiting
            state = Volatile.Read(ref _state);

            switch (state)
            {
                case StateReady:
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Result of '{_value}' found to be available on final check before waiting (CacheEntry: {GetHashCode()})...");
                    return _value;

                case StateFailed:
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Failure discovered on final check before waiting. Rethrowing '{_error.GetType().Name}' exception (CacheEntry: {GetHashCode()})...");
                    ExceptionDispatchInfo.Capture(_error!).Throw();

                    break;
            }

            EnsureCacheNotExpired();

            // Block until the producer signals completion (either ready or failed)
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Waiting for result to be available (CacheEntry: {GetHashCode()})...");
            @event.Wait(ct);

            EnsureCacheNotExpired();

            state = Volatile.Read(ref _state);

            if (state == StateReady)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Result of '{_value}' found to be available after wait completion (CacheEntry: {GetHashCode()})...");
                return _value;
            }

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Failure discovered after wait completion. Rethrowing '{_error.GetType().Name}' exception (CacheEntry: {GetHashCode()})...");
            ExceptionDispatchInfo.Capture(_error!).Throw();

            // Unreachable code - keep the compiler happy
            return default;
        }
    }
}
