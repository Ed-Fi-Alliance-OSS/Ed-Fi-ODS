// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Features.OwnershipBasedAuthorization.Security
{
    public class OwnershipInitializationCreateEntityDecorator<TEntity>
        : RepositoryOperationAuthorizationDecoratorBase<TEntity>, ICreateEntity<TEntity>
        where TEntity : AggregateRootWithCompositeKey
    {
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly ICreateEntity<TEntity> _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnershipInitializationCreateEntityDecorator{T}"/> class.
        /// </summary>
        /// <param name="next">The decorated instance for which authorization is being performed.</param>
        /// <param name="authorizationContextProvider">Provides access to the authorization context, such as the resource and action.</param>
        /// <param name="apiClientContextProvider"></param>
        /// <param name="entityAuthorizer"></param>
        public OwnershipInitializationCreateEntityDecorator(
            ICreateEntity<TEntity> next,
            IAuthorizationContextProvider authorizationContextProvider,
            IApiClientContextProvider apiClientContextProvider,
            IEntityAuthorizer entityAuthorizer)
            : base(
                authorizationContextProvider,
                entityAuthorizer)
        {
            _next = Preconditions.ThrowIfNull(next, nameof(next));
            _apiClientContextProvider = apiClientContextProvider ?? throw new ArgumentNullException(nameof(apiClientContextProvider));
        }

        public async Task CreateAsync(TEntity entity, bool enforceOptimisticLock, CancellationToken cancellationToken)
        {
            Preconditions.ThrowIfNull(entity, nameof(entity));

            // POST comes in as an "Upsert", but at this point we know it's actually about to create an entity,
            // so we'll use the more explicit action for authorization.
            short? creatorOwnershipTokenId = _apiClientContextProvider.GetApiClientContext().CreatorOwnershipTokenId;

            entity.CreatedByOwnershipTokenId = creatorOwnershipTokenId;

            // Pass the call through to the decorated repository method
            await _next.CreateAsync(entity, enforceOptimisticLock, cancellationToken);
        }
    }
}
