// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using log4net;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;

namespace EdFi.Ods.Api.Caching
{
    public struct CacheItem<T>(T _value, TimeSpan _expirationPeriod)
    {
        public readonly T Value = _value;
        public readonly DateTime Expiration = DateTime.UtcNow.Add(_expirationPeriod);
    }

    /// <summary>
    /// Implements a cache provider backed by a <see cref="ConcurrentDictionary{TKey, Object}" /> that expires all entries after
    /// a specified period of time.
    /// </summary>
    /// <typeparam name="TKey">The Type of the key for entries in the cache.</typeparam>
    public class ExpiringConcurrentDictionaryCacheProvider<TKey> : ICacheProvider<TKey>, IClearable, IConcurrentCacheProvider<TKey>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly TimeSpan _defaultFactoryTimeout = TimeSpan.FromSeconds(30);

        private readonly string _description;
        private readonly Action _expirationCallback;
        
        private readonly ConcurrentDictionary<TKey, SemaphoreSlim> _locks = new();
        private readonly ConcurrentDictionary<TKey, ManualResetEventSlim> _resetEvents = new();
        private readonly ConcurrentDictionary<TKey, CacheItem<object>> _cache = new();

        private readonly ILog _logger = LogManager.GetLogger(typeof(ExpiringConcurrentDictionaryCacheProvider<>));

        private Timer _timer;
        private readonly bool _cacheEnabled = true;
        private readonly TimeSpan _expirationPeriod;
        private readonly TimeSpan _factoryTimeout;

        private int _hits = 0;
        private int _misses = 0;
        private RetryPolicy _retryPolicy;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpiringConcurrentDictionaryCacheProvider{TKey}" /> class using the
        /// specified recurring expiration period.
        /// </summary>
        /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
        /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
        /// <param name="factoryTimeout">The timeout period for a factory operation (to initialize a cache entry).</param>
        public ExpiringConcurrentDictionaryCacheProvider(string description, TimeSpan expirationPeriod, TimeSpan factoryTimeout = default)
            : this(description, expirationPeriod, expirationCallback: null, factoryTimeout) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpiringConcurrentDictionaryCacheProvider{TKey}" /> class using the
        /// specified recurring expiration period.
        /// </summary>
        /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
        /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
        /// <param name="factoryTimeout">The timeout period for a factory operation (to initialize a cache entry).</param>
        /// <param name="expirationCallback">Callback to invoke when the cache expires.</param>
        public ExpiringConcurrentDictionaryCacheProvider(
            string description,
            TimeSpan expirationPeriod,
            Action expirationCallback,
            TimeSpan factoryTimeout = default)
        {
            _description = description;
            _expirationPeriod = expirationPeriod;
            _factoryTimeout = factoryTimeout == default ? _defaultFactoryTimeout : factoryTimeout;

            // If expiration period is less than 0 disable caching behavior.
            if (expirationPeriod.TotalSeconds < 0)
            {
                _logger.Debug($"Cache '{description}' is disabled...");
                _cacheEnabled = false;
            }
            // Set expiration period only if expiration period is not the default (0)
            else if (expirationPeriod.TotalSeconds > 0)
            {
                _timer = new Timer(CacheExpired, null, expirationPeriod, expirationPeriod);
                _expirationCallback = expirationCallback;
            }
            
            _retryPolicy = Policy
                .Handle<TimeoutException>()
                .WaitAndRetry(Backoff.ExponentialBackoff(
                        initialDelay: _factoryTimeout / 2, // Initial retry delay
                        retryCount: 4),
                    onRetry: (exception, timeSpan, retryAttempt, context) =>
                    {
                        _logger.Warn($"Retry attempt {retryAttempt} of 4: Retrying factory delegate in {timeSpan.TotalSeconds} seconds due to exception: {exception.Message}");
                    });
        }

