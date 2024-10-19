// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Providers.Queries.Paging;

namespace EdFi.Ods.Common.Models.Queries;

public static class QueryParametersValidator
{
    public static bool IsValid(IQueryParameters queryParameters, int defaultPageLimitSize, out string errorMessage)
    {
        errorMessage = null;

        // Look for multiple paging approaches indicated by parameters
        if (queryParameters.Offset.HasValue
            && (queryParameters.MinAggregateId.HasValue || queryParameters.MaxAggregateId.HasValue))
        {
            errorMessage = "Both offset and pageToken parameters were provided, but they support alternative paging approaches and cannot be used together.";

            return false;
        }

        // Determine which paging strategy is in use
        var pagingStrategy = queryParameters.MinAggregateId.HasValue || queryParameters.MaxAggregateId.HasValue
            ? PagingStrategy.KeySet
            : PagingStrategy.LimitOffset;

        if (pagingStrategy == PagingStrategy.LimitOffset)
        {
            // Validate basic parameter usage
            if (queryParameters.PageSize.HasValue && !queryParameters.Limit.HasValue)
            {
                if (queryParameters.Offset.HasValue)
                {
                    errorMessage = "pageSize cannot be used with limit/offset paging.";
                }
                else
                {
                    errorMessage = "pageToken is required when pageSize is specified.";
                }

                return false;
            }

            // Validate the values provided
            if (queryParameters.Offset is < 0)
            {
                errorMessage = $"offset cannot be a negative value.";
                return false;
            }

            if (queryParameters.Limit is < 0)
            {
                errorMessage = $"limit cannot be a negative value.";
                return false;
            }

            if (queryParameters.Limit.HasValue && queryParameters.Limit > defaultPageLimitSize)
            {
                errorMessage = $"limit cannot be greater than {defaultPageLimitSize}.";
                return false;
            }
        }
        else
        {
            // Cursor paging
            if (queryParameters.Limit.HasValue && !queryParameters.PageSize.HasValue)
            {
                errorMessage = "Use pageSize instead of limit when using cursor paging with pageToken.";
                return false;
            }

            // Validate the values provided
            if (queryParameters.PageSize is < 0)
            {
                errorMessage = $"pageSize cannot be a negative value.";
                return false;
            }

            if (queryParameters.PageSize.HasValue && queryParameters.PageSize > defaultPageLimitSize)
            {
                errorMessage = $"pageSize cannot be greater than {defaultPageLimitSize}.";
                return false;
            }
        }

        return true;
    }
}
