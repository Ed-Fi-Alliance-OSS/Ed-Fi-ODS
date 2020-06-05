// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Models;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.Authorization.Pipeline
{
    /// <summary>
    /// Sets the resource and action values into the current context for downstream authorization activities.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TResourceModel"></typeparam>
    /// <typeparam name="TEntityModel"></typeparam>
    public abstract class SetAuthorizationContextBase<TContext, TResult, TResourceModel, TEntityModel>
        : IStep<TContext, TResult>
        where TContext : class
        where TResult : class
    {
        protected readonly IAuthorizationContextProvider AuthorizationContextProvider;
        protected readonly ISecurityRepository SecurityRepository;
        protected readonly IResourceClaimUriProvider ResourceClaimUriProvider;

        protected SetAuthorizationContextBase(
            IAuthorizationContextProvider authorizationContextProvider, 
            ISecurityRepository securityRepository,
            IResourceClaimUriProvider resourceClaimUriProvider)
        {
            AuthorizationContextProvider = Preconditions.ThrowIfNull(authorizationContextProvider, nameof(authorizationContextProvider));
            SecurityRepository = Preconditions.ThrowIfNull(securityRepository, nameof(securityRepository));
            ResourceClaimUriProvider = Preconditions.ThrowIfNull(resourceClaimUriProvider, nameof(resourceClaimUriProvider));
        }

        protected abstract string Action { get; }

        public Task ExecuteAsync(TContext context, TResult result, CancellationToken cancellationToken)
        {
            Preconditions.ThrowIfNull(context, nameof(context));
            Preconditions.ThrowIfNull(result, nameof(result));
            
            AuthorizationContextProvider.SetResourceUris(
                ResourceClaimUriProvider.GetResourceClaimUris(typeof(TResourceModel)));
            
            AuthorizationContextProvider.SetAction(Action);

            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Sets the action to Read in context for downstream authorization processing.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TResourceModel"></typeparam>
    /// <typeparam name="TEntityModel"></typeparam>
    public class SetAuthorizationContextForGet<TContext, TResult, TResourceModel, TEntityModel>
        : SetAuthorizationContextBase<TContext, TResult, TResourceModel, TEntityModel>
        where TContext : class
        where TResult : class
    {
        public SetAuthorizationContextForGet(
            IAuthorizationContextProvider authorizationContextProvider, 
            ISecurityRepository securityRepository,
            IResourceClaimUriProvider resourceClaimUriProvider)
            : base(authorizationContextProvider, securityRepository, resourceClaimUriProvider) { }

        protected override string Action
        {
            get => SecurityRepository.GetActionByName("Read").ActionUri;
        }
    }

    /// <summary>
    /// Sets the action to Update in context for downstream authorization processing.
    /// </summary>
    public class SetAuthorizationContextForPut<TContext, TResult, TResourceModel, TEntityModel>
        : SetAuthorizationContextBase<TContext, TResult, TResourceModel, TEntityModel>
        where TContext : class
        where TResult : class
    {
        public SetAuthorizationContextForPut(
            IAuthorizationContextProvider authorizationContextProvider, 
            ISecurityRepository securityRepository,
            IResourceClaimUriProvider resourceClaimUriProvider)
            : base(authorizationContextProvider, securityRepository, resourceClaimUriProvider) { }

        protected override string Action
        {
            get => SecurityRepository.GetActionByName("Update").ActionUri;
        }
    }

    /// <summary>
    /// Sets the action to Upsert in context for downstream authorization processing.
    /// </summary>
    public class SetAuthorizationContextForPost<TContext, TResult, TResourceModel, TEntityModel>
        : SetAuthorizationContextBase<TContext, TResult, TResourceModel, TEntityModel>
        where TContext : class
        where TResult : class
    {
        public SetAuthorizationContextForPost(
            IAuthorizationContextProvider authorizationContextProvider, 
            ISecurityRepository securityRepository,
            IResourceClaimUriProvider resourceClaimUriProvider)
            : base(authorizationContextProvider, securityRepository, resourceClaimUriProvider) { }

        protected override string Action
        {
            get => "Upsert";
        }
    }

    /// <summary>
    /// Sets the action to Delete in context for downstream authorization processing.
    /// </summary>
    public class SetAuthorizationContextForDelete<TContext, TResult, TResourceModel, TEntityModel>
        : SetAuthorizationContextBase<TContext, TResult, TResourceModel, TEntityModel>
        where TContext : class
        where TResult : class
    {
        public SetAuthorizationContextForDelete(
            IAuthorizationContextProvider authorizationContextProvider, 
            ISecurityRepository securityRepository,
            IResourceClaimUriProvider resourceClaimUriProvider)
            : base(authorizationContextProvider, securityRepository, resourceClaimUriProvider) { }

        protected override string Action
        {
            get => SecurityRepository.GetActionByName("Delete").ActionUri;
        }
    }

    public class SetAuthorizationContextForGetDeletedResourceIds<TContext, TResult, TResourceModel, TEntityModel>
        : SetAuthorizationContextBase<TContext, TResult, TResourceModel, TEntityModel>
        where TContext : class
        where TResult : class
    {
        public SetAuthorizationContextForGetDeletedResourceIds(
            IAuthorizationContextProvider authorizationContextProvider, 
            ISecurityRepository securityRepository,
            IResourceClaimUriProvider resourceClaimUriProvider)
            : base(authorizationContextProvider, securityRepository, resourceClaimUriProvider) { }

        protected override string Action
        {
            get => SecurityRepository.GetActionByName("Read").ActionUri;
        }
    }
}
