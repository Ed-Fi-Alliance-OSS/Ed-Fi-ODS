// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Security.Authorization;

public static class QueryBuilderFilterStrategyExtensions
{
    public static void SetQueryBuilderFilterStrategy(this IDictionary<string, object> queryBuilderContext, QueryBuilderFilterStrategy strategy)
    {
        queryBuilderContext[nameof(QueryBuilderFilterStrategy)] = strategy;
    }

    public static bool UsesCteFilterStrategy(this IDictionary<string, object> queryBuilderContext)
    {
        return ((queryBuilderContext.TryGetValue(nameof(QueryBuilderFilterStrategy), out var strategyAsObject)
            && strategyAsObject is QueryBuilderFilterStrategy.CTEs));
    }
    
    public static bool UsesJoinFilterStrategy(this IDictionary<string, object> queryBuilderContext)
    {
        return ((queryBuilderContext.TryGetValue(nameof(QueryBuilderFilterStrategy), out var strategyAsObject)
            && strategyAsObject is QueryBuilderFilterStrategy.Joins));
    }

    public static bool UsesExistsSubqueryFilterStrategy(this IDictionary<string, object> queryBuilderContext)
    {
        return ((queryBuilderContext.TryGetValue(nameof(QueryBuilderFilterStrategy), out var strategyAsObject)
            && strategyAsObject is QueryBuilderFilterStrategy.ExistsSubquery));
    }
}
