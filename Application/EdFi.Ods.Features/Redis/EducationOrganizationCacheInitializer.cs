// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Common.Caching;
using log4net;

namespace EdFi.Ods.Features.Redis
{
    public class EducationOrganizationCacheInitializer : IEducationOrganizationCacheInitializer
    {
        private readonly IEducationOrganizationCacheDataProvider _educationOrganizationIdentifiersProvider;

        private readonly ConcurrentDictionary<string, bool> _initializationsInProgress =
            new ConcurrentDictionary<string, bool>();
        private readonly ILog _logger = LogManager.GetLogger(typeof(EducationOrganizationCacheInitializer));
        private readonly IRedisCacheProvider _redisCacheProvider;

        public EducationOrganizationCacheInitializer(
            IEducationOrganizationCacheDataProvider educationOrganizationIdentifiersProvider,
            IRedisCacheProvider redisCacheProvider)
        {
            _educationOrganizationIdentifiersProvider = educationOrganizationIdentifiersProvider;
            _redisCacheProvider = redisCacheProvider;
        }

        public async Task InitializeAsync(string cacheKey)
        {
            if (!_initializationsInProgress.TryAdd(cacheKey, true))
            {
                return;
            }

            await InitializeEducationOrganizationValueMapsAsync(cacheKey);

            _initializationsInProgress.TryRemove(cacheKey, out bool _);
        }

        private async Task InitializeEducationOrganizationValueMapsAsync(string cacheKey)
        {
            try
            {
                var educationOrganizationIdentifiersByEducationOrganizationId =
                    new Dictionary<string, EducationOrganizationIdentifiers>();

                Stopwatch stopwatch = null;

                if (_logger.IsDebugEnabled)
                {
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                }

                foreach (var valueMap in await _educationOrganizationIdentifiersProvider
                             .GetAllEducationOrganizationIdentifiers()
                             .ConfigureAwait(false))
                {
                    educationOrganizationIdentifiersByEducationOrganizationId.TryAdd(
                        valueMap.EducationOrganizationId.ToString(),
                        valueMap);
                }

                if (_logger.IsDebugEnabled)
                {
                    stopwatch.Stop();

                    _logger.DebugFormat(
                        "Education organization cache for {0} initialized {1:n0} entries in {2:n0} milliseconds.",
                        cacheKey,
                        educationOrganizationIdentifiersByEducationOrganizationId.Count,
                        stopwatch.ElapsedMilliseconds);
                }

                _redisCacheProvider.Insert(
                    cacheKey,
                    educationOrganizationIdentifiersByEducationOrganizationId,
                    DateTime.MaxValue,
                    TimeSpan.FromHours(4));
            }
            catch (Exception ex)
            {
                _logger.Error(
                    "An exception occurred while trying to warm the Education Organization Cache",
                    ex);
            }
        }
    }
}
