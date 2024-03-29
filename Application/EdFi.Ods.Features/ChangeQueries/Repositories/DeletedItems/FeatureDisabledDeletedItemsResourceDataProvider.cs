// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;

public class FeatureDisabledDeletedItemsResourceDataProvider : IDeletedItemsResourceDataProvider
{
    public Task<ResourceData<DeletedResourceItem>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters)
        => throw new FeatureDisabledException(ChangeQueriesConstants.FeatureName);
}
