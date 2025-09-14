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

namespace EdFi.Ods.Api.Caching;

using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;

public class SingleFlightFactoryCacheProvider<TKey, TValue> : ISingleFlightFactoryCacheProvider<TKey, TValue>, IClearable
    where TKey : notnull
{
    // ReSharper disable once StaticMemberInGenericType
    private static readonly TimeSpan _defaultFactoryTimeout = TimeSpan.FromSeconds(30);

    protected readonly ConcurrentDictionary<TKey, CacheEntry> Cache = new();

    private readonly ILog _logger = LogManager.GetLogger(typeof(SingleFlightFactoryCacheProvider<TKey, TValue>));

    protected readonly string Description;
    protected int HitsApproximate = 0;
    protected int MissesApproximate = 0;

    private readonly TimeSpan _factoryTimeout;

    private readonly RetryPolicy _retryPolicy;

    public SingleFlightFactoryCacheProvider(string description, TimeSpan factoryTimeout)
    {
        Description = description;

        _factoryTimeout = factoryTimeout == default
            ? _defaultFactoryTimeout
            : factoryTimeout;

        _retryPolicy = Policy.Handle<TimeoutException>()
            .WaitAndRetry(
                Backoff.ExponentialBackoff(
                    initialDelay: _factoryTimeout / 2, // Initial retry delay
                    retryCount: 4),
                onRetry: (exception, timeSpan, retryAttempt, context) =>
                {
                    _logger.Warn(
                        $"Retry attempt {retryAttempt} of 4: Retrying factory delegate in {timeSpan.TotalSeconds} seconds due to exception: {exception.Message}");
                });
    }

    public virtual TValue GetOrCreate<TArg>(
        TKey key,
        Func<TKey, TArg, TValue> factory,
        TimeSpan singleFlightTimeout,
        TArg factoryArgument)
    {
        // TODO: Consider removal of tokens in favor of all waits being controlled by the producer and factory timeout
        var cts = new CancellationTokenSource(singleFlightTimeout);
        var ct = cts.Token;

        // Fast path: only allocates a CacheEntry on a miss
        var entry = Cache.GetOrAdd(key, static _ => new CacheEntry());

        // Try to read without producing
        if (entry.TryGet(out var value))
        {
            return value;
        }

        // Try to become the producer (no allocation here)
        entry.Produce(factory, key, factoryArgument, _retryPolicy, _factoryTimeout);

        // All callers (including the producer) converge here to read the result
        return entry.WaitForResult(ct);
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
        
        Cache.Clear();

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                $"{nameof(ExpiringSingleFlightFactoryCacheProvider<TKey, TValue>)} cache '{Description}' cleared (of {Cache.Count} entries).");

            HitsApproximate = 0;
            MissesApproximate = 0;
        }
    }

    protected sealed class CacheEntry()
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

        public bool TryGet(out TValue value)
        {
            if (Volatile.Read(ref _state) == StateReady)
            {
                value = _value;
                return true;
            }

            value = default;
            return false;
        }

        // Called by exactly one producer
        public void Produce<TArg>(
            Func<TKey, TArg, TValue> factory,
            TKey key,
            TArg factoryArgument,
            RetryPolicy retryPolicy,
            TimeSpan factoryTimeout)
        {
            // Check if another thread is already producing or has produced a result
            if (Interlocked.CompareExchange(ref _state, StateProducing, StateInit) != StateInit)
            {
                return;
            }

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Becoming producer for entry '{key}' (CacheEntry: {GetHashCode()})...");

            try
            {
                // Execute the factory method, respecting the timeout
                _value = retryPolicy.Execute(() =>
                {
                    // Execute the factory method, respecting the timeout
                    var factoryTask = Task.Run(() => factory(key, factoryArgument));

                    if (factoryTask.Wait(factoryTimeout))
                    {
                        var value = factoryTask.ConfigureAwait(false).GetAwaiter().GetResult();

                        Console.WriteLine(
                            $"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Factory created value of '{value}' for entry '{key}' (CacheEntry: {GetHashCode()})...");

                        return value;
                    }

                    Console.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Timeout waiting for factory to create value for cache item '{key}' (CacheEntry: {GetHashCode()})...");

                    throw new TimeoutException("Operation to create value for cache item timed out.");
                });


                Volatile.Write(ref _state, StateReady);
                _event?.Set();
            }
            catch (Exception ex)
            {
                _error = ex;
                Volatile.Write(ref _state, StateFailed);
                _event?.Set();

                throw;
            }
        }

        // Called by waiters (including non-producers)
        public TValue WaitForResult(CancellationToken ct)
        {
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

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Waiting for result to be available (CacheEntry: {GetHashCode()})...");

            // Block until the producer signals completion (either ready or failed)
            @event.Wait(ct);

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
