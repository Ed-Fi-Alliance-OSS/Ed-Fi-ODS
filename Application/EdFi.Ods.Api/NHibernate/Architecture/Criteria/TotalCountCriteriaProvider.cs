// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using NHibernate;
using NHibernate.Criterion;

namespace EdFi.Ods.Api.NHibernate.Architecture.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the total count of resource items available to the current caller.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which criteria is being applied.</typeparam>
    public class TotalCountCriteriaProvider<TEntity> : AggregateRootCriteriaProviderBase<TEntity>, ITotalCountCriteriaProvider<TEntity>
        where TEntity : class
    {
        public TotalCountCriteriaProvider(ISessionFactory sessionFactory, IDescriptorsCache descriptorsCache)
            : base(sessionFactory, descriptorsCache) { }

        /// <summary>
        /// Get a <see cref="ICriteria"/> query that retrieves the total count of resource items available to the current caller.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The NHibernate <see cref="ICriteria"/> instance representing the query.</returns>
        public ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters)
        {
            var countQueryCriteria = Session
                .CreateCriteria<TEntity>("aggregateRoot")
                .SetProjection(Projections.RowCountInt64());

            return countQueryCriteria;
        }
    }
}