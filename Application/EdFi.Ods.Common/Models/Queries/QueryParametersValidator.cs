// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Queries;

public class QueryParametersValidator
{
    public static bool IsValid(QueryParameters queryParameters, int defaultPageLimitSize, out string errorMessage)
    {
        errorMessage = string.Empty;

        // Check if offset/limit paging is being used
        bool isOffsetLimitPagingProvided = queryParameters.Offset.HasValue || queryParameters.Limit.HasValue;

        // Check if key set paging is being used
        bool isKeySetPagingProvided = queryParameters.PageSize.HasValue
            || queryParameters.MinAggregateId.HasValue
            || queryParameters.MaxAggregateId.HasValue;

        // Ensure that only one type of paging is provided
        if (isOffsetLimitPagingProvided && isKeySetPagingProvided)
        {
            errorMessage =
                "Both offset/limit and key set paging parameters are provided, but only one type of paging can be used.";

            return false;
        }

        // // Validate offset/limit paging: if one parameter is provided, both must be provided
        if (isOffsetLimitPagingProvided)
        {
            if ((queryParameters.Offset ?? 0) < 0)
            {
                errorMessage = $"Offset cannot be a negative value.";
                return false;
            }
            
            if ((queryParameters.Limit ?? 0) < 0 || (queryParameters.Limit ?? defaultPageLimitSize) > defaultPageLimitSize)
            {
                errorMessage = $"Limit must be omitted or set to a value between 0 and {defaultPageLimitSize}.";
                return false;
            }
        }

        // Validate key set paging: if one parameter is provided, all must be provided
        if (isKeySetPagingProvided)
        {
            if (!queryParameters.PageSize.HasValue
                || !queryParameters.MinAggregateId.HasValue
                || !queryParameters.MaxAggregateId.HasValue)
            {
                errorMessage = "Page token and page size must both be provided for key set paging.";

                return false;
            }
        }

        return true;
    }
}
