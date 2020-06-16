// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using EdFi.Ods.Api.NHibernate.Architecture.Criteria;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Security.Authorization.Filtering;

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Applies authorization filtering criteria to the "total count" queries.
    /// </summary>
    /// <typeparam name="TEntity">The type of the aggregate root entity being queried.</typeparam>
    public class TotalCountCriteriaProviderDecorator<TEntity>
        : AggregateRootCriteriaProviderDecoratorBase<TEntity>, ITotalCountCriteriaProvider<TEntity>
        where TEntity : class
    {
        public TotalCountCriteriaProviderDecorator(
            ITotalCountCriteriaProvider<TEntity> decoratedInstance,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IFilterCriteriaApplicatorProvider authorizationCriteriaApplicatorProvider)
            : base(decoratedInstance, authorizationFilterContextProvider, authorizationCriteriaApplicatorProvider) { }
    }
}
