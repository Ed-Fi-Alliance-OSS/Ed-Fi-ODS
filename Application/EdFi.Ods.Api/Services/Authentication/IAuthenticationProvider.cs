// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace EdFi.Ods.Api.Services.Authentication
{
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Authenticates api requests and sets the correct claims identity into the <see cref="HttpAuthenticationContext"/>.
        /// </summary>
        /// <param name="context">The authentication context to be used in making the authentication decision.</param>
        /// <param name="cancellationToken">The cancellation token associated with the request.</param>
        Task Authenticate(HttpAuthenticationContext context, CancellationToken cancellationToken);

        /// <summary>
        /// Adds an authentication challenge to the HTTP response in the case of a 401 errror.
        /// </summary>
        /// <param name="context">The authentication challenge context to be used in making the decision to return a WwwAuthenticate header.</param>
        /// <param name="cancellationToken">The cancellation token associated with the request.</param>
        Task Challenge(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken);
    }
}
