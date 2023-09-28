// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using EdFi.Ods.Common.Caching;
using log4net;

namespace EdFi.Ods.Api.Caching
{
    /// <summary>
    /// Implements a cache provider backed by a <see cref="ConcurrentDictionary{TKey, Object}" /> that expires all entries after
    /// a specified period of time.
    /// </summary>
    /// <typeparam name="TKey">The Type of the key for entries in the cache.</typeparam>
    public class ExpiringConcurrentDictionaryCacheProvider<TKey> : ICacheProvider<TKey>, IClearable
    {
        private readonly string _description;
        private readonly Action _expirationCallback;
        private readonly IDictionary<TKey, object> _cacheDictionary = new ConcurrentDictionary<TKey, object>();

        private readonly ILog _logger = LogManager.GetLogger(typeof(ExpiringConcurrentDictionaryCacheProvider<>));

        private Timer _timer;
        private readonly bool _cacheEnabled = true;
        private readonly TimeSpan _expirationPeriod;

        private int _hits = 0;
        private int _misses = 0;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpiringConcurrentDictionaryCacheProvider{TKey}" /> class using the
        /// specified recurring expiration period.
        /// </summary>
        /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
        /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
        public ExpiringConcurrentDictionaryCacheProvider(string description, TimeSpan expirationPeriod)
            : this(description, expirationPeriod, expirationCallback: null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpiringConcurrentDictionaryCacheProvider{TKey}" /> class using the
        /// specified recurring expiration period.
        /// </summary>
        /// <param name="description">A description of the contents of the cached data for information/logging purposes.</param>
        /// <param name="expirationPeriod">The recurring expiration period for all of the entries in the cache.</param>
        /// <param name="expirationCallback">Callback to invoke when the cache expires.</param>
        public ExpiringConcurrentDictionaryCacheProvider(string description, TimeSpan expirationPeriod, Action expirationCallback)
        {
            _description = description;
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
                _timer = new Timer(CacheExpired, null, expirationPeriod, expirationPeriod);
                _expirationCallback = expirationCallback;
            }
        }

        public bool TryGetCachedObject(TKey key, out object value)
        {
            if (_cacheEnabled)
            {
                if (_cacheDictionary.TryGetValue(key, out value))
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

                    return true;
                }

                if (_logger.IsDebugEnabled)
                {
                    _misses++;
                    _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' MISS ({_hits} hits, {_misses} misses).");
                }
            }

            value = null;
            return false;
        }

        public void SetCachedObject(TKey key, object obj)
        {
            if (_cacheEnabled)
            {
                _cacheDictionary[key] = obj;
            }
        }

        public void Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            if (_cacheEnabled)
            {
                _cacheDictionary[key] = value;
            }
        }

        public void Clear()
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' cleared (of {_cacheDictionary.Count} entries).");
            }

            // Clear the entries of the dictionary
            _cacheDictionary.Clear();
            
            // Recreate the timer
            _timer.Dispose();
            _timer = new Timer(CacheExpired, null, _expirationPeriod, _expirationPeriod);
        }

        private void CacheExpired(object state)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' expired ({_cacheDictionary.Count} entries cleared after {_hits} hits and {_misses} misses).");

                Interlocked.Exchange(ref _hits, 0); 
                Interlocked.Exchange(ref _misses, 0);
            }

            _cacheDictionary.Clear();
            _expirationCallback?.Invoke();
        }
    }
}
