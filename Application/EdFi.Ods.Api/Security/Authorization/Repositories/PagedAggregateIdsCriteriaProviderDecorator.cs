// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Providers.Criteria;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Applies authorization filtering criteria to the paged queries.
    /// </summary>
    /// <typeparam name="TEntity">The type of the aggregate root entity being queried.</typeparam>
    public class PagedAggregateIdsCriteriaProviderAuthorizationDecorator<TEntity>
        : AggregateRootCriteriaProviderAuthorizationDecoratorBase<TEntity>, IPagedAggregateIdsCriteriaProvider<TEntity>
        where TEntity : class
    {
        public PagedAggregateIdsCriteriaProviderAuthorizationDecorator(
            IPagedAggregateIdsCriteriaProvider<TEntity> decoratedInstance,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider)
            : base(
                decoratedInstance,
                authorizationFilterContextProvider,
                authorizationFilterDefinitionProvider) { }
    }
}
