// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Caching;
using EdFi.Ods.Api.Common.IdentityValueMappers;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using log4net;

namespace EdFi.Ods.Security.Authorization
{
    public class EducationOrganizationCache : IEducationOrganizationCache
    {
        private const string CacheKeyPrefix = "EducationOrganizationCache_";
        private readonly ICacheProvider _cacheProvider;
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
        private readonly IEducationOrganizationCacheDataProvider _educationOrganizationIdentifiersProvider;
        private readonly IEducationOrganizationIdentifiersValueMapper _educationOrganizationIdentifiersValueMapper;

        private readonly object _identityValueMapsLock = new object();

        private readonly ILog _logger = LogManager.GetLogger(typeof(EducationOrganizationCache));
        private readonly bool _synchronousInitialization;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheProvider">The cache where the database-specific maps (dictionaries) are stored, expiring after 4 hours of inactivity.</param>
        /// <param name="edFiOdsInstanceIdentificationProvider">Identifies the ODS instance for the current call.</param>
        /// <param name="educationOrganizationIdentifiersValueMapper">A component that maps between USI and UniqueId values.</param>
        /// <param name="educationOrganizationIdentifiersProvider">A component that retrieves all education organization identifiers.</param>
        /// <param name="synchronousInitialization">Indicates whether the cache should wait until all the Person identifiers are loaded before responding, or if using the value mappers initially to avoid an initial delay is preferable.</param>
        public EducationOrganizationCache(
            ICacheProvider cacheProvider,
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider,
            IEducationOrganizationIdentifiersValueMapper educationOrganizationIdentifiersValueMapper,
            IEducationOrganizationCacheDataProvider educationOrganizationIdentifiersProvider,
            bool synchronousInitialization)
        {
            _cacheProvider = cacheProvider;
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
            _educationOrganizationIdentifiersValueMapper = educationOrganizationIdentifiersValueMapper;
            _educationOrganizationIdentifiersProvider = educationOrganizationIdentifiersProvider;
            _synchronousInitialization = synchronousInitialization;
        }

        /// <summary>
        /// Gets or sets the optional dependency for when the cache is being used in the scope of an HttpContext and
        /// specific context values (see <see cref="IHttpContextStorageTransferKeys"/>) must be transferred to CallContext for
        /// a worker thread to perform background initialization of the cache.
        /// </summary>
        public IHttpContextStorageTransfer HttpContextStorageTransfer { get; set; }

        /// <summary>
        /// Finds the <see cref="EducationOrganizationIdentifiers"/> for the specified <paramref name="educationOrganizationId"/>.
        /// </summary>
        /// <param name="educationOrganizationId">The generic Education Organization identifier for which to search.</param>
        /// <returns>The matching <see cref="EducationOrganizationIdentifiers"/>.</returns>
        public EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(int educationOrganizationId)
        {
            if (educationOrganizationId == default(int))
            {
                return null;
            }

            string context = GetEdOrgIdKeyTokenContext();

            string key = GetEducationOrganizationIdentifiersByEducationOrganizationIdCacheKey(educationOrganizationId, context);

            EducationOrganizationIdentifiers educationOrganizationIdentifiers;

            // Get the cache first, initializing it if necessary
            var educationOrganizationIdentifiersByEducationOrganizationId =
                GetEducationOrganizationIdentifiersByEducationOrganizationIdMap(context);

            // Check the cache for the value
            if (educationOrganizationIdentifiersByEducationOrganizationId != null &&
                educationOrganizationIdentifiersByEducationOrganizationId.TryGetValue(
                    key,
                    out educationOrganizationIdentifiers))
            {
                return educationOrganizationIdentifiers;
            }

            // Call the value mapper for the individual value
            // With the change to use NHibernate, this query will return a null object instead of an empty object.
            var valueMap = GetEducationOrganizationIdentifiersFromEducationOrganizationId(educationOrganizationId);

            // Save the value
            if (valueMap != null)
            {
                educationOrganizationIdentifiersByEducationOrganizationId?.TryAdd(key, valueMap);

                //NOTE: Add the reverse cache back in when support for StateOrganizations is added.
                //GetEducationOrganizationIdentifiersByStateOrganizationIdMap(context).AddOrUpdate(GetEducationOrganizationIdentifiersByStateOrganizationIdCacheKey(valueMap.), educationOrganizationId, (x, y) => educationOrganizationId);
            }

            return valueMap;
        }

        private ConcurrentDictionary<string, EducationOrganizationIdentifiers>
            GetEducationOrganizationIdentifiersByEducationOrganizationIdMap(
            string context)
        {
            EducationOrganizationValueMaps identityValueMaps;

            if (!TryGetEducationOrganizationValueMaps(context, out identityValueMaps))
            {
                return null;
            }

            return identityValueMaps.EducationOrganizationIdentifiersByEducationOrganizationId;
        }

