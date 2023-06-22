// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Providers;
using EdFi.Ods.Common.Specifications;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.Caching
{
    public class PersonUniqueIdToUsiCache : IPersonUniqueIdToUsiCache
    {
        public const string CacheKeyPrefix = "IdentityValueMaps_";

        /// <summary>
        /// Gets or sets a static delegate to obtain the cache.
        /// </summary>
        /// <remarks>This method exists to serve the cache to the NHibernate-generated entities in a way
        /// that does not require IoC component resolution, for performance reasons.</remarks>
        public static Func<IPersonUniqueIdToUsiCache> GetCache = () => null;
        private readonly ICacheProvider<string> _cacheProvider;
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;

        private readonly ReaderWriterLockSlim _identityValueMapsLock = new ReaderWriterLockSlim();

        private readonly ILog _logger = LogManager.GetLogger(typeof(PersonUniqueIdToUsiCache));
        private readonly IPersonIdentifiersProvider _personIdentifiersProvider;
        private readonly IPersonEntitySpecification _personEntitySpecification;
        private readonly IPersonTypesProvider _personTypesProvider;
        private readonly IUniqueIdToUsiValueMapper _uniqueIdToUsiValueMapper;
        private readonly bool _synchronousInitialization;
        private readonly Dictionary<string, bool> _cacheSuppression;

        private readonly TimeSpan _slidingExpiration;
        private readonly TimeSpan _absoluteExpirationPeriod;

        /// <summary>
        /// Provides cached translations between UniqueIds and USI values.
        /// </summary>
        /// <param name="cacheProvider">The cache where the database-specific maps (dictionaries) are stored, expiring after 4 hours of inactivity.</param>
        /// <param name="edFiOdsInstanceIdentificationProvider">Identifies the ODS instance for the current call.</param>
        /// <param name="uniqueIdToUsiValueMapper">A component that maps between USI and UniqueId values.</param>
        /// <param name="personIdentifiersProvider">A component that retrieves all Person identifiers.</param>
        /// <param name="personEntitySpecification">A component that obtains the entity names of the known person types, and identifying whether various input arguments are referring to a person type or person identifier.</param>
        /// <param name="personTypesProvider">A component that obtains the names of the person type entities in the model.</param>
        /// <param name="slidingExpiration">Indicates how long the cache values will remain in memory after being used before all the cached values are removed.</param>
        /// <param name="absoluteExpirationPeriod">Indicates the maximum time that the cache values will remain in memory before being refreshed.</param>
        /// <param name="synchronousInitialization">Indicates whether the cache should wait until all the Person identifiers are loaded before responding, or if using the value mappers initially to avoid an initial delay is preferable.</param>
        /// <param name="cacheSuppression">Indicates whether caching of any of the person types should be suppressed (retrieved on-demand with each request).</param>
        public PersonUniqueIdToUsiCache(
            ICacheProvider<string> cacheProvider,
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider,
            IUniqueIdToUsiValueMapper uniqueIdToUsiValueMapper,
            IPersonIdentifiersProvider personIdentifiersProvider,
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider,
            TimeSpan slidingExpiration,
            TimeSpan absoluteExpirationPeriod,
            bool synchronousInitialization,
            Dictionary<string, bool> cacheSuppression)
        {
            _cacheProvider = cacheProvider;
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
            _uniqueIdToUsiValueMapper = uniqueIdToUsiValueMapper;
            _personIdentifiersProvider = personIdentifiersProvider;
            _personEntitySpecification = personEntitySpecification;
            _personTypesProvider = personTypesProvider;
            _synchronousInitialization = synchronousInitialization;
            _cacheSuppression = cacheSuppression;

            if (slidingExpiration < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(slidingExpiration), "TimeSpan cannot be a negative value.");
            }

            if (absoluteExpirationPeriod < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(absoluteExpirationPeriod), "TimeSpan cannot be a negative value.");
            }

            // Use sliding expiration value, if both are set.
            if (slidingExpiration > TimeSpan.Zero && absoluteExpirationPeriod > TimeSpan.Zero)
            {
                absoluteExpirationPeriod = TimeSpan.Zero;
            }

            _slidingExpiration = slidingExpiration;
            _absoluteExpirationPeriod = absoluteExpirationPeriod;
        }

        /// <summary>
        /// Gets the externally defined UniqueId for the specified type of person and the ODS-specific surrogate identifier.
        /// </summary>
        /// <param name="personType">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="usi">The integer-based identifier for the specified representation of the person,
        /// specific to a particular ODS database instance.</param>
        /// <returns>The UniqueId value assigned to the person if found; otherwise <b>null</b>.</returns>
        public string GetUniqueId(string personType, int usi)
        {
            if (usi == default)
            {
                return default;
            }

            if (_cacheSuppression.TryGetValue(personType, out bool isSuppressed) && isSuppressed)
            {
                // Call the value mapper for the individual value
                var uncachedValueMap = GetUniqueIdValueMap(personType, usi);

                return uncachedValueMap.UniqueId;
            }

            string context = GetUsiKeyTokenContext();

            // Get the cache first, initializing it if necessary
            var uniqueIdByUsi = GetUniqueIdByUsiMap(personType, context);

            // Check the cache for the value
            if (uniqueIdByUsi != null && uniqueIdByUsi.TryGetValue(usi, out string uniqueId))
            {
                return uniqueId;
            }

            // Call the value mapper for the individual value
            var valueMap = GetUniqueIdValueMap(personType, usi);

            // Save the value
            if (valueMap.UniqueId != null && uniqueIdByUsi != null)
            {
                uniqueIdByUsi.TryAdd(usi, valueMap.UniqueId);

                GetUsiByUniqueIdMap(personType, context)
                   .AddOrUpdate(valueMap.UniqueId, usi, (x, y) => usi);
            }

            return valueMap.UniqueId;
        }

        /// <summary>
        /// Gets the ODS-specific integer identifier for the specified type of person and their UniqueId value.
        /// </summary>
        /// <param name="personType">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="uniqueId">The UniqueId value associated with the person.</param>
        /// <returns>The ODS-specific integer identifier for the specified type of representation of
        /// the person if found; otherwise 0.</returns>
        public int GetUsi(string personType, string uniqueId)
        {
            var usi = GetUsi(personType, uniqueId, false);
            return usi.GetValueOrDefault();
        }

        /// <summary>
        /// Gets the ODS-specific integer identifier for the specified type of person and their UniqueId value.
        /// </summary>
        /// <param name="personTypeName">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="uniqueId">The UniqueId value associated with the person.</param>
        /// <returns>The ODS-specific integer identifier for the specified type of representation of
        /// the person if found; otherwise <b>null</b>.</returns>
        public int? GetUsiNullable(string personTypeName, string uniqueId)
        {
            var usi = GetUsi(personTypeName, uniqueId, true);

            return usi is default(int) ? null : usi;
        }

        private ConcurrentDictionary<int, string> GetUniqueIdByUsiMap(string personType, string context)
        {
            if (!TryGetIdentityValueMaps(personType, context, out IdentityValueMaps identityValueMaps))
            {
                return null;
            }

            return identityValueMaps.UniqueIdByUsi;
        }

        private ConcurrentDictionary<string, int> GetUsiByUniqueIdMap(string personType, string context)
        {
            if (!TryGetIdentityValueMaps(personType, context, out IdentityValueMaps identityValueMaps))
            {
                return null;
            }

            return identityValueMaps.UsiByUniqueId;
        }

        private bool TryGetIdentityValueMaps(string personType, string context, out IdentityValueMaps identityValueMaps)
        {
            string cacheKey = GetPersonTypeIdentifiersCacheKey(personType, context);

            if (!_cacheProvider.TryGetCachedObject(cacheKey, out object personCacheAsObject))
            {
                // Make sure there is only one cache set being initialized at a time
                lock (_identityValueMapsLock)
                {
                    // Make sure that the entry still doesn't exist yet
                    if (!_cacheProvider.TryGetCachedObject(cacheKey, out personCacheAsObject))
                    {
                        var newValueMaps = new IdentityValueMaps();

                        //Put the initialization task on the cached object so that we know the initialization status by cache entry key
                        //Even if/when the cache provider storage changes context
                        newValueMaps.InitializationTask = InitializePersonTypeValueMaps(newValueMaps, personType, context);

                        //Initial Insert is for while async initialization is running.
                        _cacheProvider.Insert(cacheKey, newValueMaps, GetAbsoluteExpiration(), _slidingExpiration);

                        _cacheProvider.TryGetCachedObject(cacheKey, out personCacheAsObject);
                    }
                }
            }

            identityValueMaps = personCacheAsObject as IdentityValueMaps;

            if (identityValueMaps == null)
            {
                return false;
            }

            if (_synchronousInitialization
                && (identityValueMaps.UniqueIdByUsi == null
                    || identityValueMaps.UsiByUniqueId == null))
            {
                // Wait for the initialization task to complete
                identityValueMaps.InitializationTask.WaitSafely();

                //If initialization failed, return false.
                if (identityValueMaps.UniqueIdByUsi == null
                    || identityValueMaps.UsiByUniqueId == null)
                {
                    return false;
                }

                // With initialization complete, try again (using a single recursive call)
                return TryGetIdentityValueMaps(personType, context, out identityValueMaps);
            }

            return true;
        }

        private Task InitializePersonTypeValueMaps(IdentityValueMaps entry, string personType, string context)
        {
            // Validate Person type
            if (!_personEntitySpecification.IsPersonEntity(personType))
            {
                throw new ArgumentException(
                    string.Format(
                        "Invalid person type '{0}'. Valid person types are: '{1}'",
                        personType,
                        string.Join("','", _personTypesProvider.PersonTypes)));
            }

            var task = InitializePersonTypeValueMapsAsync(entry, personType, context);

            if (task.Status == TaskStatus.Created)
            {
                task.Start();
            }

            return task;
        }

        private async Task InitializePersonTypeValueMapsAsync(IdentityValueMaps entry, string personType, string context)
        {
            // Un-handled exceptions here will take down the ASP.NET process
            try
            {
                // Start building the data
                var uniqueIdByUsi = new ConcurrentDictionary<int, string>();
                var usiByUniqueId = new ConcurrentDictionary<string, int>();

                Stopwatch stopwatch = null;

                if (_logger.IsDebugEnabled)
                {
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                }

                foreach (
                    var valueMap in await _personIdentifiersProvider.GetAllPersonIdentifiers(personType))
                {
                    uniqueIdByUsi.TryAdd(valueMap.Usi, valueMap.UniqueId);
                    usiByUniqueId.TryAdd(valueMap.UniqueId, valueMap.Usi);
                }

                if (_logger.IsDebugEnabled)
                {
                    stopwatch.Stop();

                    _logger.DebugFormat(
                        "UniqueId/USI cache for {0} initialized {1:n0} entries in {2:n0} milliseconds.",
                        personType,
                        uniqueIdByUsi.Count,
                        stopwatch.ElapsedMilliseconds);
                }

                entry.SetMaps(usiByUniqueId, uniqueIdByUsi);
                string cacheKey = GetPersonTypeIdentifiersCacheKey(personType, context);

                //Now that it's loaded extend the cache expiration.
                _cacheProvider.Insert(cacheKey, entry, GetAbsoluteExpiration(), _slidingExpiration);
            }
            catch (Exception ex)
            {
                _logger.Error(
                    "An exception occurred while trying to warm the PersonCache. UniqueIds will be retrieved individually.",
                    ex);
            }
        }

        private DateTime GetAbsoluteExpiration() => _absoluteExpirationPeriod == TimeSpan.Zero
            ? DateTime.MaxValue
            : DateTime.UtcNow.Add(_absoluteExpirationPeriod);

        private static string GetPersonTypeIdentifiersCacheKey(string personType, string context)
        {
            return CacheKeyPrefix + personType + "_" + context;
        }

        private PersonIdentifiersValueMap GetUniqueIdValueMap(string personTypeName, int usi)
        {
            return _uniqueIdToUsiValueMapper.GetUniqueId(personTypeName, usi);
        }

        private PersonIdentifiersValueMap GetUsiValueMap(string personTypeName, string uniqueId)
        {
            return _uniqueIdToUsiValueMapper.GetUsi(personTypeName, uniqueId);
        }

        private int? GetUsi(string personType, string uniqueId, bool isNullable)
        {
            if (string.IsNullOrWhiteSpace(uniqueId))
            {
                return isNullable
                    ? default(int?)
                    : default(int);
            }

            if (_cacheSuppression.TryGetValue(personType, out bool isSuppressed) && isSuppressed)
            {
                var uncachedValueMap = GetUsiValueMap(personType, uniqueId);

                return uncachedValueMap.Usi;
            }

            string context = GetUsiKeyTokenContext();

            // Get the cache first, initializing it if necessary
            var usiByUniqueId = GetUsiByUniqueIdMap(personType, context);

            _logger.DebugFormat(
                "For person type: {0}, there are {1} records cached.",
                personType,
                usiByUniqueId?.Count ?? 0);

            // Check the cache for the value
            if (usiByUniqueId != null && usiByUniqueId.TryGetValue(uniqueId, out int usi))
            {
                if (usi != default(int))
                {
                    return usi;
                }
            }

            var valueMap = GetUsiValueMap(personType, uniqueId);

            // Save the value
            if (usiByUniqueId != null && valueMap.Usi != default(int))
            {
                usiByUniqueId.TryAdd(uniqueId, valueMap.Usi);

                GetUniqueIdByUsiMap(personType, context)
                   .AddOrUpdate(valueMap.Usi, uniqueId, (x, y) => uniqueId);
            }

            return valueMap.Usi;
        }

        private string GetUsiKeyTokenContext()
        {
            return $"from_{_edFiOdsInstanceIdentificationProvider.GetInstanceIdentification()}";
        }

        public class IdentityValueMaps
        {
            private readonly ReaderWriterLockSlim _mapLock = new();

            [JsonProperty]
            private ConcurrentDictionary<int, string> _uniqueIdByUsi;

            [JsonProperty]
            private ConcurrentDictionary<string, int> _usiByUniqueId;

            public ConcurrentDictionary<int, string> UniqueIdByUsi
            {
                get
                {
                    if (_mapLock.TryEnterReadLock(0))
                    {
                        try
                        {
                            return _uniqueIdByUsi;
                        }
                        finally
                        {
                            _mapLock.ExitReadLock();
                        }
                    }

                    return null;
                }
            }

            public ConcurrentDictionary<string, int> UsiByUniqueId
            {
                get
                {
                    if (_mapLock.TryEnterReadLock(0))
                    {
                        try
                        {
                            return _usiByUniqueId;
                        }
                        finally
                        {
                            _mapLock.ExitReadLock();
                        }
                    }

                    return null;
                }
            }

            [JsonIgnore]
            public Task InitializationTask { get; set; }

            public void SetMaps(
                ConcurrentDictionary<string, int> usiByUniqueId,
                ConcurrentDictionary<int, string> uniqueIdByUsi)
            {
                try
                {
                    _mapLock.EnterWriteLock();
                    _usiByUniqueId = usiByUniqueId;
                    _uniqueIdByUsi = uniqueIdByUsi;
                }
                finally
                {
                    _mapLock.ExitWriteLock();
                }
            }
        }
    }
}