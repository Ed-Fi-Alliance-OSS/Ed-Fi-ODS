// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Caching;

/// <summary>
/// Stores the context of all the UniqueIds for the USIs that need to be resolved during the current request.
/// </summary>
public class UsiLookupsByUniqueIdContext : PersonIdentifierLookupContextBase<string, int>
{
    public IDictionary<string, IDictionary<string, int>> UsiByUniqueIdByPersonType
    {
        get => ValuesByPersonType;
    }
}
