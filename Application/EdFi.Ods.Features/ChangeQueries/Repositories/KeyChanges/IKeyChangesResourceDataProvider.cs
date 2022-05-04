// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Resources;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    /// <summary>
    /// Defines a method for obtaining the data needed to provide a response to a key changes API request.
    /// </summary>
    public interface IKeyChangesResourceDataProvider
    {
        Task<ResourceData<KeyChange>> GetResourceDataAsync(Resource resource, IQueryParameters queryParameters);
    }
}
