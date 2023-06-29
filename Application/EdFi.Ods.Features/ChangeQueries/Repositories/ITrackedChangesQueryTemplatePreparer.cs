// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    /// <summary>
    /// Defines a method for preparing the queries for a tracked changes request.
    /// </summary>
    public interface ITrackedChangesQueryTemplatePreparer
    {
        TrackedChangesQueryTemplates PrepareQueryTemplates(
            IQueryParameters queryParameters,
            Resource resource);
    }
}
