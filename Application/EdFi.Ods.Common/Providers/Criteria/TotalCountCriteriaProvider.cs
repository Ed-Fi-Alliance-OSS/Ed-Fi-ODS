﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;
using NHibernate;
using NHibernate.Criterion;

namespace EdFi.Ods.Common.Providers.Criteria
{
    /// <summary>
    /// Builds a query that retrieves the total count of resource items available to the current caller.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which criteria is being applied.</typeparam>
    public class TotalCountCriteriaProvider<TEntity> : AggregateRootCriteriaProviderBase<TEntity>, ITotalCountCriteriaProvider<TEntity>
        where TEntity : AggregateRootWithCompositeKey
    {
        public TotalCountCriteriaProvider(
            ISessionFactory sessionFactory,
            IDescriptorResolver descriptorResolver,
            IPersonEntitySpecification personEntitySpecification,
            IPersonTypesProvider personTypesProvider)
            : base(sessionFactory, descriptorResolver, personEntitySpecification, personTypesProvider) { }

        /// <summary>
        /// Get a <see cref="NHibernate.ICriteria"/> query that retrieves the total count of resource items available to the current caller.
        /// </summary>
        /// <param name="specification">An instance of the entity containing parameters to be added to the query.</param>
        /// <param name="queryParameters">The query parameters to be applied to the filtering.</param>
        /// <returns>The NHibernate <see cref="NHibernate.ICriteria"/> instance representing the query.</returns>
        public ICriteria GetCriteriaQuery(TEntity specification, IQueryParameters queryParameters)
        {
            var countQueryCriteria = Session
                .CreateCriteria<TEntity>("aggregateRoot")
                .SetProjection(Projections.CountDistinct<TEntity>(x => x.Id));

            // Add specification-based criteria
            ProcessSpecification(countQueryCriteria, specification);

            // Add special query fields
            ProcessQueryParameters(countQueryCriteria, queryParameters);

            return countQueryCriteria;
        }
    }
}