        private ConcurrentDictionary<string, EducationOrganizationIdentifiers>
            GetEducationOrganizationIdentifiersByStateOrganizationIdMap(
            string context)
        {
            EducationOrganizationValueMaps identityValueMaps;

            if (!TryGetEducationOrganizationValueMaps(context, out identityValueMaps))
            {
                return null;
            }

            return identityValueMaps.EducationOrganizationIdentifiersByStateOrganizationId;
        }

        private bool TryGetEducationOrganizationValueMaps(string context, out EducationOrganizationValueMaps identityValueMaps)
        {
            object educationOrganizationCacheAsObject;

            string cacheKey = GetEducationOrganizationCacheKey(context);

            if (!_cacheProvider.TryGetCachedObject(cacheKey, out educationOrganizationCacheAsObject))
            {
                // Make sure there is only one cache set being initialized at a time
                lock (_identityValueMapsLock)
                {
                    // Make sure that the entry still doesn't exist yet
                    if (!_cacheProvider.TryGetCachedObject(cacheKey, out educationOrganizationCacheAsObject))
                    {
                        var newValueMaps = new EducationOrganizationValueMaps();

                        //Put the initialization task on the cached object so that we know the initialization status by cache entry key
                        //Even if/when the cache provider storage changes context
                        newValueMaps.InitializationTask = InitializeEducationOrganizationValueMaps(newValueMaps, context);

                        //Initial Insert is for while async initialization is running.
                        _cacheProvider.Insert(cacheKey, newValueMaps, DateTime.MaxValue, TimeSpan.FromMinutes(5));

                        _cacheProvider.TryGetCachedObject(cacheKey, out educationOrganizationCacheAsObject);
                    }
                }
            }

            identityValueMaps = educationOrganizationCacheAsObject as EducationOrganizationValueMaps;

            if (identityValueMaps == null)
            {
                return false;
            }

            if (_synchronousInitialization
                && (identityValueMaps.EducationOrganizationIdentifiersByEducationOrganizationId == null
                    || identityValueMaps.EducationOrganizationIdentifiersByStateOrganizationId == null))
            {
                // Wait for the initialization task to complete
                identityValueMaps.InitializationTask.WaitSafely();

                //If initialization failed, return false.
                if (identityValueMaps.EducationOrganizationIdentifiersByEducationOrganizationId == null
                    || identityValueMaps.EducationOrganizationIdentifiersByStateOrganizationId == null)
                {
                    return false;
                }

                // With initialization complete, try again (using a single recursive call)
                return TryGetEducationOrganizationValueMaps(context, out identityValueMaps);
            }

            return true;
        }

        private Task InitializeEducationOrganizationValueMaps(EducationOrganizationValueMaps entry, string context)
        {
            // In web application scenarios, copy pertinent context from HttpContext to CallContext
            if (HttpContextStorageTransfer != null)
            {
                HttpContextStorageTransfer.TransferContext();
            }

            var task = InitializeEducationOrganizationValueMapsAsync(entry, context);

            if (task.Status == TaskStatus.Created)
            {
                task.Start();
            }

            return task;
        }

        private async Task InitializeEducationOrganizationValueMapsAsync(EducationOrganizationValueMaps entry, string context)
        {
            // Unhandled exceptions here will take down the ASP.NET process
            try
            {
                // Start building the data
                var educationOrganizationIdentifiersByStateOrganizationId =
                    new ConcurrentDictionary<string, EducationOrganizationIdentifiers>();

                var educationOrganizationIdentifiersByEducationOrganizationId =
                    new ConcurrentDictionary<string, EducationOrganizationIdentifiers>();

                Stopwatch stopwatch = null;

                if (_logger.IsDebugEnabled)
                {
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                }

                foreach (
                    var valueMap in
                    await
                        _educationOrganizationIdentifiersProvider.GetAllEducationOrganizationIdentifiers()
                            .ConfigureAwait(false))
                {
                    string key =
                        GetEducationOrganizationIdentifiersByEducationOrganizationIdCacheKey(
                            valueMap.EducationOrganizationId,
                            context);

                    educationOrganizationIdentifiersByEducationOrganizationId.TryAdd(key, valueMap);

                    //NOTE: future support for string based state org ids.
                    //string key2 = GetEducationOrganizationIdentifiersByStateOrganizationIdCacheKey(valueMap.StateOrganizationId, context);
                    //educationOrganizationIdentifiersByStateOrganizationId.TryAdd(key2, valueMap);
                }

                if (_logger.IsDebugEnabled)
                {
                    stopwatch.Stop();

                    _logger.DebugFormat(
                        "Education Organization Id cache initialized {0:n0} entries in {1:n0} milliseconds.",
                        educationOrganizationIdentifiersByEducationOrganizationId.Count,
                        stopwatch.ElapsedMilliseconds);
                }

                entry.SetMaps(
                    educationOrganizationIdentifiersByStateOrganizationId,
                    educationOrganizationIdentifiersByEducationOrganizationId);

                string cacheKey = GetEducationOrganizationCacheKey(context);

                //Now that it's loaded extend the cache expiration.
                _cacheProvider.Insert(cacheKey, entry, DateTime.MaxValue, TimeSpan.FromHours(4));
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(
                    "An exception occurred while trying to warm the EducationOrganizationCache. EducationOrganizationIdentifiers will be retrieved individually.\r\n{0}",
                    ex);
            }
        }

