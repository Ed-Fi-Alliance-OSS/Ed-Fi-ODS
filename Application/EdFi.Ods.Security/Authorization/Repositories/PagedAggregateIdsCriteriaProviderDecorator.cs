// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Common.Providers.Criteria;
using EdFi.Ods.Security.Authorization.Filtering;

namespace EdFi.Ods.Security.Authorization.Repositories
{
    /// <summary>
    /// Applies authorization filtering criteria to the paged queries.
    /// </summary>
    /// <typeparam name="TEntity">The type of the aggregate root entity being queried.</typeparam>
    public class PagedAggregateIdsCriteriaProviderDecorator<TEntity>
        : AggregateRootCriteriaProviderDecoratorBase<TEntity>, IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        public PagedAggregateIdsCriteriaProviderDecorator(
            IPagedAggregateIdsCriteriaProvider<TEntity> decoratedInstance,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IFilterCriteriaApplicatorProvider authorizationCriteriaApplicatorProvider)
            : base(decoratedInstance, authorizationFilterContextProvider, authorizationCriteriaApplicatorProvider) { }
    }
}
