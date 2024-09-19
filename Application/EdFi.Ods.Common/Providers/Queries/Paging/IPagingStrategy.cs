// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Database.Querying;

namespace EdFi.Ods.Common.Providers.Queries.Paging;

public interface IPagingStrategy
{
    /// <summary>
    /// Applies the paging strategy to the provided query.
    /// </summary>
    /// <param name="queryBuilder"></param>
    /// <param name="pagingParameters"></param>
    void ApplyPaging(QueryBuilder queryBuilder, PagingParameters pagingParameters);
    
    /// <summary>
    /// Applies the paging parameter values to a previously built and cloned query.
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="pagingParameters"></param>
    void ApplyPagingParameters(IDictionary<string, object> parameters, PagingParameters pagingParameters);
}
