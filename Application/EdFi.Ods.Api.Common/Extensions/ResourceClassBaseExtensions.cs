// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Common.Extensions
{
    public static class ResourceClassBaseExtensions
    {
        public static bool IsSingleItemRequest(
            this ResourceClassBase currentResourceClass,
            IList<KeyValuePair<string, object>> queryStringParameters)
        {
            // Detect GetById request (for single item result)
            bool isRequestById = queryStringParameters.Any(kvp => kvp.Key.EqualsIgnoreCase("id"));

            // Detect GetByKey request (for single item result)
            bool isRequestByKey = currentResourceClass
                                 .IdentifyingProperties
                                 .All(p => queryStringParameters.Any(x => p.PropertyName.EqualsIgnoreCase(x.Key)));

            return isRequestById || isRequestByKey;
        }
    }
}
