// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.Api.Common.Infrastructure.Composites
{
    public static class ResultCardinalityExtensions
    {
        public static object ApplyCardinality(this IList<IDictionary> results, bool isSingleItemResult)
        {
            if (isSingleItemResult)
            {
                return results.FirstOrDefault();
            }

            return results;
        }
    }
}
