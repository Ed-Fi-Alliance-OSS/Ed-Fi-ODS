// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Authorizes calls to the "GetById" repository method.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of entity being queried.</typeparam>
    public class GetEntityByIdAuthorizationDecorator<TEntity>
        : RepositoryOperationAuthorizationDecoratorBase<TEntity>, IGetEntityById<TEntity>
        where TEntity : class, IHasIdentifier, IDateVersionedEntity
    {
        private readonly IGetEntityById<TEntity> _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEntityByIdAuthorizationDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="authorizationFilteringProvider"></param>
        /// <param name="authorizationBasisMetadataSelector"></param>
        /// <param name="apiClientContextProvider"></param>
        /// <param name="dataManagementResourceContextProvider"></param>
        /// <param name="entityAuthorizer"></param>
        public GetEntityByIdAuthorizationDecorator(
            IGetEntityById<TEntity> next,
            IAuthorizationContextProvider authorizationContextProvider,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            IApiClientContextProvider apiClientContextProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IEntityAuthorizer entityAuthorizer)
            : base(
                authorizationContextProvider,
                authorizationFilteringProvider,
                authorizationBasisMetadataSelector,
                apiClientContextProvider,
                dataManagementResourceContextProvider,
                entityAuthorizer)
        {
            _next = next;
        }

        /// <summary>
        /// Authorizes a call to get a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The value of the unique identifier.</param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        /// <remarks>The <see cref="DeleteEntityByIdAuthorizationDecorator{T}"/> depends on this 
        /// authorization invocation, and runs with a authorization context of "Delete".</remarks>
        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // Pass the call through to the decorated repository method to get the entity
            // to then determine if it can be returned to the caller.
            var entity = await _next.GetByIdAsync(id, cancellationToken);

            // If found, authorize access to the located entity
            if (entity != null)
            {
                await AuthorizeSingleItemAsync(entity, cancellationToken);
            }

            return entity;
        }
    }
}
