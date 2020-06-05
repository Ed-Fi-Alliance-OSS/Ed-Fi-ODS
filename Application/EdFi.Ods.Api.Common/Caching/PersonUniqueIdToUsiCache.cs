// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Specifications;
using log4net;

namespace EdFi.Ods.Api.Common.Caching
{
    public class PersonUniqueIdToUsiCache : IPersonUniqueIdToUsiCache
    {
        private const string CacheKeyPrefix = "IdentityValueMaps_";

        /// <summary>
        /// Gets or sets a static delegate to obtain the cache.
        /// </summary>
        /// <remarks>This method exists to serve the cache to the NHibernate-generated entities in a way
        /// that does not require IoC component resolution, for performance reasons.</remarks>
        public static Func<IPersonUniqueIdToUsiCache> GetCache = () => null;
        private readonly ICacheProvider _cacheProvider;
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;

        private readonly ReaderWriterLockSlim _identityValueMapsLock = new ReaderWriterLockSlim();

        private readonly ILog _logger = LogManager.GetLogger(typeof(PersonUniqueIdToUsiCache));
        private readonly IPersonIdentifiersProvider _personIdentifiersProvider;
        private readonly bool _synchronousInitialization;
        private readonly IUniqueIdToUsiValueMapper _uniqueIdToUsiValueMapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheProvider">The cache where the database-specific maps (dictionaries) are stored, expiring after 4 hours of inactivity.</param>
        /// <param name="edFiOdsInstanceIdentificationProvider">Identifies the ODS instance for the current call.</param>
        /// <param name="uniqueIdToUsiValueMapper">A component that maps between USI and UniqueId values.</param>
        /// <param name="personIdentifiersProvider">A component that retrieves all Person identifiers.</param>
        /// <param name="synchronousInitialization">Indicates whether the cache should wait until all the Person identifiers are loaded before responding, or if using the value mappers initially to avoid an initial delay is preferable.</param>
        public PersonUniqueIdToUsiCache(
            ICacheProvider cacheProvider,
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider,
            IUniqueIdToUsiValueMapper uniqueIdToUsiValueMapper,
            IPersonIdentifiersProvider personIdentifiersProvider,
            bool synchronousInitialization)
        {
            _cacheProvider = cacheProvider;
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
            _uniqueIdToUsiValueMapper = uniqueIdToUsiValueMapper;
            _personIdentifiersProvider = personIdentifiersProvider;
            _synchronousInitialization = synchronousInitialization;
        }

        /// <summary>
        /// Gets or sets the optional dependency for when the cache is being used in the scope of an HttpContext and
        /// specific context values (see <see cref="IHttpContextStorageTransferKeys"/>) must be transferred to CallContext for
        /// a worker thread to perform background initialization of the cache.
        /// </summary>
        public IHttpContextStorageTransfer HttpContextStorageTransfer { get; set; }

