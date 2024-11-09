// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Infrastructure.Repositories;

public class StudentSurrogateKeyResolver : ISurrogateKeyResolver
{
    private readonly IPersonUsiResolver _personUsiResolver;

    public StudentSurrogateKeyResolver(IPersonUsiResolver personUsiResolver)
    {
        _personUsiResolver = personUsiResolver;
    }

    public async Task<bool> TryResolveKeyAsync(Entity entity, object instance)
    {
        if (instance is IPersonUsiMutator personMutator)
        {
            int usi = personMutator.GetUsi();

            // If already resolved, quit resolution process now
            if (usi != 0)
            {
                return true;
            }

            // Perform cache-based resolution of USI value
            string uniqueId = personMutator.UniqueId;

            var lookups = new Dictionary<string, int>() { { uniqueId, 0 } };

            await _personUsiResolver.ResolveUsisAsync(entity.Name, lookups);

            int resolvedUsi = lookups[uniqueId];

            if (resolvedUsi == 0)
            {
                // This should never happen
                throw new Exception($"The '{entity.Name}UniqueId' value of '{uniqueId}' could not be resolved.");
            }
                
            personMutator.SetUsi(resolvedUsi);

            return true;
        }

        return false;
    }
}
