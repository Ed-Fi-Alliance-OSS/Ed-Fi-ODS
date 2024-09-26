// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;

namespace EdFi.Ods.Common.Providers.Queries.Paging;

/// <summary>
/// Applies key set paging criteria to a query.
/// </summary>
public class KeySetPagingStrategy : IPagingStrategy
{
    private readonly int _defaultPageLimitSize;

    public KeySetPagingStrategy(IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
    {
        _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
    }

    public void ApplyPaging(QueryBuilder queryBuilder, PagingParameters pagingParameters)
    {
        if (pagingParameters.PagingStrategy == PagingStrategy.KeySet)
        {
            queryBuilder.WhereBetween(
                "AggregateId",
                pagingParameters.MinAggregateId,
                pagingParameters.MaxAggregateId,
                "@MinAggregateId",
                "@MaxAggregateId");

            var pageSize = pagingParameters.PageSize ?? _defaultPageLimitSize;

            queryBuilder.LimitOffset(pageSize, 0, "@Limit", "@Offset");
        }
    }

    public void ApplyPagingParameters(IDictionary<string, object> parameters, PagingParameters pagingParameters)
    {
        if (pagingParameters.PagingStrategy == PagingStrategy.KeySet)
        {
            parameters["@MinAggregateId"] = pagingParameters.MinAggregateId;
            parameters["@MaxAggregateId"] = pagingParameters.MaxAggregateId;
            parameters["@Offset"] = 0;
            parameters["@Limit"] = pagingParameters.PageSize ?? _defaultPageLimitSize;
        }
    }
}
