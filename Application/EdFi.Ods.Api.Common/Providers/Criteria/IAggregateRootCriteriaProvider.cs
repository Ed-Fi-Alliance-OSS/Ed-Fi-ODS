// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using NHibernate;

namespace EdFi.Ods.Api.Common.Providers.Criteria
{
    /// <summary>
    /// Provides an abstraction for aggregate queries using the <see cref="ICriteria"/> API in NHibernate, primarily to
    /// provide a seam for authorization filtering by the AggregateRootCriteriaProviderDecorator class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which criteria is being applied.</typeparam>
    public interface IAggregateRootCriteriaProvider<in TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets the ICriteria for an NHibernate query.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The NHibernate <see cref="ICriteria"/> instance representing the query.</returns>
        ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters);
    }
}