// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Security;
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
        private readonly IAuthorizationFilteringProvider _authorizationFilteringProvider;
        private readonly IAuthorizationBasisMetadataSelector _authorizationBasisMetadataSelector;
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly IEntityAuthorizer _entityAuthorizer;

        protected RepositoryOperationAuthorizationDecoratorBase(
            IAuthorizationContextProvider authorizationContextProvider,
            IAuthorizationFilteringProvider authorizationFilteringProvider,
            IAuthorizationBasisMetadataSelector authorizationBasisMetadataSelector,
            IApiClientContextProvider apiClientContextProvider,
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IEntityAuthorizer entityAuthorizer)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _authorizationFilteringProvider = authorizationFilteringProvider;
            _authorizationBasisMetadataSelector = authorizationBasisMetadataSelector;
            _apiClientContextProvider = apiClientContextProvider;
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
            _entityAuthorizer = entityAuthorizer;
        }

        /// <summary>
        /// Invokes authorization of the request using the resource/action currently in context.
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeSingleItemAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var action = _authorizationContextProvider.GetAction();

            await AuthorizeSingleItemAsync(entity, action, cancellationToken);
        }

        /// <summary>
        /// Invokes authorization of the request using the resource currently in context but wit 
        /// an override action (e.g. for converting the "Upsert" action to either "Create" or "Update").
        /// </summary>
        /// <param name="entity">The request/entity being authorized.</param>
        /// <param name="actionUri">The action being performed with the request/entity.</param>
        /// <param name="cancellationToken"></param>
        protected async Task AuthorizeSingleItemAsync(TEntity entity, string actionUri, CancellationToken cancellationToken)
        {
            await _entityAuthorizer.AuthorizeEntityAsync(entity, actionUri, cancellationToken);
        }

        protected IReadOnlyList<AuthorizationStrategyFiltering> GetAuthorizationFiltering()
        {
            // Make sure Authorization context is present before proceeding
            _authorizationContextProvider.VerifyAuthorizationContextExists();

            // Build the AuthorizationContext
            var apiClientContext = _apiClientContextProvider.GetApiClientContext();
            var resource = _dataManagementResourceContextProvider.Get().Resource;
            string[] resourceClaimUris = _authorizationContextProvider.GetResourceUris();
            string requestActionUri = _authorizationContextProvider.GetAction();

            var authorizationContext = new EdFiAuthorizationContext(
                apiClientContext,
                resource,
                resourceClaimUris,
                requestActionUri,
                typeof(TEntity));

            // Get authorization filters
            var authorizationBasisMetadata = _authorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata(
                apiClientContext.ClaimSetName,
                resourceClaimUris,
                requestActionUri);

            return _authorizationFilteringProvider.GetAuthorizationFiltering(authorizationContext, authorizationBasisMetadata);
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
