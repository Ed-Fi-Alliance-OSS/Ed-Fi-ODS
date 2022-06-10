// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Models.Queries;

namespace EdFi.Ods.Common.Models.Validation
{
    public static class UrlQueryParametersRequestExtensions
    {
        public static IEnumerable<string> Validate(this UrlQueryParametersRequest urlQueryParametersRequest, int defaultPageLimitSize)
        {
            if (urlQueryParametersRequest.Limit != null &&
                (urlQueryParametersRequest.Limit < 0 || urlQueryParametersRequest.Limit > defaultPageLimitSize))
            {
                yield return $"Limit must be omitted or set to a value between 1 and {defaultPageLimitSize}.";
            }

            if ((urlQueryParametersRequest.Offset ?? 0) < 0)
            {
                yield return $"Offset must be greater than or equal to 0.";
            }
        }
    }
}