        private SemaphoreSlim GetLock(TKey key) =>
            _locks.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));

        private ManualResetEventSlim GetResetEvent(TKey key) =>
            _resetEvents.GetOrAdd(key, _ => new ManualResetEventSlim(true, 1));

        // public async Task<object> GetOrCreateAsync(
        //     TKey key,
        //     Func<CancellationToken, Task<object>> factory,
        //     TimeSpan singleFlightTimeout,
        //     CancellationToken ct = default)

        public object GetOrCreate<TArg>(
            TKey key,
            Func<TKey, TArg, object> factory,
            TimeSpan singleFlightTimeout,
            TArg factoryArgument)
        {
            if (!_cacheEnabled)
            {
                return factory(key, factoryArgument);
            }

            // Fast path, return the unexpired item
            if (_cache.TryGetValue(key, out var existing)) // && existing.Expiration > DateTime.UtcNow)
            {
                return existing.Value;
            }

            // Get the lock for the key
            var gate = GetLock(key);

            // Respect a timeout to avoid "infinite blocking"
            // using var timeoutCts = new CancellationTokenSource(singleFlightTimeout);
            // using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct, timeoutCts.Token);

            // Wait for the lock to be available
            // await gate.WaitAsync(linkedCts.Token).ConfigureAwait(false);

            // Wait for the lock to be available
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Waiting at gate for '{key}' for {singleFlightTimeout.TotalMilliseconds} ms...");

            if (!gate.Wait(singleFlightTimeout))
            {
                throw new TimeoutException($"Timeout waiting for exclusive lock for cache item '{key}'.");
            }

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Entered gate for '{key}'...");

            try
            {
                // Double-check the cache now after acquiring the lock successfully
                if (_cache.TryGetValue(key, out existing)) // && existing.Expiration > DateTime.UtcNow)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Found entry '{key}' already exists...");
                    return existing.Value;
                }

                // Value doesn't exist or is expired. Create it.
                // var value = await factory(linkedCts.Token).ConfigureAwait(false);
                
                // using var timeoutCts = new CancellationTokenSource(_factoryTimeout);

                return _retryPolicy.Execute(() =>
                {
                    // Execute the factory method, respecting the timeout
                    var factoryTask = Task.Run(() => factory(key, factoryArgument));

                    if (factoryTask.Wait(_factoryTimeout))
                    {
                        var value = factoryTask.GetAwaiter().GetResult();

                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Setting entry '{key}' in cache...");
                        _cache[key] = new CacheItem<object>(value, _expirationPeriod);

                        return value;
                    }
                    
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ({Common.Context.CallContext.GetData("TestTask")}): Timeout waiting for factory to create cache item '{key}'...");
                    throw new TimeoutException("Operation to create cache item timed out.");
                });
            }
            finally
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Releasing gate for '{key}'...");
                gate.Release();

                // Clean up semaphore now if no threads are waiting (to avoid growth)
                // if (gate.CurrentCount == 1)
                // {
                //     Console.WriteLine($"Removing lock for '{key}'...");
                //     _locks.TryRemove(new KeyValuePair<TKey, SemaphoreSlim>(key, gate));
                // }
            }
        }

        public bool TryGetCachedObject(TKey key, out object value)
        {
            if (_cacheEnabled)
            {
                if (_cache.TryGetValue(key, out var item))
                {
                    if (_logger.IsDebugEnabled)
                    {
                        _hits++;
                        
                        if (_hits < 50 || _hits % 100 == 0)
                        {
                            _logger.Debug(
                                $"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' HIT ({_hits} hits, {_misses} misses).");
                        }
                    }

                    value = item.Value;
                    return true;
                }

                if (_logger.IsDebugEnabled)
                {
                    _misses++;

                    if (_misses < 50 || _misses % 100 == 0)
                    {
                        _logger.Debug(
                            $"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' MISS ({_hits} hits, {_misses} misses).");
                    }
                }
            }

            value = null;
            return false;
        }

        public void SetCachedObject(TKey key, object obj)
        {
            if (_cacheEnabled)
            {
                _cache[key] = new CacheItem<object>(obj, _expirationPeriod);
            }
        }

        public void Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            if (_cacheEnabled)
            {
                _cache[key] = new CacheItem<object>(value, _expirationPeriod);
            }
        }

        public void Clear()
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' cleared (of {_cache.Count} entries).");
                
                _hits = 0; 
                _misses = 0;
            }

            // Clear the entries of the dictionary
            _cache.Clear();
            _locks.Clear();

            // Recreate the timer
            _timer.Dispose();
            _timer = new Timer(CacheExpired, null, _expirationPeriod, _expirationPeriod);
        }

        private void CacheExpired(object state)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' expired ({_cache.Count} entries cleared after {_hits} hits and {_misses} misses).");

                _hits = 0; 
                _misses = 0;
            }

            _cache.Clear();
            _locks.Clear();
            _expirationCallback?.Invoke();
        }
    }
}
