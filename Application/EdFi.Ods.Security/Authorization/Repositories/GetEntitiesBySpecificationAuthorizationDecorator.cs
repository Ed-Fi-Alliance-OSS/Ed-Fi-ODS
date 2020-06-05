// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Security.Authorization.Filtering;
using NHibernate;

namespace EdFi.Ods.Security.Authorization.Repositories
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
        private readonly IGetEntitiesBySpecification<TEntity> _next;
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEntityByKeyAuthorizationDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="sessionFactory">The NHibernate session factory used to manage session (database connection) context.</param>
        /// <param name="authorizationFilterContextProvider">Applies authorization-related filters for the entity on the current NHiberate session.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="authorizationProvider">The component capable of authorizing the request, given necessary context.</param>
        public GetEntitiesBySpecificationAuthorizationDecorator(
            IGetEntitiesBySpecification<TEntity> next,
            ISessionFactory sessionFactory,
            IAuthorizationFilterContextProvider authorizationFilterContextProvider,
            IAuthorizationContextProvider authorizationContextProvider,
            IEdFiAuthorizationProvider authorizationProvider)
            : base(authorizationContextProvider, authorizationProvider)
        {
            _next = next;
            _sessionFactory = sessionFactory;
            _authorizationFilterContextProvider = authorizationFilterContextProvider;
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
            var authorizationFilters = GetAuthorizationFilters<TEntity>();

            // Ensure we've bound an NHibernate session to the current context
            using (new SessionScope(_sessionFactory))
            {
                // Apply authorization filtering to the entity for the current session
                _authorizationFilterContextProvider.SetFilterContext(authorizationFilters);

                // Pass call through to the repository operation implementation to execute the query
                return await _next.GetBySpecificationAsync(specification, queryParameters, cancellationToken);
            }
        }
    }
}
