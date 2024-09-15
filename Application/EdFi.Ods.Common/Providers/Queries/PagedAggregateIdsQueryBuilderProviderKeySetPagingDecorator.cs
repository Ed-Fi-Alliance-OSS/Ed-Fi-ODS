// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries;

/// <summary>
/// Implements a decorator that applies keyset paging criteria to the query.
/// </summary>
public class PagedAggregateIdsQueryBuilderProviderKeySetPagingDecorator : IAggregateRootQueryBuilderProvider
{
    private readonly IAggregateRootQueryBuilderProvider _decoratedInstance;
    private readonly int _defaultPageLimitSize;

    public PagedAggregateIdsQueryBuilderProviderKeySetPagingDecorator(
        IAggregateRootQueryBuilderProvider decoratedInstance,
        IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
    {
        _decoratedInstance = decoratedInstance;
        _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
    }

    public QueryBuilder GetQueryBuilder(
        Entity aggregateRootEntity,
        AggregateRootWithCompositeKey specification,
        IQueryParameters queryParameters)
    {
        var queryBuilder = _decoratedInstance.GetQueryBuilder(aggregateRootEntity, specification, queryParameters);

        if (queryParameters.MinAggregateId != null)
        {
            queryBuilder.WhereBetween("AggregateId", queryParameters.MinAggregateId, queryParameters.MaxAggregateId);

            var limit = queryParameters.Limit ?? _defaultPageLimitSize;

            queryBuilder.LimitOffset(limit);
        }

        return queryBuilder;
    }
}
