// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries;

/// <summary>
/// Implements a decorator that applies limit/offset paging criteria to the query.
/// </summary>
public class PagedAggregateIdsCriteriaProviderLimitOffsetPagingDecorator : IAggregateRootQueryBuilderProvider
{
    private readonly IAggregateRootQueryBuilderProvider _decoratedInstance;
    private readonly int _defaultPageLimitSize;

    public PagedAggregateIdsCriteriaProviderLimitOffsetPagingDecorator(
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

        if (queryParameters.MinAggregateId == null)
        {
            queryBuilder.LimitOffset(queryParameters.Limit ?? _defaultPageLimitSize, queryParameters.Offset ?? 0);
        }

        return queryBuilder;
    }
}