        /// <summary>
        /// Gets the externally defined UniqueId for the specified type of person and the ODS-specific surrogate identifier.
        /// </summary>
        /// <param name="personType">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="usi">The integer-based identifier for the specified representation of the person, 
        /// specific to a particular ODS database instance.</param>
        /// <returns>The UniqueId value assigned to the person if found; otherwise <b>null</b>.</returns>
        public string GetUniqueId(string personType, int usi)
        {
            if (usi == default(int))
            {
                return default(string);
            }

            string context = GetUsiKeyTokenContext();

            string key = GetUniqueIdByUsiCacheKey(personType, usi, context);

            string uniqueId;

            // Get the cache first, initializing it if necessary
            var uniqueIdByUsi = GetUniqueIdByUsiMap(personType, context);

            // Check the cache for the value
            if (uniqueIdByUsi != null && uniqueIdByUsi.TryGetValue(key, out uniqueId))
            {
                return uniqueId;
            }

            // Call the value mapper for the individual value
            var valueMap = GetUniqueIdValueMap(personType, usi);

            // Save the value
            if (valueMap.UniqueId != null && uniqueIdByUsi != null)
            {
                uniqueIdByUsi.TryAdd(key, valueMap.UniqueId);

                GetUsiByUniqueIdMap(personType, context)
                   .AddOrUpdate(GetUsiByUniqueIdCacheKey(personType, valueMap.UniqueId), usi, (x, y) => usi);
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

            return usi.HasValue && usi.Value == default(int)
                ? null
                : usi;
        }

        private ConcurrentDictionary<string, string> GetUniqueIdByUsiMap(string personType, string context)
        {
            IdentityValueMaps identityValueMaps;

            if (!TryGetIdentityValueMaps(personType, context, out identityValueMaps))
            {
                return null;
            }

            return identityValueMaps.UniqueIdByUsi;
        }

        private ConcurrentDictionary<string, int> GetUsiByUniqueIdMap(string personType, string context)
        {
            IdentityValueMaps identityValueMaps;

            if (!TryGetIdentityValueMaps(personType, context, out identityValueMaps))
            {
                return null;
            }

            return identityValueMaps.UsiByUniqueId;
        }

        private bool TryGetIdentityValueMaps(string personType, string context, out IdentityValueMaps identityValueMaps)
        {
            object personCacheAsObject;

            string cacheKey = GetPersonTypeIdentifiersCacheKey(personType, context);

            if (!_cacheProvider.TryGetCachedObject(cacheKey, out personCacheAsObject))
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
                        _cacheProvider.Insert(cacheKey, newValueMaps, DateTime.MaxValue, TimeSpan.FromMinutes(5));

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
            if (!PersonEntitySpecification.IsPersonEntity(personType))
            {
                throw new ArgumentException(
                    string.Format(
                        "Invalid person type '{0}'. Valid person types are: {1}",
                        personType,
                        "'" + string.Join("','", PersonEntitySpecification.ValidPersonTypes) + "'"));
            }

            // In web application scenarios, copy pertinent context from HttpContext to CallContext
            if (HttpContextStorageTransfer != null)
            {
                HttpContextStorageTransfer.TransferContext();
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
                var uniqueIdByUsi = new ConcurrentDictionary<string, string>();
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
                    string key = GetUniqueIdByUsiCacheKey(personType, valueMap.Usi, context);
                    uniqueIdByUsi.TryAdd(key, valueMap.UniqueId);

                    string key2 = GetUsiByUniqueIdCacheKey(personType, valueMap.UniqueId, context);
                    usiByUniqueId.TryAdd(key2, valueMap.Usi);
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
                _cacheProvider.Insert(cacheKey, entry, DateTime.MaxValue, TimeSpan.FromHours(4));
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(
                    "An exception occurred while trying to warm the PersonCache. UniqueIds will be retrieved individually.\r\n{0}",
                    ex);
            }
        }

        private static string GetPersonTypeIdentifiersCacheKey(string personType, string context)
        {
            return CacheKeyPrefix + personType + "_" + context;
        }

        private string GetUniqueIdByUsiCacheKey(string personType, int usi)
        {
            return GetUniqueIdByUsiCacheKey(personType, usi, GetUsiKeyTokenContext());
        }

        private string GetUniqueIdByUsiCacheKey(string personType, int usi, string context)
        {
            string key = string.Format(
                "{0}_{1}_{2}",
                personType,
                usi,
                context);

            return key;
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

            string context = GetUsiKeyTokenContext();

            string key = GetUsiByUniqueIdCacheKey(personType, uniqueId, context);

            int usi;

            // Get the cache first, initializing it if necessary
            var usiByUniqueId = GetUsiByUniqueIdMap(personType, context);

            _logger.DebugFormat(
                "For person type: {0}, there are {1} records cached.",
                personType,
                usiByUniqueId != null
                    ? usiByUniqueId.Count
                    : 0);

            // Check the cache for the value
            if (usiByUniqueId != null && usiByUniqueId.TryGetValue(key, out usi))
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
                usiByUniqueId.TryAdd(key, valueMap.Usi);

                GetUniqueIdByUsiMap(personType, context)
                   .AddOrUpdate(GetUniqueIdByUsiCacheKey(personType, valueMap.Usi), uniqueId, (x, y) => uniqueId);
            }

            //NOTE: This code is here for future use.
            //// Handle opportunistic cache value assignment of alternate value
            //if (valueMap.Id != default(Guid))
            //{
            //    var extraEntyKey = string.Format("{0}{1}_id_by_uniqueid_{2}", CacheKeyPrefix, personTypeName, uniqueId);

            //    if (!_cacheProvider.TryGetCachedObject(extraEntyKey, out obj))
            //        _cacheProvider.Insert(extraEntyKey, valueMap.Id, DateTime.MaxValue, _cacheItemPolicy.SlidingExpiration);
            //}

            return valueMap.Usi;
        }

        private string GetUsiByUniqueIdCacheKey(string personTypeName, string uniqueId)
        {
            return GetUsiByUniqueIdCacheKey(personTypeName, uniqueId, GetUsiKeyTokenContext());
        }

        private string GetUsiByUniqueIdCacheKey(string personTypeName, string uniqueId, string context)
        {
            return string.Format("{0}_usi_{1}_by_uniqueid_{2}", personTypeName, context, uniqueId);
        }

        private string GetUsiKeyTokenContext()
        {
            return string.Format((string) "from_{0}", (object) _edFiOdsInstanceIdentificationProvider.GetInstanceIdentification());
        }

        private class IdentityValueMaps
        {
            private readonly ReaderWriterLockSlim _mapLock = new ReaderWriterLockSlim();

            private ConcurrentDictionary<string, string> _uniqueIdByUsi;

            private ConcurrentDictionary<string, int> _usiByUniqueId;

            public ConcurrentDictionary<string, string> UniqueIdByUsi
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

            public Task InitializationTask { get; set; }

            public void SetMaps(
                ConcurrentDictionary<string, int> usiByUniqueId,
                ConcurrentDictionary<string, string> uniqueIdByUsi)
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
