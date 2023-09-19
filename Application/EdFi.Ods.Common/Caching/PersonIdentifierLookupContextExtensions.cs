// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Common.Caching;

public static class PersonIdentifierLookupContextExtensions
{
    public static async Task ResolveAllUniqueIds(this UniqueIdLookupsByUsiContext context, IPersonUniqueIdResolver resolver)
    {
        if (context == null || !context.Any())
        {
            return;
        }

        foreach (var kvp in context.UniqueIdByUsiByPersonType)
        {
            await resolver.ResolveUniqueIdsAsync(kvp.Key, kvp.Value);
        }
    }

    public static async Task ResolveAllUsis(this UsiLookupsByUniqueIdContext context, IPersonUsiResolver resolver)
    {
        if (context == null || !context.Any())
        {
            return;
        }

        foreach (var kvp in context.UsiByUniqueIdByPersonType)
        {
            await resolver.ResolveUsisAsync(kvp.Key, kvp.Value);
        }
    }
}
