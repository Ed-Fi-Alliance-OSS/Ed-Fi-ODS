// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Common;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public interface IDeletedItemsQueriesProvider
    {
        DeletedItemsQueries GetQueries(DbConnection connection, Resource resource, IQueryParameters queryParameters);
    }
}
