// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using EdFi.Common;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Provides an Ed-Fi-specific authorization context for making authorization decisions.
    /// </summary>
    public class EdFiAuthorizationContext
    {
        private const string ClaimsName = "http://edfi.org/v3/identity/claims/name";

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiAuthorizationContext"/> class using the principal, resource, action and Ed-Fi authorization context data.
        /// </summary>
        /// <param name="apiClientContext">Direct information about the current API client, typically presented as claims.</param>
        /// <param name="resource">The semantic model's representation of the resource being authorized.</param>
        /// <param name="resourceClaimUris">The URI representations of the resource claims being authorized.</param>
        /// <param name="action">The action being taken on the resource.</param>
        /// <param name="data">An object containing the data available for authorization which implements one of the
        /// model interfaces (e.g. IStudent).</param>
        /// <param name="authorizationPhase">Indicates the phase of authorization to be performed on the <see cref="data" /> (as the existing or proposed entity).</param>
        public EdFiAuthorizationContext(
            ApiClientContext apiClientContext,
            Resource resource,
            string[] resourceClaimUris,
            string action,
            object data,
            AuthorizationPhase authorizationPhase)
        {
            Preconditions.ThrowIfNull(apiClientContext, nameof(apiClientContext));
            Preconditions.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));
            Preconditions.ThrowIfNull(action, nameof(action));

            ApiClientContext = apiClientContext;
            Data = data;
            Resource = resource;
            ResourceClaimUris = resourceClaimUris;
            Action = action;
            AuthorizationPhase = authorizationPhase;

            if (data != null)
            {
                Type = data.GetType();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiAuthorizationContext"/> class using the principal, resource, action and Ed-Fi entity type.
        /// </summary>
        /// <param name="apiClientContext">Direct information about the current API client, typically presented as claims.</param>
        /// <param name="resource">The semantic model's representation of the resource being authorized.</param>
        /// <param name="resourceClaimUris">The URI representations of the resource claims being authorized.</param>
        /// <param name="action">The action being taken on the resource.</param>
        /// <param name="type">The entity type which implements one of the model interfaces (e.g. IStudent) which is the subject of a multiple-item request.</param>
        public EdFiAuthorizationContext(
            ApiClientContext apiClientContext,
            Resource resource,
            string[] resourceClaimUris,
            string action,
            Type type)
        {
            Preconditions.ThrowIfNull(apiClientContext, nameof(apiClientContext));
            Preconditions.ThrowIfNull(resource, nameof(resource));
            Preconditions.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));
            Preconditions.ThrowIfNull(action, nameof(action));
            Preconditions.ThrowIfNull(type, nameof(type));

            ApiClientContext = apiClientContext;
            Type = type;
            Resource = resource;
            ResourceClaimUris = resourceClaimUris;
            Action = action;
        }

        public ApiClientContext ApiClientContext { get; }

        /// <summary>
        /// Gets an object containing the data available for authorization which implements one of
        /// the model interfaces (e.g. IStudent).
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Indicates whether the entity instance in the <see cref="Data" /> property represents an existing entity (loaded
        /// from the database), or the proposed entity.
        /// </summary>
        public AuthorizationPhase AuthorizationPhase { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> of the data associated with the request represented by the authorization context.
        /// </summary>
        public Type Type { get; }

        public string Action { get; }

        /// <summary>Gets the resource on which the principal is to be authorized.</summary>
        /// <returns>A collection of URI claims that represent the resource.</returns>
        public string[] ResourceClaimUris { get; }
        
        /// <summary>
        /// The semantic model's representation of the resource being authorized.
        /// </summary>
        public Resource Resource { get; }
    }
}
