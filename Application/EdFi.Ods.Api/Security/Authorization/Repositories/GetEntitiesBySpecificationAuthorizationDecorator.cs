// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Authorization;
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
        where TEntity : class, IHasIdentifier, IDateVersionedEntity, IMappable
    {
        private readonly IContextProvider<DataManagementAuthorizationPlan> _authorizationPlanContextProvider;
        private readonly IDataManagementAuthorizationPlanFactory _dataManagementAuthorizationPlanFactory;
        private readonly IGetEntitiesBySpecification<TEntity> _next;
        private readonly ISessionFactory _sessionFactory;
        private readonly Lazy<string> _readActionUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEntityByKeyAuthorizationDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="sessionFactory">The NHibernate session factory used to manage session (database connection) context.</param>
        /// <param name="authorizationPlanContextProvider">Sets the authorization plan into context.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="dataManagementAuthorizationPlanFactory">The component capable of authorizing the request, given necessary context.</param>
        /// <param name="entityAuthorizer"></param>
        /// <param name="securityRepository"></param>
        public GetEntitiesBySpecificationAuthorizationDecorator(
            IGetEntitiesBySpecification<TEntity> next,
            ISessionFactory sessionFactory,
            IContextProvider<DataManagementAuthorizationPlan> authorizationPlanContextProvider,
            IAuthorizationContextProvider authorizationContextProvider,
            IDataManagementAuthorizationPlanFactory dataManagementAuthorizationPlanFactory,
            IEntityAuthorizer entityAuthorizer,
            ISecurityRepository securityRepository)
            : base(
                authorizationContextProvider,
                entityAuthorizer)
        {
            _next = next;
            _sessionFactory = sessionFactory;
            _authorizationPlanContextProvider = authorizationPlanContextProvider;
            _dataManagementAuthorizationPlanFactory = dataManagementAuthorizationPlanFactory;

            _readActionUri = new Lazy<string>(() => securityRepository.GetActionByName("Read").ActionUri);
        }

        /// <summary>
        /// Authorizes a call to get multiple entities using an open query specification.
        /// </summary>
        /// <param name="specification">An entity instance that has all the primary key properties assigned with values.</param>
        /// <param name="queryParameters">The additional query parameter to apply the results (e.g. paging, sorting).</param>
        /// <param name="additionalQueryParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of matching resources, or an empty result.</returns>
        public async Task<GetBySpecificationResult<TEntity>> GetBySpecificationAsync(
            TEntity specification,
            IQueryParameters queryParameters,
            IDictionary<string, string> additionalQueryParameters,
            CancellationToken cancellationToken)
        {
            // Use the authorization subsystem to set filtering context
            var authorizationPlan = _dataManagementAuthorizationPlanFactory.CreateAuthorizationPlan(_readActionUri.Value);

            // Ensure we've bound an NHibernate session to the current context
            using (new SessionScope(_sessionFactory))
            {
                // Set the authorization plan into context
                _authorizationPlanContextProvider.Set(authorizationPlan);

                // Pass call through to the repository operation implementation to execute the query
                return await _next.GetBySpecificationAsync(
                    specification,
                    queryParameters,
                    additionalQueryParameters,
                    cancellationToken);
            }
        }
    }
}
