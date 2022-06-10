// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.Querying;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class TrackedChangesQueryTemplates
    {
        public TrackedChangesQueryTemplates(SqlBuilder.Template dataQueryTemplate, SqlBuilder.Template countQueryTemplate)
        {
            DataQueryTemplate = dataQueryTemplate;
            CountQueryTemplate = countQueryTemplate;
        }

        /// <summary>
        /// Gets the main driving query for the results (i.e. a query that should be filtered for authorization purposes).
        /// </summary>
        public SqlBuilder.Template DataQueryTemplate { get; }
        
        /// <summary>
        /// Gets the count query for the results (i.e. a query that should be filtered for authorization purposes).
        /// </summary>
        public SqlBuilder.Template CountQueryTemplate { get; }
    }
}
