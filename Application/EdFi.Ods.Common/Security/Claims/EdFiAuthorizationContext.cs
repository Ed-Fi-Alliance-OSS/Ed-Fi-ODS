// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.ObjectModel;
using System.Security.Claims;
using EdFi.Ods.Common.Utils.Extensions;

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
        /// <param name="principal">The <see cref="ClaimsPrincipal" /> containing the claims.</param>
        /// <param name="resourceClaimUris">The URI representations of the resource claims being authorized.</param>
        /// <param name="action">The action being taken on the resource.</param>
        /// <param name="data">An object containing the data available for authorization which implements one of the 
        /// model interfaces (e.g. IStudent).</param>
        public EdFiAuthorizationContext(
            ClaimsPrincipal principal,
            string[] resourceClaimUris,
            string action,
            object data)
        {
            Preconditions.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));
            Preconditions.ThrowIfNull(action, nameof(action));

            Principal = principal;
            Data = data;

            resourceClaimUris.ForEach(
                resourceClaimUri =>
                    Resource.Add(new Claim(ClaimsName, resourceClaimUri)));
            
            Action.Add(new Claim(ClaimsName, action));

            if (data != null)
            {
                Type = data.GetType();
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiAuthorizationContext"/> class using the principal, resource, action and Ed-Fi entity type.
        /// </summary>
        /// <param name="principal">The <see cref="ClaimsPrincipal" /> containing the claims.</param>
        /// <param name="resourceClaimUris">The URI representations of the resource claims being authorized.</param>
        /// <param name="action">The action being taken on the resource.</param>
        /// <param name="type">The entity type which implements one of the model interfaces (e.g. IStudent) which is the subject of a multiple-item request.</param>
        public EdFiAuthorizationContext(
            ClaimsPrincipal principal,
            string[] resourceClaimUris,
            string action,
            Type type)
        {
            Preconditions.ThrowIfNull(resourceClaimUris, nameof(resourceClaimUris));
            Preconditions.ThrowIfNull(action, nameof(action));
            Preconditions.ThrowIfNull(type, nameof(type));
            
            Principal = principal;
            Type = type;

            resourceClaimUris.ForEach(
                resourceClaimUri =>
                    Resource.Add(new Claim(ClaimsName, resourceClaimUri)));
            
            Action.Add(new Claim(ClaimsName, action));
        }

        public ClaimsPrincipal Principal { get; }

        /// <summary>
        /// Gets an object containing the data available for authorization which implements one of 
        /// the model interfaces (e.g. IStudent).
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> of the data associated with the request represented by the authorization context.
        /// </summary>
        public Type Type { get; }

        public Collection<Claim> Action { get; } = new Collection<Claim>();

        /// <summary>Gets the resource on which the principal is to be authorized.</summary>
        /// <returns>A collection of URI claims that represent the resource.</returns>
        public Collection<Claim> Resource { get; } = new Collection<Claim>();
    }
}
