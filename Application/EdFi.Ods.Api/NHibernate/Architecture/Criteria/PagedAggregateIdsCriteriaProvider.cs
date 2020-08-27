// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using EdFi.Ods.Common.Caching;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Api.NHibernate.Architecture.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the Ids for the next page of data.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to build the query.</typeparam>
    public class PagedAggregateIdsCriteriaProvider<TEntity> : AggregateRootCriteriaProviderBase<TEntity>, IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        public PagedAggregateIdsCriteriaProvider(ISessionFactory sessionFactory, IDescriptorsCache descriptorsCache)
            : base(sessionFactory, descriptorsCache) { }

        /// <summary>
        /// Get a <see cref="ICriteria"/> query that retrieves the Ids for the next page of data.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The NHibernate <see cref="ICriteria"/> instance representing the query.</returns>
        public ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters)
        {
            var idQueryCriteria = Session.CreateCriteria<TEntity>("aggregateRoot")
                .SetProjection(Projections.Property("Id"))
                .SetFirstResult(queryParameters.Offset ?? 0)
                .SetMaxResults(queryParameters.Limit ?? 25);

            AddDefaultOrdering(idQueryCriteria);

            // Add specification-based criteria
            ProcessSpecification(idQueryCriteria, specification);

            // Add special query fields
            ProcessQueryParameters(idQueryCriteria, queryParameters);

            return idQueryCriteria;
        }

        private void AddDefaultOrdering(ICriteria queryCriteria)
        {
            var persister = (AbstractEntityPersister) SessionFactory.GetClassMetadata(typeof(TEntity));

            if (persister.IdentifierColumnNames != null && persister.IdentifierColumnNames.Length > 0)
            {
                foreach (var identifierColumnName in persister.IdentifierColumnNames)
                {
                    queryCriteria.AddOrder(Order.Asc(identifierColumnName));
                }
            }
            else
            {
                queryCriteria.AddOrder(Order.Asc("Id"));
            }
        }
    }
}