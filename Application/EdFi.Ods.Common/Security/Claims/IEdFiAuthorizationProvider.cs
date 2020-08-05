// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Defines methods for performing single-item and filter-based authorization appropriate to the claims, resource, action and possibly the entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
    /// </summary>
    public interface IEdFiAuthorizationProvider
    {
        /// <summary>
        /// Authorizes a single-item request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
        /// </summary>
        /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
        Task AuthorizeSingleItemAsync(EdFiAuthorizationContext authorizationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Authorizes a multiple-item read request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
        /// </summary>
        /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
        /// <returns>A collection of filters to be applied to the query.</returns>
        IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(EdFiAuthorizationContext authorizationContext);

        /// <summary>
        /// Performs a claims authorization evaluation on the request related to the resource and action only 
        /// without performing any authorization strategies normally performed for authorization decisions.
        /// </summary>
        /// <param name="authorizationContext">The current authorization context of the request.</param>
        /// <param name="securityExceptionMessage">In the event of authorization failure, will contain the security exception message.</param>
        /// <returns><b>true</b> if the caller is authorized to perform the requested action on the requested resource (without regard to application of authorization strategies); otherwise <b>false</b>.</returns>
        bool TryAuthorizeResourceActionOnly(EdFiAuthorizationContext authorizationContext, out string securityExceptionMessage);

        /// <summary>
        /// Performs a claims authorization evaluation on the request related to the resource and action only 
        /// without performing any authorization strategies normally performed for authorization decisions.
        /// </summary>
        /// <param name="authorizationContext">The current authorization context of the request.</param>
        void AuthorizeResourceActionOnly(EdFiAuthorizationContext authorizationContext);
    }
}
