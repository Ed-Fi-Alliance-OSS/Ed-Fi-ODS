// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
using EdFi.Security.DataAccess.Repositories;
using NHibernate;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Authorizes calls to the "GetEntitiesBySpecification" repository method.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of entity being queried.</typeparam>
    public class GetEntitiesBySpecificationAuthorizationDecorator<TEntity>
        : RepositoryOperationAuthorizationDecoratorBase<TEntity>, IGetEntitiesBySpecification<TEntity>
        where TEntity : class, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IAuthorizationFilterContextProvider _authorizationFilterContextProvider;
        private readonly IViewBasedSingleItemAuthorizationQuerySupport _viewBasedSingleItemAuthorizationQuerySupport;
        private readonly IGetEntitiesBySpecification<TEntity> _next;
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEntityByKeyAuthorizationDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="sessionFactory">The NHibernate session factory used to manage session (database connection) context.</param>
        /// <param name="authorizationFilterContextProvider">Applies authorization-related filters for the entity on the current NHiberate session.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="authorizationFilteringProvider">The component capable of authorizing the request, given necessary context.</param>
        /// <param name="authorizationFilterDefinitionProvider"></param>
        /// <param name="explicitObjectValidators"></param>
        /// <param name="authorizationBasisMetadataSelector"></param>
        /// <param name="securityRepository"></param>
        /// <param name="apiClientContextProvider"></param>
        /// <param name="viewBasedSingleItemAuthorizationQuerySupport"></param>
        /// <param name="dataManagementResourceContextProvider"></param>
        public GetEntitiesBySpecificationAuthorizationDecorator(
            IGetEntitiesBySpecification<TEntity> next,
            ISessionFactory sessionFactory,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IAuthorizationContextProvider authorizationContextProvider,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationFilterDefinitionProvider authorizationFilterDefinitionProvider,
            IExplicitObjectValidator[] explicitObjectValidators,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            ISecurityRepository securityRepository,
            IApiClientContextProvider apiClientContextProvider,
            IViewBasedSingleItemAuthorizationQuerySupport viewBasedSingleItemAuthorizationQuerySupport,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
            : base(
                authorizationContextProvider,
                authorizationFilteringProvider,
                authorizationFilterDefinitionProvider,
                explicitObjectValidators,
                authorizationBasisMetadataSelector,
                securityRepository,
                sessionFactory,
                apiClientContextProvider,
                viewBasedSingleItemAuthorizationQuerySupport,
                dataManagementResourceContextProvider)
        {
            _next = next;
            _sessionFactory = sessionFactory;
            _authorizationFilterContextProvider = authorizationFilterContextProvider;
            _viewBasedSingleItemAuthorizationQuerySupport = viewBasedSingleItemAuthorizationQuerySupport;
        }

        /// <summary>
        /// Authorizes a call to get multiple entities using an open query specification.
        /// </summary>
        /// <param name="specification">An entity instance that has all the primary key properties assigned with values.</param>
        /// <param name="queryParameters">The additional query parameter to apply the results (e.g. paging, sorting).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of matching resources, or an empty result.</returns>
        public async Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(
            TEntity specification,
            IQueryParameters queryParameters,
            CancellationToken cancellationToken)
        {
            // Use the authorization subsystem to set filtering context
            var authorizationFiltering = GetAuthorizationFiltering();

            // Ensure we've bound an NHibernate session to the current context
            using (new SessionScope(_sessionFactory))
            {
                // Apply authorization filtering to the entity for the current session
                _authorizationFilterContextProvider.SetFilterContext(authorizationFiltering);

                // Pass call through to the repository operation implementation to execute the query
                return await _next.GetBySpecificationAsync(specification, queryParameters, cancellationToken);
            }
        }
    }
}
