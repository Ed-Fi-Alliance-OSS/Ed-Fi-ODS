// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Providers;

namespace EdFi.Ods.Features.UniqueIdIntegration.Caching
{
 public class PersonUniqueIdToIdCache : IPersonUniqueIdToIdCache
    {
        private const string CacheKeyPrefix = "PersonIdentifiers.";
        public const string IdByUniqueIdFormatter = "{0}{1}_id_by_uniqueid_{2}";
        public const string UniqueIdByIdFormatter = "{0}{1}_uniqueid_by_id_{2}";

        private readonly ICacheProvider<string> _cacheProvider;
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
        private readonly IUniqueIdToIdValueMapper _uniqueIdToIdValueMapper;
        private readonly TimeSpan _slidingExpiration;

        public PersonUniqueIdToIdCache(
            ICacheProvider<string> cacheProvider,
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider,
            IUniqueIdToIdValueMapper uniqueIdToIdValueMapper,
            int cacheExpirationMinutes = 10)
        {
            _cacheProvider = cacheProvider;
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
            _uniqueIdToIdValueMapper = uniqueIdToIdValueMapper;
            _slidingExpiration = new TimeSpan(0, cacheExpirationMinutes, 0);
        }

        /// <summary>
        /// Gets the GUID-based identifier for the specified type of person and their UniqueId value.
        /// </summary>
        /// <param name="personTypeName">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="uniqueId">The UniqueId value associated with the person.</param>
        /// <returns>The GUID-based identifier for the person; otherwise the default GUID value.</returns>
        public Guid GetId(string personTypeName, string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(uniqueId))
            {
                return default;
            }

            string key = string.Format(IdByUniqueIdFormatter, CacheKeyPrefix, personTypeName, uniqueId);

            if (_cacheProvider.TryGetCachedObject(key, out object obj))
            {
                return (Guid) obj;
            }

            var valueMap = _uniqueIdToIdValueMapper.GetId(personTypeName, uniqueId);

            // Save the primary value
            if (valueMap.Id != default(Guid))
            {
                _cacheProvider.Insert(key, valueMap.Id, DateTime.MaxValue, _slidingExpiration);

                string idToUniqueIdKey = string.Format(UniqueIdByIdFormatter, CacheKeyPrefix, personTypeName, valueMap.Id);

                if (!_cacheProvider.TryGetCachedObject(idToUniqueIdKey, out obj))
                {
                    _cacheProvider.Insert(idToUniqueIdKey, uniqueId, DateTime.MaxValue, _slidingExpiration);
                }
            }

            return valueMap.Id;
        }

        /// <summary>
        /// Gets the externally defined UniqueId for the specified type of person and the GUID-based identifier.
        /// </summary>
        /// <param name="personTypeName">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="id">The GUID-based identifier for the person.</param>
        /// <returns>The UniqueId value assigned to the person if found; otherwise <b>null</b>.</returns>
        public string GetUniqueId(string personTypeName, Guid id)
        {
            if (id == default)
            {
                return default;
            }

            string key = string.Format(UniqueIdByIdFormatter, CacheKeyPrefix, personTypeName, id);

            if (_cacheProvider.TryGetCachedObject(key, out object obj))
            {
                return (string) obj;
            }

            var valueMap = _uniqueIdToIdValueMapper.GetUniqueId(personTypeName, id);

            // Save the primary value
            if (valueMap.UniqueId != null)
            {
                _cacheProvider.Insert(key, valueMap.UniqueId, DateTime.MaxValue, _slidingExpiration);
            }

            return valueMap.UniqueId;
        }
    }
}