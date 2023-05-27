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
        /// <param name="apiKeyContext">Direct information about the current API client, typically presented as claims.</param>
        /// <param name="claimSetClaims"></param>
        /// <param name="resource">The semantic model's representation of the resource being authorized.</param>
        /// <param name="resourceClaimUris">The URI representations of the resource claims being authorized.</param>
        /// <param name="action">The action being taken on the resource.</param>
        /// <param name="data">An object containing the data available for authorization which implements one of the
        /// model interfaces (e.g. IStudent).</param>
        public EdFiAuthorizationContext(
            ApiKeyContext apiKeyContext,
            IList<EdFiResourceClaim> claimSetClaims,
            Resource resource,
            string[] resourceClaimUris,
            string action,
            object data)
        {
            Preconditions.ThrowIfNull(apiKeyContext, nameof(apiKeyContext));
            Preconditions.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));
            Preconditions.ThrowIfNull(action, nameof(action));

            ApiKeyContext = apiKeyContext;
            ClaimSetClaims = claimSetClaims;
            Data = data;
            Resource = resource;
            ResourceClaimUris = resourceClaimUris;
            Action = action;

            if (data != null)
            {
                Type = data.GetType();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiAuthorizationContext"/> class using the principal, resource, action and Ed-Fi entity type.
        /// </summary>
        /// <param name="apiKeyContext">Direct information about the current API client, typically presented as claims.</param>
        /// <param name="claimSetClaims"></param>
        /// <param name="resource">The semantic model's representation of the resource being authorized.</param>
        /// <param name="resourceClaimUris">The URI representations of the resource claims being authorized.</param>
        /// <param name="action">The action being taken on the resource.</param>
        /// <param name="type">The entity type which implements one of the model interfaces (e.g. IStudent) which is the subject of a multiple-item request.</param>
        public EdFiAuthorizationContext(
            ApiKeyContext apiKeyContext,
            IList<EdFiResourceClaim> claimSetClaims,
            Resource resource,
            string[] resourceClaimUris,
            string action,
            Type type)
        {
            Preconditions.ThrowIfNull(apiKeyContext, nameof(apiKeyContext));
            Preconditions.ThrowIfNull(resource, nameof(resource));
            Preconditions.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));
            Preconditions.ThrowIfNull(action, nameof(action));
            Preconditions.ThrowIfNull(type, nameof(type));

            ApiKeyContext = apiKeyContext;
            ClaimSetClaims = claimSetClaims;
            Type = type;
            Resource = resource;
            ResourceClaimUris = resourceClaimUris;
            Action = action;
        }

        public ApiKeyContext ApiKeyContext { get; }

        public IList<EdFiResourceClaim> ClaimSetClaims { get; }

        /// <summary>
        /// Gets an object containing the data available for authorization which implements one of
        /// the model interfaces (e.g. IStudent).
        /// </summary>
        public object Data { get; }

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
