// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Ods.Api.IdentityValueMappers;
using log4net;

namespace EdFi.Ods.Api.Caching;

public class PersonMapCacheInitializer : IPersonMapCacheInitializer
{
    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), string, int> _usiByUniqueIdMapCache;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType, PersonMapType mapType), int, string> _uniqueIdByUsiMapCache;

    private readonly ConcurrentDictionary<(ulong odsInstanceHashId, string personType), Task>
        _initializationTaskByOdsPersonType = new();

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

    public Task EnsurePersonMapsInitialized(ulong odsInstanceHashId, string personType)
    {
        var initializationTask = _initializationTaskByOdsPersonType.GetOrAdd(
            (odsInstanceHashId, personType),
            key =>
            {
                var (hashId, pt) = key;
                
                return Task.Run(() => _personIdentifiersProvider.GetAllPersonIdentifiers(pt))
                    .ContinueWith(
                        t =>
                        {
                            if (t.IsFaulted)
                            {
                                _logger.Error($"Unable to load '{personType}' mappings from ODS (with OdsInstanceHashId '{hashId}').", t.Exception);
                            }
                            else if (t.IsCompletedSuccessfully)
                            {
                                var uniqueIdByUsiCacheEntries = t.Result
                                    .Select(v => (v.Usi, v.UniqueId))
                                    .ToArray();

                                var usiByUniqueIdCacheEntries = t.Result
                                    .Select(v => (v.UniqueId, v.Usi))
                                    .ToArray();

                                // Set the retrieved tuples into the cache
                                _uniqueIdByUsiMapCache.SetMapEntries((key.odsInstanceHashId, key.personType, PersonMapType.UniqueIdByUsi), uniqueIdByUsiCacheEntries);
                                _usiByUniqueIdMapCache.SetMapEntries((key.odsInstanceHashId, key.personType, PersonMapType.UsiByUniqueId), usiByUniqueIdCacheEntries);
                            }
                        });
            });

        // If the task was found as completed, release the reference so it can garbage collected
        if (initializationTask?.IsCompleted == true)
        {
            _initializationTaskByOdsPersonType.TryUpdate((odsInstanceHashId, personType), null, initializationTask);

            return null;
        }

        return initializationTask;
    } 
}
