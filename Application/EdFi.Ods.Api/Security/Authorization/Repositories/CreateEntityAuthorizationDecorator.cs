﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Authorizes calls to the "CreateEntity" repository method.
    /// </summary>
    /// <typeparam name="TEntity">The Type of entity being created.</typeparam>
    public class CreateEntityAuthorizationDecorator<TEntity>
        : RepositoryOperationAuthorizationDecoratorBase<TEntity>, ICreateEntity<TEntity>
        where TEntity : AggregateRootWithCompositeKey
    {
        private readonly ICreateEntity<TEntity> _next;
        private readonly ISecurityRepository _securityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEntityAuthorizationDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="securityRepository">Provides access to the repository where the claims/actions are stored.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="authorizationFilteringProvider"></param>
        /// <param name="authorizationBasisMetadataSelector"></param>
        /// <param name="apiClientContextProvider"></param>
        /// <param name="dataManagementResourceContextProvider"></param>
        /// <param name="entityAuthorizer"></param>
        public CreateEntityAuthorizationDecorator(
            ICreateEntity<TEntity> next,
            ISecurityRepository securityRepository,
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
            _securityRepository = securityRepository;
        }

        /// <summary>
        /// Authorizes a call to create an entity.
        /// </summary>
        /// <param name="entity">An entity instance that has all the primary key properties assigned with values.</param>
        /// <param name="enforceOptimisticLock"></param>
        /// <returns>The specified entity if found; otherwise null.</returns>
        public async Task CreateAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
        {
            // POST comes in as an "Upsert", but at this point we know it's actually about to create an entity,
            // so we'll use the more explicit action for authorization.
            var createActionUri = _securityRepository.GetActionByName("Create")
                .ActionUri;

            // Authorize the request
            await AuthorizeSingleItemAsync(entity, createActionUri, cancellationToken);

            // Pass the call through to the decorated repository method
            await _next.CreateAsync(entity, enforceOptimisticLock, cancellationToken);
        }
    }
}
