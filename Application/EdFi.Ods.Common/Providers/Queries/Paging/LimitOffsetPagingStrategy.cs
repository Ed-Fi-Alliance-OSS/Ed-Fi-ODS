// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;

namespace EdFi.Ods.Common.Providers.Queries.Paging;

/// <summary>
/// Applies limit/offset paging criteria to a query.
/// </summary>
public class LimitOffsetPagingStrategy : IPagingStrategy
{
    private readonly int _defaultPageLimitSize;

    public LimitOffsetPagingStrategy(IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
    {
        _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
    }

    public void ApplyPaging(QueryBuilder queryBuilder, PagingParameters pagingParameters)
    {
        if (pagingParameters.PagingStrategy == PagingStrategy.LimitOffset)
        {
            queryBuilder.LimitOffset(pagingParameters.Limit ?? _defaultPageLimitSize, pagingParameters.Offset ?? 0);
        }
    }
    
    public void ApplyPagingParameters(IDictionary<string, object> parameters, PagingParameters pagingParameters)
    {
        if (pagingParameters.PagingStrategy == PagingStrategy.LimitOffset)
        {
            parameters["@Offset"] = pagingParameters.Offset ?? 0;
            parameters["@Limit"] = pagingParameters.Limit ?? _defaultPageLimitSize;
        }
    }
}
