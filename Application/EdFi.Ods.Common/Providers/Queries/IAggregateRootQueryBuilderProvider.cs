﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Providers.Queries
{
    public interface IAggregateRootQueryBuilderProvider
    {
        /// <summary>
        /// Gets the <see cref="QueryBuilder" /> instance containing a query against an aggregate root entity.
        /// </summary>
        /// <param name="aggregateRootEntity"></param>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">Additional query parameters to be applied to the filtering.</param>
        /// <returns>The <see cref="QueryBuilder"/> instance representing the query.</returns>
        QueryBuilder GetQueryBuilder(
            Entity aggregateRootEntity,
            AggregateRootWithCompositeKey specification,
            IQueryParameters queryParameters);
    }
}