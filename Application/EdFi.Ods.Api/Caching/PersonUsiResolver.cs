// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Caching;

public class PersonUsiResolver : IPersonUsiResolver
{
    private readonly IMapCache<(ulong odsInstanceHashId, string personType), string, int> _mapCache;

    private readonly IContextProvider<OdsInstanceConfiguration> _odsInstanceConfigurationContextProvider;

    public PersonUsiResolver(
        IContextProvider<OdsInstanceConfiguration> odsInstanceConfigurationContextProvider,
        IMapCache<(ulong, string), string, int> mapCache)
    {
        _odsInstanceConfigurationContextProvider = odsInstanceConfigurationContextProvider;
        _mapCache = mapCache;
    }
    
    public Task ResolveUsis(string personType, IDictionary<string, int> lookups)
    {
        var keys = lookups.Keys.ToArray();
        ulong odsInstanceHashId = _odsInstanceConfigurationContextProvider.Get().OdsInstanceHashId;
        
        var resolvedUsis = _mapCache.GetMapItems((odsInstanceHashId, personType), keys);

        resolvedUsis.ForEach(
            (usi, i) =>
            {
                if (usi != default)
                {
                    lookups[keys[i]] = usi;
                }
            });

        return Task.CompletedTask;
    }
}
