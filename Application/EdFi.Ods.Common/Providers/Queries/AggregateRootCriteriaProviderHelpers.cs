// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.Common.Providers.Criteria;

internal static class AggregateRootCriteriaProviderHelpers
{
    private static string[] _uniqueIds;

    public static string[] GetUniqueIdProperties(IPersonTypesProvider personTypesProvider)
    {
        return _uniqueIds ??= personTypesProvider.PersonTypes.Select(pt => $"{pt}UniqueId").ToArray();
    }

    public static readonly string[] PropertiesToIgnore =
    {
        "Offset",
        "Limit",
        "TotalCount",
        "Q",
        "SortBy",
        "SortDirection"
    };
}
