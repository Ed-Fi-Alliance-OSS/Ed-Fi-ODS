// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Api.IdentityValueMappers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching;

public class PersonUniqueIdResolver : IPersonUniqueIdResolver
{
    private readonly IMapCache<(ulong odsInstanceHashId, string personType), int, string> _mapCache;

    private readonly IPersonMapCacheInitializer _personMapCacheInitializer;
    private readonly IPersonIdentifiersProvider _personIdentifiersProvider;
    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;

    public PersonUniqueIdResolver(
        IPersonMapCacheInitializer personMapCacheInitializer,
        IPersonIdentifiersProvider personIdentifiersProvider,
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong odsInstanceHashId, string personType), int, string> mapCache)
    {
        _personMapCacheInitializer = personMapCacheInitializer;
        _personIdentifiersProvider = personIdentifiersProvider;
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _mapCache = mapCache;
    }

    public async Task ResolveUniqueIds(string personType, IDictionary<int, string> lookups)
    {
        ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;

        // Ensure cache initialization of the entire UniqueId/USI map for the ODS
        var initializationTask = _personMapCacheInitializer.InitializePersonMaps(odsInstanceHashId, personType);

        ICollection<int> usisToLoad = null;
        var suppliedLookupUsis = lookups.Keys.ToArray();

        // If the cache initialization has completed, use the cache to resolve the values first
        if (initializationTask == null || initializationTask.IsCompleted)
        {
            // Resolve uniqueIds from the map cache
            var resolvedUniqueIds = _mapCache.GetMapItems((odsInstanceHashId, personType), suppliedLookupUsis);

            // Assign resolved values to the supplied dictionary
            resolvedUniqueIds.ForEach(
                (uniqueId, i) =>
                {
                    if (uniqueId != default)
                    {
                        lookups[suppliedLookupUsis[i]] = uniqueId;
                    }
                    else
                    {
                        // Need to look up from the ODS
                        AddUniqueIdToLoad(suppliedLookupUsis[i]);
                    }
                });

            void AddUniqueIdToLoad(int usi)
            {
                if (usisToLoad == null)
                {
                    usisToLoad = new List<int>();
                }
            
                usisToLoad.Add(usi);
            }
        }

        // If not initialized, then all the supplied lookup USIs must be loaded
        usisToLoad ??= suppliedLookupUsis;
        
        // If there are any values that still need to be loaded directly from the ODS...
        if (usisToLoad.Any())
        {
            var results = await _personIdentifiersProvider.GetPersonUniqueIds(personType, usisToLoad.ToArray());
            
            // await using var conn = _dbProviderFactory.CreateConnection();
            //
            // conn.ConnectionString = _odsDatabaseConnectionStringProvider.GetReadReplicaConnectionString()
            //     ?? _odsDatabaseConnectionStringProvider.GetConnectionString();
            //
            // await conn.OpenAsync();
            //
            // var results = await conn.QueryAsync<UniqueIdUsiTuple>(
            //     $"select {personType}UniqueId as UniqueId, {personType}Usi as Usi from edfi.{personType}");

            foreach (var result in results)
            {
                lookups[result.Usi] = result.UniqueId;
            }
            
            // TODO: We may need to validate that all values have been resolved, though this may be more important for UniqueId to USI (PUT/POST requests)
        }
    }
}
