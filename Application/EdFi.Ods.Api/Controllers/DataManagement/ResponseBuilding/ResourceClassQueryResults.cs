// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding
{
    public class ResourceClassQueryResults
    {
        public ResourceClassQueryResults(ResourceClassBase resourceClass, List<object> results)
        {
            ResourceClass = resourceClass;
            Results = results.Cast<IDictionary<string, object>>().ToList();
        }
            
        public ResourceClassBase ResourceClass { get; }
            
        public IList<IDictionary<string, object>> Results { get; }
    }
}
