// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using log4net;

namespace EdFi.Ods.Api.Caching.Person;

public class PersonMapCacheInitializer : IPersonMapCacheInitializer
{
    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> _usiByUniqueIdMapCache;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> _uniqueIdByUsiMapCache;

    private readonly ILog _logger = LogManager.GetLogger(typeof(PersonMapCacheInitializer));

    public PersonMapCacheInitializer(
        IPersonIdentifiersProvider personIdentifiersProvider,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> uniqueIdByUsiMapCache,
        IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> usiByUniqueIdMapCache)
    {
        _personIdentifiersProvider = personIdentifiersProvider;
        _usiByUniqueIdMapCache = usiByUniqueIdMapCache;
        _uniqueIdByUsiMapCache = uniqueIdByUsiMapCache;
    }

    /// <inheritdoc cref="IPersonMapCacheInitializer.InitializePersonMapAsync" />
    public Task InitializePersonMapAsync(ulong odsInstanceHashId, string personType)
    {
        Stopwatch sw = null;

        return Task.Run(async () =>
            {
                if (_logger.IsDebugEnabled)
                {
                    _logger.Debug($"Starting '{personType}' cache initialization for ODS instance '{odsInstanceHashId}'...");

                    sw = new Stopwatch();
                    sw.Start();
                }

                var result = await _personIdentifiersProvider.GetAllPersonIdentifiersAsync(personType);

                if (_logger.IsDebugEnabled)
                {
                    if (result is ICollection<PersonIdentifiersValueMap> countableResult)
                    {
                        _logger.Debug($"Obtained {countableResult.Count:N0} '{personType}' identifiers after {sw.ElapsedMilliseconds:N0} ms...");
                    }
                    else
                    {
                        _logger.Debug($"Obtained all '{personType}' identifiers after {sw.ElapsedMilliseconds:N0} ms...");
                    }
                }

                return result;
            })
            .ContinueWith(
                async t =>
                {
                    if (t.IsFaulted)
                    {
                        _logger.Error(
                            $"Unable to load '{personType}' mappings from ODS (with OdsInstanceHashId '{odsInstanceHashId}').",
                            t.Exception);
                    }
                    else if (t.IsCompletedSuccessfully)
                    {
                        if (_logger.IsDebugEnabled)
                        {
                            _logger.Debug($"Setting '{personType}' map entries into cache for ODS instance '{odsInstanceHashId}'...");
                        }

                        var uniqueIdByUsiCacheEntries = t.Result.Select(v => (v.Usi, v.UniqueId))
                            .Concat(
                                new[]
                                {
                                    (InitializedReservedKeyForUsi: CacheInitializationConstants.InitializationMarkerKeyForUsi,
                                        InitializedKeyForUniqueId: CacheInitializationConstants.InitializationMarkerKeyForUniqueId)
                                })
                            .ToArray();

                        var usiByUniqueIdCacheEntries = t.Result.Select(v => (v.UniqueId, v.Usi))
                            .Concat(
                                new[]
                                {
                                    (InitializedKeyForUniqueId: CacheInitializationConstants.InitializationMarkerKeyForUniqueId,
                                        InitializedReservedKeyForUsi: CacheInitializationConstants.InitializationMarkerKeyForUsi)
                                })
                            .ToArray();

                        // Set the retrieved tuples into the cache
                        try
                        {
                            await Task.WhenAll(
                                _uniqueIdByUsiMapCache.SetMapEntriesAsync(
                                    (odsInstanceHashId, personType, PersonMapType.UniqueIdByUsi),
                                    uniqueIdByUsiCacheEntries),
                                _usiByUniqueIdMapCache.SetMapEntriesAsync(
                                    (odsInstanceHashId, personType, PersonMapType.UsiByUniqueId),
                                    usiByUniqueIdCacheEntries));
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("An error occurred while setting UniqueId/USI entries into the cache.", ex);
                        }

                        if (_logger.IsDebugEnabled)
                        {
                            sw.Stop();
                            
                            _logger.Debug($"Completed background cache initialization of {uniqueIdByUsiCacheEntries.Length:N0} {personType} entries for ODS instance '{odsInstanceHashId}' in {sw.ElapsedMilliseconds:N0} ms...");
                        }
                    }
                });
    } 
}
