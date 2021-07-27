// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Resource;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    // TODO: GKM - Should we even include the query collection for this resource?
    public interface IDeletedItemsResourceDataProvider
    {
        Task<DeletedItemsResourceData> GetResourceDataAsync(
            Resource resource,
            IQueryParameters queryParameters,
            IQueryCollection query);
    }
}
