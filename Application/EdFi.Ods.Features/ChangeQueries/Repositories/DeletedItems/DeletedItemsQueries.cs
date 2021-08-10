// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueries
    {
        public DeletedItemsQueries(Query dataQuery, Query countQuery)
        {
            DataQuery = dataQuery;
            CountQuery = countQuery;
        }

        public Query DataQuery { get; }
        
        public Query CountQuery { get; }
    }
}
