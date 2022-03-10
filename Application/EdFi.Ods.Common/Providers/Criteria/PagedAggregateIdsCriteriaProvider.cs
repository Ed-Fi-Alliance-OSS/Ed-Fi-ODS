// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Persister.Entity;

namespace EdFi.Ods.Common.Providers.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the Ids for the next page of data.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to build the query.</typeparam>
    public class PagedAggregateIdsCriteriaProvider<TEntity> : AggregateRootCriteriaProviderBase<TEntity>, IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        public PagedAggregateIdsCriteriaProvider(
            ISessionFactory sessionFactory, 
            IDescriptorsCache descriptorsCache, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(sessionFactory, descriptorsCache)
        {
            _identifierColumnNames = new Lazy<string[]>(
                () =>
                {
                    var persister = (AbstractEntityPersister) SessionFactory.GetClassMetadata(typeof(TEntity));

                    if (persister.IdentifierColumnNames != null && persister.IdentifierColumnNames.Length > 0)
                    {
                        return persister.IdentifierColumnNames;
                    }

                    return new[] { "Id" };
                });

            _defaultPageLimitSize = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
        }

        private readonly Lazy<string[]> _identifierColumnNames;
        private readonly int _defaultPageLimitSize;

        /// <summary>
        /// Get a <see cref="NHibernate.ICriteria"/> query that retrieves the Ids for the next page of data.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The NHibernate <see cref="NHibernate.ICriteria"/> instance representing the query.</returns>
        public ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters)
        {
            var idQueryCriteria = Session.CreateCriteria<TEntity>("aggregateRoot")
                .SetProjection(Projections.Distinct(GetColumnProjectionsForDistinctWithOrderBy()))
                .SetFirstResult(queryParameters.Offset ?? 0)
                .SetMaxResults(queryParameters.Limit ?? _defaultPageLimitSize);

            AddDefaultOrdering(idQueryCriteria);

            // Add specification-based criteria
            ProcessSpecification(idQueryCriteria, specification);

            // Add special query fields
            ProcessQueryParameters(idQueryCriteria, queryParameters);

            return idQueryCriteria;
            
            IProjection GetColumnProjectionsForDistinctWithOrderBy()
            {
                var projections = Projections.ProjectionList();
            
                // Add the resource identifier (this is the value we need for the secondary "page" query)
                projections.Add(Projections.Property("Id"));
            
                // Add the order by (primary key) columns (required when using DISTINCT with ORDER BY)
                foreach (var identifierColumnName in _identifierColumnNames.Value)
                {
                    projections.Add(Projections.Property(identifierColumnName));
                }

                return projections;
            }
        }

        private void AddDefaultOrdering(ICriteria queryCriteria)
        {
            foreach (var identifierColumnName in _identifierColumnNames.Value)
            {
                queryCriteria.AddOrder(Order.Asc(identifierColumnName));
            }
        }
    }
}