        private static string GetEducationOrganizationCacheKey(string context)
        {
            return CacheKeyPrefix + context;
        }

        private string GetEducationOrganizationIdentifiersByEducationOrganizationIdCacheKey(int educationOrganizationId)
        {
            return GetEducationOrganizationIdentifiersByEducationOrganizationIdCacheKey(
                educationOrganizationId, GetEdOrgIdKeyTokenContext());
        }

        private string GetEducationOrganizationIdentifiersByEducationOrganizationIdCacheKey(int educationOrganizationId,
            string context)
        {
            string key = string.Format(
                "{0}_{1}",
                educationOrganizationId,
                context);

            return key;
        }

        private EducationOrganizationIdentifiers GetEducationOrganizationIdentifiersFromEducationOrganizationId(
            int educationOrganizationId)
        {
            return _educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(educationOrganizationId);
        }

        private EducationOrganizationIdentifiers GetEducationOrganizationIdentifiersFromStateOrganizationId(
            string stateOrganizationId)
        {
            return _educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(stateOrganizationId);
        }

        private string GetEducationOrganizationIdentifiersByStateOrganizationIdCacheKey(string stateOrganizationId)
        {
            return GetEducationOrganizationIdentifiersByStateOrganizationIdCacheKey(
                stateOrganizationId, GetEdOrgIdKeyTokenContext());
        }

        private string GetEducationOrganizationIdentifiersByStateOrganizationIdCacheKey(string stateOrganizationId,
            string context)
        {
            return string.Format("education_organization_id_{0}_by_state_organization_id_{1}", context, stateOrganizationId);
        }

        private string GetEdOrgIdKeyTokenContext()
        {
            return string.Format("from_{0}", _edFiOdsInstanceIdentificationProvider.GetInstanceIdentification());
        }

        private class EducationOrganizationValueMaps
        {
            private readonly ReaderWriterLockSlim _mapLock = new ReaderWriterLockSlim();

            private ConcurrentDictionary<string, EducationOrganizationIdentifiers>
                _educationOrganizationIdentifiersByEducationOrganizationId;

            private ConcurrentDictionary<string, EducationOrganizationIdentifiers>
                _educationOrganizationIdentifiersByStateOrganizationId;

            public ConcurrentDictionary<string, EducationOrganizationIdentifiers>
                EducationOrganizationIdentifiersByStateOrganizationId
            {
                get
                {
                    if (_mapLock.TryEnterReadLock(0))
                    {
                        try
                        {
                            return _educationOrganizationIdentifiersByStateOrganizationId;
                        }
                        finally
                        {
                            _mapLock.ExitReadLock();
                        }
                    }

                    return null;
                }
            }

            public ConcurrentDictionary<string, EducationOrganizationIdentifiers>
                EducationOrganizationIdentifiersByEducationOrganizationId
            {
                get
                {
                    if (_mapLock.TryEnterReadLock(0))
                    {
                        try
                        {
                            return _educationOrganizationIdentifiersByEducationOrganizationId;
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
                ConcurrentDictionary<string, EducationOrganizationIdentifiers>
                    educationOrganizationIdentifiersByStateOrganizationId,
                ConcurrentDictionary<string, EducationOrganizationIdentifiers>
                    educationOrganizationIdentifiersByEducationOrganizationId)
            {
                try
                {
                    _mapLock.EnterWriteLock();

                    _educationOrganizationIdentifiersByStateOrganizationId =
                        educationOrganizationIdentifiersByStateOrganizationId;

                    _educationOrganizationIdentifiersByEducationOrganizationId =
                        educationOrganizationIdentifiersByEducationOrganizationId;
                }
                finally
                {
                    _mapLock.ExitWriteLock();
                }
            }
        }
    }
}
