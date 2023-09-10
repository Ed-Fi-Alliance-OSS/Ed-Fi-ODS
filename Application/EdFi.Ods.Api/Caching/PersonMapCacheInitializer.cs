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
    private readonly IMapCache<(ulong odsInstanceHashId, string personType), string, int> _usiByUniqueIdMapCache;
    private readonly IMapCache<(ulong odsInstanceHashId, string personType), int, string> _uniqueIdByUsiMapCache;

    private readonly ConcurrentDictionary<(ulong odsInstanceHashId, string personType), Task>
        _initializationTaskByOdsPersonType = new();

    private readonly ILog _logger = LogManager.GetLogger(typeof(PersonMapCacheInitializer));
    
    public PersonMapCacheInitializer(
        IPersonIdentifiersProvider personIdentifiersProvider,
        IMapCache<(ulong odsInstanceHashId, string personType), int, string> uniqueIdByUsiMapCache,
        IMapCache<(ulong odsInstanceHashId, string personType), string, int> usiByUniqueIdMapCache)
    {
        _personIdentifiersProvider = personIdentifiersProvider;
        _usiByUniqueIdMapCache = usiByUniqueIdMapCache;
        _uniqueIdByUsiMapCache = uniqueIdByUsiMapCache;
    }

    public Task InitializePersonMaps(ulong odsInstanceHashId, string personType)
    {
        var initializationTask = _initializationTaskByOdsPersonType.GetOrAdd(
            (odsInstanceHashId, personType),
            key =>
            {
                return Task.Run(() => _personIdentifiersProvider.GetAllPersonIdentifiers(key.personType))
                    .ContinueWith(
                        x =>
                        {
                            if (x.IsFaulted)
                            {
                                _logger.Error($"Unable to load '{personType}' mappings from ODS (hashId={odsInstanceHashId}).", x.Exception);
                            }
                            else if (x.IsCompletedSuccessfully)
                            {
                                var uniqueIdByUsiCacheEntries = x.Result
                                    .Select(v => (v.Usi, v.UniqueId))
                                    .ToArray();

                                var usiByUniqueIdCacheEntries = x.Result
                                    .Select(v => (v.UniqueId, v.Usi))
                                    .ToArray();

                                // Set the retrieved tuples into the cache
                                _uniqueIdByUsiMapCache.SetMapItems(key, uniqueIdByUsiCacheEntries);
                                _usiByUniqueIdMapCache.SetMapItems(key, usiByUniqueIdCacheEntries);
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
