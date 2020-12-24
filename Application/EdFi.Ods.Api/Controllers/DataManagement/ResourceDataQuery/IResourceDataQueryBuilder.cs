// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Api.Controllers.DataManagement.ResponseBuilding;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourceDataQuery
{
    /// <summary>
    /// Defines a method for building the queries needed to retrieve all the data for specified resource.
    /// </summary>
    public interface IResourceDataQueryBuilder
    {
        IEnumerable<ResourceClassQuery> BuildQueries(
            Resource resource,
            IDictionary<string, object> primaryKeyValues = null);
    }
}
