// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database.Querying;

namespace EdFi.Ods.Common.Providers.Criteria
{
    /// <summary>
    /// Defines a method for building a query that retrieves the Ids for the next page of data.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which criteria is being applied.</typeparam>
    public interface IPagedAggregateIdsCriteriaProvider<in TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets the <see cref="QueryBuilder" /> instance containing the query for getting the requested paged of data.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The <see cref="QueryBuilder"/> instance representing the query.</returns>
        QueryBuilder GetQueryBuilder(TEntity specification, IQueryParameters queryParameters);        
    }
}
