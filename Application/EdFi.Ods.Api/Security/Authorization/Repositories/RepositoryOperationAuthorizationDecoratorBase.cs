// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.Repositories
{
    /// <summary>
    /// Provides an abstract base class for authorization decorators to use for invoking 
    /// authorization.
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="Type"/> of the entity/request.</typeparam>
    public abstract class RepositoryOperationAuthorizationDecoratorBase<TEntity>
        where TEntity : class
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IEntityAuthorizer _entityAuthorizer;

        protected RepositoryOperationAuthorizationDecoratorBase(
            IAuthorizationContextProvider authorizationContextProvider,
            IEntityAuthorizer entityAuthorizer)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _entityAuthorizer = entityAuthorizer;
        }

        /// <summary>
        /// Invokes authorization of the request using the supplied (existing) entity and the resource/action currently in context for request.
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeExistingSingleItemAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var action = _authorizationContextProvider.GetAction();

            await _entityAuthorizer.AuthorizeEntityAsync(entity, action, AuthorizationPhase.ExistingData, cancellationToken);
        }

        /// <summary>
        /// Invokes authorization of the request using the resource currently in context but wit 
        /// an override action (e.g. for converting the "Upsert" action to either "Create" or "Update").
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="actionUri">The action being performed with the request/entity.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeProposedSingleItemAsync(TEntity entity, string actionUri, CancellationToken cancellationToken)
        {
            await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, AuthorizationPhase.ProposedData, cancellationToken);
        }
    }
    
    public class FilterAuthorizationResult
    {
        public AuthorizationFilterDefinition FilterDefinition { get; set; }

        public AuthorizationFilterContext FilterContext { get; set; }

        public InstanceAuthorizationResult Result { get; set; }
    }

    public class AuthorizationStrategyFilterResults
    {
        public string AuthorizationStrategyName { get; set; }

        public FilterOperator Operator { get; set; }

        public FilterAuthorizationResult[] FilterResults { get; set; }
    }
}
