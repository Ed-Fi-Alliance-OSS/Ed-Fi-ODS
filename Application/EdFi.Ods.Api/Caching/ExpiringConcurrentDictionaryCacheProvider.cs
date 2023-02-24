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
    public class ExpiringConcurrentDictionaryCacheProvider<TKey> : ICacheProvider<TKey>
    {
        private readonly string _description;
        private readonly Action _expirationCallback;
        private readonly IDictionary<TKey, object> _cacheDictionary = new ConcurrentDictionary<TKey, object>();

        private readonly ILog _logger = LogManager.GetLogger(typeof(ExpiringConcurrentDictionaryCacheProvider<>));

        private Timer _timer;

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
            _timer = new Timer(CacheExpired, null, expirationPeriod, expirationPeriod);
            _expirationCallback = expirationCallback;
        }

        public bool TryGetCachedObject(TKey key, out object value)
        {
            return _cacheDictionary.TryGetValue(key, out value);
        }

        public void SetCachedObject(TKey key, object obj)
        {
            _cacheDictionary[key] = obj;
        }

        public void Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            _cacheDictionary[key] = value;
        }

        private void CacheExpired(object state)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug($"{nameof(ExpiringConcurrentDictionaryCacheProvider<TKey>)} cache '{_description}' expired (all entries cleared).");
            }

            _cacheDictionary.Clear();

            _expirationCallback?.Invoke();
        }
    }
}
