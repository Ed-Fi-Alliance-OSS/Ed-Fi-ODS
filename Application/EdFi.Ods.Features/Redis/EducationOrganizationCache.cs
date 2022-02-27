// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Providers;

namespace EdFi.Ods.Features.Redis
{
    public class EducationOrganizationCache : IEducationOrganizationCache
    {
        private const string CacheKeyPrefix = "EducationOrganizationCache_";
        private readonly IEdFiOdsInstanceIdentificationProvider _edFiOdsInstanceIdentificationProvider;
        private readonly IEducationOrganizationCacheInitializer
            _educationOrganizationCacheInitializer;
        private readonly IEducationOrganizationIdentifiersValueMapper
            _educationOrganizationIdentifiersValueMapper;
        private readonly IRedisCacheProvider _redisCacheProvider;

        /// <summary>
        /// Provides cached values for education organizations.
        /// </summary>
        /// <param name="redisCacheProvider">The cache where the database-specific maps (dictionaries) are stored, expiring after 4 hours of inactivity.</param>
        /// <param name="edFiOdsInstanceIdentificationProvider">Identifies the ODS instance for the current call.</param>
        /// <param name="educationOrganizationIdentifiersValueMapper">A component that gets the identifier values for a given state organization id value.</param>
        /// <param name="educationOrganizationCacheInitializer">A component that initializes the cache with education organization values for certain context based on id</param>
        public EducationOrganizationCache(
            IRedisCacheProvider redisCacheProvider,
            IEdFiOdsInstanceIdentificationProvider edFiOdsInstanceIdentificationProvider,
            IEducationOrganizationIdentifiersValueMapper educationOrganizationIdentifiersValueMapper,
            IEducationOrganizationCacheInitializer educationOrganizationCacheInitializer)
        {
            _redisCacheProvider = redisCacheProvider;
            _edFiOdsInstanceIdentificationProvider = edFiOdsInstanceIdentificationProvider;
            _educationOrganizationIdentifiersValueMapper = educationOrganizationIdentifiersValueMapper;
            _educationOrganizationCacheInitializer = educationOrganizationCacheInitializer;
        }

        /// <summary>
        /// Finds the <see cref="EducationOrganizationIdentifiers"/> for the specified <paramref name="educationOrganizationId"/>.
        /// </summary>
        /// <param name="educationOrganizationId">The generic Education Organization identifier for which to search.</param>
        /// <returns>The matching <see cref="EducationOrganizationIdentifiers"/>.</returns>
        public EducationOrganizationIdentifiers GetEducationOrganizationIdentifiers(
            int educationOrganizationId)
        {
            if (educationOrganizationId == default)
            {
                return null;
            }

            string outerKey = GetEducationOrganizationCacheKey();
            string innerKey = educationOrganizationId.ToString();

            if (_redisCacheProvider.TryGetCachedObjectFromHash(
                    outerKey,
                    innerKey,
                    out EducationOrganizationIdentifiers educationOrganizationIdentifiers))
            {
                return educationOrganizationIdentifiers;
            }

            if (!_redisCacheProvider.KeyExists(outerKey))
            {
                _educationOrganizationCacheInitializer.InitializeAsync(outerKey);
            }

            var valueMap =
                GetEducationOrganizationIdentifiersFromEducationOrganizationId(educationOrganizationId);

            if (valueMap != null)
            {
                _redisCacheProvider.InsertToHash(outerKey, innerKey, valueMap);
            }

            return valueMap;
        }

        private string GetEducationOrganizationCacheKey()
        {
            return
                $"{CacheKeyPrefix}from_{_edFiOdsInstanceIdentificationProvider.GetInstanceIdentification()}";
        }

        private EducationOrganizationIdentifiers
            GetEducationOrganizationIdentifiersFromEducationOrganizationId(
            int educationOrganizationId)
        {
            return _educationOrganizationIdentifiersValueMapper.GetEducationOrganizationIdentifiers(
                educationOrganizationId);
        }
    }
}
